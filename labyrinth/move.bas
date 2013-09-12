Attribute VB_Name = "move"
Option Explicit
Public route(0 To C_RMAX - 1) As Integer ' holds the sequence of locs to move through
Public path(0 To C_LOCS - 1) As Integer ' holds the loc's parent in the shortest path
Public old(0 To C_LOCS - 1) As Integer ' holds the depth of the location
Public cur As Integer
Public curroute(0 To C_RMAX - 1) As Integer

Public Sub RefreshGame()
  Dim dest As Integer
  Dim exp As Integer
  Dim roadp As Integer
  Dim i As Integer
  Dim frr, bar As String
  
  For i = 0 To 4
    dest = World.World(Loc).Link(i)
    frr = ""
    bar = ""
    If dest <> -1 Then
      World.World(dest).Known = 1
      exp = World.World(dest).Explored
      
'      lcityt = World.World(dest).LCity.T
      frmGame.imgMoveRoad(i).Visible = World.World(dest).Road
      frmGame.imgMoveExp(i).Visible = Not (World.World(dest).Explored <> 0)
          
      
      Call CityPic(dest, i)
    
      frmGame.imgTer(i).Picture = frmGame.imgTerrain(World.World(dest).Terrain).Picture
      frmGame.imgTer(i).Visible = True
    
'      frmGame.cmdMove(i).Caption = "&" & i + 1 & ": " & frr & dest & bar
      frmGame.cmdMove(i).Caption = frr & dest & bar
      
      frmGame.cmdMove(i).Enabled = True
      
      frmGame.txMove(i).Text = RegionName(World.World(dest).Region) & vbCrLf
      
      If Not World.World(dest).LCity Is Nothing Then
        If World.World(dest).LCity.T = "City" Then
          frmGame.txMove(i).Text = frmGame.txMove(i).Text & "Cit: " & World.World(dest).LCity.Name & " (" & World.World(dest).LCity.Size & ")" & vbCrLf
        ElseIf World.World(dest).LCity.T = "Haunted House" Then
          frmGame.txMove(i).Text = frmGame.txMove(i).Text & "Haunted House" & vbCrLf
        End If
      Else
        frmGame.txMove(i).Text = frmGame.txMove(i).Text & "None" & vbCrLf
      End If
      
      frmGame.txMove(i).Text = frmGame.txMove(i).Text & "Area: " & dest & vbCrLf
      frmGame.txMove(i).Text = frmGame.txMove(i).Text & "Ter: " & TerName(World.World(dest).Terrain) & vbCrLf
      frmGame.txMove(i).Text = frmGame.txMove(i).Text & "Depth: " & World.World(dest).Depth & vbCrLf
    Else
      frmGame.imgCit(i).Visible = False
      frmGame.imgTer(i).Visible = False
      frmGame.cmdMove(i).Enabled = False
      frmGame.imgMoveExp(i).Visible = False
      frmGame.imgMoveRoad(i).Visible = False
      frmGame.cmdMove(i).Caption = "None"
      frmGame.txMove(i).Text = ""
    End If
  Next i
  
  frmGame.txCur.Text = ""
  frmGame.txCur.Text = frmGame.txCur.Text & RegionName(World.World(Loc).Region) & vbCrLf
  frmGame.txCur.Text = frmGame.txCur.Text & "Area: " & Loc & vbCrLf
  frmGame.txCur.Text = frmGame.txCur.Text & "Terrain: " & TerName(World.World(Loc).Terrain) & vbCrLf
  frmGame.txCur.Text = frmGame.txCur.Text & "Depth: " & World.World(Loc).Depth & vbCrLf & vbCrLf
  
  frmGame.txLoc.Text = Loc
  
  If Not World.World(Loc).LCity Is Nothing Then
    If World.World(Loc).LCity.T = "City" Then
      frmGame.cmdCity.Enabled = True
      frmGame.cmdCity.Caption = World.World(Loc).LCity.Button
      frmGame.txCur.Text = frmGame.txCur.Text & "The City of " & World.World(Loc).LCity.Name & "." & vbCrLf
      frmGame.txCur.Text = frmGame.txCur.Text & World.World(Loc).LCity.Desc & vbCrLf
    ElseIf World.World(Loc).LCity.T <> "None" Then
      frmGame.cmdCity.Enabled = True
      frmGame.cmdCity.Caption = World.World(Loc).LCity.Button
      frmGame.txCur.Text = frmGame.txCur.Text & World.World(Loc).LCity.T & vbCrLf
      frmGame.txCur.Text = frmGame.txCur.Text & World.World(Loc).LCity.Desc & vbCrLf
    End If
  Else
    frmGame.cmdCity.Enabled = False
    frmGame.cmdCity.Caption = ""
    frmGame.txCur.Text = frmGame.txCur.Text & "There is nothing of much interest here."
  End If
  
  frmGame.txGameDate = GameDate
  frmGame.txHP = char.Player.Dervs(D_CHP) & "/" & char.Player.Dervs(D_HTP)
  frmGame.txGold = char.Player.Gold
  
  World.World(Loc).Explored = 1
  World.World(Loc).Known = 1
  If World.World(Loc).Road = 1 Then
    frmGame.imgMoveRoad(5).Visible = True
  Else
    frmGame.imgMoveRoad(5).Visible = False
  End If
  Call CityPic(Loc, 5)
  
  frmGame.imgTer(5).Picture = frmGame.imgTerrain(World.World(Loc).Terrain).Picture
  
  frmGame.lstPeople.Clear
  For i = 0 To C_PEOPLE - 1
    If People(i).Loc = Loc Then
      frmGame.lstPeople.AddItem (People(i).Name)
      frmGame.lstPeople.ItemData(frmGame.lstPeople.NewIndex) = i
    End If
  Next i
  
  frmGame.txPoints = char.Player.Points
  
  If frmPlaces.Visible = True Then
    Call frmPlaces.RefreshPlaces
  End If
  
End Sub

Public Sub CityPic(i As Integer, pic)
  Dim LCity As String
  
  If World.World(i).LCity Is Nothing Then
    frmGame.imgCit(pic).Visible = False
    Exit Sub
  End If
  
  LCity = World.World(i).LCity.T
      
      frmGame.imgCit(pic).Visible = True
      If LCity = "City" Then
        frmGame.imgCit(pic).Picture = frmGame.imgCitCity.Picture
      ElseIf LCity = "Crossroad" Then
        frmGame.imgCit(pic).Picture = frmGame.imgCitCross.Picture
      ElseIf LCity = "Slums" Then
        frmGame.imgCit(pic).Picture = frmGame.imgCitSlums.Picture
      ElseIf LCity = "Haunted House" Then
        frmGame.imgCit(pic).Picture = frmGame.imgCitHH.Picture
      ElseIf LCity <> "None" Then
        frmGame.imgCit(pic).Picture = frmGame.imgMoveExp(0).Picture
      Else
'        frmGame.imgCit(pic).Picture = LoadPicture()
        frmGame.imgCit(pic).Visible = False
      End If

End Sub

Public Sub froute(s As Integer, d As Integer, cur As Integer, cheat As Integer, Optional Wide As Integer = 0)
  Dim i As Integer
  For i = 0 To 4
    If World.World(s).Link(i) <> -1 Then
      If World.World(World.World(s).Link(i)).Explored = 1 Or World.World(s).Link(i) = d Or cheat = 1 Then
        If old(s) + 1 > C_RMAX - 1 Or (Wide <> 0 And old(s) + 1 > Wide) Then
          Exit Sub
        ElseIf old(s) + 1 < old(World.World(s).Link(i)) Then
          old(World.World(s).Link(i)) = old(s) + 1
          path(World.World(s).Link(i)) = s
          Call froute(World.World(s).Link(i), d, cur, cheat, Wide)
        ElseIf cheat = 1 Then
'          frmStart.pbGenerate.Value = s
        End If
      End If
'    Else
'      Exit Sub
    End If
  Next i
End Sub

Public Function CalcRoute(dest As String, Optional cheat As Integer = 0, Optional Wide As Integer = 0) As String
  Dim d As Integer
  d = Val(dest)
  If d > -1 And d < C_LOCS Then
    Dim s As Integer
    Dim i As Integer
    s = Loc
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
    Wend
    
    CalcRoute = ""
    For i = 1 To C_RMAX - 1
      If route(i) <> -1 Then
        CalcRoute = CalcRoute & " > "
        If World.World(route(i)).Explored = 0 Then
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

Public Function NextRoute() As Integer
  Dim dest As Integer
  Dim i As Integer
  
  dest = curroute(1)
  
'  dest = Left(frmGame.txShowRoute, Len(frmGame.txShowRoute) - InStr(1, frmGame.txShowRoute, ">", vbBinaryCompare) + 1)
  frmGame.txShowRoute = Right(frmGame.txShowRoute, Len(frmGame.txShowRoute) - 2)
  If InStr(1, frmGame.txShowRoute, ">", vbTextCompare) <> 0 Then
    frmGame.txShowRoute = Right(frmGame.txShowRoute, Len(frmGame.txShowRoute) - InStr(1, frmGame.txShowRoute, ">", vbTextCompare) + 2)
  Else
    frmGame.txShowRoute = ""
  End If
  For i = 1 To C_RMAX - 1
    curroute(i - 1) = curroute(i)
    If curroute(i) = -1 Then Exit For
  Next i
  NextRoute = dest
End Function

Public Sub MoveTo(T As Integer)
  frmGame.AddEvent ("Moved from " & Loc & " to " & T)
  Loc = T
  If World.World(Loc).Explored = 0 Then frmGame.AddEvent ("Explored " & Loc)

  PassTime
  
  Encounter
End Sub


