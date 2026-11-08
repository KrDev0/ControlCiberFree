Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks

''' <summary>
''' Un solo socket UDP recibe las capturas de TODOS los clientes y las reparte
''' por IP de origen. Así se pueden abrir varios visores a la vez sin el
''' error "dirección ya en uso" y sin perder tramas.
''' Protocolo del cliente: "TOTAL:&lt;n&gt;" + fragmentos con prefijo D5, todo UTF8.
''' </summary>
Public Module ScreenHub
    Private _cli As UdpClient
    Private _port As Integer = -1
    Private _cts As CancellationTokenSource
    Private _lock As New Object()

    Private Class FrameBuf
        Public Total As Integer = -1
        Public Parts As New Dictionary(Of Integer, Byte())()
        Public Inicio As DateTime = DateTime.Now
    End Class

    Private _subs As New Dictionary(Of String, Action(Of Byte()))()
    Private _bufs As New Dictionary(Of String, FrameBuf)()
    Private _seen As New Dictionary(Of String, DateTime)()
    Private _estadoBloqueado As New Dictionary(Of String, Boolean)()

    Public Event EstadoClienteRecibido(ip As String, bloqueado As Boolean)
    Public Event SesionClientePausada(ip As String, inicio As DateTime, fin As DateTime, pausaDesde As DateTime)

    Public Sub Ensure(puerto As Integer)
        SyncLock _lock
            If _cli IsNot Nothing AndAlso _port = puerto Then Return
            Try
                If _cts IsNot Nothing Then _cts.Cancel()
            Catch
            End Try
            Try
                If _cli IsNot Nothing Then _cli.Close()
            Catch
            End Try
            _port = puerto
            _cts = New CancellationTokenSource()
            _cli = New UdpClient(puerto)
            _cli.Client.ReceiveTimeout = 2000
            Dim tok = _cts.Token
            Task.Run(Sub() LoopRecibir(tok))
        End SyncLock
    End Sub

    Public Sub Subscribe(ip As String, cb As Action(Of Byte()))
        SyncLock _lock
            _subs(ip.Trim()) = cb
            _bufs(ip.Trim()) = New FrameBuf()
        End SyncLock
    End Sub

    Public Sub Unsubscribe(ip As String)
        SyncLock _lock
            _subs.Remove(ip.Trim())
            _bufs.Remove(ip.Trim())
        End SyncLock
    End Sub

    ''' <summary>Últimos remitentes vistos (cualquier IP), para diagnosticar llegada de tramas.</summary>
    Public Function Remitentes() As Dictionary(Of String, DateTime)
        SyncLock _lock
            Return New Dictionary(Of String, DateTime)(_seen)
        End SyncLock
    End Function

    Public Function EstadoBloqueo(ip As String) As Nullable(Of Boolean)
        SyncLock _lock
            Dim valor As Boolean
            If _estadoBloqueado.TryGetValue(If(ip, "").Trim(), valor) Then Return New Nullable(Of Boolean)(valor)
            Return Nothing
        End SyncLock
    End Function

    Private Sub LoopRecibir(tok As CancellationToken)
        Dim ep As New IPEndPoint(IPAddress.Any, _port)
        While Not tok.IsCancellationRequested
            Try
                Dim datos As Byte() = _cli.Receive(ep)
                If datos Is Nothing OrElse datos.Length = 0 Then Continue While
                Dim fromIp As String = ep.Address.ToString()
                SyncLock _lock
                    _seen(fromIp) = DateTime.Now
                End SyncLock
                Dim mensaje As String = Encoding.UTF8.GetString(datos).Trim()
                If mensaje.StartsWith("ESTADO:", StringComparison.OrdinalIgnoreCase) Then
                    Dim partes As String() = mensaje.Split(":"c)
                    Dim estado As String = If(partes.Length > 1, partes(1).Trim().ToUpperInvariant(), "")
                    If estado = "BLOQUEADO" OrElse estado = "EN_USO" Then
                        Dim bloqueado As Boolean = estado = "BLOQUEADO"
                        SyncLock _lock
                            _estadoBloqueado(fromIp) = bloqueado
                        End SyncLock
                        Try : RaiseEvent EstadoClienteRecibido(fromIp, bloqueado) : Catch : End Try
                    ElseIf estado = "PAUSADO" AndAlso partes.Length >= 5 Then
                        Dim inicioTicks, finTicks, pausaTicks As Long
                        If Long.TryParse(partes(2), inicioTicks) AndAlso Long.TryParse(partes(3), finTicks) AndAlso Long.TryParse(partes(4), pausaTicks) Then
                            Dim inicio As New DateTime(inicioTicks)
                            Dim fin As DateTime = If(finTicks = DateTime.MinValue.Ticks, DateTime.MinValue, New DateTime(finTicks))
                            Dim pausaDesde As New DateTime(pausaTicks)
                            SyncLock _lock
                                _estadoBloqueado(fromIp) = True
                            End SyncLock
                            Try : RaiseEvent SesionClientePausada(fromIp, inicio, fin, pausaDesde) : Catch : End Try
                            Try : RaiseEvent EstadoClienteRecibido(fromIp, True) : Catch : End Try
                        End If
                    End If
                    Continue While
                End If
                Dim cb As Action(Of Byte()) = Nothing
                SyncLock _lock
                    If Not _subs.TryGetValue(fromIp, cb) Then Continue While
                End SyncLock
                Dim frame As Byte() = Procesar(fromIp, datos)
                If frame IsNot Nothing AndAlso cb IsNot Nothing Then
                    Try : cb(frame) : Catch : End Try
                End If
            Catch ex As SocketException
                Continue While ' timeout: seguir escuchando
            Catch ex As ObjectDisposedException
                Exit While
            Catch
                If tok.IsCancellationRequested Then Exit While
                Thread.Sleep(500)
            End Try
        End While
    End Sub

    Private Function Procesar(fromIp As String, datos As Byte()) As Byte()
        If datos.Length >= 7 Then
            Dim head As String = Encoding.UTF8.GetString(datos, 0, Math.Min(32, datos.Length))
            If head.StartsWith("TOTAL:") Then
                Dim n As Integer
                If Integer.TryParse(head.Substring(6).Trim(), n) AndAlso n > 0 AndAlso n < 5000 Then
                    SyncLock _lock
                        If Not _bufs.ContainsKey(fromIp) Then _bufs(fromIp) = New FrameBuf()
                        _bufs(fromIp).Total = n
                        _bufs(fromIp).Parts.Clear()
                        _bufs(fromIp).Inicio = DateTime.Now
                    End SyncLock
                End If
                Return Nothing
            End If
        End If
        If datos.Length < 6 Then Return Nothing
        Dim idx As Integer
        If Not Integer.TryParse(Encoding.UTF8.GetString(datos, 0, 5), idx) Then Return Nothing
        Dim payload(datos.Length - 6) As Byte
        Array.Copy(datos, 5, payload, 0, payload.Length)
        SyncLock _lock
            If Not _bufs.ContainsKey(fromIp) Then Return Nothing
            Dim b = _bufs(fromIp)
            ' A 1 fps, un parcial de más de 4 s es de otro cuadro mezclado: se descarta.
            If (DateTime.Now - b.Inicio).TotalSeconds > 4 Then
                b.Parts.Clear()
                b.Total = -1
                Return Nothing
            End If
            b.Parts(idx) = payload
            If b.Total > 0 AndAlso b.Parts.Count >= b.Total Then
                Using ms As New MemoryStream()
                    For i As Integer = 0 To b.Total - 1
                        If Not b.Parts.ContainsKey(i) Then Return Nothing
                        ms.Write(b.Parts(i), 0, b.Parts(i).Length)
                    Next
                    b.Parts.Clear()
                    b.Total = -1
                    Return ms.ToArray()
                End Using
            End If
        End SyncLock
        Return Nothing
    End Function
End Module
