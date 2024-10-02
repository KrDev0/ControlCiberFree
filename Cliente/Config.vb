﻿Imports System.Net.Sockets
Imports System.Net
Imports System.Text.Encoding
Imports Microsoft.Win32

Public Class Config

    Dim ORDENADOR As UdpClient
    Dim MIARRAY As ArrayList
    Dim HORAINICIO As DateTime
    Dim HORALIMITE As DateTime
    Dim AVISADO As Boolean = False

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ORDENADOR = New UdpClient(CInt(TextBoxPUERTO.Text))
        ORDENADOR.Client.Blocking = False
        Timer1.Interval = 10
        Timer1.Start()
        PantallaBlo.DESBLOQUEO = False
        PantallaBlo.Show()
    End Sub

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
            Case "PantallaBlo"
                TimerMINUTOS.Stop()
                TiempoServ.Close()
                Mensaje.Close()
                PantallaBlo.DESBLOQUEO = False
                PantallaBlo.Show()
            Case "MENSAJE"
                Mensaje.TextBoxMENSAJES.Text = MIARRAY(1)
                Mensaje.Show()
            Case "CERRAR"
                CERRAR()
            Case "REINICIAR"
                CERRAR()
                Process.Start("shutdown", "/r /f")
            Case "APAGAR"
                CERRAR()
                Process.Start("shutdown", "/s /t 0 /f")
        End Select
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
            MsgBox("TASKMGR DESACTIVADO")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ButtonSITSKMNGR_Click(sender As System.Object, e As System.EventArgs) Handles ButtonSITSKMNGR.Click
        Try
            Registry.CurrentUser.DeleteSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System")
            MsgBox("TASKMGR REACTIVADO")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ButtonREGISTRAR_Click(sender As System.Object, e As System.EventArgs) Handles ButtonREGISTRAR.Click
        Try
            Dim REGISTRADOR As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", True)
            If REGISTRADOR Is Nothing Then
                Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run")
            End If
            REGISTRADOR.SetValue(Application.ProductName, Application.ExecutablePath, RegistryValueKind.String)
            MsgBox("REGISTRADO")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ButtonDESREGISTRAR_Click(sender As System.Object, e As System.EventArgs) Handles ButtonDESREGISTRAR.Click
        Try
            Dim REGISTRADOR As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", True)
            If REGISTRADOR IsNot Nothing Then
                REGISTRADOR.DeleteValue(Application.ProductName, False)
                MsgBox("BORRADO")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub CERRAR()
        TiempoServ.Close()
        Mensaje.Close()
        PantallaBlo.DESBLOQUEO = True
        PantallaBlo.Close()
        Me.Close()
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
        Me.Hide()
        PantallaBlo.Show()
    End Sub
End Class
