Imports System.Net
Imports System.Globalization

''' <summary>
''' Tarjeta de control por equipo (editable desde el diseñador).
''' Todos los botones envían comandos UDP reales.
''' </summary>
Public Class EquipoCard
    Inherits UserControl

    Public Property NombreEquipo As String = ""
    Private _ip As String = ""
    Public ReadOnly Property IpEquipo As String
        Get
            Return _ip.Trim()
        End Get
    End Property
    Private _inicioSesion As DateTime = DateTime.MinValue
    Private _finSesion As DateTime = DateTime.MinValue
    Private _sesionActivaGuardada As Boolean = False
    Private _recuperacionPendiente As Boolean = False
    Private _pausaDesde As DateTime = DateTime.MinValue
    Private _ultimaReanudacion As DateTime = DateTime.MinValue
    Private WithEvents _timerSesion As New Timer()

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        Me.Height = 316
        grid.RowStyles(1).Height = 50.0!
        _timerSesion.Interval = 1000
        Try
            Theme.StyleButton(btnIniciar, Theme.Success)
            Theme.StyleButton(btnAnadir, Theme.Primary)
            Theme.StyleButton(btnBloq, Theme.Warn)
            Theme.StyleButton(btnDesbloq, Theme.Success)
            Theme.StyleButton(btnVer, Theme.Dark)
            Theme.StyleButton(btnMsg, Theme.Primary)
            Theme.StyleButton(btnWin, Theme.Muted)
            Theme.StyleButton(btnRei, Theme.Muted)
            Theme.StyleButton(btnApa, Theme.Danger)
            Theme.StyleButton(btnReanudar, Theme.Success)
            Theme.StyleButton(btnFinalizar, Theme.Danger)
        Catch
        End Try
    End Sub

    Public Sub LoadData(nombre As String, ip As String)
        NombreEquipo = nombre
        _ip = If(ip, "")
        SetEstadoBloqueo(True)
        lblNombre.Text = nombre
        If String.IsNullOrWhiteSpace(_ip) Then
            lblIp.Text = "Sin IP asignada: ve a Red y equipos"
        Else
            lblIp.Text = _ip & " · puerto " & Servidor.Data.Db.Puerto().ToString()
        End If
        lblSesion.Text = "Sin sesión activa"
        _inicioSesion = DateTime.MinValue
        _finSesion = DateTime.MinValue
        _sesionActivaGuardada = False
        _recuperacionPendiente = False
        _pausaDesde = DateTime.MinValue
        _ultimaReanudacion = DateTime.MinValue
        MostrarOpcionesRecuperacion(False)
        Try
            Dim activa As DataRow = Servidor.Data.Db.SesionActiva(NombreEquipo)
            If activa IsNot Nothing AndAlso Convert.ToInt32(activa("Finalizada")) = 0 Then
                Dim inicio As DateTime
                Dim fin As DateTime
                If DateTime.TryParseExact(CStr(activa("Inicio")), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, inicio) AndAlso
                   DateTime.TryParseExact(CStr(activa("Fin")), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, fin) Then
                    Dim recuperada As Boolean = Convert.ToInt32(activa("Recuperada")) <> 0
                    DateTime.TryParseExact(CStr(activa("PausaDesde")), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, _pausaDesde)
                    If fin <> DateTime.MinValue AndAlso fin <= DateTime.Now AndAlso Not recuperada Then
                        Servidor.Data.Db.FinalizarSesionActiva(NombreEquipo, fin)
                    Else
                        _inicioSesion = inicio
                        _finSesion = fin
                        _sesionActivaGuardada = True
                        _recuperacionPendiente = recuperada
                        MostrarOpcionesRecuperacion(_recuperacionPendiente)
                        btnAnadir.Enabled = Not _recuperacionPendiente
                        If _recuperacionPendiente Then
                            If _pausaDesde = DateTime.MinValue Then _pausaDesde = DateTime.Now
                            MostrarSesionPausada()
                            btnReanudar.Enabled = _finSesion = DateTime.MinValue OrElse _finSesion > _pausaDesde
                        Else
                            MostrarControlesSesionActiva()
                            ActualizarSesion()
                            _timerSesion.Start()
                        End If
                    End If
                Else
                    Servidor.Data.Db.EliminarSesionActiva(NombreEquipo)
                End If
            Else
                MostrarOpcionesRecuperacion(False)
            End If
        Catch
        End Try
        SetOnline(Nothing)
    End Sub

    ''' <summary>Nothing=desconocido, True=en línea, False=sin conexión.</summary>
    Public Sub SetOnline(online As Nullable(Of Boolean))
        If Not online.HasValue Then
            lblEstado.Text = "● ..."
            header.BackColor = Theme.Muted
        ElseIf online.Value Then
            lblEstado.Text = "● En línea"
            header.BackColor = Theme.Success
        Else
            lblEstado.Text = "● Sin conexión"
            header.BackColor = Theme.Danger
        End If
    End Sub

    Public Sub SetEstadoBloqueo(bloqueado As Boolean)
        btnBloq.Enabled = Not bloqueado
        btnDesbloq.Enabled = bloqueado
    End Sub

    Public ReadOnly Property SesionPendienteRecuperacion As Boolean
        Get
            Return _recuperacionPendiente
        End Get
    End Property

    Public ReadOnly Property TieneSesionActiva As Boolean
        Get
            Return _sesionActivaGuardada
        End Get
    End Property

    Public ReadOnly Property InicioSesionActual As DateTime
        Get
            Return _inicioSesion
        End Get
    End Property

    Public Sub PausarPorDesconexion(pausaDesde As DateTime)
        If Not _sesionActivaGuardada OrElse _recuperacionPendiente Then Return
        If pausaDesde = DateTime.MinValue Then pausaDesde = DateTime.Now
        _pausaDesde = pausaDesde
        _recuperacionPendiente = True
        _timerSesion.Stop()
        Servidor.Data.Db.GuardarSesionPausada(NombreEquipo, _inicioSesion, _finSesion, _pausaDesde)
        MostrarOpcionesRecuperacion(True)
        btnAnadir.Enabled = False
        btnReanudar.Enabled = _finSesion = DateTime.MinValue OrElse _finSesion > _pausaDesde
        MostrarSesionPausada()
        SetEstadoBloqueo(True)
    End Sub

    Public Sub FinalizarPorCobro()
        ReiniciarCronometro()
        SetEstadoBloqueo(True)
    End Sub

    Private Function IpOk() As Boolean
        Dim a As IPAddress = Nothing
        If String.IsNullOrWhiteSpace(_ip) OrElse Not IPAddress.TryParse(_ip.Trim(), a) Then
            MessageBox.Show(NombreEquipo & " no tiene IP válida. Asígnala en Red y equipos.",
                            "Control Ciber", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        _ip = a.ToString()
        Return True
    End Function

    Private Sub Enviar(cmd As String, p1 As String, p2 As String)
        If Not IpOk() Then Return
        Try
            NetProtocol.SendUdp(_ip, Servidor.Data.Db.Puerto(), cmd, p1, p2)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Control Ciber", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MostrarOpcionesRecuperacion(mostrar As Boolean)
        btnReanudar.Visible = mostrar
        btnFinalizar.Visible = mostrar
        btnReanudar.SetBounds(0, 2, 165, 32)
        btnFinalizar.SetBounds(175, 2, 165, 32)
        btnFinalizar.Text = "Finalizar / cobrar"
        lh.Visible = Not mostrar
        numH.Visible = Not mostrar
        lm.Visible = Not mostrar
        numM.Visible = Not mostrar
        btnIniciar.Visible = Not mostrar
        btnAnadir.Visible = Not mostrar
    End Sub

    Private Sub MostrarControlesSesionActiva()
        btnReanudar.Visible = False
        btnFinalizar.Visible = True
        btnFinalizar.SetBounds(164, 2, 88, 32)
        btnFinalizar.Text = "Cobrar"
        lh.Visible = True
        numH.Visible = True
        lm.Visible = True
        numM.Visible = True
        btnIniciar.Visible = False
        btnAnadir.Visible = True
    End Sub

    Private Sub MostrarSesionPausada()
        Dim hasta As DateTime = If(_pausaDesde = DateTime.MinValue, DateTime.Now, _pausaDesde)
        If _finSesion <> DateTime.MinValue AndAlso _finSesion < hasta Then hasta = _finSesion
        Dim transcurrido As TimeSpan = hasta - _inicioSesion
        Dim minutos As Integer = CInt(Math.Ceiling(Math.Max(0, transcurrido.TotalMinutes)))
        Dim tarifa As Decimal = LeerTarifaHora()
        Dim importe As Decimal = Math.Round(minutos * tarifa / 60D, 2)
        Dim restante As TimeSpan = If(_finSesion = DateTime.MinValue, TimeSpan.Zero, TimeSpan.FromSeconds(Math.Max(0, (_finSesion - If(_pausaDesde = DateTime.MinValue, DateTime.Now, _pausaDesde)).TotalSeconds)))
        Dim duracion As TimeSpan = If(_finSesion = DateTime.MinValue, TimeSpan.Zero, _finSesion - _inicioSesion)
        lblSesion.Text = "Sesión pausada · Transcurrido " & FormatoDuracion(transcurrido) & vbCrLf &
            If(_finSesion = DateTime.MinValue, "Tiempo libre · Importe $" & importe.ToString("N2"), "Duración " & FormatoDuracion(duracion) & " · Restante " & FormatoDuracion(restante) & " · $" & importe.ToString("N2"))
        lblSesion.ForeColor = Color.FromArgb(180, 83, 9)
    End Sub

    Private Sub OnReanudar(s As Object, e As EventArgs) Handles btnReanudar.Click
        If Not _recuperacionPendiente Then Return
        If Not IpOk() Then Return
        Dim ahora As DateTime = If(_pausaDesde = DateTime.MinValue, DateTime.Now, _pausaDesde)
        Dim tiempoLibre As Boolean = _finSesion = DateTime.MinValue
        Dim restante As Integer = If(tiempoLibre, 0, Math.Max(0, CInt(Math.Floor((_finSesion - ahora).TotalSeconds))))
        If Not tiempoLibre AndAlso restante <= 0 Then
            btnReanudar.Enabled = False
            Return
        End If
        Dim transcurrido As Integer = Math.Max(0, CInt(Math.Floor((ahora - _inicioSesion).TotalSeconds)))
        Enviar("REANUDAR", transcurrido.ToString(), If(tiempoLibre, "LIBRE", restante.ToString()))
        SetEstadoBloqueo(False)
        _inicioSesion = DateTime.Now.AddSeconds(-transcurrido)
        _finSesion = If(tiempoLibre, DateTime.MinValue, DateTime.Now.AddSeconds(restante))
        _pausaDesde = DateTime.MinValue
        _recuperacionPendiente = False
        _ultimaReanudacion = DateTime.Now
        Servidor.Data.Db.ActualizarSesionReanudada(NombreEquipo, _inicioSesion, _finSesion)
        MostrarControlesSesionActiva()
        btnAnadir.Enabled = True
        _timerSesion.Start()
    End Sub

    Private Sub OnFinalizar(s As Object, e As EventArgs) Handles btnFinalizar.Click
        If Not _recuperacionPendiente AndAlso Not _sesionActivaGuardada Then Return
        RaiseEvent SolicitarCobroEquipo(NombreEquipo)
    End Sub

    Public Event SolicitarCobroEquipo(equipo As String)

    Public Sub SincronizarSesionPausada(inicio As DateTime, fin As DateTime, pausaDesde As DateTime)
        If inicio = DateTime.MinValue Then Return
        If _ultimaReanudacion <> DateTime.MinValue AndAlso pausaDesde <= _ultimaReanudacion Then Return
        _inicioSesion = inicio
        _finSesion = fin
        _pausaDesde = pausaDesde
        _sesionActivaGuardada = True
        _recuperacionPendiente = True
        Servidor.Data.Db.GuardarSesionPausada(NombreEquipo, inicio, fin, pausaDesde)
        MostrarOpcionesRecuperacion(True)
        btnAnadir.Enabled = False
        btnReanudar.Enabled = fin = DateTime.MinValue OrElse fin > pausaDesde
        MostrarSesionPausada()
        SetEstadoBloqueo(True)
    End Sub
    Private Sub OnIniciar(s As Object, e As EventArgs) Handles btnIniciar.Click
        If Not IpOk() Then Return
        btnAnadir.Enabled = True
        Enviar("INICIAR", numH.Value.ToString(), numM.Value.ToString())
        SetEstadoBloqueo(False)
        _inicioSesion = DateTime.Now
        Dim minutos As Integer = CInt(numH.Value) * 60 + CInt(numM.Value)
        _finSesion = If(minutos > 0, _inicioSesion.AddMinutes(minutos), DateTime.MinValue)
        _sesionActivaGuardada = True
        _recuperacionPendiente = False
        _ultimaReanudacion = DateTime.Now
        MostrarControlesSesionActiva()
        Servidor.Data.Db.GuardarSesionActiva(NombreEquipo, _inicioSesion, _finSesion)
        ActualizarSesion()
        _timerSesion.Start()
        Servidor.Data.Db.RegistrarSesion(NombreEquipo, CInt(numH.Value) * 60 + CInt(numM.Value))
        numH.Value = 0 : numM.Value = 0
    End Sub

    Private Sub _timerSesion_Tick(sender As Object, e As EventArgs) Handles _timerSesion.Tick
        ActualizarSesion()
    End Sub

    Private Sub ActualizarSesion()
        If _inicioSesion = DateTime.MinValue Then Return
        Dim transcurrido As TimeSpan = DateTime.Now - _inicioSesion
        Dim libre As Boolean = _finSesion = DateTime.MinValue
        Dim restante As TimeSpan = If(libre, TimeSpan.Zero, _finSesion - DateTime.Now)
        If Not libre AndAlso restante.Ticks <= 0 Then
            Try
                Servidor.Data.Db.FinalizarSesionActiva(NombreEquipo, _finSesion)
            Catch
            End Try
            ReiniciarCronometro()
            Return
        End If
        Dim minutos As Integer = CInt(Math.Ceiling(Math.Max(0, transcurrido.TotalMinutes)))
        Dim tarifaHora As Decimal = LeerTarifaHora()
        Dim gastado As Decimal = Math.Round(minutos * tarifaHora / 60D, 2)
        Dim duracion As TimeSpan = If(libre, TimeSpan.Zero, _finSesion - _inicioSesion)
        lblSesion.Text = "Inicio " & _inicioSesion.ToString("HH:mm:ss") & " · Transcurrido " & FormatoDuracion(transcurrido) & vbCrLf &
            If(libre, "Tiempo libre · Gastado $" & gastado.ToString("N2"), "Duración " & FormatoDuracion(duracion) & " · Restante " & FormatoDuracion(restante) & " · $" & gastado.ToString("N2"))
        lblSesion.ForeColor = If(libre, Theme.Success, Color.FromArgb(55, 65, 81))
    End Sub

    Private Function LeerTarifaHora() As Decimal
        Dim tarifa As Decimal
        Dim valor As String = Servidor.Data.Db.GetConfig("tarifaHora", "")
        If Decimal.TryParse(valor, Globalization.NumberStyles.Any, CultureInfo.InvariantCulture, tarifa) Then Return tarifa
        If Decimal.TryParse(Servidor.Data.Db.GetConfig("tarifaMinuto", "0"), Globalization.NumberStyles.Any, CultureInfo.InvariantCulture, tarifa) Then Return tarifa * 60D
        Return 0D
    End Function

    Private Sub ReiniciarCronometro()
        _timerSesion.Stop()
        SetEstadoBloqueo(True)
        _inicioSesion = DateTime.MinValue
        _finSesion = DateTime.MinValue
        _sesionActivaGuardada = False
        _recuperacionPendiente = False
        lblSesion.Text = "Sin sesión activa"
        lblSesion.ForeColor = Theme.Muted
        MostrarOpcionesRecuperacion(False)
        btnAnadir.Enabled = False
    End Sub

    Private Function FormatoDuracion(valor As TimeSpan) As String
        Dim horas As Integer = CInt(Math.Floor(Math.Max(0, valor.TotalHours)))
        Return horas.ToString("00") & ":" & valor.Minutes.ToString("00") & ":" & valor.Seconds.ToString("00")
    End Function
    Private Sub OnAnadir(s As Object, e As EventArgs) Handles btnAnadir.Click
        Enviar("AÑADIR", numH.Value.ToString(), numM.Value.ToString())
        Dim agregarMinutos As Integer = CInt(numH.Value) * 60 + CInt(numM.Value)
        If agregarMinutos > 0 Then _finSesion = If(_finSesion = DateTime.MinValue, DateTime.Now.AddMinutes(agregarMinutos), _finSesion.AddMinutes(agregarMinutos))
        If _sesionActivaGuardada Then Servidor.Data.Db.GuardarSesionActiva(NombreEquipo, _inicioSesion, _finSesion)
        ActualizarSesion()
        numH.Value = 0 : numM.Value = 0
    End Sub

    Private Sub OnBloq(s As Object, e As EventArgs) Handles btnBloq.Click
        If MessageBox.Show("¿Bloquear " & NombreEquipo & "?", "Control Ciber",
                           MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
            Enviar("BLOQUEO", "0", "0")
            SetEstadoBloqueo(True)
            If _inicioSesion <> DateTime.MinValue Then
                Try
                    _finSesion = DateTime.Now
                    Servidor.Data.Db.FinalizarSesionActiva(NombreEquipo, _finSesion)
                Catch ex As Exception
                    MessageBox.Show("No se guardó el cierre de la sesión: " & ex.Message, "Control Ciber", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
            ReiniciarCronometro()
        End If
    End Sub

    Private Sub OnDesbloq(s As Object, e As EventArgs) Handles btnDesbloq.Click
        If Not IpOk() Then Return
        Enviar("DESBLOQUEAR", "0", "0")
        SetEstadoBloqueo(False)
        _inicioSesion = DateTime.Now
        _finSesion = DateTime.MinValue
        _sesionActivaGuardada = True
        _recuperacionPendiente = False
        _ultimaReanudacion = DateTime.Now
        MostrarControlesSesionActiva()
        Servidor.Data.Db.GuardarSesionActiva(NombreEquipo, _inicioSesion, _finSesion)
        Servidor.Data.Db.RegistrarSesion(NombreEquipo, 0)
        btnAnadir.Enabled = True
        ActualizarSesion()
        _timerSesion.Start()
    End Sub

    Private Sub OnMsgKey(s As Object, e As KeyEventArgs) Handles txtMsg.KeyDown
        If e.KeyCode = Keys.Enter AndAlso txtMsg.Text <> "" Then OnMsg(Nothing, Nothing)
    End Sub

    Private Sub OnMsg(s As Object, e As EventArgs) Handles btnMsg.Click
        If txtMsg.Text.Trim() = "" Then Return
        Enviar("MENSAJE", txtMsg.Text.Trim(), "0")
        txtMsg.Clear()
    End Sub

    Private Sub OnVer(s As Object, e As EventArgs) Handles btnVer.Click
        If Not IpOk() Then Return
        ' Pide al cliente un cuadro inmediato y abre el visor en vivo.
        Enviar("VER", "0", "0")
        Dim f As New pantallaEquipo(_ip)
        f.Show()
    End Sub

    Private Sub OnWin(s As Object, e As EventArgs) Handles btnWin.Click
        Enviar("BLOQUEARPC", "0", "0")
    End Sub

    Private Sub OnRei(s As Object, e As EventArgs) Handles btnRei.Click
        If MessageBox.Show("¿Reiniciar " & NombreEquipo & "?", "Control Ciber",
                           MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
            Enviar("REINICIAR", "0", "0")
        End If
    End Sub

    Private Sub OnApa(s As Object, e As EventArgs) Handles btnApa.Click
        If MessageBox.Show("¿Apagar " & NombreEquipo & "?", "Control Ciber",
                           MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
            Enviar("APAGAR", "0", "0")
        End If
    End Sub
End Class
