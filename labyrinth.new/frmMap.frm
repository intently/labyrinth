VERSION 5.00
Begin VB.Form frmMap 
   BackColor       =   &H00000000&
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Map"
   ClientHeight    =   8730
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   10755
   KeyPreview      =   -1  'True
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   ScaleHeight     =   8730
   ScaleWidth      =   10755
   StartUpPosition =   2  'CenterScreen
End
Attribute VB_Name = "frmMap"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Private Sub Form_Click()
  DrawMap
End Sub

Private Sub Form_GotFocus()
  DrawMap
End Sub

Private Sub Form_Load()
'  DrawMap
End Sub

Public Sub DrawMap()
  Dim i As Integer
  Dim j As Integer
  Dim xx As Integer
  Dim yy As Integer
  Dim source As Location
  Dim dest As Location
  Dim lastlevel As Integer
  Dim lastdepth As Integer
  Dim lloc As Integer
  Dim Color As Integer
  Dim Wide As Integer
  Dim baselevel As Integer
  Dim dep, dep2, depdif As Integer
  
  xx = 0
  yy = 0
  lastlevel = 0
  lloc = Loc
  Wide = 10
  
  For i = 0 To C_LOCS - 1
'    If Abs(World.World(i).Depth - World.World(lloc).Depth) <= 2 Then
      baselevel = World.World(i).level - World.World(lloc).level
      If World.World(i).level = lastlevel Then
        yy = yy + 300
      Else
        yy = 300
        lastdepth = World.World(i).level
      End If
      xx = ((baselevel) * CLng(500)) + 5400 '+ ((i Mod 50) * 10)
      lastlevel = World.World(i).level
      World.World(i).xx = xx
      World.World(i).yy = yy
'    End If
  Next i
  
  For i = 0 To C_LOCS - 1
    If Abs(World.World(i).level - World.World(lloc).level) <= Wide Then
      
      For j = 0 To 4
        If World.World(i).Link(j) <> -1 Then
          If i < World.World(i).Link(j) And Abs(World.World(i).level - World.World(lloc).level) <= Wide Then 'And Abs(World.World(i).Level - World.World(lloc).Level) <> 0 Then
            Set source = World.World(i)
            Set dest = World.World(World.World(i).Link(j))
'            If i = lloc Then
'              Line (source.xx, source.yy)-(dest.xx, dest.yy), RGB(200, 120, 0)
'            Else
              Line (source.xx, source.yy)-(dest.xx, dest.yy), RGB(120, 120, 0)
'            End If
          End If
        End If
      Next j
    End If
  Next i
  
  For j = 0 To 4
    If World.World(lloc).Link(j) <> -1 Then
      Set source = World.World(lloc)
      Set dest = World.World(World.World(lloc).Link(j))
      Line (source.xx, source.yy)-(dest.xx, dest.yy), RGB(255, 120, 0)
      Circle (dest.xx, dest.yy), 100, RGB(255, 120, 0)
    End If
  Next j
  
  For i = 0 To C_LOCS - 1
    If Abs(World.World(i).level - World.World(lloc).level) <= Wide Then
      
      dep = World.World(lloc).Depth
      dep2 = World.World(i).Depth
      depdif = dep2 - dep
      xx = World.World(i).xx
      yy = World.World(i).yy
      
      If World.World(i).Terrain = T_DES Then
        Color = RGB(255, 255, 30)
      ElseIf World.World(i).Terrain = T_FOR Then
        Color = RGB(0, 180, 0)
      ElseIf World.World(i).Terrain = T_HIL Then
        Color = RGB(160, 160, 0)
      ElseIf World.World(i).Terrain = T_JUN Then
        Color = RGB(180, 80, 180)
      ElseIf World.World(i).Terrain = T_MTN Then
        Color = RGB(180, 50, 0)
      ElseIf World.World(i).Terrain = T_PLN Then
        Color = RGB(0, 230, 0)
      ElseIf World.World(i).Terrain = T_SWP Then
        Color = RGB(0, 120, 120)
      ElseIf World.World(i).Terrain = T_TUN Then
        Color = RGB(200, 200, 200)
      Else
        Color = RGB(255, 0, 0)
      End If
      
'      Red = depdif * 50 + 125
'      Blue = -depdif * 50 + 125
'      Green = (2 - Abs(depdif)) * 100 + 25
      Circle (xx, yy), 40, Color
      If i = lloc Then
        Circle (xx, yy), 100, RGB(255, 255, 255)
      End If
      If World.World(i).LCity.T = "City" Then
        Line (xx - 10, yy - 10)-(xx + 10, yy + 10), RGB(255, 255, 255), BF
      End If
    End If
  Next i
  
End Sub
