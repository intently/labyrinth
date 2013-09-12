VERSION 5.00
Begin VB.Form frmRad 
   BackColor       =   &H00000000&
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Radial Map"
   ClientHeight    =   8805
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   10740
   KeyPreview      =   -1  'True
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   ScaleHeight     =   8805
   ScaleWidth      =   10740
   StartUpPosition =   2  'CenterScreen
   Begin VB.CommandButton cmdZoomIn 
      Caption         =   "Zoom &In"
      Height          =   525
      Left            =   90
      TabIndex        =   1
      Top             =   8220
      Width           =   1245
   End
   Begin VB.CommandButton cmdZoomOut 
      Caption         =   "Zoom &Out"
      Height          =   525
      Left            =   1410
      TabIndex        =   0
      Top             =   8220
      Width           =   1245
   End
   Begin VB.Label lbALL 
      Caption         =   "Label1"
      Height          =   255
      Left            =   4110
      TabIndex        =   4
      Top             =   8460
      Width           =   1335
   End
   Begin VB.Label lbZones 
      Caption         =   "Label1"
      Height          =   255
      Left            =   2700
      TabIndex        =   3
      Top             =   8460
      Width           =   1335
   End
   Begin VB.Label lbZoom 
      Caption         =   "Label1"
      Height          =   255
      Left            =   90
      TabIndex        =   2
      Top             =   7920
      Width           =   1215
   End
End
Attribute VB_Name = "frmRad"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Private Const MaxWide As Integer = 20
Private Wide As Integer
Private Spread As Double
Private ALL As Double
Private VisAreas As Integer
Private links As Integer

Private Sub cmdZoomIn_Click()
  If Wide > 2 Then
    Wide = Wide - 1
  End If
  Spread = 9000 / (2 * Wide - 1)
  DrawMap
End Sub

Private Sub cmdZoomOut_Click()
  If Wide < MaxWide Then
    Wide = Wide + 1
  End If
  Spread = 9000 / (2 * Wide - 1)
  DrawMap
End Sub

Private Sub Form_Click()
  DrawMap
End Sub

Private Sub Form_GotFocus()
  DrawMap
End Sub

Private Sub Form_Load()
'  DrawMap
  Wide = frmGame.Wide
  Spread = 9000 / (2 * Wide - 1)
End Sub

Public Sub DrawMap()
  Dim i As Integer
  Dim j As Integer
  Dim xx As Double
  Dim yy As Double
  Dim rr As Double
  Dim aa As Double
  Dim source As Location
  Dim dest As Location
  Dim lastlevel As Integer
  Dim lastdepth As Integer
  Dim lloc As Integer
  Dim Color As Long
  Dim onroute(0 To C_LOCS - 1) As Integer
  Dim Count(0 To MaxWide - 1) As Integer
  Dim Used(0 To C_LOCS - 1) As Integer 'MaxWide - 1) As long
  Dim kids(0 To C_LOCS - 1) As Integer
  Dim dep, dep2, depdif As Integer
  
  Dim Pi As Double
  
  Pi = 3.14159265358979
  links = 0
  ALL = 0
  VisAreas = 0
  frmRad.Width = 9200 '(2 * Wide - 1) * Spread + 200
  frmRad.Height = 9200 '(2 * Wide - 1) * Spread + 200
  lbZoom.Caption = "Zoom Factor: " & Wide
  frmRad.Cls
  
  xx = 0
  yy = 0
  lastlevel = 0
  lloc = Loc
  
  Call CalcRoute(Str(lloc), 1, Wide - 1) ' Str(lloc)
  
  For i = 0 To C_LOCS - 1
    If old(i) < Wide Then
      Count(old(i)) = Count(old(i)) + 1
    End If
    If path(i) <> -1 Then
      kids(path(i)) = kids(path(i)) + 1
    End If
    
    World.World(i).xx = 0
    World.World(i).yy = 0
    World.World(i).aa = 0
    World.World(i).rr = 0
    
    If i < C_RMAX Then
      If curroute(i) <> -1 Then
        onroute(curroute(i)) = 1
      End If
    End If
  Next i
  
  ' calculate radial positions
  For i = 0 To C_LOCS - 1
    If old(i) <> C_LOCS Then
      Dim avail As Double
      
      If path(i) <> -1 Then
'        avail = 2 * Pi * kids(path(i)) / (Count(old(i)) + Count(old(i) - 1))
        avail = 2 * Pi / (Count(old(i) - 1))
        If old(i) > 1 Then
          aa = ((avail / (kids(path(i)) + 1)) * (Used(path(i)) + 1)) + World.World(path(i)).aa - (avail / 2)
        Else
          aa = ((avail / (kids(path(i)))) * Used(path(i))) + World.World(path(i)).aa
        End If
        Used(path(i)) = Used(path(i)) + 1
      Else
        avail = 2 * Pi
        aa = 0
      End If
      rr = old(i) * Spread
      xx = ((frmRad.Width / 2)) + rr * Cos(aa)
      yy = ((frmRad.Height / 2) - 150) + rr * Sin(aa)
      World.World(i).xx = xx
      World.World(i).yy = yy
      World.World(i).aa = aa
      World.World(i).rr = rr
     
'      aa = (2# * CDbl(Used(old(i))) * Pi) / CDbl(Count(old(i))) - (Pi / CDbl(2)) '- (CDbl(old(i) - 1) * Pi / CDbl(Wide))
'      rr = old(i) * Spread
'      xx = ((frmRad.Width / 2)) + rr * Cos(aa)
'      yy = ((frmRad.Height / 2) - 150) + rr * Sin(aa)
'      World.World(i).xx = xx
'      World.World(i).yy = yy
'      World.World(i).aa = aa
'      World.World(i).rr = rr
'      Used(old(i)) = Used(old(i)) + 1
    End If
  Next i
  
  For i = 0 To C_LOCS - 1
    If old(i) <> C_LOCS Then
      For j = 0 To 4
        If World.World(i).Link(j) <> -1 Then
' "<>" below was "<", check if paths to lesser unexplored sectors are drawn
          If i <> World.World(i).Link(j) And old(World.World(i).Link(j)) <> C_LOCS Then 'And Abs(World.World(i).Level - World.World(lloc).Level) <> 0 Then
            Set source = World.World(i)
            Set dest = World.World(World.World(i).Link(j))
            If source.Explored = 1 Or frmGame.ckCombat.Value = 1 Then
              If dest.Explored = 1 Then
                frmRad.DrawStyle = 0
              Else
                frmRad.DrawStyle = 2
              End If
              ALL = ALL + Sqr((source.xx - dest.xx) ^ 2 + (source.yy - dest.yy) ^ 2)
              links = links + 1
              If onroute(i) = 1 And onroute(World.World(i).Link(j)) = 1 Then
                Line (source.xx, source.yy)-(dest.xx, dest.yy), RGB(255, 255, 255)
              ElseIf source.Road = 1 And dest.Road = 1 Then
                Line (source.xx, source.yy)-(dest.xx, dest.yy), RGB(140, 140, 140)
              Else
                Line (source.xx, source.yy)-(dest.xx, dest.yy), RGB(140, 110, 0)
              End If
            End If
            
          End If
        End If
      Next j
    End If
  Next i
  
  frmRad.DrawStyle = 0
  
  VisAreas = 0
  
  For j = 0 To 4
    If World.World(lloc).Link(j) <> -1 Then
      If old(World.World(lloc).Link(j)) <> C_LOCS Then
        Set source = World.World(lloc)
        Set dest = World.World(World.World(lloc).Link(j))
        Circle (dest.xx, dest.yy), 100, RGB(255, 120, 0)
        ForeColor = RGB(255, 255, 255)
        CurrentX = dest.xx - 150
        CurrentY = dest.yy - 300
        Print World.World(lloc).Link(j)
      End If
    End If
  Next j
  
  For i = 0 To C_LOCS - 1
    If old(i) <> C_LOCS Then
      
      dep = World.World(lloc).Depth
      dep2 = World.World(i).Depth
      depdif = dep2 - dep
      xx = World.World(i).xx
      yy = World.World(i).yy
      
'      If World.World(i).Explored = 0 And World.World(i).Known = 0 Then
'        Color = RGB(80, 80, 80)
'      Else
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
      If World.World(i).Explored = 1 Or frmGame.ckCombat = 1 Then
        ForeColor = Color
        CurrentX = xx - 150
        CurrentY = yy - 300
        Print i
      End If
      
'      If World.World(i).Explored = 0 Then
'        Circle (xx, yy), 30, RGB(140, 140, 140)
'      End If
      If i = lloc Then
        Circle (xx, yy), 100, RGB(255, 255, 255)
      End If
      If Not World.World(i).LCity Is Nothing Then
        If World.World(i).LCity.T = "City" Then
          Line (xx - 10, yy - 10)-(xx + 10, yy + 10), RGB(255, 255, 255), BF
        End If
      End If
      VisAreas = VisAreas + 1
    End If
  Next i
  lbZones.Caption = "Visible Areas: " & VisAreas
  lbALL.Caption = "ALL: " & Round(ALL / Max(links, 1), 0)
End Sub

Private Sub Form_Unload(cancel As Integer)
  frmGame.Wide = Wide
End Sub

Private Sub Form_KeyPress(keyascii As Integer)
  If keyascii = 27 Then
    Unload Me
  ElseIf keyascii = Asc("o") Or keyascii = Asc("O") Then
    Call cmdZoomOut_Click
  ElseIf keyascii = Asc("i") Or keyascii = Asc("I") Then
    Call cmdZoomIn_Click
  End If
End Sub

