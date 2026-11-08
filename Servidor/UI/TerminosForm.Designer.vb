<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TerminosForm
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
        Me.txtTerminos = New System.Windows.Forms.TextBox()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtTerminos
        '
        Me.txtTerminos.BackColor = System.Drawing.Color.White
        Me.txtTerminos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTerminos.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtTerminos.Location = New System.Drawing.Point(12, 12)
        Me.txtTerminos.Multiline = True
        Me.txtTerminos.Name = "txtTerminos"
        Me.txtTerminos.ReadOnly = True
        Me.txtTerminos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTerminos.Size = New System.Drawing.Size(560, 357)
        Me.txtTerminos.TabIndex = 0
        '
        'btnCerrar
        '
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnCerrar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnCerrar.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnCerrar.Location = New System.Drawing.Point(12, 369)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(560, 36)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'TerminosForm
        '
        Me.AcceptButton = Me.btnCerrar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(584, 417)
        Me.Controls.Add(Me.txtTerminos)
        Me.Controls.Add(Me.btnCerrar)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TerminosForm"
        Me.Padding = New System.Windows.Forms.Padding(12)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Términos de uso"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtTerminos As TextBox
    Friend WithEvents btnCerrar As Button
End Class
