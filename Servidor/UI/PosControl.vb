''' <summary>
''' Punto de venta embebido en el Dashboard (editable desde el diseñador).
''' Estilo del sistema: cabeceras oscuras, botones planos.
''' </summary>
Public Class PosControl
    Inherits UserControl

    Private _carrito As New DataTable()
    Private _lblTarifa As Label
    Private _nudTarifa As NumericUpDown
    Private _dgvPendientes As DataGridView
    Private _splitTicket As SplitContainer
    Public Event EquipoLiquidado(equipo As String)

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        CrearVistaCargosPendientes()
        CrearControlTarifa()
        Try
            Theme.StyleButton(btnAgregar, Theme.Primary)
            Theme.StyleButton(btnQuitar, Theme.Danger)
            Theme.StyleButton(btnLimpiar, Theme.Muted)
            Theme.StyleButton(btnCobrar, Theme.Success)
            Theme.StyleGrid(dgvCat)
            Theme.StyleGrid(dgvCar)
            Theme.StyleGrid(_dgvPendientes)
        Catch
        End Try
    End Sub

    Private Sub CrearVistaCargosPendientes()
        _splitTicket = New SplitContainer()
        _splitTicket.Dock = DockStyle.Fill
        _splitTicket.Orientation = Orientation.Horizontal
        _splitTicket.SplitterDistance = 145
        _splitTicket.Panel1MinSize = 75
        _splitTicket.Panel2MinSize = 100
        _dgvPendientes = New DataGridView()
        _dgvPendientes.Dock = DockStyle.Fill
        _dgvPendientes.ReadOnly = True
        _dgvPendientes.AllowUserToAddRows = False
        _dgvPendientes.AllowUserToDeleteRows = False
        _dgvPendientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        _dgvPendientes.RowHeadersVisible = False
        _dgvPendientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        g2.Controls.Remove(dgvCar)
        _splitTicket.Panel1.Controls.Add(_dgvPendientes)
        _splitTicket.Panel2.Controls.Add(dgvCar)
        g2.Controls.Add(_splitTicket)
    End Sub

    Public Sub Refrescar()
        Try
            cboPago.Items.Clear()
            cboPago.Items.AddRange(New String() {"Efectivo", "Tarjeta", "Transferencia"})
            cboPago.SelectedIndex = 0
            cboEquipo.Items.Clear()
            cboEquipo.Items.Add("Mostrador")
            For Each r As DataRow In Servidor.Data.Db.ListarEquipos().Rows
                cboEquipo.Items.Add(CStr(r("Nombre")))
            Next
            cboEquipo.SelectedIndex = 0
            Dim tarifa As Decimal
            Dim tarifaGuardada As String = Servidor.Data.Db.GetConfig("tarifaHora", "")
            If Not Decimal.TryParse(tarifaGuardada, Globalization.NumberStyles.Any, Globalization.CultureInfo.InvariantCulture, tarifa) Then
                Decimal.TryParse(Servidor.Data.Db.GetConfig("tarifaMinuto", "0"), Globalization.NumberStyles.Any, Globalization.CultureInfo.InvariantCulture, tarifa)
                tarifa *= 60D
            End If
            _nudTarifa.Value = Math.Max(_nudTarifa.Minimum, Math.Min(_nudTarifa.Maximum, tarifa))
        Catch
        End Try
        If _carrito.Columns.Count = 0 Then
            _carrito.Columns.Add("Id", GetType(Integer))
            _carrito.Columns.Add("Nombre", GetType(String))
            _carrito.Columns.Add("Cant", GetType(Integer))
            _carrito.Columns.Add("Precio", GetType(Decimal))
            _carrito.Columns.Add("Subtotal", GetType(Decimal))
            dgvCar.DataSource = _carrito
        End If
        CargarCatalogo()
        ActualizarTotal()
        ActualizarModoEquipo()
    End Sub

    Public Sub PrepararCobroEquipo(equipo As String)
        If cboEquipo.Items.Count = 0 Then Refrescar()
        If cboEquipo.Items.Contains(equipo) Then cboEquipo.SelectedItem = equipo
        ActualizarModoEquipo()
        ActualizarTotal()
    End Sub

    Private Sub CrearControlTarifa()
        _lblTarifa = New Label()
        _lblTarifa.AutoSize = True
        _lblTarifa.Text = "Tarifa/hora: $"
        _lblTarifa.Location = New Point(380, 18)
        _lblTarifa.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
        _lblTarifa.ForeColor = Theme.Dark
        _nudTarifa = New NumericUpDown()
        _nudTarifa.DecimalPlaces = 2
        _nudTarifa.Increment = 0.05D
        _nudTarifa.Maximum = 1000D
        _nudTarifa.Minimum = 0D
        _nudTarifa.Location = New Point(470, 16)
        _nudTarifa.Size = New Size(90, 24)
        _nudTarifa.ThousandsSeparator = True
        AddHandler _nudTarifa.ValueChanged, AddressOf TarifaCambiada
        topBar.Controls.Add(_lblTarifa)
        topBar.Controls.Add(_nudTarifa)
    End Sub

    Private Sub TarifaCambiada(sender As Object, e As EventArgs)
        Try
            Servidor.Data.Db.SetConfig("tarifaHora", _nudTarifa.Value.ToString(Globalization.CultureInfo.InvariantCulture))
            ActualizarTotal()
            ActualizarModoEquipo()
        Catch
        End Try
    End Sub

    Private Sub cboEquipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEquipo.SelectedIndexChanged
        ActualizarModoEquipo()
        ActualizarTotal()
    End Sub

    Private Function EquipoActual() As String
        If cboEquipo.SelectedItem Is Nothing Then Return "Mostrador"
        Return CStr(cboEquipo.SelectedItem)
    End Function

    Private Sub ActualizarModoEquipo()
        Dim equipo = EquipoActual()
        Dim esEquipo As Boolean = equipo <> "Mostrador"
        If _dgvPendientes IsNot Nothing Then _dgvPendientes.Visible = esEquipo
        If _splitTicket IsNot Nothing Then _splitTicket.Panel1Collapsed = Not esEquipo
        CargarCargosPendientes()
        lP.Visible = True
        cboPago.Visible = True
        If esEquipo Then
            Try
                Dim pendientes = Servidor.Data.Db.TotalCargosPendientes(equipo)
                btnCobrar.Text = If(_carrito.Rows.Count > 0, "Cargar a cuenta", "Cobrar cuenta")
                btnCobrar.Enabled = _carrito.Rows.Count > 0 OrElse pendientes > 0D OrElse TieneTiempoPendiente(equipo)
                g2.Text = "Cuenta · " & equipo
            Catch
                btnCobrar.Text = If(_carrito.Rows.Count > 0, "Cargar a cuenta", "Cobrar cuenta")
                btnCobrar.Enabled = _carrito.Rows.Count > 0
                g2.Text = "Cuenta · " & equipo
            End Try
        Else
            btnCobrar.Text = "Cobrar"
            btnCobrar.Enabled = _carrito.Rows.Count > 0
            g2.Text = "Ticket actual"
        End If
    End Sub

    Private Sub CargarCargosPendientes()
        If _dgvPendientes Is Nothing Then Return
        Try
            If EquipoActual() = "Mostrador" Then
                _dgvPendientes.DataSource = Nothing
                Return
            End If
            Dim dt = Servidor.Data.Db.CargosPendientesEquipo(EquipoActual())
            Dim minutos As Integer = MinutosSesion(EquipoActual())
            If minutos > 0 Then
                Dim importeTiempo As Decimal = Math.Round(minutos * _nudTarifa.Value / 60D, 2)
                Dim filaTiempo As DataRow = dt.NewRow()
                filaTiempo("Id") = -1
                filaTiempo("Nombre") = "Uso de PC"
                filaTiempo("Cantidad") = minutos
                filaTiempo("Precio") = _nudTarifa.Value / 60D
                filaTiempo("Subtotal") = importeTiempo
                filaTiempo("Fecha") = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                dt.Rows.Add(filaTiempo)
            End If
            _dgvPendientes.DataSource = dt
            _dgvPendientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            For Each nombre In New String() {"Id", "Nombre", "Cantidad", "Precio", "Subtotal", "Fecha"}
                If _dgvPendientes.Columns.Contains(nombre) Then _dgvPendientes.Columns(nombre).Visible = nombre = "Nombre" OrElse nombre = "Cantidad" OrElse nombre = "Subtotal"
            Next
            If _dgvPendientes.Columns.Contains("Nombre") Then
                _dgvPendientes.Columns("Nombre").HeaderText = "Producto" : _dgvPendientes.Columns("Nombre").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End If
            If _dgvPendientes.Columns.Contains("Cantidad") Then _dgvPendientes.Columns("Cantidad").HeaderText = "Cant. / min"
            If _dgvPendientes.Columns.Contains("Subtotal") Then _dgvPendientes.Columns("Subtotal").HeaderText = "Importe"
            For Each fila As DataGridViewRow In _dgvPendientes.Rows
                If fila.Cells("Nombre").Value IsNot Nothing AndAlso CStr(fila.Cells("Nombre").Value).StartsWith("Uso de PC", StringComparison.OrdinalIgnoreCase) Then
                    fila.DefaultCellStyle.BackColor = Color.FromArgb(236, 253, 245)
                    fila.DefaultCellStyle.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
                End If
            Next
        Catch
        End Try
    End Sub
    Private Function TieneTiempoPendiente(equipo As String) As Boolean
        Return MinutosSesion(equipo) > 0
    End Function

    Private Function MinutosSesion(equipo As String) As Integer
        Dim activa = Servidor.Data.Db.SesionActiva(equipo)
        If activa Is Nothing Then Return 0
        Dim inicio As DateTime
        Dim fin As DateTime
        If Not DateTime.TryParseExact(CStr(activa("Inicio")), "yyyy-MM-dd HH:mm:ss", Globalization.CultureInfo.InvariantCulture, Globalization.DateTimeStyles.None, inicio) OrElse
           Not DateTime.TryParseExact(CStr(activa("Fin")), "yyyy-MM-dd HH:mm:ss", Globalization.CultureInfo.InvariantCulture, Globalization.DateTimeStyles.None, fin) Then Return 0
        Dim pausa As DateTime = DateTime.MinValue
        DateTime.TryParseExact(CStr(activa("PausaDesde")), "yyyy-MM-dd HH:mm:ss", Globalization.CultureInfo.InvariantCulture, Globalization.DateTimeStyles.None, pausa)
        Dim hasta As DateTime = If(pausa <> DateTime.MinValue, pausa, DateTime.Now)
        If fin <> DateTime.MinValue AndAlso fin < hasta Then hasta = fin
        If hasta <= inicio Then Return 0
        Return CInt(Math.Ceiling((hasta - inicio).TotalMinutes))
    End Function

    Private Sub CargarCatalogo()
        Try
            dgvCat.DataSource = Servidor.Data.Db.ListarProductos(txtBuscar.Text.Trim())
            dgvCat.SuspendLayout()
            dgvCat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.None
            If dgvCat.Columns.Contains("Id") Then
                dgvCat.Columns("Id").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                dgvCat.Columns("Id").Width = 50
            End If
            For Each cn In New String() {"Nombre", "Categoria", "Precio", "Stock"}
                If dgvCat.Columns.Contains(cn) Then
                    dgvCat.Columns(cn).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End If
            Next
            dgvCat.ResumeLayout()
            If dgvCat.Columns.Contains("Precio") Then dgvCat.Columns("Precio").DefaultCellStyle.Format = "N2"
        Catch
        End Try
    End Sub

    Private Sub txtBuscar_TextChanged(s As Object, e As EventArgs) Handles txtBuscar.TextChanged
        CargarCatalogo()
    End Sub

    Private Sub Agregar(s As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            If dgvCat.CurrentRow Is Nothing Then Return
            Dim c = dgvCat.CurrentRow.Cells
            Dim id As Integer = CInt(c("Id").Value)
            Dim nombre As String = CStr(c("Nombre").Value)
            Dim precio As Decimal = CDec(c("Precio").Value)
            Dim stock As Integer = CInt(c("Stock").Value)
            Dim cant As Integer = CInt(numCant.Value)
            If cant > stock Then
                MessageBox.Show("Stock insuficiente. Disponible: " & stock, "Punto de venta",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            Dim found As DataRow = Nothing
            For Each r As DataRow In _carrito.Rows
                If CInt(r("Id")) = id Then found = r : Exit For
            Next
            If found Is Nothing Then
                _carrito.Rows.Add(id, nombre, cant, precio, cant * precio)
            Else
                Dim nueva As Integer = CInt(found("Cant")) + cant
                If nueva > stock Then
                    MessageBox.Show("Supera el stock disponible.", "Punto de venta",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
                found("Cant") = nueva
                found("Subtotal") = nueva * precio
            End If
            ActualizarTotal()
            ActualizarModoEquipo()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Punto de venta", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvCat_DoubleClick(s As Object, e As DataGridViewCellEventArgs) Handles dgvCat.CellDoubleClick
        Agregar(Nothing, Nothing)
    End Sub

    Private Sub Quitar(s As Object, e As EventArgs) Handles btnQuitar.Click
        Try
            If dgvCar.CurrentRow Is Nothing Then Return
            Dim id As Integer = CInt(dgvCar.CurrentRow.Cells("Id").Value)
            For Each r As DataRow In _carrito.Rows
                If CInt(r("Id")) = id Then r.Delete() : Exit For
            Next
            _carrito.AcceptChanges()
            ActualizarTotal()
            ActualizarModoEquipo()
        Catch
        End Try
    End Sub

    Private Sub LimpiarTicket(s As Object, e As EventArgs) Handles btnLimpiar.Click
        _carrito.Clear()
        ActualizarTotal()
        ActualizarModoEquipo()
    End Sub

    Private Sub ActualizarTotal()
        Dim t As Decimal = 0
        For Each r As DataRow In _carrito.Rows
            t += CDec(r("Subtotal"))
        Next
        If cboEquipo IsNot Nothing AndAlso cboEquipo.SelectedItem IsNot Nothing AndAlso EquipoActual() <> "Mostrador" Then
            Try
                Dim cuenta As Decimal = Servidor.Data.Db.TotalCargosPendientes(EquipoActual())
                cuenta += Math.Round(MinutosSesion(EquipoActual()) * _nudTarifa.Value / 60D, 2)
                lblTotal.Text = "Cuenta + ticket: $" & (cuenta + t).ToString("N2")
            Catch
                lblTotal.Text = "Ticket: $" & t.ToString("N2")
            End Try
        Else
            lblTotal.Text = "Total: $" & t.ToString("N2")
        End If
    End Sub

    Private Sub Cobrar(s As Object, e As EventArgs) Handles btnCobrar.Click
        If EquipoActual() <> "Mostrador" Then
            If _carrito.Rows.Count > 0 Then
                CargarTicketACuenta()
            Else
                CobrarCuentaEquipo()
            End If
            Return
        End If
        If _carrito.Rows.Count = 0 Then Return
        Dim items As New List(Of Tuple(Of Integer, Integer, Decimal))()
        For Each r As DataRow In _carrito.Rows
            items.Add(Tuple.Create(CInt(r("Id")), CInt(r("Cant")), CDec(r("Precio"))))
        Next
        Dim total As Decimal = items.Sum(Function(i) i.Item2 * i.Item3)
        Dim pagos = SolicitarPagos(total, "Venta de mostrador", CStr(cboPago.SelectedItem))
        If pagos Is Nothing Then Return
        Try
            Dim folio = Servidor.Data.Db.RegistrarVenta("Mostrador", MetodoPago(pagos), items, pagos)
            MessageBox.Show("Venta #" & folio.ToString() & " registrada. " & lblTotal.Text,
                            "Punto de venta", MessageBoxButtons.OK, MessageBoxIcon.Information)
            _carrito.Clear()
            ActualizarTotal()
            ActualizarModoEquipo()
            CargarCatalogo()
        Catch ex As Exception
            MessageBox.Show("No se pudo cobrar: " & ex.Message, "Punto de venta",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CargarTicketACuenta()
        Dim items As New List(Of Tuple(Of Integer, Integer, Decimal))()
        For Each r As DataRow In _carrito.Rows
            items.Add(Tuple.Create(CInt(r("Id")), CInt(r("Cant")), CDec(r("Precio"))))
        Next
        Try
            Servidor.Data.Db.CargarProductosACuenta(EquipoActual(), items)
            _carrito.Clear()
            CargarCatalogo()
            ActualizarTotal()
            ActualizarModoEquipo()
            MessageBox.Show("Productos cargados a la cuenta de " & EquipoActual() & ".", "Punto de venta", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("No se pudo cargar a la cuenta: " & ex.Message, "Punto de venta", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CobrarCuentaEquipo()
        Dim equipo = EquipoActual()
        Try
            Dim cargos = Servidor.Data.Db.CargosPendientesEquipo(equipo)
            Dim minutos = MinutosSesion(equipo)
            Dim tarifaHora = _nudTarifa.Value
            If minutos > 0 AndAlso tarifaHora <= 0D Then
                MessageBox.Show("Configura una tarifa por hora mayor que cero para cobrar el tiempo de " & equipo & ".", "Punto de venta", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            Dim totalProductos As Decimal = 0D
            Dim resumen As New System.Text.StringBuilder()
            For Each r As DataRow In cargos.Rows
                totalProductos += CDec(r("Subtotal"))
                resumen.AppendLine(CStr(r("Nombre")) & " x" & CInt(r("Cantidad")).ToString() & "  $" & CDec(r("Subtotal")).ToString("N2"))
            Next
            Dim montoTiempo As Decimal = Math.Round(minutos * tarifaHora / 60D, 2)
            If minutos > 0 Then resumen.AppendLine("Uso de PC: " & minutos.ToString() & " min × $" & tarifaHora.ToString("N2") & "/h = $" & montoTiempo.ToString("N2"))
            Dim total As Decimal = totalProductos + montoTiempo
            If total <= 0D Then
                MessageBox.Show(equipo & " no tiene cargos pendientes.", "Punto de venta", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
            Dim pagos = SolicitarPagos(total, resumen.ToString(), If(cboPago.SelectedItem Is Nothing, "Efectivo", CStr(cboPago.SelectedItem)))
            If pagos Is Nothing Then Return
            Dim folio = Servidor.Data.Db.LiquidarCuentaEquipo(equipo, minutos, tarifaHora, pagos)
            Dim ip = Servidor.Data.Db.IpDeEquipo(equipo)
            Dim addr As System.Net.IPAddress = Nothing
            If System.Net.IPAddress.TryParse(If(ip, "").Trim(), addr) Then
                Try
                    NetProtocol.SendUdp(addr.ToString(), Servidor.Data.Db.Puerto(), "BLOQUEO", "0", "0")
                Catch
                End Try
            End If
            RaiseEvent EquipoLiquidado(equipo)
            CargarCatalogo()
            ActualizarTotal()
            ActualizarModoEquipo()
            MessageBox.Show("Cuenta de " & equipo & " liquidada. Venta #" & folio.ToString() & ".", "Punto de venta", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("No se pudo liquidar la cuenta: " & ex.Message, "Punto de venta", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function MetodoPago(pagos As Dictionary(Of String, Decimal)) As String
        Dim usados = pagos.Where(Function(p) p.Value > 0D).ToList()
        If usados.Count = 1 Then Return usados(0).Key
        Return "Mixto"
    End Function

    Private Function SolicitarPagos(total As Decimal, detalle As String, preferido As String) As Dictionary(Of String, Decimal)
        Dim dlg As New Form()
        dlg.Text = "Cobrar · Total $" & total.ToString("N2")
        dlg.FormBorderStyle = FormBorderStyle.FixedDialog
        dlg.StartPosition = FormStartPosition.CenterParent
        dlg.MinimizeBox = False
        dlg.MaximizeBox = False
        dlg.ShowInTaskbar = False
        dlg.ClientSize = New Size(460, 400)
        Dim lDetalle As New TextBox() With {.Multiline = True, .ReadOnly = True, .ScrollBars = ScrollBars.Vertical, .Location = New Point(16, 16), .Size = New Size(428, 125), .Text = detalle}
        Dim lTotal As New Label() With {.Location = New Point(16, 150), .Size = New Size(428, 28), .Font = New Font("Segoe UI", 12.0!, FontStyle.Bold), .Text = "Total a cobrar: $" & total.ToString("N2")}
        dlg.Controls.Add(lDetalle)
        dlg.Controls.Add(lTotal)
        Dim chkMixto As New CheckBox() With {.Text = "Dividir el pago entre varios medios", .Location = New Point(18, 180), .Size = New Size(330, 24)}
        dlg.Controls.Add(chkMixto)
        Dim nombres As String() = {"Efectivo", "Tarjeta", "Transferencia"}
        Dim cajas As New Dictionary(Of String, NumericUpDown)()
        Dim y As Integer = 210
        For Each nombre In nombres
            Dim etiqueta As New Label() With {.Text = nombre & ":", .Location = New Point(18, y + 4), .Size = New Size(150, 24)}
            Dim caja As New NumericUpDown() With {.DecimalPlaces = 2, .Maximum = total, .Minimum = 0D, .ThousandsSeparator = True, .Location = New Point(190, y), .Size = New Size(180, 24)}
            If nombre = preferido Then caja.Value = total
            dlg.Controls.Add(etiqueta)
            dlg.Controls.Add(caja)
            cajas(nombre) = caja
            y += 36
        Next
        For Each caja In cajas.Values
            caja.Enabled = False
        Next
        If cajas.ContainsKey(preferido) Then cajas(preferido).Enabled = True
        If cajas.ContainsKey(preferido) Then cajas(preferido).Value = total
        AddHandler chkMixto.CheckedChanged, Sub(sender As Object, e As EventArgs)
                                                    For Each caja In cajas.Values
                                                        caja.Value = 0D
                                                        caja.Enabled = chkMixto.Checked
                                                    Next
                                                    If Not chkMixto.Checked Then
                                                        If cajas.ContainsKey(preferido) Then
                                                            cajas(preferido).Enabled = True
                                                            cajas(preferido).Value = total
                                                        End If
                                                    End If
                                                End Sub
        Dim lblRestante As New Label() With {.Location = New Point(18, 324), .Size = New Size(260, 25), .Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)}
        Dim ActualizarRestante As Action = Sub()
                                              Dim asignado As Decimal = cajas.Values.Sum(Function(c) c.Value)
                                              lblRestante.Text = "Por asignar: $" & (total - asignado).ToString("N2")
                                          End Sub
        For Each caja In cajas.Values
            AddHandler caja.ValueChanged, Sub(sender As Object, e As EventArgs) ActualizarRestante()
        Next
        ActualizarRestante()
        dlg.Controls.Add(lblRestante)
        Dim ok As New Button() With {.Text = "Confirmar cobro", .DialogResult = DialogResult.None, .Location = New Point(266, 350), .Size = New Size(178, 34)}
        Dim cancel As New Button() With {.Text = "Cancelar", .DialogResult = DialogResult.Cancel, .Location = New Point(16, 350), .Size = New Size(110, 34)}
        dlg.Controls.Add(ok)
        dlg.Controls.Add(cancel)
        dlg.AcceptButton = ok
        dlg.CancelButton = cancel
        Dim resultado As Dictionary(Of String, Decimal) = Nothing
        AddHandler ok.Click, Sub(sender As Object, e As EventArgs)
                                 Dim suma As Decimal = cajas.Values.Sum(Function(c) c.Value)
                                 If Math.Abs(suma - total) > 0.01D Then
                                     MessageBox.Show("Los importes deben sumar exactamente $" & total.ToString("N2") & ". Ajusta Efectivo, Tarjeta o Transferencia.", "Cobro mixto", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                     Return
                                 End If
                                 resultado = cajas.ToDictionary(Function(kv) kv.Key, Function(kv) kv.Value.Value)
                                 dlg.DialogResult = DialogResult.OK
                             End Sub
        If dlg.ShowDialog(FindForm()) <> DialogResult.OK Then Return Nothing
        Return resultado
    End Function
End Class
