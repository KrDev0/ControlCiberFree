Imports System.IO

''' <summary>
''' Visor de pantalla en vivo: se suscribe al ScreenHub compartido por IP.
''' Muestra estado de señal para diagnosticar (IP servidor / puerto / firewall).
''' </summary>
Public Class pantallaEquipo
    Private ReadOnly _ipAddress As String
    Private _lastFrame As DateTime = DateTime.MinValue
    Private _frames As Integer = 0
    Private _tick As New Queue(Of DateTime)()
    Private _imgW As Integer = 0
    Private _imgH As Integer = 0
    Private _cargando As Boolean = True
    Private WithEvents tWatch As New Timer()

    Public Sub New(ip As String)
        InitializeComponent()
        _ipAddress = ip.Trim()
        Me.Text = "Pantalla en vivo - " & _ipAddress
    End Sub

    Private Sub pantallaEquipo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath)
        Catch
        End Try
        TimerRecibir.Enabled = False
        lblStatus.Text = "Conectando con " & _ipAddress & "..."
        Try
            If cboCalidad.Items.Count > 1 Then cboCalidad.SelectedIndex = 1 ' Media 960
        Catch
        End Try
        _cargando = False
        Try
            ScreenHub.Ensure(Servidor.Data.Db.Puerto())
            ScreenHub.Subscribe(_ipAddress, AddressOf OnFrame)
        Catch ex As Exception
            lblStatus.Text = "No se pudo escuchar el puerto: " & ex.Message
            Return
        End Try
        tWatch.Interval = 2000
        tWatch.Start()
    End Sub

    Private Sub OnFrame(jpeg As Byte())
        Try
            If Me.IsDisposed Then Return
            Me.Invoke(Sub()
                          Try
                              Using ms As New MemoryStream(jpeg)
                                  Using img As Image = Image.FromStream(ms)
                                      Dim bmp As New Bitmap(img)
                                      _imgW = bmp.Width : _imgH = bmp.Height
                                      Dim old = PictureBox1.Image
                                      PictureBox1.Image = bmp
                                      If old IsNot Nothing Then old.Dispose()
                                  End Using
                              End Using
                              _frames += 1
                              _lastFrame = DateTime.Now
                              _tick.Enqueue(_lastFrame)
                              While _tick.Count > 0 AndAlso (DateTime.Now - _tick.Peek()).TotalSeconds > 10
                                  _tick.Dequeue()
                              End While
                              Dim fps As Double = 0
                              If _tick.Count >= 2 Then
                                  Dim span As Double = (_tick.Last() - _tick.First()).TotalSeconds
                                  If span > 0 Then fps = (_tick.Count - 1) / span
                              End If
                              lblStatus.Text = "En vivo · " & _ipAddress & " · " &
                                  _imgW.ToString() & "x" & _imgH.ToString() & " · " &
                                  fps.ToString("0.0") & " fps · " & _lastFrame.ToLongTimeString()
                          Catch
                          End Try
                      End Sub)
        Catch
        End Try
    End Sub

    Private Sub cboCalidad_SelectedIndexChanged(s As Object, e As EventArgs) Handles cboCalidad.SelectedIndexChanged
        If _cargando Then Return
        Try
            Dim w As Integer = 960, q As Integer = 50
            Select Case cboCalidad.SelectedIndex
                Case 0 : w = 640 : q = 45
                Case 1 : w = 960 : q = 50
                Case 2 : w = 1280 : q = 55
                Case 3 : w = 1600 : q = 60
            End Select
            NetProtocol.SendUdp(_ipAddress, Servidor.Data.Db.Puerto(), "CALIDAD", w.ToString(), q.ToString())
        Catch
        End Try
    End Sub

    Private Sub tWatch_Tick(sender As Object, e As EventArgs) Handles tWatch.Tick
        Try
            Dim puerto = Servidor.Data.Db.Puerto()
            If _frames = 0 Then
                ' Re-pedir video hasta que llegue el primer cuadro (UDP puede perder el primero).
                Try
                    NetProtocol.SendUdp(_ipAddress, puerto, "VER", "0", "0")
                Catch
                End Try
                Dim n = ScreenHub.Remitentes().Count
                lblStatus.Text = "Sin señal de " & _ipAddress & " (puerto " & puerto.ToString() &
                    ", remitentes vistos: " & n.ToString() &
                    "). En el cliente: IP del servidor, mismo puerto, Cliente.exe nuevo y firewall."
            ElseIf (DateTime.Now - _lastFrame).TotalSeconds > 12 Then
                lblStatus.Text = "Señal perdida (último cuadro " & _lastFrame.ToLongTimeString() & "). Revisa la red del cliente."
            End If
        Catch
        End Try
    End Sub

    Private Sub pantallaEquipo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try : tWatch.Stop() : Catch : End Try
        Try : ScreenHub.Unsubscribe(_ipAddress) : Catch : End Try
    End Sub
End Class
