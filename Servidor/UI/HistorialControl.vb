''' <summary>Módulo independiente de historial de ventas, editable desde el diseñador.</summary>
Public Class HistorialControl
    Inherits UserControl

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        Try
            Theme.StyleButton(btnFiltrar, Theme.Primary)
            Theme.StyleGrid(dgv)
        Catch
        End Try
    End Sub

    Public Sub Refrescar()
        Try
            If dtpDesde.Value.Year < 2000 Then dtpDesde.Value = DateTime.Today.AddDays(-30)
            If dtpHasta.Value.Year < 2000 Then dtpHasta.Value = DateTime.Today
            Dim dt = Servidor.Data.Db.HistorialVentas(dtpDesde.Value.Date, dtpHasta.Value.Date)
            dgv.DataSource = dt
            If dgv.Columns.Contains("Total") Then dgv.Columns("Total").DefaultCellStyle.Format = "N2"
            For Each nombre As String In New String() {"Efectivo", "Transferencia", "Tarjeta"}
                If dgv.Columns.Contains(nombre) Then dgv.Columns(nombre).DefaultCellStyle.Format = "N2"
            Next
            If dgv.Columns.Contains("Productos") Then
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                dgv.Columns("Id").Width = 48
                dgv.Columns("Fecha").Width = 150
                dgv.Columns("Equipo").Width = 90
                dgv.Columns("Productos").Width = 210
                dgv.Columns("Servicios").Width = 105
                dgv.Columns("Total").Width = 85
                dgv.Columns("MetodoPago").Visible = False
                dgv.Columns("Pagos").Visible = False
                dgv.Columns("Efectivo").Width = 85
                dgv.Columns("Transferencia").Width = 105
                dgv.Columns("Tarjeta").Width = 85
                dgv.Columns("Productos").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                dgv.Columns("Productos").MinimumWidth = 150
                dgv.Columns("Servicios").HeaderText = "Otros cargos"
                dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                dgv.Columns("Productos").DefaultCellStyle.WrapMode = DataGridViewTriState.True
                dgv.Columns("Servicios").DefaultCellStyle.WrapMode = DataGridViewTriState.True
            End If
            Dim t As Decimal = 0
            For Each r As DataRow In dt.Rows
                t += CDec(r("Total"))
            Next
            Dim pagos = Servidor.Data.Db.ResumenPagos(dtpDesde.Value.Date, dtpHasta.Value.Date)
            lblTotal.Text = "Total: $" & t.ToString("N2") & " (" & dt.Rows.Count.ToString() & ")" & vbCrLf &
                "Efectivo: $" & pagos("Efectivo").ToString("N2") & " · Transferencia: $" & pagos("Transferencia").ToString("N2") & " · Tarjeta: $" & pagos("Tarjeta").ToString("N2")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Historial", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnFiltrar_Click(s As Object, e As EventArgs) 
        Refrescar()
    End Sub
End Class
