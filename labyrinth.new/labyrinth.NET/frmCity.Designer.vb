<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmCity
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
	Public WithEvents txInfo As System.Windows.Forms.TextBox
	Public WithEvents cmdLeave As System.Windows.Forms.Button
	Public WithEvents frInfo As System.Windows.Forms.GroupBox
	Public WithEvents _cmdStores_3 As System.Windows.Forms.Button
	Public WithEvents _cmdStores_4 As System.Windows.Forms.Button
	Public WithEvents _cmdStores_2 As System.Windows.Forms.Button
	Public WithEvents _cmdStores_1 As System.Windows.Forms.Button
	Public WithEvents _cmdStores_0 As System.Windows.Forms.Button
	Public WithEvents _cmdStores_5 As System.Windows.Forms.Button
	Public WithEvents cmdExplore As System.Windows.Forms.Button
	Public WithEvents frCity As System.Windows.Forms.GroupBox
	Public WithEvents cmdStores As Microsoft.VisualBasic.Compatibility.VB6.ButtonArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCity))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.frInfo = New System.Windows.Forms.GroupBox
		Me.txInfo = New System.Windows.Forms.TextBox
		Me.cmdLeave = New System.Windows.Forms.Button
		Me.frCity = New System.Windows.Forms.GroupBox
		Me._cmdStores_3 = New System.Windows.Forms.Button
		Me._cmdStores_4 = New System.Windows.Forms.Button
		Me._cmdStores_2 = New System.Windows.Forms.Button
		Me._cmdStores_1 = New System.Windows.Forms.Button
		Me._cmdStores_0 = New System.Windows.Forms.Button
		Me._cmdStores_5 = New System.Windows.Forms.Button
		Me.cmdExplore = New System.Windows.Forms.Button
		Me.cmdStores = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(components)
		Me.frInfo.SuspendLayout()
		Me.frCity.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.cmdStores, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "City"
		Me.ClientSize = New System.Drawing.Size(234, 258)
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
		Me.Name = "frmCity"
		Me.frInfo.Size = New System.Drawing.Size(129, 257)
		Me.frInfo.Location = New System.Drawing.Point(0, 0)
		Me.frInfo.TabIndex = 7
		Me.frInfo.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.frInfo.BackColor = System.Drawing.SystemColors.Control
		Me.frInfo.Enabled = True
		Me.frInfo.ForeColor = System.Drawing.SystemColors.ControlText
		Me.frInfo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.frInfo.Visible = True
		Me.frInfo.Padding = New System.Windows.Forms.Padding(0)
		Me.frInfo.Name = "frInfo"
		Me.txInfo.AutoSize = False
		Me.txInfo.Size = New System.Drawing.Size(113, 193)
		Me.txInfo.Location = New System.Drawing.Point(8, 16)
		Me.txInfo.MultiLine = True
		Me.txInfo.TabIndex = 9
		Me.txInfo.Text = "Text1"
		Me.txInfo.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txInfo.AcceptsReturn = True
		Me.txInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txInfo.BackColor = System.Drawing.SystemColors.Window
		Me.txInfo.CausesValidation = True
		Me.txInfo.Enabled = True
		Me.txInfo.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txInfo.HideSelection = True
		Me.txInfo.ReadOnly = False
		Me.txInfo.Maxlength = 0
		Me.txInfo.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txInfo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txInfo.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txInfo.TabStop = True
		Me.txInfo.Visible = True
		Me.txInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txInfo.Name = "txInfo"
		Me.cmdLeave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdLeave.Text = "Leave"
		Me.cmdLeave.Size = New System.Drawing.Size(81, 33)
		Me.cmdLeave.Location = New System.Drawing.Point(24, 216)
		Me.cmdLeave.TabIndex = 8
		Me.cmdLeave.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdLeave.BackColor = System.Drawing.SystemColors.Control
		Me.cmdLeave.CausesValidation = True
		Me.cmdLeave.Enabled = True
		Me.cmdLeave.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdLeave.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdLeave.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdLeave.TabStop = True
		Me.cmdLeave.Name = "cmdLeave"
		Me.frCity.Text = "Buildings"
		Me.frCity.Size = New System.Drawing.Size(97, 257)
		Me.frCity.Location = New System.Drawing.Point(136, 0)
		Me.frCity.TabIndex = 0
		Me.frCity.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.frCity.BackColor = System.Drawing.SystemColors.Control
		Me.frCity.Enabled = True
		Me.frCity.ForeColor = System.Drawing.SystemColors.ControlText
		Me.frCity.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.frCity.Visible = True
		Me.frCity.Padding = New System.Windows.Forms.Padding(0)
		Me.frCity.Name = "frCity"
		Me._cmdStores_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._cmdStores_3.Text = "Magic Shop"
		Me._cmdStores_3.Size = New System.Drawing.Size(81, 33)
		Me._cmdStores_3.Location = New System.Drawing.Point(8, 136)
		Me._cmdStores_3.TabIndex = 4
		Me._cmdStores_3.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._cmdStores_3.BackColor = System.Drawing.SystemColors.Control
		Me._cmdStores_3.CausesValidation = True
		Me._cmdStores_3.Enabled = True
		Me._cmdStores_3.ForeColor = System.Drawing.SystemColors.ControlText
		Me._cmdStores_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._cmdStores_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._cmdStores_3.TabStop = True
		Me._cmdStores_3.Name = "_cmdStores_3"
		Me._cmdStores_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._cmdStores_4.Text = "Inn"
		Me._cmdStores_4.Size = New System.Drawing.Size(81, 33)
		Me._cmdStores_4.Location = New System.Drawing.Point(8, 176)
		Me._cmdStores_4.TabIndex = 5
		Me._cmdStores_4.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._cmdStores_4.BackColor = System.Drawing.SystemColors.Control
		Me._cmdStores_4.CausesValidation = True
		Me._cmdStores_4.Enabled = True
		Me._cmdStores_4.ForeColor = System.Drawing.SystemColors.ControlText
		Me._cmdStores_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._cmdStores_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._cmdStores_4.TabStop = True
		Me._cmdStores_4.Name = "_cmdStores_4"
		Me._cmdStores_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._cmdStores_2.Text = "General Store"
		Me._cmdStores_2.Size = New System.Drawing.Size(81, 33)
		Me._cmdStores_2.Location = New System.Drawing.Point(8, 96)
		Me._cmdStores_2.TabIndex = 3
		Me._cmdStores_2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._cmdStores_2.BackColor = System.Drawing.SystemColors.Control
		Me._cmdStores_2.CausesValidation = True
		Me._cmdStores_2.Enabled = True
		Me._cmdStores_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._cmdStores_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._cmdStores_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._cmdStores_2.TabStop = True
		Me._cmdStores_2.Name = "_cmdStores_2"
		Me._cmdStores_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._cmdStores_1.Text = "Armor"
		Me._cmdStores_1.Size = New System.Drawing.Size(81, 33)
		Me._cmdStores_1.Location = New System.Drawing.Point(8, 56)
		Me._cmdStores_1.TabIndex = 2
		Me._cmdStores_1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._cmdStores_1.BackColor = System.Drawing.SystemColors.Control
		Me._cmdStores_1.CausesValidation = True
		Me._cmdStores_1.Enabled = True
		Me._cmdStores_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._cmdStores_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._cmdStores_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._cmdStores_1.TabStop = True
		Me._cmdStores_1.Name = "_cmdStores_1"
		Me._cmdStores_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._cmdStores_0.Text = "Weapons"
		Me._cmdStores_0.Size = New System.Drawing.Size(81, 33)
		Me._cmdStores_0.Location = New System.Drawing.Point(8, 16)
		Me._cmdStores_0.TabIndex = 1
		Me._cmdStores_0.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._cmdStores_0.BackColor = System.Drawing.SystemColors.Control
		Me._cmdStores_0.CausesValidation = True
		Me._cmdStores_0.Enabled = True
		Me._cmdStores_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._cmdStores_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._cmdStores_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._cmdStores_0.TabStop = True
		Me._cmdStores_0.Name = "_cmdStores_0"
		Me._cmdStores_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._cmdStores_5.Text = "Market"
		Me._cmdStores_5.Size = New System.Drawing.Size(81, 33)
		Me._cmdStores_5.Location = New System.Drawing.Point(8, 216)
		Me._cmdStores_5.TabIndex = 6
		Me._cmdStores_5.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._cmdStores_5.BackColor = System.Drawing.SystemColors.Control
		Me._cmdStores_5.CausesValidation = True
		Me._cmdStores_5.Enabled = True
		Me._cmdStores_5.ForeColor = System.Drawing.SystemColors.ControlText
		Me._cmdStores_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._cmdStores_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._cmdStores_5.TabStop = True
		Me._cmdStores_5.Name = "_cmdStores_5"
		Me.cmdExplore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdExplore.Text = "Explore"
		Me.cmdExplore.Size = New System.Drawing.Size(81, 33)
		Me.cmdExplore.Location = New System.Drawing.Point(8, 216)
		Me.cmdExplore.TabIndex = 10
		Me.cmdExplore.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdExplore.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExplore.CausesValidation = True
		Me.cmdExplore.Enabled = True
		Me.cmdExplore.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExplore.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExplore.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExplore.TabStop = True
		Me.cmdExplore.Name = "cmdExplore"
		Me.Controls.Add(frInfo)
		Me.Controls.Add(frCity)
		Me.frInfo.Controls.Add(txInfo)
		Me.frInfo.Controls.Add(cmdLeave)
		Me.frCity.Controls.Add(_cmdStores_3)
		Me.frCity.Controls.Add(_cmdStores_4)
		Me.frCity.Controls.Add(_cmdStores_2)
		Me.frCity.Controls.Add(_cmdStores_1)
		Me.frCity.Controls.Add(_cmdStores_0)
		Me.frCity.Controls.Add(_cmdStores_5)
		Me.frCity.Controls.Add(cmdExplore)
		Me.cmdStores.SetIndex(_cmdStores_3, CType(3, Short))
		Me.cmdStores.SetIndex(_cmdStores_4, CType(4, Short))
		Me.cmdStores.SetIndex(_cmdStores_2, CType(2, Short))
		Me.cmdStores.SetIndex(_cmdStores_1, CType(1, Short))
		Me.cmdStores.SetIndex(_cmdStores_0, CType(0, Short))
		Me.cmdStores.SetIndex(_cmdStores_5, CType(5, Short))
		CType(Me.cmdStores, System.ComponentModel.ISupportInitialize).EndInit()
		Me.frInfo.ResumeLayout(False)
		Me.frCity.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class