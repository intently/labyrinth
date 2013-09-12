<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmInven
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
	Public WithEvents txValue As System.Windows.Forms.TextBox
	Public WithEvents txCur As System.Windows.Forms.TextBox
	Public WithEvents lblValue As System.Windows.Forms.Label
	Public WithEvents frCurrent As System.Windows.Forms.GroupBox
	Public WithEvents cmdPickUp As System.Windows.Forms.Button
	Public WithEvents txPickUp As System.Windows.Forms.TextBox
	Public WithEvents lstInven As System.Windows.Forms.ListBox
	Public WithEvents frInven As System.Windows.Forms.GroupBox
	Public WithEvents cmdID As System.Windows.Forms.Button
	Public WithEvents _txRes_3 As System.Windows.Forms.TextBox
	Public WithEvents _txRes_2 As System.Windows.Forms.TextBox
	Public WithEvents _txRes_1 As System.Windows.Forms.TextBox
	Public WithEvents _txRes_0 As System.Windows.Forms.TextBox
	Public WithEvents txGold As System.Windows.Forms.TextBox
	Public WithEvents cmdDrop As System.Windows.Forms.Button
	Public WithEvents txDR As System.Windows.Forms.TextBox
	Public WithEvents txDam As System.Windows.Forms.TextBox
	Public WithEvents _txStats_0 As System.Windows.Forms.TextBox
	Public WithEvents _txStats_1 As System.Windows.Forms.TextBox
	Public WithEvents _txStats_2 As System.Windows.Forms.TextBox
	Public WithEvents _txStats_3 As System.Windows.Forms.TextBox
	Public WithEvents _txStats_4 As System.Windows.Forms.TextBox
	Public WithEvents _txStats_5 As System.Windows.Forms.TextBox
	Public WithEvents _txStats_6 As System.Windows.Forms.TextBox
	Public WithEvents _txDervs_0 As System.Windows.Forms.TextBox
	Public WithEvents _txDervs_1 As System.Windows.Forms.TextBox
	Public WithEvents _txDervs_2 As System.Windows.Forms.TextBox
	Public WithEvents _txDervs_3 As System.Windows.Forms.TextBox
	Public WithEvents _txDervs_4 As System.Windows.Forms.TextBox
	Public WithEvents _txDervs_5 As System.Windows.Forms.TextBox
	Public WithEvents _txDervs_6 As System.Windows.Forms.TextBox
	Public WithEvents _cmdUneq_7 As System.Windows.Forms.Button
	Public WithEvents _cmdUneq_6 As System.Windows.Forms.Button
	Public WithEvents _cmdUneq_5 As System.Windows.Forms.Button
	Public WithEvents _cmdUneq_4 As System.Windows.Forms.Button
	Public WithEvents _cmdUneq_3 As System.Windows.Forms.Button
	Public WithEvents _cmdUneq_2 As System.Windows.Forms.Button
	Public WithEvents _cmdUneq_1 As System.Windows.Forms.Button
	Public WithEvents _cmdUneq_0 As System.Windows.Forms.Button
	Public WithEvents cmdDone As System.Windows.Forms.Button
	Public WithEvents _txEq_7 As System.Windows.Forms.TextBox
	Public WithEvents _txEq_6 As System.Windows.Forms.TextBox
	Public WithEvents _txEq_5 As System.Windows.Forms.TextBox
	Public WithEvents _txEq_4 As System.Windows.Forms.TextBox
	Public WithEvents _txEq_3 As System.Windows.Forms.TextBox
	Public WithEvents _txEq_2 As System.Windows.Forms.TextBox
	Public WithEvents _txEq_1 As System.Windows.Forms.TextBox
	Public WithEvents _txEq_0 As System.Windows.Forms.TextBox
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents lblRFire As System.Windows.Forms.Label
	Public WithEvents lblGold As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents lblDam As System.Windows.Forms.Label
	Public WithEvents _lblStats_0 As System.Windows.Forms.Label
	Public WithEvents _lblStats_1 As System.Windows.Forms.Label
	Public WithEvents _lblStats_2 As System.Windows.Forms.Label
	Public WithEvents _lblStats_3 As System.Windows.Forms.Label
	Public WithEvents _lblStats_4 As System.Windows.Forms.Label
	Public WithEvents _lblStats_5 As System.Windows.Forms.Label
	Public WithEvents _lblStats_6 As System.Windows.Forms.Label
	Public WithEvents _lblDervs_0 As System.Windows.Forms.Label
	Public WithEvents _lblDervs_1 As System.Windows.Forms.Label
	Public WithEvents _lblDervs_2 As System.Windows.Forms.Label
	Public WithEvents _lblDervs_3 As System.Windows.Forms.Label
	Public WithEvents _lblDervs_4 As System.Windows.Forms.Label
	Public WithEvents _lblDervs_5 As System.Windows.Forms.Label
	Public WithEvents _lblDervs_6 As System.Windows.Forms.Label
	Public WithEvents _lblEq_7 As System.Windows.Forms.Label
	Public WithEvents _lblEq_6 As System.Windows.Forms.Label
	Public WithEvents _lblEq_5 As System.Windows.Forms.Label
	Public WithEvents _lblEq_4 As System.Windows.Forms.Label
	Public WithEvents _lblEq_3 As System.Windows.Forms.Label
	Public WithEvents _lblEq_2 As System.Windows.Forms.Label
	Public WithEvents _lblEq_1 As System.Windows.Forms.Label
	Public WithEvents _lblEq_0 As System.Windows.Forms.Label
	Public WithEvents frEquip As System.Windows.Forms.GroupBox
	Public WithEvents cmdUneq As Microsoft.VisualBasic.Compatibility.VB6.ButtonArray
	Public WithEvents lblDervs As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents lblEq As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents lblStats As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents txDervs As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	Public WithEvents txEq As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	Public WithEvents txRes As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	Public WithEvents txStats As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmInven))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.frCurrent = New System.Windows.Forms.GroupBox
		Me.txValue = New System.Windows.Forms.TextBox
		Me.txCur = New System.Windows.Forms.TextBox
		Me.lblValue = New System.Windows.Forms.Label
		Me.frInven = New System.Windows.Forms.GroupBox
		Me.cmdPickUp = New System.Windows.Forms.Button
		Me.txPickUp = New System.Windows.Forms.TextBox
		Me.lstInven = New System.Windows.Forms.ListBox
		Me.frEquip = New System.Windows.Forms.GroupBox
		Me.cmdID = New System.Windows.Forms.Button
		Me._txRes_3 = New System.Windows.Forms.TextBox
		Me._txRes_2 = New System.Windows.Forms.TextBox
		Me._txRes_1 = New System.Windows.Forms.TextBox
		Me._txRes_0 = New System.Windows.Forms.TextBox
		Me.txGold = New System.Windows.Forms.TextBox
		Me.cmdDrop = New System.Windows.Forms.Button
		Me.txDR = New System.Windows.Forms.TextBox
		Me.txDam = New System.Windows.Forms.TextBox
		Me._txStats_0 = New System.Windows.Forms.TextBox
		Me._txStats_1 = New System.Windows.Forms.TextBox
		Me._txStats_2 = New System.Windows.Forms.TextBox
		Me._txStats_3 = New System.Windows.Forms.TextBox
		Me._txStats_4 = New System.Windows.Forms.TextBox
		Me._txStats_5 = New System.Windows.Forms.TextBox
		Me._txStats_6 = New System.Windows.Forms.TextBox
		Me._txDervs_0 = New System.Windows.Forms.TextBox
		Me._txDervs_1 = New System.Windows.Forms.TextBox
		Me._txDervs_2 = New System.Windows.Forms.TextBox
		Me._txDervs_3 = New System.Windows.Forms.TextBox
		Me._txDervs_4 = New System.Windows.Forms.TextBox
		Me._txDervs_5 = New System.Windows.Forms.TextBox
		Me._txDervs_6 = New System.Windows.Forms.TextBox
		Me._cmdUneq_7 = New System.Windows.Forms.Button
		Me._cmdUneq_6 = New System.Windows.Forms.Button
		Me._cmdUneq_5 = New System.Windows.Forms.Button
		Me._cmdUneq_4 = New System.Windows.Forms.Button
		Me._cmdUneq_3 = New System.Windows.Forms.Button
		Me._cmdUneq_2 = New System.Windows.Forms.Button
		Me._cmdUneq_1 = New System.Windows.Forms.Button
		Me._cmdUneq_0 = New System.Windows.Forms.Button
		Me.cmdDone = New System.Windows.Forms.Button
		Me._txEq_7 = New System.Windows.Forms.TextBox
		Me._txEq_6 = New System.Windows.Forms.TextBox
		Me._txEq_5 = New System.Windows.Forms.TextBox
		Me._txEq_4 = New System.Windows.Forms.TextBox
		Me._txEq_3 = New System.Windows.Forms.TextBox
		Me._txEq_2 = New System.Windows.Forms.TextBox
		Me._txEq_1 = New System.Windows.Forms.TextBox
		Me._txEq_0 = New System.Windows.Forms.TextBox
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.lblRFire = New System.Windows.Forms.Label
		Me.lblGold = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.lblDam = New System.Windows.Forms.Label
		Me._lblStats_0 = New System.Windows.Forms.Label
		Me._lblStats_1 = New System.Windows.Forms.Label
		Me._lblStats_2 = New System.Windows.Forms.Label
		Me._lblStats_3 = New System.Windows.Forms.Label
		Me._lblStats_4 = New System.Windows.Forms.Label
		Me._lblStats_5 = New System.Windows.Forms.Label
		Me._lblStats_6 = New System.Windows.Forms.Label
		Me._lblDervs_0 = New System.Windows.Forms.Label
		Me._lblDervs_1 = New System.Windows.Forms.Label
		Me._lblDervs_2 = New System.Windows.Forms.Label
		Me._lblDervs_3 = New System.Windows.Forms.Label
		Me._lblDervs_4 = New System.Windows.Forms.Label
		Me._lblDervs_5 = New System.Windows.Forms.Label
		Me._lblDervs_6 = New System.Windows.Forms.Label
		Me._lblEq_7 = New System.Windows.Forms.Label
		Me._lblEq_6 = New System.Windows.Forms.Label
		Me._lblEq_5 = New System.Windows.Forms.Label
		Me._lblEq_4 = New System.Windows.Forms.Label
		Me._lblEq_3 = New System.Windows.Forms.Label
		Me._lblEq_2 = New System.Windows.Forms.Label
		Me._lblEq_1 = New System.Windows.Forms.Label
		Me._lblEq_0 = New System.Windows.Forms.Label
		Me.cmdUneq = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(components)
		Me.lblDervs = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.lblEq = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.lblStats = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.txDervs = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
		Me.txEq = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
		Me.txRes = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
		Me.txStats = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
		Me.frCurrent.SuspendLayout()
		Me.frInven.SuspendLayout()
		Me.frEquip.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.cmdUneq, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.lblDervs, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.lblEq, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.lblStats, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txDervs, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txEq, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txRes, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txStats, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Inventory"
		Me.ClientSize = New System.Drawing.Size(691, 421)
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
		Me.Name = "frmInven"
		Me.frCurrent.Text = "Current Item"
		Me.frCurrent.Size = New System.Drawing.Size(689, 41)
		Me.frCurrent.Location = New System.Drawing.Point(0, 376)
		Me.frCurrent.TabIndex = 73
		Me.frCurrent.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.frCurrent.BackColor = System.Drawing.SystemColors.Control
		Me.frCurrent.Enabled = True
		Me.frCurrent.ForeColor = System.Drawing.SystemColors.ControlText
		Me.frCurrent.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.frCurrent.Visible = True
		Me.frCurrent.Padding = New System.Windows.Forms.Padding(0)
		Me.frCurrent.Name = "frCurrent"
		Me.txValue.AutoSize = False
		Me.txValue.Size = New System.Drawing.Size(97, 19)
		Me.txValue.Location = New System.Drawing.Point(584, 16)
		Me.txValue.ReadOnly = True
		Me.txValue.TabIndex = 76
		Me.txValue.Text = "Text1"
		Me.txValue.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txValue.AcceptsReturn = True
		Me.txValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txValue.BackColor = System.Drawing.SystemColors.Window
		Me.txValue.CausesValidation = True
		Me.txValue.Enabled = True
		Me.txValue.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txValue.HideSelection = True
		Me.txValue.Maxlength = 0
		Me.txValue.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txValue.MultiLine = False
		Me.txValue.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txValue.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txValue.TabStop = True
		Me.txValue.Visible = True
		Me.txValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txValue.Name = "txValue"
		Me.txCur.AutoSize = False
		Me.txCur.Size = New System.Drawing.Size(537, 19)
		Me.txCur.Location = New System.Drawing.Point(8, 16)
		Me.txCur.ReadOnly = True
		Me.txCur.TabIndex = 74
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
		Me.lblValue.Text = "Value"
		Me.lblValue.Size = New System.Drawing.Size(33, 17)
		Me.lblValue.Location = New System.Drawing.Point(552, 16)
		Me.lblValue.TabIndex = 75
		Me.lblValue.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblValue.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblValue.BackColor = System.Drawing.SystemColors.Control
		Me.lblValue.Enabled = True
		Me.lblValue.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblValue.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblValue.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblValue.UseMnemonic = True
		Me.lblValue.Visible = True
		Me.lblValue.AutoSize = False
		Me.lblValue.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblValue.Name = "lblValue"
		Me.frInven.Text = "Inventory"
		Me.frInven.Size = New System.Drawing.Size(305, 377)
		Me.frInven.Location = New System.Drawing.Point(384, 0)
		Me.frInven.TabIndex = 1
		Me.frInven.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.frInven.BackColor = System.Drawing.SystemColors.Control
		Me.frInven.Enabled = True
		Me.frInven.ForeColor = System.Drawing.SystemColors.ControlText
		Me.frInven.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.frInven.Visible = True
		Me.frInven.Padding = New System.Windows.Forms.Padding(0)
		Me.frInven.Name = "frInven"
		Me.cmdPickUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPickUp.Text = "Pick Up"
		Me.cmdPickUp.Size = New System.Drawing.Size(73, 17)
		Me.cmdPickUp.Location = New System.Drawing.Point(8, 352)
		Me.cmdPickUp.TabIndex = 64
		Me.cmdPickUp.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdPickUp.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPickUp.CausesValidation = True
		Me.cmdPickUp.Enabled = True
		Me.cmdPickUp.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPickUp.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPickUp.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPickUp.TabStop = True
		Me.cmdPickUp.Name = "cmdPickUp"
		Me.txPickUp.AutoSize = False
		Me.txPickUp.Size = New System.Drawing.Size(209, 19)
		Me.txPickUp.Location = New System.Drawing.Point(88, 352)
		Me.txPickUp.ReadOnly = True
		Me.txPickUp.TabIndex = 63
		Me.txPickUp.Text = "Text1"
		Me.txPickUp.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txPickUp.AcceptsReturn = True
		Me.txPickUp.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txPickUp.BackColor = System.Drawing.SystemColors.Window
		Me.txPickUp.CausesValidation = True
		Me.txPickUp.Enabled = True
		Me.txPickUp.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txPickUp.HideSelection = True
		Me.txPickUp.Maxlength = 0
		Me.txPickUp.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txPickUp.MultiLine = False
		Me.txPickUp.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txPickUp.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txPickUp.TabStop = True
		Me.txPickUp.Visible = True
		Me.txPickUp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txPickUp.Name = "txPickUp"
		Me.lstInven.Size = New System.Drawing.Size(289, 332)
		Me.lstInven.Location = New System.Drawing.Point(8, 16)
		Me.lstInven.Sorted = True
		Me.lstInven.TabIndex = 18
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
		Me.frEquip.Text = "Equipped"
		Me.frEquip.Size = New System.Drawing.Size(377, 377)
		Me.frEquip.Location = New System.Drawing.Point(0, 0)
		Me.frEquip.TabIndex = 0
		Me.frEquip.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.frEquip.BackColor = System.Drawing.SystemColors.Control
		Me.frEquip.Enabled = True
		Me.frEquip.ForeColor = System.Drawing.SystemColors.ControlText
		Me.frEquip.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.frEquip.Visible = True
		Me.frEquip.Padding = New System.Windows.Forms.Padding(0)
		Me.frEquip.Name = "frEquip"
		Me.cmdID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdID.Text = "Identify"
		Me.cmdID.Size = New System.Drawing.Size(57, 33)
		Me.cmdID.Location = New System.Drawing.Point(312, 256)
		Me.cmdID.TabIndex = 77
		Me.cmdID.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdID.BackColor = System.Drawing.SystemColors.Control
		Me.cmdID.CausesValidation = True
		Me.cmdID.Enabled = True
		Me.cmdID.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdID.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdID.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdID.TabStop = True
		Me.cmdID.Name = "cmdID"
		Me._txRes_3.AutoSize = False
		Me._txRes_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txRes_3.Size = New System.Drawing.Size(41, 19)
		Me._txRes_3.Location = New System.Drawing.Point(264, 352)
		Me._txRes_3.ReadOnly = True
		Me._txRes_3.TabIndex = 72
		Me._txRes_3.Text = "Text1"
		Me._txRes_3.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txRes_3.AcceptsReturn = True
		Me._txRes_3.BackColor = System.Drawing.SystemColors.Window
		Me._txRes_3.CausesValidation = True
		Me._txRes_3.Enabled = True
		Me._txRes_3.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txRes_3.HideSelection = True
		Me._txRes_3.Maxlength = 0
		Me._txRes_3.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txRes_3.MultiLine = False
		Me._txRes_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txRes_3.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txRes_3.TabStop = True
		Me._txRes_3.Visible = True
		Me._txRes_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txRes_3.Name = "_txRes_3"
		Me._txRes_2.AutoSize = False
		Me._txRes_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txRes_2.Size = New System.Drawing.Size(41, 19)
		Me._txRes_2.Location = New System.Drawing.Point(264, 328)
		Me._txRes_2.ReadOnly = True
		Me._txRes_2.TabIndex = 71
		Me._txRes_2.Text = "Text1"
		Me._txRes_2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txRes_2.AcceptsReturn = True
		Me._txRes_2.BackColor = System.Drawing.SystemColors.Window
		Me._txRes_2.CausesValidation = True
		Me._txRes_2.Enabled = True
		Me._txRes_2.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txRes_2.HideSelection = True
		Me._txRes_2.Maxlength = 0
		Me._txRes_2.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txRes_2.MultiLine = False
		Me._txRes_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txRes_2.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txRes_2.TabStop = True
		Me._txRes_2.Visible = True
		Me._txRes_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txRes_2.Name = "_txRes_2"
		Me._txRes_1.AutoSize = False
		Me._txRes_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txRes_1.Size = New System.Drawing.Size(41, 19)
		Me._txRes_1.Location = New System.Drawing.Point(264, 304)
		Me._txRes_1.ReadOnly = True
		Me._txRes_1.TabIndex = 70
		Me._txRes_1.Text = "Text1"
		Me._txRes_1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txRes_1.AcceptsReturn = True
		Me._txRes_1.BackColor = System.Drawing.SystemColors.Window
		Me._txRes_1.CausesValidation = True
		Me._txRes_1.Enabled = True
		Me._txRes_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txRes_1.HideSelection = True
		Me._txRes_1.Maxlength = 0
		Me._txRes_1.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txRes_1.MultiLine = False
		Me._txRes_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txRes_1.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txRes_1.TabStop = True
		Me._txRes_1.Visible = True
		Me._txRes_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txRes_1.Name = "_txRes_1"
		Me._txRes_0.AutoSize = False
		Me._txRes_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txRes_0.Size = New System.Drawing.Size(41, 19)
		Me._txRes_0.Location = New System.Drawing.Point(264, 280)
		Me._txRes_0.ReadOnly = True
		Me._txRes_0.TabIndex = 69
		Me._txRes_0.Text = "Text1"
		Me._txRes_0.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txRes_0.AcceptsReturn = True
		Me._txRes_0.BackColor = System.Drawing.SystemColors.Window
		Me._txRes_0.CausesValidation = True
		Me._txRes_0.Enabled = True
		Me._txRes_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txRes_0.HideSelection = True
		Me._txRes_0.Maxlength = 0
		Me._txRes_0.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txRes_0.MultiLine = False
		Me._txRes_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txRes_0.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txRes_0.TabStop = True
		Me._txRes_0.Visible = True
		Me._txRes_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txRes_0.Name = "_txRes_0"
		Me.txGold.AutoSize = False
		Me.txGold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txGold.Size = New System.Drawing.Size(57, 19)
		Me.txGold.Location = New System.Drawing.Point(248, 256)
		Me.txGold.ReadOnly = True
		Me.txGold.TabIndex = 62
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
		Me.cmdDrop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDrop.Text = "Drop"
		Me.cmdDrop.Size = New System.Drawing.Size(57, 33)
		Me.cmdDrop.Location = New System.Drawing.Point(312, 296)
		Me.cmdDrop.TabIndex = 60
		Me.cmdDrop.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdDrop.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDrop.CausesValidation = True
		Me.cmdDrop.Enabled = True
		Me.cmdDrop.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDrop.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDrop.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDrop.TabStop = True
		Me.cmdDrop.Name = "cmdDrop"
		Me.txDR.AutoSize = False
		Me.txDR.Size = New System.Drawing.Size(41, 19)
		Me.txDR.Location = New System.Drawing.Point(264, 232)
		Me.txDR.ReadOnly = True
		Me.txDR.TabIndex = 59
		Me.txDR.Text = "Text1"
		Me.txDR.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txDR.AcceptsReturn = True
		Me.txDR.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txDR.BackColor = System.Drawing.SystemColors.Window
		Me.txDR.CausesValidation = True
		Me.txDR.Enabled = True
		Me.txDR.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txDR.HideSelection = True
		Me.txDR.Maxlength = 0
		Me.txDR.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txDR.MultiLine = False
		Me.txDR.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txDR.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txDR.TabStop = True
		Me.txDR.Visible = True
		Me.txDR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txDR.Name = "txDR"
		Me.txDam.AutoSize = False
		Me.txDam.Size = New System.Drawing.Size(41, 19)
		Me.txDam.Location = New System.Drawing.Point(168, 256)
		Me.txDam.ReadOnly = True
		Me.txDam.TabIndex = 57
		Me.txDam.Text = "Text1"
		Me.txDam.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txDam.AcceptsReturn = True
		Me.txDam.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txDam.BackColor = System.Drawing.SystemColors.Window
		Me.txDam.CausesValidation = True
		Me.txDam.Enabled = True
		Me.txDam.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txDam.HideSelection = True
		Me.txDam.Maxlength = 0
		Me.txDam.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txDam.MultiLine = False
		Me.txDam.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txDam.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txDam.TabStop = True
		Me.txDam.Visible = True
		Me.txDam.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txDam.Name = "txDam"
		Me._txStats_0.AutoSize = False
		Me._txStats_0.Size = New System.Drawing.Size(41, 19)
		Me._txStats_0.Location = New System.Drawing.Point(64, 208)
		Me._txStats_0.ReadOnly = True
		Me._txStats_0.TabIndex = 48
		Me._txStats_0.Text = "Text1"
		Me._txStats_0.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txStats_0.AcceptsReturn = True
		Me._txStats_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txStats_0.BackColor = System.Drawing.SystemColors.Window
		Me._txStats_0.CausesValidation = True
		Me._txStats_0.Enabled = True
		Me._txStats_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txStats_0.HideSelection = True
		Me._txStats_0.Maxlength = 0
		Me._txStats_0.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txStats_0.MultiLine = False
		Me._txStats_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txStats_0.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txStats_0.TabStop = True
		Me._txStats_0.Visible = True
		Me._txStats_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txStats_0.Name = "_txStats_0"
		Me._txStats_1.AutoSize = False
		Me._txStats_1.Size = New System.Drawing.Size(41, 19)
		Me._txStats_1.Location = New System.Drawing.Point(64, 232)
		Me._txStats_1.ReadOnly = True
		Me._txStats_1.TabIndex = 47
		Me._txStats_1.Text = "Text1"
		Me._txStats_1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txStats_1.AcceptsReturn = True
		Me._txStats_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txStats_1.BackColor = System.Drawing.SystemColors.Window
		Me._txStats_1.CausesValidation = True
		Me._txStats_1.Enabled = True
		Me._txStats_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txStats_1.HideSelection = True
		Me._txStats_1.Maxlength = 0
		Me._txStats_1.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txStats_1.MultiLine = False
		Me._txStats_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txStats_1.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txStats_1.TabStop = True
		Me._txStats_1.Visible = True
		Me._txStats_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txStats_1.Name = "_txStats_1"
		Me._txStats_2.AutoSize = False
		Me._txStats_2.Size = New System.Drawing.Size(41, 19)
		Me._txStats_2.Location = New System.Drawing.Point(64, 256)
		Me._txStats_2.ReadOnly = True
		Me._txStats_2.TabIndex = 46
		Me._txStats_2.Text = "Text1"
		Me._txStats_2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txStats_2.AcceptsReturn = True
		Me._txStats_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txStats_2.BackColor = System.Drawing.SystemColors.Window
		Me._txStats_2.CausesValidation = True
		Me._txStats_2.Enabled = True
		Me._txStats_2.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txStats_2.HideSelection = True
		Me._txStats_2.Maxlength = 0
		Me._txStats_2.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txStats_2.MultiLine = False
		Me._txStats_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txStats_2.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txStats_2.TabStop = True
		Me._txStats_2.Visible = True
		Me._txStats_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txStats_2.Name = "_txStats_2"
		Me._txStats_3.AutoSize = False
		Me._txStats_3.Size = New System.Drawing.Size(41, 19)
		Me._txStats_3.Location = New System.Drawing.Point(64, 280)
		Me._txStats_3.ReadOnly = True
		Me._txStats_3.TabIndex = 45
		Me._txStats_3.Text = "Text1"
		Me._txStats_3.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txStats_3.AcceptsReturn = True
		Me._txStats_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txStats_3.BackColor = System.Drawing.SystemColors.Window
		Me._txStats_3.CausesValidation = True
		Me._txStats_3.Enabled = True
		Me._txStats_3.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txStats_3.HideSelection = True
		Me._txStats_3.Maxlength = 0
		Me._txStats_3.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txStats_3.MultiLine = False
		Me._txStats_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txStats_3.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txStats_3.TabStop = True
		Me._txStats_3.Visible = True
		Me._txStats_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txStats_3.Name = "_txStats_3"
		Me._txStats_4.AutoSize = False
		Me._txStats_4.Size = New System.Drawing.Size(41, 19)
		Me._txStats_4.Location = New System.Drawing.Point(64, 304)
		Me._txStats_4.ReadOnly = True
		Me._txStats_4.TabIndex = 44
		Me._txStats_4.Text = "Text1"
		Me._txStats_4.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txStats_4.AcceptsReturn = True
		Me._txStats_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txStats_4.BackColor = System.Drawing.SystemColors.Window
		Me._txStats_4.CausesValidation = True
		Me._txStats_4.Enabled = True
		Me._txStats_4.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txStats_4.HideSelection = True
		Me._txStats_4.Maxlength = 0
		Me._txStats_4.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txStats_4.MultiLine = False
		Me._txStats_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txStats_4.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txStats_4.TabStop = True
		Me._txStats_4.Visible = True
		Me._txStats_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txStats_4.Name = "_txStats_4"
		Me._txStats_5.AutoSize = False
		Me._txStats_5.Size = New System.Drawing.Size(41, 19)
		Me._txStats_5.Location = New System.Drawing.Point(64, 328)
		Me._txStats_5.ReadOnly = True
		Me._txStats_5.TabIndex = 43
		Me._txStats_5.Text = "Text1"
		Me._txStats_5.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txStats_5.AcceptsReturn = True
		Me._txStats_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txStats_5.BackColor = System.Drawing.SystemColors.Window
		Me._txStats_5.CausesValidation = True
		Me._txStats_5.Enabled = True
		Me._txStats_5.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txStats_5.HideSelection = True
		Me._txStats_5.Maxlength = 0
		Me._txStats_5.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txStats_5.MultiLine = False
		Me._txStats_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txStats_5.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txStats_5.TabStop = True
		Me._txStats_5.Visible = True
		Me._txStats_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txStats_5.Name = "_txStats_5"
		Me._txStats_6.AutoSize = False
		Me._txStats_6.Size = New System.Drawing.Size(41, 19)
		Me._txStats_6.Location = New System.Drawing.Point(64, 352)
		Me._txStats_6.ReadOnly = True
		Me._txStats_6.TabIndex = 42
		Me._txStats_6.Text = "Text1"
		Me._txStats_6.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txStats_6.AcceptsReturn = True
		Me._txStats_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txStats_6.BackColor = System.Drawing.SystemColors.Window
		Me._txStats_6.CausesValidation = True
		Me._txStats_6.Enabled = True
		Me._txStats_6.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txStats_6.HideSelection = True
		Me._txStats_6.Maxlength = 0
		Me._txStats_6.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txStats_6.MultiLine = False
		Me._txStats_6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txStats_6.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txStats_6.TabStop = True
		Me._txStats_6.Visible = True
		Me._txStats_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txStats_6.Name = "_txStats_6"
		Me._txDervs_0.AutoSize = False
		Me._txDervs_0.Size = New System.Drawing.Size(41, 19)
		Me._txDervs_0.Location = New System.Drawing.Point(168, 208)
		Me._txDervs_0.ReadOnly = True
		Me._txDervs_0.TabIndex = 34
		Me._txDervs_0.Text = "Text1"
		Me._txDervs_0.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txDervs_0.AcceptsReturn = True
		Me._txDervs_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txDervs_0.BackColor = System.Drawing.SystemColors.Window
		Me._txDervs_0.CausesValidation = True
		Me._txDervs_0.Enabled = True
		Me._txDervs_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txDervs_0.HideSelection = True
		Me._txDervs_0.Maxlength = 0
		Me._txDervs_0.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txDervs_0.MultiLine = False
		Me._txDervs_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txDervs_0.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txDervs_0.TabStop = True
		Me._txDervs_0.Visible = True
		Me._txDervs_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txDervs_0.Name = "_txDervs_0"
		Me._txDervs_1.AutoSize = False
		Me._txDervs_1.Size = New System.Drawing.Size(41, 19)
		Me._txDervs_1.Location = New System.Drawing.Point(168, 232)
		Me._txDervs_1.ReadOnly = True
		Me._txDervs_1.TabIndex = 33
		Me._txDervs_1.Text = "Text1"
		Me._txDervs_1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txDervs_1.AcceptsReturn = True
		Me._txDervs_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txDervs_1.BackColor = System.Drawing.SystemColors.Window
		Me._txDervs_1.CausesValidation = True
		Me._txDervs_1.Enabled = True
		Me._txDervs_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txDervs_1.HideSelection = True
		Me._txDervs_1.Maxlength = 0
		Me._txDervs_1.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txDervs_1.MultiLine = False
		Me._txDervs_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txDervs_1.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txDervs_1.TabStop = True
		Me._txDervs_1.Visible = True
		Me._txDervs_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txDervs_1.Name = "_txDervs_1"
		Me._txDervs_2.AutoSize = False
		Me._txDervs_2.Size = New System.Drawing.Size(41, 19)
		Me._txDervs_2.Location = New System.Drawing.Point(264, 208)
		Me._txDervs_2.ReadOnly = True
		Me._txDervs_2.TabIndex = 32
		Me._txDervs_2.Text = "Text1"
		Me._txDervs_2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txDervs_2.AcceptsReturn = True
		Me._txDervs_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txDervs_2.BackColor = System.Drawing.SystemColors.Window
		Me._txDervs_2.CausesValidation = True
		Me._txDervs_2.Enabled = True
		Me._txDervs_2.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txDervs_2.HideSelection = True
		Me._txDervs_2.Maxlength = 0
		Me._txDervs_2.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txDervs_2.MultiLine = False
		Me._txDervs_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txDervs_2.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txDervs_2.TabStop = True
		Me._txDervs_2.Visible = True
		Me._txDervs_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txDervs_2.Name = "_txDervs_2"
		Me._txDervs_3.AutoSize = False
		Me._txDervs_3.Size = New System.Drawing.Size(41, 19)
		Me._txDervs_3.Location = New System.Drawing.Point(168, 280)
		Me._txDervs_3.ReadOnly = True
		Me._txDervs_3.TabIndex = 31
		Me._txDervs_3.Text = "Text1"
		Me._txDervs_3.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txDervs_3.AcceptsReturn = True
		Me._txDervs_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txDervs_3.BackColor = System.Drawing.SystemColors.Window
		Me._txDervs_3.CausesValidation = True
		Me._txDervs_3.Enabled = True
		Me._txDervs_3.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txDervs_3.HideSelection = True
		Me._txDervs_3.Maxlength = 0
		Me._txDervs_3.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txDervs_3.MultiLine = False
		Me._txDervs_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txDervs_3.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txDervs_3.TabStop = True
		Me._txDervs_3.Visible = True
		Me._txDervs_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txDervs_3.Name = "_txDervs_3"
		Me._txDervs_4.AutoSize = False
		Me._txDervs_4.Size = New System.Drawing.Size(41, 19)
		Me._txDervs_4.Location = New System.Drawing.Point(168, 304)
		Me._txDervs_4.ReadOnly = True
		Me._txDervs_4.TabIndex = 30
		Me._txDervs_4.Text = "Text1"
		Me._txDervs_4.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txDervs_4.AcceptsReturn = True
		Me._txDervs_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txDervs_4.BackColor = System.Drawing.SystemColors.Window
		Me._txDervs_4.CausesValidation = True
		Me._txDervs_4.Enabled = True
		Me._txDervs_4.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txDervs_4.HideSelection = True
		Me._txDervs_4.Maxlength = 0
		Me._txDervs_4.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txDervs_4.MultiLine = False
		Me._txDervs_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txDervs_4.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txDervs_4.TabStop = True
		Me._txDervs_4.Visible = True
		Me._txDervs_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txDervs_4.Name = "_txDervs_4"
		Me._txDervs_5.AutoSize = False
		Me._txDervs_5.Size = New System.Drawing.Size(41, 19)
		Me._txDervs_5.Location = New System.Drawing.Point(168, 328)
		Me._txDervs_5.ReadOnly = True
		Me._txDervs_5.TabIndex = 29
		Me._txDervs_5.Text = "Text1"
		Me._txDervs_5.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txDervs_5.AcceptsReturn = True
		Me._txDervs_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txDervs_5.BackColor = System.Drawing.SystemColors.Window
		Me._txDervs_5.CausesValidation = True
		Me._txDervs_5.Enabled = True
		Me._txDervs_5.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txDervs_5.HideSelection = True
		Me._txDervs_5.Maxlength = 0
		Me._txDervs_5.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txDervs_5.MultiLine = False
		Me._txDervs_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txDervs_5.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txDervs_5.TabStop = True
		Me._txDervs_5.Visible = True
		Me._txDervs_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txDervs_5.Name = "_txDervs_5"
		Me._txDervs_6.AutoSize = False
		Me._txDervs_6.Size = New System.Drawing.Size(41, 19)
		Me._txDervs_6.Location = New System.Drawing.Point(168, 352)
		Me._txDervs_6.ReadOnly = True
		Me._txDervs_6.TabIndex = 28
		Me._txDervs_6.Text = "Text1"
		Me._txDervs_6.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txDervs_6.AcceptsReturn = True
		Me._txDervs_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txDervs_6.BackColor = System.Drawing.SystemColors.Window
		Me._txDervs_6.CausesValidation = True
		Me._txDervs_6.Enabled = True
		Me._txDervs_6.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txDervs_6.HideSelection = True
		Me._txDervs_6.Maxlength = 0
		Me._txDervs_6.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txDervs_6.MultiLine = False
		Me._txDervs_6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txDervs_6.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txDervs_6.TabStop = True
		Me._txDervs_6.Visible = True
		Me._txDervs_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txDervs_6.Name = "_txDervs_6"
		Me._cmdUneq_7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._cmdUneq_7.Text = "U"
		Me._cmdUneq_7.Size = New System.Drawing.Size(17, 17)
		Me._cmdUneq_7.Location = New System.Drawing.Point(352, 184)
		Me._cmdUneq_7.TabIndex = 27
		Me._cmdUneq_7.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._cmdUneq_7.BackColor = System.Drawing.SystemColors.Control
		Me._cmdUneq_7.CausesValidation = True
		Me._cmdUneq_7.Enabled = True
		Me._cmdUneq_7.ForeColor = System.Drawing.SystemColors.ControlText
		Me._cmdUneq_7.Cursor = System.Windows.Forms.Cursors.Default
		Me._cmdUneq_7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._cmdUneq_7.TabStop = True
		Me._cmdUneq_7.Name = "_cmdUneq_7"
		Me._cmdUneq_6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._cmdUneq_6.Text = "U"
		Me._cmdUneq_6.Size = New System.Drawing.Size(17, 17)
		Me._cmdUneq_6.Location = New System.Drawing.Point(352, 160)
		Me._cmdUneq_6.TabIndex = 26
		Me._cmdUneq_6.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._cmdUneq_6.BackColor = System.Drawing.SystemColors.Control
		Me._cmdUneq_6.CausesValidation = True
		Me._cmdUneq_6.Enabled = True
		Me._cmdUneq_6.ForeColor = System.Drawing.SystemColors.ControlText
		Me._cmdUneq_6.Cursor = System.Windows.Forms.Cursors.Default
		Me._cmdUneq_6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._cmdUneq_6.TabStop = True
		Me._cmdUneq_6.Name = "_cmdUneq_6"
		Me._cmdUneq_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._cmdUneq_5.Text = "U"
		Me._cmdUneq_5.Size = New System.Drawing.Size(17, 17)
		Me._cmdUneq_5.Location = New System.Drawing.Point(352, 136)
		Me._cmdUneq_5.TabIndex = 25
		Me._cmdUneq_5.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._cmdUneq_5.BackColor = System.Drawing.SystemColors.Control
		Me._cmdUneq_5.CausesValidation = True
		Me._cmdUneq_5.Enabled = True
		Me._cmdUneq_5.ForeColor = System.Drawing.SystemColors.ControlText
		Me._cmdUneq_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._cmdUneq_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._cmdUneq_5.TabStop = True
		Me._cmdUneq_5.Name = "_cmdUneq_5"
		Me._cmdUneq_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._cmdUneq_4.Text = "U"
		Me._cmdUneq_4.Size = New System.Drawing.Size(17, 17)
		Me._cmdUneq_4.Location = New System.Drawing.Point(352, 112)
		Me._cmdUneq_4.TabIndex = 24
		Me._cmdUneq_4.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._cmdUneq_4.BackColor = System.Drawing.SystemColors.Control
		Me._cmdUneq_4.CausesValidation = True
		Me._cmdUneq_4.Enabled = True
		Me._cmdUneq_4.ForeColor = System.Drawing.SystemColors.ControlText
		Me._cmdUneq_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._cmdUneq_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._cmdUneq_4.TabStop = True
		Me._cmdUneq_4.Name = "_cmdUneq_4"
		Me._cmdUneq_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._cmdUneq_3.Text = "U"
		Me._cmdUneq_3.Size = New System.Drawing.Size(17, 17)
		Me._cmdUneq_3.Location = New System.Drawing.Point(352, 88)
		Me._cmdUneq_3.TabIndex = 23
		Me._cmdUneq_3.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._cmdUneq_3.BackColor = System.Drawing.SystemColors.Control
		Me._cmdUneq_3.CausesValidation = True
		Me._cmdUneq_3.Enabled = True
		Me._cmdUneq_3.ForeColor = System.Drawing.SystemColors.ControlText
		Me._cmdUneq_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._cmdUneq_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._cmdUneq_3.TabStop = True
		Me._cmdUneq_3.Name = "_cmdUneq_3"
		Me._cmdUneq_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._cmdUneq_2.Text = "U"
		Me._cmdUneq_2.Size = New System.Drawing.Size(17, 17)
		Me._cmdUneq_2.Location = New System.Drawing.Point(352, 64)
		Me._cmdUneq_2.TabIndex = 22
		Me._cmdUneq_2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._cmdUneq_2.BackColor = System.Drawing.SystemColors.Control
		Me._cmdUneq_2.CausesValidation = True
		Me._cmdUneq_2.Enabled = True
		Me._cmdUneq_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._cmdUneq_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._cmdUneq_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._cmdUneq_2.TabStop = True
		Me._cmdUneq_2.Name = "_cmdUneq_2"
		Me._cmdUneq_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._cmdUneq_1.Text = "U"
		Me._cmdUneq_1.Size = New System.Drawing.Size(17, 17)
		Me._cmdUneq_1.Location = New System.Drawing.Point(352, 40)
		Me._cmdUneq_1.TabIndex = 21
		Me._cmdUneq_1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._cmdUneq_1.BackColor = System.Drawing.SystemColors.Control
		Me._cmdUneq_1.CausesValidation = True
		Me._cmdUneq_1.Enabled = True
		Me._cmdUneq_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._cmdUneq_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._cmdUneq_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._cmdUneq_1.TabStop = True
		Me._cmdUneq_1.Name = "_cmdUneq_1"
		Me._cmdUneq_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._cmdUneq_0.Text = "U"
		Me._cmdUneq_0.Size = New System.Drawing.Size(17, 17)
		Me._cmdUneq_0.Location = New System.Drawing.Point(352, 16)
		Me._cmdUneq_0.TabIndex = 20
		Me._cmdUneq_0.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._cmdUneq_0.BackColor = System.Drawing.SystemColors.Control
		Me._cmdUneq_0.CausesValidation = True
		Me._cmdUneq_0.Enabled = True
		Me._cmdUneq_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._cmdUneq_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._cmdUneq_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._cmdUneq_0.TabStop = True
		Me._cmdUneq_0.Name = "_cmdUneq_0"
		Me.cmdDone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDone.Text = "Done"
		Me.cmdDone.Size = New System.Drawing.Size(57, 33)
		Me.cmdDone.Location = New System.Drawing.Point(312, 336)
		Me.cmdDone.TabIndex = 19
		Me.cmdDone.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdDone.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDone.CausesValidation = True
		Me.cmdDone.Enabled = True
		Me.cmdDone.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDone.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDone.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDone.TabStop = True
		Me.cmdDone.Name = "cmdDone"
		Me._txEq_7.AutoSize = False
		Me._txEq_7.Size = New System.Drawing.Size(289, 19)
		Me._txEq_7.Location = New System.Drawing.Point(56, 184)
		Me._txEq_7.ReadOnly = True
		Me._txEq_7.TabIndex = 17
		Me._txEq_7.Text = "Text1"
		Me._txEq_7.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txEq_7.AcceptsReturn = True
		Me._txEq_7.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txEq_7.BackColor = System.Drawing.SystemColors.Window
		Me._txEq_7.CausesValidation = True
		Me._txEq_7.Enabled = True
		Me._txEq_7.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txEq_7.HideSelection = True
		Me._txEq_7.Maxlength = 0
		Me._txEq_7.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txEq_7.MultiLine = False
		Me._txEq_7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txEq_7.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txEq_7.TabStop = True
		Me._txEq_7.Visible = True
		Me._txEq_7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txEq_7.Name = "_txEq_7"
		Me._txEq_6.AutoSize = False
		Me._txEq_6.Size = New System.Drawing.Size(289, 19)
		Me._txEq_6.Location = New System.Drawing.Point(56, 160)
		Me._txEq_6.ReadOnly = True
		Me._txEq_6.TabIndex = 16
		Me._txEq_6.Text = "Text1"
		Me._txEq_6.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txEq_6.AcceptsReturn = True
		Me._txEq_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txEq_6.BackColor = System.Drawing.SystemColors.Window
		Me._txEq_6.CausesValidation = True
		Me._txEq_6.Enabled = True
		Me._txEq_6.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txEq_6.HideSelection = True
		Me._txEq_6.Maxlength = 0
		Me._txEq_6.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txEq_6.MultiLine = False
		Me._txEq_6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txEq_6.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txEq_6.TabStop = True
		Me._txEq_6.Visible = True
		Me._txEq_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txEq_6.Name = "_txEq_6"
		Me._txEq_5.AutoSize = False
		Me._txEq_5.Size = New System.Drawing.Size(289, 19)
		Me._txEq_5.Location = New System.Drawing.Point(56, 136)
		Me._txEq_5.ReadOnly = True
		Me._txEq_5.TabIndex = 15
		Me._txEq_5.Text = "Text1"
		Me._txEq_5.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txEq_5.AcceptsReturn = True
		Me._txEq_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txEq_5.BackColor = System.Drawing.SystemColors.Window
		Me._txEq_5.CausesValidation = True
		Me._txEq_5.Enabled = True
		Me._txEq_5.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txEq_5.HideSelection = True
		Me._txEq_5.Maxlength = 0
		Me._txEq_5.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txEq_5.MultiLine = False
		Me._txEq_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txEq_5.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txEq_5.TabStop = True
		Me._txEq_5.Visible = True
		Me._txEq_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txEq_5.Name = "_txEq_5"
		Me._txEq_4.AutoSize = False
		Me._txEq_4.Size = New System.Drawing.Size(289, 19)
		Me._txEq_4.Location = New System.Drawing.Point(56, 112)
		Me._txEq_4.ReadOnly = True
		Me._txEq_4.TabIndex = 14
		Me._txEq_4.Text = "Text1"
		Me._txEq_4.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txEq_4.AcceptsReturn = True
		Me._txEq_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txEq_4.BackColor = System.Drawing.SystemColors.Window
		Me._txEq_4.CausesValidation = True
		Me._txEq_4.Enabled = True
		Me._txEq_4.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txEq_4.HideSelection = True
		Me._txEq_4.Maxlength = 0
		Me._txEq_4.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txEq_4.MultiLine = False
		Me._txEq_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txEq_4.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txEq_4.TabStop = True
		Me._txEq_4.Visible = True
		Me._txEq_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txEq_4.Name = "_txEq_4"
		Me._txEq_3.AutoSize = False
		Me._txEq_3.Size = New System.Drawing.Size(289, 19)
		Me._txEq_3.Location = New System.Drawing.Point(56, 88)
		Me._txEq_3.ReadOnly = True
		Me._txEq_3.TabIndex = 13
		Me._txEq_3.Text = "Text1"
		Me._txEq_3.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txEq_3.AcceptsReturn = True
		Me._txEq_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txEq_3.BackColor = System.Drawing.SystemColors.Window
		Me._txEq_3.CausesValidation = True
		Me._txEq_3.Enabled = True
		Me._txEq_3.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txEq_3.HideSelection = True
		Me._txEq_3.Maxlength = 0
		Me._txEq_3.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txEq_3.MultiLine = False
		Me._txEq_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txEq_3.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txEq_3.TabStop = True
		Me._txEq_3.Visible = True
		Me._txEq_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txEq_3.Name = "_txEq_3"
		Me._txEq_2.AutoSize = False
		Me._txEq_2.Size = New System.Drawing.Size(289, 19)
		Me._txEq_2.Location = New System.Drawing.Point(56, 64)
		Me._txEq_2.ReadOnly = True
		Me._txEq_2.TabIndex = 12
		Me._txEq_2.Text = "Text1"
		Me._txEq_2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txEq_2.AcceptsReturn = True
		Me._txEq_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txEq_2.BackColor = System.Drawing.SystemColors.Window
		Me._txEq_2.CausesValidation = True
		Me._txEq_2.Enabled = True
		Me._txEq_2.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txEq_2.HideSelection = True
		Me._txEq_2.Maxlength = 0
		Me._txEq_2.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txEq_2.MultiLine = False
		Me._txEq_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txEq_2.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txEq_2.TabStop = True
		Me._txEq_2.Visible = True
		Me._txEq_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txEq_2.Name = "_txEq_2"
		Me._txEq_1.AutoSize = False
		Me._txEq_1.Size = New System.Drawing.Size(289, 19)
		Me._txEq_1.Location = New System.Drawing.Point(56, 40)
		Me._txEq_1.ReadOnly = True
		Me._txEq_1.TabIndex = 11
		Me._txEq_1.Text = "Text1"
		Me._txEq_1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txEq_1.AcceptsReturn = True
		Me._txEq_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txEq_1.BackColor = System.Drawing.SystemColors.Window
		Me._txEq_1.CausesValidation = True
		Me._txEq_1.Enabled = True
		Me._txEq_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txEq_1.HideSelection = True
		Me._txEq_1.Maxlength = 0
		Me._txEq_1.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txEq_1.MultiLine = False
		Me._txEq_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txEq_1.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txEq_1.TabStop = True
		Me._txEq_1.Visible = True
		Me._txEq_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txEq_1.Name = "_txEq_1"
		Me._txEq_0.AutoSize = False
		Me._txEq_0.Size = New System.Drawing.Size(289, 19)
		Me._txEq_0.Location = New System.Drawing.Point(56, 16)
		Me._txEq_0.ReadOnly = True
		Me._txEq_0.TabIndex = 10
		Me._txEq_0.Text = "Text1"
		Me._txEq_0.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txEq_0.AcceptsReturn = True
		Me._txEq_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txEq_0.BackColor = System.Drawing.SystemColors.Window
		Me._txEq_0.CausesValidation = True
		Me._txEq_0.Enabled = True
		Me._txEq_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txEq_0.HideSelection = True
		Me._txEq_0.Maxlength = 0
		Me._txEq_0.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txEq_0.MultiLine = False
		Me._txEq_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txEq_0.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txEq_0.TabStop = True
		Me._txEq_0.Visible = True
		Me._txEq_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txEq_0.Name = "_txEq_0"
		Me.Label4.Text = "R Magic"
		Me.Label4.Size = New System.Drawing.Size(41, 17)
		Me.Label4.Location = New System.Drawing.Point(216, 352)
		Me.Label4.TabIndex = 68
		Me.Label4.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label4.BackColor = System.Drawing.SystemColors.Control
		Me.Label4.Enabled = True
		Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label4.UseMnemonic = True
		Me.Label4.Visible = True
		Me.Label4.AutoSize = False
		Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label4.Name = "Label4"
		Me.Label3.Text = "R Elec"
		Me.Label3.Size = New System.Drawing.Size(33, 17)
		Me.Label3.Location = New System.Drawing.Point(216, 328)
		Me.Label3.TabIndex = 67
		Me.Label3.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label3.BackColor = System.Drawing.SystemColors.Control
		Me.Label3.Enabled = True
		Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.UseMnemonic = True
		Me.Label3.Visible = True
		Me.Label3.AutoSize = False
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label3.Name = "Label3"
		Me.Label2.Text = "R Cold"
		Me.Label2.Size = New System.Drawing.Size(33, 17)
		Me.Label2.Location = New System.Drawing.Point(216, 304)
		Me.Label2.TabIndex = 66
		Me.Label2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.BackColor = System.Drawing.SystemColors.Control
		Me.Label2.Enabled = True
		Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.lblRFire.Text = "R Fire"
		Me.lblRFire.Size = New System.Drawing.Size(33, 17)
		Me.lblRFire.Location = New System.Drawing.Point(216, 280)
		Me.lblRFire.TabIndex = 65
		Me.lblRFire.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblRFire.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblRFire.BackColor = System.Drawing.SystemColors.Control
		Me.lblRFire.Enabled = True
		Me.lblRFire.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblRFire.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblRFire.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblRFire.UseMnemonic = True
		Me.lblRFire.Visible = True
		Me.lblRFire.AutoSize = False
		Me.lblRFire.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblRFire.Name = "lblRFire"
		Me.lblGold.Text = "Gold"
		Me.lblGold.Size = New System.Drawing.Size(33, 17)
		Me.lblGold.Location = New System.Drawing.Point(216, 256)
		Me.lblGold.TabIndex = 61
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
		Me.Label1.Text = "DR"
		Me.Label1.Size = New System.Drawing.Size(41, 17)
		Me.Label1.Location = New System.Drawing.Point(216, 232)
		Me.Label1.TabIndex = 58
		Me.Label1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.SystemColors.Control
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.lblDam.Text = "Damage"
		Me.lblDam.Size = New System.Drawing.Size(41, 17)
		Me.lblDam.Location = New System.Drawing.Point(112, 256)
		Me.lblDam.TabIndex = 56
		Me.lblDam.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblDam.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblDam.BackColor = System.Drawing.SystemColors.Control
		Me.lblDam.Enabled = True
		Me.lblDam.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDam.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDam.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDam.UseMnemonic = True
		Me.lblDam.Visible = True
		Me.lblDam.AutoSize = False
		Me.lblDam.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblDam.Name = "lblDam"
		Me._lblStats_0.Text = "Strength"
		Me._lblStats_0.Size = New System.Drawing.Size(41, 17)
		Me._lblStats_0.Location = New System.Drawing.Point(8, 208)
		Me._lblStats_0.TabIndex = 55
		Me._lblStats_0.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._lblStats_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblStats_0.BackColor = System.Drawing.SystemColors.Control
		Me._lblStats_0.Enabled = True
		Me._lblStats_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblStats_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblStats_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblStats_0.UseMnemonic = True
		Me._lblStats_0.Visible = True
		Me._lblStats_0.AutoSize = False
		Me._lblStats_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblStats_0.Name = "_lblStats_0"
		Me._lblStats_1.Text = "Dexterity"
		Me._lblStats_1.Size = New System.Drawing.Size(41, 17)
		Me._lblStats_1.Location = New System.Drawing.Point(8, 232)
		Me._lblStats_1.TabIndex = 54
		Me._lblStats_1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._lblStats_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblStats_1.BackColor = System.Drawing.SystemColors.Control
		Me._lblStats_1.Enabled = True
		Me._lblStats_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblStats_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblStats_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblStats_1.UseMnemonic = True
		Me._lblStats_1.Visible = True
		Me._lblStats_1.AutoSize = False
		Me._lblStats_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblStats_1.Name = "_lblStats_1"
		Me._lblStats_2.Text = "Constitution"
		Me._lblStats_2.Size = New System.Drawing.Size(57, 17)
		Me._lblStats_2.Location = New System.Drawing.Point(8, 256)
		Me._lblStats_2.TabIndex = 53
		Me._lblStats_2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._lblStats_2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblStats_2.BackColor = System.Drawing.SystemColors.Control
		Me._lblStats_2.Enabled = True
		Me._lblStats_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblStats_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblStats_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblStats_2.UseMnemonic = True
		Me._lblStats_2.Visible = True
		Me._lblStats_2.AutoSize = False
		Me._lblStats_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblStats_2.Name = "_lblStats_2"
		Me._lblStats_3.Text = "Intelligence"
		Me._lblStats_3.Size = New System.Drawing.Size(57, 17)
		Me._lblStats_3.Location = New System.Drawing.Point(8, 280)
		Me._lblStats_3.TabIndex = 52
		Me._lblStats_3.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._lblStats_3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblStats_3.BackColor = System.Drawing.SystemColors.Control
		Me._lblStats_3.Enabled = True
		Me._lblStats_3.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblStats_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblStats_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblStats_3.UseMnemonic = True
		Me._lblStats_3.Visible = True
		Me._lblStats_3.AutoSize = False
		Me._lblStats_3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblStats_3.Name = "_lblStats_3"
		Me._lblStats_4.Text = "Wisdom"
		Me._lblStats_4.Size = New System.Drawing.Size(41, 17)
		Me._lblStats_4.Location = New System.Drawing.Point(8, 304)
		Me._lblStats_4.TabIndex = 51
		Me._lblStats_4.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._lblStats_4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblStats_4.BackColor = System.Drawing.SystemColors.Control
		Me._lblStats_4.Enabled = True
		Me._lblStats_4.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblStats_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblStats_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblStats_4.UseMnemonic = True
		Me._lblStats_4.Visible = True
		Me._lblStats_4.AutoSize = False
		Me._lblStats_4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblStats_4.Name = "_lblStats_4"
		Me._lblStats_5.Text = "Charisma"
		Me._lblStats_5.Size = New System.Drawing.Size(49, 17)
		Me._lblStats_5.Location = New System.Drawing.Point(8, 328)
		Me._lblStats_5.TabIndex = 50
		Me._lblStats_5.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._lblStats_5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblStats_5.BackColor = System.Drawing.SystemColors.Control
		Me._lblStats_5.Enabled = True
		Me._lblStats_5.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblStats_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblStats_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblStats_5.UseMnemonic = True
		Me._lblStats_5.Visible = True
		Me._lblStats_5.AutoSize = False
		Me._lblStats_5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblStats_5.Name = "_lblStats_5"
		Me._lblStats_6.Text = "Reputation"
		Me._lblStats_6.Size = New System.Drawing.Size(57, 17)
		Me._lblStats_6.Location = New System.Drawing.Point(8, 352)
		Me._lblStats_6.TabIndex = 49
		Me._lblStats_6.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._lblStats_6.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblStats_6.BackColor = System.Drawing.SystemColors.Control
		Me._lblStats_6.Enabled = True
		Me._lblStats_6.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblStats_6.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblStats_6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblStats_6.UseMnemonic = True
		Me._lblStats_6.Visible = True
		Me._lblStats_6.AutoSize = False
		Me._lblStats_6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblStats_6.Name = "_lblStats_6"
		Me._lblDervs_0.Text = "Str Attack"
		Me._lblDervs_0.Size = New System.Drawing.Size(49, 17)
		Me._lblDervs_0.Location = New System.Drawing.Point(112, 208)
		Me._lblDervs_0.TabIndex = 41
		Me._lblDervs_0.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._lblDervs_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblDervs_0.BackColor = System.Drawing.SystemColors.Control
		Me._lblDervs_0.Enabled = True
		Me._lblDervs_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblDervs_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblDervs_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblDervs_0.UseMnemonic = True
		Me._lblDervs_0.Visible = True
		Me._lblDervs_0.AutoSize = False
		Me._lblDervs_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblDervs_0.Name = "_lblDervs_0"
		Me._lblDervs_1.Text = "Dex Attack"
		Me._lblDervs_1.Size = New System.Drawing.Size(57, 17)
		Me._lblDervs_1.Location = New System.Drawing.Point(112, 232)
		Me._lblDervs_1.TabIndex = 40
		Me._lblDervs_1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._lblDervs_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblDervs_1.BackColor = System.Drawing.SystemColors.Control
		Me._lblDervs_1.Enabled = True
		Me._lblDervs_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblDervs_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblDervs_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblDervs_1.UseMnemonic = True
		Me._lblDervs_1.Visible = True
		Me._lblDervs_1.AutoSize = False
		Me._lblDervs_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblDervs_1.Name = "_lblDervs_1"
		Me._lblDervs_2.Text = "Defense"
		Me._lblDervs_2.Size = New System.Drawing.Size(49, 17)
		Me._lblDervs_2.Location = New System.Drawing.Point(216, 208)
		Me._lblDervs_2.TabIndex = 39
		Me._lblDervs_2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._lblDervs_2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblDervs_2.BackColor = System.Drawing.SystemColors.Control
		Me._lblDervs_2.Enabled = True
		Me._lblDervs_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblDervs_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblDervs_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblDervs_2.UseMnemonic = True
		Me._lblDervs_2.Visible = True
		Me._lblDervs_2.AutoSize = False
		Me._lblDervs_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblDervs_2.Name = "_lblDervs_2"
		Me._lblDervs_3.Text = "Hit Points"
		Me._lblDervs_3.Size = New System.Drawing.Size(49, 17)
		Me._lblDervs_3.Location = New System.Drawing.Point(112, 280)
		Me._lblDervs_3.TabIndex = 38
		Me._lblDervs_3.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._lblDervs_3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblDervs_3.BackColor = System.Drawing.SystemColors.Control
		Me._lblDervs_3.Enabled = True
		Me._lblDervs_3.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblDervs_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblDervs_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblDervs_3.UseMnemonic = True
		Me._lblDervs_3.Visible = True
		Me._lblDervs_3.AutoSize = False
		Me._lblDervs_3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblDervs_3.Name = "_lblDervs_3"
		Me._lblDervs_4.Text = "Speed"
		Me._lblDervs_4.Size = New System.Drawing.Size(49, 17)
		Me._lblDervs_4.Location = New System.Drawing.Point(112, 304)
		Me._lblDervs_4.TabIndex = 37
		Me._lblDervs_4.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._lblDervs_4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblDervs_4.BackColor = System.Drawing.SystemColors.Control
		Me._lblDervs_4.Enabled = True
		Me._lblDervs_4.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblDervs_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblDervs_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblDervs_4.UseMnemonic = True
		Me._lblDervs_4.Visible = True
		Me._lblDervs_4.AutoSize = False
		Me._lblDervs_4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblDervs_4.Name = "_lblDervs_4"
		Me._lblDervs_5.Text = "Perception"
		Me._lblDervs_5.Size = New System.Drawing.Size(49, 17)
		Me._lblDervs_5.Location = New System.Drawing.Point(112, 328)
		Me._lblDervs_5.TabIndex = 36
		Me._lblDervs_5.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._lblDervs_5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblDervs_5.BackColor = System.Drawing.SystemColors.Control
		Me._lblDervs_5.Enabled = True
		Me._lblDervs_5.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblDervs_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblDervs_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblDervs_5.UseMnemonic = True
		Me._lblDervs_5.Visible = True
		Me._lblDervs_5.AutoSize = False
		Me._lblDervs_5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblDervs_5.Name = "_lblDervs_5"
		Me._lblDervs_6.Text = "Luck"
		Me._lblDervs_6.Size = New System.Drawing.Size(49, 17)
		Me._lblDervs_6.Location = New System.Drawing.Point(112, 352)
		Me._lblDervs_6.TabIndex = 35
		Me._lblDervs_6.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._lblDervs_6.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblDervs_6.BackColor = System.Drawing.SystemColors.Control
		Me._lblDervs_6.Enabled = True
		Me._lblDervs_6.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblDervs_6.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblDervs_6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblDervs_6.UseMnemonic = True
		Me._lblDervs_6.Visible = True
		Me._lblDervs_6.AutoSize = False
		Me._lblDervs_6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblDervs_6.Name = "_lblDervs_6"
		Me._lblEq_7.Text = "Ring"
		Me._lblEq_7.Size = New System.Drawing.Size(49, 17)
		Me._lblEq_7.Location = New System.Drawing.Point(8, 184)
		Me._lblEq_7.TabIndex = 9
		Me._lblEq_7.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._lblEq_7.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblEq_7.BackColor = System.Drawing.SystemColors.Control
		Me._lblEq_7.Enabled = True
		Me._lblEq_7.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblEq_7.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblEq_7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblEq_7.UseMnemonic = True
		Me._lblEq_7.Visible = True
		Me._lblEq_7.AutoSize = False
		Me._lblEq_7.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblEq_7.Name = "_lblEq_7"
		Me._lblEq_6.Text = "Ring"
		Me._lblEq_6.Size = New System.Drawing.Size(49, 17)
		Me._lblEq_6.Location = New System.Drawing.Point(8, 160)
		Me._lblEq_6.TabIndex = 8
		Me._lblEq_6.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._lblEq_6.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblEq_6.BackColor = System.Drawing.SystemColors.Control
		Me._lblEq_6.Enabled = True
		Me._lblEq_6.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblEq_6.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblEq_6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblEq_6.UseMnemonic = True
		Me._lblEq_6.Visible = True
		Me._lblEq_6.AutoSize = False
		Me._lblEq_6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblEq_6.Name = "_lblEq_6"
		Me._lblEq_5.Text = "Boots"
		Me._lblEq_5.Size = New System.Drawing.Size(49, 17)
		Me._lblEq_5.Location = New System.Drawing.Point(8, 136)
		Me._lblEq_5.TabIndex = 7
		Me._lblEq_5.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._lblEq_5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblEq_5.BackColor = System.Drawing.SystemColors.Control
		Me._lblEq_5.Enabled = True
		Me._lblEq_5.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblEq_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblEq_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblEq_5.UseMnemonic = True
		Me._lblEq_5.Visible = True
		Me._lblEq_5.AutoSize = False
		Me._lblEq_5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblEq_5.Name = "_lblEq_5"
		Me._lblEq_4.Text = "Gauntlets"
		Me._lblEq_4.Size = New System.Drawing.Size(49, 17)
		Me._lblEq_4.Location = New System.Drawing.Point(8, 112)
		Me._lblEq_4.TabIndex = 6
		Me._lblEq_4.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._lblEq_4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblEq_4.BackColor = System.Drawing.SystemColors.Control
		Me._lblEq_4.Enabled = True
		Me._lblEq_4.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblEq_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblEq_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblEq_4.UseMnemonic = True
		Me._lblEq_4.Visible = True
		Me._lblEq_4.AutoSize = False
		Me._lblEq_4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblEq_4.Name = "_lblEq_4"
		Me._lblEq_3.Text = "Helmet"
		Me._lblEq_3.Size = New System.Drawing.Size(49, 17)
		Me._lblEq_3.Location = New System.Drawing.Point(8, 88)
		Me._lblEq_3.TabIndex = 5
		Me._lblEq_3.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._lblEq_3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblEq_3.BackColor = System.Drawing.SystemColors.Control
		Me._lblEq_3.Enabled = True
		Me._lblEq_3.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblEq_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblEq_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblEq_3.UseMnemonic = True
		Me._lblEq_3.Visible = True
		Me._lblEq_3.AutoSize = False
		Me._lblEq_3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblEq_3.Name = "_lblEq_3"
		Me._lblEq_2.Text = "Shield"
		Me._lblEq_2.Size = New System.Drawing.Size(49, 17)
		Me._lblEq_2.Location = New System.Drawing.Point(8, 64)
		Me._lblEq_2.TabIndex = 4
		Me._lblEq_2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._lblEq_2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblEq_2.BackColor = System.Drawing.SystemColors.Control
		Me._lblEq_2.Enabled = True
		Me._lblEq_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblEq_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblEq_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblEq_2.UseMnemonic = True
		Me._lblEq_2.Visible = True
		Me._lblEq_2.AutoSize = False
		Me._lblEq_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblEq_2.Name = "_lblEq_2"
		Me._lblEq_1.Text = "Armor"
		Me._lblEq_1.Size = New System.Drawing.Size(49, 17)
		Me._lblEq_1.Location = New System.Drawing.Point(8, 40)
		Me._lblEq_1.TabIndex = 3
		Me._lblEq_1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._lblEq_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblEq_1.BackColor = System.Drawing.SystemColors.Control
		Me._lblEq_1.Enabled = True
		Me._lblEq_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblEq_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblEq_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblEq_1.UseMnemonic = True
		Me._lblEq_1.Visible = True
		Me._lblEq_1.AutoSize = False
		Me._lblEq_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblEq_1.Name = "_lblEq_1"
		Me._lblEq_0.Text = "Weapon"
		Me._lblEq_0.Size = New System.Drawing.Size(49, 17)
		Me._lblEq_0.Location = New System.Drawing.Point(8, 16)
		Me._lblEq_0.TabIndex = 2
		Me._lblEq_0.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._lblEq_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblEq_0.BackColor = System.Drawing.SystemColors.Control
		Me._lblEq_0.Enabled = True
		Me._lblEq_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblEq_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblEq_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblEq_0.UseMnemonic = True
		Me._lblEq_0.Visible = True
		Me._lblEq_0.AutoSize = False
		Me._lblEq_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblEq_0.Name = "_lblEq_0"
		Me.Controls.Add(frCurrent)
		Me.Controls.Add(frInven)
		Me.Controls.Add(frEquip)
		Me.frCurrent.Controls.Add(txValue)
		Me.frCurrent.Controls.Add(txCur)
		Me.frCurrent.Controls.Add(lblValue)
		Me.frInven.Controls.Add(cmdPickUp)
		Me.frInven.Controls.Add(txPickUp)
		Me.frInven.Controls.Add(lstInven)
		Me.frEquip.Controls.Add(cmdID)
		Me.frEquip.Controls.Add(_txRes_3)
		Me.frEquip.Controls.Add(_txRes_2)
		Me.frEquip.Controls.Add(_txRes_1)
		Me.frEquip.Controls.Add(_txRes_0)
		Me.frEquip.Controls.Add(txGold)
		Me.frEquip.Controls.Add(cmdDrop)
		Me.frEquip.Controls.Add(txDR)
		Me.frEquip.Controls.Add(txDam)
		Me.frEquip.Controls.Add(_txStats_0)
		Me.frEquip.Controls.Add(_txStats_1)
		Me.frEquip.Controls.Add(_txStats_2)
		Me.frEquip.Controls.Add(_txStats_3)
		Me.frEquip.Controls.Add(_txStats_4)
		Me.frEquip.Controls.Add(_txStats_5)
		Me.frEquip.Controls.Add(_txStats_6)
		Me.frEquip.Controls.Add(_txDervs_0)
		Me.frEquip.Controls.Add(_txDervs_1)
		Me.frEquip.Controls.Add(_txDervs_2)
		Me.frEquip.Controls.Add(_txDervs_3)
		Me.frEquip.Controls.Add(_txDervs_4)
		Me.frEquip.Controls.Add(_txDervs_5)
		Me.frEquip.Controls.Add(_txDervs_6)
		Me.frEquip.Controls.Add(_cmdUneq_7)
		Me.frEquip.Controls.Add(_cmdUneq_6)
		Me.frEquip.Controls.Add(_cmdUneq_5)
		Me.frEquip.Controls.Add(_cmdUneq_4)
		Me.frEquip.Controls.Add(_cmdUneq_3)
		Me.frEquip.Controls.Add(_cmdUneq_2)
		Me.frEquip.Controls.Add(_cmdUneq_1)
		Me.frEquip.Controls.Add(_cmdUneq_0)
		Me.frEquip.Controls.Add(cmdDone)
		Me.frEquip.Controls.Add(_txEq_7)
		Me.frEquip.Controls.Add(_txEq_6)
		Me.frEquip.Controls.Add(_txEq_5)
		Me.frEquip.Controls.Add(_txEq_4)
		Me.frEquip.Controls.Add(_txEq_3)
		Me.frEquip.Controls.Add(_txEq_2)
		Me.frEquip.Controls.Add(_txEq_1)
		Me.frEquip.Controls.Add(_txEq_0)
		Me.frEquip.Controls.Add(Label4)
		Me.frEquip.Controls.Add(Label3)
		Me.frEquip.Controls.Add(Label2)
		Me.frEquip.Controls.Add(lblRFire)
		Me.frEquip.Controls.Add(lblGold)
		Me.frEquip.Controls.Add(Label1)
		Me.frEquip.Controls.Add(lblDam)
		Me.frEquip.Controls.Add(_lblStats_0)
		Me.frEquip.Controls.Add(_lblStats_1)
		Me.frEquip.Controls.Add(_lblStats_2)
		Me.frEquip.Controls.Add(_lblStats_3)
		Me.frEquip.Controls.Add(_lblStats_4)
		Me.frEquip.Controls.Add(_lblStats_5)
		Me.frEquip.Controls.Add(_lblStats_6)
		Me.frEquip.Controls.Add(_lblDervs_0)
		Me.frEquip.Controls.Add(_lblDervs_1)
		Me.frEquip.Controls.Add(_lblDervs_2)
		Me.frEquip.Controls.Add(_lblDervs_3)
		Me.frEquip.Controls.Add(_lblDervs_4)
		Me.frEquip.Controls.Add(_lblDervs_5)
		Me.frEquip.Controls.Add(_lblDervs_6)
		Me.frEquip.Controls.Add(_lblEq_7)
		Me.frEquip.Controls.Add(_lblEq_6)
		Me.frEquip.Controls.Add(_lblEq_5)
		Me.frEquip.Controls.Add(_lblEq_4)
		Me.frEquip.Controls.Add(_lblEq_3)
		Me.frEquip.Controls.Add(_lblEq_2)
		Me.frEquip.Controls.Add(_lblEq_1)
		Me.frEquip.Controls.Add(_lblEq_0)
		Me.cmdUneq.SetIndex(_cmdUneq_7, CType(7, Short))
		Me.cmdUneq.SetIndex(_cmdUneq_6, CType(6, Short))
		Me.cmdUneq.SetIndex(_cmdUneq_5, CType(5, Short))
		Me.cmdUneq.SetIndex(_cmdUneq_4, CType(4, Short))
		Me.cmdUneq.SetIndex(_cmdUneq_3, CType(3, Short))
		Me.cmdUneq.SetIndex(_cmdUneq_2, CType(2, Short))
		Me.cmdUneq.SetIndex(_cmdUneq_1, CType(1, Short))
		Me.cmdUneq.SetIndex(_cmdUneq_0, CType(0, Short))
		Me.lblDervs.SetIndex(_lblDervs_0, CType(0, Short))
		Me.lblDervs.SetIndex(_lblDervs_1, CType(1, Short))
		Me.lblDervs.SetIndex(_lblDervs_2, CType(2, Short))
		Me.lblDervs.SetIndex(_lblDervs_3, CType(3, Short))
		Me.lblDervs.SetIndex(_lblDervs_4, CType(4, Short))
		Me.lblDervs.SetIndex(_lblDervs_5, CType(5, Short))
		Me.lblDervs.SetIndex(_lblDervs_6, CType(6, Short))
		Me.lblEq.SetIndex(_lblEq_7, CType(7, Short))
		Me.lblEq.SetIndex(_lblEq_6, CType(6, Short))
		Me.lblEq.SetIndex(_lblEq_5, CType(5, Short))
		Me.lblEq.SetIndex(_lblEq_4, CType(4, Short))
		Me.lblEq.SetIndex(_lblEq_3, CType(3, Short))
		Me.lblEq.SetIndex(_lblEq_2, CType(2, Short))
		Me.lblEq.SetIndex(_lblEq_1, CType(1, Short))
		Me.lblEq.SetIndex(_lblEq_0, CType(0, Short))
		Me.lblStats.SetIndex(_lblStats_0, CType(0, Short))
		Me.lblStats.SetIndex(_lblStats_1, CType(1, Short))
		Me.lblStats.SetIndex(_lblStats_2, CType(2, Short))
		Me.lblStats.SetIndex(_lblStats_3, CType(3, Short))
		Me.lblStats.SetIndex(_lblStats_4, CType(4, Short))
		Me.lblStats.SetIndex(_lblStats_5, CType(5, Short))
		Me.lblStats.SetIndex(_lblStats_6, CType(6, Short))
		Me.txDervs.SetIndex(_txDervs_0, CType(0, Short))
		Me.txDervs.SetIndex(_txDervs_1, CType(1, Short))
		Me.txDervs.SetIndex(_txDervs_2, CType(2, Short))
		Me.txDervs.SetIndex(_txDervs_3, CType(3, Short))
		Me.txDervs.SetIndex(_txDervs_4, CType(4, Short))
		Me.txDervs.SetIndex(_txDervs_5, CType(5, Short))
		Me.txDervs.SetIndex(_txDervs_6, CType(6, Short))
		Me.txEq.SetIndex(_txEq_7, CType(7, Short))
		Me.txEq.SetIndex(_txEq_6, CType(6, Short))
		Me.txEq.SetIndex(_txEq_5, CType(5, Short))
		Me.txEq.SetIndex(_txEq_4, CType(4, Short))
		Me.txEq.SetIndex(_txEq_3, CType(3, Short))
		Me.txEq.SetIndex(_txEq_2, CType(2, Short))
		Me.txEq.SetIndex(_txEq_1, CType(1, Short))
		Me.txEq.SetIndex(_txEq_0, CType(0, Short))
		Me.txRes.SetIndex(_txRes_3, CType(3, Short))
		Me.txRes.SetIndex(_txRes_2, CType(2, Short))
		Me.txRes.SetIndex(_txRes_1, CType(1, Short))
		Me.txRes.SetIndex(_txRes_0, CType(0, Short))
		Me.txStats.SetIndex(_txStats_0, CType(0, Short))
		Me.txStats.SetIndex(_txStats_1, CType(1, Short))
		Me.txStats.SetIndex(_txStats_2, CType(2, Short))
		Me.txStats.SetIndex(_txStats_3, CType(3, Short))
		Me.txStats.SetIndex(_txStats_4, CType(4, Short))
		Me.txStats.SetIndex(_txStats_5, CType(5, Short))
		Me.txStats.SetIndex(_txStats_6, CType(6, Short))
		CType(Me.txStats, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txRes, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txEq, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txDervs, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.lblStats, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.lblEq, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.lblDervs, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.cmdUneq, System.ComponentModel.ISupportInitialize).EndInit()
		Me.frCurrent.ResumeLayout(False)
		Me.frInven.ResumeLayout(False)
		Me.frEquip.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class