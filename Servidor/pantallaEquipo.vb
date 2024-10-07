Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading.Tasks
Imports System.Text
Public Class pantallaEquipo
    Private _ipAddress As String

    Dim CLIENTE As UdpClient
    Dim datosRecibidos As New List(Of Byte()) ' Lista para almacenar fragmentos recibidos
    Dim PUERTO_SERVIDOR As Integer = My.Settings.puerto ' Puerto en el que escucha el servidor
    Dim fragmentosRecibidos As New Dictionary(Of Integer, Byte())
    Dim totalFragments As Integer = -1

    ' Constructor que recibe la IP
    Public Sub New(ip As String)
        InitializeComponent() ' Inicializa los componentes
        _ipAddress = ip
    End Sub

    Private Sub pantallaEquipo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CLIENTE = New UdpClient(PUERTO_SERVIDOR)
        Task.Run(AddressOf EsperarCapturas)
    End Sub

    Private Sub EsperarCapturas()
        Dim ipEndPoint As New IPEndPoint(IPAddress.Any, PUERTO_SERVIDOR)
        While True
            Try
                ' Recibe los bytes de la imagen desde el cliente
                Dim datos As Byte() = CLIENTE.Receive(ipEndPoint)

                ' Obtener el número de fragmento
                Dim fragmentoNumero As String = Encoding.UTF8.GetString(datos.Take(5).ToArray()) ' Usar UTF8 en lugar de UTF7
                Dim fragmentoIndice As Integer = Integer.Parse(fragmentoNumero)
                Dim fragmentoDatos As Byte() = datos.Skip(5).ToArray()

                ' Almacenar el fragmento en el diccionario
                fragmentosRecibidos(fragmentoIndice) = fragmentoDatos

                ' Si tenemos todos los fragmentos, recomponer la imagen
                If fragmentosRecibidos.Count = totalFragments Then
                    Dim imagenCompleta As Byte() = UnirFragmentos(fragmentosRecibidos)
                    Dim captura As Bitmap = ConvertirBytesAImagen(imagenCompleta)

                    ' Actualiza el PictureBox con la imagen capturada
                    If captura IsNot Nothing Then
                        PictureBox1.Invoke(Sub()
                                               PictureBox1.Image = captura
                                           End Sub)
                    End If

                    ' Limpiar los fragmentos para la próxima captura
                    fragmentosRecibidos.Clear()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error en el servidor", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End While
    End Sub

    Private Function UnirFragmentos(fragmentos As Dictionary(Of Integer, Byte())) As Byte()
        Dim ms As New MemoryStream()
        For i As Integer = 0 To fragmentos.Count - 1
            ms.Write(fragmentos(i), 0, fragmentos(i).Length)
        Next
        Return ms.ToArray()
    End Function

    Private Function ConvertirBytesAImagen(datos As Byte()) As Bitmap
        Using ms As New MemoryStream(datos)
            Return New Bitmap(ms)
        End Using
    End Function
    Private Sub pantallaEquipo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

    End Sub

    Private Sub TimerRecibir_Tick(sender As Object, e As EventArgs) Handles TimerRecibir.Tick
        Try
            ' Recibir fragmento del cliente
            Dim ipEndPoint As New IPEndPoint(IPAddress.Any, 0)
            Dim dataRecibida As Byte() = CLIENTE.Receive(ipEndPoint)

            ' Extraer el prefijo (número de fragmento)
            Dim prefijo As String = Encoding.UTF8.GetString(dataRecibida.Take(5).ToArray())
            Dim numeroFragmento As Integer = Convert.ToInt32(prefijo)

            ' Guardar el fragmento en la lista de fragmentos recibidos
            Dim fragmentoDatos As Byte() = dataRecibida.Skip(5).ToArray() ' Saltar los primeros 5 bytes que son el prefijo
            If datosRecibidos.Count <= numeroFragmento Then
                datosRecibidos.AddRange(New Byte(numeroFragmento - datosRecibidos.Count)() {}) ' Asegurarse de que la lista tenga el tamaño correcto
            End If
            datosRecibidos(numeroFragmento) = fragmentoDatos

            ' Si todos los fragmentos han llegado, ensamblar la imagen
            If TodosLosFragmentosRecibidos() Then
                ' Ensamblar la imagen y mostrarla en el PictureBox
                Dim imagenBytes As Byte() = datosRecibidos.SelectMany(Function(b) b).ToArray() ' Unir todos los fragmentos
                MostrarImagen(imagenBytes)
                datosRecibidos.Clear() ' Limpiar la lista para la siguiente imagen
            End If

        Catch ex As Exception
            MessageBox.Show("Error al recibir fragmentos: " & ex.Message)
        End Try
    End Sub

    ' Verifica si todos los fragmentos han sido recibidos
    Private Function TodosLosFragmentosRecibidos() As Boolean
        Return datosRecibidos.All(Function(b) b IsNot Nothing)
    End Function

    ' Convertir el array de bytes a una imagen y mostrarla en el PictureBox
    Private Sub MostrarImagen(imagenBytes As Byte())
        Using ms As New MemoryStream(imagenBytes)
            Dim imagen As Image = Image.FromStream(ms)
            PictureBox1.Image = imagen
        End Using
    End Sub
End Class