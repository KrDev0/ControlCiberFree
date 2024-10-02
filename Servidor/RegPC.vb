Public Class RegPC
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Settings.ipPC1 = ip1.Text
        My.Settings.ipPC2 = ip2.Text
        My.Settings.ipPC3 = ip3.Text
        My.Settings.ipPC4 = ip4.Text
        My.Settings.Save()

        MessageBox.Show("Equipo/s Registrados")
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ip1.Text = My.Settings.ipPC1
        ip2.Text = My.Settings.ipPC2
        ip3.Text = My.Settings.ipPC3
        ip4.Text = My.Settings.ipPC4
    End Sub
End Class