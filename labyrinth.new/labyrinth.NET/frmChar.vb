Option Strict Off
Option Explicit On
Friend Class frmChar
	Inherits System.Windows.Forms.Form
	Private Sub cmdCharDone_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCharDone.Click
		RefreshGame()
		Me.Close()
	End Sub
	
	
	Private Sub cmdDown_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDown.Click
		Dim i As Short = cmdDown.GetIndex(eventSender)
		Dim cost As Short
		cost = AtrCost(Player.Stats(i), 0)
		
		If Player.Stats(i) - 1 >= char_Renamed.Locked(i) Then
			Player.Points = Player.Points + cost
			Player.Stats(i) = Player.Stats(i) - 1
		End If
		
		Call RefreshChar()
	End Sub
	
	Private Sub cmdReset_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdReset.Click
		Dim i As Short
		
		For i = 0 To 6
			char_Renamed.Player.Stats(i) = char_Renamed.Locked(i)
		Next i
		char_Renamed.Player.Points = char_Renamed.LockedPoints
		
		Call RefreshChar()
	End Sub
	
	Private Sub cmdUp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUp.Click
		Dim i As Short = cmdUp.GetIndex(eventSender)
		Dim cost As Short
		cost = AtrCost(Player.Stats(i) + 1)
		
		If Player.Points >= cost Then
			Player.Points = Player.Points - cost
			Player.Stats(i) = Player.Stats(i) + 1
		End If
		
		Call RefreshChar()
		
	End Sub
	
	
	Private Sub tmrCount_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrCount.Tick
		'UPGRADE_ISSUE: Timer property tmrCount.Tag was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If CDbl(tmrCount.Tag) > 9 Then
			'UPGRADE_ISSUE: Timer property tmrCount.Tag was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			cmdUp_Click(cmdUp.Item(CDbl(tmrCount.Tag) - 10), New System.EventArgs())
		Else
			'UPGRADE_ISSUE: Timer property tmrCount.Tag was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			cmdDown_Click(cmdDown.Item(CShort(tmrCount.Tag)), New System.EventArgs())
		End If
		'UPGRADE_WARNING: Couldn't resolve default property of object Max(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Timer property tmrCount.Interval cannot have a value of 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="169ECF4A-1968-402D-B243-16603CC08604"'
		If tmrCount.Interval > 1 Then tmrCount.Interval = Max(tmrCount.Interval - 25, 1)
	End Sub
	Private Sub cmdUp_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles cmdUp.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim x As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim index As Short = cmdUp.GetIndex(eventSender)
		'UPGRADE_ISSUE: Timer property tmrCount.Tag was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		tmrCount.Tag = index + 10
		tmrCount.Enabled = True
	End Sub
	
	Private Sub cmdUp_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles cmdUp.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim x As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim index As Short = cmdUp.GetIndex(eventSender)
		tmrCount.Enabled = False
		tmrCount.Interval = 200
	End Sub
	
	Private Sub cmdDown_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles cmdDown.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim x As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim index As Short = cmdDown.GetIndex(eventSender)
		'UPGRADE_ISSUE: Timer property tmrCount.Tag was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		tmrCount.Tag = index
		tmrCount.Enabled = True
	End Sub
	
	Private Sub cmdDown_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles cmdDown.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim x As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim index As Short = cmdDown.GetIndex(eventSender)
		tmrCount.Enabled = False
		tmrCount.Interval = 200
	End Sub
	
	Public Sub RefreshChar()
		Dim i As Short
		Player.CalcDervs()
		For i = 0 To 6
			txStats(i).Text = Player.Stats(i) & " (" & Player.Reals(i) & ")"
		Next i
		For i = 0 To 9
			txDervs(i).Text = CStr(Player.Dervs(i))
		Next i
		For i = 0 To 5
			lblCost(i).Text = CStr(AtrCost(Player.Stats(i) + 1))
		Next i
		txPoints.Text = CStr(Player.Points)
		
	End Sub
	
	
	Private Sub frmChar_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim i As Short
		Call RefreshChar()
		txPoints.Text = CStr(Player.Points)
		
		For i = 0 To 6
			char_Renamed.Locked(i) = Player.Stats(i)
		Next i
		char_Renamed.LockedPoints = Player.Points
		tmrCount.Enabled = False
		tmrCount.Interval = 200
	End Sub
	
	
	Private Sub frmChar_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim keyascii As Short = Asc(eventArgs.KeyChar)
		If keyascii = 27 Then
			Call cmdCharDone_Click(cmdCharDone, New System.EventArgs())
		End If
		eventArgs.KeyChar = Chr(keyascii)
		If keyascii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
End Class