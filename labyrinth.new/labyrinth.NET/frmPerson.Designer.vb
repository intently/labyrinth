<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmPerson
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
	Public WithEvents cmdBeg As System.Windows.Forms.Button
	Public WithEvents cmdMonsters As System.Windows.Forms.Button
	Public WithEvents cmdHelp As System.Windows.Forms.Button
	Public WithEvents cmdRumors As System.Windows.Forms.Button
	Public WithEvents cmdItems As System.Windows.Forms.Button
	Public WithEvents cmdPlaces As System.Windows.Forms.Button
	Public WithEvents frCity As System.Windows.Forms.GroupBox
	Public WithEvents cmdLeave As System.Windows.Forms.Button
	Public WithEvents txInfo As System.Windows.Forms.TextBox
	Public WithEvents frInfo As System.Windows.Forms.GroupBox
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPerson))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.frCity = New System.Windows.Forms.GroupBox
		Me.cmdBeg = New System.Windows.Forms.Button
		Me.cmdMonsters = New System.Windows.Forms.Button
		Me.cmdHelp = New System.Windows.Forms.Button
		Me.cmdRumors = New System.Windows.Forms.Button
		Me.cmdItems = New System.Windows.Forms.Button
		Me.cmdPlaces = New System.Windows.Forms.Button
		Me.frInfo = New System.Windows.Forms.GroupBox
		Me.cmdLeave = New System.Windows.Forms.Button
		Me.txInfo = New System.Windows.Forms.TextBox
		Me.frCity.SuspendLayout()
		Me.frInfo.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.Text = "Person"
		Me.ClientSize = New System.Drawing.Size(235, 258)
		Me.Location = New System.Drawing.Point(4, 23)
		Me.KeyPreview = True
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.ControlBox = True
		Me.Enabled = True
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmPerson"
		Me.frCity.Text = "Actions"
		Me.frCity.Size = New System.Drawing.Size(97, 257)
		Me.frCity.Location = New System.Drawing.Point(136, 0)
		Me.frCity.TabIndex = 3
		Me.frCity.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.frCity.BackColor = System.Drawing.SystemColors.Control
		Me.frCity.Enabled = True
		Me.frCity.ForeColor = System.Drawing.SystemColors.ControlText
		Me.frCity.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.frCity.Visible = True
		Me.frCity.Padding = New System.Windows.Forms.Padding(0)
		Me.frCity.Name = "frCity"
		Me.cmdBeg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdBeg.Text = "Beg"
		Me.cmdBeg.Size = New System.Drawing.Size(81, 33)
		Me.cmdBeg.Location = New System.Drawing.Point(8, 216)
		Me.cmdBeg.TabIndex = 9
		Me.cmdBeg.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdBeg.BackColor = System.Drawing.SystemColors.Control
		Me.cmdBeg.CausesValidation = True
		Me.cmdBeg.Enabled = True
		Me.cmdBeg.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdBeg.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdBeg.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdBeg.TabStop = True
		Me.cmdBeg.Name = "cmdBeg"
		Me.cmdMonsters.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdMonsters.Text = "Ask About Monsters"
		Me.cmdMonsters.Size = New System.Drawing.Size(81, 33)
		Me.cmdMonsters.Location = New System.Drawing.Point(8, 136)
		Me.cmdMonsters.TabIndex = 8
		Me.cmdMonsters.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdMonsters.BackColor = System.Drawing.SystemColors.Control
		Me.cmdMonsters.CausesValidation = True
		Me.cmdMonsters.Enabled = True
		Me.cmdMonsters.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdMonsters.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdMonsters.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdMonsters.TabStop = True
		Me.cmdMonsters.Name = "cmdMonsters"
		Me.cmdHelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdHelp.Text = "Converse"
		Me.cmdHelp.Size = New System.Drawing.Size(81, 33)
		Me.cmdHelp.Location = New System.Drawing.Point(8, 176)
		Me.cmdHelp.TabIndex = 7
		Me.cmdHelp.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdHelp.BackColor = System.Drawing.SystemColors.Control
		Me.cmdHelp.CausesValidation = True
		Me.cmdHelp.Enabled = True
		Me.cmdHelp.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdHelp.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdHelp.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdHelp.TabStop = True
		Me.cmdHelp.Name = "cmdHelp"
		Me.cmdRumors.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRumors.Text = "Ask About Rumors"
		Me.cmdRumors.Size = New System.Drawing.Size(81, 33)
		Me.cmdRumors.Location = New System.Drawing.Point(8, 96)
		Me.cmdRumors.TabIndex = 6
		Me.cmdRumors.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdRumors.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRumors.CausesValidation = True
		Me.cmdRumors.Enabled = True
		Me.cmdRumors.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRumors.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRumors.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRumors.TabStop = True
		Me.cmdRumors.Name = "cmdRumors"
		Me.cmdItems.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdItems.Text = "AskTo Buy Items"
		Me.cmdItems.Size = New System.Drawing.Size(81, 33)
		Me.cmdItems.Location = New System.Drawing.Point(8, 56)
		Me.cmdItems.TabIndex = 5
		Me.cmdItems.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdItems.BackColor = System.Drawing.SystemColors.Control
		Me.cmdItems.CausesValidation = True
		Me.cmdItems.Enabled = True
		Me.cmdItems.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdItems.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdItems.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdItems.TabStop = True
		Me.cmdItems.Name = "cmdItems"
		Me.cmdPlaces.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPlaces.Text = "Ask About Places"
		Me.cmdPlaces.Size = New System.Drawing.Size(81, 33)
		Me.cmdPlaces.Location = New System.Drawing.Point(8, 16)
		Me.cmdPlaces.TabIndex = 4
		Me.cmdPlaces.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdPlaces.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPlaces.CausesValidation = True
		Me.cmdPlaces.Enabled = True
		Me.cmdPlaces.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPlaces.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPlaces.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPlaces.TabStop = True
		Me.cmdPlaces.Name = "cmdPlaces"
		Me.frInfo.Size = New System.Drawing.Size(129, 257)
		Me.frInfo.Location = New System.Drawing.Point(0, 0)
		Me.frInfo.TabIndex = 0
		Me.frInfo.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.frInfo.BackColor = System.Drawing.SystemColors.Control
		Me.frInfo.Enabled = True
		Me.frInfo.ForeColor = System.Drawing.SystemColors.ControlText
		Me.frInfo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.frInfo.Visible = True
		Me.frInfo.Padding = New System.Windows.Forms.Padding(0)
		Me.frInfo.Name = "frInfo"
		Me.cmdLeave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdLeave.Text = "Leave"
		Me.cmdLeave.Size = New System.Drawing.Size(81, 33)
		Me.cmdLeave.Location = New System.Drawing.Point(24, 216)
		Me.cmdLeave.TabIndex = 2
		Me.cmdLeave.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdLeave.BackColor = System.Drawing.SystemColors.Control
		Me.cmdLeave.CausesValidation = True
		Me.cmdLeave.Enabled = True
		Me.cmdLeave.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdLeave.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdLeave.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdLeave.TabStop = True
		Me.cmdLeave.Name = "cmdLeave"
		Me.txInfo.AutoSize = False
		Me.txInfo.Size = New System.Drawing.Size(113, 193)
		Me.txInfo.Location = New System.Drawing.Point(8, 16)
		Me.txInfo.MultiLine = True
		Me.txInfo.TabIndex = 1
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
		Me.Controls.Add(frCity)
		Me.Controls.Add(frInfo)
		Me.frCity.Controls.Add(cmdBeg)
		Me.frCity.Controls.Add(cmdMonsters)
		Me.frCity.Controls.Add(cmdHelp)
		Me.frCity.Controls.Add(cmdRumors)
		Me.frCity.Controls.Add(cmdItems)
		Me.frCity.Controls.Add(cmdPlaces)
		Me.frInfo.Controls.Add(cmdLeave)
		Me.frInfo.Controls.Add(txInfo)
		Me.frCity.ResumeLayout(False)
		Me.frInfo.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class