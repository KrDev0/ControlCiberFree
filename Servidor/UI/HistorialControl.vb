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
            Dim t As Decimal = 0
            For Each r As DataRow In dt.Rows
                t += CDec(r("Total"))
            Next
            lblTotal.Text = "Total: $" & t.ToString("N2") & " (" & dt.Rows.Count.ToString() & ")"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Historial", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnFiltrar_Click(s As Object, e As EventArgs) 
        Refrescar()
    End Sub
End Class
