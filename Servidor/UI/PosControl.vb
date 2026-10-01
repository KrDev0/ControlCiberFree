''' <summary>
''' Punto de venta embebido en el Dashboard (editable desde el diseñador).
''' Estilo del sistema: cabeceras oscuras, botones planos.
''' </summary>
Public Class PosControl
    Inherits UserControl

    Private _carrito As New DataTable()

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        Try
            Theme.StyleButton(btnAgregar, Theme.Primary)
            Theme.StyleButton(btnQuitar, Theme.Danger)
            Theme.StyleButton(btnLimpiar, Theme.Muted)
            Theme.StyleButton(btnCobrar, Theme.Success)
            Theme.StyleGrid(dgvCat)
            Theme.StyleGrid(dgvCar)
        Catch
        End Try
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
    End Sub

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
        Catch
        End Try
    End Sub

    Private Sub LimpiarTicket(s As Object, e As EventArgs) Handles btnLimpiar.Click
        _carrito.Clear()
        ActualizarTotal()
    End Sub

    Private Sub ActualizarTotal()
        Dim t As Decimal = 0
        For Each r As DataRow In _carrito.Rows
            t += CDec(r("Subtotal"))
        Next
        lblTotal.Text = "Total: $" & t.ToString("N2")
    End Sub

    Private Sub Cobrar(s As Object, e As EventArgs) Handles btnCobrar.Click
        If _carrito.Rows.Count = 0 Then
            MessageBox.Show("El ticket está vacío.", "Punto de venta", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Dim items As New List(Of Tuple(Of Integer, Integer, Decimal))()
        For Each r As DataRow In _carrito.Rows
            items.Add(Tuple.Create(CInt(r("Id")), CInt(r("Cant")), CDec(r("Precio"))))
        Next
        Try
            Dim folio = Servidor.Data.Db.RegistrarVenta(cboEquipo.Text, cboPago.Text, items)
            MessageBox.Show("Venta #" & folio.ToString() & " registrada. " & lblTotal.Text,
                            "Punto de venta", MessageBoxButtons.OK, MessageBoxIcon.Information)
            _carrito.Clear()
            ActualizarTotal()
            CargarCatalogo()
        Catch ex As Exception
            MessageBox.Show("No se pudo cobrar: " & ex.Message, "Punto de venta",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
