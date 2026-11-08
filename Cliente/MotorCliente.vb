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
    Private _envio As UdpClient
    Private MIARRAY As String()
    Private HORAINICIO As DateTime
    Public HORALIMITE As DateTime = DateTime.MinValue
    Private AVISADO As Boolean = False
    Private _ultimoServidor As String = ""
    Private _ultimoPingServidor As DateTime = DateTime.MinValue
    Private _fondoTotal As Integer = -1
    Private _fondoPartes As New Dictionary(Of Integer, Byte())()
    Private _fondoT0 As DateTime = DateTime.MinValue

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
        Log("arranque v3.2 puerto=" & ClienteCfg.Puerto.ToString() &
            " servidor=" & If(ClienteCfg.IpServidor = "", "(vacio)", ClienteCfg.IpServidor))
        PantallaBlo.DESBLOQUEO = False
        PantallaBlo.Show()
        TecladoBloqueo.Instalar()
        RestaurarSesionLocal()
        ReportarEstadoCliente()
        tMsg.Interval = Math.Max(1, ClienteCfg.TiempoMensaje) * 1000
        tMsg.Start()
        tCap.Interval = 1000 ' ~1 cuadro/seg: casi tiempo real en LAN
        tCap.Start()
    End Sub

    Private Sub GuardarSesionLocal(activa As Boolean)
        ClienteCfg.SesionLocalActiva = activa
        If activa Then
            ClienteCfg.SesionLocalInicio = HORAINICIO
            ClienteCfg.SesionLocalFin = HORALIMITE
        Else
            ClienteCfg.SesionLocalInicio = DateTime.MinValue
            ClienteCfg.SesionLocalFin = DateTime.MinValue
            ClienteCfg.SesionLocalPausada = False
            ClienteCfg.SesionLocalPausaDesde = DateTime.MinValue
        End If
        ClienteCfg.Guardar()
    End Sub

    Private Sub RestaurarSesionLocal()
        Try
            If Not ClienteCfg.SesionLocalActiva OrElse ClienteCfg.SesionLocalInicio = DateTime.MinValue Then Return
            HORAINICIO = ClienteCfg.SesionLocalInicio
            HORALIMITE = ClienteCfg.SesionLocalFin
            AVISADO = False
            If Not ClienteCfg.SesionLocalPausada Then
                ClienteCfg.SesionLocalPausada = True
                ClienteCfg.SesionLocalPausaDesde = DateTime.Now
                ClienteCfg.Guardar()
            End If
            BloquearPantallaPorPausa()
            ReportarEstadoCliente()
            Log("sesion local restaurada en pausa")
        Catch ex As Exception
            Log("restaurar sesion error: " & ex.Message)
        End Try
    End Sub

    Private Sub AbrirSocket()
        Try
            If ORDENADOR IsNot Nothing Then
                Try : ORDENADOR.Close() : Catch : End Try
            End If
            ORDENADOR = New UdpClient(ClienteCfg.Puerto)
            ORDENADOR.Client.Blocking = False
            Try : ORDENADOR.Client.ReceiveBufferSize = 2 * 1024 * 1024 : Catch : End Try
            If _envio Is Nothing Then _envio = New UdpClient()
        Catch
            ORDENADOR = Nothing
        End Try
    End Sub

    '================ RECEPCIÓN =================
    Private Sub tMsg_Tick(sender As Object, e As EventArgs) Handles tMsg.Tick
        Try
            ReportarEstadoCliente()
            If ORDENADOR Is Nothing Then Return
            ' Drenar la cola (el fondo llega en decenas de datagramas por tick).
            Dim n As Integer = 0
            While ORDENADOR IsNot Nothing AndAlso ORDENADOR.Available > 0 AndAlso n < 80
                n += 1
                Try
                    Dim IP As New IPEndPoint(IPAddress.Any, 0)
                    Dim raw As Byte() = ORDENADOR.Receive(IP)
                    _ultimoServidor = IP.Address.ToString()
                    _ultimoPingServidor = DateTime.Now
                    ' Límite a 3 partes: el texto del mensaje puede contener ':'.
                    MIARRAY = Encoding.UTF8.GetString(raw).Split(New Char() {":"c}, 3)
                    If MIARRAY IsNot Nothing AndAlso MIARRAY.Length >= 1 Then EJECUTA()
                Catch ex As SocketException
                Catch
                End Try
            End While
            RevisarPulsoServidor()
        Catch
        End Try
    End Sub

    Private Sub RevisarPulsoServidor()
        If Not ClienteCfg.SesionLocalActiva OrElse ClienteCfg.SesionLocalPausada OrElse Not ClienteCfg.PausarSiServidorDesconectado Then Return
        If _ultimoPingServidor = DateTime.MinValue OrElse (DateTime.Now - _ultimoPingServidor).TotalSeconds >= 15 Then
            PausarSesionCliente()
        End If
    End Sub

    Private Sub PausarSesionCliente()
        If Not ClienteCfg.SesionLocalActiva OrElse ClienteCfg.SesionLocalPausada Then Return
        ClienteCfg.SesionLocalPausada = True
        ClienteCfg.SesionLocalPausaDesde = DateTime.Now
        ClienteCfg.Guardar()
        tMin.Stop()
        BloquearPantallaPorPausa()
        ReportarEstadoCliente()
        Log("sesion pausada por cierre o desconexion del servidor")
    End Sub

    Private Sub BloquearPantallaPorPausa()
        Try : TiempoServ.CerrarPorSistema() : Catch : End Try
        Try : Mensaje.Close() : Catch : End Try
        PantallaBlo.DESBLOQUEO = False
        PantallaBlo.Show()
        TecladoBloqueo.Instalar()
    End Sub

    Private Sub ReportarEstadoCliente()
        Try
            If ORDENADOR Is Nothing Then Return
            Dim destino As String = If(String.IsNullOrWhiteSpace(ClienteCfg.IpServidor), _ultimoServidor, ClienteCfg.IpServidor).Trim()
            Dim ip As IPAddress = Nothing
            If Not IPAddress.TryParse(destino, ip) Then Return
            If ClienteCfg.SesionLocalActiva AndAlso ClienteCfg.SesionLocalPausada Then
                Dim inicioTicks As String = ClienteCfg.SesionLocalInicio.Ticks.ToString(Globalization.CultureInfo.InvariantCulture)
                Dim finTicks As String = ClienteCfg.SesionLocalFin.Ticks.ToString(Globalization.CultureInfo.InvariantCulture)
                Dim pausaTicks As String = ClienteCfg.SesionLocalPausaDesde.Ticks.ToString(Globalization.CultureInfo.InvariantCulture)
                Dim pausado As Byte() = Encoding.UTF8.GetBytes("ESTADO:PAUSADO:" & inicioTicks & ":" & finTicks & ":" & pausaTicks)
                If _envio Is Nothing Then _envio = New UdpClient()
                _envio.Send(pausado, pausado.Length, New IPEndPoint(ip, ClienteCfg.Puerto))
                Return
            End If
            Dim bloqueado As Boolean = Not PantallaBlo.IsDisposed AndAlso PantallaBlo.Visible
            Dim estado As String = If(bloqueado, "BLOQUEADO", "EN_USO")
            Dim datos As Byte() = Encoding.UTF8.GetBytes("ESTADO:" & estado)
            If _envio Is Nothing Then _envio = New UdpClient()
            _envio.Send(datos, datos.Length, New IPEndPoint(ip, ClienteCfg.Puerto))
        Catch ex As Exception
            Log("estado cliente error: " & ex.Message)
        End Try
    End Sub

    Public Sub EJECUTA()
        If MIARRAY Is Nothing OrElse MIARRAY.Length = 0 Then Return
        Select Case MIARRAY(0).Trim().ToUpperInvariant()
            Case "PING"
                _ultimoPingServidor = DateTime.Now
                If MIARRAY.Length >= 2 Then
                    Dim pausar As Boolean
                    If Boolean.TryParse(MIARRAY(1).Trim(), pausar) Then
                        If ClienteCfg.PausarSiServidorDesconectado <> pausar Then
                            ClienteCfg.PausarSiServidorDesconectado = pausar
                            ClienteCfg.Guardar()
                        End If
                    End If
                End If
                ReportarEstadoCliente()
            Case "PAUSAR"
                PausarSesionCliente()
            Case "INICIAR"
                If MIARRAY.Length < 3 Then Return
                Dim h, m As Integer
                Integer.TryParse(MIARRAY(1), h) : Integer.TryParse(MIARRAY(2), m)
                HORAINICIO = DateTime.Now
                TiempoServ.LabelINICIO.Text = HORAINICIO.ToLongTimeString
                HORALIMITE = If(h * 60 + m > 0, HORAINICIO.AddMinutes(h * 60 + m), DateTime.MinValue)
                GuardarSesionLocal(True)
                ClienteCfg.SesionLocalPausada = False
                ClienteCfg.SesionLocalPausaDesde = DateTime.MinValue
                ClienteCfg.Guardar()
                TiempoServ.LabelLIMITE.Text = If(HORALIMITE = DateTime.MinValue, "Tiempo libre", HORALIMITE.ToLongTimeString())
                AVISADO = False
                PantallaBlo.DESBLOQUEO = True
                TecladoBloqueo.Desinstalar()
                Try : PantallaBlo.Close() : Catch : End Try
                TiempoServ.Show()
                tMin.Stop()
                If HORALIMITE <> DateTime.MinValue Then
                    tMin.Interval = 15000
                    tMin.Start()
                End If
            Case "REANUDAR"
                If MIARRAY.Length < 3 Then Return
                Dim transcurrido As Integer
                If Not Integer.TryParse(MIARRAY(1), transcurrido) OrElse transcurrido < 0 Then Return
                HORAINICIO = DateTime.Now.AddSeconds(-transcurrido)
                Dim tiempoLibre As Boolean = MIARRAY(2).Trim().Equals("LIBRE", StringComparison.OrdinalIgnoreCase)
                Dim restante As Integer = 0
                If Not tiempoLibre AndAlso (Not Integer.TryParse(MIARRAY(2), restante) OrElse restante <= 0) Then Return
                HORALIMITE = If(tiempoLibre, DateTime.MinValue, DateTime.Now.AddSeconds(restante))
                GuardarSesionLocal(True)
                ClienteCfg.SesionLocalPausada = False
                ClienteCfg.SesionLocalPausaDesde = DateTime.MinValue
                ClienteCfg.Guardar()
                AVISADO = False
                TiempoServ.LabelINICIO.Text = HORAINICIO.ToLongTimeString
                TiempoServ.LabelLIMITE.Text = If(tiempoLibre, "Tiempo libre", HORALIMITE.ToLongTimeString())
                PantallaBlo.DESBLOQUEO = True
                TecladoBloqueo.Desinstalar()
                Try : PantallaBlo.Close() : Catch : End Try
                TiempoServ.Show()
                tMin.Stop()
                If Not tiempoLibre Then
                    tMin.Interval = 15000
                    tMin.Start()
                End If
            Case "AÑADIR"
                If MIARRAY.Length < 3 Then Return
                Dim h, m As Integer
                Integer.TryParse(MIARRAY(1), h) : Integer.TryParse(MIARRAY(2), m)
                If h * 60 + m <= 0 Then Return
                HORALIMITE = If(HORALIMITE = DateTime.MinValue, DateTime.Now.AddMinutes(h * 60 + m), HORALIMITE.AddMinutes(h * 60 + m))
                GuardarSesionLocal(True)
                ClienteCfg.SesionLocalPausada = False
                ClienteCfg.SesionLocalPausaDesde = DateTime.MinValue
                ClienteCfg.Guardar()
                Try : TiempoServ.LabelLIMITE.Text = HORALIMITE.ToLongTimeString : Catch : End Try
                tMin.Stop()
                tMin.Interval = 15000
                tMin.Start()
            Case "BLOQUEO"
                GuardarSesionLocal(False)
                tMin.Stop()
                HORAINICIO = DateTime.MinValue
                HORALIMITE = DateTime.MinValue
                AVISADO = False
                Try : TiempoServ.CerrarPorSistema() : Catch : End Try
                Try : Mensaje.Close() : Catch : End Try
                PantallaBlo.DESBLOQUEO = False
                PantallaBlo.Show()
                TecladoBloqueo.Instalar()
            Case "DESBLOQUEAR"
                HORAINICIO = DateTime.Now
                HORALIMITE = DateTime.MinValue
                GuardarSesionLocal(True)
                ClienteCfg.SesionLocalPausada = False
                ClienteCfg.SesionLocalPausaDesde = DateTime.MinValue
                ClienteCfg.Guardar()
                Try : TiempoServ.LabelINICIO.Text = HORAINICIO.ToLongTimeString : Catch : End Try
                Try : TiempoServ.LabelLIMITE.Text = "Tiempo libre" : Catch : End Try
                tMin.Stop()
                Try : TiempoServ.CerrarPorSistema() : Catch : End Try
                Try : Mensaje.Close() : Catch : End Try
                PantallaBlo.DESBLOQUEO = True
                TecladoBloqueo.Desinstalar()
                Try : PantallaBlo.Close() : Catch : End Try
                TiempoServ.Show()
                tMin.Stop()
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
                GuardarSesionLocal(False)
                CERRAR()
                Application.ExitThread()
            Case "FONDOINI"
                Try
                    Dim t As Integer
                    If MIARRAY.Length >= 2 AndAlso Integer.TryParse(MIARRAY(1).Trim(), t) AndAlso t > 0 AndAlso t <= 500 Then
                        _fondoTotal = t
                        _fondoPartes.Clear()
                        _fondoT0 = DateTime.Now
                        Log("fondo inicio partes=" & t.ToString())
                    End If
                Catch
                End Try
            Case "FONDO"
                ProcesarFondo()
        End Select
    End Sub

    ''' <summary>Reensambla el fondo (Base64) y lo guarda como fondo.jpg.</summary>
    Private Sub ProcesarFondo()
        Try
            If _fondoTotal <= 0 Then Return
            If (DateTime.Now - _fondoT0).TotalSeconds > 60 Then
                _fondoTotal = -1 : _fondoPartes.Clear() : Return
            End If
            If MIARRAY.Length < 3 Then Return
            Dim idx As Integer
            If Not Integer.TryParse(MIARRAY(1).Trim(), idx) Then Return
            _fondoPartes(idx) = Convert.FromBase64String(MIARRAY(2))
            If _fondoPartes.Count >= _fondoTotal Then
                Using ms As New IO.MemoryStream()
                    For i As Integer = 0 To _fondoTotal - 1
                        If Not _fondoPartes.ContainsKey(i) Then Return
                        ms.Write(_fondoPartes(i), 0, _fondoPartes(i).Length)
                    Next
                    Dim ruta As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "fondo.jpg")
                    IO.File.WriteAllBytes(ruta, ms.ToArray())
                End Using
                Log("fondo recibido bytes=" & _fondoPartes.Values.Sum(Function(b) b.Length).ToString())
                _fondoTotal = -1 : _fondoPartes.Clear()
                Try
                    If Not PantallaBlo.IsDisposed AndAlso PantallaBlo.Visible Then PantallaBlo.AplicarFondo()
                Catch
                End Try
            End If
        Catch ex As Exception
            Log("fondo error: " & ex.Message)
        End Try
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
                Case "taskmgr"
                    Dim activar As Boolean
                    If Boolean.TryParse(MIARRAY(2).Trim(), activar) Then
                        ClienteCfg.BloquearAdministradorTareas = activar
                        ClienteCfg.Guardar()
                        ClienteCfg.AplicarOpcionesWindows()
                    End If
                Case "autostart"
                    Dim activar As Boolean
                    If Boolean.TryParse(MIARRAY(2).Trim(), activar) Then
                        ClienteCfg.IniciarConWindows = activar
                        ClienteCfg.Guardar()
                        ClienteCfg.AplicarOpcionesWindows()
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
        Try : TecladoBloqueo.Desinstalar() : Catch : End Try
        Try : TiempoServ.CerrarPorSistema() : Catch : End Try
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
                GuardarSesionLocal(False)
                HORAINICIO = DateTime.MinValue
                HORALIMITE = DateTime.MinValue
                AVISADO = False
                tMin.Stop()
                AVISADO = False
                Try : Mensaje.Close() : Catch : End Try
                Try : TiempoServ.CerrarPorSistema() : Catch : End Try
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
            If _envio Is Nothing Then _envio = New UdpClient()
            _envio.Send(data, data.Length, New IPEndPoint(IPAddress.Parse(dest), p))
        Catch ex As Exception
            Log("udp envio servidor error: " & ex.Message)
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
