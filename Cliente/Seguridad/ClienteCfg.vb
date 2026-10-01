''' <summary>
''' Configuración del cliente: vive en cliente.cfg CIFRADO junto al exe.
''' La recibe del servidor (comando SETCFG) o usa valores por defecto.
''' Ya no hay formulario de configuración en el cliente.
''' </summary>
Public Module ClienteCfg
    Public Puerto As Integer = 55555
    Public IpServidor As String = ""
    Public NombreCiber As String = "Nombre ciber"
    Public TiempoMensaje As Integer = 5
    Public TiempoPreaviso As Integer = 5
    ' Hash SHA256 de la clave de admin. Vacío = clave inicial "102250".
    Public AdminHash As String = ""
    ' Video: ancho de captura y calidad JPEG (los pide el visor con CALIDAD).
    Public VideoW As Integer = 960
    Public VideoQ As Integer = 50

    Private Function Ruta() As String
        Return IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cliente.cfg")
    End Function

    Public Sub Cargar()
        Try
            ' Respaldo inicial desde My.Settings (instalaciones anteriores).
            Dim p As Integer
            If Integer.TryParse(If(My.Settings.puerto, "").ToString(), p) AndAlso p > 0 AndAlso p <= 65535 Then Puerto = p
            If Not String.IsNullOrWhiteSpace(My.Settings.ipServidor) Then IpServidor = My.Settings.ipServidor.Trim()
            If Not String.IsNullOrWhiteSpace(My.Settings.nombreCiber) Then NombreCiber = My.Settings.nombreCiber
            If My.Settings.tiempoMensaje > 0 Then TiempoMensaje = My.Settings.tiempoMensaje
            If My.Settings.tiempoPreaviso > 0 Then TiempoPreaviso = My.Settings.tiempoPreaviso
            If Not String.IsNullOrWhiteSpace(My.Settings.adminPass) Then
                Dim s As String = My.Settings.adminPass
                AdminHash = If(s.Length = 64, s.ToLowerInvariant(), Crypto.HashPass(s))
            End If
        Catch
        End Try
        Try
            If Not IO.File.Exists(Ruta()) Then Return
            Dim plano As String = Crypto.Descifrar(IO.File.ReadAllText(Ruta()).Trim())
            If String.IsNullOrEmpty(plano) Then Return ' manipulado o ilegible: se ignora
            For Each ln As String In plano.Split(New String() {vbCrLf, vbLf}, StringSplitOptions.RemoveEmptyEntries)
                Dim i As Integer = ln.IndexOf("="c)
                If i <= 0 Then Continue For
                Dim k As String = ln.Substring(0, i).Trim().ToLowerInvariant()
                Dim v As String = ln.Substring(i + 1).Trim()
                Select Case k
                    Case "puerto"
                        Dim q As Integer
                        If Integer.TryParse(v, q) AndAlso q > 0 AndAlso q <= 65535 Then Puerto = q
                    Case "servidor" : IpServidor = v
                    Case "ciber" : If v <> "" Then NombreCiber = v
                    Case "tmsg"
                        Dim q As Integer
                        If Integer.TryParse(v, q) AndAlso q > 0 Then TiempoMensaje = q
                    Case "tpre"
                        Dim q As Integer
                        If Integer.TryParse(v, q) AndAlso q > 0 Then TiempoPreaviso = q
                    Case "pass" : If v <> "" Then AdminHash = v.ToLowerInvariant()
                    Case "videow"
                        Dim q As Integer
                        If Integer.TryParse(v, q) AndAlso q >= 320 AndAlso q <= 1920 Then VideoW = q
                    Case "videoq"
                        Dim q As Integer
                        If Integer.TryParse(v, q) AndAlso q >= 30 AndAlso q <= 85 Then VideoQ = q
                End Select
            Next
        Catch
        End Try
    End Sub

    Public Sub Guardar()
        Try
            Dim sb As New Text.StringBuilder()
            sb.AppendLine("puerto=" & Puerto.ToString())
            sb.AppendLine("servidor=" & IpServidor)
            sb.AppendLine("ciber=" & NombreCiber)
            sb.AppendLine("tmsg=" & TiempoMensaje.ToString())
            sb.AppendLine("tpre=" & TiempoPreaviso.ToString())
            sb.AppendLine("pass=" & AdminHash)
            sb.AppendLine("videow=" & VideoW.ToString())
            sb.AppendLine("videoq=" & VideoQ.ToString())
            IO.File.WriteAllText(Ruta(), Crypto.Cifrar(sb.ToString()))
        Catch
        End Try
    End Sub

    ''' <summary>Hash vigente (o el de la clave inicial).</summary>
    Public Function ClaveAdmin() As String
        If String.IsNullOrEmpty(AdminHash) Then Return Crypto.HashPass("102250")
        Return AdminHash
    End Function

    Public Function PassOk(input As String) As Boolean
        Return Crypto.PassOk(input, ClaveAdmin())
    End Function
End Module
