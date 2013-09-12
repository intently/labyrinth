Attribute VB_Name = "texts"
Option Explicit
Public Function CityName(Size As Integer) As String
  If Size = 3 Then
    CityName = "Centris"
  Else
    CityName = CityNameFirst(Size) & CityNameLast(Size)
  End If
End Function

Public Function CityNameFirst(Optional Size As Integer = 0) As String
  Dim r As Integer
  r = Int(Rnd * 78)
  
  Select Case r
    Case 0
      CityNameFirst = "Aerin"
    Case 1
      CityNameFirst = "Ardas"
    Case 2
      CityNameFirst = "Authindon"
    Case 3
      CityNameFirst = "Bilar"
    Case 4
      CityNameFirst = "Blansdale"
    Case 5
      CityNameFirst = "Borno"
    Case 6
      CityNameFirst = "Caltris"
    Case 7
      CityNameFirst = "Cedonia"
    Case 8
      CityNameFirst = "Cygor"
    Case 9
      CityNameFirst = "Dans"
    Case 10
      CityNameFirst = "Drasten"
    Case 11
      CityNameFirst = "Duvelo"
    Case 12
      CityNameFirst = "Edner"
    Case 13
      CityNameFirst = "Eggars"
    Case 14
      CityNameFirst = "Erenton"
    Case 15
      CityNameFirst = "Fidno"
    Case 16
      CityNameFirst = "Firedane"
    Case 17
      CityNameFirst = "Furmen"
    Case 18
      CityNameFirst = "Gaster"
    Case 19
      CityNameFirst = "Glaen"
    Case 20
      CityNameFirst = "Gorrido"
    Case 21
      CityNameFirst = "Harvish"
    Case 22
      CityNameFirst = "Harridon"
    Case 23
      CityNameFirst = "Helan"
    Case 24
      CityNameFirst = "Indaneo"
    Case 25
      CityNameFirst = "Irzegan"
    Case 26
      CityNameFirst = "Ilton"
    Case 27
      CityNameFirst = "Julmine"
    Case 28
      CityNameFirst = "Josphet"
    Case 29
      CityNameFirst = "Jart"
    Case 30
      CityNameFirst = "Kardik"
    Case 31
      CityNameFirst = "Killton"
    Case 32
      CityNameFirst = "Kunzanis"
    Case 33
      CityNameFirst = "Laillien"
    Case 34
      CityNameFirst = "Lephros"
    Case 35
      CityNameFirst = "Lund"
    Case 36
      CityNameFirst = "Mako"
    Case 37
      CityNameFirst = "Meddin"
    Case 38
      CityNameFirst = "Murtaugh"
    Case 39
      CityNameFirst = "Nengo"
    Case 40
      CityNameFirst = "Nibden"
    Case 41
      CityNameFirst = "Nollia"
    Case 42
      CityNameFirst = "Oaceia"
    Case 43
      CityNameFirst = "Oro"
    Case 44
      CityNameFirst = "Osterborne"
    Case 45
      CityNameFirst = "Pens"
    Case 46
      CityNameFirst = "Pinter"
    Case 47
      CityNameFirst = "Prad"
    Case 48
      CityNameFirst = "Quadic"
    Case 49
      CityNameFirst = "Qordia"
    Case 50
      CityNameFirst = "Qzans"
    Case 51
      CityNameFirst = "Robin"
    Case 52
      CityNameFirst = "Regaloh"
    Case 53
      CityNameFirst = "Riddick"
    Case 54
      CityNameFirst = "Salazar"
    Case 55
      CityNameFirst = "Sitaneo"
    Case 56
      CityNameFirst = "Sundaniol"
    Case 57
      CityNameFirst = "Tebason"
    Case 58
      CityNameFirst = "Teran"
    Case 59
      CityNameFirst = "Terro"
    Case 60
      CityNameFirst = "Ulistea"
    Case 61
      CityNameFirst = "Ulos"
    Case 62
      CityNameFirst = "Utengo"
    Case 63
      CityNameFirst = "Vasto"
    Case 64
      CityNameFirst = "Vemmenon"
    Case 65
      CityNameFirst = "Verdis"
    Case 66
      CityNameFirst = "Walis"
    Case 67
      CityNameFirst = "Wadenho"
    Case 68
      CityNameFirst = "Worstic"
    Case 69
      CityNameFirst = "Xejara"
    Case 70
      CityNameFirst = "Xixtini"
    Case 71
      CityNameFirst = "Xudon"
    Case 72
      CityNameFirst = "Yaltan"
    Case 73
      CityNameFirst = "Yeen"
    Case 74
      CityNameFirst = "Yorikiri"
    Case 75
      CityNameFirst = "Zelno"
    Case 76
      CityNameFirst = "Zoristar"
    Case 77
      CityNameFirst = "Zzyzx"
  End Select
    
End Function

Public Function CityNameLast(Size As Integer) As String
  Dim r As Integer
  r = Int(Rnd * 15)
  
  Select Case r
    Case 0
      CityNameLast = "sville"
    Case 1
      CityNameLast = "sburg"
    Case 2
      CityNameLast = "'s Hill"
    Case 3
      CityNameLast = "onia"
    Case 4
      CityNameLast = "'s Bridge"
    Case 5
      CityNameLast = " Town"
    Case 6
      CityNameLast = " Keep"
    Case 7
      CityNameLast = "feld"
    Case 8
      CityNameLast = "shire"
    Case 9
      CityNameLast = "'s Cross"
    Case 10
      CityNameLast = "land"
    Case 11
      CityNameLast = "sford"
    Case 12
      CityNameLast = " County"
    Case 13
      CityNameLast = ""
    Case 14
      CityNameLast = "ston"
  End Select
End Function


Public Function CityDesc(Size As Integer) As String

  If Size = 0 Then
    CityDesc = "A tiny, inconsequential village."
  ElseIf Size = 1 Then
    CityDesc = "A medium-sized town."
  ElseIf Size = 2 Then
    CityDesc = "A bustling city."
  End If

End Function

Public Function RegionName(r As Integer)
  RegionName = RegionNames(r)
End Function

Public Function UseEle(s As String, c As Integer) As String
  If Int(Rnd * 100) + 1 < c Then
    UseEle = s
  Else
    UseEle = ""
  End If
End Function
Public Function JustText(s As String) As String
  Dim temp As String
  temp = Right(s, Len(s) - 3)
'  temp = Left(temp, Len(temp) - InStr(1, temp, "[", vbTextCompare))
  JustText = temp
End Function

Public Function PadSpaces(s As String, n As Integer) As String
  Dim i As Integer
  
  PadSpaces = s
  If Len(s) < n Then
    For i = 1 To 10 - Len(s)
      PadSpaces = "_" & PadSpaces
    Next i
  End If
End Function

Public Sub NameRegions()
  Dim i As Integer
  Dim r As Integer
  
  r = Int(Rnd * 5)
  
  For i = 0 To UBound(RegionNames)
    If Val(RegionNames(i)) = T_DES Then
      If r = 0 Then
        RegionNames(i) = CityNameFirst & " Desert"
      ElseIf r = 1 Then
        RegionNames(i) = "Wastelands of " & CityNameFirst
      ElseIf r = 2 Then
        RegionNames(i) = CityNameFirst & " Dunes"
      ElseIf r = 3 Then
        RegionNames(i) = "Sands of " & CityNameFirst
      ElseIf r = 4 Then
        RegionNames(i) = CityNameFirst & " Desert"
      End If
    ElseIf Val(RegionNames(i)) = T_FOR Then
      If r = 0 Then
        RegionNames(i) = CityNameFirst & " Forest"
      ElseIf r = 1 Then
        RegionNames(i) = "Glade of " & CityNameFirst
      ElseIf r = 2 Then
        RegionNames(i) = CityNameFirst & " Woods"
      ElseIf r = 3 Then
        RegionNames(i) = "Forest of " & CityNameFirst
      ElseIf r = 4 Then
        RegionNames(i) = CityNameFirst & "'s Wood"
      End If
    ElseIf Val(RegionNames(i)) = T_HIL Then
      If r = 0 Then
        RegionNames(i) = CityNameFirst & " Hills"
      ElseIf r = 1 Then
        RegionNames(i) = "Slopes of " & CityNameFirst
      ElseIf r = 2 Then
        RegionNames(i) = CityNameFirst & " Downs"
      ElseIf r = 3 Then
        RegionNames(i) = "Hillsland of " & CityNameFirst
      ElseIf r = 4 Then
        RegionNames(i) = CityNameFirst & " Plateaus"
      End If
    ElseIf Val(RegionNames(i)) = T_JUN Then
      If r = 0 Then
        RegionNames(i) = CityNameFirst & " Jungle"
      ElseIf r = 1 Then
        RegionNames(i) = "Rainforest of " & CityNameFirst
      ElseIf r = 2 Then
        RegionNames(i) = CityNameFirst & " Deepwood"
      ElseIf r = 3 Then
        RegionNames(i) = "Jungle of " & CityNameFirst
      ElseIf r = 4 Then
        RegionNames(i) = CityNameFirst & " Rainforest"
      End If
    ElseIf Val(RegionNames(i)) = T_MTN Then
      If r = 0 Then
        RegionNames(i) = CityNameFirst & " Mountains"
      ElseIf r = 1 Then
        RegionNames(i) = "Mountains of " & CityNameFirst
      ElseIf r = 2 Then
        RegionNames(i) = CityNameFirst & " Highlands"
      ElseIf r = 3 Then
        RegionNames(i) = "High Passes of " & CityNameFirst
      ElseIf r = 4 Then
        RegionNames(i) = CityNameFirst & " Volcanoes"
      End If
    ElseIf Val(RegionNames(i)) = T_PLN Then
      If r = 0 Then
        RegionNames(i) = CityNameFirst & " Plains"
      ElseIf r = 1 Then
        RegionNames(i) = "Moors of " & CityNameFirst
      ElseIf r = 2 Then
        RegionNames(i) = CityNameFirst & " Meadows"
      ElseIf r = 3 Then
        RegionNames(i) = "Plains of " & CityNameFirst
      ElseIf r = 4 Then
        RegionNames(i) = CityNameFirst & " Grasslands"
      End If
    ElseIf Val(RegionNames(i)) = T_SWP Then
      If r = 0 Then
        RegionNames(i) = CityNameFirst & " Swamp"
      ElseIf r = 1 Then
        RegionNames(i) = "Swamp of " & CityNameFirst
      ElseIf r = 2 Then
        RegionNames(i) = CityNameFirst & " Bog"
      ElseIf r = 3 Then
        RegionNames(i) = "Pools of " & CityNameFirst
      ElseIf r = 4 Then
        RegionNames(i) = CityNameFirst & " Marsh"
      End If
    ElseIf Val(RegionNames(i)) = T_TUN Then
      If r = 0 Then
        RegionNames(i) = CityNameFirst & " Tundra"
      ElseIf r = 1 Then
        RegionNames(i) = "Icelands of " & CityNameFirst
      ElseIf r = 2 Then
        RegionNames(i) = CityNameFirst & " Snowfields"
      ElseIf r = 3 Then
        RegionNames(i) = "Tundra of " & CityNameFirst
      ElseIf r = 4 Then
        RegionNames(i) = CityNameFirst & " Frostlands"
      End If
    End If
  Next i
End Sub
