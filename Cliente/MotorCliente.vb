Imports System.Net.Sockets
Imports System.Net
Imports System.Text
Imports System.Drawing.Imaging
Imports System.IO

''' <summary>
''' Motor del cliente: escucha comandos UDP del servidor y ejecuta.
''' Sin ventana de configuración: todo llega por SETCFG y se guarda cifrado.
''' </summary>
Public Class MotorCliente
    Private ORDENADOR As UdpClient
    Private MIARRAY As String()
    Private HORAINICIO As DateTime
    Public HORALIMITE As DateTime = DateTime.MinValue
    Private AVISADO As Boolean = False
    Private _ultimoServidor As String = ""

    ''' <summary>Instancia vigente (la crea Arranque). Permite leer el tiempo restante desde la UI.</summary>
    Public Shared Instancia As MotorCliente

    Public Shared Function TiempoRestante() As TimeSpan
        Try
            If Instancia Is Nothing OrElse Instancia.HORALIMITE = DateTime.MinValue Then Return TimeSpan.Zero
            Dim r As TimeSpan = Instancia.HORALIMITE - DateTime.Now
            If r.Ticks < 0 Then Return TimeSpan.Zero
            Return r
        Catch
            Return TimeSpan.Zero
        End Try
    End Function

    Private WithEvents tMsg As New Timer()
    Private WithEvents tMin As New Timer()
    Private WithEvents tCap As New Timer()
    Private _framesSent As Long = 0
    Private _capTick As Integer = 0

    Private Sub Log(msg As String)
        Try
            Dim lp As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cliente.log")
            Dim fi As New IO.FileInfo(lp)
            If fi.Exists AndAlso fi.Length > 102400 Then IO.File.WriteAllText(lp, "")
            IO.File.AppendAllText(lp, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & " " & msg & vbCrLf)
        Catch
        End Try
    End Sub

    Public Sub Iniciar()
        AbrirSocket()
        Log("arranque v4.9 puerto=" & ClienteCfg.Puerto.ToString() &
            " servidor=" & If(ClienteCfg.IpServidor = "", "(vacio)", ClienteCfg.IpServidor))
        PantallaBlo.DESBLOQUEO = False
        PantallaBlo.Show()
        tMsg.Interval = Math.Max(1, ClienteCfg.TiempoMensaje) * 1000
        tMsg.Start()
        tCap.Interval = 1000 ' ~1 cuadro/seg: casi tiempo real en LAN
        tCap.Start()
    End Sub

    Private Sub AbrirSocket()
        Try
            If ORDENADOR IsNot Nothing Then
                Try : ORDENADOR.Close() : Catch : End Try
            End If
            ORDENADOR = New UdpClient(ClienteCfg.Puerto)
            ORDENADOR.Client.Blocking = False
        Catch
            ORDENADOR = Nothing
        End Try
    End Sub

    '================ RECEPCIÓN =================
    Private Sub tMsg_Tick(sender As Object, e As EventArgs) Handles tMsg.Tick
        Try
            If ORDENADOR Is Nothing Then Return
            If ORDENADOR.Available <= 0 Then Return
            Dim IP As New IPEndPoint(IPAddress.Any, 0)
            Dim raw As Byte() = ORDENADOR.Receive(IP)
            _ultimoServidor = IP.Address.ToString()
            ' Límite a 3 partes: el texto del mensaje puede contener ':'.
            MIARRAY = Encoding.UTF8.GetString(raw).Split(New Char() {":"c}, 3)
            If MIARRAY IsNot Nothing AndAlso MIARRAY.Length >= 1 Then EJECUTA()
        Catch ex As SocketException
        Catch
        End Try
    End Sub

    Public Sub EJECUTA()
        If MIARRAY Is Nothing OrElse MIARRAY.Length = 0 Then Return
        Select Case MIARRAY(0).Trim().ToUpperInvariant()
            Case "INICIAR"
                If MIARRAY.Length < 3 Then Return
                Dim h, m As Integer
                Integer.TryParse(MIARRAY(1), h) : Integer.TryParse(MIARRAY(2), m)
                HORAINICIO = DateTime.Now
                TiempoServ.LabelINICIO.Text = HORAINICIO.ToLongTimeString
                HORALIMITE = HORAINICIO.AddMinutes(h * 60 + m)
                TiempoServ.LabelLIMITE.Text = HORALIMITE.ToLongTimeString
                AVISADO = False
                PantallaBlo.DESBLOQUEO = True
                Try : PantallaBlo.Close() : Catch : End Try
                TiempoServ.Show()
                tMin.Interval = 15000
                tMin.Start()
            Case "AÑADIR"
                If MIARRAY.Length < 3 Then Return
                Dim h, m As Integer
                Integer.TryParse(MIARRAY(1), h) : Integer.TryParse(MIARRAY(2), m)
                HORALIMITE = HORALIMITE.AddMinutes(h * 60 + m)
                Try : TiempoServ.LabelLIMITE.Text = HORALIMITE.ToLongTimeString : Catch : End Try
            Case "BLOQUEO"
                tMin.Stop()
                Try : TiempoServ.Close() : Catch : End Try
                Try : Mensaje.Close() : Catch : End Try
                PantallaBlo.DESBLOQUEO = False
                PantallaBlo.Show()
            Case "DESBLOQUEAR"
                HORAINICIO = DateTime.Now
                Try : TiempoServ.LabelINICIO.Text = HORAINICIO.ToLongTimeString : Catch : End Try
                tMin.Stop()
                Try : TiempoServ.Close() : Catch : End Try
                Try : Mensaje.Close() : Catch : End Try
                PantallaBlo.DESBLOQUEO = True
                Try : PantallaBlo.Close() : Catch : End Try
                TiempoServ.Show()
                tMin.Interval = 15000
                tMin.Start()
            Case "MENSAJE"
                Mensaje.TextBoxMENSAJES.Text = If(MIARRAY.Length >= 2, MIARRAY(1), "")
                Mensaje.Show()
            Case "REINICIAR"
                CERRAR()
                Process.Start("shutdown", "/r /f /t 5")
            Case "APAGAR"
                CERRAR()
                Process.Start("shutdown", "/s /t 5 /f")
            Case "BLOQUEARPC"
                CERRAR()
                Process.Start("rundll32.exe", "user32.dll,LockWorkStation")
            Case "VER"
                Log("ver recibido")
                EnviarCaptura()
            Case "CALIDAD"
                ' CALIDAD:ancho:q — el visor pide más o menos resolución en vivo.
                Try
                    If MIARRAY.Length >= 3 Then
                        Dim w, q As Integer
                        If Integer.TryParse(MIARRAY(1).Trim(), w) AndAlso
                           Integer.TryParse(MIARRAY(2).Trim(), q) AndAlso
                           w >= 320 AndAlso w <= 1920 AndAlso q >= 30 AndAlso q <= 85 Then
                            ClienteCfg.VideoW = w
                            ClienteCfg.VideoQ = q
                            ClienteCfg.Guardar()
                            Log("video " & w.ToString() & "x q" & q.ToString())
                            EnviarCaptura()
                        End If
                    End If
                Catch
                End Try
            Case "SETCFG"
                Log("setcfg clave=" & If(MIARRAY.Length >= 2, MIARRAY(1), "?"))
                AplicarCfg()
            Case "SALIR"
                CERRAR()
                Application.ExitThread()
        End Select
    End Sub

    ''' <summary>SETCFG:clave:valor — guarda cifrado y aplica en caliente.</summary>
    Private Sub AplicarCfg()
        Try
            If MIARRAY.Length < 3 Then Return
            Select Case MIARRAY(1).Trim().ToLowerInvariant()
                Case "puerto"
                    Dim p As Integer
                    If Integer.TryParse(MIARRAY(2).Trim(), p) AndAlso p > 0 AndAlso p <= 65535 Then
                        ClienteCfg.Puerto = p
                        ClienteCfg.Guardar()
                        AbrirSocket()
                    End If
                Case "servidor"
                    Dim v As String = MIARRAY(2).Trim()
                    Dim a As IPAddress = Nothing
                    If v = "" OrElse IPAddress.TryParse(v, a) Then
                        ClienteCfg.IpServidor = v
                        ClienteCfg.Guardar()
                        Log("cfg aplicado servidor=" & v)
                    End If
                Case "ciber"
                    If MIARRAY(2).Trim() <> "" Then
                        ClienteCfg.NombreCiber = MIARRAY(2).Trim()
                        ClienteCfg.Guardar()
                        Log("cfg aplicado ciber=" & ClienteCfg.NombreCiber)
                    End If
                Case "tmsg"
                    Dim q As Integer
                    If Integer.TryParse(MIARRAY(2).Trim(), q) AndAlso q > 0 Then
                        ClienteCfg.TiempoMensaje = q
                        ClienteCfg.Guardar()
                        tMsg.Interval = q * 1000
                        Log("cfg aplicado tmsg=" & q.ToString())
                    End If
                Case "tpre"
                    Dim q As Integer
                    If Integer.TryParse(MIARRAY(2).Trim(), q) AndAlso q > 0 Then
                        ClienteCfg.TiempoPreaviso = q
                        ClienteCfg.Guardar()
                        Log("cfg aplicado tpre=" & q.ToString())
                    End If
                Case "pass"
                    If MIARRAY(2) <> "" Then
                        ClienteCfg.AdminHash = Crypto.HashPass(MIARRAY(2))
                        ClienteCfg.Guardar()
                        Log("cfg aplicado pass=***")
                    End If
            End Select
            ' Refrescar el nombre en la pantalla de bloqueo abierta.
            Try
                If Not PantallaBlo.IsDisposed AndAlso PantallaBlo.Visible Then
                    PantallaBlo.lblNombreCiber.Text = ClienteCfg.NombreCiber
                End If
            Catch
            End Try
        Catch
        End Try
    End Sub

    Private Sub CERRAR()
        Try : tMin.Stop() : Catch : End Try
        Try : TiempoServ.Close() : Catch : End Try
        Try : Mensaje.Close() : Catch : End Try
        PantallaBlo.DESBLOQUEO = False
        Try : PantallaBlo.Close() : Catch : End Try
    End Sub

    '================ CUENTA REGRESIVA =================
    Private Sub tMin_Tick(sender As Object, e As EventArgs) Handles tMin.Tick
        Try
            If HORALIMITE = DateTime.MinValue Then Return
            Dim INTERVALO As TimeSpan = TimeSpan.FromMinutes(CDbl(ClienteCfg.TiempoPreaviso))
            Dim ahora As DateTime = DateTime.Now
            If HORALIMITE - ahora <= INTERVALO AndAlso Not AVISADO Then
                Mensaje.TextBoxMENSAJES.Text = "QUEDAN " & ClienteCfg.TiempoPreaviso.ToString() &
                    " MINUTOS PARA LA HORA LIMITE. SI NECESITAS MAS TIEMPO DIRIGETE AL ENCARGADO."
                AVISADO = True
                Mensaje.Show()
            End If
            If ahora >= HORALIMITE Then
                tMin.Stop()
                AVISADO = False
                Try : Mensaje.Close() : Catch : End Try
                Try : TiempoServ.Close() : Catch : End Try
                PantallaBlo.DESBLOQUEO = False
                PantallaBlo.Show()
            End If
        Catch
        End Try
    End Sub

    '================ CAPTURA =================
    Private Sub tCap_Tick(sender As Object, e As EventArgs) Handles tCap.Tick
        EnviarCaptura()
        _capTick += 1
        If _capTick >= 20 Then
            _capTick = 0
            Dim dest As String = If(IpValida(ClienteCfg.IpServidor), ClienteCfg.IpServidor, _ultimoServidor)
            Log("stream cuadros=" & _framesSent.ToString() &
                " dest=" & If(IpValida(dest), dest & ":" & DestPort().ToString(), "(sin destino)"))
        End If
    End Sub

    Private Function DestPort() As Integer
        Dim p As Integer = ClienteCfg.Puerto
        If p <= 0 OrElse p > 65535 Then p = 55555
        Return p
    End Function

    Private Sub EnviarCaptura()
        If Not IpValida(ClienteCfg.IpServidor) AndAlso Not IpValida(_ultimoServidor) Then Return
        Try
            Using captura As Bitmap = CapturarPantalla()
                Dim q As Long = ClienteCfg.VideoQ
                If q < 30 OrElse q > 85 Then q = 50
                Dim bin As Byte() = ConvertirImagenABytes(captura, q)
                If bin Is Nothing OrElse bin.Length = 0 Then Return
                Dim frag As Integer = 7000
                Dim total As Integer = CInt(Math.Ceiling(bin.Length / CDbl(frag)))
                If total <= 0 OrElse total > 2000 Then Return
                EnviarAlServidor(Encoding.UTF8.GetBytes("TOTAL:" & total.ToString()))
                For i As Integer = 0 To total - 1
                    Dim st As Integer = i * frag
                    Dim ln As Integer = Math.Min(frag, bin.Length - st)
                    Dim pre As Byte() = Encoding.UTF8.GetBytes(i.ToString("D5"))
                    Dim data(ln + pre.Length - 1) As Byte
                    Array.Copy(pre, 0, data, 0, pre.Length)
                    Array.Copy(bin, st, data, pre.Length, ln)
                    EnviarAlServidor(data)
                Next
                _framesSent += 1
            End Using
        Catch ex As Exception
            Log("captura error: " & ex.Message)
        End Try
    End Sub

    Private Sub EnviarAlServidor(data As Byte())
        Try
            If ORDENADOR Is Nothing Then Return
            Dim dest As String = If(IpValida(ClienteCfg.IpServidor), ClienteCfg.IpServidor, _ultimoServidor)
            If Not IpValida(dest) Then Return
            Dim p As Integer = ClienteCfg.Puerto
            If p <= 0 OrElse p > 65535 Then p = 55555
            ORDENADOR.Send(data, data.Length, New IPEndPoint(IPAddress.Parse(dest), p))
        Catch
        End Try
    End Sub

    Private Function CapturarPantalla() As Bitmap
        Dim b As Rectangle = Screen.PrimaryScreen.Bounds
        Dim maxW As Integer = ClienteCfg.VideoW
        If maxW < 320 OrElse maxW > 1920 Then maxW = 960
        Dim sc As Double = 1.0
        If b.Width > maxW Then sc = maxW / b.Width ' resolución pedida por el visor
        Dim nw As Integer = Math.Max(320, CInt(b.Width * sc))
        Dim nh As Integer = Math.Max(200, CInt(b.Height * sc))
        Using full As New Bitmap(b.Width, b.Height)
            Using g0 As Graphics = Graphics.FromImage(full)
                g0.CopyFromScreen(0, 0, 0, 0, New Size(b.Width, b.Height))
            End Using
            Dim c As New Bitmap(nw, nh)
            Using g As Graphics = Graphics.FromImage(c)
                g.InterpolationMode = Drawing.Drawing2D.InterpolationMode.Bilinear
                g.DrawImage(full, 0, 0, nw, nh)
            End Using
            Return c
        End Using
    End Function

    Private Function ConvertirImagenABytes(imagen As Bitmap, calidad As Long) As Byte()
        Try
            Using ms As New MemoryStream()
                Dim codec = ImageCodecInfo.GetImageEncoders().FirstOrDefault(Function(x) x.FormatID = ImageFormat.Jpeg.Guid)
                If codec Is Nothing Then
                    imagen.Save(ms, ImageFormat.Jpeg)
                Else
                    Using ep As New EncoderParameters(1)
                        ep.Param(0) = New EncoderParameter(Imaging.Encoder.Quality, calidad)
                        imagen.Save(ms, codec, ep)
                    End Using
                End If
                Return ms.ToArray()
            End Using
        Catch
            Return Nothing
        End Try
    End Function

    Private Shared Function IpValida(s As String) As Boolean
        Dim a As IPAddress = Nothing
        Return Not String.IsNullOrWhiteSpace(s) AndAlso IPAddress.TryParse(s.Trim(), a)
    End Function
End Class
