VERSION 5.00
Begin VB.Form frmGame 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Labyrinth"
   ClientHeight    =   7095
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   9015
   KeyPreview      =   -1  'True
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   ScaleHeight     =   7095
   ScaleWidth      =   9015
   StartUpPosition =   2  'CenterScreen
   Begin VB.Frame frLocation 
      Caption         =   "Current Location"
      Height          =   3255
      Left            =   0
      TabIndex        =   21
      Top             =   0
      Width           =   9015
      Begin VB.TextBox txPoints 
         Alignment       =   1  'Right Justify
         Height          =   285
         Left            =   7320
         TabIndex        =   40
         Text            =   "Text1"
         Top             =   2880
         Width           =   1575
      End
      Begin VB.ListBox lstPeople 
         Height          =   2400
         Left            =   7320
         TabIndex        =   37
         Top             =   240
         Width           =   1575
      End
      Begin VB.CommandButton cmdCity 
         Caption         =   "Enter"
         Height          =   375
         Left            =   3480
         TabIndex        =   32
         Top             =   2760
         Width           =   1575
      End
      Begin VB.TextBox txLoc 
         Alignment       =   1  'Right Justify
         Height          =   285
         Left            =   1200
         Locked          =   -1  'True
         TabIndex        =   27
         Text            =   "Text1"
         Top             =   2880
         Width           =   975
      End
      Begin VB.TextBox txGameDate 
         Alignment       =   1  'Right Justify
         Height          =   285
         Left            =   120
         Locked          =   -1  'True
         TabIndex        =   26
         Text            =   "Text1"
         Top             =   2880
         Width           =   975
      End
      Begin VB.TextBox txHP 
         Alignment       =   1  'Right Justify
         Height          =   285
         Left            =   5160
         Locked          =   -1  'True
         TabIndex        =   25
         Text            =   "Text1"
         Top             =   2880
         Width           =   975
      End
      Begin VB.TextBox txGold 
         Alignment       =   1  'Right Justify
         Height          =   285
         Left            =   6240
         Locked          =   -1  'True
         TabIndex        =   24
         Text            =   "Text1"
         Top             =   2880
         Width           =   975
      End
      Begin VB.ListBox lstEvents 
         Height          =   2400
         Left            =   3720
         TabIndex        =   23
         Top             =   240
         Width           =   3495
      End
      Begin VB.TextBox txCur 
         Height          =   2415
         Left            =   120
         Locked          =   -1  'True
         MultiLine       =   -1  'True
         TabIndex        =   22
         Text            =   "frmGame.frx":0000
         Top             =   240
         Width           =   3495
      End
      Begin VB.Label Label1 
         Caption         =   "Points"
         Height          =   255
         Left            =   7320
         TabIndex        =   39
         Top             =   2640
         Width           =   615
      End
      Begin VB.Label lblLoc 
         Caption         =   "Area"
         Height          =   255
         Left            =   1200
         TabIndex        =   31
         Top             =   2640
         Width           =   495
      End
      Begin VB.Label lblDate 
         Caption         =   "Date"
         Height          =   255
         Left            =   120
         TabIndex        =   30
         Top             =   2640
         Width           =   615
      End
      Begin VB.Label lblHP 
         Caption         =   "Hit Points"
         Height          =   255
         Left            =   5160
         TabIndex        =   29
         Top             =   2640
         Width           =   735
      End
      Begin VB.Label lblGold 
         Caption         =   "Gold Coins"
         Height          =   255
         Left            =   6240
         TabIndex        =   28
         Top             =   2640
         Width           =   855
      End
      Begin VB.Image imgTer 
         BorderStyle     =   1  'Fixed Single
         Height          =   255
         Index           =   5
         Left            =   3120
         Top             =   2880
         Width           =   255
      End
      Begin VB.Image imgCit 
         BorderStyle     =   1  'Fixed Single
         Height          =   255
         Index           =   5
         Left            =   2880
         Top             =   2880
         Width           =   255
      End
      Begin VB.Image imgMoveRoad 
         BorderStyle     =   1  'Fixed Single
         Height          =   255
         Index           =   5
         Left            =   2280
         Picture         =   "frmGame.frx":0006
         Top             =   2880
         Width           =   255
      End
   End
   Begin VB.Frame frMove 
      Height          =   3015
      Left            =   0
      TabIndex        =   0
      Top             =   3240
      Width           =   7335
      Begin VB.CommandButton cmdMove 
         Caption         =   "Command1"
         Height          =   495
         Index           =   3
         Left            =   4440
         TabIndex        =   16
         Top             =   240
         Width           =   1335
      End
      Begin VB.TextBox txShowRoute 
         Height          =   285
         Left            =   3000
         Locked          =   -1  'True
         TabIndex        =   15
         Top             =   2640
         Width           =   4215
      End
      Begin VB.TextBox txRoute 
         Height          =   285
         Left            =   1560
         TabIndex        =   14
         Top             =   2640
         Width           =   1335
      End
      Begin VB.CommandButton cmdRoute 
         Caption         =   "Route"
         Height          =   255
         Left            =   120
         TabIndex        =   13
         Top             =   2640
         Width           =   1335
      End
      Begin VB.TextBox txMove 
         Height          =   1575
         Index           =   4
         Left            =   5880
         Locked          =   -1  'True
         MultiLine       =   -1  'True
         TabIndex        =   9
         Text            =   "frmGame.frx":036C
         Top             =   960
         Width           =   1335
      End
      Begin VB.TextBox txMove 
         Height          =   1575
         Index           =   3
         Left            =   4440
         Locked          =   -1  'True
         MultiLine       =   -1  'True
         TabIndex        =   8
         Text            =   "frmGame.frx":0372
         Top             =   960
         Width           =   1335
      End
      Begin VB.TextBox txMove 
         Height          =   1575
         Index           =   2
         Left            =   3000
         Locked          =   -1  'True
         MultiLine       =   -1  'True
         TabIndex        =   7
         Text            =   "frmGame.frx":0378
         Top             =   960
         Width           =   1335
      End
      Begin VB.TextBox txMove 
         Height          =   1575
         Index           =   1
         Left            =   1560
         Locked          =   -1  'True
         MultiLine       =   -1  'True
         TabIndex        =   6
         Text            =   "frmGame.frx":037E
         Top             =   960
         Width           =   1335
      End
      Begin VB.TextBox txMove 
         Height          =   1575
         Index           =   0
         Left            =   120
         Locked          =   -1  'True
         MultiLine       =   -1  'True
         TabIndex        =   5
         Text            =   "frmGame.frx":0384
         Top             =   960
         Width           =   1335
      End
      Begin VB.CommandButton cmdMove 
         Caption         =   "Command1"
         Height          =   495
         Index           =   4
         Left            =   5880
         TabIndex        =   4
         Top             =   240
         Width           =   1335
      End
      Begin VB.CommandButton cmdMove 
         Caption         =   "Command1"
         Height          =   495
         Index           =   2
         Left            =   3000
         TabIndex        =   3
         Top             =   240
         Width           =   1335
      End
      Begin VB.CommandButton cmdMove 
         Caption         =   "Command1"
         Height          =   495
         Index           =   1
         Left            =   1560
         TabIndex        =   2
         Top             =   240
         Width           =   1335
      End
      Begin VB.CommandButton cmdMove 
         Caption         =   "Command1"
         Height          =   495
         Index           =   0
         Left            =   120
         TabIndex        =   1
         Top             =   240
         Width           =   1335
      End
      Begin VB.Image imgCit 
         BorderStyle     =   1  'Fixed Single
         Height          =   255
         Index           =   4
         Left            =   6720
         Top             =   720
         Width           =   255
      End
      Begin VB.Image imgCit 
         BorderStyle     =   1  'Fixed Single
         Height          =   255
         Index           =   3
         Left            =   5280
         Top             =   720
         Width           =   255
      End
      Begin VB.Image imgCit 
         BorderStyle     =   1  'Fixed Single
         Height          =   255
         Index           =   2
         Left            =   3840
         Top             =   720
         Width           =   255
      End
      Begin VB.Image imgCit 
         BorderStyle     =   1  'Fixed Single
         Height          =   255
         Index           =   1
         Left            =   2400
         Top             =   720
         Width           =   255
      End
      Begin VB.Image imgCit 
         BorderStyle     =   1  'Fixed Single
         Height          =   255
         Index           =   0
         Left            =   960
         Top             =   720
         Width           =   255
      End
      Begin VB.Image imgTer 
         BorderStyle     =   1  'Fixed Single
         Height          =   255
         Index           =   4
         Left            =   6960
         Top             =   720
         Width           =   255
      End
      Begin VB.Image imgTer 
         BorderStyle     =   1  'Fixed Single
         Height          =   255
         Index           =   3
         Left            =   5520
         Top             =   720
         Width           =   255
      End
      Begin VB.Image imgTer 
         BorderStyle     =   1  'Fixed Single
         Height          =   255
         Index           =   2
         Left            =   4080
         Top             =   720
         Width           =   255
      End
      Begin VB.Image imgTer 
         BorderStyle     =   1  'Fixed Single
         Height          =   255
         Index           =   1
         Left            =   2640
         Top             =   720
         Width           =   255
      End
      Begin VB.Image imgTer 
         BorderStyle     =   1  'Fixed Single
         Height          =   255
         Index           =   0
         Left            =   1200
         Top             =   720
         Width           =   255
      End
      Begin VB.Image imgMoveRoad 
         BorderStyle     =   1  'Fixed Single
         Height          =   255
         Index           =   4
         Left            =   6120
         Picture         =   "frmGame.frx":038A
         Top             =   720
         Width           =   255
      End
      Begin VB.Image imgMoveRoad 
         BorderStyle     =   1  'Fixed Single
         Height          =   255
         Index           =   3
         Left            =   4680
         Picture         =   "frmGame.frx":06F0
         Top             =   720
         Width           =   255
      End
      Begin VB.Image imgMoveRoad 
         BorderStyle     =   1  'Fixed Single
         Height          =   255
         Index           =   2
         Left            =   3240
         Picture         =   "frmGame.frx":0A56
         Top             =   720
         Width           =   255
      End
      Begin VB.Image imgMoveRoad 
         BorderStyle     =   1  'Fixed Single
         Height          =   255
         Index           =   1
         Left            =   1800
         Picture         =   "frmGame.frx":0DBC
         Top             =   720
         Width           =   255
      End
      Begin VB.Image imgMoveRoad 
         BorderStyle     =   1  'Fixed Single
         Height          =   255
         Index           =   0
         Left            =   360
         Picture         =   "frmGame.frx":1122
         Top             =   720
         Width           =   255
      End
      Begin VB.Image imgMoveExp 
         BorderStyle     =   1  'Fixed Single
         Height          =   255
         Index           =   4
         Left            =   5880
         Picture         =   "frmGame.frx":1488
         Stretch         =   -1  'True
         Top             =   720
         Width           =   255
      End
      Begin VB.Image imgMoveExp 
         BorderStyle     =   1  'Fixed Single
         Height          =   255
         Index           =   3
         Left            =   4440
         Picture         =   "frmGame.frx":17F3
         Stretch         =   -1  'True
         Top             =   720
         Width           =   255
      End
      Begin VB.Image imgMoveExp 
         BorderStyle     =   1  'Fixed Single
         Height          =   255
         Index           =   2
         Left            =   3000
         Picture         =   "frmGame.frx":1B5E
         Stretch         =   -1  'True
         Top             =   720
         Width           =   255
      End
      Begin VB.Image imgMoveExp 
         BorderStyle     =   1  'Fixed Single
         Height          =   255
         Index           =   1
         Left            =   1560
         Picture         =   "frmGame.frx":1EC9
         Stretch         =   -1  'True
         Top             =   720
         Width           =   255
      End
      Begin VB.Image imgMoveExp 
         BorderStyle     =   1  'Fixed Single
         Height          =   255
         Index           =   0
         Left            =   120
         Picture         =   "frmGame.frx":2234
         Stretch         =   -1  'True
         Top             =   720
         Width           =   255
      End
   End
   Begin VB.Frame frDisk 
      Caption         =   "Disk Options"
      Height          =   855
      Left            =   0
      TabIndex        =   11
      Top             =   6240
      Width           =   7335
      Begin VB.CommandButton cmdMap 
         Caption         =   "Flat Map"
         Height          =   495
         Left            =   2760
         TabIndex        =   41
         Top             =   240
         Width           =   1215
      End
      Begin VB.CommandButton cmdRad 
         Caption         =   "Radial &Map"
         Height          =   495
         Left            =   1440
         TabIndex        =   36
         Top             =   240
         Width           =   1215
      End
      Begin VB.CheckBox ckCombat 
         Caption         =   "No Combat"
         Height          =   495
         Left            =   4680
         TabIndex        =   35
         Top             =   240
         Width           =   1215
      End
      Begin VB.CommandButton cmdCheat 
         Caption         =   "C&heat"
         Height          =   495
         Left            =   6000
         TabIndex        =   34
         Top             =   240
         Width           =   1215
      End
      Begin VB.CommandButton cmdQuit 
         Caption         =   "&Quit"
         Height          =   495
         Left            =   120
         TabIndex        =   19
         Top             =   240
         Width           =   1215
      End
   End
   Begin VB.Frame frControls 
      Caption         =   "Controls"
      Height          =   3855
      Left            =   7440
      TabIndex        =   10
      Top             =   3240
      Width           =   1575
      Begin VB.CommandButton cmdStats 
         Caption         =   "S&tats"
         Height          =   495
         Left            =   120
         TabIndex        =   38
         Top             =   3240
         Width           =   1335
      End
      Begin VB.CommandButton cmdMagic 
         Caption         =   "&Spells"
         Height          =   495
         Left            =   120
         TabIndex        =   33
         Top             =   1440
         Width           =   1335
      End
      Begin VB.CommandButton cmdPlaces 
         Caption         =   "&Places"
         Height          =   495
         Left            =   120
         TabIndex        =   20
         Top             =   2040
         Width           =   1335
      End
      Begin VB.CommandButton cmdRest 
         Caption         =   "&Rest"
         Height          =   495
         Left            =   120
         TabIndex        =   18
         Top             =   2640
         Width           =   1335
      End
      Begin VB.CommandButton cmdInven 
         Caption         =   "&Inventory"
         Height          =   495
         Left            =   120
         TabIndex        =   17
         Top             =   840
         Width           =   1335
      End
      Begin VB.CommandButton cmdChar 
         Caption         =   "&Character"
         Height          =   495
         Left            =   120
         TabIndex        =   12
         Top             =   240
         Width           =   1335
      End
   End
   Begin VB.Image imgCitHH 
      BorderStyle     =   1  'Fixed Single
      Height          =   255
      Left            =   720
      Picture         =   "frmGame.frx":259F
      Top             =   0
      Width           =   255
   End
   Begin VB.Image imgCitSlums 
      BorderStyle     =   1  'Fixed Single
      Height          =   255
      Left            =   0
      Picture         =   "frmGame.frx":2946
      Top             =   0
      Visible         =   0   'False
      Width           =   255
   End
   Begin VB.Image imgCitCross 
      BorderStyle     =   1  'Fixed Single
      Height          =   255
      Left            =   240
      Picture         =   "frmGame.frx":2CB5
      Top             =   0
      Visible         =   0   'False
      Width           =   255
   End
   Begin VB.Image imgCitCity 
      BorderStyle     =   1  'Fixed Single
      Height          =   255
      Left            =   480
      Picture         =   "frmGame.frx":3023
      Top             =   0
      Visible         =   0   'False
      Width           =   255
   End
   Begin VB.Image imgTerrain 
      BorderStyle     =   1  'Fixed Single
      Height          =   255
      Index           =   6
      Left            =   4080
      Picture         =   "frmGame.frx":3397
      Top             =   0
      Visible         =   0   'False
      Width           =   255
   End
   Begin VB.Image imgTerrain 
      BorderStyle     =   1  'Fixed Single
      Height          =   255
      Index           =   5
      Left            =   3840
      Picture         =   "frmGame.frx":3707
      Top             =   0
      Visible         =   0   'False
      Width           =   255
   End
   Begin VB.Image imgTerrain 
      BorderStyle     =   1  'Fixed Single
      Height          =   255
      Index           =   7
      Left            =   4320
      Picture         =   "frmGame.frx":3A6B
      Top             =   0
      Visible         =   0   'False
      Width           =   255
   End
   Begin VB.Image imgTerrain 
      BorderStyle     =   1  'Fixed Single
      Height          =   255
      Index           =   3
      Left            =   3360
      Picture         =   "frmGame.frx":3DC8
      Top             =   0
      Visible         =   0   'False
      Width           =   255
   End
   Begin VB.Image imgTerrain 
      BorderStyle     =   1  'Fixed Single
      Height          =   255
      Index           =   2
      Left            =   3120
      Picture         =   "frmGame.frx":4129
      Top             =   0
      Visible         =   0   'False
      Width           =   255
   End
   Begin VB.Image imgTerrain 
      BorderStyle     =   1  'Fixed Single
      Height          =   255
      Index           =   1
      Left            =   2880
      Picture         =   "frmGame.frx":4489
      Top             =   0
      Visible         =   0   'False
      Width           =   255
   End
   Begin VB.Image imgTerrain 
      BorderStyle     =   1  'Fixed Single
      Height          =   255
      Index           =   4
      Left            =   3600
      Picture         =   "frmGame.frx":47FA
      Top             =   0
      Visible         =   0   'False
      Width           =   255
   End
   Begin VB.Image imgTerrain 
      BorderStyle     =   1  'Fixed Single
      Height          =   255
      Index           =   0
      Left            =   2640
      Picture         =   "frmGame.frx":4B7F
      Top             =   0
      Visible         =   0   'False
      Width           =   255
   End
End
Attribute VB_Name = "frmGame"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
' textbox on frmgame for area description
' spells: max wis/50, each spell as different charge needed, rate = int/day
Public Quitting As Integer
Public Wide As Integer

Private Sub cmdChar_Click()
'  Dim CF As New frmChar
  frmChar.Visible = True
  frmChar.RefreshChar
End Sub

Private Sub cmdCheat_Click()
  Dim i As Integer
  char.Player.Points = 1000000000
  char.Player.Gold = 1000000000
  For i = 0 To 6
    char.Player.Stats(i) = char.Player.Stats(i) + 100
  Next i
  char.Player.CalcDervs
  RefreshGame
End Sub

Private Sub cmdCity_Click()
  If World.World(Loc).LCity.T = "City" Then
    Player.LastTown = Loc
  End If
  
  frmCity.Visible = True
  frmGame.Visible = False
  frmCity.RefreshCity
End Sub

Private Sub cmdInven_Click()
'  Dim CF As New frmInven
  frmInven.Visible = True
  frmInven.RefreshInven
End Sub

Public Sub AddEvent(s As String)
  Static le As Date
  
  If le <> GameDate Then
    Call lstEvents.AddItem(GameDate, lstEvents.ListCount)
    le = GameDate
  End If
  Call lstEvents.AddItem(" -" & s, lstEvents.ListCount)
  While lstEvents.ListCount > 200
    lstEvents.RemoveItem (0)
  Wend
  lstEvents.ListIndex = lstEvents.ListCount - 1
End Sub

Private Sub cmdMap_Click()
  frmMap.Visible = True
  frmMap.SetFocus
  frmMap.DrawMap
End Sub

Private Sub cmdMove_Click(index As Integer)
  frmGame.cmdRoute.Caption = "Calc. Route"
  Call MoveTo(World.World(Loc).Link(index))
End Sub

Private Sub cmdPlaces_Click()
  Call frmPlaces.RefreshPlaces
  frmPlaces.Visible = True
  frmPlaces.SetFocus
End Sub
Private Sub cmdMagic_Click()
  Call frmMagic.RefreshSpells
  frmMagic.Visible = True
  frmMagic.SetFocus
End Sub

Private Sub cmdRad_Click()
  frmRad.Visible = True
  frmRad.SetFocus
  frmRad.DrawMap
End Sub

Private Sub cmdRest_Click()
  If Not World.World(Loc).LCity Is Nothing Then
    If World.World(Loc).LCity.T = "City" Then
      If events.GuardsStop() = 1 Then
        Exit Sub
      End If
    End If
  End If
  AddEvent ("Rested")
  PassTime
  Encounter
End Sub

Private Sub cmdRoute_Click()
  Dim i As Integer
  If cmdRoute.Caption = "Calc. Route" And IsNumeric(txRoute.Text) And Val(txRoute.Text) <> Loc Then
    txShowRoute.Text = CalcRoute(txRoute.Text, frmGame.ckCombat.Value)
    If Left(txShowRoute.Text, 8) <> "Bad Dest" Then
      cmdRoute.Caption = "Move Route"
      For i = 0 To C_RMAX - 1
        curroute(i) = route(i)
      Next i
    End If
  ElseIf cmdRoute.Caption = "Move Route" Then
    Call MoveTo(NextRoute())
    If txShowRoute.Text = "" Then
      cmdRoute.Caption = "Calc. Route"
      cmdRoute.Enabled = False
      txRoute.Text = ""
    End If
    RefreshGame
  ElseIf Val(txRoute.Text) = Loc Then
    txShowRoute.Text = "Bad Dest"
    cmdRoute.Enabled = False
  End If
End Sub

Private Sub cmdStats_Click()
  Dim j As Integer
  Dim info As String
  Dim roads As Integer
  Dim exp As Integer
  Dim cits(0 To 4) As Integer
  Dim crosses As Integer
  Dim slums As Integer
  Dim temp As Location
  Dim links As Double
  Dim depths As Double
  Dim maxdepth As Integer
  Dim tosame As Double
  Dim todif As Double
  Dim deps(0 To 999) As Double
  Dim depsto(0 To 999) As Double
  Dim depslinks(0 To 999) As Double
  Dim i As Integer
  
  For i = 0 To C_LOCS - 1
    Set temp = World.World(i)
    If World.World(i).Road = 1 Then roads = roads + 1
    If World.World(i).Explored = 1 Then exp = exp + 1
    If Not World.World(i).LCity Is Nothing Then
      If World.World(i).LCity.T = "City" Then
        cits(temp.LCity.Size) = cits(temp.LCity.Size) + 1
        cits(4) = cits(4) + 1
      End If
      If temp.LCity.T = "Slums" Then slums = slums + 1
      If World.World(i).LCity.T = "Crossroad" Then crosses = crosses + 1
    End If
    depths = depths + World.World(i).Depth
    deps(World.World(i).Depth) = deps(World.World(i).Depth) + 1
    If World.World(i).Depth > maxdepth Then maxdepth = World.World(i).Depth
    For j = 0 To 4
      If World.World(i).Link(j) <> -1 Then
        links = links + 1
        depslinks(World.World(i).Depth) = depslinks(World.World(i).Depth) + 1
        If Abs(World.World(World.World(i).Link(j)).Depth - World.World(i).Depth) <= 0 Then
          depsto(World.World(i).Depth) = depsto(World.World(i).Depth) + 1
        End If
        
        If World.World(World.World(i).Link(j)).Terrain = World.World(i).Terrain Then
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
  info = info & "ToSame: " & Round(tosame, 3) & " ToDif: " & Round(todif, 3) & vbCrLf
  info = info & "Avg. Depth: " & depths & vbCrLf
  info = info & "Max Depth: " & maxdepth & vbCrLf
  info = info & "Explored: " & exp & "/" & C_LOCS & vbCrLf
  info = info & "Regions: " & World.TRegions & vbCrLf
  info = info & "Avg Areas Per: " & Round(C_LOCS / World.TRegions, 3) & vbCrLf
  info = info & "Roads: " & roads & vbCrLf
  info = info & "Cities: (" & cits(4) & ") " & cits(0) & "/" & cits(1) & "/" & cits(2) & "/" & cits(3) & vbCrLf
  info = info & "Crossroads: " & crosses & vbCrLf
  info = info & "Slums: " & slums & vbCrLf
  
  For i = 0 To maxdepth
    info = info & i & ": " & deps(i) & " : " & depsto(i) & "/" & depslinks(i) & " : " & Round(depsto(i) / depslinks(i), 3) & vbCrLf
  Next i
  
  MsgBox info
End Sub

Private Sub Form_Load()
  txRoute.MaxLength = Len(Str(C_LOCS - 1)) - 1
  Wide = 8
  Quitting = 0
  Call MsgBox("Welcome to the Labyrinth!" & vbCrLf & "Don't forget to spend your character points before you begin adventuring!" & vbCrLf & "Then, purchase some equipment in Centris, equip it, and you're off!" & vbCrLf & vbCrLf & "The only way to escape this chaotic maze is to keep moving forward!", , "Entering the Labyrinth")
End Sub

Private Sub cmdQuit_Click()
  Quitting = 1
  Call Form_Unload(0)
End Sub
Private Sub Form_Unload(cancel As Integer)
  Dim ans As VbMsgBoxResult
  
  If Quitting = 0 Then
    cancel = 1
    Exit Sub
  End If

  If Quitting = 1 Then
    ans = MsgBox("Are you sure you want to quit?", vbYesNoCancel, "Quit Confirmation")
    
    If ans = vbNo Then
      cancel = 1
      Quitting = 0
      Exit Sub
    ElseIf ans = vbCancel Then
      cancel = 1
      Quitting = 0
      Exit Sub
    End If
  End If
  Quitting = 2
  Unload frmGame
  Unload frmChar
  Unload frmInven
  Unload frmPlaces
  Unload frmStart
  Unload frmCombat
  Unload frmMagic
  Unload frmCity
  Unload frmStore
  Unload frmMap
  Unload frmRad
End Sub

Private Sub lstPeople_DblClick()
  Dim p As Integer
  
  If lstPeople.Text = "" Then Exit Sub
  
  p = lstPeople.ItemData(lstPeople.ListIndex)
  
  frmPerson.Visible = True
  frmGame.Visible = False
  Call frmPerson.RefreshPerson(p)
  
End Sub

Private Sub txRoute_Change()
  If txRoute.Text = "" Then
    cmdRoute.Enabled = False
  Else
    cmdRoute.Enabled = True
  End If
  cmdRoute.Caption = "Calc. Route"
End Sub

Private Sub txRoute_KeyPress(keyascii As Integer)
  If keyascii = 13 Then
    cmdRoute_Click
    keyascii = 0
  End If
End Sub

Private Sub Form_KeyPress(keyascii As Integer)
  Dim K As String
  K = Chr(keyascii)
  K = LCase(K)
  
  If K = "r" Then
    Call cmdRest_Click
  ElseIf K = "m" Then
    Call cmdRad_Click
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
    Call cmdChar_Click
  ElseIf K = "i" Then
    Call cmdInven_Click
  ElseIf K = "s" Then
    Call cmdMagic_Click
  ElseIf K = "t" Then
    Call cmdStats_Click
  ElseIf K = "q" Then
    Call cmdQuit_Click
  ElseIf K = "e" Then
    Call cmdCity_Click
  ElseIf K = "f" Then
    Call cmdRoute_Click
  End If
  
  If (keyascii < Asc("0") Or keyascii > Asc("9")) And keyascii <> 13 And keyascii <> 8 Then
    keyascii = 0
  End If
  
End Sub

