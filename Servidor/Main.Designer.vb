<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.NumH1 = New System.Windows.Forms.NumericUpDown()
        Me.NumM1 = New System.Windows.Forms.NumericUpDown()
        Me.ButtonBLOQUEO = New System.Windows.Forms.Button()
        Me.ButtonAPAGAR = New System.Windows.Forms.Button()
        Me.ButtonINICIAR = New System.Windows.Forms.Button()
        Me.TextBoxMENSAJES1 = New System.Windows.Forms.TextBox()
        Me.ButtonAÑADIR = New System.Windows.Forms.Button()
        Me.ButtonREINICIAR = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.picPantalla = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnDesbloquear = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnBloquear = New System.Windows.Forms.Button()
        Me.lblEquipo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnEnviarMensaje = New System.Windows.Forms.Button()
        Me.lblIp = New System.Windows.Forms.Label()
        Me.lblPuerto = New System.Windows.Forms.Label()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnConectar = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.NumH1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumM1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPantalla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'NumH1
        '
        Me.NumH1.BackColor = System.Drawing.Color.White
        Me.NumH1.ForeColor = System.Drawing.Color.Black
        Me.NumH1.Location = New System.Drawing.Point(75, 27)
        Me.NumH1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.NumH1.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.NumH1.Name = "NumH1"
        Me.NumH1.Size = New System.Drawing.Size(60, 29)
        Me.NumH1.TabIndex = 7
        Me.NumH1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'NumM1
        '
        Me.NumM1.BackColor = System.Drawing.Color.White
        Me.NumM1.ForeColor = System.Drawing.Color.Black
        Me.NumM1.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NumM1.Location = New System.Drawing.Point(75, 64)
        Me.NumM1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.NumM1.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.NumM1.Name = "NumM1"
        Me.NumM1.Size = New System.Drawing.Size(60, 29)
        Me.NumM1.TabIndex = 8
        Me.NumM1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ButtonBLOQUEO
        '
        Me.ButtonBLOQUEO.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonBLOQUEO.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ButtonBLOQUEO.ForeColor = System.Drawing.Color.Black
        Me.ButtonBLOQUEO.Location = New System.Drawing.Point(155, 94)
        Me.ButtonBLOQUEO.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButtonBLOQUEO.Name = "ButtonBLOQUEO"
        Me.ButtonBLOQUEO.Size = New System.Drawing.Size(115, 29)
        Me.ButtonBLOQUEO.TabIndex = 10
        Me.ButtonBLOQUEO.Text = "Bloquear PC"
        Me.ButtonBLOQUEO.UseVisualStyleBackColor = True
        '
        'ButtonAPAGAR
        '
        Me.ButtonAPAGAR.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonAPAGAR.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ButtonAPAGAR.ForeColor = System.Drawing.Color.Black
        Me.ButtonAPAGAR.Location = New System.Drawing.Point(15, 63)
        Me.ButtonAPAGAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButtonAPAGAR.Name = "ButtonAPAGAR"
        Me.ButtonAPAGAR.Size = New System.Drawing.Size(140, 29)
        Me.ButtonAPAGAR.TabIndex = 11
        Me.ButtonAPAGAR.Text = "Apagar equipo"
        Me.ButtonAPAGAR.UseVisualStyleBackColor = True
        '
        'ButtonINICIAR
        '
        Me.ButtonINICIAR.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonINICIAR.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ButtonINICIAR.ForeColor = System.Drawing.Color.Black
        Me.ButtonINICIAR.Location = New System.Drawing.Point(155, 21)
        Me.ButtonINICIAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButtonINICIAR.Name = "ButtonINICIAR"
        Me.ButtonINICIAR.Size = New System.Drawing.Size(115, 29)
        Me.ButtonINICIAR.TabIndex = 12
        Me.ButtonINICIAR.Text = "Iniciar tiempo"
        Me.ButtonINICIAR.UseVisualStyleBackColor = True
        '
        'TextBoxMENSAJES1
        '
        Me.TextBoxMENSAJES1.BackColor = System.Drawing.Color.White
        Me.TextBoxMENSAJES1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TextBoxMENSAJES1.ForeColor = System.Drawing.Color.Black
        Me.TextBoxMENSAJES1.Location = New System.Drawing.Point(473, 49)
        Me.TextBoxMENSAJES1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxMENSAJES1.Multiline = True
        Me.TextBoxMENSAJES1.Name = "TextBoxMENSAJES1"
        Me.TextBoxMENSAJES1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxMENSAJES1.Size = New System.Drawing.Size(257, 200)
        Me.TextBoxMENSAJES1.TabIndex = 13
        '
        'ButtonAÑADIR
        '
        Me.ButtonAÑADIR.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonAÑADIR.Enabled = False
        Me.ButtonAÑADIR.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ButtonAÑADIR.ForeColor = System.Drawing.Color.Black
        Me.ButtonAÑADIR.Location = New System.Drawing.Point(155, 57)
        Me.ButtonAÑADIR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButtonAÑADIR.Name = "ButtonAÑADIR"
        Me.ButtonAÑADIR.Size = New System.Drawing.Size(115, 29)
        Me.ButtonAÑADIR.TabIndex = 24
        Me.ButtonAÑADIR.Text = "Añadir tiempo"
        Me.ButtonAÑADIR.UseVisualStyleBackColor = True
        '
        'ButtonREINICIAR
        '
        Me.ButtonREINICIAR.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonREINICIAR.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ButtonREINICIAR.ForeColor = System.Drawing.Color.Black
        Me.ButtonREINICIAR.Location = New System.Drawing.Point(15, 100)
        Me.ButtonREINICIAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButtonREINICIAR.Name = "ButtonREINICIAR"
        Me.ButtonREINICIAR.Size = New System.Drawing.Size(140, 29)
        Me.ButtonREINICIAR.TabIndex = 26
        Me.ButtonREINICIAR.Text = "Reiniciar equipo"
        Me.ButtonREINICIAR.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(6, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 21)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Minuto:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(22, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 21)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Hora:"
        '
        'picPantalla
        '
        Me.picPantalla.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picPantalla.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picPantalla.Image = CType(resources.GetObject("picPantalla.Image"), System.Drawing.Image)
        Me.picPantalla.Location = New System.Drawing.Point(12, 13)
        Me.picPantalla.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.picPantalla.Name = "picPantalla"
        Me.picPantalla.Size = New System.Drawing.Size(100, 100)
        Me.picPantalla.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picPantalla.TabIndex = 39
        Me.picPantalla.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnDesbloquear)
        Me.GroupBox1.Controls.Add(Me.NumH1)
        Me.GroupBox1.Controls.Add(Me.ButtonBLOQUEO)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.NumM1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.ButtonINICIAR)
        Me.GroupBox1.Controls.Add(Me.ButtonAÑADIR)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 116)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(279, 171)
        Me.GroupBox1.TabIndex = 40
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Control de tiempo:"
        '
        'btnDesbloquear
        '
        Me.btnDesbloquear.BackColor = System.Drawing.SystemColors.Control
        Me.btnDesbloquear.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnDesbloquear.ForeColor = System.Drawing.Color.Black
        Me.btnDesbloquear.Location = New System.Drawing.Point(155, 131)
        Me.btnDesbloquear.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnDesbloquear.Name = "btnDesbloquear"
        Me.btnDesbloquear.Size = New System.Drawing.Size(115, 29)
        Me.btnDesbloquear.TabIndex = 32
        Me.btnDesbloquear.Text = "Desbloquear PC"
        Me.btnDesbloquear.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnBloquear)
        Me.GroupBox2.Controls.Add(Me.ButtonAPAGAR)
        Me.GroupBox2.Controls.Add(Me.ButtonREINICIAR)
        Me.GroupBox2.Location = New System.Drawing.Point(297, 116)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(170, 171)
        Me.GroupBox2.TabIndex = 41
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Opciones de equipo"
        '
        'btnBloquear
        '
        Me.btnBloquear.BackColor = System.Drawing.SystemColors.Control
        Me.btnBloquear.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnBloquear.ForeColor = System.Drawing.Color.Black
        Me.btnBloquear.Location = New System.Drawing.Point(15, 26)
        Me.btnBloquear.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnBloquear.Name = "btnBloquear"
        Me.btnBloquear.Size = New System.Drawing.Size(140, 29)
        Me.btnBloquear.TabIndex = 27
        Me.btnBloquear.Text = "Bloquear equipo"
        Me.btnBloquear.UseVisualStyleBackColor = True
        '
        'lblEquipo
        '
        Me.lblEquipo.AutoSize = True
        Me.lblEquipo.Font = New System.Drawing.Font("Segoe UI", 18.0!)
        Me.lblEquipo.Location = New System.Drawing.Point(114, 13)
        Me.lblEquipo.Name = "lblEquipo"
        Me.lblEquipo.Size = New System.Drawing.Size(115, 32)
        Me.lblEquipo.TabIndex = 42
        Me.lblEquipo.Text = "Equipo {i}"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 18.0!)
        Me.Label1.Location = New System.Drawing.Point(467, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 32)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "Mensaje"
        '
        'btnEnviarMensaje
        '
        Me.btnEnviarMensaje.BackColor = System.Drawing.SystemColors.Control
        Me.btnEnviarMensaje.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnEnviarMensaje.ForeColor = System.Drawing.Color.Black
        Me.btnEnviarMensaje.Location = New System.Drawing.Point(590, 257)
        Me.btnEnviarMensaje.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnEnviarMensaje.Name = "btnEnviarMensaje"
        Me.btnEnviarMensaje.Size = New System.Drawing.Size(140, 29)
        Me.btnEnviarMensaje.TabIndex = 44
        Me.btnEnviarMensaje.Text = "Enviar (F5)"
        Me.btnEnviarMensaje.UseVisualStyleBackColor = True
        '
        'lblIp
        '
        Me.lblIp.AutoSize = True
        Me.lblIp.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblIp.Location = New System.Drawing.Point(114, 45)
        Me.lblIp.Name = "lblIp"
        Me.lblIp.Size = New System.Drawing.Size(23, 21)
        Me.lblIp.TabIndex = 45
        Me.lblIp.Text = "ip"
        '
        'lblPuerto
        '
        Me.lblPuerto.AutoSize = True
        Me.lblPuerto.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblPuerto.Location = New System.Drawing.Point(114, 66)
        Me.lblPuerto.Name = "lblPuerto"
        Me.lblPuerto.Size = New System.Drawing.Size(56, 21)
        Me.lblPuerto.TabIndex = 45
        Me.lblPuerto.Text = "puerto"
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblEstado.Location = New System.Drawing.Point(181, 88)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(0, 21)
        Me.lblEstado.TabIndex = 45
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label4.Location = New System.Drawing.Point(116, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 21)
        Me.Label4.TabIndex = 45
        Me.Label4.Text = "Estado:"
        '
        'btnConectar
        '
        Me.btnConectar.BackColor = System.Drawing.SystemColors.Control
        Me.btnConectar.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnConectar.ForeColor = System.Drawing.Color.Black
        Me.btnConectar.Image = CType(resources.GetObject("btnConectar.Image"), System.Drawing.Image)
        Me.btnConectar.Location = New System.Drawing.Point(437, 83)
        Me.btnConectar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnConectar.Name = "btnConectar"
        Me.btnConectar.Size = New System.Drawing.Size(30, 30)
        Me.btnConectar.TabIndex = 46
        Me.ToolTip1.SetToolTip(Me.btnConectar, "Validar conexión")
        Me.btnConectar.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 20000
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(752, 299)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnConectar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.lblPuerto)
        Me.Controls.Add(Me.lblIp)
        Me.Controls.Add(Me.btnEnviarMensaje)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblEquipo)
        Me.Controls.Add(Me.TextBoxMENSAJES1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.picPantalla)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Servidor"
        CType(Me.NumH1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumM1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPantalla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents NumH1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumM1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents ButtonBLOQUEO As System.Windows.Forms.Button
    Friend WithEvents ButtonAPAGAR As System.Windows.Forms.Button
    Friend WithEvents ButtonINICIAR As System.Windows.Forms.Button
    Friend WithEvents TextBoxMENSAJES1 As System.Windows.Forms.TextBox
    Friend WithEvents ButtonAÑADIR As System.Windows.Forms.Button
    Friend WithEvents ButtonREINICIAR As System.Windows.Forms.Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents picPantalla As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lblEquipo As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnEnviarMensaje As Button
    Friend WithEvents btnBloquear As Button
    Friend WithEvents lblIp As Label
    Friend WithEvents lblPuerto As Label
    Friend WithEvents lblEstado As Label
    Friend WithEvents btnDesbloquear As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents btnConectar As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Timer1 As Timer
End Class
