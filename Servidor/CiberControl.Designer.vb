<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CiberControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CiberControl))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pc1 = New System.Windows.Forms.TabPage()
        Me.pc2 = New System.Windows.Forms.TabPage()
        Me.pc3 = New System.Windows.Forms.TabPage()
        Me.pc4 = New System.Windows.Forms.TabPage()
        Me.pc5 = New System.Windows.Forms.TabPage()
        Me.pc6 = New System.Windows.Forms.TabPage()
        Me.pc7 = New System.Windows.Forms.TabPage()
        Me.pc8 = New System.Windows.Forms.TabPage()
        Me.pc9 = New System.Windows.Forms.TabPage()
        Me.pc10 = New System.Windows.Forms.TabPage()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.btnSettings = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pc1.SuspendLayout()
        Me.pc2.SuspendLayout()
        Me.pc3.SuspendLayout()
        Me.pc4.SuspendLayout()
        Me.pc5.SuspendLayout()
        Me.pc6.SuspendLayout()
        Me.pc7.SuspendLayout()
        Me.pc8.SuspendLayout()
        Me.pc9.SuspendLayout()
        Me.pc10.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.pc1)
        Me.TabControl1.Controls.Add(Me.pc2)
        Me.TabControl1.Controls.Add(Me.pc3)
        Me.TabControl1.Controls.Add(Me.pc4)
        Me.TabControl1.Controls.Add(Me.pc5)
        Me.TabControl1.Controls.Add(Me.pc6)
        Me.TabControl1.Controls.Add(Me.pc7)
        Me.TabControl1.Controls.Add(Me.pc8)
        Me.TabControl1.Controls.Add(Me.pc9)
        Me.TabControl1.Controls.Add(Me.pc10)
        Me.TabControl1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(12, 96)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(776, 356)
        Me.TabControl1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 22.0!)
        Me.Label1.Location = New System.Drawing.Point(118, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(281, 41)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "CONTROL DE CIBER"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 78)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'pc1
        '
        Me.pc1.Controls.Add(Me.Panel1)
        Me.pc1.Location = New System.Drawing.Point(4, 30)
        Me.pc1.Name = "pc1"
        Me.pc1.Size = New System.Drawing.Size(768, 322)
        Me.pc1.TabIndex = 0
        Me.pc1.Text = "Equipo 1"
        Me.pc1.UseVisualStyleBackColor = True
        '
        'pc2
        '
        Me.pc2.Controls.Add(Me.Panel2)
        Me.pc2.Location = New System.Drawing.Point(4, 30)
        Me.pc2.Name = "pc2"
        Me.pc2.Size = New System.Drawing.Size(768, 338)
        Me.pc2.TabIndex = 1
        Me.pc2.Text = "Equipo 2"
        Me.pc2.UseVisualStyleBackColor = True
        '
        'pc3
        '
        Me.pc3.Controls.Add(Me.Panel3)
        Me.pc3.Location = New System.Drawing.Point(4, 30)
        Me.pc3.Name = "pc3"
        Me.pc3.Size = New System.Drawing.Size(768, 338)
        Me.pc3.TabIndex = 2
        Me.pc3.Text = "Equipo 3"
        Me.pc3.UseVisualStyleBackColor = True
        '
        'pc4
        '
        Me.pc4.Controls.Add(Me.Panel4)
        Me.pc4.Location = New System.Drawing.Point(4, 30)
        Me.pc4.Name = "pc4"
        Me.pc4.Size = New System.Drawing.Size(768, 338)
        Me.pc4.TabIndex = 3
        Me.pc4.Text = "Equipo 4"
        Me.pc4.UseVisualStyleBackColor = True
        '
        'pc5
        '
        Me.pc5.Controls.Add(Me.Panel5)
        Me.pc5.Location = New System.Drawing.Point(4, 30)
        Me.pc5.Name = "pc5"
        Me.pc5.Size = New System.Drawing.Size(768, 338)
        Me.pc5.TabIndex = 4
        Me.pc5.Text = "Equipo 5"
        Me.pc5.UseVisualStyleBackColor = True
        '
        'pc6
        '
        Me.pc6.Controls.Add(Me.Panel6)
        Me.pc6.Location = New System.Drawing.Point(4, 30)
        Me.pc6.Name = "pc6"
        Me.pc6.Size = New System.Drawing.Size(768, 338)
        Me.pc6.TabIndex = 5
        Me.pc6.Text = "Equipo 6"
        Me.pc6.UseVisualStyleBackColor = True
        '
        'pc7
        '
        Me.pc7.Controls.Add(Me.Panel7)
        Me.pc7.Location = New System.Drawing.Point(4, 30)
        Me.pc7.Name = "pc7"
        Me.pc7.Size = New System.Drawing.Size(768, 338)
        Me.pc7.TabIndex = 6
        Me.pc7.Text = "Equipo 7"
        Me.pc7.UseVisualStyleBackColor = True
        '
        'pc8
        '
        Me.pc8.Controls.Add(Me.Panel8)
        Me.pc8.Location = New System.Drawing.Point(4, 30)
        Me.pc8.Name = "pc8"
        Me.pc8.Size = New System.Drawing.Size(768, 338)
        Me.pc8.TabIndex = 7
        Me.pc8.Text = "Equipo 8"
        Me.pc8.UseVisualStyleBackColor = True
        '
        'pc9
        '
        Me.pc9.Controls.Add(Me.Panel9)
        Me.pc9.Location = New System.Drawing.Point(4, 30)
        Me.pc9.Name = "pc9"
        Me.pc9.Size = New System.Drawing.Size(768, 338)
        Me.pc9.TabIndex = 8
        Me.pc9.Text = "Equipo 9"
        Me.pc9.UseVisualStyleBackColor = True
        '
        'pc10
        '
        Me.pc10.Controls.Add(Me.Panel10)
        Me.pc10.Location = New System.Drawing.Point(4, 30)
        Me.pc10.Name = "pc10"
        Me.pc10.Size = New System.Drawing.Size(768, 338)
        Me.pc10.TabIndex = 9
        Me.pc10.Text = "Equipo 10"
        Me.pc10.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label2.Location = New System.Drawing.Point(320, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 19)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "version: 2.0"
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(768, 322)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(768, 338)
        Me.Panel2.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(768, 338)
        Me.Panel3.TabIndex = 2
        '
        'Panel4
        '
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(768, 338)
        Me.Panel4.TabIndex = 2
        '
        'Panel5
        '
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(768, 338)
        Me.Panel5.TabIndex = 2
        '
        'Panel6
        '
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(768, 338)
        Me.Panel6.TabIndex = 2
        '
        'Panel7
        '
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(768, 338)
        Me.Panel7.TabIndex = 2
        '
        'Panel8
        '
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel8.Location = New System.Drawing.Point(0, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(768, 338)
        Me.Panel8.TabIndex = 2
        '
        'Panel9
        '
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel9.Location = New System.Drawing.Point(0, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(768, 338)
        Me.Panel9.TabIndex = 2
        '
        'Panel10
        '
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel10.Location = New System.Drawing.Point(0, 0)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(768, 338)
        Me.Panel10.TabIndex = 2
        '
        'btnSettings
        '
        Me.btnSettings.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSettings.Image = CType(resources.GetObject("btnSettings.Image"), System.Drawing.Image)
        Me.btnSettings.Location = New System.Drawing.Point(710, 12)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(78, 78)
        Me.btnSettings.TabIndex = 4
        Me.btnSettings.Text = "Ajustes"
        Me.btnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnSettings.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label3.Location = New System.Drawing.Point(121, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(155, 19)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Desarrollado por: KrDev"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label4.Location = New System.Drawing.Point(661, 452)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(127, 19)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "www.krsolution.site"
        '
        'CiberControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 480)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnSettings)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "CiberControl"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Control de ciber"
        Me.TabControl1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pc1.ResumeLayout(False)
        Me.pc2.ResumeLayout(False)
        Me.pc3.ResumeLayout(False)
        Me.pc4.ResumeLayout(False)
        Me.pc5.ResumeLayout(False)
        Me.pc6.ResumeLayout(False)
        Me.pc7.ResumeLayout(False)
        Me.pc8.ResumeLayout(False)
        Me.pc9.ResumeLayout(False)
        Me.pc10.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents pc1 As TabPage
    Friend WithEvents pc2 As TabPage
    Friend WithEvents pc3 As TabPage
    Friend WithEvents pc4 As TabPage
    Friend WithEvents pc5 As TabPage
    Friend WithEvents pc6 As TabPage
    Friend WithEvents pc7 As TabPage
    Friend WithEvents pc8 As TabPage
    Friend WithEvents pc9 As TabPage
    Friend WithEvents pc10 As TabPage
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Panel10 As Panel
    Friend WithEvents btnSettings As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
End Class
