Option Strict Off
Option Explicit On
Friend Class frmPerson
	Inherits System.Windows.Forms.Form
	Public Per As Person
	
	Public Sub RefreshPerson(ByRef p As Short)
		Per = People(p)
		
		Me.Text = Per.Name
		Me.txInfo.Text = Per.Desc
	End Sub
	
	
	Private Sub cmdBeg_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBeg.Click
		Dim gift As Short
		
		'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If Player.Reals(S_CHA) < (World_Renamed.World(Per.Loc_Renamed).Depth - 1) * 10 Or (Player.Reals(S_REP) < 2) Then
			Call MsgBox(Per.Name & " glares at you distainfully." & vbCrLf & "You lose a point of reputation.",  , "Beg")
			'UPGRADE_WARNING: Couldn't resolve default property of object Max(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Player.Stats(S_REP) = Max(Player.Stats(S_REP) - 1, 0)
		Else
			'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			gift = PM(Player.Reals(S_CHA) * (I_MANT ^ World_Renamed.World(Per.Loc_Renamed).Depth), 25)
			Call MsgBox(Per.Name & " takes pity on you and gifts you with " & gift & " gold pieces." & vbCrLf & "You lose two points of reputation.",  , "Beg")
			'UPGRADE_WARNING: Couldn't resolve default property of object Max(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Player.Stats(S_REP) = Max(Player.Stats(S_REP) - 2, 0)
		End If
	End Sub
	
	Private Sub cmdHelp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdHelp.Click
		Dim i As Short
		Dim r As Short
		Dim s As String
		Dim level As Short
		Dim ans As MsgBoxResult
		Dim it As Item
		If Per.T = "Taxidermist" Then
			For i = 0 To 99
				r = Int(Rnd() * C_INVMAX)
				If Not Player.Inven(r) Is Nothing Then
					If InStr(1, Player.Inven(r).Text, "Doll") Then
						s = Per.Name & " offers you an item of rare and wondrous power in exchange for your " & vbCrLf & JustText((Player.Inven(r).Text)) & vbCrLf & vbCrLf & "Do you accept?"
						Player.Inven(r).ID = True
						Exit For
					End If
				End If
			Next i
			
			If i = 100 Then
				MsgBox(Per.Name & " has nothing to say to you.",  , "Converse")
				Exit Sub
			End If
		Else
			MsgBox(Per.Name & " has nothing to say to you.",  , "Converse")
			Exit Sub
		End If
		
		ans = MsgBox(s, MsgBoxStyle.YesNo, "Converse")
		
		If ans = MsgBoxResult.Yes Then
			it = Player.Inven(r)
			level = it.Depth
			Call Player.RemInven(it)
			
			it = New Item
			r = Int(Rnd() * 100)
			Select Case r
				Case 0 To 49
					Call it.Create(Int(Rnd() * 4), level + 2 + Int(Rnd() * 3), level + 2, 100)
				Case 50 To 99
					Call it.CreateArtifact(Int(Rnd() * 6), level)
			End Select
			
			it.ID = True
			Call Player.AddInven(it)
			MsgBox("You receive in exchange:" & vbCrLf & JustText((it.Text)),  , "Receive Item")
		Else
		End If
		
	End Sub
	
	Private Sub cmdItems_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdItems.Click
		Dim cost As Integer
		Dim ans As MsgBoxResult
		
		If Per.LastExplored <> GameDate Or Per.it Is Nothing Then
			Per.it = New Item
			'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Call Per.it.Create(Int(Rnd() * 4), World_Renamed.World(Per.Loc_Renamed).Depth + Per.Quality)
			Per.it.Value = Int(Per.it.Value * Per.Greed / 100)
			Per.it.ID = True
		End If
		cost = Price((Per.it.Value), 1)
		
		ans = MsgBox(Per.Name & " offers you a " & vbCrLf & JustText(ItemText((Per.it))) & vbCrLf & "for " & cost & " gold coins." & vbCrLf & "You have " & char_Renamed.Player.Gold & " gold coins, do you accept?", MsgBoxStyle.YesNo, "Purchase Item")
		
		If ans = MsgBoxResult.Yes Then
			If char_Renamed.Player.Gold >= cost Then
				char_Renamed.Player.Gold = char_Renamed.Player.Gold - cost
				
				Call char_Renamed.Player.AddInven((Per.it))
				'UPGRADE_NOTE: Object Per.it may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				Per.it = Nothing
			Else
				MsgBox(Per.Name & " laughs, seeing that you don't have the money.",  , "Purchase Item")
			End If
		Else
			
		End If
		
		Per.LastExplored = GameDate
		
	End Sub
	
	Private Sub cmdLeave_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdLeave.Click
		Per.LastExplored = GameDate
		
		frmGame.Visible = True
		RefreshGame()
		Me.Close()
	End Sub
	
	Private Sub cmdMonsters_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdMonsters.Click
		Dim dep As Short
		Dim monstername As String
		Dim Mo As Monster
		Dim cost As Integer
		Dim ans As MsgBoxResult
		
		'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		cost = Price((Per.Greed / 100) * 3 * (I_MANT ^ World_Renamed.World(Per.Loc_Renamed).Depth), 1)
		'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		dep = World_Renamed.World(Per.Loc_Renamed).Depth - World_Renamed.World(Per.Loc_Renamed).Road
		
		If dep < 0 Then
			Call MsgBox(Per.Name & " laughs heartily, and reminds you that there are no monsters on the roads this close to Centris.", MsgBoxStyle.OKOnly, "Ask About Monsters")
			Exit Sub
		End If
		
		'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		monstername = SelectMonster(World_Renamed.World(Per.Loc_Renamed).Terrain, dep, 1)
		
		ans = MsgBox(Per.Name & " offers you information about the " & monstername & " for " & cost & " gold coins." & vbCrLf & "You have " & char_Renamed.Player.Gold & " gold coins, do you accept?", MsgBoxStyle.YesNo, "Ask About Monsters")
		
		If ans = MsgBoxResult.Yes Then
			If char_Renamed.Player.Gold >= cost Then
				char_Renamed.Player.Gold = char_Renamed.Player.Gold - cost
				
				Mo = New Monster
				Call Mo.MakeMonster(monstername)
				Call DispMonster(Mo, 0)
				If char_Renamed.Player.KL((Mo.Terrain), (Mo.Depth)) < 50 Then
					char_Renamed.Player.KL((Mo.Terrain), (Mo.Depth)) = char_Renamed.Player.KL((Mo.Terrain), (Mo.Depth)) + 10
				End If
			Else
				MsgBox(Per.Name & " laughs, seeing that you don't have the money.",  , "Ask About Places")
			End If
		Else
			
		End If
	End Sub
	
	Private Sub cmdPlaces_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPlaces.Click
		Dim i As Short
		Dim d As Short
		Dim cost As Integer
		Dim ans As MsgBoxResult
		Dim kn As Short
		
		'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		cost = Price(Per.Greed * TG(World_Renamed.World(Per.Loc_Renamed).Depth) / 200, 1)
		kn = 0
		
		For i = 0 To C_LOCS - 1
			d = Int(Rnd() * C_LOCS)
			'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If Per.Known(d) = 1 And World_Renamed.World(d).Known = 0 And Not World_Renamed.World(d).LCity Is Nothing Then
				'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If World_Renamed.World(d).LCity.T <> "None" Then
					Exit For
				End If
			End If
			d = -1
			If Per.Known(i) = 1 Then kn = kn + 1
		Next i
		
		If d <> -1 Then
			'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ans = MsgBox(Per.Name & " offers you information about a " & World_Renamed.World(d).LCity.T & " for " & cost & " gold coins." & vbCrLf & "You have " & char_Renamed.Player.Gold & " gold coins, do you accept?", MsgBoxStyle.YesNo, "Ask About Places")
			
			If ans = MsgBoxResult.Yes Then
				If char_Renamed.Player.Gold >= cost Then
					char_Renamed.Player.Gold = char_Renamed.Player.Gold - cost
					
					'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					MsgBox(Per.Name & " tells you that there is a " & World_Renamed.World(d).LCity.T & vbCrLf & " located at " & d & ".",  , "Ask About Places")
					'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					World_Renamed.World(d).Known = 1
				Else
					MsgBox(Per.Name & " laughs, seeing that you don't have the money.",  , "Ask About Places")
				End If
			Else
				
			End If
		Else
			MsgBox(Per.Name & " has nothing interesting to tell you.",  , "Ask About Places")
		End If
	End Sub
	Private Sub frmPerson_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim keyascii As Short = Asc(eventArgs.KeyChar)
		If keyascii = 27 Then
			Call cmdLeave_Click(cmdLeave, New System.EventArgs())
		End If
		eventArgs.KeyChar = Chr(keyascii)
		If keyascii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
End Class