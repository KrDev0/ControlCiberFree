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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.TextBoxPUERTO1 = New System.Windows.Forms.TextBox()
        Me.NumH1 = New System.Windows.Forms.NumericUpDown()
        Me.NumM1 = New System.Windows.Forms.NumericUpDown()
        Me.ButtonBLOQUEO = New System.Windows.Forms.Button()
        Me.ButtonAPAGAR = New System.Windows.Forms.Button()
        Me.ButtonINICIAR = New System.Windows.Forms.Button()
        Me.TextBoxMENSAJES1 = New System.Windows.Forms.TextBox()
        Me.ButtonAÑADIR = New System.Windows.Forms.Button()
        Me.ButtonCERRAR = New System.Windows.Forms.Button()
        Me.ButtonREINICIAR = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DOS = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnRegistrarIP = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        CType(Me.NumH1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumM1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBoxPUERTO1
        '
        Me.TextBoxPUERTO1.BackColor = System.Drawing.Color.White
        Me.TextBoxPUERTO1.ForeColor = System.Drawing.Color.Black
        Me.TextBoxPUERTO1.Location = New System.Drawing.Point(301, 139)
        Me.TextBoxPUERTO1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxPUERTO1.Name = "TextBoxPUERTO1"
        Me.TextBoxPUERTO1.Size = New System.Drawing.Size(140, 29)
        Me.TextBoxPUERTO1.TabIndex = 5
        Me.TextBoxPUERTO1.Text = "55555"
        Me.TextBoxPUERTO1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TextBoxPUERTO1.Visible = False
        '
        'NumH1
        '
        Me.NumH1.BackColor = System.Drawing.Color.White
        Me.NumH1.ForeColor = System.Drawing.Color.Black
        Me.NumH1.Location = New System.Drawing.Point(53, 23)
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
        Me.NumM1.Location = New System.Drawing.Point(178, 23)
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
        Me.ButtonBLOQUEO.Location = New System.Drawing.Point(123, 94)
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
        Me.ButtonAPAGAR.Location = New System.Drawing.Point(15, 23)
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
        Me.ButtonINICIAR.Location = New System.Drawing.Point(9, 60)
        Me.ButtonINICIAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButtonINICIAR.Name = "ButtonINICIAR"
        Me.ButtonINICIAR.Size = New System.Drawing.Size(108, 29)
        Me.ButtonINICIAR.TabIndex = 12
        Me.ButtonINICIAR.Text = "Iniciar tiempo"
        Me.ButtonINICIAR.UseVisualStyleBackColor = True
        '
        'TextBoxMENSAJES1
        '
        Me.TextBoxMENSAJES1.BackColor = System.Drawing.Color.White
        Me.TextBoxMENSAJES1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TextBoxMENSAJES1.ForeColor = System.Drawing.Color.Black
        Me.TextBoxMENSAJES1.Location = New System.Drawing.Point(12, 176)
        Me.TextBoxMENSAJES1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxMENSAJES1.Multiline = True
        Me.TextBoxMENSAJES1.Name = "TextBoxMENSAJES1"
        Me.TextBoxMENSAJES1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxMENSAJES1.Size = New System.Drawing.Size(429, 104)
        Me.TextBoxMENSAJES1.TabIndex = 13
        '
        'ButtonAÑADIR
        '
        Me.ButtonAÑADIR.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonAÑADIR.Enabled = False
        Me.ButtonAÑADIR.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ButtonAÑADIR.ForeColor = System.Drawing.Color.Black
        Me.ButtonAÑADIR.Location = New System.Drawing.Point(123, 60)
        Me.ButtonAÑADIR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButtonAÑADIR.Name = "ButtonAÑADIR"
        Me.ButtonAÑADIR.Size = New System.Drawing.Size(115, 29)
        Me.ButtonAÑADIR.TabIndex = 24
        Me.ButtonAÑADIR.Text = "Añadir tiempo"
        Me.ButtonAÑADIR.UseVisualStyleBackColor = True
        '
        'ButtonCERRAR
        '
        Me.ButtonCERRAR.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonCERRAR.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ButtonCERRAR.ForeColor = System.Drawing.Color.Black
        Me.ButtonCERRAR.Location = New System.Drawing.Point(9, 94)
        Me.ButtonCERRAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButtonCERRAR.Name = "ButtonCERRAR"
        Me.ButtonCERRAR.Size = New System.Drawing.Size(108, 29)
        Me.ButtonCERRAR.TabIndex = 25
        Me.ButtonCERRAR.Text = "Cerrar app"
        Me.ButtonCERRAR.UseVisualStyleBackColor = True
        '
        'ButtonREINICIAR
        '
        Me.ButtonREINICIAR.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonREINICIAR.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ButtonREINICIAR.ForeColor = System.Drawing.Color.Black
        Me.ButtonREINICIAR.Location = New System.Drawing.Point(15, 60)
        Me.ButtonREINICIAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButtonREINICIAR.Name = "ButtonREINICIAR"
        Me.ButtonREINICIAR.Size = New System.Drawing.Size(140, 29)
        Me.ButtonREINICIAR.TabIndex = 26
        Me.ButtonREINICIAR.Text = "Reiniciar equipo"
        Me.ButtonREINICIAR.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.BackColor = System.Drawing.SystemColors.Control
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.ForeColor = System.Drawing.Color.Black
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Equipo 1", "Equipo 2", "Equipo 3", "Equipo 4"})
        Me.ComboBox1.Location = New System.Drawing.Point(156, 139)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(140, 29)
        Me.ComboBox1.TabIndex = 27
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(119, 25)
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
        Me.Label3.Location = New System.Drawing.Point(9, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 21)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Hora:"
        '
        'DOS
        '
        Me.DOS.AutoSize = True
        Me.DOS.BackColor = System.Drawing.Color.Transparent
        Me.DOS.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.DOS.ForeColor = System.Drawing.Color.Black
        Me.DOS.Location = New System.Drawing.Point(154, 114)
        Me.DOS.Name = "DOS"
        Me.DOS.Size = New System.Drawing.Size(144, 21)
        Me.DOS.TabIndex = 38
        Me.DOS.Text = "Seleccionar equipo:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(178, 14)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(96, 96)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 39
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.NumH1)
        Me.GroupBox1.Controls.Add(Me.ButtonBLOQUEO)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.NumM1)
        Me.GroupBox1.Controls.Add(Me.ButtonINICIAR)
        Me.GroupBox1.Controls.Add(Me.ButtonAÑADIR)
        Me.GroupBox1.Controls.Add(Me.ButtonCERRAR)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 287)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(246, 130)
        Me.GroupBox1.TabIndex = 40
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Control de tiempo:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnRegistrarIP)
        Me.GroupBox2.Controls.Add(Me.ButtonAPAGAR)
        Me.GroupBox2.Controls.Add(Me.ButtonREINICIAR)
        Me.GroupBox2.Location = New System.Drawing.Point(271, 287)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(170, 130)
        Me.GroupBox2.TabIndex = 41
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Opciones de equipo"
        '
        'btnRegistrarIP
        '
        Me.btnRegistrarIP.BackColor = System.Drawing.SystemColors.Control
        Me.btnRegistrarIP.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnRegistrarIP.ForeColor = System.Drawing.Color.Black
        Me.btnRegistrarIP.Location = New System.Drawing.Point(15, 94)
        Me.btnRegistrarIP.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnRegistrarIP.Name = "btnRegistrarIP"
        Me.btnRegistrarIP.Size = New System.Drawing.Size(140, 29)
        Me.btnRegistrarIP.TabIndex = 27
        Me.btnRegistrarIP.Text = "Registrar equipo"
        Me.btnRegistrarIP.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(0, 418)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(453, 13)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Desarrollado por: CSoftware"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(12, 13)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(76, 34)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 43
        Me.PictureBox2.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(453, 431)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.TextBoxMENSAJES1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TextBoxPUERTO1)
        Me.Controls.Add(Me.DOS)
        Me.Controls.Add(Me.ComboBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Servidor"
        CType(Me.NumH1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumM1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBoxPUERTO1 As System.Windows.Forms.TextBox
    Friend WithEvents NumH1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumM1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents ButtonBLOQUEO As System.Windows.Forms.Button
    Friend WithEvents ButtonAPAGAR As System.Windows.Forms.Button
    Friend WithEvents ButtonINICIAR As System.Windows.Forms.Button
    Friend WithEvents TextBoxMENSAJES1 As System.Windows.Forms.TextBox
    Friend WithEvents ButtonAÑADIR As System.Windows.Forms.Button
    Friend WithEvents ButtonCERRAR As System.Windows.Forms.Button
    Friend WithEvents ButtonREINICIAR As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents DOS As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents btnRegistrarIP As Button
End Class
