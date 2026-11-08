Public Class TiempoServ
    Private _cierreSolicitado As Boolean = False

    Public Sub CerrarPorSistema()
        _cierreSolicitado = True
        TimerSEGUNDOS.Stop()
        Me.Close()
    End Sub
    Private Sub SERVICIO_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - Me.Width - 40, 50)
        Me.TopMost = True
        ' Tema oscuro v4.8
        Try
            Me.BackColor = Color.FromArgb(31, 41, 55)
            Me.ForeColor = Color.White
            Label1.ForeColor = Color.FromArgb(209, 213, 219)
            LabelACTUAL.ForeColor = Color.White
            Label2.ForeColor = Color.FromArgb(110, 231, 183)
            LabelINICIO.ForeColor = Color.White
            Label3.ForeColor = Color.FromArgb(252, 165, 165)
            LabelLIMITE.ForeColor = Color.White
            Label4.ForeColor = Color.FromArgb(156, 163, 175)
            LabelRestante.ForeColor = Color.FromArgb(110, 231, 183)
            Me.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        Catch
        End Try
        TimerSEGUNDOS.Interval = 1000
        TimerSEGUNDOS.Start()
    End Sub

    Private Sub TimerSEGUNDOS_Tick(sender As System.Object, e As System.EventArgs) Handles TimerSEGUNDOS.Tick
        LabelACTUAL.Text = DateTime.Now.ToLongTimeString
        Try
            If MotorCliente.Instancia Is Nothing OrElse MotorCliente.Instancia.HORALIMITE = DateTime.MinValue Then
                LabelRestante.Text = "Tiempo libre"
                LabelRestante.ForeColor = Color.FromArgb(110, 231, 183)
                Return
            End If
            Dim r As TimeSpan = MotorCliente.TiempoRestante()
            If r = TimeSpan.Zero Then
                LabelRestante.Text = "--:--:--"
                LabelRestante.ForeColor = Color.FromArgb(209, 213, 219)
            Else
                LabelRestante.Text = "Te quedan " & r.Hours.ToString("00") & ":" &
                    r.Minutes.ToString("00") & ":" & r.Seconds.ToString("00")
                If r.TotalMinutes <= ClienteCfg.TiempoPreaviso Then
                    LabelRestante.ForeColor = Color.FromArgb(252, 165, 165)
                Else
                    LabelRestante.ForeColor = Color.FromArgb(110, 231, 183)
                End If
            End If
        Catch
        End Try
    End Sub

    Private Sub SERVICIO_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not _cierreSolicitado Then
            e.Cancel = True
        Else
            _cierreSolicitado = False
        End If
    End Sub
End Class
