Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Net.Sockets
Imports System.Text.Encoding
Imports System.Threading.Tasks

Public Class Main
    Dim ADMINISTRADOR As New UdpClient()
    Dim ORDENADOR As IPAddress

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        lblPuerto.Text = "Puerto: " + My.Settings.puerto.ToString
        obtenerOrdenador()
        verificarEquipoAsync()
    End Sub

    Private Sub obtenerOrdenador()
        ButtonAÑADIR.Enabled = False
        Try
            Select Case lblEquipo.Text
                Case "Equipo 1"
                    ORDENADOR = IPAddress.Parse(My.Settings.ipPC1)
                Case "Equipo 2"
                    ORDENADOR = IPAddress.Parse(My.Settings.ipPC2)
                Case "Equipo 3"
                    ORDENADOR = IPAddress.Parse(My.Settings.ipPC3)
                Case "Equipo 4"
                    ORDENADOR = IPAddress.Parse(My.Settings.ipPC4)
                Case "Equipo 5"
                    ORDENADOR = IPAddress.Parse(My.Settings.ipPC5)
                Case "Equipo 6"
                    ORDENADOR = IPAddress.Parse(My.Settings.ipPC6)
                Case "Equipo 7"
                    ORDENADOR = IPAddress.Parse(My.Settings.ipPC7)
                Case "Equipo 8"
                    ORDENADOR = IPAddress.Parse(My.Settings.ipPC8)
                Case "Equipo 9"
                    ORDENADOR = IPAddress.Parse(My.Settings.ipPC9)
                Case "Equipo 10"
                    ORDENADOR = IPAddress.Parse(My.Settings.ipPC10)
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Control Ciber", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        obtenerDatos()
    End Sub

    Private Sub obtenerDatos()
        Try
            Select Case lblEquipo.Text
                Case "Equipo 1"
                    lblIp.Text = "IP: " + My.Settings.ipPC1
                Case "Equipo 2"
                    lblIp.Text = "IP: " + My.Settings.ipPC2
                Case "Equipo 3"
                    lblIp.Text = "IP: " + My.Settings.ipPC3
                Case "Equipo 4"
                    lblIp.Text = "IP: " + My.Settings.ipPC4
                Case "Equipo 5"
                    lblIp.Text = "IP: " + My.Settings.ipPC5
                Case "Equipo 6"
                    lblIp.Text = "IP: " + My.Settings.ipPC6
                Case "Equipo 7"
                    lblIp.Text = "IP: " + My.Settings.ipPC7
                Case "Equipo 8"
                    lblIp.Text = "IP: " + My.Settings.ipPC8
                Case "Equipo 9"
                    lblIp.Text = "IP: " + My.Settings.ipPC9
                Case "Equipo 10"
                    lblIp.Text = "IP: " + My.Settings.ipPC10
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Control Ciber", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Dim ip As String
    Private Async Sub verificarEquipoAsync()
        Try
            ' Verificar si la variable ORDENADOR es Nothing
            If ORDENADOR Is Nothing Then
                lblEstado.Text = "Sin IP especificada"
                lblEstado.ForeColor = Color.Gray
                Return
            End If

            ' Convertir la IP a una cadena
            ip = ORDENADOR.ToString()

            ' Llamar al método asíncrono para hacer ping
            Dim estadoEquipo As Boolean = Await HacerPingAsync(ip)

            ' Actualizar el label de estado según el resultado del ping
            If estadoEquipo Then
                lblEstado.ForeColor = Color.Green
                lblEstado.Text = "En línea"
            Else
                lblEstado.ForeColor = Color.Red
                lblEstado.Text = "Sin conexión"
            End If

        Catch ex As Exception
            lblEstado.Text = "Error inesperado: " & ex.Message
            lblEstado.ForeColor = Color.Red
        End Try
    End Sub

    Private Async Function HacerPingAsync(ip As String) As Task(Of Boolean)
        Try
            ' Crear un objeto Ping para enviar la solicitud
            Dim ping As New Ping()

            ' Enviar el ping de manera asíncrona
            Dim reply As PingReply = Await ping.SendPingAsync(ip)

            ' Devolver true si el ping fue exitoso, false si no lo fue
            Return reply.Status = IPStatus.Success
        Catch ex As PingException
            ' Si falla el ping, capturar la excepción y devolver false
            Return False
        End Try
    End Function


    Private Sub ButtonINICIAR_Click(sender As System.Object, e As System.EventArgs) Handles ButtonINICIAR.Click
        Try
            ButtonAÑADIR.Enabled = True
            Dim IP As IPEndPoint = New IPEndPoint(ORDENADOR, My.Settings.puerto)
            Dim FRASE As String = "INICIAR:" & NumH1.Value & ":" & NumM1.Value
            Dim MENSAJE As Byte() = UTF7.GetBytes(FRASE)
            ADMINISTRADOR.Connect(IP)
            ADMINISTRADOR.Send(MENSAJE, MENSAJE.Length)
            NumH1.Value = 0
            NumM1.Value = 0
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Control Ciber", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonAÑADIR_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAÑADIR.Click
        Try
            Dim IP As IPEndPoint = New IPEndPoint(ORDENADOR, My.Settings.puerto)
            Dim FRASE As String = "AÑADIR:" & NumH1.Value & ":" & NumM1.Value
            Dim MENSAJE As Byte() = UTF7.GetBytes(FRASE)
            ADMINISTRADOR.Connect(IP)
            ADMINISTRADOR.Send(MENSAJE, MENSAJE.Length)
            NumH1.Value = 0
            NumM1.Value = 0
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Control Ciber", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TextBoxMENSAJES_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TextBoxMENSAJES1.KeyDown
        If e.KeyCode = Keys.F5 Then
            If TextBoxMENSAJES1.Text <> "" Then
                enviarMensaje()
            End If
        End If
    End Sub

    Private Sub ButtonBLOQUEO_Click(sender As System.Object, e As System.EventArgs) Handles ButtonBLOQUEO.Click
        If MessageBox.Show("Seguro que desea bloquear el equipo?", "Control Ciber", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = MsgBoxResult.Ok Then
            Try
                Dim IP As IPEndPoint = New IPEndPoint(ORDENADOR, My.Settings.puerto)
                Dim FRASE As String = "BLOQUEO:0:0"
                Dim MENSAJE As Byte() = UTF7.GetBytes(FRASE)
                ADMINISTRADOR.Connect(IP)
                ADMINISTRADOR.Send(MENSAJE, MENSAJE.Length)
                ButtonAÑADIR.Enabled = False
                btnDesbloquear.Enabled = True
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Control Ciber", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub ButtonREINICIAR_Click(sender As System.Object, e As System.EventArgs) Handles ButtonREINICIAR.Click
        If MessageBox.Show("Seguro que desea reiniciar el equipo?", "Control Ciber", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = MsgBoxResult.Ok Then
            Try
                Dim IP As IPEndPoint = New IPEndPoint(ORDENADOR, My.Settings.puerto)
                Dim FRASE As String = "REINICIAR:0:0"
                Dim MENSAJE As Byte() = UTF7.GetBytes(FRASE)
                ADMINISTRADOR.Connect(IP)
                ADMINISTRADOR.Send(MENSAJE, MENSAJE.Length)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Control Ciber", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub ButtonAPAGAR_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAPAGAR.Click
        If MessageBox.Show("Seguro que desea apagar el equipo?", "Control Ciber", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = MsgBoxResult.Ok Then
            Try
                Dim IP As IPEndPoint = New IPEndPoint(ORDENADOR, My.Settings.puerto)
                Dim FRASE As String = "APAGAR:0:0"
                Dim MENSAJE As Byte() = UTF7.GetBytes(FRASE)
                ADMINISTRADOR.Connect(IP)
                ADMINISTRADOR.Send(MENSAJE, MENSAJE.Length)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Control Ciber", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub


    Private Sub btnEnviarMensaje_Click(sender As Object, e As EventArgs) Handles btnEnviarMensaje.Click
        If TextBoxMENSAJES1.Text <> "" Then
            enviarMensaje()
        End If
    End Sub
    Private Sub enviarMensaje()
        Try
            Dim IP As IPEndPoint = New IPEndPoint(ORDENADOR, My.Settings.puerto)
            Dim FRASE As String = "MENSAJE:" & TextBoxMENSAJES1.Text & ":0"
            Dim MENSAJE As Byte() = UTF7.GetBytes(FRASE)
            ADMINISTRADOR.Connect(IP)
            ADMINISTRADOR.Send(MENSAJE, MENSAJE.Length)
            TextBoxMENSAJES1.Clear()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Control Ciber", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBloquear_Click(sender As Object, e As EventArgs) Handles btnBloquear.Click
        Try
            Dim IP As IPEndPoint = New IPEndPoint(ORDENADOR, My.Settings.puerto)
            Dim FRASE As String = "BLOQUEARPC:0:0"
            Dim MENSAJE As Byte() = UTF7.GetBytes(FRASE)
            ADMINISTRADOR.Connect(IP)
            ADMINISTRADOR.Send(MENSAJE, MENSAJE.Length)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Control Ciber", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDesbloquear_Click(sender As Object, e As EventArgs) Handles btnDesbloquear.Click
        Try
            Dim IP As IPEndPoint = New IPEndPoint(ORDENADOR, My.Settings.puerto)
            Dim FRASE As String = "DESBLOQUEAR:0:0"
            Dim MENSAJE As Byte() = UTF7.GetBytes(FRASE)
            ADMINISTRADOR.Connect(IP)
            ADMINISTRADOR.Send(MENSAJE, MENSAJE.Length)
            btnDesbloquear.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Control Ciber", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnConectar_Click(sender As Object, e As EventArgs) Handles btnConectar.Click
        verificarEquipoAsync()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        verificarEquipoAsync()
    End Sub

    Private Sub picPantalla_Click(sender As Object, e As EventArgs) 
        Dim formPantalla As New pantallaEquipo(ORDENADOR.ToString)
        formPantalla.Show()
    End Sub
End Class
