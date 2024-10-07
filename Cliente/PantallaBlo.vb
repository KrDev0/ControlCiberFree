
Imports System.Runtime.InteropServices
Imports System.Security.Principal

Public Class PantallaBlo

    Public DESBLOQUEO As Boolean = False
    ' Comando para detener y finalizar explorer.exe usando cmd
    Dim proceso As New Process()
    Private Sub BLOQUEO_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If DESBLOQUEO = False Then
            e.Cancel = True
        End If
    End Sub
    Private Sub TextBoxCONTRASEÑA_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TextBoxCONTRASEÑA.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TextBoxCONTRASEÑA.Text = My.Settings.adminPass Then
                e.SuppressKeyPress = True
                DESBLOQUEO = True
                Me.Close()
                Config.Show()
            Else
                MessageBox.Show("La contraseña del administrador no es correcta", "Control Ciber", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
        If e.KeyCode = Keys.LWin Or e.KeyCode = Keys.RWin Then
            Me.Activate()
            e.SuppressKeyPress = True ' Suprimir el evento de la tecla
            e.Handled = True          ' Indicar que el evento fue manejado
        End If
    End Sub

    Private Sub BLOQUEO_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.LWin Or e.KeyCode = Keys.RWin Then
            Me.Activate()
            e.SuppressKeyPress = True ' Suprimir el evento de la tecla
            e.Handled = True          ' Indicar que el evento fue manejado
        End If
    End Sub

    'NO IMPLEMENTADO
    Private Sub FinalizarExplorador()
        proceso.StartInfo.FileName = "cmd.exe"
        proceso.StartInfo.Arguments = "/C taskkill /f /IM explorer.exe"
        proceso.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        proceso.Start()
    End Sub

    Private Sub PantallaBlo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblNombreCiber.Text = My.Settings.nombreCiber
    End Sub
End Class