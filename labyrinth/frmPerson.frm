VERSION 5.00
Begin VB.Form frmPerson 
   Caption         =   "Person"
   ClientHeight    =   3870
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   3525
   KeyPreview      =   -1  'True
   LinkTopic       =   "Form1"
   ScaleHeight     =   3870
   ScaleWidth      =   3525
   StartUpPosition =   2  'CenterScreen
   Begin VB.Frame frCity 
      Caption         =   "Actions"
      Height          =   3855
      Left            =   2040
      TabIndex        =   3
      Top             =   0
      Width           =   1455
      Begin VB.CommandButton cmdBeg 
         Caption         =   "Beg"
         Height          =   495
         Left            =   120
         TabIndex        =   9
         Top             =   3240
         Width           =   1215
      End
      Begin VB.CommandButton cmdMonsters 
         Caption         =   "Ask About Monsters"
         Height          =   495
         Left            =   120
         TabIndex        =   8
         Top             =   2040
         Width           =   1215
      End
      Begin VB.CommandButton cmdHelp 
         Caption         =   "Converse"
         Height          =   495
         Left            =   120
         TabIndex        =   7
         Top             =   2640
         Width           =   1215
      End
      Begin VB.CommandButton cmdRumors 
         Caption         =   "Ask About Rumors"
         Height          =   495
         Left            =   120
         TabIndex        =   6
         Top             =   1440
         Width           =   1215
      End
      Begin VB.CommandButton cmdItems 
         Caption         =   "AskTo Buy Items"
         Height          =   495
         Left            =   120
         TabIndex        =   5
         Top             =   840
         Width           =   1215
      End
      Begin VB.CommandButton cmdPlaces 
         Caption         =   "Ask About Places"
         Height          =   495
         Left            =   120
         TabIndex        =   4
         Top             =   240
         Width           =   1215
      End
   End
   Begin VB.Frame frInfo 
      Height          =   3855
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   1935
      Begin VB.CommandButton cmdLeave 
         Caption         =   "Leave"
         Height          =   495
         Left            =   360
         TabIndex        =   2
         Top             =   3240
         Width           =   1215
      End
      Begin VB.TextBox txInfo 
         Height          =   2895
         Left            =   120
         MultiLine       =   -1  'True
         TabIndex        =   1
         Text            =   "frmPerson.frx":0000
         Top             =   240
         Width           =   1695
      End
   End
End
Attribute VB_Name = "frmPerson"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Public Per As Person

Public Sub RefreshPerson(p As Integer)
  Set Per = People(p)
  
  frmPerson.Caption = Per.Name
  frmPerson.txInfo = Per.Desc
End Sub


Private Sub cmdBeg_Click()
  Dim gift As Integer

  If Player.Reals(S_CHA) < (World.World(Per.Loc).Depth - 1) * 10 Or (Player.Reals(S_REP) < 2) Then
    Call MsgBox(Per.Name & " glares at you distainfully." & vbCrLf & "You lose a point of reputation.", , "Beg")
    Player.Stats(S_REP) = Max(Player.Stats(S_REP) - 1, 0)
  Else
    gift = PM(Player.Reals(S_CHA) * (I_MANT ^ World.World(Per.Loc).Depth), 25)
    Call MsgBox(Per.Name & " takes pity on you and gifts you with " & gift & " gold pieces." & vbCrLf & "You lose two points of reputation.", , "Beg")
    Player.Stats(S_REP) = Max(Player.Stats(S_REP) - 2, 0)
  End If
End Sub

Private Sub cmdHelp_Click()
  Dim i As Integer
  Dim r As Integer
  Dim s As String
  Dim level As Integer
  Dim ans As VbMsgBoxResult
  Dim it As Item
  If Per.T = "Taxidermist" Then
    For i = 0 To 99
      r = Int(Rnd * C_INVMAX)
      If Not Player.Inven(r) Is Nothing Then
        If InStr(1, Player.Inven(r).Text, "Doll") Then
          s = Per.Name & " offers you an item of rare and wondrous power in exchange for your " & vbCrLf & JustText(Player.Inven(r).Text) & vbCrLf & vbCrLf & "Do you accept?"
          Player.Inven(r).ID = True
          Exit For
        End If
      End If
    Next i
        
    If i = 100 Then
      MsgBox Per.Name & " has nothing to say to you.", , "Converse"
      Exit Sub
    End If
  Else
    MsgBox Per.Name & " has nothing to say to you.", , "Converse"
    Exit Sub
  End If

  ans = MsgBox(s, vbYesNo, "Converse")
  
  If ans = vbYes Then
    Set it = Player.Inven(r)
    level = it.Depth
    Call Player.RemInven(it)
    
    Set it = New Item
    r = Int(Rnd * 100)
    Select Case r
      Case 0 To 49
        Call it.Create(Int(Rnd * 4), level + 2 + Int(Rnd * 3), level + 2, 100)
      Case 50 To 99
        Call it.CreateArtifact(Int(Rnd * 6), level)
    End Select
    
    it.ID = True
    Call Player.AddInven(it)
    MsgBox "You receive in exchange:" & vbCrLf & JustText(it.Text), , "Receive Item"
  Else
  End If

End Sub

Private Sub cmdItems_Click()
  Dim cost As Long
  Dim ans As VbMsgBoxResult
  
  If Per.LastExplored <> GameDate Or Per.it Is Nothing Then
    Set Per.it = New Item
    Call Per.it.Create(Int(Rnd * 4), World.World(Per.Loc).Depth + Per.Quality)
    Per.it.Value = Int(Per.it.Value * Per.Greed / 100)
    Per.it.ID = True
  End If
  cost = Price(Per.it.Value, 1)
  
  ans = MsgBox(Per.Name & " offers you a " & vbCrLf & JustText(ItemText(Per.it)) & vbCrLf & "for " & cost & " gold coins." & vbCrLf & "You have " & char.Player.Gold & " gold coins, do you accept?", vbYesNo, "Purchase Item")
  
  If ans = vbYes Then
    If char.Player.Gold >= cost Then
      char.Player.Gold = char.Player.Gold - cost
      
      Call char.Player.AddInven(Per.it)
      Set Per.it = Nothing
    Else
      MsgBox Per.Name & " laughs, seeing that you don't have the money.", , "Purchase Item"
    End If
  Else
    
  End If
  
  Per.LastExplored = GameDate
  
End Sub

Private Sub cmdLeave_Click()
  Per.LastExplored = GameDate
  
  frmGame.Visible = True
  RefreshGame
  Unload frmPerson
End Sub

Private Sub cmdMonsters_Click()
  Dim dep As Integer
  Dim monstername As String
  Dim Mo As Monster
  Dim cost As Long
  Dim ans As VbMsgBoxResult
  
  cost = Price((Per.Greed / 100) * 3 * (I_MANT ^ World.World(Per.Loc).Depth), 1)
  dep = World.World(Per.Loc).Depth - World.World(Per.Loc).Road
  
  If dep < 0 Then
    Call MsgBox(Per.Name & " laughs heartily, and reminds you that there are no monsters on the roads this close to Centris.", vbOKOnly, "Ask About Monsters")
    Exit Sub
  End If
  
  monstername = SelectMonster(World.World(Per.Loc).Terrain, dep, 1)
  
  ans = MsgBox(Per.Name & " offers you information about the " & monstername & " for " & cost & " gold coins." & vbCrLf & "You have " & char.Player.Gold & " gold coins, do you accept?", vbYesNo, "Ask About Monsters")
  
  If ans = vbYes Then
    If char.Player.Gold >= cost Then
      char.Player.Gold = char.Player.Gold - cost
      
      Set Mo = New Monster
      Call Mo.MakeMonster(monstername)
      Call DispMonster(Mo, 0)
      If char.Player.KL(Mo.Terrain, Mo.Depth) < 50 Then
        char.Player.KL(Mo.Terrain, Mo.Depth) = char.Player.KL(Mo.Terrain, Mo.Depth) + 10
      End If
    Else
      MsgBox Per.Name & " laughs, seeing that you don't have the money.", , "Ask About Places"
    End If
  Else
    
  End If
End Sub

Private Sub cmdPlaces_Click()
  Dim i As Integer
  Dim d As Integer
  Dim cost As Long
  Dim ans As VbMsgBoxResult
  Dim kn As Integer
  
  cost = Price(Per.Greed * TG(World.World(Per.Loc).Depth) / 200, 1)
  kn = 0
  
  For i = 0 To C_LOCS - 1
    d = Int(Rnd * C_LOCS)
    If Per.Known(d) = 1 And World.World(d).Known = 0 And Not World.World(d).LCity Is Nothing Then
      If World.World(d).LCity.T <> "None" Then
        Exit For
      End If
    End If
    d = -1
    If Per.Known(i) = 1 Then kn = kn + 1
  Next i
  
  If d <> -1 Then
    ans = MsgBox(Per.Name & " offers you information about a " & World.World(d).LCity.T & " for " & cost & " gold coins." & vbCrLf & "You have " & char.Player.Gold & " gold coins, do you accept?", vbYesNo, "Ask About Places")
    
    If ans = vbYes Then
      If char.Player.Gold >= cost Then
        char.Player.Gold = char.Player.Gold - cost
        
        MsgBox Per.Name & " tells you that there is a " & World.World(d).LCity.T & vbCrLf & " located at " & d & ".", , "Ask About Places"
        World.World(d).Known = 1
      Else
        MsgBox Per.Name & " laughs, seeing that you don't have the money.", , "Ask About Places"
      End If
    Else
      
    End If
  Else
    MsgBox Per.Name & " has nothing interesting to tell you.", , "Ask About Places"
  End If
End Sub
Private Sub Form_KeyPress(keyascii As Integer)
  If keyascii = 27 Then
    Call cmdLeave_Click
  End If
End Sub

