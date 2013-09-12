<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmStart
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
	Public WithEvents _ckStatus_6 As System.Windows.Forms.CheckBox
	Public WithEvents _ckStatus_5 As System.Windows.Forms.CheckBox
	Public WithEvents _ckStatus_4 As System.Windows.Forms.CheckBox
	Public WithEvents _ckStatus_3 As System.Windows.Forms.CheckBox
	Public WithEvents _ckStatus_2 As System.Windows.Forms.CheckBox
	Public WithEvents _ckStatus_1 As System.Windows.Forms.CheckBox
	Public WithEvents _ckStatus_0 As System.Windows.Forms.CheckBox
	Public WithEvents frStatus As System.Windows.Forms.GroupBox
	Public WithEvents cmdQuit As System.Windows.Forms.Button
	Public WithEvents cmdStart As System.Windows.Forms.Button
	Public WithEvents ckStatus As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmStart))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.frStatus = New System.Windows.Forms.GroupBox
		Me._ckStatus_6 = New System.Windows.Forms.CheckBox
		Me._ckStatus_5 = New System.Windows.Forms.CheckBox
		Me._ckStatus_4 = New System.Windows.Forms.CheckBox
		Me._ckStatus_3 = New System.Windows.Forms.CheckBox
		Me._ckStatus_2 = New System.Windows.Forms.CheckBox
		Me._ckStatus_1 = New System.Windows.Forms.CheckBox
		Me._ckStatus_0 = New System.Windows.Forms.CheckBox
		Me.cmdQuit = New System.Windows.Forms.Button
		Me.cmdStart = New System.Windows.Forms.Button
		Me.ckStatus = New Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray(components)
		Me.frStatus.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.ckStatus, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Labyrinth"
		Me.ClientSize = New System.Drawing.Size(122, 299)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmStart"
		Me.frStatus.Text = "Status"
		Me.frStatus.Size = New System.Drawing.Size(121, 201)
		Me.frStatus.Location = New System.Drawing.Point(0, 96)
		Me.frStatus.TabIndex = 2
		Me.frStatus.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.frStatus.BackColor = System.Drawing.SystemColors.Control
		Me.frStatus.Enabled = True
		Me.frStatus.ForeColor = System.Drawing.SystemColors.ControlText
		Me.frStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.frStatus.Visible = True
		Me.frStatus.Padding = New System.Windows.Forms.Padding(0)
		Me.frStatus.Name = "frStatus"
		Me._ckStatus_6.Text = "(6) Specials"
		Me._ckStatus_6.Enabled = False
		Me._ckStatus_6.Size = New System.Drawing.Size(105, 33)
		Me._ckStatus_6.Location = New System.Drawing.Point(8, 160)
		Me._ckStatus_6.TabIndex = 9
		Me._ckStatus_6.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._ckStatus_6.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._ckStatus_6.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me._ckStatus_6.BackColor = System.Drawing.SystemColors.Control
		Me._ckStatus_6.CausesValidation = True
		Me._ckStatus_6.ForeColor = System.Drawing.SystemColors.ControlText
		Me._ckStatus_6.Cursor = System.Windows.Forms.Cursors.Default
		Me._ckStatus_6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._ckStatus_6.Appearance = System.Windows.Forms.Appearance.Normal
		Me._ckStatus_6.TabStop = True
		Me._ckStatus_6.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._ckStatus_6.Visible = True
		Me._ckStatus_6.Name = "_ckStatus_6"
		Me._ckStatus_5.Text = "(5) Regions"
		Me._ckStatus_5.Enabled = False
		Me._ckStatus_5.Size = New System.Drawing.Size(105, 33)
		Me._ckStatus_5.Location = New System.Drawing.Point(8, 136)
		Me._ckStatus_5.TabIndex = 8
		Me._ckStatus_5.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._ckStatus_5.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._ckStatus_5.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me._ckStatus_5.BackColor = System.Drawing.SystemColors.Control
		Me._ckStatus_5.CausesValidation = True
		Me._ckStatus_5.ForeColor = System.Drawing.SystemColors.ControlText
		Me._ckStatus_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._ckStatus_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._ckStatus_5.Appearance = System.Windows.Forms.Appearance.Normal
		Me._ckStatus_5.TabStop = True
		Me._ckStatus_5.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._ckStatus_5.Visible = True
		Me._ckStatus_5.Name = "_ckStatus_5"
		Me._ckStatus_4.Text = "(4) Depth"
		Me._ckStatus_4.Enabled = False
		Me._ckStatus_4.Size = New System.Drawing.Size(105, 33)
		Me._ckStatus_4.Location = New System.Drawing.Point(8, 112)
		Me._ckStatus_4.TabIndex = 7
		Me._ckStatus_4.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._ckStatus_4.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._ckStatus_4.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me._ckStatus_4.BackColor = System.Drawing.SystemColors.Control
		Me._ckStatus_4.CausesValidation = True
		Me._ckStatus_4.ForeColor = System.Drawing.SystemColors.ControlText
		Me._ckStatus_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._ckStatus_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._ckStatus_4.Appearance = System.Windows.Forms.Appearance.Normal
		Me._ckStatus_4.TabStop = True
		Me._ckStatus_4.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._ckStatus_4.Visible = True
		Me._ckStatus_4.Name = "_ckStatus_4"
		Me._ckStatus_3.Text = "(3) Sort"
		Me._ckStatus_3.Enabled = False
		Me._ckStatus_3.Size = New System.Drawing.Size(105, 33)
		Me._ckStatus_3.Location = New System.Drawing.Point(8, 88)
		Me._ckStatus_3.TabIndex = 6
		Me._ckStatus_3.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._ckStatus_3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._ckStatus_3.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me._ckStatus_3.BackColor = System.Drawing.SystemColors.Control
		Me._ckStatus_3.CausesValidation = True
		Me._ckStatus_3.ForeColor = System.Drawing.SystemColors.ControlText
		Me._ckStatus_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._ckStatus_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._ckStatus_3.Appearance = System.Windows.Forms.Appearance.Normal
		Me._ckStatus_3.TabStop = True
		Me._ckStatus_3.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._ckStatus_3.Visible = True
		Me._ckStatus_3.Name = "_ckStatus_3"
		Me._ckStatus_2.Text = "(2) Renumber"
		Me._ckStatus_2.Enabled = False
		Me._ckStatus_2.Size = New System.Drawing.Size(105, 33)
		Me._ckStatus_2.Location = New System.Drawing.Point(8, 64)
		Me._ckStatus_2.TabIndex = 5
		Me._ckStatus_2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._ckStatus_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._ckStatus_2.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me._ckStatus_2.BackColor = System.Drawing.SystemColors.Control
		Me._ckStatus_2.CausesValidation = True
		Me._ckStatus_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._ckStatus_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._ckStatus_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._ckStatus_2.Appearance = System.Windows.Forms.Appearance.Normal
		Me._ckStatus_2.TabStop = True
		Me._ckStatus_2.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._ckStatus_2.Visible = True
		Me._ckStatus_2.Name = "_ckStatus_2"
		Me._ckStatus_1.Text = "(1) Connect"
		Me._ckStatus_1.Enabled = False
		Me._ckStatus_1.Size = New System.Drawing.Size(105, 33)
		Me._ckStatus_1.Location = New System.Drawing.Point(8, 40)
		Me._ckStatus_1.TabIndex = 4
		Me._ckStatus_1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._ckStatus_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._ckStatus_1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me._ckStatus_1.BackColor = System.Drawing.SystemColors.Control
		Me._ckStatus_1.CausesValidation = True
		Me._ckStatus_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._ckStatus_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._ckStatus_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._ckStatus_1.Appearance = System.Windows.Forms.Appearance.Normal
		Me._ckStatus_1.TabStop = True
		Me._ckStatus_1.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._ckStatus_1.Visible = True
		Me._ckStatus_1.Name = "_ckStatus_1"
		Me._ckStatus_0.Text = "(0) Create Nodes"
		Me._ckStatus_0.Enabled = False
		Me._ckStatus_0.Size = New System.Drawing.Size(105, 33)
		Me._ckStatus_0.Location = New System.Drawing.Point(8, 16)
		Me._ckStatus_0.TabIndex = 3
		Me._ckStatus_0.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._ckStatus_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._ckStatus_0.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me._ckStatus_0.BackColor = System.Drawing.SystemColors.Control
		Me._ckStatus_0.CausesValidation = True
		Me._ckStatus_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._ckStatus_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._ckStatus_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._ckStatus_0.Appearance = System.Windows.Forms.Appearance.Normal
		Me._ckStatus_0.TabStop = True
		Me._ckStatus_0.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._ckStatus_0.Visible = True
		Me._ckStatus_0.Name = "_ckStatus_0"
		Me.cmdQuit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdQuit.Text = "Quit"
		Me.cmdQuit.Size = New System.Drawing.Size(121, 41)
		Me.cmdQuit.Location = New System.Drawing.Point(0, 48)
		Me.cmdQuit.TabIndex = 1
		Me.cmdQuit.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdQuit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdQuit.CausesValidation = True
		Me.cmdQuit.Enabled = True
		Me.cmdQuit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdQuit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdQuit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdQuit.TabStop = True
		Me.cmdQuit.Name = "cmdQuit"
		Me.cmdStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdStart.Text = "Start New Game"
		Me.cmdStart.Size = New System.Drawing.Size(121, 41)
		Me.cmdStart.Location = New System.Drawing.Point(0, 0)
		Me.cmdStart.TabIndex = 0
		Me.cmdStart.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdStart.BackColor = System.Drawing.SystemColors.Control
		Me.cmdStart.CausesValidation = True
		Me.cmdStart.Enabled = True
		Me.cmdStart.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdStart.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdStart.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdStart.TabStop = True
		Me.cmdStart.Name = "cmdStart"
		Me.Controls.Add(frStatus)
		Me.Controls.Add(cmdQuit)
		Me.Controls.Add(cmdStart)
		Me.frStatus.Controls.Add(_ckStatus_6)
		Me.frStatus.Controls.Add(_ckStatus_5)
		Me.frStatus.Controls.Add(_ckStatus_4)
		Me.frStatus.Controls.Add(_ckStatus_3)
		Me.frStatus.Controls.Add(_ckStatus_2)
		Me.frStatus.Controls.Add(_ckStatus_1)
		Me.frStatus.Controls.Add(_ckStatus_0)
		Me.ckStatus.SetIndex(_ckStatus_6, CType(6, Short))
		Me.ckStatus.SetIndex(_ckStatus_5, CType(5, Short))
		Me.ckStatus.SetIndex(_ckStatus_4, CType(4, Short))
		Me.ckStatus.SetIndex(_ckStatus_3, CType(3, Short))
		Me.ckStatus.SetIndex(_ckStatus_2, CType(2, Short))
		Me.ckStatus.SetIndex(_ckStatus_1, CType(1, Short))
		Me.ckStatus.SetIndex(_ckStatus_0, CType(0, Short))
		CType(Me.ckStatus, System.ComponentModel.ISupportInitialize).EndInit()
		Me.frStatus.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class