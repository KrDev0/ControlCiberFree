Imports System.IO
Imports System.Text

''' <summary>
''' Comprueba nuevas versiones contra el repo público de updaters.
''' Convención: https://raw.githubusercontent.com/KrDev0/updaters/refs/heads/main/ciber/ciber.json
''' con {"version":"3.2","notas":"..."} (el dueño lo mantiene en GitHub).
''' </summary>
Public Module Actualizador
    ' Versión de esta compilación (la fija el dueño).
    Public Const VERSION_ACTUAL As String = "3.1"
    Public Const URL_VERSION As String = "https://raw.githubusercontent.com/KrDev0/updaters/refs/heads/main/ciber/ciber.json"
    Public Const URL_DESCARGA As String = "https://kr-dev.site/?app=ciber"

    Public Structure InfoVersion
        Public HayNueva As Boolean
        Public Version As String
        Public Notas As String
        Public ErrorMsg As String
    End Structure

    Public Function Comprobar() As InfoVersion
        Dim r As New InfoVersion()
        Try
            Dim req = DirectCast(Net.WebRequest.Create(URL_VERSION), Net.HttpWebRequest)
            req.Timeout = 8000
            req.UserAgent = "ControlCiber-Updater"
            Using resp = DirectCast(req.GetResponse(), Net.HttpWebResponse)
                Using sr = New StreamReader(resp.GetResponseStream(), Encoding.UTF8)
                    Dim json As String = sr.ReadToEnd()
                    r.Version = Extraer(json, "version")
                    r.Notas = Extraer(json, "notas")
                End Using
            End Using
            If String.IsNullOrWhiteSpace(r.Version) Then
                r.ErrorMsg = "El archivo de versión no trae un campo version válido."
                Return r
            End If
            r.HayNueva = EsMayor(r.Version, VERSION_ACTUAL)
        Catch ex As Exception
            r.ErrorMsg = "No se pudo comprobar (revisa tu conexión): " & ex.Message
        End Try
        Return r
    End Function

    Private Function Extraer(json As String, campo As String) As String
        Try
            Dim i As Integer = json.IndexOf("""" & campo & """", StringComparison.OrdinalIgnoreCase)
            If i < 0 Then Return ""
            i = json.IndexOf(":", i)
            If i < 0 Then Return ""
            Dim q1 As Integer = json.IndexOf("""", i)
            If q1 < 0 Then Return ""
            Dim q2 As Integer = json.IndexOf("""", q1 + 1)
            If q2 < 0 Then Return ""
            Return json.Substring(q1 + 1, q2 - q1 - 1).Trim()
        Catch
            Return ""
        End Try
    End Function

    ''' <summary>True si remota > local comparando partes numéricas.</summary>
    Public Function EsMayor(remota As String, local As String) As Boolean
        Try
            Dim a = remota.Trim().Split("."c)
            Dim b = local.Trim().Split("."c)
            For i As Integer = 0 To Math.Max(a.Length, b.Length) - 1
                Dim x, y As Integer
                Integer.TryParse(If(i < a.Length, a(i), "0"), x)
                Integer.TryParse(If(i < b.Length, b(i), "0"), y)
                If x <> y Then Return x > y
            Next
        Catch
        End Try
        Return False
    End Function
End Module
