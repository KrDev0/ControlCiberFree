<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Config
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Config))
        Me.TextBoxPUERTO = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBoxCONTRASEÑA = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TimerMENSAJES = New System.Windows.Forms.Timer(Me.components)
        Me.ButtonINICIAR = New System.Windows.Forms.Button()
        Me.NumMENSAJES = New System.Windows.Forms.NumericUpDown()
        Me.NumPREAVISO = New System.Windows.Forms.NumericUpDown()
        Me.TimerMINUTOS = New System.Windows.Forms.Timer(Me.components)
        Me.ButtonNOTSKMNGR = New System.Windows.Forms.Button()
        Me.ButtonSITSKMNGR = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ButtonDESREGISTRAR = New System.Windows.Forms.Button()
        Me.ButtonREGISTRAR = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.btnMensaje = New System.Windows.Forms.Button()
        Me.btnPreaviso = New System.Windows.Forms.Button()
        Me.btnNombreCiber = New System.Windows.Forms.Button()
        Me.btnGuardarPuerto = New System.Windows.Forms.Button()
        Me.btnSavePass = New System.Windows.Forms.Button()
        Me.txtNombreCiber = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuAbrir = New System.Windows.Forms.ToolStripMenuItem()
        Me.TimerCaptura = New System.Windows.Forms.Timer(Me.components)
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtServidor = New System.Windows.Forms.TextBox()
        Me.btnServidor = New System.Windows.Forms.Button()
        CType(Me.NumMENSAJES, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumPREAVISO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBoxPUERTO
        '
        Me.TextBoxPUERTO.BackColor = System.Drawing.SystemColors.Control
        Me.TextBoxPUERTO.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxPUERTO.ForeColor = System.Drawing.Color.Black
        Me.TextBoxPUERTO.Location = New System.Drawing.Point(234, 51)
        Me.TextBoxPUERTO.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxPUERTO.Name = "TextBoxPUERTO"
        Me.TextBoxPUERTO.Size = New System.Drawing.Size(208, 29)
        Me.TextBoxPUERTO.TabIndex = 11
        Me.TextBoxPUERTO.Text = "55555"
        Me.TextBoxPUERTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(85, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(146, 21)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Puerto de conexión:"
        '
        'TextBoxCONTRASEÑA
        '
        Me.TextBoxCONTRASEÑA.BackColor = System.Drawing.SystemColors.Control
        Me.TextBoxCONTRASEÑA.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCONTRASEÑA.ForeColor = System.Drawing.Color.Black
        Me.TextBoxCONTRASEÑA.Location = New System.Drawing.Point(234, 14)
        Me.TextBoxCONTRASEÑA.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxCONTRASEÑA.Name = "TextBoxCONTRASEÑA"
        Me.TextBoxCONTRASEÑA.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBoxCONTRASEÑA.Size = New System.Drawing.Size(208, 29)
        Me.TextBoxCONTRASEÑA.TabIndex = 14
        Me.TextBoxCONTRASEÑA.Text = "102250"
        Me.TextBoxCONTRASEÑA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(219, 21)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Contraseña del administrador:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(83, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(148, 21)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Tiempo de mensaje:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(82, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(149, 21)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Tiempo de preaviso:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(401, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 21)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Seg."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.White
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(400, 127)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 21)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Min."
        '
        'TimerMENSAJES
        '
        '
        'ButtonINICIAR
        '
        Me.ButtonINICIAR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonINICIAR.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonINICIAR.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ButtonINICIAR.ForeColor = System.Drawing.Color.Black
        Me.ButtonINICIAR.Location = New System.Drawing.Point(384, 300)
        Me.ButtonINICIAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButtonINICIAR.Name = "ButtonINICIAR"
        Me.ButtonINICIAR.Size = New System.Drawing.Size(196, 29)
        Me.ButtonINICIAR.TabIndex = 23
        Me.ButtonINICIAR.Text = "Iniciar tiempo [Libre]"
        Me.ButtonINICIAR.UseVisualStyleBackColor = True
        '
        'NumMENSAJES
        '
        Me.NumMENSAJES.BackColor = System.Drawing.SystemColors.Control
        Me.NumMENSAJES.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumMENSAJES.ForeColor = System.Drawing.Color.Black
        Me.NumMENSAJES.Location = New System.Drawing.Point(234, 88)
        Me.NumMENSAJES.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.NumMENSAJES.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumMENSAJES.Name = "NumMENSAJES"
        Me.NumMENSAJES.Size = New System.Drawing.Size(161, 29)
        Me.NumMENSAJES.TabIndex = 24
        Me.NumMENSAJES.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumMENSAJES.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'NumPREAVISO
        '
        Me.NumPREAVISO.BackColor = System.Drawing.SystemColors.Control
        Me.NumPREAVISO.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumPREAVISO.ForeColor = System.Drawing.Color.Black
        Me.NumPREAVISO.Location = New System.Drawing.Point(235, 125)
        Me.NumPREAVISO.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.NumPREAVISO.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumPREAVISO.Name = "NumPREAVISO"
        Me.NumPREAVISO.Size = New System.Drawing.Size(159, 29)
        Me.NumPREAVISO.TabIndex = 25
        Me.NumPREAVISO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumPREAVISO.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'TimerMINUTOS
        '
        '
        'ButtonNOTSKMNGR
        '
        Me.ButtonNOTSKMNGR.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonNOTSKMNGR.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ButtonNOTSKMNGR.ForeColor = System.Drawing.Color.Black
        Me.ButtonNOTSKMNGR.Location = New System.Drawing.Point(25, 29)
        Me.ButtonNOTSKMNGR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButtonNOTSKMNGR.Name = "ButtonNOTSKMNGR"
        Me.ButtonNOTSKMNGR.Size = New System.Drawing.Size(156, 29)
        Me.ButtonNOTSKMNGR.TabIndex = 26
        Me.ButtonNOTSKMNGR.Text = "Bloquear acceso"
        Me.ButtonNOTSKMNGR.UseVisualStyleBackColor = True
        '
        'ButtonSITSKMNGR
        '
        Me.ButtonSITSKMNGR.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonSITSKMNGR.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ButtonSITSKMNGR.ForeColor = System.Drawing.Color.Black
        Me.ButtonSITSKMNGR.Location = New System.Drawing.Point(25, 66)
        Me.ButtonSITSKMNGR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButtonSITSKMNGR.Name = "ButtonSITSKMNGR"
        Me.ButtonSITSKMNGR.Size = New System.Drawing.Size(156, 29)
        Me.ButtonSITSKMNGR.TabIndex = 27
        Me.ButtonSITSKMNGR.Text = "Desbloquear acceso"
        Me.ButtonSITSKMNGR.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ButtonNOTSKMNGR)
        Me.GroupBox1.Controls.Add(Me.ButtonSITSKMNGR)
        Me.GroupBox1.Location = New System.Drawing.Point(64, 17)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(206, 108)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Administrador de tareas"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ButtonDESREGISTRAR)
        Me.GroupBox2.Controls.Add(Me.ButtonREGISTRAR)
        Me.GroupBox2.Location = New System.Drawing.Point(276, 17)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(206, 108)
        Me.GroupBox2.TabIndex = 29
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Iniciar con el sistema"
        '
        'ButtonDESREGISTRAR
        '
        Me.ButtonDESREGISTRAR.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonDESREGISTRAR.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ButtonDESREGISTRAR.ForeColor = System.Drawing.Color.Black
        Me.ButtonDESREGISTRAR.Location = New System.Drawing.Point(15, 66)
        Me.ButtonDESREGISTRAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButtonDESREGISTRAR.Name = "ButtonDESREGISTRAR"
        Me.ButtonDESREGISTRAR.Size = New System.Drawing.Size(176, 29)
        Me.ButtonDESREGISTRAR.TabIndex = 26
        Me.ButtonDESREGISTRAR.Text = "Eliminar inicio"
        Me.ButtonDESREGISTRAR.UseVisualStyleBackColor = True
        '
        'ButtonREGISTRAR
        '
        Me.ButtonREGISTRAR.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonREGISTRAR.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ButtonREGISTRAR.ForeColor = System.Drawing.Color.Black
        Me.ButtonREGISTRAR.Location = New System.Drawing.Point(15, 29)
        Me.ButtonREGISTRAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButtonREGISTRAR.Name = "ButtonREGISTRAR"
        Me.ButtonREGISTRAR.Size = New System.Drawing.Size(176, 29)
        Me.ButtonREGISTRAR.TabIndex = 26
        Me.ButtonREGISTRAR.Text = "Registrar Inicio"
        Me.ButtonREGISTRAR.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(19, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(554, 281)
        Me.TabControl1.TabIndex = 30
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.btnServidor)
        Me.TabPage3.Controls.Add(Me.txtServidor)
        Me.TabPage3.Controls.Add(Me.Label8)
        Me.TabPage3.Controls.Add(Me.btnMensaje)
        Me.TabPage3.Controls.Add(Me.btnPreaviso)
        Me.TabPage3.Controls.Add(Me.btnNombreCiber)
        Me.TabPage3.Controls.Add(Me.btnGuardarPuerto)
        Me.TabPage3.Controls.Add(Me.btnSavePass)
        Me.TabPage3.Controls.Add(Me.txtNombreCiber)
        Me.TabPage3.Controls.Add(Me.Label7)
        Me.TabPage3.Controls.Add(Me.TextBoxPUERTO)
        Me.TabPage3.Controls.Add(Me.Label3)
        Me.TabPage3.Controls.Add(Me.Label1)
        Me.TabPage3.Controls.Add(Me.NumPREAVISO)
        Me.TabPage3.Controls.Add(Me.Label4)
        Me.TabPage3.Controls.Add(Me.Label6)
        Me.TabPage3.Controls.Add(Me.TextBoxCONTRASEÑA)
        Me.TabPage3.Controls.Add(Me.NumMENSAJES)
        Me.TabPage3.Controls.Add(Me.Label2)
        Me.TabPage3.Controls.Add(Me.Label5)
        Me.TabPage3.Location = New System.Drawing.Point(4, 30)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(546, 247)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.Text = "General"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'btnMensaje
        '
        Me.btnMensaje.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnMensaje.Location = New System.Drawing.Point(448, 91)
        Me.btnMensaje.Name = "btnMensaje"
        Me.btnMensaje.Size = New System.Drawing.Size(80, 23)
        Me.btnMensaje.TabIndex = 28
        Me.btnMensaje.Text = "Guardar"
        Me.btnMensaje.UseVisualStyleBackColor = True
        '
        'btnPreaviso
        '
        Me.btnPreaviso.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnPreaviso.Location = New System.Drawing.Point(448, 126)
        Me.btnPreaviso.Name = "btnPreaviso"
        Me.btnPreaviso.Size = New System.Drawing.Size(80, 23)
        Me.btnPreaviso.TabIndex = 28
        Me.btnPreaviso.Text = "Guardar"
        Me.btnPreaviso.UseVisualStyleBackColor = True
        '
        'btnNombreCiber
        '
        Me.btnNombreCiber.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnNombreCiber.Location = New System.Drawing.Point(448, 166)
        Me.btnNombreCiber.Name = "btnNombreCiber"
        Me.btnNombreCiber.Size = New System.Drawing.Size(80, 23)
        Me.btnNombreCiber.TabIndex = 27
        Me.btnNombreCiber.Text = "Guardar"
        Me.btnNombreCiber.UseVisualStyleBackColor = True
        '
        'btnGuardarPuerto
        '
        Me.btnGuardarPuerto.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnGuardarPuerto.Location = New System.Drawing.Point(448, 55)
        Me.btnGuardarPuerto.Name = "btnGuardarPuerto"
        Me.btnGuardarPuerto.Size = New System.Drawing.Size(80, 23)
        Me.btnGuardarPuerto.TabIndex = 27
        Me.btnGuardarPuerto.Text = "Guardar"
        Me.btnGuardarPuerto.UseVisualStyleBackColor = True
        '
        'btnSavePass
        '
        Me.btnSavePass.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnSavePass.Location = New System.Drawing.Point(448, 17)
        Me.btnSavePass.Name = "btnSavePass"
        Me.btnSavePass.Size = New System.Drawing.Size(80, 23)
        Me.btnSavePass.TabIndex = 26
        Me.btnSavePass.Text = "Guardar"
        Me.btnSavePass.UseVisualStyleBackColor = True
        '
        'txtNombreCiber
        '
        Me.txtNombreCiber.BackColor = System.Drawing.SystemColors.Control
        Me.txtNombreCiber.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreCiber.ForeColor = System.Drawing.Color.Black
        Me.txtNombreCiber.Location = New System.Drawing.Point(234, 162)
        Me.txtNombreCiber.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNombreCiber.Name = "txtNombreCiber"
        Me.txtNombreCiber.Size = New System.Drawing.Size(208, 29)
        Me.txtNombreCiber.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.White
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(97, 165)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(134, 21)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Nombre del ciber:"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 30)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(546, 201)
        Me.TabPage1.TabIndex = 1
        Me.TabPage1.Text = "Configuración del sistema"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnCerrar.Location = New System.Drawing.Point(12, 301)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(96, 29)
        Me.btnCerrar.TabIndex = 31
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Control de Cyber"
        Me.NotifyIcon1.Visible = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAbrir})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(178, 26)
        '
        'mnuAbrir
        '
        Me.mnuAbrir.Name = "mnuAbrir"
        Me.mnuAbrir.Size = New System.Drawing.Size(177, 22)
        Me.mnuAbrir.Text = "Abrir configuración"
        '
        'TimerCaptura
        '
        Me.TimerCaptura.Enabled = True
        Me.TimerCaptura.Interval = 5000
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(142, 202)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 21)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "IP Servidor:"
        '
        'txtServidor
        '
        Me.txtServidor.BackColor = System.Drawing.SystemColors.Control
        Me.txtServidor.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtServidor.ForeColor = System.Drawing.Color.Black
        Me.txtServidor.Location = New System.Drawing.Point(234, 199)
        Me.txtServidor.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtServidor.Name = "txtServidor"
        Me.txtServidor.Size = New System.Drawing.Size(208, 29)
        Me.txtServidor.TabIndex = 30
        '
        'btnServidor
        '
        Me.btnServidor.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnServidor.Location = New System.Drawing.Point(448, 203)
        Me.btnServidor.Name = "btnServidor"
        Me.btnServidor.Size = New System.Drawing.Size(80, 23)
        Me.btnServidor.TabIndex = 31
        Me.btnServidor.Text = "Guardar"
        Me.btnServidor.UseVisualStyleBackColor = True
        '
        'Config
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(592, 342)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ButtonINICIAR)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(608, 338)
        Me.Name = "Config"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        CType(Me.NumMENSAJES, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumPREAVISO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TextBoxPUERTO As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBoxCONTRASEÑA As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TimerMENSAJES As System.Windows.Forms.Timer
    Friend WithEvents ButtonINICIAR As System.Windows.Forms.Button
    Friend WithEvents NumMENSAJES As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumPREAVISO As System.Windows.Forms.NumericUpDown
    Friend WithEvents TimerMINUTOS As System.Windows.Forms.Timer
    Friend WithEvents ButtonNOTSKMNGR As System.Windows.Forms.Button
    Friend WithEvents ButtonSITSKMNGR As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents ButtonDESREGISTRAR As Button
    Friend WithEvents ButtonREGISTRAR As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents btnSavePass As Button
    Friend WithEvents btnGuardarPuerto As Button
    Friend WithEvents btnMensaje As Button
    Friend WithEvents btnPreaviso As Button
    Friend WithEvents btnCerrar As Button
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents mnuAbrir As ToolStripMenuItem
    Friend WithEvents btnNombreCiber As Button
    Friend WithEvents txtNombreCiber As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TimerCaptura As Timer
    Friend WithEvents btnServidor As Button
    Friend WithEvents txtServidor As TextBox
    Friend WithEvents Label8 As Label
End Class
