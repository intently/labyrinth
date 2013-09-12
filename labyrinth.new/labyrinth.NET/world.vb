Option Strict Off
Option Explicit On
Module world
	'UPGRADE_WARNING: Arrays can't be declared with New. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC9D3AE5-6B95-4B43-91C7-28276302A5E8"'
	'UPGRADE_NOTE: World was upgraded to World_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Public World_Renamed(C_LOCS - 1) As New Location
	'UPGRADE_WARNING: Arrays can't be declared with New. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC9D3AE5-6B95-4B43-91C7-28276302A5E8"'
	Public People(C_PEOPLE - 1) As New Person
	Public RegionNames() As String '(0 To C_LOCS - 1) As String
	'UPGRADE_NOTE: Loc was upgraded to Loc_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Public Loc_Renamed As Short
	Public Cities() As Short
	Public Turn As Short
	Public GameDate As Date
	Public TRegions As Short
	
	Public Function TerName(ByRef i As Short) As String
		Select Case i
			Case T_FOR
				TerName = "Forest"
			Case T_DES
				TerName = "Desert"
			Case T_PLN
				TerName = "Plains"
			Case T_TUN
				TerName = "Tundra"
			Case T_SWP
				TerName = "Swamp"
			Case T_MTN
				TerName = "Mountains"
			Case T_HIL
				TerName = "Hills"
			Case T_JUN
				TerName = "Jungle"
		End Select
	End Function
	
	Public Function Available(ByRef g As Short) As Object
		Dim n As Short
		For n = 0 To C_MAXCONNECTS - 1
			If World_Renamed(g).Link(n) = -1 Then
				'UPGRADE_WARNING: Couldn't resolve default property of object Available. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Available = n
				Exit Function
			End If
		Next n
		'UPGRADE_WARNING: Couldn't resolve default property of object Available. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Available = -1
	End Function
	
	Public Function Accessable() As Short
		Dim i As Short
		For i = 0 To C_LOCS - 1
			If old(i) = 0 Then
				Accessable = 0
				Exit Function
			End If
		Next i
		Accessable = 1
	End Function
	
	Public Sub Region(ByRef n As Short, ByRef r As Short, Optional ByRef dep As Short = -1)
		Dim i As Short
		World_Renamed(n).Region = r
		If dep <> -1 Then World_Renamed(n).Depth = dep
		For i = 0 To 4
			If World_Renamed(n).Link(i) <> -1 Then
				If World_Renamed(n).Terrain = World_Renamed(World_Renamed(n).Link(i)).Terrain And World_Renamed(World_Renamed(n).Link(i)).Region = -1 Then
					Call Region(World_Renamed(n).Link(i), r, dep)
				End If
			End If
		Next i
	End Sub
	
	Public Sub SwapLoc(ByRef A As Location, ByRef b As Location)
		Dim temp As Location
		
		'  If a = b Then Exit Sub
		
		temp = A
		A = A
		b = temp
	End Sub
	
	
	Public Sub Renumber(ByRef r As Short, ByRef place As Short)
		Dim nplace As Short
		Dim ntd As Short
		Dim i As Short
		Dim j As Short
		Dim temp(C_LOCS - 1) As Location
		Dim todo(C_LOCS - 1) As Short
		Dim rev(C_LOCS - 1) As Short
		Dim Done(C_LOCS - 1) As Short
		
		ntd = 0
		nplace = ntd
		todo(0) = r
		Done(ntd) = 1
		
		While ntd < C_LOCS
			
			For i = 0 To 4
				If World_Renamed(todo(ntd)).Link(i) <> -1 Then
					If Done(World_Renamed(todo(ntd)).Link(i)) = 0 Then
						nplace = nplace + 1
						todo(nplace) = World_Renamed(todo(ntd)).Link(i)
						rev(World_Renamed(todo(ntd)).Link(i)) = nplace
						Done(World_Renamed(todo(ntd)).Link(i)) = 1
					End If
				End If
			Next i
			
			ntd = ntd + 1
			
		End While
		
		For i = 0 To C_LOCS - 1
			temp(i) = World_Renamed(todo(i))
			For j = 0 To 4
				If temp(i).Link(j) < C_LOCS And temp(i).Link(j) <> -1 Then
					temp(i).Link(j) = rev(temp(i).Link(j)) + C_LOCS
				End If
			Next j
		Next i
		
		For i = 0 To C_LOCS - 1
			For j = 0 To 4
				If temp(i).Link(j) <> -1 Then
					temp(i).Link(j) = temp(i).Link(j) - C_LOCS
				End If
			Next j
		Next i
		
		For i = 0 To C_LOCS - 1
			Call SwapLoc(temp(i), World_Renamed(i))
		Next i
		
		Exit Sub
		
	End Sub
	
	Public Sub BuildRoads()
		Dim c As Short
		Dim follow As Short
		Dim i As Short
		Dim rs As Short
		
		For i = 0 To C_LOCS - 1
			If Not World_Renamed(i).LCity Is Nothing Then
				If World_Renamed(i).LCity.T = "City" Then
					c = c + 1
				End If
			End If
		Next i
		
		ReDim Cities(c - 1)
		c = 0
		
		For i = 0 To C_LOCS - 1
			If Not World_Renamed(i).LCity Is Nothing Then
				If World_Renamed(i).LCity.T = "City" Then
					Cities(c) = i
					c = c + 1
				End If
			End If
		Next i
		
		Dim cur As Short
		Dim last As Short
		For i = 0 To UBound(Cities)
			cur = Cities(i)
			
			If World_Renamed(cur).Road = 1 And World_Renamed(cur).RoadFrom <> -1 Then
				World_Renamed(cur).RoadFrom = cur
			ElseIf Int(Rnd() * 0) + 1 <= World_Renamed(cur).LCity.Size Or Int(Rnd() * 3) = 0 Then  ' = 0
				Do 
					World_Renamed(cur).Road = 1
					World_Renamed(cur).RoadFrom = cur
					rs = rs + 1
					Do 
						follow = Int(Rnd() * 4)
					Loop While World_Renamed(cur).Link(follow) = -1
					
					cur = World_Renamed(cur).Link(follow)
					
					'      Call Road(World(Cities(i)).Link(follow), i)
					If Not World_Renamed(cur).LCity Is Nothing Then
						If World_Renamed(cur).LCity.T = "City" Then
							Exit Do
						End If
					End If
					If World_Renamed(cur).RoadFrom <> cur And World_Renamed(cur).RoadFrom <> -1 Then
						Exit Do
					End If
				Loop 
				World_Renamed(cur).Road = 1
				World_Renamed(cur).RoadFrom = cur
				rs = rs + 1
			Else
				World_Renamed(cur).Road = 1
				World_Renamed(cur).RoadFrom = cur
				rs = rs + 1
			End If
			
			For last = 0 To 4
				If World_Renamed(cur).Link(last) <> -1 Then
					If World_Renamed(World_Renamed(cur).Link(last)).LCity Is Nothing Then
						If Int(Rnd() * 5) < World_Renamed(cur).LCity.Size Then
							World_Renamed(World_Renamed(cur).Link(last)).LCity = New City
							Call World_Renamed(World_Renamed(cur).Link(last)).LCity.MakeSlums(World_Renamed(cur).Link(last))
							Exit For
						End If
					End If
				End If
			Next last
			
		Next i
		
		Exit Sub
	End Sub
	
	Public Sub BuildCrossroads()
		Dim j As Short
		Dim i As Short
		Dim roads As Short
		For i = 0 To C_LOCS - 1
			roads = 0
			If World_Renamed(i).Road = 1 Then
				roads = 1
			Else
				roads = -10
			End If
			For j = 0 To 4
				If World_Renamed(i).Link(j) <> -1 Then
					If World_Renamed(World_Renamed(i).Link(j)).Road = 1 Then roads = roads + 1
					If Not World_Renamed(World_Renamed(i).Link(j)).LCity Is Nothing Then
						If World_Renamed(World_Renamed(i).Link(j)).LCity.T = "Crossroad" Then roads = -5
					End If
				End If
			Next j
			If roads >= 5 And World_Renamed(i).LCity Is Nothing Then
				World_Renamed(i).LCity = New City
				Call World_Renamed(i).LCity.MakeCrossroad(i)
			End If
		Next i
	End Sub
	
	Public Sub BuildSpecials()
		Dim i As Short
		Dim n As Short
		Dim r As Short
		Dim z As Short
		Dim c As Short
		
		'  For i = 0 To C_LOCS - 1
		For i = 0 To 19
			c = 0
			Do 
				z = ((C_LOCS \ 20) * i) + Int(Rnd() * (C_LOCS \ 20))
				c = c + 1
			Loop While (Not World_Renamed(z).LCity Is Nothing Or World_Renamed(z).Road = 1) And c < 50
			'    r = Int(Rnd * 1000)
			r = Int(Rnd() * 100)
			
			Select Case r
				Case 0 To 9
					If World_Renamed(z).LCity Is Nothing And World_Renamed(z).Road = 0 Then
						World_Renamed(z).LCity = New City
						Call World_Renamed(z).LCity.MakeHauntedHouse(z)
					End If
				Case 10 To 19
					If World_Renamed(z).LCity Is Nothing And World_Renamed(z).Road = 0 Then
						World_Renamed(z).LCity = New City
						Call World_Renamed(z).LCity.MakeGraveyard(z)
					End If
				Case 20 To 39
					If World_Renamed(z).LCity Is Nothing And World_Renamed(z).Road = 0 Then
						World_Renamed(z).LCity = New City
						Call World_Renamed(z).LCity.MakeFairyPond(z)
					End If
				Case 40 To 49
					If World_Renamed(z).LCity Is Nothing And World_Renamed(z).Road = 0 Then
						World_Renamed(z).LCity = New City
						Call World_Renamed(z).LCity.MakeRuins(z)
					End If
				Case 50 To 59
					If World_Renamed(z).LCity Is Nothing And World_Renamed(z).Road = 0 Then
						World_Renamed(z).LCity = New City
						Call World_Renamed(z).LCity.MakeGoblinMine(z)
					End If
				Case 60 To 69
					If World_Renamed(z).LCity Is Nothing And World_Renamed(z).Road = 0 Then
						World_Renamed(z).LCity = New City
						Call World_Renamed(z).LCity.MakeTransmuter(z)
					End If
				Case 70 To 79
					If World_Renamed(z).LCity Is Nothing And World_Renamed(z).Road = 0 Then
						World_Renamed(z).LCity = New City
						Call World_Renamed(z).LCity.MakeCarnival(z)
					End If
				Case 80 To 89
					If World_Renamed(z).LCity Is Nothing And World_Renamed(z).Road = 0 Then
						World_Renamed(z).LCity = New City
						Call World_Renamed(z).LCity.MakeAcademy(z)
					End If
				Case 90 To 99
					If World_Renamed(z).LCity Is Nothing And World_Renamed(z).Road = 0 Then
						World_Renamed(z).LCity = New City
						Call World_Renamed(z).LCity.MakeTemple(z)
					End If
			End Select
		Next i
		
	End Sub
	
	Public Sub Access(ByRef n As Short)
		Dim i As Short
		Static c As Short
		
		If n = 0 Then
			c = 0
		Else
			c = c + 1
		End If
		If c > 1000 Then
			MsgBox("Access Error")
			Exit Sub
		End If
		
		old(n) = 1
		For i = 0 To 4
			If World_Renamed(n).Link(i) <> -1 Then
				If old(World_Renamed(n).Link(i)) = 0 Then
					Access((World_Renamed(n).Link(i)))
				End If
			End If
		Next i
	End Sub
	
	Public Sub MakeAccessable()
		Dim i As Short
		Dim g As Short
		Dim j As Short
		Dim c As Short
		For i = 0 To C_LOCS - 1
			old(i) = 0
		Next i
		Call Access(0)
		Dim getyup As Short
		While Accessable() = 0
			For i = 0 To C_LOCS - 1
				'UPGRADE_WARNING: Couldn't resolve default property of object Available(i). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If old(i) = 0 And Available(i) <> -1 Then
					g = LinkT(i)
					
					'UPGRADE_WARNING: Couldn't resolve default property of object Available(g). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					While Connected(i, g) = 1 Or Available(g) = -1
						g = LinkT(i)
					End While
					
					'UPGRADE_WARNING: Couldn't resolve default property of object Available(g). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If Connected(i, g) = 0 And Available(g) <> -1 Then
						'UPGRADE_WARNING: Couldn't resolve default property of object Available(i). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						World_Renamed(i).Link(Available(i)) = g
						'UPGRADE_WARNING: Couldn't resolve default property of object Available(g). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						World_Renamed(g).Link(Available(g)) = i
						'          Call Connected(i, g)
					End If
				ElseIf old(i) = 0 Then 
					g = LinkT(i)
					
					'UPGRADE_WARNING: Couldn't resolve default property of object Available(g). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					While Connected(i, g) = 1 Or Available(g) = -1
						g = LinkT(i)
					End While
					
					'UPGRADE_WARNING: Couldn't resolve default property of object Available(g). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If Connected(i, g) = 0 And Available(g) <> -1 Then
						getyup = Int(Rnd() * C_MAXCONNECTS)
						
						For j = 0 To 4
							If World_Renamed(World_Renamed(i).Link(getyup)).Link(j) <> -1 Then
								If World_Renamed(World_Renamed(i).Link(getyup)).Link(j) = i Then Exit For
							End If
						Next j
						
						World_Renamed(World_Renamed(i).Link(getyup)).Link(j) = -1
						World_Renamed(i).Link(getyup) = g
						'UPGRADE_WARNING: Couldn't resolve default property of object Available(g). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						World_Renamed(g).Link(Available(g)) = i
						'          Call Connected(i, g)
					End If
				End If
			Next i
			For i = 0 To C_LOCS - 1
				old(i) = 0
			Next i
			
			Call Access(0)
			frmStart.ckStatus(1).CheckState = 1 - frmStart.ckStatus(1).CheckState
		End While
		
	End Sub
	
	Public Sub MakeCities()
		Dim i As Short
		
		Call World_Renamed(0).GenerateCity(3)
		Call World_Renamed(Int(Rnd() * 50) + 1 * 50).GenerateCity(0)
		Call World_Renamed(Int(Rnd() * 50) + 2 * 50).GenerateCity(1)
		Call World_Renamed(Int(Rnd() * 50) + 3 * 50).GenerateCity(0)
		Call World_Renamed(Int(Rnd() * 50) + 4 * 50).GenerateCity(2)
		Call World_Renamed(Int(Rnd() * 50) + 5 * 50).GenerateCity(0)
		Call World_Renamed(Int(Rnd() * 50) + 6 * 50).GenerateCity(1)
		Call World_Renamed(Int(Rnd() * 50) + 7 * 50).GenerateCity(0)
		Call World_Renamed(Int(Rnd() * 50) + 8 * 50).GenerateCity(2)
		Call World_Renamed(Int(Rnd() * 50) + 9 * 50).GenerateCity(0)
		Call World_Renamed(Int(Rnd() * 50) + 10 * 50).GenerateCity(1)
		Call World_Renamed(Int(Rnd() * 50) + 11 * 50).GenerateCity(0)
		Call World_Renamed(Int(Rnd() * 50) + 12 * 50).GenerateCity(2)
		Call World_Renamed(Int(Rnd() * 50) + 13 * 50).GenerateCity(0)
		Call World_Renamed(Int(Rnd() * 50) + 14 * 50).GenerateCity(1)
		Call World_Renamed(Int(Rnd() * 50) + 15 * 50).GenerateCity(0)
		Call World_Renamed(Int(Rnd() * 50) + 16 * 50).GenerateCity(2)
		Call World_Renamed(Int(Rnd() * 50) + 17 * 50).GenerateCity(0)
		Call World_Renamed(Int(Rnd() * 50) + 18 * 50).GenerateCity(1)
		
		
		
		'  For i = 0 To 998
		'    If Int(Rnd * 25) = 0 Or i = 0 Then
		'      Set World(i).LCity = New City
		'      Call World(i).LCity.MakeCity(i)
		'    Else
		'      Set World(i).LCity = New City
		'    End If
		'  Next i
	End Sub
	Public Function Connected(ByRef i As Short, ByRef g As Short) As Short
		Dim n As Short
		
		If i = g Then
			Connected = 1
			Exit Function
		Else
			For n = 0 To 4
				If World_Renamed(i).Link(n) = g Then
					Connected = 1
					'        Exit Function
					Exit For
				End If
			Next n
			For n = 0 To 4
				If World_Renamed(g).Link(n) = i Then
					Connected = Connected + 1
					'        Exit Function
					Exit For
				End If
			Next n
			If Connected = 1 Then
				MsgBox("ERROR!")
			ElseIf Connected = 2 Then 
				Connected = 1
				Exit Function
			End If
			
		End If
		Connected = 0
	End Function
	
	Public Function LinkT(ByRef i As Short) As Short ', Optional f As long = 0)
		'  Dim ff As long
		'  Dim g As long
		'  ff = f + 1
		Dim K As Object
		Dim g As Short
		For K = 0 To 10
			'UPGRADE_WARNING: Couldn't resolve default property of object Max(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			g = Max(Min(Int(i + Rnd() * (C_LOCS \ (20))) - C_LOCS \ (40), C_LOCS - 1), 0)
			
			If World_Renamed(i).Terrain = World_Renamed(g).Terrain And i <> g Then 'And Connected(i, g) = 0 Then ' And Available(g) <> -1 Then
				Exit For
			End If
		Next K
		
		LinkT = g
	End Function
	
	Public Sub PlacePeople()
		Dim i As Short
		Dim r As Short
		Dim j As Short
		Dim n As Short
		
		For j = 0 To UBound(Cities)
			If Int(Rnd() * 4) <= World_Renamed(Cities(j)).LCity.Size Then
				Call People(n).MakeGuards(Cities(j), (World_Renamed(Cities(j)).LCity.Name))
				n = n + 1
			End If
		Next j
		
		For i = n To C_PEOPLE - 1
			r = Int(Rnd() * 100)
			Select Case r
				Case 0 To 44
					Call People(i).MakeMerchant(Int(Rnd() * C_LOCS), CityNameFirst)
				Case 45 To 90
					Call People(i).MakeGypsy(Int(Rnd() * C_LOCS), CityNameFirst)
				Case 91 To 99
					Call People(i).MakeTaxidermist(Int(Rnd() * C_LOCS), CityNameFirst)
			End Select
		Next i
	End Sub
	
	Public Sub Generate()
		Dim g As Short
		Dim j As Short
		Dim i As Short
		Dim K As Short
		Dim gt As Short
		Dim tempregionnames(C_LOCS - 1) As String
		Dim T As Short
		
		For i = 0 To C_LOCS - 1
			For j = 0 To 4
				
				g = LinkT(i)
				'UPGRADE_WARNING: Couldn't resolve default property of object Available(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				gt = Available(g)
				
				If World_Renamed(i).Link(j) = -1 And Connected(i, g) = 0 And gt <> -1 And ((World_Renamed(i).Terrain = World_Renamed(g).Terrain And Int(Rnd() * 100) < C_SAMETERRAINCHANCE) Or Int(Rnd() * 100) < C_DIFTERRAINCHANCE) Then 'And Int(Rnd * 100) < 50 - Abs(i - g) Then
					World_Renamed(i).Link(j) = g
					World_Renamed(g).Link(gt) = i
					'        Call Connected(i, g)
				End If
			Next j
		Next i
		
		frmStart.ckStatus(0).CheckState = System.Windows.Forms.CheckState.Checked
		frmStart.Refresh()
		
		Call MakeAccessable()
		frmStart.ckStatus(1).CheckState = System.Windows.Forms.CheckState.Checked
		frmStart.Refresh()
		
		Call Renumber(0, 0)
		'  Call MakeAccessable
		
		frmStart.ckStatus(2).CheckState = System.Windows.Forms.CheckState.Checked
		frmStart.Refresh()
		
		Dim c As Short
		For i = 0 To C_LOCS - 1
			For g = 0 To 4
				For c = 0 To 3
					If (World_Renamed(i).Link(c) > World_Renamed(i).Link(c + 1) And World_Renamed(i).Link(c + 1) <> -1) Or World_Renamed(i).Link(c) = -1 Then
						T = World_Renamed(i).Link(c)
						World_Renamed(i).Link(c) = World_Renamed(i).Link(c + 1)
						World_Renamed(i).Link(c + 1) = T
					End If
				Next c
			Next g
		Next i
		
		frmStart.ckStatus(3).CheckState = System.Windows.Forms.CheckState.Checked
		frmStart.Refresh()
		
		Call move.CalcRoute("0", 1)
		
		frmStart.ckStatus(4).CheckState = System.Windows.Forms.CheckState.Checked
		frmStart.Refresh()
		
		TRegions = 0
		For i = 0 To C_LOCS - 1
			World_Renamed(i).level = old(i)
			World_Renamed(i).Depth = i \ 50
			World_Renamed(i).Loc_Renamed = i
			If World_Renamed(i).Region = -1 Then
				Call Region(i, TRegions) ', old(i)) 'World(i).Depth)
				tempregionnames(TRegions) = CStr(World_Renamed(i).Terrain)
				TRegions = TRegions + 1
			End If
		Next i
		
		ReDim RegionNames(TRegions - 1)
		
		For i = 0 To TRegions - 1
			RegionNames(i) = tempregionnames(i)
		Next i
		
		Call NameRegions()
		
		frmStart.ckStatus(5).CheckState = System.Windows.Forms.CheckState.Checked
		frmStart.Refresh()
		
		Call MakeCities()
		Call BuildRoads()
		Call BuildCrossroads()
		Call BuildSpecials()
		Call PlacePeople()
		'  Call BuildHauntedHouses
		'  Call BuildFairyPonds
		
		frmStart.ckStatus(6).CheckState = System.Windows.Forms.CheckState.Checked
		frmStart.Refresh()
		
		'  For i = 0 To C_LOCS - 1
		'    For j = 0 To C_LOCS - 1
		'      q = Connected(i, j)
		'    Next j
		'  Next i
		
		'UPGRADE_WARNING: DateValue has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		GameDate = DateValue("January 1, 2000")
	End Sub
End Module