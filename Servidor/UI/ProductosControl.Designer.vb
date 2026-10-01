<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductosControl
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
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.numStock = New System.Windows.Forms.NumericUpDown()
        Me.numPrecio = New System.Windows.Forms.NumericUpDown()
        Me.txtCat = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblId = New System.Windows.Forms.Label()
        Me.g = New System.Windows.Forms.GroupBox()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.bar.SuspendLayout()
        CType(Me.numStock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numPrecio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.g.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bar
        '
        Me.bar.BackColor = System.Drawing.Color.White
        Me.bar.Controls.Add(Me.btnEliminar)
        Me.bar.Controls.Add(Me.btnGuardar)
        Me.bar.Controls.Add(Me.btnNuevo)
        Me.bar.Controls.Add(Me.numStock)
        Me.bar.Controls.Add(Me.numPrecio)
        Me.bar.Controls.Add(Me.txtCat)
        Me.bar.Controls.Add(Me.txtNombre)
        Me.bar.Controls.Add(Me.lblId)
        Me.bar.Dock = System.Windows.Forms.DockStyle.Top
        Me.bar.Location = New System.Drawing.Point(0, 0)
        Me.bar.Name = "bar"
        Me.bar.Padding = New System.Windows.Forms.Padding(10)
        Me.bar.Size = New System.Drawing.Size(909, 60)
        Me.bar.TabIndex = 0
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(808, 10)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(90, 40)
        Me.btnEliminar.TabIndex = 7
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(712, 10)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(90, 40)
        Me.btnGuardar.TabIndex = 6
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New System.Drawing.Point(616, 10)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(90, 40)
        Me.btnNuevo.TabIndex = 5
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'numStock
        '
        Me.numStock.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.numStock.Location = New System.Drawing.Point(530, 10)
        Me.numStock.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.numStock.Name = "numStock"
        Me.numStock.Size = New System.Drawing.Size(80, 27)
        Me.numStock.TabIndex = 4
        '
        'numPrecio
        '
        Me.numPrecio.DecimalPlaces = 2
        Me.numPrecio.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.numPrecio.Location = New System.Drawing.Point(424, 10)
        Me.numPrecio.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.numPrecio.Name = "numPrecio"
        Me.numPrecio.Size = New System.Drawing.Size(100, 27)
        Me.numPrecio.TabIndex = 3
        '
        'txtCat
        '
        Me.txtCat.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtCat.Location = New System.Drawing.Point(288, 10)
        Me.txtCat.Name = "txtCat"
        Me.txtCat.Size = New System.Drawing.Size(130, 27)
        Me.txtCat.TabIndex = 2
        '
        'txtNombre
        '
        Me.txtNombre.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtNombre.Location = New System.Drawing.Point(62, 10)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(220, 27)
        Me.txtNombre.TabIndex = 1
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblId.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.lblId.Location = New System.Drawing.Point(10, 10)
        Me.lblId.Name = "lblId"
        Me.lblId.Padding = New System.Windows.Forms.Padding(0, 8, 8, 0)
        Me.lblId.Size = New System.Drawing.Size(48, 28)
        Me.lblId.TabIndex = 0
        Me.lblId.Text = "Id: 0"
        '
        'g
        '
        Me.g.BackColor = System.Drawing.Color.White
        Me.g.Controls.Add(Me.dgv)
        Me.g.Dock = System.Windows.Forms.DockStyle.Fill
        Me.g.Location = New System.Drawing.Point(0, 60)
        Me.g.Name = "g"
        Me.g.Size = New System.Drawing.Size(909, 540)
        Me.g.TabIndex = 1
        Me.g.TabStop = False
        Me.g.Text = "Catálogo (Nombre · Categoría · Precio · Stock)"
        '
        'dgv
        '
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv.Location = New System.Drawing.Point(3, 16)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(903, 521)
        Me.dgv.TabIndex = 0
        '
        'ProductosControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Controls.Add(Me.g)
        Me.Controls.Add(Me.bar)
        Me.Name = "ProductosControl"
        Me.Size = New System.Drawing.Size(909, 600)
        Me.bar.ResumeLayout(False)
        Me.bar.PerformLayout()
        CType(Me.numStock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numPrecio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.g.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents bar As Panel
    Friend WithEvents lblId As Label
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents txtCat As TextBox
    Friend WithEvents numPrecio As NumericUpDown
    Friend WithEvents numStock As NumericUpDown
    Friend WithEvents btnNuevo As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents g As GroupBox
    Friend WithEvents dgv As DataGridView
End Class
