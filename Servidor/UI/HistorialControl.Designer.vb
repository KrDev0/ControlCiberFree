<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HistorialControl
    Inherits System.Windows.Forms.UserControl

    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.bar = New System.Windows.Forms.Panel()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.dtpHasta = New System.Windows.Forms.DateTimePicker()
        Me.lHasta = New System.Windows.Forms.Label()
        Me.dtpDesde = New System.Windows.Forms.DateTimePicker()
        Me.lDesde = New System.Windows.Forms.Label()
        Me.g = New System.Windows.Forms.GroupBox()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.btnFiltrar = New System.Windows.Forms.Button()
        Me.bar.SuspendLayout()
        Me.g.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bar
        '
        Me.bar.BackColor = System.Drawing.Color.White
        Me.bar.Controls.Add(Me.btnFiltrar)
        Me.bar.Controls.Add(Me.lblTotal)
        Me.bar.Controls.Add(Me.dtpHasta)
        Me.bar.Controls.Add(Me.lHasta)
        Me.bar.Controls.Add(Me.dtpDesde)
        Me.bar.Controls.Add(Me.lDesde)
        Me.bar.Dock = System.Windows.Forms.DockStyle.Top
        Me.bar.Location = New System.Drawing.Point(0, 0)
        Me.bar.Name = "bar"
        Me.bar.Padding = New System.Windows.Forms.Padding(10)
        Me.bar.Size = New System.Drawing.Size(900, 60)
        Me.bar.TabIndex = 0
        '
        'lblTotal
        '
        Me.lblTotal.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTotal.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.lblTotal.Location = New System.Drawing.Point(510, 5)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(380, 50)
        Me.lblTotal.TabIndex = 5
        Me.lblTotal.Text = "Total: $0.00"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpHasta
        '
        Me.dtpHasta.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpHasta.Location = New System.Drawing.Point(268, 10)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(130, 27)
        Me.dtpHasta.TabIndex = 3
        '
        'lHasta
        '
        Me.lHasta.AutoSize = True
        Me.lHasta.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lHasta.Location = New System.Drawing.Point(200, 10)
        Me.lHasta.Name = "lHasta"
        Me.lHasta.Padding = New System.Windows.Forms.Padding(12, 7, 6, 0)
        Me.lHasta.Size = New System.Drawing.Size(68, 27)
        Me.lHasta.TabIndex = 2
        Me.lHasta.Text = "Hasta:"
        '
        'dtpDesde
        '
        Me.dtpDesde.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDesde.Location = New System.Drawing.Point(70, 10)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(130, 27)
        Me.dtpDesde.TabIndex = 1
        '
        'lDesde
        '
        Me.lDesde.AutoSize = True
        Me.lDesde.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lDesde.Location = New System.Drawing.Point(10, 10)
        Me.lDesde.Name = "lDesde"
        Me.lDesde.Padding = New System.Windows.Forms.Padding(0, 7, 6, 0)
        Me.lDesde.Size = New System.Drawing.Size(60, 27)
        Me.lDesde.TabIndex = 0
        Me.lDesde.Text = "Desde:"
        '
        'g
        '
        Me.g.BackColor = System.Drawing.Color.White
        Me.g.Controls.Add(Me.dgv)
        Me.g.Dock = System.Windows.Forms.DockStyle.Fill
        Me.g.Location = New System.Drawing.Point(0, 60)
        Me.g.Name = "g"
        Me.g.Size = New System.Drawing.Size(900, 540)
        Me.g.TabIndex = 1
        Me.g.TabStop = False
        Me.g.Text = "Ventas del periodo"
        '
        'dgv
        '
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv.Location = New System.Drawing.Point(3, 16)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(894, 521)
        Me.dgv.TabIndex = 0
        '
        'btnFiltrar
        '
        Me.btnFiltrar.Location = New System.Drawing.Point(409, 10)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(110, 40)
        Me.btnFiltrar.TabIndex = 6
        Me.btnFiltrar.Text = "Filtrar"
        Me.btnFiltrar.UseVisualStyleBackColor = True
        '
        'HistorialControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Controls.Add(Me.g)
        Me.Controls.Add(Me.bar)
        Me.Name = "HistorialControl"
        Me.Size = New System.Drawing.Size(900, 600)
        Me.bar.ResumeLayout(False)
        Me.bar.PerformLayout()
        Me.g.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents bar As Panel
    Friend WithEvents lDesde As Label
    Friend WithEvents dtpDesde As DateTimePicker
    Friend WithEvents lHasta As Label
    Friend WithEvents dtpHasta As DateTimePicker
    Friend WithEvents lblTotal As Label
    Friend WithEvents g As GroupBox
    Friend WithEvents dgv As DataGridView
    Friend WithEvents btnFiltrar As Button
End Class
