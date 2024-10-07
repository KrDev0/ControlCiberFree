Imports System.Net.Sockets
Imports System.Net
Imports System.Text.Encoding
Imports Microsoft.Win32
Imports System.Threading.Tasks
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Text

Public Class Config

    Dim ORDENADOR As UdpClient
    Dim MIARRAY As ArrayList
    Dim HORAINICIO As DateTime
    Dim HORALIMITE As DateTime
    Dim AVISADO As Boolean = False
    Dim ADMINISTRADOR As Boolean = False

    Dim SERVIDOR_IP As String = My.Settings.ipServidor ' IP del servidor
    Dim SERVIDOR_PUERTO As Integer = My.Settings.puerto ' Puerto del servidor
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If ADMINISTRADOR = True Then
            Me.Show()
        Else
            Me.Hide()
        End If

        ORDENADOR = New UdpClient(CInt(TextBoxPUERTO.Text))
        ORDENADOR.Client.Blocking = False
        Timer1.Interval = 10
        Timer1.Start()
        PantallaBlo.DESBLOQUEO = False
        PantallaBlo.Show()

        'Cargo la contrasena desde las configuraciones
        TextBoxCONTRASEÑA.Text = My.Settings.adminPass
        TextBoxPUERTO.Text = My.Settings.puerto
        NumMENSAJES.Value = My.Settings.tiempoMensaje
        NumPREAVISO.Value = My.Settings.tiempoPreaviso
        txtNombreCiber.Text = My.Settings.nombreCiber
        txtServidor.Text = My.Settings.ipServidor

        'TimerCaptura.Start()
    End Sub

    Private Sub TimerCaptura_Tick(sender As Object, e As EventArgs) Handles TimerCaptura.Tick
        Try
            ' Captura la pantalla
            Dim captura As Bitmap = CapturarPantalla()

            ' Convierte la captura a un array de bytes
            Dim capturaBytes As Byte() = ConvertirImagenABytes(captura)

            ' Enviar la captura en fragmentos pequeños (por ejemplo, 8192 bytes por fragmento)
            Dim fragmentSize As Integer = 8192
            Dim totalFragments As Integer = Math.Ceiling(capturaBytes.Length / fragmentSize)

            For i As Integer = 0 To totalFragments - 1
                Dim start As Integer = i * fragmentSize
                Dim length As Integer = Math.Min(fragmentSize, capturaBytes.Length - start)
                Dim fragment As Byte() = New Byte(length - 1) {}
                Array.Copy(capturaBytes, start, fragment, 0, length)

                ' Enviar el fragmento con un prefijo indicando el número de fragmento
                Dim prefijo As String = i.ToString("D5") ' Asegurar que todos los fragmentos tengan el mismo tamaño de prefijo
                Dim prefijoBytes As Byte() = Encoding.UTF8.GetBytes(prefijo)
                Dim dataToSend As Byte() = prefijoBytes.Concat(fragment).ToArray()

                ' Enviar fragmento al servidor
                EnviarFragmento(dataToSend)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error al capturar pantalla", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub EnviarFragmento(dataToSend As Byte())
        Dim maxIntentos As Integer = 5 ' Máximo número de intentos
        Dim intentos As Integer = 0
        Dim exito As Boolean = False

        While Not exito AndAlso intentos < maxIntentos
            Try
                ' Configurar el IPEndPoint del servidor
                Dim ipEndPoint As IPEndPoint = New IPEndPoint(IPAddress.Parse(SERVIDOR_IP), SERVIDOR_PUERTO)

                ' Enviar los datos al servidor
                ORDENADOR.Send(dataToSend, dataToSend.Length, ipEndPoint)

                ' Si no hubo error, marcar como exitoso
                exito = True
            Catch ex As SocketException
                ' Si no pudo enviar, aumentar el número de intentos y esperar un breve tiempo antes de reintentar
                intentos += 1
                Threading.Thread.Sleep(100) ' Esperar 100 milisegundos antes de reintentar

                ' Si alcanza el número máximo de intentos, lanzar la excepción
                If intentos >= maxIntentos Then
                    MessageBox.Show("Error al enviar el fragmento de datos al servidor: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit While
                End If
            End Try
        End While
    End Sub
    Private Function CapturarPantalla() As Bitmap
        Dim captura As New Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height)
        Using g As Graphics = Graphics.FromImage(captura)
            g.CopyFromScreen(0, 0, 0, 0, captura.Size)
        End Using
        Return captura
    End Function

    Private Function ConvertirImagenABytes(imagen As Bitmap) As Byte()
        Using ms As New MemoryStream()
            imagen.Save(ms, ImageFormat.Jpeg)
            Return ms.ToArray()
        End Using
    End Function

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Me.Hide()
        Timer1.Stop()
        TimerMENSAJES.Interval = NumMENSAJES.Value * 1000
        TimerMENSAJES.Start()
    End Sub

    Private Sub ButtonINICIAR_Click(sender As System.Object, e As System.EventArgs) Handles ButtonINICIAR.Click
        TiempoServ.Show()
        Me.Hide()
    End Sub

    Private Sub TimerMENSAJES_Tick(sender As System.Object, e As System.EventArgs) Handles TimerMENSAJES.Tick
        Try
            Dim IP As IPEndPoint = New IPEndPoint(IPAddress.Any, 0)
            Dim RECIBEMENSAJE As Byte() = ORDENADOR.Receive(IP)
            Dim MENSAJE As String = UTF7.GetString(RECIBEMENSAJE)
            MIARRAY = New ArrayList(MENSAJE.Split(":"))
            EJECUTA()
        Catch ex As Exception
            'SI HAY MENSAJE NUEVO LO REGISTRA, SI NO LO HAY NO HACE NADA
        End Try
    End Sub

    Public Sub EJECUTA()
        Select Case MIARRAY(0)
            Case "INICIAR"
                HORAINICIO = DateTime.Now
                TiempoServ.LabelINICIO.Text = HORAINICIO.ToLongTimeString
                Dim TOTALMINUTOS As Integer = (MIARRAY(1) * 60) + MIARRAY(2)
                HORALIMITE = HORAINICIO.AddMinutes(TOTALMINUTOS)
                TiempoServ.LabelLIMITE.Text = HORALIMITE.ToLongTimeString
                PantallaBlo.DESBLOQUEO = True
                PantallaBlo.Close()
                Me.Hide()
                TiempoServ.Show()
                TimerMINUTOS.Interval = 60000
                TimerMINUTOS.Start()
            Case "AÑADIR"
                Dim TOTALMINUTOS As Integer = (MIARRAY(1) * 60) + MIARRAY(2)
                HORALIMITE = HORALIMITE.AddMinutes(TOTALMINUTOS)
                TiempoServ.LabelLIMITE.Text = HORALIMITE.ToLongTimeString
            Case "BLOQUEO"
                TimerMINUTOS.Stop()
                TiempoServ.Close()
                Mensaje.Close()
                PantallaBlo.DESBLOQUEO = False
                PantallaBlo.Show()
            Case "DESBLOQUEAR"
                HORAINICIO = DateTime.Now
                TiempoServ.LabelINICIO.Text = HORAINICIO.ToLongTimeString
                TimerMINUTOS.Stop()
                TiempoServ.Close()
                Mensaje.Close()
                PantallaBlo.DESBLOQUEO = True
                PantallaBlo.Close()
                Me.Hide()
                TiempoServ.Show()
                TimerMINUTOS.Interval = 60000
                TimerMINUTOS.Start()
            Case "MENSAJE"
                Mensaje.TextBoxMENSAJES.Text = MIARRAY(1)
                Mensaje.Show()
            Case "REINICIAR"
                CERRAR()
                Process.Start("shutdown", "/r /f")
            Case "APAGAR"
                CERRAR()
                Process.Start("shutdown", "/s /t 0 /f")
            Case "BLOQUEARPC"
                CERRAR()
                Process.Start("rundll32.exe", "user32.dll,LockWorkStation")
        End Select
    End Sub

    Private Sub CERRAR()
        TimerMINUTOS.Stop()
        TiempoServ.Close()
        Mensaje.Close()
        PantallaBlo.DESBLOQUEO = False
        PantallaBlo.Close()
    End Sub

    Private Sub TimerMINUTOS_Tick(sender As System.Object, e As System.EventArgs) Handles TimerMINUTOS.Tick
        Dim INTERVALO As TimeSpan = TimeSpan.FromMinutes(NumPREAVISO.Value)
        Dim HORAACTUAL As DateTime = DateTime.Now
        If HORALIMITE - HORAACTUAL <= INTERVALO And AVISADO = False Then
            Mensaje.TextBoxMENSAJES.Text = "QUEDAN " & NumPREAVISO.Value & " MINUTOS PARA LA HORA LIMITE. SI NECESITAS MAS TIEMPO DIRIGETE AL ENCARGADO. EN OTRO CASO EL ORDENADOR SE BLOQUEARA AUTOMATICAMENTE. GRACIAS POR TU ATENCION"
            AVISADO = True
            Mensaje.Show()
        End If
        If HORAACTUAL >= HORALIMITE Then
            TimerMINUTOS.Stop()
            AVISADO = False
            Mensaje.Close()
            TiempoServ.Close()
            PantallaBlo.DESBLOQUEO = False
            PantallaBlo.Show()
        End If
    End Sub

    Private Sub ButtonNOTSKMNGR_Click(sender As System.Object, e As System.EventArgs) Handles ButtonNOTSKMNGR.Click
        Try
            Dim REGISTRADOR As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System")
            REGISTRADOR.SetValue("DisableTaskMgr", 1)
            MessageBox.Show("Administrador de tareas desactivado", "Control Ciber", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Control Ciber", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonSITSKMNGR_Click(sender As System.Object, e As System.EventArgs) Handles ButtonSITSKMNGR.Click
        Try
            Registry.CurrentUser.DeleteSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System")
            MessageBox.Show("Administrador de tareas activado", "Control Ciber", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Control Ciber", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonREGISTRAR_Click(sender As System.Object, e As System.EventArgs) Handles ButtonREGISTRAR.Click
        Try
            Dim REGISTRADOR As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", True)
            If REGISTRADOR Is Nothing Then
                Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run")
            End If
            REGISTRADOR.SetValue(Application.ProductName, Application.ExecutablePath, RegistryValueKind.String)
            MessageBox.Show("Registro en el inicio de Windows correcto", "Control Ciber", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Control Ciber", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonDESREGISTRAR_Click(sender As System.Object, e As System.EventArgs) Handles ButtonDESREGISTRAR.Click
        Try
            Dim REGISTRADOR As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", True)
            If REGISTRADOR IsNot Nothing Then
                REGISTRADOR.DeleteValue(Application.ProductName, False)
                MessageBox.Show("Registro en el inicio de Windows desactivado", "Control Ciber", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Control Ciber", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
        Me.Hide()
        PantallaBlo.Show()
    End Sub

    Private Sub btnSavePass_Click(sender As Object, e As EventArgs) Handles btnSavePass.Click
        My.Settings.adminPass = TextBoxCONTRASEÑA.Text
        My.Settings.Save()
    End Sub

    Private Sub btnGuardarPuerto_Click(sender As Object, e As EventArgs) Handles btnGuardarPuerto.Click
        My.Settings.puerto = TextBoxPUERTO.Text
        My.Settings.Save()
    End Sub

    Private Sub btnMensaje_Click(sender As Object, e As EventArgs) Handles btnMensaje.Click
        My.Settings.tiempoMensaje = NumMENSAJES.Value
        My.Settings.Save()
    End Sub

    Private Sub btnPreaviso_Click(sender As Object, e As EventArgs) Handles btnPreaviso.Click
        My.Settings.tiempoPreaviso = NumPREAVISO.Value
        My.Settings.Save()
    End Sub

    Private Sub mnuAbrir_Click(sender As Object, e As EventArgs) Handles mnuAbrir.Click
        If ingresarContrasena.ShowDialog() = DialogResult.OK Then
            Me.WindowState = FormWindowState.Normal
            Me.Show()
        Else
            MessageBox.Show("La contraseña del administrador no es correcta", "Control Ciber", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.WindowState = FormWindowState.Minimized
        Me.Hide()
    End Sub

    Private Sub btnNombreCiber_Click(sender As Object, e As EventArgs) Handles btnNombreCiber.Click
        My.Settings.nombreCiber = txtNombreCiber.Text
        My.Settings.Save()
    End Sub

    Private Sub btnServidor_Click(sender As Object, e As EventArgs) Handles btnServidor.Click
        My.Settings.ipServidor = txtServidor.Text
        My.Settings.Save()
    End Sub
End Class
