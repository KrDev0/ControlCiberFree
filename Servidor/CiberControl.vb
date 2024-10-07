Imports System.Diagnostics.SymbolStore

Public Class CiberControl
    Private Sub CiberControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Agregar el formulario Form2 en cada uno de los paneles existentes
        For i As Integer = 1 To 10

            ' Obtener el panel por nombre dinámicamente
            Dim panelName As String = "Panel" & i.ToString()
            Dim panel As Panel = Me.Controls.Find(panelName, True).FirstOrDefault()

            If panel IsNot Nothing Then
                ' Crear una nueva instancia del formulario Form2
                Dim childForm As New Main()
                childForm.TopLevel = False
                childForm.FormBorderStyle = FormBorderStyle.None
                childForm.Dock = DockStyle.Fill

                ' Cambiar el texto del lblEquipo dentro del formulario
                Dim lbl As Label = childForm.Controls.Find("lblEquipo", True).FirstOrDefault()
                If lbl IsNot Nothing Then
                    lbl.Text = "Equipo " & i.ToString() ' Cambiar texto según el número de panel
                End If

                ' Agregar el formulario al panel y mostrarlo
                panel.Controls.Add(childForm)
                childForm.Show()
            End If
        Next
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        RegPC.ShowDialog()
    End Sub
End Class