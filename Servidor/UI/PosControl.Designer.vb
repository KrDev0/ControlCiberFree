<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PosControl
    Inherits System.Windows.Forms.UserControl

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
        Me.topBar = New System.Windows.Forms.Panel()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.lblTituloPos = New System.Windows.Forms.Label()
        Me.split = New System.Windows.Forms.SplitContainer()
        Me.g1 = New System.Windows.Forms.GroupBox()
        Me.dgvCat = New System.Windows.Forms.DataGridView()
        Me.g2 = New System.Windows.Forms.GroupBox()
        Me.dgvCar = New System.Windows.Forms.DataGridView()
        Me.bot = New System.Windows.Forms.Panel()
        Me.f3 = New System.Windows.Forms.Panel()
        Me.btnCobrar = New System.Windows.Forms.Button()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.f2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnQuitar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.f1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.lE = New System.Windows.Forms.Label()
        Me.cboEquipo = New System.Windows.Forms.ComboBox()
        Me.lP = New System.Windows.Forms.Label()
        Me.cboPago = New System.Windows.Forms.ComboBox()
        Me.lC = New System.Windows.Forms.Label()
        Me.numCant = New System.Windows.Forms.NumericUpDown()
        Me.topBar.SuspendLayout()
        CType(Me.split, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.split.Panel1.SuspendLayout()
        Me.split.Panel2.SuspendLayout()
        Me.split.SuspendLayout()
        Me.g1.SuspendLayout()
        CType(Me.dgvCat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.g2.SuspendLayout()
        CType(Me.dgvCar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bot.SuspendLayout()
        Me.f3.SuspendLayout()
        Me.f2.SuspendLayout()
        Me.f1.SuspendLayout()
        CType(Me.numCant, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'topBar
        '
        Me.topBar.BackColor = System.Drawing.Color.White
        Me.topBar.Controls.Add(Me.txtBuscar)
        Me.topBar.Controls.Add(Me.lblBuscar)
        Me.topBar.Controls.Add(Me.lblTituloPos)
        Me.topBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.topBar.Location = New System.Drawing.Point(0, 0)
        Me.topBar.Name = "topBar"
        Me.topBar.Padding = New System.Windows.Forms.Padding(12)
        Me.topBar.Size = New System.Drawing.Size(900, 56)
        Me.topBar.TabIndex = 0
        '
        'txtBuscar
        '
        Me.txtBuscar.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtBuscar.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtBuscar.Location = New System.Drawing.Point(75, 12)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(300, 27)
        Me.txtBuscar.TabIndex = 1
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblBuscar.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lblBuscar.Location = New System.Drawing.Point(12, 12)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Padding = New System.Windows.Forms.Padding(0, 5, 8, 0)
        Me.lblBuscar.Size = New System.Drawing.Size(63, 25)
        Me.lblBuscar.TabIndex = 0
        Me.lblBuscar.Text = "Buscar:"
        '
        'lblTituloPos
        '
        Me.lblTituloPos.AutoSize = True
        Me.lblTituloPos.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTituloPos.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblTituloPos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.lblTituloPos.Location = New System.Drawing.Point(594, 12)
        Me.lblTituloPos.Name = "lblTituloPos"
        Me.lblTituloPos.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.lblTituloPos.Size = New System.Drawing.Size(294, 25)
        Me.lblTituloPos.TabIndex = 2
        Me.lblTituloPos.Text = "Punto de venta · consumibles y papelería"
        '
        'split
        '
        Me.split.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.split.Dock = System.Windows.Forms.DockStyle.Fill
        Me.split.Location = New System.Drawing.Point(0, 56)
        Me.split.Name = "split"
        '
        'split.Panel1
        '
        Me.split.Panel1.Controls.Add(Me.g1)
        '
        'split.Panel2
        '
        Me.split.Panel2.Controls.Add(Me.g2)
        Me.split.Panel2.Controls.Add(Me.bot)
        Me.split.Size = New System.Drawing.Size(900, 544)
        Me.split.SplitterDistance = 560
        Me.split.TabIndex = 1
        '
        'g1
        '
        Me.g1.BackColor = System.Drawing.Color.White
        Me.g1.Controls.Add(Me.dgvCat)
        Me.g1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.g1.Location = New System.Drawing.Point(0, 0)
        Me.g1.Name = "g1"
        Me.g1.Size = New System.Drawing.Size(560, 544)
        Me.g1.TabIndex = 0
        Me.g1.TabStop = False
        Me.g1.Text = "Catálogo"
        '
        'dgvCat
        '
        Me.dgvCat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCat.Location = New System.Drawing.Point(3, 16)
        Me.dgvCat.Name = "dgvCat"
        Me.dgvCat.Size = New System.Drawing.Size(554, 525)
        Me.dgvCat.TabIndex = 0
        '
        'g2
        '
        Me.g2.BackColor = System.Drawing.Color.White
        Me.g2.Controls.Add(Me.dgvCar)
        Me.g2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.g2.Location = New System.Drawing.Point(0, 0)
        Me.g2.Name = "g2"
        Me.g2.Size = New System.Drawing.Size(336, 374)
        Me.g2.TabIndex = 0
        Me.g2.TabStop = False
        Me.g2.Text = "Ticket actual"
        '
        'dgvCar
        '
        Me.dgvCar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCar.Location = New System.Drawing.Point(3, 16)
        Me.dgvCar.Name = "dgvCar"
        Me.dgvCar.Size = New System.Drawing.Size(330, 355)
        Me.dgvCar.TabIndex = 0
        '
        'bot
        '
        Me.bot.BackColor = System.Drawing.Color.White
        Me.bot.Controls.Add(Me.f3)
        Me.bot.Controls.Add(Me.f2)
        Me.bot.Controls.Add(Me.f1)
        Me.bot.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bot.Location = New System.Drawing.Point(0, 374)
        Me.bot.Name = "bot"
        Me.bot.Padding = New System.Windows.Forms.Padding(10)
        Me.bot.Size = New System.Drawing.Size(336, 170)
        Me.bot.TabIndex = 1
        '
        'f3
        '
        Me.f3.BackColor = System.Drawing.Color.White
        Me.f3.Controls.Add(Me.btnCobrar)
        Me.f3.Controls.Add(Me.lblTotal)
        Me.f3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.f3.Location = New System.Drawing.Point(10, 112)
        Me.f3.Name = "f3"
        Me.f3.Size = New System.Drawing.Size(316, 48)
        Me.f3.TabIndex = 2
        '
        'btnCobrar
        '
        Me.btnCobrar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCobrar.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.btnCobrar.Location = New System.Drawing.Point(146, 0)
        Me.btnCobrar.Name = "btnCobrar"
        Me.btnCobrar.Size = New System.Drawing.Size(170, 48)
        Me.btnCobrar.TabIndex = 1
        Me.btnCobrar.Text = "Cobrar"
        Me.btnCobrar.UseVisualStyleBackColor = True
        '
        'lblTotal
        '
        Me.lblTotal.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblTotal.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.lblTotal.Location = New System.Drawing.Point(0, 0)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(220, 48)
        Me.lblTotal.TabIndex = 0
        Me.lblTotal.Text = "Total: $0.00"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'f2
        '
        Me.f2.BackColor = System.Drawing.Color.White
        Me.f2.Controls.Add(Me.btnAgregar)
        Me.f2.Controls.Add(Me.btnQuitar)
        Me.f2.Controls.Add(Me.btnLimpiar)
        Me.f2.Dock = System.Windows.Forms.DockStyle.Top
        Me.f2.Location = New System.Drawing.Point(10, 72)
        Me.f2.Name = "f2"
        Me.f2.Size = New System.Drawing.Size(316, 40)
        Me.f2.TabIndex = 1
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(3, 3)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(100, 32)
        Me.btnAgregar.TabIndex = 0
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnQuitar
        '
        Me.btnQuitar.Location = New System.Drawing.Point(109, 3)
        Me.btnQuitar.Name = "btnQuitar"
        Me.btnQuitar.Size = New System.Drawing.Size(100, 32)
        Me.btnQuitar.TabIndex = 1
        Me.btnQuitar.Text = "Quitar"
        Me.btnQuitar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(3, 41)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(100, 32)
        Me.btnLimpiar.TabIndex = 2
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'f1
        '
        Me.f1.BackColor = System.Drawing.Color.White
        Me.f1.Controls.Add(Me.lE)
        Me.f1.Controls.Add(Me.cboEquipo)
        Me.f1.Controls.Add(Me.lP)
        Me.f1.Controls.Add(Me.cboPago)
        Me.f1.Controls.Add(Me.lC)
        Me.f1.Controls.Add(Me.numCant)
        Me.f1.Dock = System.Windows.Forms.DockStyle.Top
        Me.f1.Location = New System.Drawing.Point(10, 10)
        Me.f1.Name = "f1"
        Me.f1.Size = New System.Drawing.Size(316, 62)
        Me.f1.TabIndex = 0
        '
        'lE
        '
        Me.lE.AutoSize = True
        Me.lE.Location = New System.Drawing.Point(3, 0)
        Me.lE.Name = "lE"
        Me.lE.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.lE.Size = New System.Drawing.Size(43, 18)
        Me.lE.TabIndex = 0
        Me.lE.Text = "Equipo:"
        '
        'cboEquipo
        '
        Me.cboEquipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEquipo.FormattingEnabled = True
        Me.cboEquipo.Location = New System.Drawing.Point(52, 3)
        Me.cboEquipo.Name = "cboEquipo"
        Me.cboEquipo.Size = New System.Drawing.Size(130, 21)
        Me.cboEquipo.TabIndex = 1
        '
        'lP
        '
        Me.lP.AutoSize = True
        Me.lP.Location = New System.Drawing.Point(188, 0)
        Me.lP.Name = "lP"
        Me.lP.Padding = New System.Windows.Forms.Padding(8, 5, 0, 0)
        Me.lP.Size = New System.Drawing.Size(43, 18)
        Me.lP.TabIndex = 2
        Me.lP.Text = "Pago:"
        '
        'cboPago
        '
        Me.cboPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPago.FormattingEnabled = True
        Me.cboPago.Location = New System.Drawing.Point(3, 30)
        Me.cboPago.Name = "cboPago"
        Me.cboPago.Size = New System.Drawing.Size(120, 21)
        Me.cboPago.TabIndex = 3
        '
        'lC
        '
        Me.lC.AutoSize = True
        Me.lC.Location = New System.Drawing.Point(129, 27)
        Me.lC.Name = "lC"
        Me.lC.Padding = New System.Windows.Forms.Padding(8, 5, 0, 0)
        Me.lC.Size = New System.Drawing.Size(40, 18)
        Me.lC.TabIndex = 4
        Me.lC.Text = "Cant:"
        '
        'numCant
        '
        Me.numCant.Location = New System.Drawing.Point(175, 30)
        Me.numCant.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.numCant.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numCant.Name = "numCant"
        Me.numCant.Size = New System.Drawing.Size(60, 20)
        Me.numCant.TabIndex = 5
        Me.numCant.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'PosControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Controls.Add(Me.split)
        Me.Controls.Add(Me.topBar)
        Me.Name = "PosControl"
        Me.Size = New System.Drawing.Size(900, 600)
        Me.topBar.ResumeLayout(False)
        Me.topBar.PerformLayout()
        Me.split.Panel1.ResumeLayout(False)
        Me.split.Panel2.ResumeLayout(False)
        CType(Me.split, System.ComponentModel.ISupportInitialize).EndInit()
        Me.split.ResumeLayout(False)
        Me.g1.ResumeLayout(False)
        CType(Me.dgvCat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.g2.ResumeLayout(False)
        CType(Me.dgvCar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bot.ResumeLayout(False)
        Me.f3.ResumeLayout(False)
        Me.f2.ResumeLayout(False)
        Me.f1.ResumeLayout(False)
        Me.f1.PerformLayout()
        CType(Me.numCant, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents topBar As Panel
    Friend WithEvents lblBuscar As Label
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents lblTituloPos As Label
    Friend WithEvents split As SplitContainer
    Friend WithEvents g1 As GroupBox
    Friend WithEvents dgvCat As DataGridView
    Friend WithEvents g2 As GroupBox
    Friend WithEvents dgvCar As DataGridView
    Friend WithEvents bot As Panel
    Friend WithEvents f1 As FlowLayoutPanel
    Friend WithEvents lE As Label
    Friend WithEvents cboEquipo As ComboBox
    Friend WithEvents lP As Label
    Friend WithEvents cboPago As ComboBox
    Friend WithEvents lC As Label
    Friend WithEvents numCant As NumericUpDown
    Friend WithEvents f2 As FlowLayoutPanel
    Friend WithEvents btnAgregar As Button
    Friend WithEvents btnQuitar As Button
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents f3 As Panel
    Friend WithEvents lblTotal As Label
    Friend WithEvents btnCobrar As Button
End Class
