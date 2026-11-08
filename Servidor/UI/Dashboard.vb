Imports System.Drawing.Imaging
Imports System.Net.NetworkInformation
Imports System.Threading.Tasks

''' <summary>
''' Ventana principal v4.8 (editable desde el diseñador de Visual Studio):
''' sidebar oscuro + tarjetas por equipo + caja del día + red/equipos.
''' El punto de venta, productos e historial son páginas internas (SQLite).
''' </summary>
Public Class Dashboard
    Inherits Form

    Private WithEvents tReloj As New Timer()
    Private WithEvents tPing As New Timer()

    Private _cards As New Dictionary(Of String, EquipoCard)()
    Private _updInfo As Actualizador.InfoVersion
    Private _updLista As Boolean = False
    Private _pingEnCurso As Boolean = False
    Private _fondoBytes As Byte()
    Private _fondoNombre As String = ""
    Private _cargandoPausa As Boolean = False
    Private _cargandoRed As Boolean = False

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        AddHandler ScreenHub.EstadoClienteRecibido, AddressOf EstadoClienteRecibido
        AddHandler ScreenHub.SesionClientePausada, AddressOf SesionClientePausada
        AddHandler posCtl.EquipoLiquidado, AddressOf EquipoLiquidado
        AplicarEstilos()
        tReloj.Interval = 1000
        tPing.Interval = 5000
    End Sub

    Private Sub EquipoLiquidado(equipo As String)
        If _cards.ContainsKey(equipo) Then _cards(equipo).FinalizarPorCobro()
        CargarCaja()
    End Sub

    Private Sub SolicitarCobroEquipo(equipo As String)
        MostrarPagina("Ventas")
        posCtl.PrepararCobroEquipo(equipo)
    End Sub

    ''' <summary>Estilos del tema (se aplican en runtime para que el diseñador siga editable).</summary>
    Private Sub AplicarEstilos()
        Try
            For Each b In New Button() {btnAcerca, btnRed, btnCaja, btnHist, btnProductos, btnVentas, btnEquipos}
                Theme.StyleSideButton(b, False)
            Next
            Theme.StyleSideButton(btnEquipos, True)
            Theme.StyleButton(btnActualizar, Theme.Primary)
            Theme.StyleButton(btnCajaHoy, Theme.Primary)
            Theme.StyleButton(bAddRed, Theme.Success)
            Theme.StyleButton(bSaveRed, Theme.Primary)
            Theme.StyleButton(bDelRed, Theme.Danger)
            Theme.StyleButton(bPortRed, Theme.Dark)
            Theme.StyleButton(bCfgEnviar, Theme.Success)
            Theme.StyleButton(btnElegirFondo, Theme.Dark)
            Theme.StyleButton(btnEnviarFondo, Theme.Success)
            Theme.StyleButton(btnBuscarUpd, Theme.Primary)
            Theme.StyleButton(btnTerminos, Theme.Dark)
            Theme.StyleGrid(dgvVentasHoy)
            Theme.StyleGrid(dgvSesHoy)
            Theme.StyleGrid(dgvRed)
        Catch
        End Try
    End Sub

    Private Sub Top_Resize(s As Object, e As EventArgs) Handles topBar.Resize
        btnActualizar.Left = topBar.Width - 130
        lblHoy.Left = 420
        lblHoy.Width = Math.Max(180, topBar.Width - 720)
        lblReloj.Left = topBar.Width - 290
    End Sub

    '================ CAJA =================
    Private Sub btnCajaHoy_Click(s As Object, e As EventArgs) Handles btnCajaHoy.Click
        CargarCaja()
    End Sub

    Private Sub CargarCaja()
        Try
            Dim hoy As Date = DateTime.Today
            dgvVentasHoy.DataSource = Servidor.Data.Db.HistorialVentas(hoy, hoy)
            dgvSesHoy.DataSource = Servidor.Data.Db.ListarSesiones(hoy)
            Dim t = Servidor.Data.Db.TotalVentasDia(hoy)
            Dim n = Servidor.Data.Db.ContarVentasDia(hoy)
            Dim pagos = Servidor.Data.Db.ResumenPagos(hoy, hoy)
            lblTotalHoy.Text = "Hoy: $" & t.ToString("N2")
            lblNTickets.Text = "Tickets: " & n.ToString()
            lblDesgloseHoy.Text = "Efectivo: $" & pagos("Efectivo").ToString("N2") & " · Transferencia: $" & pagos("Transferencia").ToString("N2") & vbCrLf &
                "Tarjeta: $" & pagos("Tarjeta").ToString("N2")
            lblHoy.Text = "Hoy $" & t.ToString("N2") & vbCrLf &
                "Efectivo $" & pagos("Efectivo").ToString("N2") & " · Transf. $" & pagos("Transferencia").ToString("N2") & " · Tarjeta $" & pagos("Tarjeta").ToString("N2")
        Catch ex As Exception
            LogErr("CargarCaja", ex)
            MessageBox.Show(ex.Message, "Caja", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '================ RED =================
    Private Sub LogErr(ctx As String, ex As Exception)
        Try
            Dim lp As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ciber_error.log")
            IO.File.AppendAllText(lp, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & " [" & ctx & "] " & ex.ToString() & vbCrLf)
        Catch
        End Try
    End Sub

    Private Sub CargarRed()
        Try
            _cargandoRed = True
            Dim dt = Servidor.Data.Db.ListarEquipos()
            If dt Is Nothing Then Throw New InvalidOperationException("ListarEquipos devolvió Nothing.")
            dt.DefaultView.Sort = "Id ASC"
            If dgvRed Is Nothing Then Throw New InvalidOperationException("dgvRed es Nothing (diseñador).")
            dgvRed.DataSource = dt.DefaultView
            dgvRed.SuspendLayout()
            ' Fijar anchos con el grid en None (con Fill + sin handle, set_Width lanza NRE).
            dgvRed.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.None
            If dgvRed.Columns.Contains("Id") Then
                dgvRed.Columns("Id").ReadOnly = True
                dgvRed.Columns("Id").HeaderText = "ID"
                dgvRed.Columns("Id").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                dgvRed.Columns("Id").Width = 60
            End If
            If dgvRed.Columns.Contains("Nombre") Then
                dgvRed.Columns("Nombre").ReadOnly = True
                dgvRed.Columns("Nombre").HeaderText = "Equipo"
                dgvRed.Columns("Nombre").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                dgvRed.Columns("Nombre").Width = 220
            End If
            If dgvRed.Columns.Contains("Ip") Then
                dgvRed.Columns("Ip").HeaderText = "IP del equipo"
                dgvRed.Columns("Ip").ReadOnly = False
                dgvRed.Columns("Ip").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End If
            dgvRed.ResumeLayout()
            ' El estilo deja el grid en solo-lectura a nivel grid (domina sobre
            ' columnas): se reabre para poder escribir la IP (ID y Equipo
            ' siguen bloqueados por columna).
            dgvRed.ReadOnly = False
            txtPuerto.Text = Servidor.Data.Db.Puerto().ToString()
            Try
                cboCfgEq.Items.Clear()
                cboCfgEq.Items.Add("Todos")
                cboFondoEq.Items.Clear()
                cboFondoEq.Items.Add("Todos")
                For Each r As DataRow In Servidor.Data.Db.ListarEquipos().Rows
                    cboCfgEq.Items.Add(CStr(r("Nombre")))
                    cboFondoEq.Items.Add(CStr(r("Nombre")))
                Next
                Dim equipoCfg As String = Servidor.Data.Db.GetConfig("clienteEquipoSeleccionado", "Todos")
                cboCfgEq.SelectedIndex = Math.Max(0, cboCfgEq.Items.IndexOf(equipoCfg))
                Dim equipoFondo As String = Servidor.Data.Db.GetConfig("fondoEquipoSeleccionado", "Todos")
                cboFondoEq.SelectedIndex = Math.Max(0, cboFondoEq.Items.IndexOf(equipoFondo))
            Catch
            End Try
            _cargandoRed = False
            CargarPerfilClienteSeleccionado()
            CargarFondoGuardado()
        Catch ex As Exception
            _cargandoRed = False
            LogErr("CargarRed", ex)
            MessageBox.Show(ex.ToString() & vbCrLf & "(detalle en ciber_error.log)", "Red", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ClavePerfilCliente(equipo As String, campo As String) As String
        Dim nombre As String = If(String.IsNullOrWhiteSpace(equipo), "Todos", equipo.Trim())
        Dim codificado As String = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(nombre))
        Return "clientePerfil:" & codificado & ":" & campo
    End Function

    Private Function CifrarConfigServidor(valor As String) As String
        Dim bytes As Byte() = System.Text.Encoding.UTF8.GetBytes(If(valor, ""))
        Return Convert.ToBase64String(Security.Cryptography.ProtectedData.Protect(bytes, Nothing, Security.Cryptography.DataProtectionScope.CurrentUser))
    End Function

    Private Function DescifrarConfigServidor(valor As String) As String
        Try
            Dim bytes As Byte() = Convert.FromBase64String(valor)
            Return System.Text.Encoding.UTF8.GetString(Security.Cryptography.ProtectedData.Unprotect(bytes, Nothing, Security.Cryptography.DataProtectionScope.CurrentUser))
        Catch
            Return ""
        End Try
    End Function

    Private Sub CargarPerfilClienteSeleccionado()
        If _cargandoRed Then Return
        Try
            Dim equipo As String = If(String.IsNullOrWhiteSpace(cboCfgEq.Text), "Todos", cboCfgEq.Text)
            Dim equipoDefecto As String = If(equipo = "Todos", "", "Todos")
            Dim leer As Func(Of String, String, String) =
                Function(campo As String, defecto As String) Servidor.Data.Db.GetConfig(ClavePerfilCliente(equipo, campo), Servidor.Data.Db.GetConfig(ClavePerfilCliente(equipoDefecto, campo), defecto))
            txtCfgSrv.Text = leer("servidor", IpLocal())
            txtCfgCiber.Text = leer("ciber", "")
            Dim n As Decimal
            If Decimal.TryParse(leer("tmsg", "5"), n) Then numCfgMsg.Value = Math.Max(numCfgMsg.Minimum, Math.Min(numCfgMsg.Maximum, n))
            If Decimal.TryParse(leer("tpre", "5"), n) Then numCfgPre.Value = Math.Max(numCfgPre.Minimum, Math.Min(numCfgPre.Maximum, n))
            Dim indice As Integer
            If Integer.TryParse(leer("taskmgr", "0"), indice) Then cboTaskMgr.SelectedIndex = Math.Max(0, Math.Min(cboTaskMgr.Items.Count - 1, indice))
            If Integer.TryParse(leer("autostart", "0"), indice) Then cboAutostart.SelectedIndex = Math.Max(0, Math.Min(cboAutostart.Items.Count - 1, indice))
            txtCfgPass.Text = DescifrarConfigServidor(leer("pass", ""))
        Catch ex As Exception
            LogErr("Cargar perfil de configuración cliente", ex)
        End Try
    End Sub

    Private Sub GuardarPerfilCliente(equipo As String)
        Dim clave As Func(Of String, String) = Function(campo As String) ClavePerfilCliente(equipo, campo)
        Servidor.Data.Db.SetConfig(clave("servidor"), txtCfgSrv.Text.Trim())
        Servidor.Data.Db.SetConfig(clave("ciber"), txtCfgCiber.Text.Trim())
        Servidor.Data.Db.SetConfig(clave("tmsg"), CInt(numCfgMsg.Value).ToString())
        Servidor.Data.Db.SetConfig(clave("tpre"), CInt(numCfgPre.Value).ToString())
        Servidor.Data.Db.SetConfig(clave("taskmgr"), Math.Max(0, cboTaskMgr.SelectedIndex).ToString())
        Servidor.Data.Db.SetConfig(clave("autostart"), Math.Max(0, cboAutostart.SelectedIndex).ToString())
        If txtCfgPass.Text <> "" Then Servidor.Data.Db.SetConfig(clave("pass"), CifrarConfigServidor(txtCfgPass.Text))
    End Sub

    Private Sub CargarFondoGuardado()
        Try
            Dim codificado As String = Servidor.Data.Db.GetConfig("fondoBloqueoBytes", "")
            If codificado = "" Then Return
            _fondoBytes = Convert.FromBase64String(codificado)
            _fondoNombre = Servidor.Data.Db.GetConfig("fondoBloqueoNombre", "Fondo guardado")
            lblFondoInfo.Text = _fondoNombre & " (" & (_fondoBytes.Length \ 1024).ToString() & " KB guardados)"
        Catch ex As Exception
            _fondoBytes = Nothing
            LogErr("Cargar fondo guardado", ex)
        End Try
    End Sub

    Private Sub cboCfgEq_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCfgEq.SelectedIndexChanged
        If _cargandoRed Then Return
        Servidor.Data.Db.SetConfig("clienteEquipoSeleccionado", If(String.IsNullOrWhiteSpace(cboCfgEq.Text), "Todos", cboCfgEq.Text))
        CargarPerfilClienteSeleccionado()
    End Sub

    Private Sub RedAgregar(s As Object, e As EventArgs) Handles bAddRed.Click
        Try
            ' Primer número libre (evita duplicar "Equipo N" si se eliminó alguno).
            Dim usados As New HashSet(Of String)()
            For Each r As DataRow In Servidor.Data.Db.ListarEquipos().Rows
                usados.Add(CStr(r("Nombre")).Trim().ToLower())
            Next
            Dim i As Integer = 1
            While usados.Contains(("Equipo " & i.ToString()).ToLower())
                i += 1
            End While
            Servidor.Data.Db.GuardarEquipo("Equipo " & i.ToString(), "")
            CargarRed() : CargarEquipos()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Red", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub RedGuardar(s As Object, e As EventArgs) Handles bSaveRed.Click
        Try
            dgvRed.EndEdit()
            For Each gr As DataGridViewRow In dgvRed.Rows
                If gr.IsNewRow Then Continue For
                Dim nombre As String = If(gr.Cells("Nombre").Value Is Nothing, "", CStr(gr.Cells("Nombre").Value))
                Dim v = gr.Cells("Ip").Value
                Dim ip As String = If(v Is Nothing OrElse v Is DBNull.Value, "", CStr(v)).Trim()
                If ip <> "" AndAlso Not Net.IPAddress.TryParse(ip, Nothing) Then
                    MessageBox.Show("IP inválida en " & nombre & ": " & ip,
                                    "Red", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
                Servidor.Data.Db.GuardarEquipo(nombre, ip)
            Next
            MessageBox.Show("Red guardada.", "Red", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CargarEquipos()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Red", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub RedEliminar(s As Object, e As EventArgs) Handles bDelRed.Click
        Try
            If dgvRed.CurrentRow Is Nothing Then Return
            Dim id As Integer = CInt(dgvRed.CurrentRow.Cells("Id").Value)
            Dim nom As String = CStr(dgvRed.CurrentRow.Cells("Nombre").Value)
            If MessageBox.Show("¿Eliminar " & nom & "?", "Red",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
            Servidor.Data.Db.EliminarEquipo(id)
            CargarRed() : CargarEquipos()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Red", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub RedGuardarPuerto(s As Object, e As EventArgs) Handles bPortRed.Click
        Dim p As Integer
        If Not Integer.TryParse(txtPuerto.Text.Trim(), p) OrElse p <= 0 OrElse p > 65535 Then
            MessageBox.Show("Puerto inválido (1-65535).", "Red", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        ' Propagar a los clientes ANTES de cambiarlo (escuchan en el puerto viejo).
        Try
            Dim oldP As Integer = Servidor.Data.Db.Puerto()
            For Each r As DataRow In Servidor.Data.Db.ListarEquipos().Rows
                Dim ip As String = If(r("Ip") Is DBNull.Value, "", CStr(r("Ip"))).Trim()
                Dim a As Net.IPAddress = Nothing
                If ip <> "" AndAlso Net.IPAddress.TryParse(ip, a) Then
                    Try : NetProtocol.SendUdp(ip, oldP, "SETCFG", "puerto", p.ToString()) : Catch : End Try
                End If
            Next
        Catch
        End Try
        Servidor.Data.Db.SetConfig("puerto", p.ToString())
        My.Settings.puerto = p : My.Settings.Save()
        Try : ScreenHub.Ensure(p) : Catch : End Try
        MessageBox.Show("Puerto guardado y enviado a los clientes.", "Red", MessageBoxButtons.OK, MessageBoxIcon.Information)
        CargarEquipos()
    End Sub

    Private Function IpLocal() As String
        Try
            For Each a As Net.IPAddress In Net.Dns.GetHostEntry(Net.Dns.GetHostName()).AddressList
                If a.AddressFamily = Net.Sockets.AddressFamily.InterNetwork AndAlso Not Net.IPAddress.IsLoopback(a) Then
                    Return a.ToString()
                End If
            Next
        Catch
        End Try
        Return ""
    End Function

    ''' <summary>Detecta el typo clásico (198.x en vez de 192.168.x): avisa si no es red privada.</summary>
    Private Function EsRedPrivada(srv As String) As Boolean
        Try
            If srv.StartsWith("192.168.") OrElse srv.StartsWith("10.") Then Return True
            If srv.StartsWith("172.") Then
                Dim n As Integer
                If Integer.TryParse(srv.Split("."c)(1), n) AndAlso n >= 16 AndAlso n <= 31 Then Return True
            End If
        Catch
        End Try
        Return False
    End Function

    ''' <summary>Envía SETCFG al equipo elegido o a todos. El cliente lo guarda cifrado.</summary>
    Private Sub CfgEnviar(s As Object, e As EventArgs) Handles bCfgEnviar.Click
        Try
            ' El puerto es global: solo se cambia con "Guardar puerto" (propaga a todos).
            Dim srv As String = txtCfgSrv.Text.Trim()
            If srv <> "" AndAlso Not Net.IPAddress.TryParse(srv, Nothing) Then
                MessageBox.Show("IP de servidor inválida.", "Red", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If srv <> "" AndAlso Not EsRedPrivada(srv) Then
                If MessageBox.Show(srv & " no parece una IP local (lo normal es 192.168.x.x). ¿Enviar igual?",
                                   "Red", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
            End If
            Dim objetivos As New List(Of String)()
            Dim equiposDestino As New List(Of String)()
            If cboCfgEq.Text = "Todos" OrElse cboCfgEq.Text = "" Then
                For Each r As DataRow In Servidor.Data.Db.ListarEquipos().Rows
                    Dim ip As String = If(r("Ip") Is DBNull.Value, "", CStr(r("Ip"))).Trim()
                    If ip <> "" Then
                        objetivos.Add(ip)
                        equiposDestino.Add(CStr(r("Nombre")))
                    End If
                Next
            Else
                Dim ip1 As String = Servidor.Data.Db.IpDeEquipo(cboCfgEq.Text)
                If ip1 <> "" Then
                    objetivos.Add(ip1.Trim())
                    equiposDestino.Add(cboCfgEq.Text)
                End If
            End If
            If objetivos.Count = 0 Then
                MessageBox.Show("Sin equipos con IP para configurar.", "Red",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            Dim keys As New List(Of Tuple(Of String, String))()
            If srv <> "" Then keys.Add(Tuple.Create("servidor", srv))
            If txtCfgCiber.Text.Trim() <> "" Then keys.Add(Tuple.Create("ciber", txtCfgCiber.Text.Trim()))
            keys.Add(Tuple.Create("tmsg", CInt(numCfgMsg.Value).ToString()))
            keys.Add(Tuple.Create("tpre", CInt(numCfgPre.Value).ToString()))
            If txtCfgPass.Text <> "" Then keys.Add(Tuple.Create("pass", txtCfgPass.Text))
            If cboTaskMgr.SelectedIndex = 1 Then keys.Add(Tuple.Create("taskmgr", "true"))
            If cboTaskMgr.SelectedIndex = 2 Then keys.Add(Tuple.Create("taskmgr", "false"))
            If cboAutostart.SelectedIndex = 1 Then keys.Add(Tuple.Create("autostart", "true"))
            If cboAutostart.SelectedIndex = 2 Then keys.Add(Tuple.Create("autostart", "false"))
            Dim n As Integer = 0
            For Each ip In objetivos
                For Each k In keys
                    Try
                        NetProtocol.SendUdp(ip, Servidor.Data.Db.Puerto(), "SETCFG", k.Item1, k.Item2)
                    Catch
                    End Try
                Next
                n += 1
            Next
            Servidor.Data.Db.SetConfig("clienteEquipoSeleccionado", If(String.IsNullOrWhiteSpace(cboCfgEq.Text), "Todos", cboCfgEq.Text))
            GuardarPerfilCliente("Todos")
            For Each equipo As String In equiposDestino
                GuardarPerfilCliente(equipo)
            Next
            MessageBox.Show("Configuración enviada a " & n.ToString() & " equipo(s).",
                            "Red", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Red", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '================ FONDO DE BLOQUEO =================
    Private Sub btnElegirFondo_Click(s As Object, e As EventArgs) Handles btnElegirFondo.Click
        Try
            Using dlg As New OpenFileDialog()
                dlg.Title = "Elegir fondo de bloqueo"
                dlg.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp|Todos|*.*"
                If dlg.ShowDialog(Me) <> DialogResult.OK Then Return
                _fondoBytes = PrepararFondo(dlg.FileName)
                If _fondoBytes Is Nothing Then
                    MessageBox.Show("No se pudo leer la imagen.", "Fondo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
                _fondoNombre = IO.Path.GetFileName(dlg.FileName)
                lblFondoInfo.Text = _fondoNombre & " (" & (_fondoBytes.Length \ 1024).ToString() & " KB listos para enviar)"
                Servidor.Data.Db.SetConfig("fondoBloqueoBytes", Convert.ToBase64String(_fondoBytes))
                Servidor.Data.Db.SetConfig("fondoBloqueoNombre", _fondoNombre)
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fondo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>Reescala a 1280 px y comprime a JPEG q65 para enviar por UDP.</summary>
    Private Function PrepararFondo(path As String) As Byte()
        Try
            Using orig As New Bitmap(path)
                Dim sc As Double = 1.0
                If orig.Width > 1280 Then sc = 1280.0 / orig.Width
                Dim nw As Integer = Math.Max(320, CInt(orig.Width * sc))
                Dim nh As Integer = Math.Max(200, CInt(orig.Height * sc))
                Using bmp As New Bitmap(nw, nh)
                    Using g As Graphics = Graphics.FromImage(bmp)
                        g.InterpolationMode = Drawing.Drawing2D.InterpolationMode.Bilinear
                        g.DrawImage(orig, 0, 0, nw, nh)
                    End Using
                    Using ms As New IO.MemoryStream()
                        Dim codec = ImageCodecInfo.GetImageEncoders().
                            FirstOrDefault(Function(c) c.FormatID = Imaging.ImageFormat.Jpeg.Guid)
                        If codec Is Nothing Then
                            bmp.Save(ms, Imaging.ImageFormat.Jpeg)
                        Else
                            Using ep As New Imaging.EncoderParameters(1)
                                ep.Param(0) = New Imaging.EncoderParameter(Imaging.Encoder.Quality, 65L)
                                bmp.Save(ms, codec, ep)
                            End Using
                        End If
                        Return ms.ToArray()
                    End Using
                End Using
            End Using
        Catch
            Return Nothing
        End Try
    End Function

    Private Sub btnEnviarFondo_Click(s As Object, e As EventArgs) Handles btnEnviarFondo.Click
        If _fondoBytes Is Nothing OrElse _fondoBytes.Length = 0 Then
            MessageBox.Show("Primero elige una imagen.", "Fondo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Try
            Servidor.Data.Db.SetConfig("fondoEquipoSeleccionado", If(String.IsNullOrWhiteSpace(cboFondoEq.Text), "Todos", cboFondoEq.Text))
            Dim objetivos As New List(Of String)()
            If cboFondoEq.Text = "Todos" OrElse cboFondoEq.Text = "" Then
                For Each r As DataRow In Servidor.Data.Db.ListarEquipos().Rows
                    Dim ip As String = If(r("Ip") Is DBNull.Value, "", CStr(r("Ip"))).Trim()
                    If ip <> "" Then objetivos.Add(ip)
                Next
            Else
                Dim ip1 As String = Servidor.Data.Db.IpDeEquipo(cboFondoEq.Text)
                If ip1 <> "" Then objetivos.Add(ip1.Trim())
            End If
            If objetivos.Count = 0 Then
                MessageBox.Show("Sin equipos con IP para enviar el fondo.", "Fondo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            Dim datos As Byte() = _fondoBytes
            Dim puerto As Integer = Servidor.Data.Db.Puerto()
            btnEnviarFondo.Enabled = False
            Task.Run(Sub()
                         Try
                             Dim b64 As String = Convert.ToBase64String(datos)
                             Dim trozo As Integer = 6000
                             Dim total As Integer = CInt(Math.Ceiling(b64.Length / CDbl(trozo)))
                             For Each ip In objetivos
                                 For pasada As Integer = 1 To 2 ' redundancia: UDP puede perder datagramas
                                     NetProtocol.SendUdp(ip, puerto, "FONDOINI", total.ToString(), "0")
                                     Threading.Thread.Sleep(30)
                                     For i As Integer = 0 To total - 1
                                         Dim st As Integer = i * trozo
                                         Dim ln As Integer = Math.Min(trozo, b64.Length - st)
                                         NetProtocol.SendUdp(ip, puerto, "FONDO", i.ToString("D5"), b64.Substring(st, ln))
                                         Threading.Thread.Sleep(15)
                                     Next
                                 Next
                             Next
                             Me.Invoke(Sub()
                                           btnEnviarFondo.Enabled = True
                                           MessageBox.Show("Fondo enviado a " & objetivos.Count.ToString() & " equipo(s).",
                                                           "Fondo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                       End Sub)
                         Catch ex As Exception
                             Try
                                 Me.Invoke(Sub()
                                               btnEnviarFondo.Enabled = True
                                               MessageBox.Show(ex.Message, "Fondo",
                                                               MessageBoxButtons.OK, MessageBoxIcon.Error)
                                           End Sub)
                             Catch
                             End Try
                         End Try
                     End Sub)
        Catch ex As Exception
            btnEnviarFondo.Enabled = True
            MessageBox.Show(ex.Message, "Fondo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub linkSitio_LinkClicked(s As Object, e As LinkLabelLinkClickedEventArgs) Handles linkSitio.LinkClicked
        Try
            Process.Start("https://kr-dev.site")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Acerca de", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnTerminos_Click(s As Object, e As EventArgs) Handles btnTerminos.Click
        Try
            Using f As New TerminosForm()
                f.ShowDialog(Me)
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Acerca de", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBuscarUpd_Click(s As Object, e As EventArgs) Handles btnBuscarUpd.Click
        If _updLista Then
            MostrarAvisoUpdate(_updInfo)
        Else
            RevisarUpdates(False)
        End If
    End Sub

    ''' <summary>Busca actualización en segundo plano. En arranque solo avisa discreto.</summary>
    Private Sub RevisarUpdates(fondo As Boolean)
        Task.Run(Sub()
                     Dim r = Actualizador.Comprobar()
                     If Me.IsDisposed Then Return
                     If r.HayNueva Then
                         Try
                             Me.Invoke(Sub()
                                           _updInfo = r : _updLista = True
                                           btnBuscarUpd.Text = "Actualizar a v" & r.Version
                                           Try : Theme.StyleButton(btnBuscarUpd, Theme.Success) : Catch : End Try
                                           ' Al arrancar también avisa: la búsqueda fue silenciosa,
                                           ' el resultado no (así se ve que sí comprobó).
                                           MostrarAvisoUpdate(r)
                                       End Sub)
                         Catch
                         End Try
                     ElseIf Not fondo Then
                         Try
                             Me.Invoke(Sub()
                                           If r.ErrorMsg <> "" Then
                                               MessageBox.Show(r.ErrorMsg, "Actualizaciones",
                                                               MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                           Else
                                               MessageBox.Show("Ya tienes la última versión (v" &
                                                               Actualizador.VERSION_ACTUAL & ").", "Actualizaciones",
                                                               MessageBoxButtons.OK, MessageBoxIcon.Information)
                                           End If
                                       End Sub)
                         Catch
                         End Try
                     End If
                 End Sub)
    End Sub

    Private Sub MostrarAvisoUpdate(r As Actualizador.InfoVersion)
        Try
            Dim t As String = "Hay una nueva versión: v" & r.Version & "." & vbCrLf & vbCrLf &
                If(String.IsNullOrWhiteSpace(r.Notas), "", r.Notas & vbCrLf & vbCrLf) &
                "¿Abrir la página de descarga?"
            If MessageBox.Show(t, "Actualización disponible",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                Process.Start(Actualizador.URL_DESCARGA)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Actualizaciones", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '================ NAVEGACIÓN =================
    Private Sub btnEquipos_Click(s As Object, e As EventArgs) Handles btnEquipos.Click
        MostrarPagina("Equipos")
    End Sub
    Private Sub btnVentas_Click(s As Object, e As EventArgs) Handles btnVentas.Click
        MostrarPagina("Ventas")
    End Sub
    Private Sub btnProductos_Click(s As Object, e As EventArgs) Handles btnProductos.Click
        MostrarPagina("Productos")
    End Sub
    Private Sub btnHist_Click(s As Object, e As EventArgs) Handles btnHist.Click
        MostrarPagina("Historial")
    End Sub
    Private Sub btnCaja_Click(s As Object, e As EventArgs) Handles btnCaja.Click
        MostrarPagina("Caja")
    End Sub
    Private Sub btnRed_Click(s As Object, e As EventArgs) Handles btnRed.Click
        MostrarPagina("Red")
    End Sub
    Private Sub btnAcerca_Click(s As Object, e As EventArgs) Handles btnAcerca.Click
        MostrarPagina("Acerca")
    End Sub
    Private Sub btnActualizar_Click(s As Object, e As EventArgs) Handles btnActualizar.Click
        RefrescarActual()
    End Sub

    Private Sub MostrarPagina(cual As String)
        pageEquipos.Visible = (cual = "Equipos")
        pageVentas.Visible = (cual = "Ventas")
        pageProductos.Visible = (cual = "Productos")
        pageHist.Visible = (cual = "Historial")
        pageCaja.Visible = (cual = "Caja")
        pageRed.Visible = (cual = "Red")
        pageAcerca.Visible = (cual = "Acerca")
        Select Case cual
            Case "Ventas" : lblTitulo.Text = "Punto de venta"
            Case "Productos" : lblTitulo.Text = "Productos"
            Case "Historial" : lblTitulo.Text = "Historial de ventas"
            Case "Caja" : lblTitulo.Text = "Caja del día"
            Case "Red" : lblTitulo.Text = "Red y equipos"
            Case "Acerca" : lblTitulo.Text = "Acerca de"
            Case Else : lblTitulo.Text = "Equipos"
        End Select
        Theme.StyleSideButton(btnEquipos, cual = "Equipos")
        Theme.StyleSideButton(btnVentas, cual = "Ventas")
        Theme.StyleSideButton(btnProductos, cual = "Productos")
        Theme.StyleSideButton(btnHist, cual = "Historial")
        Theme.StyleSideButton(btnCaja, cual = "Caja")
        Theme.StyleSideButton(btnRed, cual = "Red")
        Theme.StyleSideButton(btnAcerca, cual = "Acerca")
        RefrescarActual()
    End Sub

    Private Sub RefrescarActual()
        If pageCaja.Visible Then CargarCaja()
        If pageRed.Visible Then CargarRed()
        If pageVentas.Visible Then
            Try
                posCtl.Refrescar()
            Catch
            End Try
        End If
        If pageProductos.Visible Then
            Try
                prodCtl.Refrescar()
            Catch
            End Try
        End If
        If pageHist.Visible Then
            Try
                histCtl.Refrescar()
            Catch
            End Try
        End If
        If pageEquipos.Visible Then PingAll()
    End Sub

    '================ LOAD + POLLING =================
    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath)
        Catch
        End Try
        Try
            Servidor.Data.Db.Init()
            Servidor.Data.Db.MarcarSesionesRecuperadas()
            _cargandoPausa = True
            chkPausarAlCerrar.Checked = Servidor.Data.Db.GetConfig("pausarAlCerrarServidor", "true").Trim().Equals("true", StringComparison.OrdinalIgnoreCase)
            _cargandoPausa = False
        Catch ex As Exception
            MessageBox.Show("No se pudo iniciar la base de datos: " & ex.Message,
                            "Control Ciber", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        ' Escucha siempre activa: el estado por WiFi depende de ver video reciente.
        Try
            ScreenHub.Ensure(Servidor.Data.Db.Puerto())
        Catch
        End Try
        Try
            txtCfgSrv.Text = IpLocal()
        Catch
        End Try
        Top_Resize(Nothing, Nothing)
        CargarEquipos()
        CargarCaja()
        CargarRed()
        RevisarUpdates(True) ' chequeo silencioso al arrancar
        tReloj.Start()
        tPing.Start()
        PingAll()
        EnviarPulsosClientes()
    End Sub

    Private Sub CargarEquipos()
        Try
            flowEq.Controls.Clear()
            _cards.Clear()
            Dim dt = Servidor.Data.Db.ListarEquipos()
            If dt.Rows.Count = 0 Then
                For i As Integer = 1 To 6
                    Servidor.Data.Db.GuardarEquipo("Equipo " & i.ToString(), "")
                Next
                dt = Servidor.Data.Db.ListarEquipos()
            End If
            For Each r As DataRow In dt.Rows
                Dim card As New EquipoCard()
                card.LoadData(CStr(r("Nombre")), If(r("Ip") Is DBNull.Value, "", CStr(r("Ip"))))
                AddHandler card.SolicitarCobroEquipo, AddressOf SolicitarCobroEquipo
                Dim estado = ScreenHub.EstadoBloqueo(card.IpEquipo)
                If estado.HasValue Then card.SetEstadoBloqueo(estado.Value)
                flowEq.Controls.Add(card)
                _cards(card.NombreEquipo) = card
            Next
        Catch ex As Exception
            LogErr("CargarEquipos", ex)
            MessageBox.Show(ex.Message, "Equipos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub EstadoClienteRecibido(ip As String, bloqueado As Boolean)
        If IsDisposed OrElse Not IsHandleCreated Then Return
        Try
            BeginInvoke(New Action(Sub()
                                      For Each equipoCard As EquipoCard In _cards.Values
                                          If String.Equals(equipoCard.IpEquipo, ip, StringComparison.OrdinalIgnoreCase) Then
                                              equipoCard.SetEstadoBloqueo(bloqueado)
                                          End If
                                      Next
                                  End Sub))
        Catch
        End Try
    End Sub

    Private Sub SesionClientePausada(ip As String, inicio As DateTime, fin As DateTime, pausaDesde As DateTime)
        If IsDisposed OrElse Not IsHandleCreated Then Return
        Try
            BeginInvoke(New Action(Sub()
                                      For Each equipoCard As EquipoCard In _cards.Values
                                          If String.Equals(equipoCard.IpEquipo, ip, StringComparison.OrdinalIgnoreCase) Then
                                              equipoCard.SincronizarSesionPausada(inicio, fin, pausaDesde)
                                          End If
                                      Next
                                  End Sub))
        Catch
        End Try
    End Sub

    Private Sub PingAll()
        Try
            If _pingEnCurso Then Return
            _pingEnCurso = True
            Dim snapshot = _cards.Values.ToList()
            Dim ips = New Dictionary(Of String, String)()
            For Each c In snapshot
                ips(c.NombreEquipo) = EquipoIp(c.NombreEquipo)
            Next
            Task.Run(Sub()
                         Try
                             Dim res = New Dictionary(Of String, Nullable(Of Boolean))()
                             Dim vistos = ScreenHub.Remitentes()
                             For Each kv In ips
                                 Dim vivo As Nullable(Of Boolean) = HacerPing(kv.Value)
                                 ' WiFi: el ping (ICMP) puede perderse aunque el UDP pase.
                                 ' En línea si hay ping O si se vio video suyo hace <15 s.
                                 If (Not vivo.HasValue OrElse Not vivo.Value) AndAlso kv.Value <> "" Then
                                     Dim t As DateTime = DateTime.MinValue
                                     If vistos.TryGetValue(kv.Value.Trim(), t) AndAlso
                                        (DateTime.Now - t).TotalSeconds <= 15 Then
                                         vivo = True
                                     End If
                                 End If
                                 res(kv.Key) = vivo
                             Next
                             Try
                                 Me.Invoke(Sub()
                                               For Each kv In res
                                                   If _cards.ContainsKey(kv.Key) Then _cards(kv.Key).SetOnline(kv.Value)
                                               Next
                                           End Sub)
                             Catch
                             End Try
                         Finally
                             _pingEnCurso = False
                         End Try
                     End Sub)
        Catch
            _pingEnCurso = False
        End Try
    End Sub

    Private Function EquipoIp(nombre As String) As String
        Try
            Return Servidor.Data.Db.IpDeEquipo(nombre)
        Catch
            Return ""
        End Try
    End Function

    Private Function HacerPing(ip As String) As Nullable(Of Boolean)
        If String.IsNullOrWhiteSpace(ip) Then Return Nothing
        Try
            Using p As New Ping()
                Dim r = p.Send(ip.Trim(), 1200)
                Return r IsNot Nothing AndAlso r.Status = IPStatus.Success
            End Using
        Catch
            Return False
        End Try
    End Function

    Private Sub tReloj_Tick(sender As Object, e As EventArgs) Handles tReloj.Tick
        lblReloj.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
    End Sub

    Private Sub tPing_Tick(sender As Object, e As EventArgs) Handles tPing.Tick
        EnviarPulsosClientes()
        If pageEquipos.Visible Then PingAll()
    End Sub

    Private Sub chkPausarAlCerrar_CheckedChanged(sender As Object, e As EventArgs) Handles chkPausarAlCerrar.CheckedChanged
        If _cargandoPausa Then Return
        Try
            Servidor.Data.Db.SetConfig("pausarAlCerrarServidor", chkPausarAlCerrar.Checked.ToString())
        Catch ex As Exception
            LogErr("Guardar preferencia de pausa", ex)
        End Try
    End Sub

    Private Sub EnviarPulsosClientes()
        Try
            Dim puerto As Integer = Servidor.Data.Db.Puerto()
            Dim pausar As String = chkPausarAlCerrar.Checked.ToString().ToLowerInvariant()
            Dim vistos = ScreenHub.Remitentes()
            For Each equipoCard As EquipoCard In _cards.Values
                If String.IsNullOrWhiteSpace(equipoCard.IpEquipo) Then Continue For
                Dim visto As DateTime = DateTime.MinValue
                Dim tieneVisto As Boolean = vistos.TryGetValue(equipoCard.IpEquipo, visto)
                If equipoCard.TieneSesionActiva AndAlso
                   ((tieneVisto AndAlso (DateTime.Now - visto).TotalSeconds >= 15) OrElse
                    (Not tieneVisto AndAlso equipoCard.InicioSesionActual <> DateTime.MinValue AndAlso (DateTime.Now - equipoCard.InicioSesionActual).TotalSeconds >= 15)) Then
                    equipoCard.PausarPorDesconexion(If(tieneVisto, visto, DateTime.Now))
                End If
                Try
                    NetProtocol.SendUdp(equipoCard.IpEquipo, puerto, "PING", pausar, "0")
                    If equipoCard.SesionPendienteRecuperacion Then
                        NetProtocol.SendUdp(equipoCard.IpEquipo, puerto, "PAUSAR", "0", "0")
                    End If
                Catch
                End Try
            Next
        Catch
        End Try
    End Sub

    Private Sub Dashboard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try : tReloj.Stop() : Catch : End Try
        Try : tPing.Stop() : Catch : End Try
        If chkPausarAlCerrar.Checked Then
            Try : Servidor.Data.Db.MarcarSesionesRecuperadas() : Catch : End Try
            Try
                Dim puerto As Integer = Servidor.Data.Db.Puerto()
                For Each equipoCard As EquipoCard In _cards.Values
                    If String.IsNullOrWhiteSpace(equipoCard.IpEquipo) Then Continue For
                    Try : NetProtocol.SendUdp(equipoCard.IpEquipo, puerto, "PAUSAR", "0", "0") : Catch : End Try
                Next
            Catch
            End Try
        End If
    End Sub
End Class
