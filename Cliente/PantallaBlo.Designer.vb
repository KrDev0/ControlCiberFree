<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PantallaBlo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PantallaBlo))
        Me.TextBoxCONTRASEÑA = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblNombreCiber = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.panelIzquierda = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.panelAbajo = New System.Windows.Forms.Panel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.panelIzquierda.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.panelAbajo.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBoxCONTRASEÑA
        '
        Me.TextBoxCONTRASEÑA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TextBoxCONTRASEÑA.Location = New System.Drawing.Point(10, 48)
        Me.TextBoxCONTRASEÑA.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxCONTRASEÑA.Name = "TextBoxCONTRASEÑA"
        Me.TextBoxCONTRASEÑA.Size = New System.Drawing.Size(184, 29)
        Me.TextBoxCONTRASEÑA.TabIndex = 0
        Me.TextBoxCONTRASEÑA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TextBoxCONTRASEÑA.UseSystemPasswordChar = True
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 24.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(155, 169)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(281, 45)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Equipo Bloqueado"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(101, 167)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 48)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.TextBoxCONTRASEÑA)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(214, 87)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Desbloquear equipo:"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(6, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(193, 19)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Contraseña del administrador:"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(312, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(459, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Desarrollado por: KrDev - www.krsolution.site"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblNombreCiber
        '
        Me.lblNombreCiber.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNombreCiber.Font = New System.Drawing.Font("Segoe UI", 24.0!)
        Me.lblNombreCiber.ForeColor = System.Drawing.Color.Black
        Me.lblNombreCiber.Location = New System.Drawing.Point(6, 219)
        Me.lblNombreCiber.Name = "lblNombreCiber"
        Me.lblNombreCiber.Size = New System.Drawing.Size(518, 45)
        Me.lblNombreCiber.TabIndex = 1
        Me.lblNombreCiber.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(42, 17)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(152, 176)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 2
        Me.PictureBox2.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.PictureBox2)
        Me.GroupBox2.Location = New System.Drawing.Point(-4, -13)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(236, 444)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(192, 229)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 19)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "v2.0"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 18.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(9, 197)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(224, 32)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "CONTROL DE CIBER"
        '
        'panelIzquierda
        '
        Me.panelIzquierda.Controls.Add(Me.GroupBox2)
        Me.panelIzquierda.Dock = System.Windows.Forms.DockStyle.Left
        Me.panelIzquierda.Location = New System.Drawing.Point(0, 0)
        Me.panelIzquierda.Name = "panelIzquierda"
        Me.panelIzquierda.Size = New System.Drawing.Size(235, 424)
        Me.panelIzquierda.TabIndex = 5
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.lblNombreCiber)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(235, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(536, 424)
        Me.Panel2.TabIndex = 6
        '
        'panelAbajo
        '
        Me.panelAbajo.Controls.Add(Me.Label2)
        Me.panelAbajo.Controls.Add(Me.GroupBox1)
        Me.panelAbajo.Controls.Add(Me.GroupBox3)
        Me.panelAbajo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panelAbajo.Location = New System.Drawing.Point(0, 424)
        Me.panelAbajo.Name = "panelAbajo"
        Me.panelAbajo.Size = New System.Drawing.Size(771, 118)
        Me.panelAbajo.TabIndex = 7
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Location = New System.Drawing.Point(-4, -11)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(786, 137)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        '
        'PantallaBlo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(771, 542)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.panelIzquierda)
        Me.Controls.Add(Me.panelAbajo)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PantallaBlo"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Equipo bloqueado"
        Me.TopMost = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.panelIzquierda.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.panelAbajo.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TextBoxCONTRASEÑA As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lblNombreCiber As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents panelIzquierda As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents panelAbajo As Panel
    Friend WithEvents GroupBox3 As GroupBox
End Class
