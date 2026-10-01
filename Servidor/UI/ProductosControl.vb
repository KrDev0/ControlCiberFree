''' <summary>Módulo independiente de productos (consumibles y papelería), editable desde el diseñador.</summary>
Public Class ProductosControl
    Inherits UserControl

    Private _editId As Integer = 0

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        Try
            Theme.StyleButton(btnNuevo, Theme.Muted)
            Theme.StyleButton(btnGuardar, Theme.Primary)
            Theme.StyleButton(btnEliminar, Theme.Danger)
            Theme.StyleGrid(dgv)
        Catch
        End Try
    End Sub

    Public Sub Refrescar()
        Try
            dgv.DataSource = Servidor.Data.Db.ListarProductos("")
            If dgv.Columns.Contains("Precio") Then dgv.Columns("Precio").DefaultCellStyle.Format = "N2"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Productos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgv_SelectionChanged(s As Object, e As EventArgs) Handles dgv.SelectionChanged
        Try
            If dgv.CurrentRow Is Nothing OrElse dgv.CurrentRow.IsNewRow Then Return
            Dim c = dgv.CurrentRow.Cells
            _editId = CInt(c("Id").Value)
            lblId.Text = "Id: " & _editId.ToString()
            txtNombre.Text = CStr(c("Nombre").Value)
            txtCat.Text = CStr(c("Categoria").Value)
            numPrecio.Value = Math.Min(numPrecio.Maximum, CDec(c("Precio").Value))
            numStock.Value = Math.Min(numStock.Maximum, CDec(c("Stock").Value))
        Catch
        End Try
    End Sub

    Private Sub btnNuevo_Click(s As Object, e As EventArgs) Handles btnNuevo.Click
        _editId = 0 : lblId.Text = "Id: 0"
        txtNombre.Clear() : txtCat.Clear()
        numPrecio.Value = 0 : numStock.Value = 0
        txtNombre.Focus()
    End Sub

    Private Sub btnGuardar_Click(s As Object, e As EventArgs) Handles btnGuardar.Click
        If String.IsNullOrWhiteSpace(txtNombre.Text) Then
            MessageBox.Show("El nombre es obligatorio.", "Productos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Try
            _editId = Servidor.Data.Db.GuardarProducto(_editId, txtNombre.Text,
                If(String.IsNullOrWhiteSpace(txtCat.Text), "General", txtCat.Text),
                numPrecio.Value, CInt(numStock.Value))
            lblId.Text = "Id: " & _editId.ToString()
            Refrescar()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Productos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEliminar_Click(s As Object, e As EventArgs) Handles btnEliminar.Click
        If _editId <= 0 Then Return
        If MessageBox.Show("¿Eliminar el producto?", "Productos",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
        Try
            Servidor.Data.Db.EliminarProducto(_editId)
            btnNuevo.PerformClick()
            Refrescar()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Productos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
