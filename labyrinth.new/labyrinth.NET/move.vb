Option Strict Off
Option Explicit On
Module move
	Public route(C_RMAX - 1) As Short ' holds the sequence of locs to move through
	Public path(C_LOCS - 1) As Short ' holds the loc's parent in the shortest path
	Public old(C_LOCS - 1) As Short ' holds the depth of the location
	Public cur As Short
	Public curroute(C_RMAX - 1) As Short
	
	Public Sub RefreshGame()
		Dim dest As Short
		Dim exp As Short
		Dim roadp As Short
		Dim i As Short
		Dim frr As Object
		Dim bar As String
		
		For i = 0 To 4
			'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dest = World_Renamed.World(Loc_Renamed).Link(i)
			'UPGRADE_WARNING: Couldn't resolve default property of object frr. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			frr = ""
			bar = ""
			If dest <> -1 Then
				'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				World_Renamed.World(dest).Known = 1
				'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				exp = World_Renamed.World(dest).Explored
				
				'      lcityt = World.World(dest).LCity.T
				'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				frmGame.imgMoveRoad(i).Visible = World_Renamed.World(dest).Road
				'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				frmGame.imgMoveExp(i).Visible = Not (World_Renamed.World(dest).Explored <> 0)
				
				
				Call CityPic(dest, i)
				
				'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				frmGame.imgTer(i).Image = frmGame.imgTerrain(World_Renamed.World(dest).Terrain).Image
				frmGame.imgTer(i).Visible = True
				
				'      frmGame.cmdMove(i).Caption = "&" & i + 1 & ": " & frr & dest & bar
				'UPGRADE_WARNING: Couldn't resolve default property of object frr. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				frmGame.cmdMove(i).Text = frr & dest & bar
				
				frmGame.cmdMove(i).Enabled = True
				
				'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object RegionName(World_Renamed.World(dest).Region). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				frmGame.txMove(i).Text = RegionName(World_Renamed.World(dest).Region) & vbCrLf
				
				'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Not World_Renamed.World(dest).LCity Is Nothing Then
					'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If World_Renamed.World(dest).LCity.T = "City" Then
						'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						frmGame.txMove(i).Text = frmGame.txMove(i).Text & "Cit: " & World_Renamed.World(dest).LCity.Name & " (" & World_Renamed.World(dest).LCity.Size & ")" & vbCrLf
						'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ElseIf World_Renamed.World(dest).LCity.T = "Haunted House" Then 
						frmGame.txMove(i).Text = frmGame.txMove(i).Text & "Haunted House" & vbCrLf
					End If
				Else
					frmGame.txMove(i).Text = frmGame.txMove(i).Text & "None" & vbCrLf
				End If
				
				frmGame.txMove(i).Text = frmGame.txMove(i).Text & "Area: " & dest & vbCrLf
				'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				frmGame.txMove(i).Text = frmGame.txMove(i).Text & "Ter: " & TerName(World_Renamed.World(dest).Terrain) & vbCrLf
				'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				frmGame.txMove(i).Text = frmGame.txMove(i).Text & "Depth: " & World_Renamed.World(dest).Depth & vbCrLf
			Else
				frmGame.imgCit(i).Visible = False
				frmGame.imgTer(i).Visible = False
				frmGame.cmdMove(i).Enabled = False
				frmGame.imgMoveExp(i).Visible = False
				frmGame.imgMoveRoad(i).Visible = False
				frmGame.cmdMove(i).Text = "None"
				frmGame.txMove(i).Text = ""
			End If
		Next i
		
		frmGame.txCur.Text = ""
		'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object RegionName(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		frmGame.txCur.Text = frmGame.txCur.Text & RegionName(World_Renamed.World(Loc_Renamed).Region) & vbCrLf
		frmGame.txCur.Text = frmGame.txCur.Text & "Area: " & Loc_Renamed & vbCrLf
		'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		frmGame.txCur.Text = frmGame.txCur.Text & "Terrain: " & TerName(World_Renamed.World(Loc_Renamed).Terrain) & vbCrLf
		'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		frmGame.txCur.Text = frmGame.txCur.Text & "Depth: " & World_Renamed.World(Loc_Renamed).Depth & vbCrLf & vbCrLf
		
		frmGame.txLoc.Text = CStr(Loc_Renamed)
		
		'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If Not World_Renamed.World(Loc_Renamed).LCity Is Nothing Then
			'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If World_Renamed.World(Loc_Renamed).LCity.T = "City" Then
				frmGame.cmdCity.Enabled = True
				'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				frmGame.cmdCity.Text = World_Renamed.World(Loc_Renamed).LCity.Button
				'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				frmGame.txCur.Text = frmGame.txCur.Text & "The City of " & World_Renamed.World(Loc_Renamed).LCity.Name & "." & vbCrLf
				'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				frmGame.txCur.Text = frmGame.txCur.Text & World_Renamed.World(Loc_Renamed).LCity.Desc & vbCrLf
				'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ElseIf World_Renamed.World(Loc_Renamed).LCity.T <> "None" Then 
				frmGame.cmdCity.Enabled = True
				'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				frmGame.cmdCity.Text = World_Renamed.World(Loc_Renamed).LCity.Button
				'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				frmGame.txCur.Text = frmGame.txCur.Text & World_Renamed.World(Loc_Renamed).LCity.T & vbCrLf
				'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				frmGame.txCur.Text = frmGame.txCur.Text & World_Renamed.World(Loc_Renamed).LCity.Desc & vbCrLf
			End If
		Else
			frmGame.cmdCity.Enabled = False
			frmGame.cmdCity.Text = ""
			frmGame.txCur.Text = frmGame.txCur.Text & "There is nothing of much interest here."
		End If
		
		frmGame.txGameDate.Text = CStr(GameDate)
		frmGame.txHP.Text = char_Renamed.Player.Dervs(D_CHP) & "/" & char_Renamed.Player.Dervs(D_HTP)
		frmGame.txGold.Text = CStr(char_Renamed.Player.Gold)
		
		'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		World_Renamed.World(Loc_Renamed).Explored = 1
		'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		World_Renamed.World(Loc_Renamed).Known = 1
		'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If World_Renamed.World(Loc_Renamed).Road = 1 Then
			frmGame.imgMoveRoad(5).Visible = True
		Else
			frmGame.imgMoveRoad(5).Visible = False
		End If
		Call CityPic(Loc_Renamed, 5)
		
		'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		frmGame.imgTer(5).Image = frmGame.imgTerrain(World_Renamed.World(Loc_Renamed).Terrain).Image
		
		frmGame.lstPeople.Items.Clear()
		For i = 0 To C_PEOPLE - 1
			If People(i).Loc_Renamed = Loc_Renamed Then
				frmGame.lstPeople.Items.Add(New VB6.ListBoxItem((People(i).Name), i))
			End If
		Next i
		
		frmGame.txPoints.Text = CStr(char_Renamed.Player.Points)
		
		If frmPlaces.Visible = True Then
			Call frmPlaces.RefreshPlaces()
		End If
		
	End Sub
	
	Public Sub CityPic(ByRef i As Short, ByRef pic As Object)
		Dim LCity As String
		
		'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If World_Renamed.World(i).LCity Is Nothing Then
			frmGame.imgCit(pic).Visible = False
			Exit Sub
		End If
		
		'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		LCity = World_Renamed.World(i).LCity.T
		
		frmGame.imgCit(pic).Visible = True
		If LCity = "City" Then
			frmGame.imgCit(pic).Image = frmGame.imgCitCity.Image
		ElseIf LCity = "Crossroad" Then 
			frmGame.imgCit(pic).Image = frmGame.imgCitCross.Image
		ElseIf LCity = "Slums" Then 
			frmGame.imgCit(pic).Image = frmGame.imgCitSlums.Image
		ElseIf LCity = "Haunted House" Then 
			frmGame.imgCit(pic).Image = frmGame.imgCitHH.Image
		ElseIf LCity <> "None" Then 
			frmGame.imgCit(pic).Image = frmGame.imgMoveExp(0).Image
		Else
			'        frmGame.imgCit(pic).Picture = LoadPicture()
			frmGame.imgCit(pic).Visible = False
		End If
		
	End Sub
	
	Public Sub froute(ByRef s As Short, ByRef d As Short, ByRef cur As Short, ByRef cheat As Short, Optional ByRef Wide As Short = 0)
		Dim i As Short
		For i = 0 To 4
			'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If World_Renamed.World(s).Link(i) <> -1 Then
				'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If World_Renamed.World(World_Renamed.World(s).Link(i)).Explored = 1 Or World_Renamed.World(s).Link(i) = d Or cheat = 1 Then
					If old(s) + 1 > C_RMAX - 1 Or (Wide <> 0 And old(s) + 1 > Wide) Then
						Exit Sub
						'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ElseIf old(s) + 1 < old(World_Renamed.World(s).Link(i)) Then 
						'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						old(World_Renamed.World(s).Link(i)) = old(s) + 1
						'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						path(World_Renamed.World(s).Link(i)) = s
						'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Call froute(World_Renamed.World(s).Link(i), d, cur, cheat, Wide)
					ElseIf cheat = 1 Then 
						'          frmStart.pbGenerate.Value = s
					End If
				End If
				'    Else
				'      Exit Sub
			End If
		Next i
	End Sub
	
	Public Function CalcRoute(ByRef dest As String, Optional ByRef cheat As Short = 0, Optional ByRef Wide As Short = 0) As String
		Dim d As Short
		d = Val(dest)
		Dim s As Short
		Dim i As Short
		If d > -1 And d < C_LOCS Then
			s = Loc_Renamed
			For i = 0 To C_RMAX - 1
				route(i) = -1
			Next i
			For i = 0 To C_LOCS - 1
				old(i) = C_LOCS
				path(i) = -1
			Next i
			cur = 0
			old(s) = 0
			Call froute(s, d, 0, cheat, Wide)
			i = d
			cur = old(d) ' - 1
			
			If cur = C_LOCS Then
				CalcRoute = "Bad Dest: Dest. not reachable through explored areas."
				Exit Function
			End If
			
			route(0) = s
			route(cur) = d
			While i <> s
				route(cur - 1) = path(i)
				i = path(i)
				cur = cur - 1
			End While
			
			CalcRoute = ""
			For i = 1 To C_RMAX - 1
				If route(i) <> -1 Then
					CalcRoute = CalcRoute & " > "
					'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If World_Renamed.World(route(i)).Explored = 0 Then
						CalcRoute = CalcRoute & "(" & route(i) & ")"
					Else
						CalcRoute = CalcRoute & route(i)
					End If
				Else
					Exit For
				End If
			Next i
		Else
			CalcRoute = "Bad Dest"
		End If
	End Function
	
	Public Function NextRoute() As Short
		Dim dest As Short
		Dim i As Short
		
		dest = curroute(1)
		
		'  dest = Left(frmGame.txShowRoute, Len(frmGame.txShowRoute) - InStr(1, frmGame.txShowRoute, ">", vbBinaryCompare) + 1)
		frmGame.txShowRoute.Text = Right(frmGame.txShowRoute.Text, Len(frmGame.txShowRoute.Text) - 2)
		If InStr(1, frmGame.txShowRoute.Text, ">", CompareMethod.Text) <> 0 Then
			frmGame.txShowRoute.Text = Right(frmGame.txShowRoute.Text, Len(frmGame.txShowRoute.Text) - InStr(1, frmGame.txShowRoute.Text, ">", CompareMethod.Text) + 2)
		Else
			frmGame.txShowRoute.Text = ""
		End If
		For i = 1 To C_RMAX - 1
			curroute(i - 1) = curroute(i)
			If curroute(i) = -1 Then Exit For
		Next i
		NextRoute = dest
	End Function
	
	Public Sub MoveTo(ByRef T As Short)
		frmGame.AddEvent(("Moved from " & Loc_Renamed & " to " & T))
		Loc_Renamed = T
		'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If World_Renamed.World(Loc_Renamed).Explored = 0 Then frmGame.AddEvent(("Explored " & Loc_Renamed))
		
		PassTime()
		
		Encounter()
	End Sub
End Module