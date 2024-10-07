Public Class ingresarContrasena
    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If My.Settings.adminPass = txtadminPass.Text Then
            Me.DialogResult = DialogResult.OK
        Else
            Me.DialogResult = DialogResult.No
        End If
    End Sub

    Private Sub ingresarContrasena_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtadminPass.Clear()
    End Sub
End Class