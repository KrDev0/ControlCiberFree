
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
                TecladoBloqueo.Desinstalar()
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

    Private Sub PantallaBlo_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        ' Hook solo con el bloqueo visible: al desbloquear o cerrar se libera el teclado.
        Try
            If Me.Visible AndAlso Not DESBLOQUEO Then
                TecladoBloqueo.Instalar()
            Else
                TecladoBloqueo.Desinstalar()
            End If
        Catch
        End Try
    End Sub

    ''' <summary>Muestra fondo.jpg (enviado desde el servidor) o limpia si no existe.</summary>
    Public Sub AplicarFondo()
        Try
            Dim ruta As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "fondo.jpg")
            If Not IO.File.Exists(ruta) Then
                Try
                    Dim old0 = picFondo.Image
                    picFondo.Image = Nothing
                    If old0 IsNot Nothing Then old0.Dispose()
                Catch
                End Try
                Return
            End If
            Dim bin As Byte() = IO.File.ReadAllBytes(ruta)
            Using ms As New IO.MemoryStream(bin)
                Using img As Image = Image.FromStream(ms)
                    Dim bmp As New Bitmap(img)
                    Dim old = picFondo.Image
                    picFondo.Image = bmp
                    If old IsNot Nothing Then old.Dispose()
                End Using
            End Using
        Catch
        End Try
    End Sub

    Private Sub PantallaBlo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblNombreCiber.Text = ClienteCfg.NombreCiber
        AplicarFondo()
        ' Tema claro (solo colores, sin tocar layout del diseñador)
        Try
            Dim ink As Color = Color.FromArgb(31, 41, 55)
            Dim accent As Color = Color.FromArgb(45, 137, 239)
            Dim soft As Color = Color.FromArgb(243, 244, 246)
            Me.BackColor = Color.White
            Panel2.BackColor = soft
            Label1.ForeColor = ink
            Label3.ForeColor = ink
            Label5.ForeColor = Color.FromArgb(107, 114, 128) : Label5.Text = "v3.2"
            Label4.ForeColor = ink
            Label2.ForeColor = Color.FromArgb(107, 114, 128)
            TextBoxCONTRASEÑA.BackColor = Color.White

            PictureBox1.Parent = picFondo
            Label1.Parent = picFondo
        Catch
        End Try
    End Sub
End Class