<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Config
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
        CType(Me.NumMENSAJES, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumPREAVISO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBoxPUERTO
        '
        Me.TextBoxPUERTO.BackColor = System.Drawing.SystemColors.Control
        Me.TextBoxPUERTO.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxPUERTO.ForeColor = System.Drawing.Color.Black
        Me.TextBoxPUERTO.Location = New System.Drawing.Point(145, 126)
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
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(73, 134)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 21)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "PUERTO"
        '
        'TextBoxCONTRASEÑA
        '
        Me.TextBoxCONTRASEÑA.BackColor = System.Drawing.SystemColors.Control
        Me.TextBoxCONTRASEÑA.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCONTRASEÑA.ForeColor = System.Drawing.Color.Black
        Me.TextBoxCONTRASEÑA.Location = New System.Drawing.Point(145, 15)
        Me.TextBoxCONTRASEÑA.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxCONTRASEÑA.Name = "TextBoxCONTRASEÑA"
        Me.TextBoxCONTRASEÑA.PasswordChar = Global.Microsoft.VisualBasic.ChrW(57)
        Me.TextBoxCONTRASEÑA.Size = New System.Drawing.Size(208, 29)
        Me.TextBoxCONTRASEÑA.TabIndex = 14
        Me.TextBoxCONTRASEÑA.Text = "102250"
        Me.TextBoxCONTRASEÑA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(28, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 21)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "CONTRASEÑA"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(37, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 21)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "T. MENSAJES"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(43, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 21)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "T. PREAVISO"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(312, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 21)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "SEG."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(310, 91)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 21)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "MIN."
        '
        'TimerMENSAJES
        '
        '
        'ButtonINICIAR
        '
        Me.ButtonINICIAR.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonINICIAR.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ButtonINICIAR.ForeColor = System.Drawing.Color.Black
        Me.ButtonINICIAR.Location = New System.Drawing.Point(95, 267)
        Me.ButtonINICIAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButtonINICIAR.Name = "ButtonINICIAR"
        Me.ButtonINICIAR.Size = New System.Drawing.Size(196, 29)
        Me.ButtonINICIAR.TabIndex = 23
        Me.ButtonINICIAR.Text = "Iniciar tiempo [Demo]"
        Me.ButtonINICIAR.UseVisualStyleBackColor = True
        '
        'NumMENSAJES
        '
        Me.NumMENSAJES.BackColor = System.Drawing.SystemColors.Control
        Me.NumMENSAJES.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumMENSAJES.ForeColor = System.Drawing.Color.Black
        Me.NumMENSAJES.Location = New System.Drawing.Point(145, 52)
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
        Me.NumPREAVISO.Location = New System.Drawing.Point(145, 89)
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
        Me.ButtonNOTSKMNGR.Location = New System.Drawing.Point(6, 21)
        Me.ButtonNOTSKMNGR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButtonNOTSKMNGR.Name = "ButtonNOTSKMNGR"
        Me.ButtonNOTSKMNGR.Size = New System.Drawing.Size(156, 29)
        Me.ButtonNOTSKMNGR.TabIndex = 26
        Me.ButtonNOTSKMNGR.Text = "Bloquear admin."
        Me.ButtonNOTSKMNGR.UseVisualStyleBackColor = True
        '
        'ButtonSITSKMNGR
        '
        Me.ButtonSITSKMNGR.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonSITSKMNGR.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ButtonSITSKMNGR.ForeColor = System.Drawing.Color.Black
        Me.ButtonSITSKMNGR.Location = New System.Drawing.Point(6, 58)
        Me.ButtonSITSKMNGR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButtonSITSKMNGR.Name = "ButtonSITSKMNGR"
        Me.ButtonSITSKMNGR.Size = New System.Drawing.Size(156, 29)
        Me.ButtonSITSKMNGR.TabIndex = 27
        Me.ButtonSITSKMNGR.Text = "Desbloquear admin."
        Me.ButtonSITSKMNGR.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ButtonNOTSKMNGR)
        Me.GroupBox1.Controls.Add(Me.ButtonSITSKMNGR)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 162)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(168, 98)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Admin. de tareas"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ButtonDESREGISTRAR)
        Me.GroupBox2.Controls.Add(Me.ButtonREGISTRAR)
        Me.GroupBox2.Location = New System.Drawing.Point(186, 162)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(188, 98)
        Me.GroupBox2.TabIndex = 29
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Inicio de Windows"
        '
        'ButtonDESREGISTRAR
        '
        Me.ButtonDESREGISTRAR.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonDESREGISTRAR.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ButtonDESREGISTRAR.ForeColor = System.Drawing.Color.Black
        Me.ButtonDESREGISTRAR.Location = New System.Drawing.Point(6, 58)
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
        Me.ButtonREGISTRAR.Location = New System.Drawing.Point(6, 21)
        Me.ButtonREGISTRAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButtonREGISTRAR.Name = "ButtonREGISTRAR"
        Me.ButtonREGISTRAR.Size = New System.Drawing.Size(176, 29)
        Me.ButtonREGISTRAR.TabIndex = 26
        Me.ButtonREGISTRAR.Text = "Registrar Inicio"
        Me.ButtonREGISTRAR.UseVisualStyleBackColor = True
        '
        'Config
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(386, 310)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.NumPREAVISO)
        Me.Controls.Add(Me.NumMENSAJES)
        Me.Controls.Add(Me.ButtonINICIAR)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBoxCONTRASEÑA)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBoxPUERTO)
        Me.Controls.Add(Me.Label3)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Config"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CONFIGURACION"
        CType(Me.NumMENSAJES, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumPREAVISO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
End Class
