Imports System.Net

''' <summary>
''' Tarjeta de control por equipo (editable desde el diseñador).
''' Todos los botones envían comandos UDP reales.
''' </summary>
Public Class EquipoCard
    Inherits UserControl

    Public Property NombreEquipo As String = ""
    Private _ip As String = ""

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        Try
            Theme.StyleButton(btnIniciar, Theme.Success)
            Theme.StyleButton(btnAnadir, Theme.Primary)
            Theme.StyleButton(btnBloq, Theme.Warn)
            Theme.StyleButton(btnDesbloq, Theme.Success)
            Theme.StyleButton(btnVer, Theme.Dark)
            Theme.StyleButton(btnMsg, Theme.Primary)
            Theme.StyleButton(btnWin, Theme.Muted)
            Theme.StyleButton(btnRei, Theme.Muted)
            Theme.StyleButton(btnApa, Theme.Danger)
        Catch
        End Try
    End Sub

    Public Sub LoadData(nombre As String, ip As String)
        NombreEquipo = nombre
        _ip = If(ip, "")
        lblNombre.Text = nombre
        If String.IsNullOrWhiteSpace(_ip) Then
            lblIp.Text = "Sin IP asignada: ve a Red y equipos"
        Else
            lblIp.Text = _ip & " · puerto " & Servidor.Data.Db.Puerto().ToString()
        End If
        SetOnline(Nothing)
    End Sub

    ''' <summary>Nothing=desconocido, True=en línea, False=sin conexión.</summary>
    Public Sub SetOnline(online As Nullable(Of Boolean))
        If Not online.HasValue Then
            lblEstado.Text = "● ..."
            header.BackColor = Theme.Muted
        ElseIf online.Value Then
            lblEstado.Text = "● En línea"
            header.BackColor = Theme.Success
        Else
            lblEstado.Text = "● Sin conexión"
            header.BackColor = Theme.Danger
        End If
    End Sub

    Private Function IpOk() As Boolean
        Dim a As IPAddress = Nothing
        If String.IsNullOrWhiteSpace(_ip) OrElse Not IPAddress.TryParse(_ip.Trim(), a) Then
            MessageBox.Show(NombreEquipo & " no tiene IP válida. Asígnala en Red y equipos.",
                            "Control Ciber", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        _ip = a.ToString()
        Return True
    End Function

    Private Sub Enviar(cmd As String, p1 As String, p2 As String)
        If Not IpOk() Then Return
        Try
            NetProtocol.SendUdp(_ip, Servidor.Data.Db.Puerto(), cmd, p1, p2)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Control Ciber", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub OnIniciar(s As Object, e As EventArgs) Handles btnIniciar.Click
        btnAnadir.Enabled = True
        btnDesbloq.Enabled = False
        Enviar("INICIAR", numH.Value.ToString(), numM.Value.ToString())
        Servidor.Data.Db.RegistrarSesion(NombreEquipo, CInt(numH.Value) * 60 + CInt(numM.Value))
        numH.Value = 0 : numM.Value = 0
    End Sub

    Private Sub OnAnadir(s As Object, e As EventArgs) Handles btnAnadir.Click
        Enviar("AÑADIR", numH.Value.ToString(), numM.Value.ToString())
        numH.Value = 0 : numM.Value = 0
    End Sub

    Private Sub OnBloq(s As Object, e As EventArgs) Handles btnBloq.Click
        If MessageBox.Show("¿Bloquear " & NombreEquipo & "?", "Control Ciber",
                           MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
            Enviar("BLOQUEO", "0", "0")
            btnAnadir.Enabled = False
            btnDesbloq.Enabled = True
        End If
    End Sub

    Private Sub OnDesbloq(s As Object, e As EventArgs) Handles btnDesbloq.Click
        Enviar("DESBLOQUEAR", "0", "0")
        btnDesbloq.Enabled = False
    End Sub

    Private Sub OnMsgKey(s As Object, e As KeyEventArgs) Handles txtMsg.KeyDown
        If e.KeyCode = Keys.Enter AndAlso txtMsg.Text <> "" Then OnMsg(Nothing, Nothing)
    End Sub

    Private Sub OnMsg(s As Object, e As EventArgs) Handles btnMsg.Click
        If txtMsg.Text.Trim() = "" Then Return
        Enviar("MENSAJE", txtMsg.Text.Trim(), "0")
        txtMsg.Clear()
    End Sub

    Private Sub OnVer(s As Object, e As EventArgs) Handles btnVer.Click
        If Not IpOk() Then Return
        ' Pide al cliente un cuadro inmediato y abre el visor en vivo.
        Enviar("VER", "0", "0")
        Dim f As New pantallaEquipo(_ip)
        f.Show()
    End Sub

    Private Sub OnWin(s As Object, e As EventArgs) Handles btnWin.Click
        Enviar("BLOQUEARPC", "0", "0")
    End Sub

    Private Sub OnRei(s As Object, e As EventArgs) Handles btnRei.Click
        If MessageBox.Show("¿Reiniciar " & NombreEquipo & "?", "Control Ciber",
                           MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
            Enviar("REINICIAR", "0", "0")
        End If
    End Sub

    Private Sub OnApa(s As Object, e As EventArgs) Handles btnApa.Click
        If MessageBox.Show("¿Apagar " & NombreEquipo & "?", "Control Ciber",
                           MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
            Enviar("APAGAR", "0", "0")
        End If
    End Sub
End Class
