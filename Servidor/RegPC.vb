Public Class RegPC
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Settings.ipPC1 = ip1.Text
        My.Settings.ipPC2 = ip2.Text
        My.Settings.ipPC3 = ip3.Text
        My.Settings.ipPC4 = ip4.Text
        My.Settings.ipPC5 = ip5.Text
        My.Settings.ipPC6 = ip6.Text
        My.Settings.ipPC7 = ip7.Text
        My.Settings.ipPC8 = ip8.Text
        My.Settings.ipPC9 = ip8.Text
        My.Settings.ipPC10 = ip10.Text
        My.Settings.Save()

        MessageBox.Show("Equipo/s registrados", "Control de ciber", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ip1.Text = My.Settings.ipPC1
        ip2.Text = My.Settings.ipPC2
        ip3.Text = My.Settings.ipPC3
        ip4.Text = My.Settings.ipPC4
        ip5.Text = My.Settings.ipPC5
        ip6.Text = My.Settings.ipPC6
        ip7.Text = My.Settings.ipPC7
        ip8.Text = My.Settings.ipPC8
        ip9.Text = My.Settings.ipPC9
        ip10.Text = My.Settings.ipPC10
        txtPuerto.Text = My.Settings.puerto
    End Sub

    Private Sub btnGuardarPuerto_Click(sender As Object, e As EventArgs) Handles btnGuardarPuerto.Click
        My.Settings.puerto = txtPuerto.Text
        My.Settings.Save()

        MessageBox.Show("Puerto registrado", "Control de ciber", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
End Class