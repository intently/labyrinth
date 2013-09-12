VERSION 5.00
Begin VB.Form frmChar 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Player Character"
   ClientHeight    =   4020
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   4590
   KeyPreview      =   -1  'True
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   ScaleHeight     =   4020
   ScaleWidth      =   4590
   StartUpPosition =   2  'CenterScreen
   Begin VB.Timer tmrCount 
      Interval        =   250
      Left            =   0
      Top             =   840
   End
   Begin VB.Frame frStats 
      Caption         =   "Statistics"
      Height          =   3975
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   4575
      Begin VB.CommandButton cmdReset 
         Caption         =   "Reset"
         Height          =   495
         Left            =   1860
         TabIndex        =   56
         Top             =   2550
         Width           =   1095
      End
      Begin VB.TextBox txDervs 
         Height          =   285
         Index           =   9
         Left            =   3840
         Locked          =   -1  'True
         TabIndex        =   46
         Text            =   "Text1"
         Top             =   2400
         Width           =   615
      End
      Begin VB.TextBox txDervs 
         Height          =   285
         Index           =   8
         Left            =   3840
         Locked          =   -1  'True
         TabIndex        =   45
         Text            =   "Text1"
         Top             =   1680
         Width           =   615
      End
      Begin VB.TextBox txDervs 
         Height          =   285
         Index           =   7
         Left            =   3840
         Locked          =   -1  'True
         TabIndex        =   44
         Text            =   "Text1"
         Top             =   960
         Width           =   615
      End
      Begin VB.CommandButton cmdCharDone 
         Caption         =   "Done"
         Height          =   495
         Left            =   720
         TabIndex        =   43
         Top             =   3240
         Width           =   1095
      End
      Begin VB.TextBox txDervs 
         Height          =   285
         Index           =   6
         Left            =   3840
         Locked          =   -1  'True
         TabIndex        =   42
         Text            =   "Text1"
         Top             =   3480
         Width           =   615
      End
      Begin VB.TextBox txDervs 
         Height          =   285
         Index           =   5
         Left            =   3840
         Locked          =   -1  'True
         TabIndex        =   41
         Text            =   "Text1"
         Top             =   3120
         Width           =   615
      End
      Begin VB.TextBox txDervs 
         Height          =   285
         Index           =   4
         Left            =   3840
         Locked          =   -1  'True
         TabIndex        =   40
         Text            =   "Text1"
         Top             =   2760
         Width           =   615
      End
      Begin VB.TextBox txDervs 
         Height          =   285
         Index           =   3
         Left            =   3840
         Locked          =   -1  'True
         TabIndex        =   39
         Text            =   "Text1"
         Top             =   2040
         Width           =   615
      End
      Begin VB.TextBox txDervs 
         Height          =   285
         Index           =   2
         Left            =   3840
         Locked          =   -1  'True
         TabIndex        =   38
         Text            =   "Text1"
         Top             =   1320
         Width           =   615
      End
      Begin VB.TextBox txDervs 
         Height          =   285
         Index           =   1
         Left            =   3840
         Locked          =   -1  'True
         TabIndex        =   37
         Text            =   "Text1"
         Top             =   600
         Width           =   615
      End
      Begin VB.TextBox txDervs 
         Height          =   285
         Index           =   0
         Left            =   3840
         Locked          =   -1  'True
         TabIndex        =   36
         Text            =   "Text1"
         Top             =   240
         Width           =   615
      End
      Begin VB.TextBox txPoints 
         Height          =   285
         Left            =   960
         Locked          =   -1  'True
         TabIndex        =   28
         Text            =   "Text1"
         Top             =   2760
         Width           =   855
      End
      Begin VB.CommandButton cmdDown 
         Caption         =   "D"
         Height          =   255
         Index           =   5
         Left            =   2640
         TabIndex        =   26
         Top             =   2040
         Visible         =   0   'False
         Width           =   255
      End
      Begin VB.CommandButton cmdDown 
         Caption         =   "D"
         Height          =   255
         Index           =   4
         Left            =   2640
         TabIndex        =   25
         Top             =   1680
         Visible         =   0   'False
         Width           =   255
      End
      Begin VB.CommandButton cmdDown 
         Caption         =   "D"
         Height          =   255
         Index           =   3
         Left            =   2640
         TabIndex        =   24
         Top             =   1320
         Visible         =   0   'False
         Width           =   255
      End
      Begin VB.CommandButton cmdDown 
         Caption         =   "D"
         Height          =   255
         Index           =   2
         Left            =   2640
         TabIndex        =   23
         Top             =   960
         Visible         =   0   'False
         Width           =   255
      End
      Begin VB.CommandButton cmdDown 
         Caption         =   "D"
         Height          =   255
         Index           =   1
         Left            =   2640
         TabIndex        =   22
         Top             =   600
         Visible         =   0   'False
         Width           =   255
      End
      Begin VB.CommandButton cmdDown 
         Caption         =   "D"
         Height          =   255
         Index           =   0
         Left            =   2640
         TabIndex        =   21
         Top             =   240
         Visible         =   0   'False
         Width           =   255
      End
      Begin VB.CommandButton cmdUp 
         Caption         =   "U"
         Height          =   255
         Index           =   5
         Left            =   2280
         TabIndex        =   20
         Top             =   2040
         Width           =   255
      End
      Begin VB.CommandButton cmdUp 
         Caption         =   "U"
         Height          =   255
         Index           =   4
         Left            =   2280
         TabIndex        =   19
         Top             =   1680
         Width           =   255
      End
      Begin VB.CommandButton cmdUp 
         Caption         =   "U"
         Height          =   255
         Index           =   3
         Left            =   2280
         TabIndex        =   18
         Top             =   1320
         Width           =   255
      End
      Begin VB.CommandButton cmdUp 
         Caption         =   "U"
         Height          =   255
         Index           =   2
         Left            =   2280
         TabIndex        =   17
         Top             =   960
         Width           =   255
      End
      Begin VB.CommandButton cmdUp 
         Caption         =   "U"
         Height          =   255
         Index           =   1
         Left            =   2280
         TabIndex        =   16
         Top             =   600
         Width           =   255
      End
      Begin VB.CommandButton cmdUp 
         Caption         =   "U"
         Height          =   255
         Index           =   0
         Left            =   2280
         TabIndex        =   15
         Top             =   240
         Width           =   255
      End
      Begin VB.TextBox txStats 
         Height          =   285
         Index           =   6
         Left            =   960
         Locked          =   -1  'True
         TabIndex        =   14
         Text            =   "Text1"
         Top             =   2400
         Width           =   855
      End
      Begin VB.TextBox txStats 
         Height          =   285
         Index           =   5
         Left            =   960
         Locked          =   -1  'True
         TabIndex        =   13
         Text            =   "Text1"
         Top             =   2040
         Width           =   855
      End
      Begin VB.TextBox txStats 
         Height          =   285
         Index           =   4
         Left            =   960
         Locked          =   -1  'True
         TabIndex        =   12
         Text            =   "Text1"
         Top             =   1680
         Width           =   855
      End
      Begin VB.TextBox txStats 
         Height          =   285
         Index           =   3
         Left            =   960
         Locked          =   -1  'True
         TabIndex        =   11
         Text            =   "Text1"
         Top             =   1320
         Width           =   855
      End
      Begin VB.TextBox txStats 
         Height          =   285
         Index           =   2
         Left            =   960
         Locked          =   -1  'True
         TabIndex        =   10
         Text            =   "Text1"
         Top             =   960
         Width           =   855
      End
      Begin VB.TextBox txStats 
         Height          =   285
         Index           =   1
         Left            =   960
         Locked          =   -1  'True
         TabIndex        =   9
         Text            =   "Text1"
         Top             =   600
         Width           =   855
      End
      Begin VB.TextBox txStats 
         Height          =   285
         Index           =   0
         Left            =   960
         Locked          =   -1  'True
         TabIndex        =   8
         Text            =   "Text1"
         Top             =   240
         Width           =   855
      End
      Begin VB.Label lblCost 
         Caption         =   "Label1"
         Height          =   255
         Index           =   5
         Left            =   1920
         TabIndex        =   55
         Top             =   2040
         Width           =   375
      End
      Begin VB.Label lblCost 
         Caption         =   "Label1"
         Height          =   255
         Index           =   4
         Left            =   1920
         TabIndex        =   54
         Top             =   1680
         Width           =   375
      End
      Begin VB.Label lblCost 
         Caption         =   "Label1"
         Height          =   255
         Index           =   3
         Left            =   1920
         TabIndex        =   53
         Top             =   1320
         Width           =   375
      End
      Begin VB.Label lblCost 
         Caption         =   "Label1"
         Height          =   255
         Index           =   2
         Left            =   1920
         TabIndex        =   52
         Top             =   960
         Width           =   375
      End
      Begin VB.Label lblCost 
         Caption         =   "Label1"
         Height          =   255
         Index           =   1
         Left            =   1920
         TabIndex        =   51
         Top             =   600
         Width           =   375
      End
      Begin VB.Label lblCost 
         Caption         =   "Label1"
         Height          =   255
         Index           =   0
         Left            =   1920
         TabIndex        =   50
         Top             =   240
         Width           =   375
      End
      Begin VB.Label lblDervs 
         Caption         =   "Cur HP"
         Height          =   255
         Index           =   9
         Left            =   3000
         TabIndex        =   49
         Top             =   2400
         Width           =   735
      End
      Begin VB.Label lblDervs 
         Caption         =   "DR"
         Height          =   255
         Index           =   8
         Left            =   3000
         TabIndex        =   48
         Top             =   1680
         Width           =   735
      End
      Begin VB.Label lblDervs 
         Caption         =   "Damage"
         Height          =   255
         Index           =   7
         Left            =   3000
         TabIndex        =   47
         Top             =   960
         Width           =   735
      End
      Begin VB.Label lblDervs 
         Caption         =   "Luck"
         Height          =   255
         Index           =   6
         Left            =   3000
         TabIndex        =   35
         Top             =   3480
         Width           =   735
      End
      Begin VB.Label lblDervs 
         Caption         =   "Perception"
         Height          =   255
         Index           =   5
         Left            =   3000
         TabIndex        =   34
         Top             =   3120
         Width           =   855
      End
      Begin VB.Label lblDervs 
         Caption         =   "Speed"
         Height          =   255
         Index           =   4
         Left            =   3000
         TabIndex        =   33
         Top             =   2760
         Width           =   735
      End
      Begin VB.Label lblDervs 
         Caption         =   "Max HP"
         Height          =   255
         Index           =   3
         Left            =   3000
         TabIndex        =   32
         Top             =   2040
         Width           =   735
      End
      Begin VB.Label lblDervs 
         Caption         =   "Defense"
         Height          =   255
         Index           =   2
         Left            =   3000
         TabIndex        =   31
         Top             =   1320
         Width           =   735
      End
      Begin VB.Label lblDervs 
         Caption         =   "Dex Attack"
         Height          =   255
         Index           =   1
         Left            =   3000
         TabIndex        =   30
         Top             =   600
         Width           =   855
      End
      Begin VB.Label lblDervs 
         Caption         =   "Str Attack"
         Height          =   255
         Index           =   0
         Left            =   3000
         TabIndex        =   29
         Top             =   240
         Width           =   735
      End
      Begin VB.Label lblPoints 
         Caption         =   "Points"
         Height          =   255
         Left            =   120
         TabIndex        =   27
         Top             =   2760
         Width           =   615
      End
      Begin VB.Label lblStats 
         Caption         =   "Reputation"
         Height          =   255
         Index           =   6
         Left            =   120
         TabIndex        =   7
         Top             =   2400
         Width           =   855
      End
      Begin VB.Label lblStats 
         Caption         =   "Charisma"
         Height          =   255
         Index           =   5
         Left            =   120
         TabIndex        =   6
         Top             =   2040
         Width           =   735
      End
      Begin VB.Label lblStats 
         Caption         =   "Wisdom"
         Height          =   255
         Index           =   4
         Left            =   120
         TabIndex        =   5
         Top             =   1680
         Width           =   615
      End
      Begin VB.Label lblStats 
         Caption         =   "Intelligence"
         Height          =   255
         Index           =   3
         Left            =   120
         TabIndex        =   4
         Top             =   1320
         Width           =   855
      End
      Begin VB.Label lblStats 
         Caption         =   "Constitution"
         Height          =   255
         Index           =   2
         Left            =   120
         TabIndex        =   3
         Top             =   960
         Width           =   855
      End
      Begin VB.Label lblStats 
         Caption         =   "Dexterity"
         Height          =   255
         Index           =   1
         Left            =   120
         TabIndex        =   2
         Top             =   600
         Width           =   615
      End
      Begin VB.Label lblStats 
         Caption         =   "Strength"
         Height          =   255
         Index           =   0
         Left            =   120
         TabIndex        =   1
         Top             =   240
         Width           =   615
      End
   End
End
Attribute VB_Name = "frmChar"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Private Sub cmdCharDone_Click()
  RefreshGame
  Unload frmChar
End Sub


Private Sub cmdDown_Click(i As Integer)
  Dim cost As Integer
  cost = AtrCost(Player.Stats(i), 0)
  
  If Player.Stats(i) - 1 >= char.Locked(i) Then
    Player.Points = Player.Points + cost
    Player.Stats(i) = Player.Stats(i) - 1
  End If
  
  Call RefreshChar
End Sub

Private Sub cmdReset_Click()
  Dim i As Integer
  
  For i = 0 To 6
    char.Player.Stats(i) = char.Locked(i)
  Next i
  char.Player.Points = char.LockedPoints
  
  Call RefreshChar
End Sub

Private Sub cmdUp_Click(i As Integer)
  Dim cost As Integer
  cost = AtrCost(Player.Stats(i) + 1)
  
  If Player.Points >= cost Then
    Player.Points = Player.Points - cost
    Player.Stats(i) = Player.Stats(i) + 1
  End If
  
  Call RefreshChar

End Sub


Private Sub tmrCount_Timer()
  If tmrCount.Tag > 9 Then
    cmdUp_Click (tmrCount.Tag - 10)
  Else
    cmdDown_Click (tmrCount.Tag)
  End If
  If tmrCount.Interval > 1 Then tmrCount.Interval = Max(tmrCount.Interval - 25, 1)
End Sub
Private Sub cmdUp_MouseDown(index As Integer, Button As Integer, Shift As Integer, x As Single, Y As Single)
  tmrCount.Tag = index + 10
  tmrCount.Enabled = True
End Sub

Private Sub cmdUp_MouseUp(index As Integer, Button As Integer, Shift As Integer, x As Single, Y As Single)
  tmrCount.Enabled = False
  tmrCount.Interval = 200
End Sub

Private Sub cmdDown_MouseDown(index As Integer, Button As Integer, Shift As Integer, x As Single, Y As Single)
  tmrCount.Tag = index
  tmrCount.Enabled = True
End Sub

Private Sub cmdDown_MouseUp(index As Integer, Button As Integer, Shift As Integer, x As Single, Y As Single)
  tmrCount.Enabled = False
  tmrCount.Interval = 200
End Sub

Public Sub RefreshChar()
  Dim i As Integer
  Player.CalcDervs
  For i = 0 To 6
    txStats(i).Text = Player.Stats(i) & " (" & Player.Reals(i) & ")"
  Next i
  For i = 0 To 9
    txDervs(i).Text = Player.Dervs(i)
  Next i
  For i = 0 To 5
    lblCost(i).Caption = AtrCost(Player.Stats(i) + 1)
  Next i
  txPoints.Text = Player.Points

End Sub


Private Sub Form_Load()
  Dim i As Integer
  Call RefreshChar
  txPoints.Text = Player.Points
  
  For i = 0 To 6
    char.Locked(i) = Player.Stats(i)
  Next i
  char.LockedPoints = Player.Points
  tmrCount.Enabled = False
  tmrCount.Interval = 200
End Sub


Private Sub Form_KeyPress(keyascii As Integer)
  If keyascii = 27 Then
    Call cmdCharDone_Click
  End If
End Sub

