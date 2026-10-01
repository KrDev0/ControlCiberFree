<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EquipoCard
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
        Me.grid = New System.Windows.Forms.TableLayoutPanel()
        Me.lblIp = New System.Windows.Forms.Label()
        Me.rT = New System.Windows.Forms.Panel()
        Me.lh = New System.Windows.Forms.Label()
        Me.numH = New System.Windows.Forms.NumericUpDown()
        Me.lm = New System.Windows.Forms.Label()
        Me.numM = New System.Windows.Forms.NumericUpDown()
        Me.btnIniciar = New System.Windows.Forms.Button()
        Me.btnAnadir = New System.Windows.Forms.Button()
        Me.rB = New System.Windows.Forms.Panel()
        Me.btnBloq = New System.Windows.Forms.Button()
        Me.btnDesbloq = New System.Windows.Forms.Button()
        Me.btnVer = New System.Windows.Forms.Button()
        Me.rM = New System.Windows.Forms.Panel()
        Me.txtMsg = New System.Windows.Forms.TextBox()
        Me.btnMsg = New System.Windows.Forms.Button()
        Me.rP = New System.Windows.Forms.Panel()
        Me.btnWin = New System.Windows.Forms.Button()
        Me.btnRei = New System.Windows.Forms.Button()
        Me.btnApa = New System.Windows.Forms.Button()
        Me.header = New System.Windows.Forms.Panel()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.lblEstado = New System.Windows.Forms.Label()
        CType(Me.numH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grid.SuspendLayout()
        Me.rT.SuspendLayout()
        Me.rB.SuspendLayout()
        Me.rM.SuspendLayout()
        Me.rP.SuspendLayout()
        Me.header.SuspendLayout()
        Me.SuspendLayout()
        '
        'grid
        '
        Me.grid.BackColor = System.Drawing.Color.White
        Me.grid.ColumnCount = 1
        Me.grid.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.grid.Controls.Add(Me.lblIp, 0, 0)
        Me.grid.Controls.Add(Me.rT, 0, 1)
        Me.grid.Controls.Add(Me.rB, 0, 2)
        Me.grid.Controls.Add(Me.rM, 0, 3)
        Me.grid.Controls.Add(Me.rP, 0, 4)
        Me.grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grid.Location = New System.Drawing.Point(0, 56)
        Me.grid.Name = "grid"
        Me.grid.Padding = New System.Windows.Forms.Padding(10, 8, 10, 8)
        Me.grid.RowCount = 5
        Me.grid.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.grid.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.grid.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.grid.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.grid.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.grid.Size = New System.Drawing.Size(372, 244)
        Me.grid.TabIndex = 0
        '
        'lblIp
        '
        Me.lblIp.AutoEllipsis = True
        Me.lblIp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblIp.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblIp.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128)
        Me.lblIp.Location = New System.Drawing.Point(13, 8)
        Me.lblIp.Name = "lblIp"
        Me.lblIp.Size = New System.Drawing.Size(346, 24)
        Me.lblIp.TabIndex = 0
        Me.lblIp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rT
        '
        Me.rT.BackColor = System.Drawing.Color.White
        Me.rT.Controls.Add(Me.lh)
        Me.rT.Controls.Add(Me.numH)
        Me.rT.Controls.Add(Me.lm)
        Me.rT.Controls.Add(Me.numM)
        Me.rT.Controls.Add(Me.btnIniciar)
        Me.rT.Controls.Add(Me.btnAnadir)
        Me.rT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rT.Location = New System.Drawing.Point(13, 35)
        Me.rT.Name = "rT"
        Me.rT.Size = New System.Drawing.Size(346, 32)
        Me.rT.TabIndex = 1
        '
        'lh
        '
        Me.lh.AutoSize = True
        Me.lh.Location = New System.Drawing.Point(0, 8)
        Me.lh.Name = "lh"
        Me.lh.Size = New System.Drawing.Size(19, 13)
        Me.lh.TabIndex = 0
        Me.lh.Text = "H:"
        '
        'numH
        '
        Me.numH.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.numH.Location = New System.Drawing.Point(24, 4)
        Me.numH.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.numH.Name = "numH"
        Me.numH.Size = New System.Drawing.Size(52, 25)
        Me.numH.TabIndex = 1
        '
        'lm
        '
        Me.lm.AutoSize = True
        Me.lm.Location = New System.Drawing.Point(82, 8)
        Me.lm.Name = "lm"
        Me.lm.Size = New System.Drawing.Size(20, 13)
        Me.lm.TabIndex = 2
        Me.lm.Text = "M:"
        '
        'numM
        '
        Me.numM.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.numM.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numM.Location = New System.Drawing.Point(106, 4)
        Me.numM.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.numM.Name = "numM"
        Me.numM.Size = New System.Drawing.Size(52, 25)
        Me.numM.TabIndex = 3
        '
        'btnIniciar
        '
        Me.btnIniciar.Location = New System.Drawing.Point(164, 2)
        Me.btnIniciar.Name = "btnIniciar"
        Me.btnIniciar.Size = New System.Drawing.Size(88, 32)
        Me.btnIniciar.TabIndex = 4
        Me.btnIniciar.Text = "Iniciar"
        Me.btnIniciar.UseVisualStyleBackColor = True
        '
        'btnAnadir
        '
        Me.btnAnadir.Enabled = False
        Me.btnAnadir.Location = New System.Drawing.Point(258, 2)
        Me.btnAnadir.Name = "btnAnadir"
        Me.btnAnadir.Size = New System.Drawing.Size(88, 32)
        Me.btnAnadir.TabIndex = 5
        Me.btnAnadir.Text = "Añadir"
        Me.btnAnadir.UseVisualStyleBackColor = True
        '
        'rB
        '
        Me.rB.BackColor = System.Drawing.Color.White
        Me.rB.Controls.Add(Me.btnBloq)
        Me.rB.Controls.Add(Me.btnDesbloq)
        Me.rB.Controls.Add(Me.btnVer)
        Me.rB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rB.Location = New System.Drawing.Point(13, 73)
        Me.rB.Name = "rB"
        Me.rB.Size = New System.Drawing.Size(346, 32)
        Me.rB.TabIndex = 2
        '
        'btnBloq
        '
        Me.btnBloq.Location = New System.Drawing.Point(0, 2)
        Me.btnBloq.Name = "btnBloq"
        Me.btnBloq.Size = New System.Drawing.Size(108, 32)
        Me.btnBloq.TabIndex = 0
        Me.btnBloq.Text = "Bloquear"
        Me.btnBloq.UseVisualStyleBackColor = True
        '
        'btnDesbloq
        '
        Me.btnDesbloq.Enabled = False
        Me.btnDesbloq.Location = New System.Drawing.Point(114, 2)
        Me.btnDesbloq.Name = "btnDesbloq"
        Me.btnDesbloq.Size = New System.Drawing.Size(118, 32)
        Me.btnDesbloq.TabIndex = 1
        Me.btnDesbloq.Text = "Desbloquear"
        Me.btnDesbloq.UseVisualStyleBackColor = True
        '
        'btnVer
        '
        Me.btnVer.Location = New System.Drawing.Point(238, 2)
        Me.btnVer.Name = "btnVer"
        Me.btnVer.Size = New System.Drawing.Size(108, 32)
        Me.btnVer.TabIndex = 2
        Me.btnVer.Text = "Ver"
        Me.btnVer.UseVisualStyleBackColor = True
        '
        'rM
        '
        Me.rM.BackColor = System.Drawing.Color.White
        Me.rM.Controls.Add(Me.txtMsg)
        Me.rM.Controls.Add(Me.btnMsg)
        Me.rM.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rM.Location = New System.Drawing.Point(13, 111)
        Me.rM.Name = "rM"
        Me.rM.Size = New System.Drawing.Size(346, 32)
        Me.rM.TabIndex = 3
        '
        'txtMsg
        '
        Me.txtMsg.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtMsg.Location = New System.Drawing.Point(0, 4)
        Me.txtMsg.Name = "txtMsg"
        Me.txtMsg.Size = New System.Drawing.Size(232, 25)
        Me.txtMsg.TabIndex = 0
        '
        'btnMsg
        '
        Me.btnMsg.Location = New System.Drawing.Point(238, 2)
        Me.btnMsg.Name = "btnMsg"
        Me.btnMsg.Size = New System.Drawing.Size(108, 32)
        Me.btnMsg.TabIndex = 1
        Me.btnMsg.Text = "Enviar"
        Me.btnMsg.UseVisualStyleBackColor = True
        '
        'rP
        '
        Me.rP.BackColor = System.Drawing.Color.White
        Me.rP.Controls.Add(Me.btnWin)
        Me.rP.Controls.Add(Me.btnRei)
        Me.rP.Controls.Add(Me.btnApa)
        Me.rP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rP.Location = New System.Drawing.Point(13, 149)
        Me.rP.Name = "rP"
        Me.rP.Size = New System.Drawing.Size(346, 84)
        Me.rP.TabIndex = 4
        '
        'btnWin
        '
        Me.btnWin.Location = New System.Drawing.Point(0, 2)
        Me.btnWin.Name = "btnWin"
        Me.btnWin.Size = New System.Drawing.Size(108, 32)
        Me.btnWin.TabIndex = 0
        Me.btnWin.Text = "Bloq. Win"
        Me.btnWin.UseVisualStyleBackColor = True
        '
        'btnRei
        '
        Me.btnRei.Location = New System.Drawing.Point(114, 2)
        Me.btnRei.Name = "btnRei"
        Me.btnRei.Size = New System.Drawing.Size(118, 32)
        Me.btnRei.TabIndex = 1
        Me.btnRei.Text = "Reiniciar"
        Me.btnRei.UseVisualStyleBackColor = True
        '
        'btnApa
        '
        Me.btnApa.Location = New System.Drawing.Point(238, 2)
        Me.btnApa.Name = "btnApa"
        Me.btnApa.Size = New System.Drawing.Size(108, 32)
        Me.btnApa.TabIndex = 2
        Me.btnApa.Text = "Apagar"
        Me.btnApa.UseVisualStyleBackColor = True
        '
        'header
        '
        Me.header.BackColor = System.Drawing.Color.FromArgb(107, 114, 128)
        Me.header.Controls.Add(Me.lblEstado)
        Me.header.Controls.Add(Me.lblNombre)
        Me.header.Dock = System.Windows.Forms.DockStyle.Top
        Me.header.Location = New System.Drawing.Point(0, 0)
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(372, 56)
        Me.header.TabIndex = 1
        '
        'lblNombre
        '
        Me.lblNombre.AutoEllipsis = True
        Me.lblNombre.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblNombre.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblNombre.ForeColor = System.Drawing.Color.White
        Me.lblNombre.Location = New System.Drawing.Point(0, 0)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Padding = New System.Windows.Forms.Padding(12, 0, 0, 0)
        Me.lblNombre.Size = New System.Drawing.Size(200, 56)
        Me.lblNombre.TabIndex = 0
        Me.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEstado
        '
        Me.lblEstado.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblEstado.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblEstado.ForeColor = System.Drawing.Color.White
        Me.lblEstado.Location = New System.Drawing.Point(212, 0)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Padding = New System.Windows.Forms.Padding(0, 0, 12, 0)
        Me.lblEstado.Size = New System.Drawing.Size(160, 56)
        Me.lblEstado.TabIndex = 1
        Me.lblEstado.Text = "● ..."
        Me.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'EquipoCard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.grid)
        Me.Controls.Add(Me.header)
        Me.Margin = New System.Windows.Forms.Padding(10)
        Me.Name = "EquipoCard"
        Me.Size = New System.Drawing.Size(372, 300)
        CType(Me.numH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grid.ResumeLayout(False)
        Me.rT.ResumeLayout(False)
        Me.rT.PerformLayout()
        Me.rB.ResumeLayout(False)
        Me.rM.ResumeLayout(False)
        Me.rM.PerformLayout()
        Me.rP.ResumeLayout(False)
        Me.header.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grid As TableLayoutPanel
    Friend WithEvents lblIp As Label
    Friend WithEvents rT As Panel
    Friend WithEvents lh As Label
    Friend WithEvents numH As NumericUpDown
    Friend WithEvents lm As Label
    Friend WithEvents numM As NumericUpDown
    Friend WithEvents btnIniciar As Button
    Friend WithEvents btnAnadir As Button
    Friend WithEvents rB As Panel
    Friend WithEvents btnBloq As Button
    Friend WithEvents btnDesbloq As Button
    Friend WithEvents btnVer As Button
    Friend WithEvents rM As Panel
    Friend WithEvents txtMsg As TextBox
    Friend WithEvents btnMsg As Button
    Friend WithEvents rP As Panel
    Friend WithEvents btnWin As Button
    Friend WithEvents btnRei As Button
    Friend WithEvents btnApa As Button
    Friend WithEvents header As Panel
    Friend WithEvents lblNombre As Label
    Friend WithEvents lblEstado As Label
End Class
