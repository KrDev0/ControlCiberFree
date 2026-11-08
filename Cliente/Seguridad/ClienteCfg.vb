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
    Public BloquearAdministradorTareas As Boolean = False
    Public IniciarConWindows As Boolean = False
    Public SesionLocalActiva As Boolean = False
    Public SesionLocalInicio As DateTime = DateTime.MinValue
    Public SesionLocalFin As DateTime = DateTime.MinValue
    Public SesionLocalPausada As Boolean = False
    Public SesionLocalPausaDesde As DateTime = DateTime.MinValue
    Public PausarSiServidorDesconectado As Boolean = True
    Private _taskMgrBackupCapturado As Boolean = False
    Private _taskMgrBackupExiste As Boolean = False
    Private _taskMgrBackupValor As String = ""
    Private _taskMgrBackupTipo As Integer = -1
    Private _taskMgrBackup64Capturado As Boolean = False
    Private _taskMgrBackup64Existe As Boolean = False
    Private _taskMgrBackup64Valor As String = ""
    Private _taskMgrBackup64Tipo As Integer = -1

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
                    Case "bloqueartareas" : Boolean.TryParse(v, BloquearAdministradorTareas)
                    Case "iniciarconwindows" : Boolean.TryParse(v, IniciarConWindows)
                    Case "sesionactiva" : Boolean.TryParse(v, SesionLocalActiva)
                    Case "sesionpausada" : Boolean.TryParse(v, SesionLocalPausada)
                    Case "pausarsiservidordesconectado" : Boolean.TryParse(v, PausarSiServidorDesconectado)
                    Case "sesioninicio"
                        Dim q As DateTime
                        If DateTime.TryParseExact(v, "yyyy-MM-dd HH:mm:ss", Globalization.CultureInfo.InvariantCulture, Globalization.DateTimeStyles.None, q) Then SesionLocalInicio = q
                    Case "sesionfin"
                        Dim q As DateTime
                        If DateTime.TryParseExact(v, "yyyy-MM-dd HH:mm:ss", Globalization.CultureInfo.InvariantCulture, Globalization.DateTimeStyles.None, q) Then SesionLocalFin = q
                    Case "sesionpausadesde"
                        Dim q As DateTime
                        If DateTime.TryParseExact(v, "yyyy-MM-dd HH:mm:ss", Globalization.CultureInfo.InvariantCulture, Globalization.DateTimeStyles.None, q) Then SesionLocalPausaDesde = q
                    Case "taskmgrbackupcapturado" : Boolean.TryParse(v, _taskMgrBackupCapturado)
                    Case "taskmgrbackupexiste" : Boolean.TryParse(v, _taskMgrBackupExiste)
                    Case "taskmgrbackupvalor" : _taskMgrBackupValor = v
                    Case "taskmgrbackuptipo"
                        Dim q As Integer
                        If Integer.TryParse(v, q) Then _taskMgrBackupTipo = q
                    Case "taskmgrbackup64capturado" : Boolean.TryParse(v, _taskMgrBackup64Capturado)
                    Case "taskmgrbackup64existe" : Boolean.TryParse(v, _taskMgrBackup64Existe)
                    Case "taskmgrbackup64valor" : _taskMgrBackup64Valor = v
                    Case "taskmgrbackup64tipo"
                        Dim q As Integer
                        If Integer.TryParse(v, q) Then _taskMgrBackup64Tipo = q
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
            sb.AppendLine("bloqueartareas=" & BloquearAdministradorTareas.ToString())
            sb.AppendLine("iniciarconwindows=" & IniciarConWindows.ToString())
            sb.AppendLine("sesionactiva=" & SesionLocalActiva.ToString())
            sb.AppendLine("sesionpausada=" & SesionLocalPausada.ToString())
            sb.AppendLine("sesionpausadesde=" & If(SesionLocalPausaDesde = DateTime.MinValue, "0001-01-01 00:00:00", SesionLocalPausaDesde.ToString("yyyy-MM-dd HH:mm:ss", Globalization.CultureInfo.InvariantCulture)))
            sb.AppendLine("pausarsiservidordesconectado=" & PausarSiServidorDesconectado.ToString())
            sb.AppendLine("sesioninicio=" & If(SesionLocalInicio = DateTime.MinValue, "0001-01-01 00:00:00", SesionLocalInicio.ToString("yyyy-MM-dd HH:mm:ss", Globalization.CultureInfo.InvariantCulture)))
            sb.AppendLine("sesionfin=" & If(SesionLocalFin = DateTime.MinValue, "0001-01-01 00:00:00", SesionLocalFin.ToString("yyyy-MM-dd HH:mm:ss", Globalization.CultureInfo.InvariantCulture)))
            sb.AppendLine("taskmgrbackupcapturado=" & _taskMgrBackupCapturado.ToString())
            sb.AppendLine("taskmgrbackupexiste=" & _taskMgrBackupExiste.ToString())
            sb.AppendLine("taskmgrbackupvalor=" & _taskMgrBackupValor)
            sb.AppendLine("taskmgrbackuptipo=" & _taskMgrBackupTipo.ToString())
            sb.AppendLine("taskmgrbackup64capturado=" & _taskMgrBackup64Capturado.ToString())
            sb.AppendLine("taskmgrbackup64existe=" & _taskMgrBackup64Existe.ToString())
            sb.AppendLine("taskmgrbackup64valor=" & _taskMgrBackup64Valor)
            sb.AppendLine("taskmgrbackup64tipo=" & _taskMgrBackup64Tipo.ToString())
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

    Public Sub AplicarOpcionesWindows()
        AplicarInicioWindows()
        AplicarBloqueoTareas()
    End Sub

    Private Sub AplicarInicioWindows()
        Try
            Const nombre As String = "ControlCiberCliente"
            Using runKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Microsoft\Windows\CurrentVersion\Run")
                If IniciarConWindows Then
                    Dim rutaExe As String = ChrW(34) & Application.ExecutablePath & ChrW(34)
                    runKey.SetValue(nombre, rutaExe, Microsoft.Win32.RegistryValueKind.String)
                Else
                    runKey.DeleteValue(nombre, False)
                End If
            End Using
        Catch ex As Exception
            LogOpciones("inicio Windows error: " & ex.Message)
        End Try
    End Sub

    Private Sub AplicarBloqueoTareas()
        Const ruta As String = "Software\Microsoft\Windows\CurrentVersion\Policies\System"
        Const valor As String = "DisableTaskMgr"
        Try
            Dim vistaNativa As Microsoft.Win32.RegistryView = If(Environment.Is64BitOperatingSystem, Microsoft.Win32.RegistryView.Registry64, Microsoft.Win32.RegistryView.Default)
            Using baseNativa = Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, vistaNativa)
                Using policy = baseNativa.CreateSubKey(ruta)
                If BloquearAdministradorTareas Then
                    If Not _taskMgrBackupCapturado Then
                        Dim actual = policy.GetValue(valor, Nothing)
                        _taskMgrBackupExiste = actual IsNot Nothing
                        If _taskMgrBackupExiste Then
                            _taskMgrBackupValor = Convert.ToString(actual, Globalization.CultureInfo.InvariantCulture)
                            _taskMgrBackupTipo = CInt(policy.GetValueKind(valor))
                        Else
                            _taskMgrBackupValor = ""
                            _taskMgrBackupTipo = -1
                        End If
                        _taskMgrBackupCapturado = True
                    End If
                    If Environment.Is64BitOperatingSystem AndAlso Not _taskMgrBackup64Capturado Then
                        Dim actual64 = policy.GetValue(valor, Nothing)
                        If actual64 IsNot Nothing AndAlso Convert.ToString(actual64, Globalization.CultureInfo.InvariantCulture) = "1" AndAlso _taskMgrBackupCapturado Then
                            _taskMgrBackup64Existe = _taskMgrBackupExiste
                            _taskMgrBackup64Valor = _taskMgrBackupValor
                            _taskMgrBackup64Tipo = _taskMgrBackupTipo
                        Else
                            _taskMgrBackup64Existe = actual64 IsNot Nothing
                            If _taskMgrBackup64Existe Then
                                _taskMgrBackup64Valor = Convert.ToString(actual64, Globalization.CultureInfo.InvariantCulture)
                                _taskMgrBackup64Tipo = CInt(policy.GetValueKind(valor))
                            Else
                                _taskMgrBackup64Valor = ""
                                _taskMgrBackup64Tipo = -1
                            End If
                        End If
                        _taskMgrBackup64Capturado = True
                    End If
                    policy.SetValue(valor, 1, Microsoft.Win32.RegistryValueKind.DWord)
                    LogOpciones("administrador de tareas bloqueado")
                ElseIf _taskMgrBackupCapturado OrElse _taskMgrBackup64Capturado Then
                    Dim restaurarExiste As Boolean = If(vistaNativa = Microsoft.Win32.RegistryView.Registry64 AndAlso _taskMgrBackup64Capturado, _taskMgrBackup64Existe, _taskMgrBackupExiste)
                    Dim restaurarValor As String = If(vistaNativa = Microsoft.Win32.RegistryView.Registry64 AndAlso _taskMgrBackup64Capturado, _taskMgrBackup64Valor, _taskMgrBackupValor)
                    Dim restaurarTipo As Integer = If(vistaNativa = Microsoft.Win32.RegistryView.Registry64 AndAlso _taskMgrBackup64Capturado, _taskMgrBackup64Tipo, _taskMgrBackupTipo)
                    If restaurarExiste Then
                        Dim tipo As Microsoft.Win32.RegistryValueKind = CType(restaurarTipo, Microsoft.Win32.RegistryValueKind)
                        Dim original As Object = If(tipo = Microsoft.Win32.RegistryValueKind.DWord,
                            CType(Convert.ToInt32(restaurarValor, Globalization.CultureInfo.InvariantCulture), Object),
                            CType(restaurarValor, Object))
                        policy.SetValue(valor, original, tipo)
                    Else
                        policy.DeleteValue(valor, False)
                    End If
                    _taskMgrBackupCapturado = False
                    _taskMgrBackupExiste = False
                    _taskMgrBackupValor = ""
                    _taskMgrBackupTipo = -1
                    _taskMgrBackup64Capturado = False
                    _taskMgrBackup64Existe = False
                    _taskMgrBackup64Valor = ""
                    _taskMgrBackup64Tipo = -1
                    LogOpciones("administrador de tareas permitido")
                End If
                End Using
            End Using
            Guardar()
        Catch ex As Exception
            LogOpciones("administrador de tareas error: " & ex.Message)
        End Try
    End Sub

    Private Sub LogOpciones(texto As String)
        Try
            Dim p = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cliente.log")
            IO.File.AppendAllText(p, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & " " & texto & Environment.NewLine)
        Catch
        End Try
    End Sub
End Module
