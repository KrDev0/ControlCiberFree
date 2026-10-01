Imports System.Net
Imports System.Net.Sockets
Imports System.Text

''' <summary>
''' Protocolo UDP unificado. Mensajes "COMANDO:parte1:parte2" en UTF8.
''' El Split se limita a 3 partes para permitir ':' dentro del texto del mensaje.
''' </summary>
Public Module NetProtocol
    Public Const SEP As Char = ":"c

    Public Function BuildMessage(comando As String, p1 As String, p2 As String) As Byte()
        Return Encoding.UTF8.GetBytes(comando & SEP & p1 & SEP & p2)
    End Function

    Public Function ParseMessage(raw As Byte()) As String()
        Dim s As String = Encoding.UTF8.GetString(raw)
        Return s.Split(New Char() {SEP}, 3)
    End Function

    Public Sub SendUdp(ip As String, puerto As Integer, comando As String, p1 As String, p2 As String)
        Dim ep As New IPEndPoint(IPAddress.Parse(ip), puerto)
        Using cli As New UdpClient()
            Dim data As Byte() = BuildMessage(comando, p1, p2)
            cli.Connect(ep)
            cli.Send(data, data.Length)
        End Using
    End Sub
End Module
