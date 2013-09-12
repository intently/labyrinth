Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmGame
	Inherits System.Windows.Forms.Form
	' textbox on frmgame for area description
	' spells: max wis/50, each spell as different charge needed, rate = int/day
	Public Quitting As Short
	Public Wide As Short
	
	Private Sub cmdChar_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdChar.Click
		'  Dim CF As New frmChar
		frmChar.Visible = True
		frmChar.RefreshChar()
	End Sub
	
	Private Sub cmdCheat_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCheat.Click
		Dim i As Short
		char_Renamed.Player.Points = 1000000000
		char_Renamed.Player.Gold = 1000000000
		For i = 0 To 6
			char_Renamed.Player.Stats(i) = char_Renamed.Player.Stats(i) + 100
		Next i
		char_Renamed.Player.CalcDervs()
		RefreshGame()
	End Sub
	
	Private Sub cmdCity_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCity.Click
		'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If World_Renamed.World(Loc_Renamed).LCity.T = "City" Then
			Player.LastTown = Loc_Renamed
		End If
		
		frmCity.Visible = True
		Me.Visible = False
		frmCity.RefreshCity()
	End Sub
	
	Private Sub cmdInven_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdInven.Click
		'  Dim CF As New frmInven
		frmInven.Visible = True
		frmInven.RefreshInven()
	End Sub
	
	Public Sub AddEvent(ByRef s As String)
		Static le As Date
		
		If le <> GameDate Then
			Call lstEvents.Items.Insert(lstEvents.Items.Count, CStr(GameDate))
			le = GameDate
		End If
		Call lstEvents.Items.Insert(lstEvents.Items.Count, " -" & s)
		While lstEvents.Items.Count > 200
			lstEvents.Items.RemoveAt((0))
		End While
		lstEvents.SelectedIndex = lstEvents.Items.Count - 1
	End Sub
	
	Private Sub cmdMap_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdMap.Click
		frmMap.Visible = True
		frmMap.Activate()
		frmMap.DrawMap()
	End Sub
	
	Private Sub cmdMove_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdMove.Click
		Dim index As Short = cmdMove.GetIndex(eventSender)
		Me.cmdRoute.Text = "Calc. Route"
		'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Call MoveTo(World_Renamed.World(Loc_Renamed).Link(index))
	End Sub
	
	Private Sub cmdPlaces_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPlaces.Click
		Call frmPlaces.RefreshPlaces()
		frmPlaces.Visible = True
		frmPlaces.Activate()
	End Sub
	Private Sub cmdMagic_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdMagic.Click
		Call frmMagic.RefreshSpells()
		frmMagic.Visible = True
		frmMagic.Activate()
	End Sub
	
	Private Sub cmdRad_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRad.Click
		frmRad.Visible = True
		frmRad.Activate()
		frmRad.DrawMap()
	End Sub
	
	Private Sub cmdRest_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRest.Click
		'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If Not World_Renamed.World(Loc_Renamed).LCity Is Nothing Then
			'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If World_Renamed.World(Loc_Renamed).LCity.T = "City" Then
				If events.GuardsStop() = 1 Then
					Exit Sub
				End If
			End If
		End If
		AddEvent(("Rested"))
		PassTime()
		Encounter()
	End Sub
	
	Private Sub cmdRoute_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRoute.Click
		Dim i As Short
		If cmdRoute.Text = "Calc. Route" And IsNumeric(txRoute.Text) And Val(txRoute.Text) <> Loc_Renamed Then
			txShowRoute.Text = CalcRoute((txRoute.Text), (Me.ckCombat.CheckState))
			If VB.Left(txShowRoute.Text, 8) <> "Bad Dest" Then
				cmdRoute.Text = "Move Route"
				For i = 0 To C_RMAX - 1
					curroute(i) = route(i)
				Next i
			End If
		ElseIf cmdRoute.Text = "Move Route" Then 
			Call MoveTo(NextRoute())
			If txShowRoute.Text = "" Then
				cmdRoute.Text = "Calc. Route"
				cmdRoute.Enabled = False
				txRoute.Text = ""
			End If
			RefreshGame()
		ElseIf Val(txRoute.Text) = Loc_Renamed Then 
			txShowRoute.Text = "Bad Dest"
			cmdRoute.Enabled = False
		End If
	End Sub
	
	Private Sub cmdStats_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdStats.Click
		Dim j As Short
		Dim info As String
		Dim roads As Short
		Dim exp As Short
		Dim cits(4) As Short
		Dim crosses As Short
		Dim slums As Short
		Dim temp As Location
		Dim links As Double
		Dim depths As Double
		Dim maxdepth As Short
		Dim tosame As Double
		Dim todif As Double
		Dim deps(999) As Double
		Dim depsto(999) As Double
		Dim depslinks(999) As Double
		Dim i As Short
		
		For i = 0 To C_LOCS - 1
			'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			temp = World_Renamed.World(i)
			'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If World_Renamed.World(i).Road = 1 Then roads = roads + 1
			'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If World_Renamed.World(i).Explored = 1 Then exp = exp + 1
			'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If Not World_Renamed.World(i).LCity Is Nothing Then
				'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If World_Renamed.World(i).LCity.T = "City" Then
					cits(temp.LCity.Size) = cits(temp.LCity.Size) + 1
					cits(4) = cits(4) + 1
				End If
				If temp.LCity.T = "Slums" Then slums = slums + 1
				'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If World_Renamed.World(i).LCity.T = "Crossroad" Then crosses = crosses + 1
			End If
			'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			depths = depths + World_Renamed.World(i).Depth
			'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			deps(World_Renamed.World(i).Depth) = deps(World_Renamed.World(i).Depth) + 1
			'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If World_Renamed.World(i).Depth > maxdepth Then maxdepth = World_Renamed.World(i).Depth
			For j = 0 To 4
				'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If World_Renamed.World(i).Link(j) <> -1 Then
					links = links + 1
					'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					depslinks(World_Renamed.World(i).Depth) = depslinks(World_Renamed.World(i).Depth) + 1
					'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If System.Math.Abs(World_Renamed.World(World_Renamed.World(i).Link(j)).Depth - World_Renamed.World(i).Depth) <= 0 Then
						'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						depsto(World_Renamed.World(i).Depth) = depsto(World_Renamed.World(i).Depth) + 1
					End If
					
					'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If World_Renamed.World(World_Renamed.World(i).Link(j)).Terrain = World_Renamed.World(i).Terrain Then
						tosame = tosame + 1
					Else
						todif = todif + 1
					End If
				End If
			Next j
		Next i
		
		tosame = tosame / links
		todif = todif / links
		links = links / C_LOCS
		depths = depths / C_LOCS
		
		info = ""
		
		info = info & "Avg. Links: " & links & vbCrLf
		info = info & "ToSame: " & System.Math.Round(tosame, 3) & " ToDif: " & System.Math.Round(todif, 3) & vbCrLf
		info = info & "Avg. Depth: " & depths & vbCrLf
		info = info & "Max Depth: " & maxdepth & vbCrLf
		info = info & "Explored: " & exp & "/" & C_LOCS & vbCrLf
		'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.TRegions. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		info = info & "Regions: " & World_Renamed.TRegions & vbCrLf
		'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.TRegions. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		info = info & "Avg Areas Per: " & System.Math.Round(C_LOCS / World_Renamed.TRegions, 3) & vbCrLf
		info = info & "Roads: " & roads & vbCrLf
		info = info & "Cities: (" & cits(4) & ") " & cits(0) & "/" & cits(1) & "/" & cits(2) & "/" & cits(3) & vbCrLf
		info = info & "Crossroads: " & crosses & vbCrLf
		info = info & "Slums: " & slums & vbCrLf
		
		For i = 0 To maxdepth
			info = info & i & ": " & deps(i) & " : " & depsto(i) & "/" & depslinks(i) & " : " & System.Math.Round(depsto(i) / depslinks(i), 3) & vbCrLf
		Next i
		
		MsgBox(info)
	End Sub
	
	Private Sub frmGame_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'UPGRADE_WARNING: TextBox property txRoute.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		txRoute.Maxlength = Len(Str(C_LOCS - 1)) - 1
		Wide = 8
		Quitting = 0
		Call MsgBox("Welcome to the Labyrinth!" & vbCrLf & "Don't forget to spend your character points before you begin adventuring!" & vbCrLf & "Then, purchase some equipment in Centris, equip it, and you're off!" & vbCrLf & vbCrLf & "The only way to escape this chaotic maze is to keep moving forward!",  , "Entering the Labyrinth")
	End Sub
	
	Private Sub cmdQuit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdQuit.Click
		Quitting = 1
		Call frmGame_FormClosed(Me, New System.Windows.Forms.FormClosedEventArgs(0, FormAction.Closed))
	End Sub
	Private Sub frmGame_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		Dim ans As MsgBoxResult
		
		If Quitting = 0 Then
			'UPGRADE_ISSUE: Event parameter Cancel was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FB723E3C-1C06-4D2B-B083-E6CD0D334DA8"'
			cancel = 1
			Exit Sub
		End If
		
		If Quitting = 1 Then
			ans = MsgBox("Are you sure you want to quit?", MsgBoxStyle.YesNoCancel, "Quit Confirmation")
			
			If ans = MsgBoxResult.No Then
				'UPGRADE_ISSUE: Event parameter Cancel was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FB723E3C-1C06-4D2B-B083-E6CD0D334DA8"'
				cancel = 1
				Quitting = 0
				Exit Sub
			ElseIf ans = MsgBoxResult.Cancel Then 
				'UPGRADE_ISSUE: Event parameter Cancel was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FB723E3C-1C06-4D2B-B083-E6CD0D334DA8"'
				cancel = 1
				Quitting = 0
				Exit Sub
			End If
		End If
		Quitting = 2
		Me.Close()
		frmChar.Close()
		frmInven.Close()
		frmPlaces.Close()
		frmStart.Close()
		frmCombat.Close()
		frmMagic.Close()
		frmCity.Close()
		frmStore.Close()
		frmMap.Close()
		frmRad.Close()
	End Sub
	
	Private Sub lstPeople_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstPeople.DoubleClick
		Dim p As Short
		
		If lstPeople.Text = "" Then Exit Sub
		
		p = VB6.GetItemData(lstPeople, lstPeople.SelectedIndex)
		
		frmPerson.Visible = True
		Me.Visible = False
		Call frmPerson.RefreshPerson(p)
		
	End Sub
	
	'UPGRADE_WARNING: Event txRoute.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txRoute_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txRoute.TextChanged
		If txRoute.Text = "" Then
			cmdRoute.Enabled = False
		Else
			cmdRoute.Enabled = True
		End If
		cmdRoute.Text = "Calc. Route"
	End Sub
	
	Private Sub txRoute_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txRoute.KeyPress
		Dim keyascii As Short = Asc(eventArgs.KeyChar)
		If keyascii = 13 Then
			cmdRoute_Click(cmdRoute, New System.EventArgs())
			keyascii = 0
		End If
		eventArgs.KeyChar = Chr(keyascii)
		If keyascii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub frmGame_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim keyascii As Short = Asc(eventArgs.KeyChar)
		Dim K As String
		K = Chr(keyascii)
		K = LCase(K)
		
		If K = "r" Then
			Call cmdRest_Click(cmdRest, New System.EventArgs())
		ElseIf K = "m" Then 
			Call cmdRad_Click(cmdRad, New System.EventArgs())
			'  ElseIf K = "1" Then
			'    Call cmdMove_Click(0)
			'  ElseIf K = "2" Then
			'    Call cmdMove_Click(1)
			'  ElseIf K = "3" Then
			'    Call cmdMove_Click(2)
			'  ElseIf K = "4" Then
			'    Call cmdMove_Click(3)
			'  ElseIf K = "5" Then
			'    Call cmdMove_Click(4)
		ElseIf K = "c" Then 
			Call cmdChar_Click(cmdChar, New System.EventArgs())
		ElseIf K = "i" Then 
			Call cmdInven_Click(cmdInven, New System.EventArgs())
		ElseIf K = "s" Then 
			Call cmdMagic_Click(cmdMagic, New System.EventArgs())
		ElseIf K = "t" Then 
			Call cmdStats_Click(cmdStats, New System.EventArgs())
		ElseIf K = "q" Then 
			Call cmdQuit_Click(cmdQuit, New System.EventArgs())
		ElseIf K = "e" Then 
			Call cmdCity_Click(cmdCity, New System.EventArgs())
		ElseIf K = "f" Then 
			Call cmdRoute_Click(cmdRoute, New System.EventArgs())
		End If
		
		If (keyascii < Asc("0") Or keyascii > Asc("9")) And keyascii <> 13 And keyascii <> 8 Then
			keyascii = 0
		End If
		
		eventArgs.KeyChar = Chr(keyascii)
		If keyascii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
End Class