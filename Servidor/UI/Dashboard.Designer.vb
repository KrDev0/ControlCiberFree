<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dashboard
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dashboard))
        Me.side = New System.Windows.Forms.Panel()
        Me.lblVer = New System.Windows.Forms.Label()
        Me.btnAcerca = New System.Windows.Forms.Button()
        Me.btnRed = New System.Windows.Forms.Button()
        Me.btnCaja = New System.Windows.Forms.Button()
        Me.btnHist = New System.Windows.Forms.Button()
        Me.btnProductos = New System.Windows.Forms.Button()
        Me.btnVentas = New System.Windows.Forms.Button()
        Me.btnEquipos = New System.Windows.Forms.Button()
        Me.lblSub = New System.Windows.Forms.Label()
        Me.lblLogo = New System.Windows.Forms.Label()
        Me.topBar = New System.Windows.Forms.Panel()
        Me.lblHoy = New System.Windows.Forms.Label()
        Me.lblReloj = New System.Windows.Forms.Label()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.content = New System.Windows.Forms.Panel()
        Me.pageRed = New System.Windows.Forms.Panel()
        Me.dgvRed = New System.Windows.Forms.DataGridView()
        Me.barRed = New System.Windows.Forms.Panel()
        Me.bDelRed = New System.Windows.Forms.Button()
        Me.bSaveRed = New System.Windows.Forms.Button()
        Me.bAddRed = New System.Windows.Forms.Button()
        Me.lblPuerto = New System.Windows.Forms.Label()
        Me.txtPuerto = New System.Windows.Forms.TextBox()
        Me.bPortRed = New System.Windows.Forms.Button()
        Me.cfgRed = New System.Windows.Forms.GroupBox()
        Me.fCfg2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.lCfgMsg = New System.Windows.Forms.Label()
        Me.numCfgMsg = New System.Windows.Forms.NumericUpDown()
        Me.lCfgPre = New System.Windows.Forms.Label()
        Me.numCfgPre = New System.Windows.Forms.NumericUpDown()
        Me.lCfgPass = New System.Windows.Forms.Label()
        Me.txtCfgPass = New System.Windows.Forms.TextBox()
        Me.bCfgEnviar = New System.Windows.Forms.Button()
        Me.fCfg1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.lCfgEq = New System.Windows.Forms.Label()
        Me.cboCfgEq = New System.Windows.Forms.ComboBox()
        Me.lCfgSrv = New System.Windows.Forms.Label()
        Me.txtCfgSrv = New System.Windows.Forms.TextBox()
        Me.lCfgCiber = New System.Windows.Forms.Label()
        Me.txtCfgCiber = New System.Windows.Forms.TextBox()
        Me.hintRed = New System.Windows.Forms.Label()
        Me.pageAcerca = New System.Windows.Forms.Panel()
        Me.wrapAcerca = New System.Windows.Forms.Panel()
        Me.linkSitio = New System.Windows.Forms.LinkLabel()
        Me.gridAcerca = New System.Windows.Forms.TableLayoutPanel()
        Me.ak0 = New System.Windows.Forms.Label()
        Me.av0 = New System.Windows.Forms.Label()
        Me.ak1 = New System.Windows.Forms.Label()
        Me.av1 = New System.Windows.Forms.Label()
        Me.ak2 = New System.Windows.Forms.Label()
        Me.av2 = New System.Windows.Forms.Label()
        Me.ak3 = New System.Windows.Forms.Label()
        Me.av3 = New System.Windows.Forms.Label()
        Me.ak4 = New System.Windows.Forms.Label()
        Me.av4 = New System.Windows.Forms.Label()
        Me.lblDesc = New System.Windows.Forms.Label()
        Me.lblVer2 = New System.Windows.Forms.Label()
        Me.lblBig = New System.Windows.Forms.Label()
        Me.pageHist = New System.Windows.Forms.Panel()
        Me.histCtl = New Servidor.HistorialControl()
        Me.pageProductos = New System.Windows.Forms.Panel()
        Me.prodCtl = New Servidor.ProductosControl()
        Me.pageVentas = New System.Windows.Forms.Panel()
        Me.posCtl = New Servidor.PosControl()
        Me.pageCaja = New System.Windows.Forms.Panel()
        Me.splitCaja = New System.Windows.Forms.SplitContainer()
        Me.gVentasHoy = New System.Windows.Forms.GroupBox()
        Me.dgvVentasHoy = New System.Windows.Forms.DataGridView()
        Me.gSesHoy = New System.Windows.Forms.GroupBox()
        Me.dgvSesHoy = New System.Windows.Forms.DataGridView()
        Me.sumCaja = New System.Windows.Forms.Panel()
        Me.btnCajaHoy = New System.Windows.Forms.Button()
        Me.lblNTickets = New System.Windows.Forms.Label()
        Me.lblTotalHoy = New System.Windows.Forms.Label()
        Me.pageEquipos = New System.Windows.Forms.Panel()
        Me.flowEq = New System.Windows.Forms.FlowLayoutPanel()
        Me.side.SuspendLayout()
        Me.topBar.SuspendLayout()
        Me.content.SuspendLayout()
        Me.pageRed.SuspendLayout()
        CType(Me.dgvRed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.barRed.SuspendLayout()
        Me.cfgRed.SuspendLayout()
        Me.fCfg2.SuspendLayout()
        CType(Me.numCfgMsg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numCfgPre, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fCfg1.SuspendLayout()
        Me.pageAcerca.SuspendLayout()
        Me.wrapAcerca.SuspendLayout()
        Me.gridAcerca.SuspendLayout()
        Me.pageHist.SuspendLayout()
        Me.pageProductos.SuspendLayout()
        Me.pageVentas.SuspendLayout()
        Me.pageCaja.SuspendLayout()
        CType(Me.splitCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitCaja.Panel1.SuspendLayout()
        Me.splitCaja.Panel2.SuspendLayout()
        Me.splitCaja.SuspendLayout()
        Me.gVentasHoy.SuspendLayout()
        CType(Me.dgvVentasHoy, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gSesHoy.SuspendLayout()
        CType(Me.dgvSesHoy, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sumCaja.SuspendLayout()
        Me.pageEquipos.SuspendLayout()
        Me.SuspendLayout()
        '
        'side
        '
        Me.side.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.side.Controls.Add(Me.lblVer)
        Me.side.Controls.Add(Me.btnAcerca)
        Me.side.Controls.Add(Me.btnRed)
        Me.side.Controls.Add(Me.btnCaja)
        Me.side.Controls.Add(Me.btnHist)
        Me.side.Controls.Add(Me.btnProductos)
        Me.side.Controls.Add(Me.btnVentas)
        Me.side.Controls.Add(Me.btnEquipos)
        Me.side.Controls.Add(Me.lblSub)
        Me.side.Controls.Add(Me.lblLogo)
        Me.side.Dock = System.Windows.Forms.DockStyle.Left
        Me.side.Location = New System.Drawing.Point(0, 0)
        Me.side.Name = "side"
        Me.side.Size = New System.Drawing.Size(230, 681)
        Me.side.TabIndex = 0
        '
        'lblVer
        '
        Me.lblVer.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblVer.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblVer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
        Me.lblVer.Location = New System.Drawing.Point(0, 651)
        Me.lblVer.Name = "lblVer"
        Me.lblVer.Size = New System.Drawing.Size(230, 30)
        Me.lblVer.TabIndex = 9
        Me.lblVer.Text = "  v3.0"
        Me.lblVer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnAcerca
        '
        Me.btnAcerca.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnAcerca.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAcerca.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.btnAcerca.Location = New System.Drawing.Point(0, 408)
        Me.btnAcerca.Name = "btnAcerca"
        Me.btnAcerca.Padding = New System.Windows.Forms.Padding(18, 0, 0, 0)
        Me.btnAcerca.Size = New System.Drawing.Size(230, 52)
        Me.btnAcerca.TabIndex = 8
        Me.btnAcerca.Text = "  Acerca de"
        Me.btnAcerca.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAcerca.UseVisualStyleBackColor = True
        '
        'btnRed
        '
        Me.btnRed.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnRed.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRed.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.btnRed.Location = New System.Drawing.Point(0, 356)
        Me.btnRed.Name = "btnRed"
        Me.btnRed.Padding = New System.Windows.Forms.Padding(18, 0, 0, 0)
        Me.btnRed.Size = New System.Drawing.Size(230, 52)
        Me.btnRed.TabIndex = 7
        Me.btnRed.Text = "  Red y equipos"
        Me.btnRed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRed.UseVisualStyleBackColor = True
        '
        'btnCaja
        '
        Me.btnCaja.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCaja.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.btnCaja.Location = New System.Drawing.Point(0, 304)
        Me.btnCaja.Name = "btnCaja"
        Me.btnCaja.Padding = New System.Windows.Forms.Padding(18, 0, 0, 0)
        Me.btnCaja.Size = New System.Drawing.Size(230, 52)
        Me.btnCaja.TabIndex = 6
        Me.btnCaja.Text = "  Caja del día"
        Me.btnCaja.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCaja.UseVisualStyleBackColor = True
        '
        'btnHist
        '
        Me.btnHist.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnHist.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHist.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.btnHist.Location = New System.Drawing.Point(0, 252)
        Me.btnHist.Name = "btnHist"
        Me.btnHist.Padding = New System.Windows.Forms.Padding(18, 0, 0, 0)
        Me.btnHist.Size = New System.Drawing.Size(230, 52)
        Me.btnHist.TabIndex = 5
        Me.btnHist.Text = "  Historial"
        Me.btnHist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnHist.UseVisualStyleBackColor = True
        '
        'btnProductos
        '
        Me.btnProductos.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProductos.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.btnProductos.Location = New System.Drawing.Point(0, 200)
        Me.btnProductos.Name = "btnProductos"
        Me.btnProductos.Padding = New System.Windows.Forms.Padding(18, 0, 0, 0)
        Me.btnProductos.Size = New System.Drawing.Size(230, 52)
        Me.btnProductos.TabIndex = 4
        Me.btnProductos.Text = "  Productos"
        Me.btnProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProductos.UseVisualStyleBackColor = True
        '
        'btnVentas
        '
        Me.btnVentas.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVentas.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.btnVentas.Location = New System.Drawing.Point(0, 148)
        Me.btnVentas.Name = "btnVentas"
        Me.btnVentas.Padding = New System.Windows.Forms.Padding(18, 0, 0, 0)
        Me.btnVentas.Size = New System.Drawing.Size(230, 52)
        Me.btnVentas.TabIndex = 3
        Me.btnVentas.Text = "  Punto de venta"
        Me.btnVentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVentas.UseVisualStyleBackColor = True
        '
        'btnEquipos
        '
        Me.btnEquipos.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnEquipos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEquipos.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.btnEquipos.Location = New System.Drawing.Point(0, 96)
        Me.btnEquipos.Name = "btnEquipos"
        Me.btnEquipos.Padding = New System.Windows.Forms.Padding(18, 0, 0, 0)
        Me.btnEquipos.Size = New System.Drawing.Size(230, 52)
        Me.btnEquipos.TabIndex = 2
        Me.btnEquipos.Text = "  Equipos"
        Me.btnEquipos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEquipos.UseVisualStyleBackColor = True
        '
        'lblSub
        '
        Me.lblSub.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSub.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSub.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
        Me.lblSub.Location = New System.Drawing.Point(0, 70)
        Me.lblSub.Name = "lblSub"
        Me.lblSub.Padding = New System.Windows.Forms.Padding(18, 0, 0, 0)
        Me.lblSub.Size = New System.Drawing.Size(230, 26)
        Me.lblSub.TabIndex = 1
        Me.lblSub.Text = "Control v3.0 · SQLite"
        '
        'lblLogo
        '
        Me.lblLogo.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblLogo.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold)
        Me.lblLogo.ForeColor = System.Drawing.Color.White
        Me.lblLogo.Location = New System.Drawing.Point(0, 0)
        Me.lblLogo.Name = "lblLogo"
        Me.lblLogo.Padding = New System.Windows.Forms.Padding(18, 0, 0, 4)
        Me.lblLogo.Size = New System.Drawing.Size(230, 70)
        Me.lblLogo.TabIndex = 0
        Me.lblLogo.Text = "CYBER"
        Me.lblLogo.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'topBar
        '
        Me.topBar.BackColor = System.Drawing.Color.White
        Me.topBar.Controls.Add(Me.lblHoy)
        Me.topBar.Controls.Add(Me.lblReloj)
        Me.topBar.Controls.Add(Me.btnActualizar)
        Me.topBar.Controls.Add(Me.lblTitulo)
        Me.topBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.topBar.Location = New System.Drawing.Point(230, 0)
        Me.topBar.Name = "topBar"
        Me.topBar.Size = New System.Drawing.Size(954, 64)
        Me.topBar.TabIndex = 1
        '
        'lblHoy
        '
        Me.lblHoy.AutoSize = True
        Me.lblHoy.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblHoy.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.lblHoy.Location = New System.Drawing.Point(482, 20)
        Me.lblHoy.Name = "lblHoy"
        Me.lblHoy.Size = New System.Drawing.Size(59, 20)
        Me.lblHoy.TabIndex = 2
        Me.lblHoy.Text = "Hoy $0"
        '
        'lblReloj
        '
        Me.lblReloj.AutoSize = True
        Me.lblReloj.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lblReloj.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblReloj.Location = New System.Drawing.Point(652, 20)
        Me.lblReloj.Name = "lblReloj"
        Me.lblReloj.Size = New System.Drawing.Size(143, 20)
        Me.lblReloj.TabIndex = 3
        Me.lblReloj.Text = "30/09/2029 21:41:50"
        '
        'btnActualizar
        '
        Me.btnActualizar.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnActualizar.Location = New System.Drawing.Point(824, 14)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(110, 36)
        Me.btnActualizar.TabIndex = 1
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'lblTitulo
        '
        Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblTitulo.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(0, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Padding = New System.Windows.Forms.Padding(18, 0, 0, 0)
        Me.lblTitulo.Size = New System.Drawing.Size(420, 64)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Equipos"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'content
        '
        Me.content.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.content.Controls.Add(Me.pageAcerca)
        Me.content.Controls.Add(Me.pageHist)
        Me.content.Controls.Add(Me.pageProductos)
        Me.content.Controls.Add(Me.pageVentas)
        Me.content.Controls.Add(Me.pageCaja)
        Me.content.Controls.Add(Me.pageEquipos)
        Me.content.Controls.Add(Me.pageRed)
        Me.content.Dock = System.Windows.Forms.DockStyle.Fill
        Me.content.Location = New System.Drawing.Point(230, 64)
        Me.content.Name = "content"
        Me.content.Padding = New System.Windows.Forms.Padding(6)
        Me.content.Size = New System.Drawing.Size(954, 617)
        Me.content.TabIndex = 2
        '
        'pageRed
        '
        Me.pageRed.Controls.Add(Me.dgvRed)
        Me.pageRed.Controls.Add(Me.barRed)
        Me.pageRed.Controls.Add(Me.cfgRed)
        Me.pageRed.Controls.Add(Me.hintRed)
        Me.pageRed.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pageRed.Location = New System.Drawing.Point(6, 6)
        Me.pageRed.Name = "pageRed"
        Me.pageRed.Size = New System.Drawing.Size(942, 605)
        Me.pageRed.TabIndex = 5
        Me.pageRed.Visible = False
        '
        'dgvRed
        '
        Me.dgvRed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRed.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvRed.Location = New System.Drawing.Point(0, 56)
        Me.dgvRed.Name = "dgvRed"
        Me.dgvRed.Size = New System.Drawing.Size(942, 399)
        Me.dgvRed.TabIndex = 2
        '
        'barRed
        '
        Me.barRed.BackColor = System.Drawing.Color.White
        Me.barRed.Controls.Add(Me.bDelRed)
        Me.barRed.Controls.Add(Me.bSaveRed)
        Me.barRed.Controls.Add(Me.bAddRed)
        Me.barRed.Controls.Add(Me.lblPuerto)
        Me.barRed.Controls.Add(Me.txtPuerto)
        Me.barRed.Controls.Add(Me.bPortRed)
        Me.barRed.Dock = System.Windows.Forms.DockStyle.Top
        Me.barRed.Location = New System.Drawing.Point(0, 0)
        Me.barRed.Name = "barRed"
        Me.barRed.Padding = New System.Windows.Forms.Padding(10)
        Me.barRed.Size = New System.Drawing.Size(942, 56)
        Me.barRed.TabIndex = 0
        '
        'bDelRed
        '
        Me.bDelRed.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.bDelRed.Location = New System.Drawing.Point(262, 10)
        Me.bDelRed.Name = "bDelRed"
        Me.bDelRed.Size = New System.Drawing.Size(110, 36)
        Me.bDelRed.TabIndex = 2
        Me.bDelRed.Text = "Eliminar"
        Me.bDelRed.UseVisualStyleBackColor = True
        '
        'bSaveRed
        '
        Me.bSaveRed.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.bSaveRed.Location = New System.Drawing.Point(126, 10)
        Me.bSaveRed.Name = "bSaveRed"
        Me.bSaveRed.Size = New System.Drawing.Size(130, 36)
        Me.bSaveRed.TabIndex = 1
        Me.bSaveRed.Text = "Guardar IPs"
        Me.bSaveRed.UseVisualStyleBackColor = True
        '
        'bAddRed
        '
        Me.bAddRed.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.bAddRed.Location = New System.Drawing.Point(10, 10)
        Me.bAddRed.Name = "bAddRed"
        Me.bAddRed.Size = New System.Drawing.Size(110, 36)
        Me.bAddRed.TabIndex = 0
        Me.bAddRed.Text = "+ Equipo"
        Me.bAddRed.UseVisualStyleBackColor = True
        '
        'lblPuerto
        '
        Me.lblPuerto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPuerto.AutoSize = True
        Me.lblPuerto.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lblPuerto.Location = New System.Drawing.Point(625, 10)
        Me.lblPuerto.Name = "lblPuerto"
        Me.lblPuerto.Padding = New System.Windows.Forms.Padding(0, 8, 6, 0)
        Me.lblPuerto.Size = New System.Drawing.Size(61, 28)
        Me.lblPuerto.TabIndex = 3
        Me.lblPuerto.Text = "Puerto:"
        '
        'txtPuerto
        '
        Me.txtPuerto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPuerto.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtPuerto.Location = New System.Drawing.Point(686, 10)
        Me.txtPuerto.Name = "txtPuerto"
        Me.txtPuerto.Size = New System.Drawing.Size(100, 27)
        Me.txtPuerto.TabIndex = 4
        '
        'bPortRed
        '
        Me.bPortRed.Dock = System.Windows.Forms.DockStyle.Right
        Me.bPortRed.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.bPortRed.Location = New System.Drawing.Point(792, 10)
        Me.bPortRed.Name = "bPortRed"
        Me.bPortRed.Size = New System.Drawing.Size(140, 36)
        Me.bPortRed.TabIndex = 5
        Me.bPortRed.Text = "Guardar puerto"
        Me.bPortRed.UseVisualStyleBackColor = True
        '
        'cfgRed
        '
        Me.cfgRed.BackColor = System.Drawing.Color.White
        Me.cfgRed.Controls.Add(Me.fCfg2)
        Me.cfgRed.Controls.Add(Me.fCfg1)
        Me.cfgRed.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cfgRed.Location = New System.Drawing.Point(0, 455)
        Me.cfgRed.Name = "cfgRed"
        Me.cfgRed.Size = New System.Drawing.Size(942, 120)
        Me.cfgRed.TabIndex = 1
        Me.cfgRed.TabStop = False
        Me.cfgRed.Text = "Configurar cliente (el equipo la guarda cifrada en cliente.cfg)"
        '
        'fCfg2
        '
        Me.fCfg2.BackColor = System.Drawing.Color.White
        Me.fCfg2.Controls.Add(Me.lCfgMsg)
        Me.fCfg2.Controls.Add(Me.numCfgMsg)
        Me.fCfg2.Controls.Add(Me.lCfgPre)
        Me.fCfg2.Controls.Add(Me.numCfgPre)
        Me.fCfg2.Controls.Add(Me.lCfgPass)
        Me.fCfg2.Controls.Add(Me.txtCfgPass)
        Me.fCfg2.Controls.Add(Me.bCfgEnviar)
        Me.fCfg2.Dock = System.Windows.Forms.DockStyle.Top
        Me.fCfg2.Location = New System.Drawing.Point(3, 56)
        Me.fCfg2.Name = "fCfg2"
        Me.fCfg2.Size = New System.Drawing.Size(936, 40)
        Me.fCfg2.TabIndex = 1
        '
        'lCfgMsg
        '
        Me.lCfgMsg.AutoSize = True
        Me.lCfgMsg.Location = New System.Drawing.Point(3, 0)
        Me.lCfgMsg.Name = "lCfgMsg"
        Me.lCfgMsg.Padding = New System.Windows.Forms.Padding(0, 8, 4, 0)
        Me.lCfgMsg.Size = New System.Drawing.Size(74, 21)
        Me.lCfgMsg.TabIndex = 0
        Me.lCfgMsg.Text = "T.mensaje(s):"
        '
        'numCfgMsg
        '
        Me.numCfgMsg.Location = New System.Drawing.Point(83, 3)
        Me.numCfgMsg.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
        Me.numCfgMsg.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numCfgMsg.Name = "numCfgMsg"
        Me.numCfgMsg.Size = New System.Drawing.Size(60, 20)
        Me.numCfgMsg.TabIndex = 1
        Me.numCfgMsg.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'lCfgPre
        '
        Me.lCfgPre.AutoSize = True
        Me.lCfgPre.Location = New System.Drawing.Point(149, 0)
        Me.lCfgPre.Name = "lCfgPre"
        Me.lCfgPre.Padding = New System.Windows.Forms.Padding(10, 8, 4, 0)
        Me.lCfgPre.Size = New System.Drawing.Size(87, 21)
        Me.lCfgPre.TabIndex = 2
        Me.lCfgPre.Text = "Preaviso(min):"
        '
        'numCfgPre
        '
        Me.numCfgPre.Location = New System.Drawing.Point(242, 3)
        Me.numCfgPre.Maximum = New Decimal(New Integer() {120, 0, 0, 0})
        Me.numCfgPre.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numCfgPre.Name = "numCfgPre"
        Me.numCfgPre.Size = New System.Drawing.Size(60, 20)
        Me.numCfgPre.TabIndex = 3
        Me.numCfgPre.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'lCfgPass
        '
        Me.lCfgPass.AutoSize = True
        Me.lCfgPass.Location = New System.Drawing.Point(308, 0)
        Me.lCfgPass.Name = "lCfgPass"
        Me.lCfgPass.Padding = New System.Windows.Forms.Padding(10, 8, 4, 0)
        Me.lCfgPass.Size = New System.Drawing.Size(85, 21)
        Me.lCfgPass.TabIndex = 4
        Me.lCfgPass.Text = "Nueva clave:"
        '
        'txtCfgPass
        '
        Me.txtCfgPass.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtCfgPass.Location = New System.Drawing.Point(399, 3)
        Me.txtCfgPass.Name = "txtCfgPass"
        Me.txtCfgPass.Size = New System.Drawing.Size(130, 25)
        Me.txtCfgPass.TabIndex = 5
        Me.txtCfgPass.UseSystemPasswordChar = True
        '
        'bCfgEnviar
        '
        Me.bCfgEnviar.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.bCfgEnviar.Location = New System.Drawing.Point(535, 3)
        Me.bCfgEnviar.Name = "bCfgEnviar"
        Me.bCfgEnviar.Size = New System.Drawing.Size(150, 32)
        Me.bCfgEnviar.TabIndex = 6
        Me.bCfgEnviar.Text = "Enviar al cliente"
        Me.bCfgEnviar.UseVisualStyleBackColor = True
        '
        'fCfg1
        '
        Me.fCfg1.BackColor = System.Drawing.Color.White
        Me.fCfg1.Controls.Add(Me.lCfgEq)
        Me.fCfg1.Controls.Add(Me.cboCfgEq)
        Me.fCfg1.Controls.Add(Me.lCfgSrv)
        Me.fCfg1.Controls.Add(Me.txtCfgSrv)
        Me.fCfg1.Controls.Add(Me.lCfgCiber)
        Me.fCfg1.Controls.Add(Me.txtCfgCiber)
        Me.fCfg1.Dock = System.Windows.Forms.DockStyle.Top
        Me.fCfg1.Location = New System.Drawing.Point(3, 16)
        Me.fCfg1.Name = "fCfg1"
        Me.fCfg1.Size = New System.Drawing.Size(936, 40)
        Me.fCfg1.TabIndex = 0
        '
        'lCfgEq
        '
        Me.lCfgEq.AutoSize = True
        Me.lCfgEq.Location = New System.Drawing.Point(3, 0)
        Me.lCfgEq.Name = "lCfgEq"
        Me.lCfgEq.Padding = New System.Windows.Forms.Padding(0, 8, 4, 0)
        Me.lCfgEq.Size = New System.Drawing.Size(47, 21)
        Me.lCfgEq.TabIndex = 0
        Me.lCfgEq.Text = "Equipo:"
        '
        'cboCfgEq
        '
        Me.cboCfgEq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCfgEq.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cboCfgEq.FormattingEnabled = True
        Me.cboCfgEq.Location = New System.Drawing.Point(56, 3)
        Me.cboCfgEq.Name = "cboCfgEq"
        Me.cboCfgEq.Size = New System.Drawing.Size(130, 25)
        Me.cboCfgEq.TabIndex = 1
        '
        'lCfgSrv
        '
        Me.lCfgSrv.AutoSize = True
        Me.lCfgSrv.Location = New System.Drawing.Point(192, 0)
        Me.lCfgSrv.Name = "lCfgSrv"
        Me.lCfgSrv.Padding = New System.Windows.Forms.Padding(0, 8, 4, 0)
        Me.lCfgSrv.Size = New System.Drawing.Size(64, 21)
        Me.lCfgSrv.TabIndex = 2
        Me.lCfgSrv.Text = "IP servidor:"
        '
        'txtCfgSrv
        '
        Me.txtCfgSrv.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtCfgSrv.Location = New System.Drawing.Point(262, 3)
        Me.txtCfgSrv.Name = "txtCfgSrv"
        Me.txtCfgSrv.Size = New System.Drawing.Size(130, 25)
        Me.txtCfgSrv.TabIndex = 3
        '
        'lCfgCiber
        '
        Me.lCfgCiber.AutoSize = True
        Me.lCfgCiber.Location = New System.Drawing.Point(398, 0)
        Me.lCfgCiber.Name = "lCfgCiber"
        Me.lCfgCiber.Padding = New System.Windows.Forms.Padding(10, 8, 4, 0)
        Me.lCfgCiber.Size = New System.Drawing.Size(48, 21)
        Me.lCfgCiber.TabIndex = 4
        Me.lCfgCiber.Text = "Ciber:"
        '
        'txtCfgCiber
        '
        Me.txtCfgCiber.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtCfgCiber.Location = New System.Drawing.Point(452, 3)
        Me.txtCfgCiber.Name = "txtCfgCiber"
        Me.txtCfgCiber.Size = New System.Drawing.Size(170, 25)
        Me.txtCfgCiber.TabIndex = 5
        '
        'hintRed
        '
        Me.hintRed.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.hintRed.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.hintRed.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.hintRed.Location = New System.Drawing.Point(0, 575)
        Me.hintRed.Name = "hintRed"
        Me.hintRed.Padding = New System.Windows.Forms.Padding(10, 6, 0, 0)
        Me.hintRed.Size = New System.Drawing.Size(942, 30)
        Me.hintRed.TabIndex = 3
        Me.hintRed.Text = "Edita la columna Ip y pulsa Guardar IPs. El cambio se refleja en las tarjetas."
        '
        'pageAcerca
        '
        Me.pageAcerca.BackColor = System.Drawing.Color.White
        Me.pageAcerca.Controls.Add(Me.wrapAcerca)
        Me.pageAcerca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pageAcerca.Location = New System.Drawing.Point(6, 6)
        Me.pageAcerca.Name = "pageAcerca"
        Me.pageAcerca.Size = New System.Drawing.Size(942, 605)
        Me.pageAcerca.TabIndex = 6
        Me.pageAcerca.Visible = False
        '
        'wrapAcerca
        '
        Me.wrapAcerca.BackColor = System.Drawing.Color.White
        Me.wrapAcerca.Controls.Add(Me.linkSitio)
        Me.wrapAcerca.Controls.Add(Me.gridAcerca)
        Me.wrapAcerca.Controls.Add(Me.lblDesc)
        Me.wrapAcerca.Controls.Add(Me.lblVer2)
        Me.wrapAcerca.Controls.Add(Me.lblBig)
        Me.wrapAcerca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wrapAcerca.Location = New System.Drawing.Point(0, 0)
        Me.wrapAcerca.Name = "wrapAcerca"
        Me.wrapAcerca.Padding = New System.Windows.Forms.Padding(40)
        Me.wrapAcerca.Size = New System.Drawing.Size(942, 605)
        Me.wrapAcerca.TabIndex = 0
        '
        'linkSitio
        '
        Me.linkSitio.Dock = System.Windows.Forms.DockStyle.Top
        Me.linkSitio.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.linkSitio.LinkColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.linkSitio.Location = New System.Drawing.Point(40, 424)
        Me.linkSitio.Name = "linkSitio"
        Me.linkSitio.Size = New System.Drawing.Size(862, 34)
        Me.linkSitio.TabIndex = 4
        Me.linkSitio.TabStop = True
        Me.linkSitio.Text = "kr-dev.site"
        '
        'gridAcerca
        '
        Me.gridAcerca.BackColor = System.Drawing.Color.White
        Me.gridAcerca.ColumnCount = 2
        Me.gridAcerca.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170.0!))
        Me.gridAcerca.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.gridAcerca.Controls.Add(Me.ak0, 0, 0)
        Me.gridAcerca.Controls.Add(Me.av0, 1, 0)
        Me.gridAcerca.Controls.Add(Me.ak1, 0, 1)
        Me.gridAcerca.Controls.Add(Me.av1, 1, 1)
        Me.gridAcerca.Controls.Add(Me.ak2, 0, 2)
        Me.gridAcerca.Controls.Add(Me.av2, 1, 2)
        Me.gridAcerca.Controls.Add(Me.ak3, 0, 3)
        Me.gridAcerca.Controls.Add(Me.av3, 1, 3)
        Me.gridAcerca.Controls.Add(Me.ak4, 0, 4)
        Me.gridAcerca.Controls.Add(Me.av4, 1, 4)
        Me.gridAcerca.Dock = System.Windows.Forms.DockStyle.Top
        Me.gridAcerca.Location = New System.Drawing.Point(40, 204)
        Me.gridAcerca.Name = "gridAcerca"
        Me.gridAcerca.RowCount = 5
        Me.gridAcerca.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.gridAcerca.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.gridAcerca.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.gridAcerca.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.gridAcerca.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.gridAcerca.Size = New System.Drawing.Size(862, 220)
        Me.gridAcerca.TabIndex = 3
        '
        'ak0
        '
        Me.ak0.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ak0.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.ak0.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.ak0.Location = New System.Drawing.Point(3, 0)
        Me.ak0.Name = "ak0"
        Me.ak0.Size = New System.Drawing.Size(164, 40)
        Me.ak0.TabIndex = 0
        Me.ak0.Text = "Versión"
        Me.ak0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'av0
        '
        Me.av0.Dock = System.Windows.Forms.DockStyle.Fill
        Me.av0.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.av0.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.av0.Location = New System.Drawing.Point(173, 0)
        Me.av0.Name = "av0"
        Me.av0.Size = New System.Drawing.Size(686, 40)
        Me.av0.TabIndex = 1
        Me.av0.Text = "3.0 (SQLite + UDP)"
        Me.av0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ak1
        '
        Me.ak1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ak1.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.ak1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.ak1.Location = New System.Drawing.Point(3, 40)
        Me.ak1.Name = "ak1"
        Me.ak1.Size = New System.Drawing.Size(164, 40)
        Me.ak1.TabIndex = 2
        Me.ak1.Text = "Base de datos"
        Me.ak1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'av1
        '
        Me.av1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.av1.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.av1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.av1.Location = New System.Drawing.Point(173, 40)
        Me.av1.Name = "av1"
        Me.av1.Size = New System.Drawing.Size(686, 40)
        Me.av1.TabIndex = 3
        Me.av1.Text = "ciber.db (SQLite, junto al ejecutable)"
        Me.av1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ak2
        '
        Me.ak2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ak2.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.ak2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.ak2.Location = New System.Drawing.Point(3, 80)
        Me.ak2.Name = "ak2"
        Me.ak2.Size = New System.Drawing.Size(164, 40)
        Me.ak2.TabIndex = 4
        Me.ak2.Text = "Comunicación"
        Me.ak2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'av2
        '
        Me.av2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.av2.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.av2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.av2.Location = New System.Drawing.Point(173, 80)
        Me.av2.Name = "av2"
        Me.av2.Size = New System.Drawing.Size(686, 40)
        Me.av2.TabIndex = 5
        Me.av2.Text = "UDP + ping de estado"
        Me.av2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ak3
        '
        Me.ak3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ak3.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.ak3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.ak3.Location = New System.Drawing.Point(3, 120)
        Me.ak3.Name = "ak3"
        Me.ak3.Size = New System.Drawing.Size(164, 40)
        Me.ak3.TabIndex = 6
        Me.ak3.Text = "Desarrollador"
        Me.ak3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'av3
        '
        Me.av3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.av3.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.av3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.av3.Location = New System.Drawing.Point(173, 120)
        Me.av3.Name = "av3"
        Me.av3.Size = New System.Drawing.Size(686, 40)
        Me.av3.TabIndex = 7
        Me.av3.Text = "KrDev"
        Me.av3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ak4
        '
        Me.ak4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ak4.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.ak4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.ak4.Location = New System.Drawing.Point(3, 160)
        Me.ak4.Name = "ak4"
        Me.ak4.Size = New System.Drawing.Size(164, 60)
        Me.ak4.TabIndex = 8
        Me.ak4.Text = "Módulos"
        Me.ak4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'av4
        '
        Me.av4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.av4.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.av4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.av4.Location = New System.Drawing.Point(173, 160)
        Me.av4.Name = "av4"
        Me.av4.Size = New System.Drawing.Size(686, 60)
        Me.av4.TabIndex = 9
        Me.av4.Text = "Equipos · Punto de venta · Productos · Historial · Caja · Red · Monitoreo"
        Me.av4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDesc
        '
        Me.lblDesc.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblDesc.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lblDesc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblDesc.Location = New System.Drawing.Point(40, 144)
        Me.lblDesc.Name = "lblDesc"
        Me.lblDesc.Size = New System.Drawing.Size(862, 60)
        Me.lblDesc.TabIndex = 2
        Me.lblDesc.Text = "Sistema de administración para cibercafés: control de tiempos por equipo," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "punto " &
    "de venta, productos, historial, caja y monitoreo de pantallas en vivo."
        '
        'lblVer2
        '
        Me.lblVer2.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblVer2.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblVer2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.lblVer2.Location = New System.Drawing.Point(40, 110)
        Me.lblVer2.Name = "lblVer2"
        Me.lblVer2.Size = New System.Drawing.Size(862, 34)
        Me.lblVer2.TabIndex = 1
        Me.lblVer2.Text = "Control de Ciber v3.0"
        '
        'lblBig
        '
        Me.lblBig.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblBig.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Bold)
        Me.lblBig.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.lblBig.Location = New System.Drawing.Point(40, 40)
        Me.lblBig.Name = "lblBig"
        Me.lblBig.Size = New System.Drawing.Size(862, 70)
        Me.lblBig.TabIndex = 0
        Me.lblBig.Text = "CIBER"
        '
        'pageHist
        '
        Me.pageHist.Controls.Add(Me.histCtl)
        Me.pageHist.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pageHist.Location = New System.Drawing.Point(6, 6)
        Me.pageHist.Name = "pageHist"
        Me.pageHist.Size = New System.Drawing.Size(942, 605)
        Me.pageHist.TabIndex = 3
        Me.pageHist.Visible = False
        '
        'histCtl
        '
        Me.histCtl.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.histCtl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.histCtl.Location = New System.Drawing.Point(0, 0)
        Me.histCtl.Name = "histCtl"
        Me.histCtl.Size = New System.Drawing.Size(942, 605)
        Me.histCtl.TabIndex = 0
        '
        'pageProductos
        '
        Me.pageProductos.Controls.Add(Me.prodCtl)
        Me.pageProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pageProductos.Location = New System.Drawing.Point(6, 6)
        Me.pageProductos.Name = "pageProductos"
        Me.pageProductos.Size = New System.Drawing.Size(942, 605)
        Me.pageProductos.TabIndex = 2
        Me.pageProductos.Visible = False
        '
        'prodCtl
        '
        Me.prodCtl.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.prodCtl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.prodCtl.Location = New System.Drawing.Point(0, 0)
        Me.prodCtl.Name = "prodCtl"
        Me.prodCtl.Size = New System.Drawing.Size(942, 605)
        Me.prodCtl.TabIndex = 0
        '
        'pageVentas
        '
        Me.pageVentas.Controls.Add(Me.posCtl)
        Me.pageVentas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pageVentas.Location = New System.Drawing.Point(6, 6)
        Me.pageVentas.Name = "pageVentas"
        Me.pageVentas.Size = New System.Drawing.Size(942, 605)
        Me.pageVentas.TabIndex = 1
        Me.pageVentas.Visible = False
        '
        'posCtl
        '
        Me.posCtl.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.posCtl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.posCtl.Location = New System.Drawing.Point(0, 0)
        Me.posCtl.Name = "posCtl"
        Me.posCtl.Size = New System.Drawing.Size(942, 605)
        Me.posCtl.TabIndex = 0
        '
        'pageCaja
        '
        Me.pageCaja.Controls.Add(Me.splitCaja)
        Me.pageCaja.Controls.Add(Me.sumCaja)
        Me.pageCaja.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pageCaja.Location = New System.Drawing.Point(6, 6)
        Me.pageCaja.Name = "pageCaja"
        Me.pageCaja.Size = New System.Drawing.Size(942, 605)
        Me.pageCaja.TabIndex = 4
        Me.pageCaja.Visible = False
        '
        'splitCaja
        '
        Me.splitCaja.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitCaja.Location = New System.Drawing.Point(0, 90)
        Me.splitCaja.Name = "splitCaja"
        Me.splitCaja.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitCaja.Panel1
        '
        Me.splitCaja.Panel1.Controls.Add(Me.gVentasHoy)
        '
        'splitCaja.Panel2
        '
        Me.splitCaja.Panel2.Controls.Add(Me.gSesHoy)
        Me.splitCaja.Size = New System.Drawing.Size(942, 515)
        Me.splitCaja.SplitterDistance = 300
        Me.splitCaja.TabIndex = 1
        '
        'gVentasHoy
        '
        Me.gVentasHoy.BackColor = System.Drawing.Color.White
        Me.gVentasHoy.Controls.Add(Me.dgvVentasHoy)
        Me.gVentasHoy.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gVentasHoy.Location = New System.Drawing.Point(0, 0)
        Me.gVentasHoy.Name = "gVentasHoy"
        Me.gVentasHoy.Size = New System.Drawing.Size(942, 300)
        Me.gVentasHoy.TabIndex = 0
        Me.gVentasHoy.TabStop = False
        Me.gVentasHoy.Text = "Ventas de hoy"
        '
        'dgvVentasHoy
        '
        Me.dgvVentasHoy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVentasHoy.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvVentasHoy.Location = New System.Drawing.Point(3, 16)
        Me.dgvVentasHoy.Name = "dgvVentasHoy"
        Me.dgvVentasHoy.Size = New System.Drawing.Size(936, 281)
        Me.dgvVentasHoy.TabIndex = 0
        '
        'gSesHoy
        '
        Me.gSesHoy.BackColor = System.Drawing.Color.White
        Me.gSesHoy.Controls.Add(Me.dgvSesHoy)
        Me.gSesHoy.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gSesHoy.Location = New System.Drawing.Point(0, 0)
        Me.gSesHoy.Name = "gSesHoy"
        Me.gSesHoy.Size = New System.Drawing.Size(942, 211)
        Me.gSesHoy.TabIndex = 0
        Me.gSesHoy.TabStop = False
        Me.gSesHoy.Text = "Sesiones de equipos de hoy"
        '
        'dgvSesHoy
        '
        Me.dgvSesHoy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSesHoy.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSesHoy.Location = New System.Drawing.Point(3, 16)
        Me.dgvSesHoy.Name = "dgvSesHoy"
        Me.dgvSesHoy.Size = New System.Drawing.Size(936, 192)
        Me.dgvSesHoy.TabIndex = 0
        '
        'sumCaja
        '
        Me.sumCaja.BackColor = System.Drawing.Color.White
        Me.sumCaja.Controls.Add(Me.btnCajaHoy)
        Me.sumCaja.Controls.Add(Me.lblNTickets)
        Me.sumCaja.Controls.Add(Me.lblTotalHoy)
        Me.sumCaja.Dock = System.Windows.Forms.DockStyle.Top
        Me.sumCaja.Location = New System.Drawing.Point(0, 0)
        Me.sumCaja.Name = "sumCaja"
        Me.sumCaja.Padding = New System.Windows.Forms.Padding(16)
        Me.sumCaja.Size = New System.Drawing.Size(942, 90)
        Me.sumCaja.TabIndex = 0
        '
        'btnCajaHoy
        '
        Me.btnCajaHoy.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCajaHoy.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnCajaHoy.Location = New System.Drawing.Point(806, 16)
        Me.btnCajaHoy.Name = "btnCajaHoy"
        Me.btnCajaHoy.Size = New System.Drawing.Size(120, 58)
        Me.btnCajaHoy.TabIndex = 2
        Me.btnCajaHoy.Text = "Actualizar"
        Me.btnCajaHoy.UseVisualStyleBackColor = True
        '
        'lblNTickets
        '
        Me.lblNTickets.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblNTickets.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblNTickets.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.lblNTickets.Location = New System.Drawing.Point(336, 16)
        Me.lblNTickets.Name = "lblNTickets"
        Me.lblNTickets.Size = New System.Drawing.Size(260, 58)
        Me.lblNTickets.TabIndex = 1
        Me.lblNTickets.Text = "Tickets: 0"
        Me.lblNTickets.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotalHoy
        '
        Me.lblTotalHoy.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblTotalHoy.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalHoy.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.lblTotalHoy.Location = New System.Drawing.Point(16, 16)
        Me.lblTotalHoy.Name = "lblTotalHoy"
        Me.lblTotalHoy.Size = New System.Drawing.Size(320, 58)
        Me.lblTotalHoy.TabIndex = 0
        Me.lblTotalHoy.Text = "Hoy: $0"
        Me.lblTotalHoy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pageEquipos
        '
        Me.pageEquipos.Controls.Add(Me.flowEq)
        Me.pageEquipos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pageEquipos.Location = New System.Drawing.Point(6, 6)
        Me.pageEquipos.Name = "pageEquipos"
        Me.pageEquipos.Size = New System.Drawing.Size(942, 605)
        Me.pageEquipos.TabIndex = 0
        '
        'flowEq
        '
        Me.flowEq.AutoScroll = True
        Me.flowEq.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.flowEq.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flowEq.Location = New System.Drawing.Point(0, 0)
        Me.flowEq.Name = "flowEq"
        Me.flowEq.Size = New System.Drawing.Size(942, 605)
        Me.flowEq.TabIndex = 0
        '
        'Dashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1184, 681)
        Me.Controls.Add(Me.content)
        Me.Controls.Add(Me.topBar)
        Me.Controls.Add(Me.side)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(1000, 600)
        Me.Name = "Dashboard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Control de Ciber v3.0"
        Me.side.ResumeLayout(False)
        Me.topBar.ResumeLayout(False)
        Me.topBar.PerformLayout()
        Me.content.ResumeLayout(False)
        Me.pageRed.ResumeLayout(False)
        CType(Me.dgvRed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.barRed.ResumeLayout(False)
        Me.barRed.PerformLayout()
        Me.cfgRed.ResumeLayout(False)
        Me.fCfg2.ResumeLayout(False)
        Me.fCfg2.PerformLayout()
        CType(Me.numCfgMsg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numCfgPre, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fCfg1.ResumeLayout(False)
        Me.fCfg1.PerformLayout()
        Me.pageAcerca.ResumeLayout(False)
        Me.wrapAcerca.ResumeLayout(False)
        Me.gridAcerca.ResumeLayout(False)
        Me.pageHist.ResumeLayout(False)
        Me.pageProductos.ResumeLayout(False)
        Me.pageVentas.ResumeLayout(False)
        Me.pageCaja.ResumeLayout(False)
        Me.splitCaja.Panel1.ResumeLayout(False)
        Me.splitCaja.Panel2.ResumeLayout(False)
        CType(Me.splitCaja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitCaja.ResumeLayout(False)
        Me.gVentasHoy.ResumeLayout(False)
        CType(Me.dgvVentasHoy, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gSesHoy.ResumeLayout(False)
        CType(Me.dgvSesHoy, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sumCaja.ResumeLayout(False)
        Me.pageEquipos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents side As Panel
    Friend WithEvents lblLogo As Label
    Friend WithEvents lblSub As Label
    Friend WithEvents btnEquipos As Button
    Friend WithEvents btnVentas As Button
    Friend WithEvents btnProductos As Button
    Friend WithEvents btnHist As Button
    Friend WithEvents btnCaja As Button
    Friend WithEvents btnRed As Button
    Friend WithEvents btnAcerca As Button
    Friend WithEvents lblVer As Label
    Friend WithEvents topBar As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents btnActualizar As Button
    Friend WithEvents lblHoy As Label
    Friend WithEvents lblReloj As Label
    Friend WithEvents content As Panel
    Friend WithEvents pageEquipos As Panel
    Friend WithEvents flowEq As FlowLayoutPanel
    Friend WithEvents pageVentas As Panel
    Friend WithEvents posCtl As PosControl
    Friend WithEvents pageProductos As Panel
    Friend WithEvents prodCtl As ProductosControl
    Friend WithEvents pageHist As Panel
    Friend WithEvents histCtl As HistorialControl
    Friend WithEvents pageCaja As Panel
    Friend WithEvents sumCaja As Panel
    Friend WithEvents lblTotalHoy As Label
    Friend WithEvents lblNTickets As Label
    Friend WithEvents btnCajaHoy As Button
    Friend WithEvents splitCaja As SplitContainer
    Friend WithEvents gVentasHoy As GroupBox
    Friend WithEvents dgvVentasHoy As DataGridView
    Friend WithEvents gSesHoy As GroupBox
    Friend WithEvents dgvSesHoy As DataGridView
    Friend WithEvents pageRed As Panel
    Friend WithEvents barRed As Panel
    Friend WithEvents bAddRed As Button
    Friend WithEvents bSaveRed As Button
    Friend WithEvents bDelRed As Button
    Friend WithEvents lblPuerto As Label
    Friend WithEvents txtPuerto As TextBox
    Friend WithEvents bPortRed As Button
    Friend WithEvents cfgRed As GroupBox
    Friend WithEvents fCfg1 As FlowLayoutPanel
    Friend WithEvents lCfgEq As Label
    Friend WithEvents cboCfgEq As ComboBox
    Friend WithEvents lCfgSrv As Label
    Friend WithEvents txtCfgSrv As TextBox
    Friend WithEvents lCfgCiber As Label
    Friend WithEvents txtCfgCiber As TextBox
    Friend WithEvents fCfg2 As FlowLayoutPanel
    Friend WithEvents lCfgMsg As Label
    Friend WithEvents numCfgMsg As NumericUpDown
    Friend WithEvents lCfgPre As Label
    Friend WithEvents numCfgPre As NumericUpDown
    Friend WithEvents lCfgPass As Label
    Friend WithEvents txtCfgPass As TextBox
    Friend WithEvents bCfgEnviar As Button
    Friend WithEvents dgvRed As DataGridView
    Friend WithEvents hintRed As Label
    Friend WithEvents pageAcerca As Panel
    Friend WithEvents wrapAcerca As Panel
    Friend WithEvents lblBig As Label
    Friend WithEvents lblVer2 As Label
    Friend WithEvents lblDesc As Label
    Friend WithEvents gridAcerca As TableLayoutPanel
    Friend WithEvents ak0 As Label
    Friend WithEvents av0 As Label
    Friend WithEvents ak1 As Label
    Friend WithEvents av1 As Label
    Friend WithEvents ak2 As Label
    Friend WithEvents av2 As Label
    Friend WithEvents ak3 As Label
    Friend WithEvents av3 As Label
    Friend WithEvents ak4 As Label
    Friend WithEvents av4 As Label
    Friend WithEvents linkSitio As LinkLabel
End Class
