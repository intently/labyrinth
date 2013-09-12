<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmCombat
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
	Public WithEvents lstSpells As AxCTLISTLib.AxctList
	Public WithEvents cmdLook As System.Windows.Forms.Button
	Public WithEvents cmdWait As System.Windows.Forms.Button
	Public WithEvents txEnemyName As System.Windows.Forms.TextBox
	Public WithEvents txHP As System.Windows.Forms.TextBox
	Public WithEvents cmdRun As System.Windows.Forms.Button
	Public WithEvents cmdInven As System.Windows.Forms.Button
	Public WithEvents cmdAttack As System.Windows.Forms.Button
	Public WithEvents lstEvents As System.Windows.Forms.ListBox
	Public WithEvents lblEnemyName As System.Windows.Forms.Label
	Public WithEvents lblHP As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCombat))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.lstSpells = New AxCTLISTLib.AxctList
		Me.cmdLook = New System.Windows.Forms.Button
		Me.cmdWait = New System.Windows.Forms.Button
		Me.txEnemyName = New System.Windows.Forms.TextBox
		Me.txHP = New System.Windows.Forms.TextBox
		Me.cmdRun = New System.Windows.Forms.Button
		Me.cmdInven = New System.Windows.Forms.Button
		Me.cmdAttack = New System.Windows.Forms.Button
		Me.lstEvents = New System.Windows.Forms.ListBox
		Me.lblEnemyName = New System.Windows.Forms.Label
		Me.lblHP = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.lstSpells, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Combat"
		Me.ClientSize = New System.Drawing.Size(381, 510)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.MaximizeBox = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmCombat"
		lstSpells.OcxState = CType(resources.GetObject("lstSpells.OcxState"), System.Windows.Forms.AxHost.State)
		Me.lstSpells.Size = New System.Drawing.Size(379, 249)
		Me.lstSpells.Location = New System.Drawing.Point(0, 260)
		Me.lstSpells.TabIndex = 10
		Me.lstSpells.Name = "lstSpells"
		Me.cmdLook.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdLook.Text = "Examine"
		Me.cmdLook.Size = New System.Drawing.Size(65, 17)
		Me.cmdLook.Location = New System.Drawing.Point(112, 200)
		Me.cmdLook.TabIndex = 5
		Me.cmdLook.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdLook.BackColor = System.Drawing.SystemColors.Control
		Me.cmdLook.CausesValidation = True
		Me.cmdLook.Enabled = True
		Me.cmdLook.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdLook.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdLook.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdLook.TabStop = True
		Me.cmdLook.Name = "cmdLook"
		Me.cmdWait.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdWait.Text = "Wait"
		Me.cmdWait.Size = New System.Drawing.Size(81, 33)
		Me.cmdWait.Location = New System.Drawing.Point(100, 224)
		Me.cmdWait.TabIndex = 2
		Me.cmdWait.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdWait.BackColor = System.Drawing.SystemColors.Control
		Me.cmdWait.CausesValidation = True
		Me.cmdWait.Enabled = True
		Me.cmdWait.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdWait.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdWait.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdWait.TabStop = True
		Me.cmdWait.Name = "cmdWait"
		Me.txEnemyName.AutoSize = False
		Me.txEnemyName.Size = New System.Drawing.Size(129, 19)
		Me.txEnemyName.Location = New System.Drawing.Point(250, 200)
		Me.txEnemyName.ReadOnly = True
		Me.txEnemyName.TabIndex = 8
		Me.txEnemyName.TabStop = False
		Me.txEnemyName.Text = "Text1"
		Me.txEnemyName.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txEnemyName.AcceptsReturn = True
		Me.txEnemyName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txEnemyName.BackColor = System.Drawing.SystemColors.Window
		Me.txEnemyName.CausesValidation = True
		Me.txEnemyName.Enabled = True
		Me.txEnemyName.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txEnemyName.HideSelection = True
		Me.txEnemyName.Maxlength = 0
		Me.txEnemyName.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txEnemyName.MultiLine = False
		Me.txEnemyName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txEnemyName.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txEnemyName.Visible = True
		Me.txEnemyName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txEnemyName.Name = "txEnemyName"
		Me.txHP.AutoSize = False
		Me.txHP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txHP.Size = New System.Drawing.Size(57, 19)
		Me.txHP.Location = New System.Drawing.Point(48, 200)
		Me.txHP.ReadOnly = True
		Me.txHP.TabIndex = 7
		Me.txHP.TabStop = False
		Me.txHP.Text = "Text1"
		Me.txHP.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txHP.AcceptsReturn = True
		Me.txHP.BackColor = System.Drawing.SystemColors.Window
		Me.txHP.CausesValidation = True
		Me.txHP.Enabled = True
		Me.txHP.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txHP.HideSelection = True
		Me.txHP.Maxlength = 0
		Me.txHP.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txHP.MultiLine = False
		Me.txHP.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txHP.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txHP.Visible = True
		Me.txHP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txHP.Name = "txHP"
		Me.cmdRun.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRun.Text = "Flee"
		Me.cmdRun.Size = New System.Drawing.Size(81, 33)
		Me.cmdRun.Location = New System.Drawing.Point(300, 224)
		Me.cmdRun.TabIndex = 4
		Me.cmdRun.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdRun.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRun.CausesValidation = True
		Me.cmdRun.Enabled = True
		Me.cmdRun.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRun.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRun.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRun.TabStop = True
		Me.cmdRun.Name = "cmdRun"
		Me.cmdInven.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdInven.Text = "Inventory"
		Me.cmdInven.Size = New System.Drawing.Size(81, 33)
		Me.cmdInven.Location = New System.Drawing.Point(200, 224)
		Me.cmdInven.TabIndex = 3
		Me.cmdInven.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdInven.BackColor = System.Drawing.SystemColors.Control
		Me.cmdInven.CausesValidation = True
		Me.cmdInven.Enabled = True
		Me.cmdInven.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdInven.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdInven.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdInven.TabStop = True
		Me.cmdInven.Name = "cmdInven"
		Me.cmdAttack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAttack.Text = "Attack"
		Me.cmdAttack.Size = New System.Drawing.Size(81, 33)
		Me.cmdAttack.Location = New System.Drawing.Point(0, 224)
		Me.cmdAttack.TabIndex = 1
		Me.cmdAttack.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdAttack.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAttack.CausesValidation = True
		Me.cmdAttack.Enabled = True
		Me.cmdAttack.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAttack.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAttack.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAttack.TabStop = True
		Me.cmdAttack.Name = "cmdAttack"
		Me.lstEvents.Size = New System.Drawing.Size(379, 202)
		Me.lstEvents.Location = New System.Drawing.Point(0, 0)
		Me.lstEvents.TabIndex = 0
		Me.lstEvents.TabStop = False
		Me.lstEvents.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lstEvents.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lstEvents.BackColor = System.Drawing.SystemColors.Window
		Me.lstEvents.CausesValidation = True
		Me.lstEvents.Enabled = True
		Me.lstEvents.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lstEvents.IntegralHeight = True
		Me.lstEvents.Cursor = System.Windows.Forms.Cursors.Default
		Me.lstEvents.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.lstEvents.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lstEvents.Sorted = False
		Me.lstEvents.Visible = True
		Me.lstEvents.MultiColumn = False
		Me.lstEvents.Name = "lstEvents"
		Me.lblEnemyName.Text = "Enemy Name"
		Me.lblEnemyName.Size = New System.Drawing.Size(65, 17)
		Me.lblEnemyName.Location = New System.Drawing.Point(184, 200)
		Me.lblEnemyName.TabIndex = 9
		Me.lblEnemyName.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblEnemyName.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblEnemyName.BackColor = System.Drawing.SystemColors.Control
		Me.lblEnemyName.Enabled = True
		Me.lblEnemyName.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblEnemyName.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblEnemyName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblEnemyName.UseMnemonic = True
		Me.lblEnemyName.Visible = True
		Me.lblEnemyName.AutoSize = False
		Me.lblEnemyName.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblEnemyName.Name = "lblEnemyName"
		Me.lblHP.Text = "Hit Points"
		Me.lblHP.Size = New System.Drawing.Size(57, 17)
		Me.lblHP.Location = New System.Drawing.Point(0, 200)
		Me.lblHP.TabIndex = 6
		Me.lblHP.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblHP.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblHP.BackColor = System.Drawing.SystemColors.Control
		Me.lblHP.Enabled = True
		Me.lblHP.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblHP.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblHP.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblHP.UseMnemonic = True
		Me.lblHP.Visible = True
		Me.lblHP.AutoSize = False
		Me.lblHP.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblHP.Name = "lblHP"
		Me.Controls.Add(lstSpells)
		Me.Controls.Add(cmdLook)
		Me.Controls.Add(cmdWait)
		Me.Controls.Add(txEnemyName)
		Me.Controls.Add(txHP)
		Me.Controls.Add(cmdRun)
		Me.Controls.Add(cmdInven)
		Me.Controls.Add(cmdAttack)
		Me.Controls.Add(lstEvents)
		Me.Controls.Add(lblEnemyName)
		Me.Controls.Add(lblHP)
		CType(Me.lstSpells, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class