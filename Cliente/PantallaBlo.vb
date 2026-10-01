
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
            If ClienteCfg.PassOk(TextBoxCONTRASEÑA.Text) Then
                e.SuppressKeyPress = True
                DESBLOQUEO = True
                TextBoxCONTRASEÑA.Clear()
                Me.Close()
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
        lblNombreCiber.Text = ClienteCfg.NombreCiber
        ' Tema claro v4.6 (solo colores, sin tocar layout del diseñador)
        Try
            Dim ink As Color = Color.FromArgb(31, 41, 55)
            Dim accent As Color = Color.FromArgb(45, 137, 239)
            Dim soft As Color = Color.FromArgb(243, 244, 246)
            Me.BackColor = Color.White
            Panel2.BackColor = Color.White
            panelAbajo.BackColor = Color.White
            panelIzquierda.BackColor = soft
            GroupBox1.ForeColor = ink : GroupBox1.BackColor = Color.Transparent
            GroupBox2.ForeColor = ink : GroupBox2.BackColor = Color.Transparent
            GroupBox3.BackColor = Color.Transparent
            Label1.ForeColor = ink
            lblNombreCiber.ForeColor = accent
            Label3.ForeColor = ink
            Label5.ForeColor = Color.FromArgb(107, 114, 128) : Label5.Text = "v3.0"
            Label4.ForeColor = ink
            Label2.ForeColor = Color.FromArgb(107, 114, 128)
            TextBoxCONTRASEÑA.BackColor = Color.White
        Catch
        End Try
    End Sub
End Class