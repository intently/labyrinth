<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmGame
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
	Public WithEvents txPoints As System.Windows.Forms.TextBox
	Public WithEvents lstPeople As System.Windows.Forms.ListBox
	Public WithEvents cmdCity As System.Windows.Forms.Button
	Public WithEvents txLoc As System.Windows.Forms.TextBox
	Public WithEvents txGameDate As System.Windows.Forms.TextBox
	Public WithEvents txHP As System.Windows.Forms.TextBox
	Public WithEvents txGold As System.Windows.Forms.TextBox
	Public WithEvents lstEvents As System.Windows.Forms.ListBox
	Public WithEvents txCur As System.Windows.Forms.TextBox
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents lblLoc As System.Windows.Forms.Label
	Public WithEvents lblDate As System.Windows.Forms.Label
	Public WithEvents lblHP As System.Windows.Forms.Label
	Public WithEvents lblGold As System.Windows.Forms.Label
	Public WithEvents _imgTer_5 As System.Windows.Forms.PictureBox
	Public WithEvents _imgCit_5 As System.Windows.Forms.PictureBox
	Public WithEvents _imgMoveRoad_5 As System.Windows.Forms.PictureBox
	Public WithEvents frLocation As System.Windows.Forms.GroupBox
	Public WithEvents _cmdMove_3 As System.Windows.Forms.Button
	Public WithEvents txShowRoute As System.Windows.Forms.TextBox
	Public WithEvents txRoute As System.Windows.Forms.TextBox
	Public WithEvents cmdRoute As System.Windows.Forms.Button
	Public WithEvents _txMove_4 As System.Windows.Forms.TextBox
	Public WithEvents _txMove_3 As System.Windows.Forms.TextBox
	Public WithEvents _txMove_2 As System.Windows.Forms.TextBox
	Public WithEvents _txMove_1 As System.Windows.Forms.TextBox
	Public WithEvents _txMove_0 As System.Windows.Forms.TextBox
	Public WithEvents _cmdMove_4 As System.Windows.Forms.Button
	Public WithEvents _cmdMove_2 As System.Windows.Forms.Button
	Public WithEvents _cmdMove_1 As System.Windows.Forms.Button
	Public WithEvents _cmdMove_0 As System.Windows.Forms.Button
	Public WithEvents _imgCit_4 As System.Windows.Forms.PictureBox
	Public WithEvents _imgCit_3 As System.Windows.Forms.PictureBox
	Public WithEvents _imgCit_2 As System.Windows.Forms.PictureBox
	Public WithEvents _imgCit_1 As System.Windows.Forms.PictureBox
	Public WithEvents _imgCit_0 As System.Windows.Forms.PictureBox
	Public WithEvents _imgTer_4 As System.Windows.Forms.PictureBox
	Public WithEvents _imgTer_3 As System.Windows.Forms.PictureBox
	Public WithEvents _imgTer_2 As System.Windows.Forms.PictureBox
	Public WithEvents _imgTer_1 As System.Windows.Forms.PictureBox
	Public WithEvents _imgTer_0 As System.Windows.Forms.PictureBox
	Public WithEvents _imgMoveRoad_4 As System.Windows.Forms.PictureBox
	Public WithEvents _imgMoveRoad_3 As System.Windows.Forms.PictureBox
	Public WithEvents _imgMoveRoad_2 As System.Windows.Forms.PictureBox
	Public WithEvents _imgMoveRoad_1 As System.Windows.Forms.PictureBox
	Public WithEvents _imgMoveRoad_0 As System.Windows.Forms.PictureBox
	Public WithEvents _imgMoveExp_4 As System.Windows.Forms.PictureBox
	Public WithEvents _imgMoveExp_3 As System.Windows.Forms.PictureBox
	Public WithEvents _imgMoveExp_2 As System.Windows.Forms.PictureBox
	Public WithEvents _imgMoveExp_1 As System.Windows.Forms.PictureBox
	Public WithEvents _imgMoveExp_0 As System.Windows.Forms.PictureBox
	Public WithEvents frMove As System.Windows.Forms.GroupBox
	Public WithEvents cmdMap As System.Windows.Forms.Button
	Public WithEvents cmdRad As System.Windows.Forms.Button
	Public WithEvents ckCombat As System.Windows.Forms.CheckBox
	Public WithEvents cmdCheat As System.Windows.Forms.Button
	Public WithEvents cmdQuit As System.Windows.Forms.Button
	Public WithEvents frDisk As System.Windows.Forms.GroupBox
	Public WithEvents cmdStats As System.Windows.Forms.Button
	Public WithEvents cmdMagic As System.Windows.Forms.Button
	Public WithEvents cmdPlaces As System.Windows.Forms.Button
	Public WithEvents cmdRest As System.Windows.Forms.Button
	Public WithEvents cmdInven As System.Windows.Forms.Button
	Public WithEvents cmdChar As System.Windows.Forms.Button
	Public WithEvents frControls As System.Windows.Forms.GroupBox
	Public WithEvents imgCitHH As System.Windows.Forms.PictureBox
	Public WithEvents imgCitSlums As System.Windows.Forms.PictureBox
	Public WithEvents imgCitCross As System.Windows.Forms.PictureBox
	Public WithEvents imgCitCity As System.Windows.Forms.PictureBox
	Public WithEvents _imgTerrain_6 As System.Windows.Forms.PictureBox
	Public WithEvents _imgTerrain_5 As System.Windows.Forms.PictureBox
	Public WithEvents _imgTerrain_7 As System.Windows.Forms.PictureBox
	Public WithEvents _imgTerrain_3 As System.Windows.Forms.PictureBox
	Public WithEvents _imgTerrain_2 As System.Windows.Forms.PictureBox
	Public WithEvents _imgTerrain_1 As System.Windows.Forms.PictureBox
	Public WithEvents _imgTerrain_4 As System.Windows.Forms.PictureBox
	Public WithEvents _imgTerrain_0 As System.Windows.Forms.PictureBox
	Public WithEvents cmdMove As Microsoft.VisualBasic.Compatibility.VB6.ButtonArray
	Public WithEvents imgCit As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents imgMoveExp As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents imgMoveRoad As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents imgTer As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents imgTerrain As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents txMove As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmGame))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.frLocation = New System.Windows.Forms.GroupBox
		Me.txPoints = New System.Windows.Forms.TextBox
		Me.lstPeople = New System.Windows.Forms.ListBox
		Me.cmdCity = New System.Windows.Forms.Button
		Me.txLoc = New System.Windows.Forms.TextBox
		Me.txGameDate = New System.Windows.Forms.TextBox
		Me.txHP = New System.Windows.Forms.TextBox
		Me.txGold = New System.Windows.Forms.TextBox
		Me.lstEvents = New System.Windows.Forms.ListBox
		Me.txCur = New System.Windows.Forms.TextBox
		Me.Label1 = New System.Windows.Forms.Label
		Me.lblLoc = New System.Windows.Forms.Label
		Me.lblDate = New System.Windows.Forms.Label
		Me.lblHP = New System.Windows.Forms.Label
		Me.lblGold = New System.Windows.Forms.Label
		Me._imgTer_5 = New System.Windows.Forms.PictureBox
		Me._imgCit_5 = New System.Windows.Forms.PictureBox
		Me._imgMoveRoad_5 = New System.Windows.Forms.PictureBox
		Me.frMove = New System.Windows.Forms.GroupBox
		Me._cmdMove_3 = New System.Windows.Forms.Button
		Me.txShowRoute = New System.Windows.Forms.TextBox
		Me.txRoute = New System.Windows.Forms.TextBox
		Me.cmdRoute = New System.Windows.Forms.Button
		Me._txMove_4 = New System.Windows.Forms.TextBox
		Me._txMove_3 = New System.Windows.Forms.TextBox
		Me._txMove_2 = New System.Windows.Forms.TextBox
		Me._txMove_1 = New System.Windows.Forms.TextBox
		Me._txMove_0 = New System.Windows.Forms.TextBox
		Me._cmdMove_4 = New System.Windows.Forms.Button
		Me._cmdMove_2 = New System.Windows.Forms.Button
		Me._cmdMove_1 = New System.Windows.Forms.Button
		Me._cmdMove_0 = New System.Windows.Forms.Button
		Me._imgCit_4 = New System.Windows.Forms.PictureBox
		Me._imgCit_3 = New System.Windows.Forms.PictureBox
		Me._imgCit_2 = New System.Windows.Forms.PictureBox
		Me._imgCit_1 = New System.Windows.Forms.PictureBox
		Me._imgCit_0 = New System.Windows.Forms.PictureBox
		Me._imgTer_4 = New System.Windows.Forms.PictureBox
		Me._imgTer_3 = New System.Windows.Forms.PictureBox
		Me._imgTer_2 = New System.Windows.Forms.PictureBox
		Me._imgTer_1 = New System.Windows.Forms.PictureBox
		Me._imgTer_0 = New System.Windows.Forms.PictureBox
		Me._imgMoveRoad_4 = New System.Windows.Forms.PictureBox
		Me._imgMoveRoad_3 = New System.Windows.Forms.PictureBox
		Me._imgMoveRoad_2 = New System.Windows.Forms.PictureBox
		Me._imgMoveRoad_1 = New System.Windows.Forms.PictureBox
		Me._imgMoveRoad_0 = New System.Windows.Forms.PictureBox
		Me._imgMoveExp_4 = New System.Windows.Forms.PictureBox
		Me._imgMoveExp_3 = New System.Windows.Forms.PictureBox
		Me._imgMoveExp_2 = New System.Windows.Forms.PictureBox
		Me._imgMoveExp_1 = New System.Windows.Forms.PictureBox
		Me._imgMoveExp_0 = New System.Windows.Forms.PictureBox
		Me.frDisk = New System.Windows.Forms.GroupBox
		Me.cmdMap = New System.Windows.Forms.Button
		Me.cmdRad = New System.Windows.Forms.Button
		Me.ckCombat = New System.Windows.Forms.CheckBox
		Me.cmdCheat = New System.Windows.Forms.Button
		Me.cmdQuit = New System.Windows.Forms.Button
		Me.frControls = New System.Windows.Forms.GroupBox
		Me.cmdStats = New System.Windows.Forms.Button
		Me.cmdMagic = New System.Windows.Forms.Button
		Me.cmdPlaces = New System.Windows.Forms.Button
		Me.cmdRest = New System.Windows.Forms.Button
		Me.cmdInven = New System.Windows.Forms.Button
		Me.cmdChar = New System.Windows.Forms.Button
		Me.imgCitHH = New System.Windows.Forms.PictureBox
		Me.imgCitSlums = New System.Windows.Forms.PictureBox
		Me.imgCitCross = New System.Windows.Forms.PictureBox
		Me.imgCitCity = New System.Windows.Forms.PictureBox
		Me._imgTerrain_6 = New System.Windows.Forms.PictureBox
		Me._imgTerrain_5 = New System.Windows.Forms.PictureBox
		Me._imgTerrain_7 = New System.Windows.Forms.PictureBox
		Me._imgTerrain_3 = New System.Windows.Forms.PictureBox
		Me._imgTerrain_2 = New System.Windows.Forms.PictureBox
		Me._imgTerrain_1 = New System.Windows.Forms.PictureBox
		Me._imgTerrain_4 = New System.Windows.Forms.PictureBox
		Me._imgTerrain_0 = New System.Windows.Forms.PictureBox
		Me.cmdMove = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(components)
		Me.imgCit = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
		Me.imgMoveExp = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
		Me.imgMoveRoad = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
		Me.imgTer = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
		Me.imgTerrain = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
		Me.txMove = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
		Me.frLocation.SuspendLayout()
		Me.frMove.SuspendLayout()
		Me.frDisk.SuspendLayout()
		Me.frControls.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.cmdMove, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.imgCit, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.imgMoveExp, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.imgMoveRoad, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.imgTer, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.imgTerrain, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txMove, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Labyrinth"
		Me.ClientSize = New System.Drawing.Size(601, 473)
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
		Me.Name = "frmGame"
		Me.frLocation.Text = "Current Location"
		Me.frLocation.Size = New System.Drawing.Size(601, 217)
		Me.frLocation.Location = New System.Drawing.Point(0, 0)
		Me.frLocation.TabIndex = 21
		Me.frLocation.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.frLocation.BackColor = System.Drawing.SystemColors.Control
		Me.frLocation.Enabled = True
		Me.frLocation.ForeColor = System.Drawing.SystemColors.ControlText
		Me.frLocation.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.frLocation.Visible = True
		Me.frLocation.Padding = New System.Windows.Forms.Padding(0)
		Me.frLocation.Name = "frLocation"
		Me.txPoints.AutoSize = False
		Me.txPoints.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txPoints.Size = New System.Drawing.Size(105, 19)
		Me.txPoints.Location = New System.Drawing.Point(488, 192)
		Me.txPoints.TabIndex = 40
		Me.txPoints.Text = "Text1"
		Me.txPoints.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txPoints.AcceptsReturn = True
		Me.txPoints.BackColor = System.Drawing.SystemColors.Window
		Me.txPoints.CausesValidation = True
		Me.txPoints.Enabled = True
		Me.txPoints.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txPoints.HideSelection = True
		Me.txPoints.ReadOnly = False
		Me.txPoints.Maxlength = 0
		Me.txPoints.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txPoints.MultiLine = False
		Me.txPoints.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txPoints.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txPoints.TabStop = True
		Me.txPoints.Visible = True
		Me.txPoints.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txPoints.Name = "txPoints"
		Me.lstPeople.Size = New System.Drawing.Size(105, 163)
		Me.lstPeople.Location = New System.Drawing.Point(488, 16)
		Me.lstPeople.TabIndex = 37
		Me.lstPeople.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lstPeople.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lstPeople.BackColor = System.Drawing.SystemColors.Window
		Me.lstPeople.CausesValidation = True
		Me.lstPeople.Enabled = True
		Me.lstPeople.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lstPeople.IntegralHeight = True
		Me.lstPeople.Cursor = System.Windows.Forms.Cursors.Default
		Me.lstPeople.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.lstPeople.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lstPeople.Sorted = False
		Me.lstPeople.TabStop = True
		Me.lstPeople.Visible = True
		Me.lstPeople.MultiColumn = False
		Me.lstPeople.Name = "lstPeople"
		Me.cmdCity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCity.Text = "Enter"
		Me.cmdCity.Size = New System.Drawing.Size(105, 25)
		Me.cmdCity.Location = New System.Drawing.Point(232, 184)
		Me.cmdCity.TabIndex = 32
		Me.cmdCity.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdCity.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCity.CausesValidation = True
		Me.cmdCity.Enabled = True
		Me.cmdCity.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCity.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCity.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCity.TabStop = True
		Me.cmdCity.Name = "cmdCity"
		Me.txLoc.AutoSize = False
		Me.txLoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txLoc.Size = New System.Drawing.Size(65, 19)
		Me.txLoc.Location = New System.Drawing.Point(80, 192)
		Me.txLoc.ReadOnly = True
		Me.txLoc.TabIndex = 27
		Me.txLoc.Text = "Text1"
		Me.txLoc.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txLoc.AcceptsReturn = True
		Me.txLoc.BackColor = System.Drawing.SystemColors.Window
		Me.txLoc.CausesValidation = True
		Me.txLoc.Enabled = True
		Me.txLoc.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txLoc.HideSelection = True
		Me.txLoc.Maxlength = 0
		Me.txLoc.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txLoc.MultiLine = False
		Me.txLoc.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txLoc.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txLoc.TabStop = True
		Me.txLoc.Visible = True
		Me.txLoc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txLoc.Name = "txLoc"
		Me.txGameDate.AutoSize = False
		Me.txGameDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txGameDate.Size = New System.Drawing.Size(65, 19)
		Me.txGameDate.Location = New System.Drawing.Point(8, 192)
		Me.txGameDate.ReadOnly = True
		Me.txGameDate.TabIndex = 26
		Me.txGameDate.Text = "Text1"
		Me.txGameDate.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txGameDate.AcceptsReturn = True
		Me.txGameDate.BackColor = System.Drawing.SystemColors.Window
		Me.txGameDate.CausesValidation = True
		Me.txGameDate.Enabled = True
		Me.txGameDate.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txGameDate.HideSelection = True
		Me.txGameDate.Maxlength = 0
		Me.txGameDate.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txGameDate.MultiLine = False
		Me.txGameDate.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txGameDate.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txGameDate.TabStop = True
		Me.txGameDate.Visible = True
		Me.txGameDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txGameDate.Name = "txGameDate"
		Me.txHP.AutoSize = False
		Me.txHP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txHP.Size = New System.Drawing.Size(65, 19)
		Me.txHP.Location = New System.Drawing.Point(344, 192)
		Me.txHP.ReadOnly = True
		Me.txHP.TabIndex = 25
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
		Me.txHP.TabStop = True
		Me.txHP.Visible = True
		Me.txHP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txHP.Name = "txHP"
		Me.txGold.AutoSize = False
		Me.txGold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txGold.Size = New System.Drawing.Size(65, 19)
		Me.txGold.Location = New System.Drawing.Point(416, 192)
		Me.txGold.ReadOnly = True
		Me.txGold.TabIndex = 24
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
		Me.lstEvents.Size = New System.Drawing.Size(233, 163)
		Me.lstEvents.Location = New System.Drawing.Point(248, 16)
		Me.lstEvents.TabIndex = 23
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
		Me.lstEvents.TabStop = True
		Me.lstEvents.Visible = True
		Me.lstEvents.MultiColumn = False
		Me.lstEvents.Name = "lstEvents"
		Me.txCur.AutoSize = False
		Me.txCur.Size = New System.Drawing.Size(233, 161)
		Me.txCur.Location = New System.Drawing.Point(8, 16)
		Me.txCur.ReadOnly = True
		Me.txCur.MultiLine = True
		Me.txCur.TabIndex = 22
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
		Me.txCur.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txCur.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txCur.TabStop = True
		Me.txCur.Visible = True
		Me.txCur.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txCur.Name = "txCur"
		Me.Label1.Text = "Points"
		Me.Label1.Size = New System.Drawing.Size(41, 17)
		Me.Label1.Location = New System.Drawing.Point(488, 176)
		Me.Label1.TabIndex = 39
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
		Me.lblLoc.Text = "Area"
		Me.lblLoc.Size = New System.Drawing.Size(33, 17)
		Me.lblLoc.Location = New System.Drawing.Point(80, 176)
		Me.lblLoc.TabIndex = 31
		Me.lblLoc.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblLoc.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblLoc.BackColor = System.Drawing.SystemColors.Control
		Me.lblLoc.Enabled = True
		Me.lblLoc.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblLoc.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblLoc.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblLoc.UseMnemonic = True
		Me.lblLoc.Visible = True
		Me.lblLoc.AutoSize = False
		Me.lblLoc.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblLoc.Name = "lblLoc"
		Me.lblDate.Text = "Date"
		Me.lblDate.Size = New System.Drawing.Size(41, 17)
		Me.lblDate.Location = New System.Drawing.Point(8, 176)
		Me.lblDate.TabIndex = 30
		Me.lblDate.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblDate.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblDate.BackColor = System.Drawing.SystemColors.Control
		Me.lblDate.Enabled = True
		Me.lblDate.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDate.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDate.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDate.UseMnemonic = True
		Me.lblDate.Visible = True
		Me.lblDate.AutoSize = False
		Me.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblDate.Name = "lblDate"
		Me.lblHP.Text = "Hit Points"
		Me.lblHP.Size = New System.Drawing.Size(49, 17)
		Me.lblHP.Location = New System.Drawing.Point(344, 176)
		Me.lblHP.TabIndex = 29
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
		Me.lblGold.Text = "Gold Coins"
		Me.lblGold.Size = New System.Drawing.Size(57, 17)
		Me.lblGold.Location = New System.Drawing.Point(416, 176)
		Me.lblGold.TabIndex = 28
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
		Me._imgTer_5.Size = New System.Drawing.Size(17, 17)
		Me._imgTer_5.Location = New System.Drawing.Point(208, 192)
		Me._imgTer_5.Enabled = True
		Me._imgTer_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._imgTer_5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._imgTer_5.Visible = True
		Me._imgTer_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._imgTer_5.Name = "_imgTer_5"
		Me._imgCit_5.Size = New System.Drawing.Size(17, 17)
		Me._imgCit_5.Location = New System.Drawing.Point(192, 192)
		Me._imgCit_5.Enabled = True
		Me._imgCit_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._imgCit_5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._imgCit_5.Visible = True
		Me._imgCit_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._imgCit_5.Name = "_imgCit_5"
		Me._imgMoveRoad_5.Size = New System.Drawing.Size(17, 17)
		Me._imgMoveRoad_5.Location = New System.Drawing.Point(152, 192)
		Me._imgMoveRoad_5.Image = CType(resources.GetObject("_imgMoveRoad_5.Image"), System.Drawing.Image)
		Me._imgMoveRoad_5.Enabled = True
		Me._imgMoveRoad_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._imgMoveRoad_5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._imgMoveRoad_5.Visible = True
		Me._imgMoveRoad_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._imgMoveRoad_5.Name = "_imgMoveRoad_5"
		Me.frMove.Size = New System.Drawing.Size(489, 201)
		Me.frMove.Location = New System.Drawing.Point(0, 216)
		Me.frMove.TabIndex = 0
		Me.frMove.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.frMove.BackColor = System.Drawing.SystemColors.Control
		Me.frMove.Enabled = True
		Me.frMove.ForeColor = System.Drawing.SystemColors.ControlText
		Me.frMove.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.frMove.Visible = True
		Me.frMove.Padding = New System.Windows.Forms.Padding(0)
		Me.frMove.Name = "frMove"
		Me._cmdMove_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._cmdMove_3.Text = "Command1"
		Me._cmdMove_3.Size = New System.Drawing.Size(89, 33)
		Me._cmdMove_3.Location = New System.Drawing.Point(296, 16)
		Me._cmdMove_3.TabIndex = 16
		Me._cmdMove_3.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._cmdMove_3.BackColor = System.Drawing.SystemColors.Control
		Me._cmdMove_3.CausesValidation = True
		Me._cmdMove_3.Enabled = True
		Me._cmdMove_3.ForeColor = System.Drawing.SystemColors.ControlText
		Me._cmdMove_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._cmdMove_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._cmdMove_3.TabStop = True
		Me._cmdMove_3.Name = "_cmdMove_3"
		Me.txShowRoute.AutoSize = False
		Me.txShowRoute.Size = New System.Drawing.Size(281, 19)
		Me.txShowRoute.Location = New System.Drawing.Point(200, 176)
		Me.txShowRoute.ReadOnly = True
		Me.txShowRoute.TabIndex = 15
		Me.txShowRoute.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txShowRoute.AcceptsReturn = True
		Me.txShowRoute.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txShowRoute.BackColor = System.Drawing.SystemColors.Window
		Me.txShowRoute.CausesValidation = True
		Me.txShowRoute.Enabled = True
		Me.txShowRoute.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txShowRoute.HideSelection = True
		Me.txShowRoute.Maxlength = 0
		Me.txShowRoute.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txShowRoute.MultiLine = False
		Me.txShowRoute.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txShowRoute.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txShowRoute.TabStop = True
		Me.txShowRoute.Visible = True
		Me.txShowRoute.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txShowRoute.Name = "txShowRoute"
		Me.txRoute.AutoSize = False
		Me.txRoute.Size = New System.Drawing.Size(89, 19)
		Me.txRoute.Location = New System.Drawing.Point(104, 176)
		Me.txRoute.TabIndex = 14
		Me.txRoute.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txRoute.AcceptsReturn = True
		Me.txRoute.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txRoute.BackColor = System.Drawing.SystemColors.Window
		Me.txRoute.CausesValidation = True
		Me.txRoute.Enabled = True
		Me.txRoute.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txRoute.HideSelection = True
		Me.txRoute.ReadOnly = False
		Me.txRoute.Maxlength = 0
		Me.txRoute.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txRoute.MultiLine = False
		Me.txRoute.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txRoute.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txRoute.TabStop = True
		Me.txRoute.Visible = True
		Me.txRoute.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txRoute.Name = "txRoute"
		Me.cmdRoute.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRoute.Text = "Route"
		Me.cmdRoute.Size = New System.Drawing.Size(89, 17)
		Me.cmdRoute.Location = New System.Drawing.Point(8, 176)
		Me.cmdRoute.TabIndex = 13
		Me.cmdRoute.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdRoute.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRoute.CausesValidation = True
		Me.cmdRoute.Enabled = True
		Me.cmdRoute.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRoute.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRoute.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRoute.TabStop = True
		Me.cmdRoute.Name = "cmdRoute"
		Me._txMove_4.AutoSize = False
		Me._txMove_4.Size = New System.Drawing.Size(89, 105)
		Me._txMove_4.Location = New System.Drawing.Point(392, 64)
		Me._txMove_4.ReadOnly = True
		Me._txMove_4.MultiLine = True
		Me._txMove_4.TabIndex = 9
		Me._txMove_4.Text = "Text1"
		Me._txMove_4.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txMove_4.AcceptsReturn = True
		Me._txMove_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txMove_4.BackColor = System.Drawing.SystemColors.Window
		Me._txMove_4.CausesValidation = True
		Me._txMove_4.Enabled = True
		Me._txMove_4.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txMove_4.HideSelection = True
		Me._txMove_4.Maxlength = 0
		Me._txMove_4.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txMove_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txMove_4.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txMove_4.TabStop = True
		Me._txMove_4.Visible = True
		Me._txMove_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txMove_4.Name = "_txMove_4"
		Me._txMove_3.AutoSize = False
		Me._txMove_3.Size = New System.Drawing.Size(89, 105)
		Me._txMove_3.Location = New System.Drawing.Point(296, 64)
		Me._txMove_3.ReadOnly = True
		Me._txMove_3.MultiLine = True
		Me._txMove_3.TabIndex = 8
		Me._txMove_3.Text = "Text1"
		Me._txMove_3.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txMove_3.AcceptsReturn = True
		Me._txMove_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txMove_3.BackColor = System.Drawing.SystemColors.Window
		Me._txMove_3.CausesValidation = True
		Me._txMove_3.Enabled = True
		Me._txMove_3.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txMove_3.HideSelection = True
		Me._txMove_3.Maxlength = 0
		Me._txMove_3.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txMove_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txMove_3.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txMove_3.TabStop = True
		Me._txMove_3.Visible = True
		Me._txMove_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txMove_3.Name = "_txMove_3"
		Me._txMove_2.AutoSize = False
		Me._txMove_2.Size = New System.Drawing.Size(89, 105)
		Me._txMove_2.Location = New System.Drawing.Point(200, 64)
		Me._txMove_2.ReadOnly = True
		Me._txMove_2.MultiLine = True
		Me._txMove_2.TabIndex = 7
		Me._txMove_2.Text = "Text1"
		Me._txMove_2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txMove_2.AcceptsReturn = True
		Me._txMove_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txMove_2.BackColor = System.Drawing.SystemColors.Window
		Me._txMove_2.CausesValidation = True
		Me._txMove_2.Enabled = True
		Me._txMove_2.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txMove_2.HideSelection = True
		Me._txMove_2.Maxlength = 0
		Me._txMove_2.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txMove_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txMove_2.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txMove_2.TabStop = True
		Me._txMove_2.Visible = True
		Me._txMove_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txMove_2.Name = "_txMove_2"
		Me._txMove_1.AutoSize = False
		Me._txMove_1.Size = New System.Drawing.Size(89, 105)
		Me._txMove_1.Location = New System.Drawing.Point(104, 64)
		Me._txMove_1.ReadOnly = True
		Me._txMove_1.MultiLine = True
		Me._txMove_1.TabIndex = 6
		Me._txMove_1.Text = "Text1"
		Me._txMove_1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txMove_1.AcceptsReturn = True
		Me._txMove_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txMove_1.BackColor = System.Drawing.SystemColors.Window
		Me._txMove_1.CausesValidation = True
		Me._txMove_1.Enabled = True
		Me._txMove_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txMove_1.HideSelection = True
		Me._txMove_1.Maxlength = 0
		Me._txMove_1.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txMove_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txMove_1.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txMove_1.TabStop = True
		Me._txMove_1.Visible = True
		Me._txMove_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txMove_1.Name = "_txMove_1"
		Me._txMove_0.AutoSize = False
		Me._txMove_0.Size = New System.Drawing.Size(89, 105)
		Me._txMove_0.Location = New System.Drawing.Point(8, 64)
		Me._txMove_0.ReadOnly = True
		Me._txMove_0.MultiLine = True
		Me._txMove_0.TabIndex = 5
		Me._txMove_0.Text = "Text1"
		Me._txMove_0.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txMove_0.AcceptsReturn = True
		Me._txMove_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txMove_0.BackColor = System.Drawing.SystemColors.Window
		Me._txMove_0.CausesValidation = True
		Me._txMove_0.Enabled = True
		Me._txMove_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txMove_0.HideSelection = True
		Me._txMove_0.Maxlength = 0
		Me._txMove_0.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txMove_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txMove_0.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txMove_0.TabStop = True
		Me._txMove_0.Visible = True
		Me._txMove_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txMove_0.Name = "_txMove_0"
		Me._cmdMove_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._cmdMove_4.Text = "Command1"
		Me._cmdMove_4.Size = New System.Drawing.Size(89, 33)
		Me._cmdMove_4.Location = New System.Drawing.Point(392, 16)
		Me._cmdMove_4.TabIndex = 4
		Me._cmdMove_4.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._cmdMove_4.BackColor = System.Drawing.SystemColors.Control
		Me._cmdMove_4.CausesValidation = True
		Me._cmdMove_4.Enabled = True
		Me._cmdMove_4.ForeColor = System.Drawing.SystemColors.ControlText
		Me._cmdMove_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._cmdMove_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._cmdMove_4.TabStop = True
		Me._cmdMove_4.Name = "_cmdMove_4"
		Me._cmdMove_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._cmdMove_2.Text = "Command1"
		Me._cmdMove_2.Size = New System.Drawing.Size(89, 33)
		Me._cmdMove_2.Location = New System.Drawing.Point(200, 16)
		Me._cmdMove_2.TabIndex = 3
		Me._cmdMove_2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._cmdMove_2.BackColor = System.Drawing.SystemColors.Control
		Me._cmdMove_2.CausesValidation = True
		Me._cmdMove_2.Enabled = True
		Me._cmdMove_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._cmdMove_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._cmdMove_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._cmdMove_2.TabStop = True
		Me._cmdMove_2.Name = "_cmdMove_2"
		Me._cmdMove_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._cmdMove_1.Text = "Command1"
		Me._cmdMove_1.Size = New System.Drawing.Size(89, 33)
		Me._cmdMove_1.Location = New System.Drawing.Point(104, 16)
		Me._cmdMove_1.TabIndex = 2
		Me._cmdMove_1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._cmdMove_1.BackColor = System.Drawing.SystemColors.Control
		Me._cmdMove_1.CausesValidation = True
		Me._cmdMove_1.Enabled = True
		Me._cmdMove_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._cmdMove_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._cmdMove_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._cmdMove_1.TabStop = True
		Me._cmdMove_1.Name = "_cmdMove_1"
		Me._cmdMove_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._cmdMove_0.Text = "Command1"
		Me._cmdMove_0.Size = New System.Drawing.Size(89, 33)
		Me._cmdMove_0.Location = New System.Drawing.Point(8, 16)
		Me._cmdMove_0.TabIndex = 1
		Me._cmdMove_0.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._cmdMove_0.BackColor = System.Drawing.SystemColors.Control
		Me._cmdMove_0.CausesValidation = True
		Me._cmdMove_0.Enabled = True
		Me._cmdMove_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._cmdMove_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._cmdMove_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._cmdMove_0.TabStop = True
		Me._cmdMove_0.Name = "_cmdMove_0"
		Me._imgCit_4.Size = New System.Drawing.Size(17, 17)
		Me._imgCit_4.Location = New System.Drawing.Point(448, 48)
		Me._imgCit_4.Enabled = True
		Me._imgCit_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._imgCit_4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._imgCit_4.Visible = True
		Me._imgCit_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._imgCit_4.Name = "_imgCit_4"
		Me._imgCit_3.Size = New System.Drawing.Size(17, 17)
		Me._imgCit_3.Location = New System.Drawing.Point(352, 48)
		Me._imgCit_3.Enabled = True
		Me._imgCit_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._imgCit_3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._imgCit_3.Visible = True
		Me._imgCit_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._imgCit_3.Name = "_imgCit_3"
		Me._imgCit_2.Size = New System.Drawing.Size(17, 17)
		Me._imgCit_2.Location = New System.Drawing.Point(256, 48)
		Me._imgCit_2.Enabled = True
		Me._imgCit_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._imgCit_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._imgCit_2.Visible = True
		Me._imgCit_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._imgCit_2.Name = "_imgCit_2"
		Me._imgCit_1.Size = New System.Drawing.Size(17, 17)
		Me._imgCit_1.Location = New System.Drawing.Point(160, 48)
		Me._imgCit_1.Enabled = True
		Me._imgCit_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._imgCit_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._imgCit_1.Visible = True
		Me._imgCit_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._imgCit_1.Name = "_imgCit_1"
		Me._imgCit_0.Size = New System.Drawing.Size(17, 17)
		Me._imgCit_0.Location = New System.Drawing.Point(64, 48)
		Me._imgCit_0.Enabled = True
		Me._imgCit_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._imgCit_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._imgCit_0.Visible = True
		Me._imgCit_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._imgCit_0.Name = "_imgCit_0"
		Me._imgTer_4.Size = New System.Drawing.Size(17, 17)
		Me._imgTer_4.Location = New System.Drawing.Point(464, 48)
		Me._imgTer_4.Enabled = True
		Me._imgTer_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._imgTer_4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._imgTer_4.Visible = True
		Me._imgTer_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._imgTer_4.Name = "_imgTer_4"
		Me._imgTer_3.Size = New System.Drawing.Size(17, 17)
		Me._imgTer_3.Location = New System.Drawing.Point(368, 48)
		Me._imgTer_3.Enabled = True
		Me._imgTer_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._imgTer_3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._imgTer_3.Visible = True
		Me._imgTer_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._imgTer_3.Name = "_imgTer_3"
		Me._imgTer_2.Size = New System.Drawing.Size(17, 17)
		Me._imgTer_2.Location = New System.Drawing.Point(272, 48)
		Me._imgTer_2.Enabled = True
		Me._imgTer_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._imgTer_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._imgTer_2.Visible = True
		Me._imgTer_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._imgTer_2.Name = "_imgTer_2"
		Me._imgTer_1.Size = New System.Drawing.Size(17, 17)
		Me._imgTer_1.Location = New System.Drawing.Point(176, 48)
		Me._imgTer_1.Enabled = True
		Me._imgTer_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._imgTer_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._imgTer_1.Visible = True
		Me._imgTer_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._imgTer_1.Name = "_imgTer_1"
		Me._imgTer_0.Size = New System.Drawing.Size(17, 17)
		Me._imgTer_0.Location = New System.Drawing.Point(80, 48)
		Me._imgTer_0.Enabled = True
		Me._imgTer_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._imgTer_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._imgTer_0.Visible = True
		Me._imgTer_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._imgTer_0.Name = "_imgTer_0"
		Me._imgMoveRoad_4.Size = New System.Drawing.Size(17, 17)
		Me._imgMoveRoad_4.Location = New System.Drawing.Point(408, 48)
		Me._imgMoveRoad_4.Image = CType(resources.GetObject("_imgMoveRoad_4.Image"), System.Drawing.Image)
		Me._imgMoveRoad_4.Enabled = True
		Me._imgMoveRoad_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._imgMoveRoad_4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._imgMoveRoad_4.Visible = True
		Me._imgMoveRoad_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._imgMoveRoad_4.Name = "_imgMoveRoad_4"
		Me._imgMoveRoad_3.Size = New System.Drawing.Size(17, 17)
		Me._imgMoveRoad_3.Location = New System.Drawing.Point(312, 48)
		Me._imgMoveRoad_3.Image = CType(resources.GetObject("_imgMoveRoad_3.Image"), System.Drawing.Image)
		Me._imgMoveRoad_3.Enabled = True
		Me._imgMoveRoad_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._imgMoveRoad_3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._imgMoveRoad_3.Visible = True
		Me._imgMoveRoad_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._imgMoveRoad_3.Name = "_imgMoveRoad_3"
		Me._imgMoveRoad_2.Size = New System.Drawing.Size(17, 17)
		Me._imgMoveRoad_2.Location = New System.Drawing.Point(216, 48)
		Me._imgMoveRoad_2.Image = CType(resources.GetObject("_imgMoveRoad_2.Image"), System.Drawing.Image)
		Me._imgMoveRoad_2.Enabled = True
		Me._imgMoveRoad_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._imgMoveRoad_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._imgMoveRoad_2.Visible = True
		Me._imgMoveRoad_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._imgMoveRoad_2.Name = "_imgMoveRoad_2"
		Me._imgMoveRoad_1.Size = New System.Drawing.Size(17, 17)
		Me._imgMoveRoad_1.Location = New System.Drawing.Point(120, 48)
		Me._imgMoveRoad_1.Image = CType(resources.GetObject("_imgMoveRoad_1.Image"), System.Drawing.Image)
		Me._imgMoveRoad_1.Enabled = True
		Me._imgMoveRoad_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._imgMoveRoad_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._imgMoveRoad_1.Visible = True
		Me._imgMoveRoad_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._imgMoveRoad_1.Name = "_imgMoveRoad_1"
		Me._imgMoveRoad_0.Size = New System.Drawing.Size(17, 17)
		Me._imgMoveRoad_0.Location = New System.Drawing.Point(24, 48)
		Me._imgMoveRoad_0.Image = CType(resources.GetObject("_imgMoveRoad_0.Image"), System.Drawing.Image)
		Me._imgMoveRoad_0.Enabled = True
		Me._imgMoveRoad_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._imgMoveRoad_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._imgMoveRoad_0.Visible = True
		Me._imgMoveRoad_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._imgMoveRoad_0.Name = "_imgMoveRoad_0"
		Me._imgMoveExp_4.Size = New System.Drawing.Size(17, 17)
		Me._imgMoveExp_4.Location = New System.Drawing.Point(392, 48)
		Me._imgMoveExp_4.Image = CType(resources.GetObject("_imgMoveExp_4.Image"), System.Drawing.Image)
		Me._imgMoveExp_4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me._imgMoveExp_4.Enabled = True
		Me._imgMoveExp_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._imgMoveExp_4.Visible = True
		Me._imgMoveExp_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._imgMoveExp_4.Name = "_imgMoveExp_4"
		Me._imgMoveExp_3.Size = New System.Drawing.Size(17, 17)
		Me._imgMoveExp_3.Location = New System.Drawing.Point(296, 48)
		Me._imgMoveExp_3.Image = CType(resources.GetObject("_imgMoveExp_3.Image"), System.Drawing.Image)
		Me._imgMoveExp_3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me._imgMoveExp_3.Enabled = True
		Me._imgMoveExp_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._imgMoveExp_3.Visible = True
		Me._imgMoveExp_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._imgMoveExp_3.Name = "_imgMoveExp_3"
		Me._imgMoveExp_2.Size = New System.Drawing.Size(17, 17)
		Me._imgMoveExp_2.Location = New System.Drawing.Point(200, 48)
		Me._imgMoveExp_2.Image = CType(resources.GetObject("_imgMoveExp_2.Image"), System.Drawing.Image)
		Me._imgMoveExp_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me._imgMoveExp_2.Enabled = True
		Me._imgMoveExp_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._imgMoveExp_2.Visible = True
		Me._imgMoveExp_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._imgMoveExp_2.Name = "_imgMoveExp_2"
		Me._imgMoveExp_1.Size = New System.Drawing.Size(17, 17)
		Me._imgMoveExp_1.Location = New System.Drawing.Point(104, 48)
		Me._imgMoveExp_1.Image = CType(resources.GetObject("_imgMoveExp_1.Image"), System.Drawing.Image)
		Me._imgMoveExp_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me._imgMoveExp_1.Enabled = True
		Me._imgMoveExp_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._imgMoveExp_1.Visible = True
		Me._imgMoveExp_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._imgMoveExp_1.Name = "_imgMoveExp_1"
		Me._imgMoveExp_0.Size = New System.Drawing.Size(17, 17)
		Me._imgMoveExp_0.Location = New System.Drawing.Point(8, 48)
		Me._imgMoveExp_0.Image = CType(resources.GetObject("_imgMoveExp_0.Image"), System.Drawing.Image)
		Me._imgMoveExp_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me._imgMoveExp_0.Enabled = True
		Me._imgMoveExp_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._imgMoveExp_0.Visible = True
		Me._imgMoveExp_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._imgMoveExp_0.Name = "_imgMoveExp_0"
		Me.frDisk.Text = "Disk Options"
		Me.frDisk.Size = New System.Drawing.Size(489, 57)
		Me.frDisk.Location = New System.Drawing.Point(0, 416)
		Me.frDisk.TabIndex = 11
		Me.frDisk.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.frDisk.BackColor = System.Drawing.SystemColors.Control
		Me.frDisk.Enabled = True
		Me.frDisk.ForeColor = System.Drawing.SystemColors.ControlText
		Me.frDisk.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.frDisk.Visible = True
		Me.frDisk.Padding = New System.Windows.Forms.Padding(0)
		Me.frDisk.Name = "frDisk"
		Me.cmdMap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdMap.Text = "Flat Map"
		Me.cmdMap.Size = New System.Drawing.Size(81, 33)
		Me.cmdMap.Location = New System.Drawing.Point(184, 16)
		Me.cmdMap.TabIndex = 41
		Me.cmdMap.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdMap.BackColor = System.Drawing.SystemColors.Control
		Me.cmdMap.CausesValidation = True
		Me.cmdMap.Enabled = True
		Me.cmdMap.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdMap.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdMap.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdMap.TabStop = True
		Me.cmdMap.Name = "cmdMap"
		Me.cmdRad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRad.Text = "Radial &Map"
		Me.cmdRad.Size = New System.Drawing.Size(81, 33)
		Me.cmdRad.Location = New System.Drawing.Point(96, 16)
		Me.cmdRad.TabIndex = 36
		Me.cmdRad.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdRad.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRad.CausesValidation = True
		Me.cmdRad.Enabled = True
		Me.cmdRad.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRad.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRad.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRad.TabStop = True
		Me.cmdRad.Name = "cmdRad"
		Me.ckCombat.Text = "No Combat"
		Me.ckCombat.Size = New System.Drawing.Size(81, 33)
		Me.ckCombat.Location = New System.Drawing.Point(312, 16)
		Me.ckCombat.TabIndex = 35
		Me.ckCombat.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ckCombat.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.ckCombat.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.ckCombat.BackColor = System.Drawing.SystemColors.Control
		Me.ckCombat.CausesValidation = True
		Me.ckCombat.Enabled = True
		Me.ckCombat.ForeColor = System.Drawing.SystemColors.ControlText
		Me.ckCombat.Cursor = System.Windows.Forms.Cursors.Default
		Me.ckCombat.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ckCombat.Appearance = System.Windows.Forms.Appearance.Normal
		Me.ckCombat.TabStop = True
		Me.ckCombat.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.ckCombat.Visible = True
		Me.ckCombat.Name = "ckCombat"
		Me.cmdCheat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCheat.Text = "C&heat"
		Me.cmdCheat.Size = New System.Drawing.Size(81, 33)
		Me.cmdCheat.Location = New System.Drawing.Point(400, 16)
		Me.cmdCheat.TabIndex = 34
		Me.cmdCheat.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdCheat.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCheat.CausesValidation = True
		Me.cmdCheat.Enabled = True
		Me.cmdCheat.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCheat.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCheat.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCheat.TabStop = True
		Me.cmdCheat.Name = "cmdCheat"
		Me.cmdQuit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdQuit.Text = "&Quit"
		Me.cmdQuit.Size = New System.Drawing.Size(81, 33)
		Me.cmdQuit.Location = New System.Drawing.Point(8, 16)
		Me.cmdQuit.TabIndex = 19
		Me.cmdQuit.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdQuit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdQuit.CausesValidation = True
		Me.cmdQuit.Enabled = True
		Me.cmdQuit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdQuit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdQuit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdQuit.TabStop = True
		Me.cmdQuit.Name = "cmdQuit"
		Me.frControls.Text = "Controls"
		Me.frControls.Size = New System.Drawing.Size(105, 257)
		Me.frControls.Location = New System.Drawing.Point(496, 216)
		Me.frControls.TabIndex = 10
		Me.frControls.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.frControls.BackColor = System.Drawing.SystemColors.Control
		Me.frControls.Enabled = True
		Me.frControls.ForeColor = System.Drawing.SystemColors.ControlText
		Me.frControls.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.frControls.Visible = True
		Me.frControls.Padding = New System.Windows.Forms.Padding(0)
		Me.frControls.Name = "frControls"
		Me.cmdStats.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdStats.Text = "S&tats"
		Me.cmdStats.Size = New System.Drawing.Size(89, 33)
		Me.cmdStats.Location = New System.Drawing.Point(8, 216)
		Me.cmdStats.TabIndex = 38
		Me.cmdStats.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdStats.BackColor = System.Drawing.SystemColors.Control
		Me.cmdStats.CausesValidation = True
		Me.cmdStats.Enabled = True
		Me.cmdStats.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdStats.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdStats.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdStats.TabStop = True
		Me.cmdStats.Name = "cmdStats"
		Me.cmdMagic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdMagic.Text = "&Spells"
		Me.cmdMagic.Size = New System.Drawing.Size(89, 33)
		Me.cmdMagic.Location = New System.Drawing.Point(8, 96)
		Me.cmdMagic.TabIndex = 33
		Me.cmdMagic.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdMagic.BackColor = System.Drawing.SystemColors.Control
		Me.cmdMagic.CausesValidation = True
		Me.cmdMagic.Enabled = True
		Me.cmdMagic.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdMagic.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdMagic.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdMagic.TabStop = True
		Me.cmdMagic.Name = "cmdMagic"
		Me.cmdPlaces.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPlaces.Text = "&Places"
		Me.cmdPlaces.Size = New System.Drawing.Size(89, 33)
		Me.cmdPlaces.Location = New System.Drawing.Point(8, 136)
		Me.cmdPlaces.TabIndex = 20
		Me.cmdPlaces.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdPlaces.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPlaces.CausesValidation = True
		Me.cmdPlaces.Enabled = True
		Me.cmdPlaces.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPlaces.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPlaces.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPlaces.TabStop = True
		Me.cmdPlaces.Name = "cmdPlaces"
		Me.cmdRest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRest.Text = "&Rest"
		Me.cmdRest.Size = New System.Drawing.Size(89, 33)
		Me.cmdRest.Location = New System.Drawing.Point(8, 176)
		Me.cmdRest.TabIndex = 18
		Me.cmdRest.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdRest.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRest.CausesValidation = True
		Me.cmdRest.Enabled = True
		Me.cmdRest.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRest.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRest.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRest.TabStop = True
		Me.cmdRest.Name = "cmdRest"
		Me.cmdInven.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdInven.Text = "&Inventory"
		Me.cmdInven.Size = New System.Drawing.Size(89, 33)
		Me.cmdInven.Location = New System.Drawing.Point(8, 56)
		Me.cmdInven.TabIndex = 17
		Me.cmdInven.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdInven.BackColor = System.Drawing.SystemColors.Control
		Me.cmdInven.CausesValidation = True
		Me.cmdInven.Enabled = True
		Me.cmdInven.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdInven.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdInven.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdInven.TabStop = True
		Me.cmdInven.Name = "cmdInven"
		Me.cmdChar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdChar.Text = "&Character"
		Me.cmdChar.Size = New System.Drawing.Size(89, 33)
		Me.cmdChar.Location = New System.Drawing.Point(8, 16)
		Me.cmdChar.TabIndex = 12
		Me.cmdChar.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdChar.BackColor = System.Drawing.SystemColors.Control
		Me.cmdChar.CausesValidation = True
		Me.cmdChar.Enabled = True
		Me.cmdChar.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdChar.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdChar.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdChar.TabStop = True
		Me.cmdChar.Name = "cmdChar"
		Me.imgCitHH.Size = New System.Drawing.Size(17, 17)
		Me.imgCitHH.Location = New System.Drawing.Point(48, 0)
		Me.imgCitHH.Image = CType(resources.GetObject("imgCitHH.Image"), System.Drawing.Image)
		Me.imgCitHH.Enabled = True
		Me.imgCitHH.Cursor = System.Windows.Forms.Cursors.Default
		Me.imgCitHH.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.imgCitHH.Visible = True
		Me.imgCitHH.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.imgCitHH.Name = "imgCitHH"
		Me.imgCitSlums.Size = New System.Drawing.Size(17, 17)
		Me.imgCitSlums.Location = New System.Drawing.Point(0, 0)
		Me.imgCitSlums.Image = CType(resources.GetObject("imgCitSlums.Image"), System.Drawing.Image)
		Me.imgCitSlums.Visible = False
		Me.imgCitSlums.Enabled = True
		Me.imgCitSlums.Cursor = System.Windows.Forms.Cursors.Default
		Me.imgCitSlums.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.imgCitSlums.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.imgCitSlums.Name = "imgCitSlums"
		Me.imgCitCross.Size = New System.Drawing.Size(17, 17)
		Me.imgCitCross.Location = New System.Drawing.Point(16, 0)
		Me.imgCitCross.Image = CType(resources.GetObject("imgCitCross.Image"), System.Drawing.Image)
		Me.imgCitCross.Visible = False
		Me.imgCitCross.Enabled = True
		Me.imgCitCross.Cursor = System.Windows.Forms.Cursors.Default
		Me.imgCitCross.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.imgCitCross.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.imgCitCross.Name = "imgCitCross"
		Me.imgCitCity.Size = New System.Drawing.Size(17, 17)
		Me.imgCitCity.Location = New System.Drawing.Point(32, 0)
		Me.imgCitCity.Image = CType(resources.GetObject("imgCitCity.Image"), System.Drawing.Image)
		Me.imgCitCity.Visible = False
		Me.imgCitCity.Enabled = True
		Me.imgCitCity.Cursor = System.Windows.Forms.Cursors.Default
		Me.imgCitCity.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.imgCitCity.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.imgCitCity.Name = "imgCitCity"
		Me._imgTerrain_6.Size = New System.Drawing.Size(17, 17)
		Me._imgTerrain_6.Location = New System.Drawing.Point(272, 0)
		Me._imgTerrain_6.Image = CType(resources.GetObject("_imgTerrain_6.Image"), System.Drawing.Image)
		Me._imgTerrain_6.Visible = False
		Me._imgTerrain_6.Enabled = True
		Me._imgTerrain_6.Cursor = System.Windows.Forms.Cursors.Default
		Me._imgTerrain_6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._imgTerrain_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._imgTerrain_6.Name = "_imgTerrain_6"
		Me._imgTerrain_5.Size = New System.Drawing.Size(17, 17)
		Me._imgTerrain_5.Location = New System.Drawing.Point(256, 0)
		Me._imgTerrain_5.Image = CType(resources.GetObject("_imgTerrain_5.Image"), System.Drawing.Image)
		Me._imgTerrain_5.Visible = False
		Me._imgTerrain_5.Enabled = True
		Me._imgTerrain_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._imgTerrain_5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._imgTerrain_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._imgTerrain_5.Name = "_imgTerrain_5"
		Me._imgTerrain_7.Size = New System.Drawing.Size(17, 17)
		Me._imgTerrain_7.Location = New System.Drawing.Point(288, 0)
		Me._imgTerrain_7.Image = CType(resources.GetObject("_imgTerrain_7.Image"), System.Drawing.Image)
		Me._imgTerrain_7.Visible = False
		Me._imgTerrain_7.Enabled = True
		Me._imgTerrain_7.Cursor = System.Windows.Forms.Cursors.Default
		Me._imgTerrain_7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._imgTerrain_7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._imgTerrain_7.Name = "_imgTerrain_7"
		Me._imgTerrain_3.Size = New System.Drawing.Size(17, 17)
		Me._imgTerrain_3.Location = New System.Drawing.Point(224, 0)
		Me._imgTerrain_3.Image = CType(resources.GetObject("_imgTerrain_3.Image"), System.Drawing.Image)
		Me._imgTerrain_3.Visible = False
		Me._imgTerrain_3.Enabled = True
		Me._imgTerrain_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._imgTerrain_3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._imgTerrain_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._imgTerrain_3.Name = "_imgTerrain_3"
		Me._imgTerrain_2.Size = New System.Drawing.Size(17, 17)
		Me._imgTerrain_2.Location = New System.Drawing.Point(208, 0)
		Me._imgTerrain_2.Image = CType(resources.GetObject("_imgTerrain_2.Image"), System.Drawing.Image)
		Me._imgTerrain_2.Visible = False
		Me._imgTerrain_2.Enabled = True
		Me._imgTerrain_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._imgTerrain_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._imgTerrain_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._imgTerrain_2.Name = "_imgTerrain_2"
		Me._imgTerrain_1.Size = New System.Drawing.Size(17, 17)
		Me._imgTerrain_1.Location = New System.Drawing.Point(192, 0)
		Me._imgTerrain_1.Image = CType(resources.GetObject("_imgTerrain_1.Image"), System.Drawing.Image)
		Me._imgTerrain_1.Visible = False
		Me._imgTerrain_1.Enabled = True
		Me._imgTerrain_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._imgTerrain_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._imgTerrain_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._imgTerrain_1.Name = "_imgTerrain_1"
		Me._imgTerrain_4.Size = New System.Drawing.Size(17, 17)
		Me._imgTerrain_4.Location = New System.Drawing.Point(240, 0)
		Me._imgTerrain_4.Image = CType(resources.GetObject("_imgTerrain_4.Image"), System.Drawing.Image)
		Me._imgTerrain_4.Visible = False
		Me._imgTerrain_4.Enabled = True
		Me._imgTerrain_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._imgTerrain_4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._imgTerrain_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._imgTerrain_4.Name = "_imgTerrain_4"
		Me._imgTerrain_0.Size = New System.Drawing.Size(17, 17)
		Me._imgTerrain_0.Location = New System.Drawing.Point(176, 0)
		Me._imgTerrain_0.Image = CType(resources.GetObject("_imgTerrain_0.Image"), System.Drawing.Image)
		Me._imgTerrain_0.Visible = False
		Me._imgTerrain_0.Enabled = True
		Me._imgTerrain_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._imgTerrain_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._imgTerrain_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._imgTerrain_0.Name = "_imgTerrain_0"
		Me.Controls.Add(frLocation)
		Me.Controls.Add(frMove)
		Me.Controls.Add(frDisk)
		Me.Controls.Add(frControls)
		Me.Controls.Add(imgCitHH)
		Me.Controls.Add(imgCitSlums)
		Me.Controls.Add(imgCitCross)
		Me.Controls.Add(imgCitCity)
		Me.Controls.Add(_imgTerrain_6)
		Me.Controls.Add(_imgTerrain_5)
		Me.Controls.Add(_imgTerrain_7)
		Me.Controls.Add(_imgTerrain_3)
		Me.Controls.Add(_imgTerrain_2)
		Me.Controls.Add(_imgTerrain_1)
		Me.Controls.Add(_imgTerrain_4)
		Me.Controls.Add(_imgTerrain_0)
		Me.frLocation.Controls.Add(txPoints)
		Me.frLocation.Controls.Add(lstPeople)
		Me.frLocation.Controls.Add(cmdCity)
		Me.frLocation.Controls.Add(txLoc)
		Me.frLocation.Controls.Add(txGameDate)
		Me.frLocation.Controls.Add(txHP)
		Me.frLocation.Controls.Add(txGold)
		Me.frLocation.Controls.Add(lstEvents)
		Me.frLocation.Controls.Add(txCur)
		Me.frLocation.Controls.Add(Label1)
		Me.frLocation.Controls.Add(lblLoc)
		Me.frLocation.Controls.Add(lblDate)
		Me.frLocation.Controls.Add(lblHP)
		Me.frLocation.Controls.Add(lblGold)
		Me.frLocation.Controls.Add(_imgTer_5)
		Me.frLocation.Controls.Add(_imgCit_5)
		Me.frLocation.Controls.Add(_imgMoveRoad_5)
		Me.frMove.Controls.Add(_cmdMove_3)
		Me.frMove.Controls.Add(txShowRoute)
		Me.frMove.Controls.Add(txRoute)
		Me.frMove.Controls.Add(cmdRoute)
		Me.frMove.Controls.Add(_txMove_4)
		Me.frMove.Controls.Add(_txMove_3)
		Me.frMove.Controls.Add(_txMove_2)
		Me.frMove.Controls.Add(_txMove_1)
		Me.frMove.Controls.Add(_txMove_0)
		Me.frMove.Controls.Add(_cmdMove_4)
		Me.frMove.Controls.Add(_cmdMove_2)
		Me.frMove.Controls.Add(_cmdMove_1)
		Me.frMove.Controls.Add(_cmdMove_0)
		Me.frMove.Controls.Add(_imgCit_4)
		Me.frMove.Controls.Add(_imgCit_3)
		Me.frMove.Controls.Add(_imgCit_2)
		Me.frMove.Controls.Add(_imgCit_1)
		Me.frMove.Controls.Add(_imgCit_0)
		Me.frMove.Controls.Add(_imgTer_4)
		Me.frMove.Controls.Add(_imgTer_3)
		Me.frMove.Controls.Add(_imgTer_2)
		Me.frMove.Controls.Add(_imgTer_1)
		Me.frMove.Controls.Add(_imgTer_0)
		Me.frMove.Controls.Add(_imgMoveRoad_4)
		Me.frMove.Controls.Add(_imgMoveRoad_3)
		Me.frMove.Controls.Add(_imgMoveRoad_2)
		Me.frMove.Controls.Add(_imgMoveRoad_1)
		Me.frMove.Controls.Add(_imgMoveRoad_0)
		Me.frMove.Controls.Add(_imgMoveExp_4)
		Me.frMove.Controls.Add(_imgMoveExp_3)
		Me.frMove.Controls.Add(_imgMoveExp_2)
		Me.frMove.Controls.Add(_imgMoveExp_1)
		Me.frMove.Controls.Add(_imgMoveExp_0)
		Me.frDisk.Controls.Add(cmdMap)
		Me.frDisk.Controls.Add(cmdRad)
		Me.frDisk.Controls.Add(ckCombat)
		Me.frDisk.Controls.Add(cmdCheat)
		Me.frDisk.Controls.Add(cmdQuit)
		Me.frControls.Controls.Add(cmdStats)
		Me.frControls.Controls.Add(cmdMagic)
		Me.frControls.Controls.Add(cmdPlaces)
		Me.frControls.Controls.Add(cmdRest)
		Me.frControls.Controls.Add(cmdInven)
		Me.frControls.Controls.Add(cmdChar)
		Me.cmdMove.SetIndex(_cmdMove_3, CType(3, Short))
		Me.cmdMove.SetIndex(_cmdMove_4, CType(4, Short))
		Me.cmdMove.SetIndex(_cmdMove_2, CType(2, Short))
		Me.cmdMove.SetIndex(_cmdMove_1, CType(1, Short))
		Me.cmdMove.SetIndex(_cmdMove_0, CType(0, Short))
		Me.imgCit.SetIndex(_imgCit_5, CType(5, Short))
		Me.imgCit.SetIndex(_imgCit_4, CType(4, Short))
		Me.imgCit.SetIndex(_imgCit_3, CType(3, Short))
		Me.imgCit.SetIndex(_imgCit_2, CType(2, Short))
		Me.imgCit.SetIndex(_imgCit_1, CType(1, Short))
		Me.imgCit.SetIndex(_imgCit_0, CType(0, Short))
		Me.imgMoveExp.SetIndex(_imgMoveExp_4, CType(4, Short))
		Me.imgMoveExp.SetIndex(_imgMoveExp_3, CType(3, Short))
		Me.imgMoveExp.SetIndex(_imgMoveExp_2, CType(2, Short))
		Me.imgMoveExp.SetIndex(_imgMoveExp_1, CType(1, Short))
		Me.imgMoveExp.SetIndex(_imgMoveExp_0, CType(0, Short))
		Me.imgMoveRoad.SetIndex(_imgMoveRoad_5, CType(5, Short))
		Me.imgMoveRoad.SetIndex(_imgMoveRoad_4, CType(4, Short))
		Me.imgMoveRoad.SetIndex(_imgMoveRoad_3, CType(3, Short))
		Me.imgMoveRoad.SetIndex(_imgMoveRoad_2, CType(2, Short))
		Me.imgMoveRoad.SetIndex(_imgMoveRoad_1, CType(1, Short))
		Me.imgMoveRoad.SetIndex(_imgMoveRoad_0, CType(0, Short))
		Me.imgTer.SetIndex(_imgTer_5, CType(5, Short))
		Me.imgTer.SetIndex(_imgTer_4, CType(4, Short))
		Me.imgTer.SetIndex(_imgTer_3, CType(3, Short))
		Me.imgTer.SetIndex(_imgTer_2, CType(2, Short))
		Me.imgTer.SetIndex(_imgTer_1, CType(1, Short))
		Me.imgTer.SetIndex(_imgTer_0, CType(0, Short))
		Me.imgTerrain.SetIndex(_imgTerrain_6, CType(6, Short))
		Me.imgTerrain.SetIndex(_imgTerrain_5, CType(5, Short))
		Me.imgTerrain.SetIndex(_imgTerrain_7, CType(7, Short))
		Me.imgTerrain.SetIndex(_imgTerrain_3, CType(3, Short))
		Me.imgTerrain.SetIndex(_imgTerrain_2, CType(2, Short))
		Me.imgTerrain.SetIndex(_imgTerrain_1, CType(1, Short))
		Me.imgTerrain.SetIndex(_imgTerrain_4, CType(4, Short))
		Me.imgTerrain.SetIndex(_imgTerrain_0, CType(0, Short))
		Me.txMove.SetIndex(_txMove_4, CType(4, Short))
		Me.txMove.SetIndex(_txMove_3, CType(3, Short))
		Me.txMove.SetIndex(_txMove_2, CType(2, Short))
		Me.txMove.SetIndex(_txMove_1, CType(1, Short))
		Me.txMove.SetIndex(_txMove_0, CType(0, Short))
		CType(Me.txMove, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.imgTerrain, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.imgTer, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.imgMoveRoad, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.imgMoveExp, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.imgCit, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.cmdMove, System.ComponentModel.ISupportInitialize).EndInit()
		Me.frLocation.ResumeLayout(False)
		Me.frMove.ResumeLayout(False)
		Me.frDisk.ResumeLayout(False)
		Me.frControls.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class