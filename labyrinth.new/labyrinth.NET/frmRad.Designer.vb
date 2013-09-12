<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmRad
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
	End Sub
	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents cmdZoomIn As System.Windows.Forms.Button
	Public WithEvents cmdZoomOut As System.Windows.Forms.Button
	Public WithEvents lbALL As System.Windows.Forms.Label
	Public WithEvents lbZones As System.Windows.Forms.Label
	Public WithEvents lbZoom As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmRad))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdZoomIn = New System.Windows.Forms.Button
		Me.cmdZoomOut = New System.Windows.Forms.Button
		Me.lbALL = New System.Windows.Forms.Label
		Me.lbZones = New System.Windows.Forms.Label
		Me.lbZoom = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Radial Map"
		Me.ClientSize = New System.Drawing.Size(716, 587)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.KeyPreview = True
		Me.MaximizeBox = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ControlBox = True
		Me.Enabled = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmRad"
		Me.cmdZoomIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdZoomIn.Text = "Zoom &In"
		Me.cmdZoomIn.Size = New System.Drawing.Size(83, 35)
		Me.cmdZoomIn.Location = New System.Drawing.Point(6, 548)
		Me.cmdZoomIn.TabIndex = 1
		Me.cmdZoomIn.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdZoomIn.BackColor = System.Drawing.SystemColors.Control
		Me.cmdZoomIn.CausesValidation = True
		Me.cmdZoomIn.Enabled = True
		Me.cmdZoomIn.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdZoomIn.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdZoomIn.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdZoomIn.TabStop = True
		Me.cmdZoomIn.Name = "cmdZoomIn"
		Me.cmdZoomOut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdZoomOut.Text = "Zoom &Out"
		Me.cmdZoomOut.Size = New System.Drawing.Size(83, 35)
		Me.cmdZoomOut.Location = New System.Drawing.Point(94, 548)
		Me.cmdZoomOut.TabIndex = 0
		Me.cmdZoomOut.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdZoomOut.BackColor = System.Drawing.SystemColors.Control
		Me.cmdZoomOut.CausesValidation = True
		Me.cmdZoomOut.Enabled = True
		Me.cmdZoomOut.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdZoomOut.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdZoomOut.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdZoomOut.TabStop = True
		Me.cmdZoomOut.Name = "cmdZoomOut"
		Me.lbALL.Text = "Label1"
		Me.lbALL.Size = New System.Drawing.Size(89, 17)
		Me.lbALL.Location = New System.Drawing.Point(274, 564)
		Me.lbALL.TabIndex = 4
		Me.lbALL.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lbALL.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lbALL.BackColor = System.Drawing.SystemColors.Control
		Me.lbALL.Enabled = True
		Me.lbALL.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lbALL.Cursor = System.Windows.Forms.Cursors.Default
		Me.lbALL.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lbALL.UseMnemonic = True
		Me.lbALL.Visible = True
		Me.lbALL.AutoSize = False
		Me.lbALL.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lbALL.Name = "lbALL"
		Me.lbZones.Text = "Label1"
		Me.lbZones.Size = New System.Drawing.Size(89, 17)
		Me.lbZones.Location = New System.Drawing.Point(180, 564)
		Me.lbZones.TabIndex = 3
		Me.lbZones.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lbZones.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lbZones.BackColor = System.Drawing.SystemColors.Control
		Me.lbZones.Enabled = True
		Me.lbZones.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lbZones.Cursor = System.Windows.Forms.Cursors.Default
		Me.lbZones.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lbZones.UseMnemonic = True
		Me.lbZones.Visible = True
		Me.lbZones.AutoSize = False
		Me.lbZones.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lbZones.Name = "lbZones"
		Me.lbZoom.Text = "Label1"
		Me.lbZoom.Size = New System.Drawing.Size(81, 17)
		Me.lbZoom.Location = New System.Drawing.Point(6, 528)
		Me.lbZoom.TabIndex = 2
		Me.lbZoom.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lbZoom.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lbZoom.BackColor = System.Drawing.SystemColors.Control
		Me.lbZoom.Enabled = True
		Me.lbZoom.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lbZoom.Cursor = System.Windows.Forms.Cursors.Default
		Me.lbZoom.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lbZoom.UseMnemonic = True
		Me.lbZoom.Visible = True
		Me.lbZoom.AutoSize = False
		Me.lbZoom.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lbZoom.Name = "lbZoom"
		Me.Controls.Add(cmdZoomIn)
		Me.Controls.Add(cmdZoomOut)
		Me.Controls.Add(lbALL)
		Me.Controls.Add(lbZones)
		Me.Controls.Add(lbZoom)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class