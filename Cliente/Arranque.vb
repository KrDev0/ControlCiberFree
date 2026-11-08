''' <summary>
''' Arranque del cliente: sin formularios de configuración.
''' Carga cliente.cfg cifrado, inicia el motor y entra al bucle de mensajes.
''' </summary>
Public Module Arranque
    <STAThread()>
    Public Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        ClienteCfg.Cargar()
        ClienteCfg.AplicarOpcionesWindows()
        Dim motor As New MotorCliente()
        MotorCliente.Instancia = motor
        motor.Iniciar()
        Application.Run()
    End Sub
End Module
