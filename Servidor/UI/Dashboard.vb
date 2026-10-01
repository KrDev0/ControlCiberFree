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

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        AplicarEstilos()
        tReloj.Interval = 1000
        tPing.Interval = 20000
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
            Theme.StyleGrid(dgvVentasHoy)
            Theme.StyleGrid(dgvSesHoy)
            Theme.StyleGrid(dgvRed)
        Catch
        End Try
    End Sub

    Private Sub Top_Resize(s As Object, e As EventArgs) Handles topBar.Resize
        btnActualizar.Left = topBar.Width - 130
        lblHoy.Left = topBar.Width - 440
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
            lblTotalHoy.Text = "Hoy: $" & t.ToString("N2")
            lblNTickets.Text = "Tickets: " & n.ToString()
            lblHoy.Text = "Hoy $" & t.ToString("N2")
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
                dgvRed.Columns("Ip").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End If
            dgvRed.ResumeLayout()
            txtPuerto.Text = Servidor.Data.Db.Puerto().ToString()
            Try
                cboCfgEq.Items.Clear()
                cboCfgEq.Items.Add("Todos")
                For Each r As DataRow In Servidor.Data.Db.ListarEquipos().Rows
                    cboCfgEq.Items.Add(CStr(r("Nombre")))
                Next
                If cboCfgEq.SelectedIndex < 0 Then cboCfgEq.SelectedIndex = 0
            Catch
            End Try
        Catch ex As Exception
            LogErr("CargarRed", ex)
            MessageBox.Show(ex.ToString() & vbCrLf & "(detalle en ciber_error.log)", "Red", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
            If cboCfgEq.Text = "Todos" OrElse cboCfgEq.Text = "" Then
                For Each r As DataRow In Servidor.Data.Db.ListarEquipos().Rows
                    Dim ip As String = If(r("Ip") Is DBNull.Value, "", CStr(r("Ip"))).Trim()
                    If ip <> "" Then objetivos.Add(ip)
                Next
            Else
                Dim ip1 As String = Servidor.Data.Db.IpDeEquipo(cboCfgEq.Text)
                If ip1 <> "" Then objetivos.Add(ip1.Trim())
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
            txtCfgPass.Clear()
            MessageBox.Show("Configuración enviada a " & n.ToString() & " equipo(s).",
                            "Red", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Red", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub linkSitio_LinkClicked(s As Object, e As LinkLabelLinkClickedEventArgs) Handles linkSitio.LinkClicked
        Try
            Process.Start("https://kr-dev.site")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Acerca de", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        Catch ex As Exception
            MessageBox.Show("No se pudo iniciar la base de datos: " & ex.Message,
                            "Control Ciber", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Try
            txtCfgSrv.Text = IpLocal()
        Catch
        End Try
        Top_Resize(Nothing, Nothing)
        CargarEquipos()
        CargarCaja()
        CargarRed()
        tReloj.Start()
        tPing.Start()
        PingAll()
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
                flowEq.Controls.Add(card)
                _cards(card.NombreEquipo) = card
            Next
        Catch ex As Exception
            LogErr("CargarEquipos", ex)
            MessageBox.Show(ex.Message, "Equipos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PingAll()
        Try
            Dim snapshot = _cards.Values.ToList()
            Dim ips = New Dictionary(Of String, String)()
            For Each c In snapshot
                ips(c.NombreEquipo) = EquipoIp(c.NombreEquipo)
            Next
            Task.Run(Sub()
                         Dim res = New Dictionary(Of String, Nullable(Of Boolean))()
                         For Each kv In ips
                             res(kv.Key) = HacerPing(kv.Value)
                         Next
                         Try
                             Me.Invoke(Sub()
                                           For Each kv In res
                                               If _cards.ContainsKey(kv.Key) Then _cards(kv.Key).SetOnline(kv.Value)
                                           Next
                                       End Sub)
                         Catch
                         End Try
                     End Sub)
        Catch
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
        If pageEquipos.Visible Then PingAll()
    End Sub

    Private Sub Dashboard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try : tReloj.Stop() : Catch : End Try
        Try : tPing.Stop() : Catch : End Try
    End Sub
End Class
