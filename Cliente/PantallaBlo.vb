
Public Class PantallaBlo
    Public DESBLOQUEO As Boolean = False

    Private Sub BLOQUEO_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If DESBLOQUEO = False Then
            e.Cancel = True
        End If
    End Sub

    Private Sub TextBoxCONTRASEÑA_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TextBoxCONTRASEÑA.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TextBoxCONTRASEÑA.Text = "102250" Then
                e.SuppressKeyPress = True
                DESBLOQUEO = True
                Me.Close()
                Config.Show()
            Else
                MsgBox("CONTRASEÑA  ERRONEA")
            End If
        End If
        If e.KeyCode = Keys.LWin Or e.KeyCode = Keys.RWin Then
            Me.Activate()
            e.Handled = True
        End If
    End Sub

    Private Sub BLOQUEO_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.LWin Or e.KeyCode = Keys.RWin Then
            Me.Activate()
            e.Handled = True
        End If
    End Sub
End Class