Attribute VB_Name = "world"
Option Explicit
Public World(0 To C_LOCS - 1) As New Location
Public People(0 To C_PEOPLE - 1) As New Person
Public RegionNames() As String '(0 To C_LOCS - 1) As String
Public Loc As Integer
Public Cities() As Integer
Public Turn As Integer
Public GameDate As Date
Public TRegions As Integer

Public Function TerName(i As Integer) As String
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

Public Function Available(g As Integer)
  Dim n As Integer
  For n = 0 To C_MAXCONNECTS - 1
    If World(g).Link(n) = -1 Then
      Available = n
      Exit Function
    End If
  Next n
  Available = -1
End Function

Public Function Accessable() As Integer
  Dim i As Integer
  For i = 0 To C_LOCS - 1
    If old(i) = 0 Then
      Accessable = 0
      Exit Function
    End If
  Next i
  Accessable = 1
End Function

Public Sub Region(n As Integer, r As Integer, Optional dep As Integer = -1)
  Dim i As Integer
  World(n).Region = r
  If dep <> -1 Then World(n).Depth = dep
  For i = 0 To 4
    If World(n).Link(i) <> -1 Then
      If World(n).Terrain = World(World(n).Link(i)).Terrain And World(World(n).Link(i)).Region = -1 Then
        Call Region(World(n).Link(i), r, dep)
      End If
    End If
  Next i
End Sub

Public Sub SwapLoc(A As Location, b As Location)
  Dim temp As Location
  
'  If a = b Then Exit Sub
  
  Set temp = A
  Set A = A
  Set b = temp
End Sub


Public Sub Renumber(r As Integer, place As Integer)
  Dim nplace As Integer
  Dim ntd As Integer
  Dim i As Integer
  Dim j As Integer
  Dim temp(0 To C_LOCS - 1) As Location
  Dim todo(0 To C_LOCS - 1) As Integer
  Dim rev(0 To C_LOCS - 1) As Integer
  Dim Done(0 To C_LOCS - 1) As Integer
  
  ntd = 0
  nplace = ntd
  todo(0) = r
  Done(ntd) = 1
  
  While ntd < C_LOCS
    
    For i = 0 To 4
      If World(todo(ntd)).Link(i) <> -1 Then
        If Done(World(todo(ntd)).Link(i)) = 0 Then
          nplace = nplace + 1
          todo(nplace) = World(todo(ntd)).Link(i)
          rev(World(todo(ntd)).Link(i)) = nplace
          Done(World(todo(ntd)).Link(i)) = 1
        End If
      End If
    Next i
    
    ntd = ntd + 1
    
  Wend
  
  For i = 0 To C_LOCS - 1
    Set temp(i) = World(todo(i))
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
    Call SwapLoc(temp(i), World(i))
  Next i
  
  Exit Sub
  
End Sub

Public Sub BuildRoads()
  Dim c As Integer
  Dim follow As Integer
  Dim i As Integer
  Dim rs As Integer
  
  For i = 0 To C_LOCS - 1
    If Not World(i).LCity Is Nothing Then
      If World(i).LCity.T = "City" Then
        c = c + 1
      End If
    End If
  Next i
  
  ReDim Cities(0 To c - 1) As Integer
  c = 0
  
  For i = 0 To C_LOCS - 1
    If Not World(i).LCity Is Nothing Then
      If World(i).LCity.T = "City" Then
        Cities(c) = i
        c = c + 1
      End If
    End If
  Next i

  For i = 0 To UBound(Cities)
    Dim cur As Integer
    Dim last As Integer
    cur = Cities(i)
    
    If World(cur).Road = 1 And World(cur).RoadFrom <> -1 Then
      World(cur).RoadFrom = cur
    ElseIf Int(Rnd * 0) + 1 <= World(cur).LCity.Size Or Int(Rnd * 3) = 0 Then ' = 0
      Do
        World(cur).Road = 1
        World(cur).RoadFrom = cur
        rs = rs + 1
        Do
          follow = Int(Rnd * 4)
        Loop While World(cur).Link(follow) = -1
        
        cur = World(cur).Link(follow)
        
  '      Call Road(World(Cities(i)).Link(follow), i)
        If Not World(cur).LCity Is Nothing Then
          If World(cur).LCity.T = "City" Then
            Exit Do
          End If
        End If
        If World(cur).RoadFrom <> cur And World(cur).RoadFrom <> -1 Then
          Exit Do
        End If
      Loop
      World(cur).Road = 1
      World(cur).RoadFrom = cur
      rs = rs + 1
    Else
      World(cur).Road = 1
      World(cur).RoadFrom = cur
      rs = rs + 1
    End If
  
    For last = 0 To 4
      If World(cur).Link(last) <> -1 Then
        If World(World(cur).Link(last)).LCity Is Nothing Then
          If Int(Rnd * 5) < World(cur).LCity.Size Then
            Set World(World(cur).Link(last)).LCity = New City
            Call World(World(cur).Link(last)).LCity.MakeSlums(World(cur).Link(last))
            Exit For
          End If
        End If
      End If
    Next last
  
  Next i
  
  Exit Sub
End Sub

Public Sub BuildCrossroads()
  Dim j As Integer
  Dim i As Integer
  Dim roads As Integer
  For i = 0 To C_LOCS - 1
    roads = 0
    If World(i).Road = 1 Then
      roads = 1
    Else
      roads = -10
    End If
    For j = 0 To 4
      If World(i).Link(j) <> -1 Then
        If World(World(i).Link(j)).Road = 1 Then roads = roads + 1
        If Not World(World(i).Link(j)).LCity Is Nothing Then
          If World(World(i).Link(j)).LCity.T = "Crossroad" Then roads = -5
        End If
      End If
    Next j
    If roads >= 5 And World(i).LCity Is Nothing Then
      Set World(i).LCity = New City
      Call World(i).LCity.MakeCrossroad(i)
    End If
  Next i
End Sub

Public Sub BuildSpecials()
  Dim i As Integer
  Dim n As Integer
  Dim r As Integer
  Dim z As Integer
  Dim c As Integer
  
'  For i = 0 To C_LOCS - 1
  For i = 0 To 19
    c = 0
    Do
      z = ((C_LOCS \ 20) * i) + Int(Rnd * (C_LOCS \ 20))
      c = c + 1
    Loop While (Not World(z).LCity Is Nothing Or World(z).Road = 1) And c < 50
'    r = Int(Rnd * 1000)
    r = Int(Rnd * 100)
    
    Select Case r
      Case 0 To 9
        If World(z).LCity Is Nothing And World(z).Road = 0 Then
          Set World(z).LCity = New City
          Call World(z).LCity.MakeHauntedHouse(z)
        End If
      Case 10 To 19
        If World(z).LCity Is Nothing And World(z).Road = 0 Then
          Set World(z).LCity = New City
          Call World(z).LCity.MakeGraveyard(z)
        End If
      Case 20 To 39
        If World(z).LCity Is Nothing And World(z).Road = 0 Then
          Set World(z).LCity = New City
          Call World(z).LCity.MakeFairyPond(z)
        End If
      Case 40 To 49
        If World(z).LCity Is Nothing And World(z).Road = 0 Then
          Set World(z).LCity = New City
          Call World(z).LCity.MakeRuins(z)
        End If
      Case 50 To 59
        If World(z).LCity Is Nothing And World(z).Road = 0 Then
          Set World(z).LCity = New City
          Call World(z).LCity.MakeGoblinMine(z)
        End If
      Case 60 To 69
        If World(z).LCity Is Nothing And World(z).Road = 0 Then
          Set World(z).LCity = New City
          Call World(z).LCity.MakeTransmuter(z)
        End If
      Case 70 To 79
        If World(z).LCity Is Nothing And World(z).Road = 0 Then
          Set World(z).LCity = New City
          Call World(z).LCity.MakeCarnival(z)
        End If
      Case 80 To 89
        If World(z).LCity Is Nothing And World(z).Road = 0 Then
          Set World(z).LCity = New City
          Call World(z).LCity.MakeAcademy(z)
        End If
      Case 90 To 99
        If World(z).LCity Is Nothing And World(z).Road = 0 Then
          Set World(z).LCity = New City
          Call World(z).LCity.MakeTemple(z)
        End If
    End Select
  Next i
  
End Sub

Public Sub Access(n As Integer)
  Dim i As Integer
  Static c As Integer

  If n = 0 Then
    c = 0
  Else
    c = c + 1
  End If
  If c > 1000 Then
    MsgBox "Access Error"
    Exit Sub
  End If

  old(n) = 1
  For i = 0 To 4
    If World(n).Link(i) <> -1 Then
      If old(World(n).Link(i)) = 0 Then
        Access (World(n).Link(i))
      End If
    End If
  Next i
End Sub

Public Sub MakeAccessable()
  Dim i As Integer
  Dim g As Integer
  Dim j As Integer
  Dim c As Integer
  For i = 0 To C_LOCS - 1
    old(i) = 0
  Next i
  Call Access(0)
  While Accessable() = 0
    For i = 0 To C_LOCS - 1
      If old(i) = 0 And Available(i) <> -1 Then
        g = LinkT(i)
        
        While Connected(i, g) = 1 Or Available(g) = -1
          g = LinkT(i)
        Wend
        
        If Connected(i, g) = 0 And Available(g) <> -1 Then
          World(i).Link(Available(i)) = g
          World(g).Link(Available(g)) = i
'          Call Connected(i, g)
        End If
      ElseIf old(i) = 0 Then
        g = LinkT(i)
        
        While Connected(i, g) = 1 Or Available(g) = -1
          g = LinkT(i)
        Wend
        
        If Connected(i, g) = 0 And Available(g) <> -1 Then
          Dim getyup As Integer
          getyup = Int(Rnd * C_MAXCONNECTS)
          
          For j = 0 To 4
            If World(World(i).Link(getyup)).Link(j) <> -1 Then
              If World(World(i).Link(getyup)).Link(j) = i Then Exit For
            End If
          Next j
          
          World(World(i).Link(getyup)).Link(j) = -1
          World(i).Link(getyup) = g
          World(g).Link(Available(g)) = i
'          Call Connected(i, g)
        End If
      End If
    Next i
    For i = 0 To C_LOCS - 1
      old(i) = 0
    Next i
    
    Call Access(0)
    frmStart.ckStatus(1).Value = 1 - frmStart.ckStatus(1).Value
  Wend

End Sub

Public Sub MakeCities()
  Dim i As Integer
  
  Call World(0).GenerateCity(3)
  Call World(Int(Rnd * 50) + 1 * 50).GenerateCity(0)
  Call World(Int(Rnd * 50) + 2 * 50).GenerateCity(1)
  Call World(Int(Rnd * 50) + 3 * 50).GenerateCity(0)
  Call World(Int(Rnd * 50) + 4 * 50).GenerateCity(2)
  Call World(Int(Rnd * 50) + 5 * 50).GenerateCity(0)
  Call World(Int(Rnd * 50) + 6 * 50).GenerateCity(1)
  Call World(Int(Rnd * 50) + 7 * 50).GenerateCity(0)
  Call World(Int(Rnd * 50) + 8 * 50).GenerateCity(2)
  Call World(Int(Rnd * 50) + 9 * 50).GenerateCity(0)
  Call World(Int(Rnd * 50) + 10 * 50).GenerateCity(1)
  Call World(Int(Rnd * 50) + 11 * 50).GenerateCity(0)
  Call World(Int(Rnd * 50) + 12 * 50).GenerateCity(2)
  Call World(Int(Rnd * 50) + 13 * 50).GenerateCity(0)
  Call World(Int(Rnd * 50) + 14 * 50).GenerateCity(1)
  Call World(Int(Rnd * 50) + 15 * 50).GenerateCity(0)
  Call World(Int(Rnd * 50) + 16 * 50).GenerateCity(2)
  Call World(Int(Rnd * 50) + 17 * 50).GenerateCity(0)
  Call World(Int(Rnd * 50) + 18 * 50).GenerateCity(1)
  
  
  
'  For i = 0 To 998
'    If Int(Rnd * 25) = 0 Or i = 0 Then
'      Set World(i).LCity = New City
'      Call World(i).LCity.MakeCity(i)
'    Else
'      Set World(i).LCity = New City
'    End If
'  Next i
End Sub
Public Function Connected(i As Integer, g As Integer) As Integer
  Dim n As Integer
  
  If i = g Then
    Connected = 1
    Exit Function
  Else
    For n = 0 To 4
      If World(i).Link(n) = g Then
        Connected = 1
'        Exit Function
        Exit For
      End If
    Next n
    For n = 0 To 4
      If World(g).Link(n) = i Then
        Connected = Connected + 1
'        Exit Function
        Exit For
      End If
    Next n
    If Connected = 1 Then
      MsgBox "ERROR!"
    ElseIf Connected = 2 Then
      Connected = 1
      Exit Function
    End If
    
  End If
  Connected = 0
End Function

Public Function LinkT(i As Integer) As Integer ', Optional f As long = 0)
'  Dim ff As long
'  Dim g As long
'  ff = f + 1
  Dim K, g As Integer
  For K = 0 To 10
    g = Max( _
          Min( _
            Int(i + Rnd * (C_LOCS \ (20))) - C_LOCS \ (40), _
          C_LOCS - 1), _
        0)

    If World(i).Terrain = World(g).Terrain And i <> g Then 'And Connected(i, g) = 0 Then ' And Available(g) <> -1 Then
      Exit For
    End If
  Next K
  
  LinkT = g
End Function

Public Sub PlacePeople()
  Dim i As Integer
  Dim r As Integer
  Dim j As Integer
  Dim n As Integer
  
  For j = 0 To UBound(Cities)
    If Int(Rnd * 4) <= World(Cities(j)).LCity.Size Then
      Call People(n).MakeGuards(Cities(j), World(Cities(j)).LCity.Name)
      n = n + 1
    End If
  Next j
  
  For i = n To C_PEOPLE - 1
    r = Int(Rnd * 100)
    Select Case r
      Case 0 To 44
        Call People(i).MakeMerchant(Int(Rnd * C_LOCS), CityNameFirst)
      Case 45 To 90
        Call People(i).MakeGypsy(Int(Rnd * C_LOCS), CityNameFirst)
      Case 91 To 99
        Call People(i).MakeTaxidermist(Int(Rnd * C_LOCS), CityNameFirst)
    End Select
  Next i
End Sub

Public Sub Generate()
  Dim g As Integer
  Dim j As Integer
  Dim i As Integer
  Dim K As Integer
  Dim gt As Integer
  Dim tempregionnames(0 To C_LOCS - 1) As String
  Dim T As Integer
  
  For i = 0 To C_LOCS - 1
    For j = 0 To 4
      
      g = LinkT(i)
      gt = Available(g)
        
      If World(i).Link(j) = -1 And Connected(i, g) = 0 And gt <> -1 And _
      ((World(i).Terrain = World(g).Terrain And Int(Rnd * 100) < C_SAMETERRAINCHANCE) _
       Or Int(Rnd * 100) < C_DIFTERRAINCHANCE) Then 'And Int(Rnd * 100) < 50 - Abs(i - g) Then
        World(i).Link(j) = g
        World(g).Link(gt) = i
'        Call Connected(i, g)
      End If
    Next j
  Next i
  
  frmStart.ckStatus(0) = 1
  frmStart.Refresh
  
  Call MakeAccessable
  frmStart.ckStatus(1) = 1
  frmStart.Refresh
  
  Call Renumber(0, 0)
'  Call MakeAccessable
  
  frmStart.ckStatus(2) = 1
  frmStart.Refresh
  
  Dim c As Integer
  For i = 0 To C_LOCS - 1
    For g = 0 To 4
      For c = 0 To 3
        If (World(i).Link(c) > World(i).Link(c + 1) And World(i).Link(c + 1) <> -1) Or World(i).Link(c) = -1 Then
          T = World(i).Link(c)
          World(i).Link(c) = World(i).Link(c + 1)
          World(i).Link(c + 1) = T
        End If
      Next c
    Next g
  Next i
  
  frmStart.ckStatus(3) = 1
  frmStart.Refresh

  Call move.CalcRoute("0", 1)
  
  frmStart.ckStatus(4) = 1
  frmStart.Refresh

  TRegions = 0
  For i = 0 To C_LOCS - 1
    World(i).level = old(i)
    World(i).Depth = i \ 50
    World(i).Loc = i
    If World(i).Region = -1 Then
      Call Region(i, TRegions) ', old(i)) 'World(i).Depth)
      tempregionnames(TRegions) = World(i).Terrain
      TRegions = TRegions + 1
    End If
  Next i
  
  ReDim RegionNames(0 To TRegions - 1)
  
  For i = 0 To TRegions - 1
    RegionNames(i) = tempregionnames(i)
  Next i
  
  Call NameRegions
  
  frmStart.ckStatus(5) = 1
  frmStart.Refresh
  
  Call MakeCities
  Call BuildRoads
  Call BuildCrossroads
  Call BuildSpecials
  Call PlacePeople
'  Call BuildHauntedHouses
'  Call BuildFairyPonds
  
  frmStart.ckStatus(6) = 1
  frmStart.Refresh
    
'  For i = 0 To C_LOCS - 1
'    For j = 0 To C_LOCS - 1
'      q = Connected(i, j)
'    Next j
'  Next i
    
  GameDate = DateValue("January 1, 2000")
End Sub


