''' <summary>Paleta moderna + helpers para WinForms clásico.</summary>
Public Module Theme
    Public ReadOnly Primary As Color = Color.FromArgb(45, 137, 239)
    Public ReadOnly Dark As Color = Color.FromArgb(31, 41, 55)
    Public ReadOnly Bg As Color = Color.FromArgb(243, 244, 246)
    Public ReadOnly Card As Color = Color.White
    Public ReadOnly Success As Color = Color.FromArgb(39, 174, 96)
    Public ReadOnly Danger As Color = Color.FromArgb(231, 76, 60)
    Public ReadOnly Warn As Color = Color.FromArgb(243, 156, 18)
    Public ReadOnly Muted As Color = Color.FromArgb(107, 114, 128)

    Public Sub StyleButton(btn As Button, back As Color, Optional fore As Color = Nothing)
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 0
        btn.BackColor = back
        btn.ForeColor = If(fore = Nothing, Color.White, fore)
        btn.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        btn.Cursor = Cursors.Hand
    End Sub

    Public Sub StyleSideButton(btn As Button, active As Boolean)
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 0
        btn.TextAlign = ContentAlignment.MiddleLeft
        btn.Padding = New Padding(18, 0, 0, 0)
        btn.Font = New Font("Segoe UI", 11, If(active, FontStyle.Bold, FontStyle.Regular))
        btn.Cursor = Cursors.Hand
        btn.Height = 52
        btn.Dock = DockStyle.Top
        If active Then
            btn.BackColor = Primary
            btn.ForeColor = Color.White
        Else
            btn.BackColor = Color.Transparent
            btn.ForeColor = Color.FromArgb(209, 213, 219)
        End If
    End Sub

    Public Sub StyleGrid(g As DataGridView)
        g.BackgroundColor = Color.White
        g.BorderStyle = BorderStyle.None
        g.EnableHeadersVisualStyles = False
        g.ColumnHeadersDefaultCellStyle.BackColor = Dark
        g.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        g.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        g.ColumnHeadersHeight = 34
        g.RowHeadersVisible = False
        g.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        g.MultiSelect = False
        g.AllowUserToAddRows = False
        g.AllowUserToDeleteRows = False
        g.ReadOnly = True
        g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        g.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251)
        g.DefaultCellStyle.Font = New Font("Segoe UI", 10)
        g.RowTemplate.Height = 28
    End Sub

    Public Function CardPanel() As Panel
        Dim p As New Panel()
        p.BackColor = Card
        p.Margin = New Padding(10)
        p.Padding = New Padding(12)
        Return p
    End Function
End Module
