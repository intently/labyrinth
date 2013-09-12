<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmStore
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
	Public WithEvents txCur As System.Windows.Forms.TextBox
	Public WithEvents frCurrent As System.Windows.Forms.GroupBox
	Public WithEvents cmdID As System.Windows.Forms.Button
	Public WithEvents cmdDone As System.Windows.Forms.Button
	Public WithEvents txGold As System.Windows.Forms.TextBox
	Public WithEvents lstStore As System.Windows.Forms.ListBox
	Public WithEvents lstInven As System.Windows.Forms.ListBox
	Public WithEvents lblGold As System.Windows.Forms.Label
	Public WithEvents frStore As System.Windows.Forms.GroupBox
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmStore))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.frCurrent = New System.Windows.Forms.GroupBox
		Me.txCur = New System.Windows.Forms.TextBox
		Me.frStore = New System.Windows.Forms.GroupBox
		Me.cmdID = New System.Windows.Forms.Button
		Me.cmdDone = New System.Windows.Forms.Button
		Me.txGold = New System.Windows.Forms.TextBox
		Me.lstStore = New System.Windows.Forms.ListBox
		Me.lstInven = New System.Windows.Forms.ListBox
		Me.lblGold = New System.Windows.Forms.Label
		Me.frCurrent.SuspendLayout()
		Me.frStore.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Store"
		Me.ClientSize = New System.Drawing.Size(720, 435)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.KeyPreview = True
		Me.MaximizeBox = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.ControlBox = True
		Me.Enabled = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmStore"
		Me.frCurrent.Text = "Current Item"
		Me.frCurrent.Size = New System.Drawing.Size(719, 41)
		Me.frCurrent.Location = New System.Drawing.Point(0, 392)
		Me.frCurrent.TabIndex = 6
		Me.frCurrent.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.frCurrent.BackColor = System.Drawing.SystemColors.Control
		Me.frCurrent.Enabled = True
		Me.frCurrent.ForeColor = System.Drawing.SystemColors.ControlText
		Me.frCurrent.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.frCurrent.Visible = True
		Me.frCurrent.Padding = New System.Windows.Forms.Padding(0)
		Me.frCurrent.Name = "frCurrent"
		Me.txCur.AutoSize = False
		Me.txCur.Size = New System.Drawing.Size(703, 19)
		Me.txCur.Location = New System.Drawing.Point(8, 16)
		Me.txCur.ReadOnly = True
		Me.txCur.TabIndex = 7
		Me.txCur.Text = "Text1"
		Me.txCur.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txCur.AcceptsReturn = True
		Me.txCur.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txCur.BackColor = System.Drawing.SystemColors.Window
		Me.txCur.CausesValidation = True
		Me.txCur.Enabled = True
		Me.txCur.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txCur.HideSelection = True
		Me.txCur.Maxlength = 0
		Me.txCur.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txCur.MultiLine = False
		Me.txCur.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txCur.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txCur.TabStop = True
		Me.txCur.Visible = True
		Me.txCur.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txCur.Name = "txCur"
		Me.frStore.Text = "Frame1"
		Me.frStore.Size = New System.Drawing.Size(719, 393)
		Me.frStore.Location = New System.Drawing.Point(0, 0)
		Me.frStore.TabIndex = 0
		Me.frStore.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.frStore.BackColor = System.Drawing.SystemColors.Control
		Me.frStore.Enabled = True
		Me.frStore.ForeColor = System.Drawing.SystemColors.ControlText
		Me.frStore.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.frStore.Visible = True
		Me.frStore.Padding = New System.Windows.Forms.Padding(0)
		Me.frStore.Name = "frStore"
		Me.cmdID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdID.Text = "Identify"
		Me.cmdID.Size = New System.Drawing.Size(89, 17)
		Me.cmdID.Location = New System.Drawing.Point(136, 16)
		Me.cmdID.TabIndex = 8
		Me.cmdID.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdID.BackColor = System.Drawing.SystemColors.Control
		Me.cmdID.CausesValidation = True
		Me.cmdID.Enabled = True
		Me.cmdID.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdID.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdID.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdID.TabStop = True
		Me.cmdID.Name = "cmdID"
		Me.cmdDone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDone.Text = "Done"
		Me.cmdDone.Size = New System.Drawing.Size(89, 17)
		Me.cmdDone.Location = New System.Drawing.Point(620, 16)
		Me.cmdDone.TabIndex = 5
		Me.cmdDone.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdDone.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDone.CausesValidation = True
		Me.cmdDone.Enabled = True
		Me.cmdDone.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDone.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDone.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDone.TabStop = True
		Me.cmdDone.Name = "cmdDone"
		Me.txGold.AutoSize = False
		Me.txGold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txGold.Size = New System.Drawing.Size(65, 19)
		Me.txGold.Location = New System.Drawing.Point(64, 16)
		Me.txGold.ReadOnly = True
		Me.txGold.TabIndex = 4
		Me.txGold.Text = "Text1"
		Me.txGold.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txGold.AcceptsReturn = True
		Me.txGold.BackColor = System.Drawing.SystemColors.Window
		Me.txGold.CausesValidation = True
		Me.txGold.Enabled = True
		Me.txGold.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txGold.HideSelection = True
		Me.txGold.Maxlength = 0
		Me.txGold.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txGold.MultiLine = False
		Me.txGold.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txGold.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txGold.TabStop = True
		Me.txGold.Visible = True
		Me.txGold.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txGold.Name = "txGold"
		Me.lstStore.Size = New System.Drawing.Size(345, 345)
		Me.lstStore.Location = New System.Drawing.Point(364, 40)
		Me.lstStore.Sorted = True
		Me.lstStore.TabIndex = 2
		Me.lstStore.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lstStore.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lstStore.BackColor = System.Drawing.SystemColors.Window
		Me.lstStore.CausesValidation = True
		Me.lstStore.Enabled = True
		Me.lstStore.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lstStore.IntegralHeight = True
		Me.lstStore.Cursor = System.Windows.Forms.Cursors.Default
		Me.lstStore.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.lstStore.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lstStore.TabStop = True
		Me.lstStore.Visible = True
		Me.lstStore.MultiColumn = False
		Me.lstStore.Name = "lstStore"
		Me.lstInven.Size = New System.Drawing.Size(345, 345)
		Me.lstInven.Location = New System.Drawing.Point(8, 40)
		Me.lstInven.Sorted = True
		Me.lstInven.TabIndex = 1
		Me.lstInven.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lstInven.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lstInven.BackColor = System.Drawing.SystemColors.Window
		Me.lstInven.CausesValidation = True
		Me.lstInven.Enabled = True
		Me.lstInven.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lstInven.IntegralHeight = True
		Me.lstInven.Cursor = System.Windows.Forms.Cursors.Default
		Me.lstInven.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.lstInven.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lstInven.TabStop = True
		Me.lstInven.Visible = True
		Me.lstInven.MultiColumn = False
		Me.lstInven.Name = "lstInven"
		Me.lblGold.Text = "Gold Coins"
		Me.lblGold.Size = New System.Drawing.Size(57, 17)
		Me.lblGold.Location = New System.Drawing.Point(8, 16)
		Me.lblGold.TabIndex = 3
		Me.lblGold.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblGold.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblGold.BackColor = System.Drawing.SystemColors.Control
		Me.lblGold.Enabled = True
		Me.lblGold.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblGold.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblGold.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblGold.UseMnemonic = True
		Me.lblGold.Visible = True
		Me.lblGold.AutoSize = False
		Me.lblGold.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblGold.Name = "lblGold"
		Me.Controls.Add(frCurrent)
		Me.Controls.Add(frStore)
		Me.frCurrent.Controls.Add(txCur)
		Me.frStore.Controls.Add(cmdID)
		Me.frStore.Controls.Add(cmdDone)
		Me.frStore.Controls.Add(txGold)
		Me.frStore.Controls.Add(lstStore)
		Me.frStore.Controls.Add(lstInven)
		Me.frStore.Controls.Add(lblGold)
		Me.frCurrent.ResumeLayout(False)
		Me.frStore.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class