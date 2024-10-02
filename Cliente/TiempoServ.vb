Public Class TiempoServ
    Private Sub SERVICIO_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - Me.Width - 40, 50)
        Me.TopMost = True
        TimerSEGUNDOS.Interval = 1000
        TimerSEGUNDOS.Start()
    End Sub

    Private Sub TimerSEGUNDOS_Tick(sender As System.Object, e As System.EventArgs) Handles TimerSEGUNDOS.Tick
        LabelACTUAL.Text = DateTime.Now.ToLongTimeString
    End Sub

    Private Sub SERVICIO_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
    End Sub
End Class