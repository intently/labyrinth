VERSION 5.00
Begin VB.Form frmInven 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Inventory"
   ClientHeight    =   6315
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   10365
   KeyPreview      =   -1  'True
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   ScaleHeight     =   6315
   ScaleWidth      =   10365
   StartUpPosition =   2  'CenterScreen
   Begin VB.Frame frCurrent 
      Caption         =   "Current Item"
      Height          =   615
      Left            =   0
      TabIndex        =   73
      Top             =   5640
      Width           =   10335
      Begin VB.TextBox txValue 
         Height          =   285
         Left            =   8760
         Locked          =   -1  'True
         TabIndex        =   76
         Text            =   "Text1"
         Top             =   240
         Width           =   1455
      End
      Begin VB.TextBox txCur 
         Height          =   285
         Left            =   120
         Locked          =   -1  'True
         TabIndex        =   74
         Text            =   "Text1"
         Top             =   240
         Width           =   8055
      End
      Begin VB.Label lblValue 
         Caption         =   "Value"
         Height          =   255
         Left            =   8280
         TabIndex        =   75
         Top             =   240
         Width           =   495
      End
   End
   Begin VB.Frame frInven 
      Caption         =   "Inventory"
      Height          =   5655
      Left            =   5760
      TabIndex        =   1
      Top             =   0
      Width           =   4575
      Begin VB.CommandButton cmdPickUp 
         Caption         =   "Pick Up"
         Height          =   255
         Left            =   120
         TabIndex        =   64
         Top             =   5280
         Width           =   1095
      End
      Begin VB.TextBox txPickUp 
         Height          =   285
         Left            =   1320
         Locked          =   -1  'True
         TabIndex        =   63
         Text            =   "Text1"
         Top             =   5280
         Width           =   3135
      End
      Begin VB.ListBox lstInven 
         Height          =   4935
         Left            =   120
         Sorted          =   -1  'True
         TabIndex        =   18
         Top             =   240
         Width           =   4335
      End
   End
   Begin VB.Frame frEquip 
      Caption         =   "Equipped"
      Height          =   5655
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   5655
      Begin VB.CommandButton cmdID 
         Caption         =   "Identify"
         Height          =   495
         Left            =   4680
         TabIndex        =   77
         Top             =   3840
         Width           =   855
      End
      Begin VB.TextBox txRes 
         Alignment       =   1  'Right Justify
         Height          =   285
         Index           =   3
         Left            =   3960
         Locked          =   -1  'True
         TabIndex        =   72
         Text            =   "Text1"
         Top             =   5280
         Width           =   615
      End
      Begin VB.TextBox txRes 
         Alignment       =   1  'Right Justify
         Height          =   285
         Index           =   2
         Left            =   3960
         Locked          =   -1  'True
         TabIndex        =   71
         Text            =   "Text1"
         Top             =   4920
         Width           =   615
      End
      Begin VB.TextBox txRes 
         Alignment       =   1  'Right Justify
         Height          =   285
         Index           =   1
         Left            =   3960
         Locked          =   -1  'True
         TabIndex        =   70
         Text            =   "Text1"
         Top             =   4560
         Width           =   615
      End
      Begin VB.TextBox txRes 
         Alignment       =   1  'Right Justify
         Height          =   285
         Index           =   0
         Left            =   3960
         Locked          =   -1  'True
         TabIndex        =   69
         Text            =   "Text1"
         Top             =   4200
         Width           =   615
      End
      Begin VB.TextBox txGold 
         Alignment       =   1  'Right Justify
         Height          =   285
         Left            =   3720
         Locked          =   -1  'True
         TabIndex        =   62
         Text            =   "Text1"
         Top             =   3840
         Width           =   855
      End
      Begin VB.CommandButton cmdDrop 
         Caption         =   "Drop"
         Height          =   495
         Left            =   4680
         TabIndex        =   60
         Top             =   4440
         Width           =   855
      End
      Begin VB.TextBox txDR 
         Height          =   285
         Left            =   3960
         Locked          =   -1  'True
         TabIndex        =   59
         Text            =   "Text1"
         Top             =   3480
         Width           =   615
      End
      Begin VB.TextBox txDam 
         Height          =   285
         Left            =   2520
         Locked          =   -1  'True
         TabIndex        =   57
         Text            =   "Text1"
         Top             =   3840
         Width           =   615
      End
      Begin VB.TextBox txStats 
         Height          =   285
         Index           =   0
         Left            =   960
         Locked          =   -1  'True
         TabIndex        =   48
         Text            =   "Text1"
         Top             =   3120
         Width           =   615
      End
      Begin VB.TextBox txStats 
         Height          =   285
         Index           =   1
         Left            =   960
         Locked          =   -1  'True
         TabIndex        =   47
         Text            =   "Text1"
         Top             =   3480
         Width           =   615
      End
      Begin VB.TextBox txStats 
         Height          =   285
         Index           =   2
         Left            =   960
         Locked          =   -1  'True
         TabIndex        =   46
         Text            =   "Text1"
         Top             =   3840
         Width           =   615
      End
      Begin VB.TextBox txStats 
         Height          =   285
         Index           =   3
         Left            =   960
         Locked          =   -1  'True
         TabIndex        =   45
         Text            =   "Text1"
         Top             =   4200
         Width           =   615
      End
      Begin VB.TextBox txStats 
         Height          =   285
         Index           =   4
         Left            =   960
         Locked          =   -1  'True
         TabIndex        =   44
         Text            =   "Text1"
         Top             =   4560
         Width           =   615
      End
      Begin VB.TextBox txStats 
         Height          =   285
         Index           =   5
         Left            =   960
         Locked          =   -1  'True
         TabIndex        =   43
         Text            =   "Text1"
         Top             =   4920
         Width           =   615
      End
      Begin VB.TextBox txStats 
         Height          =   285
         Index           =   6
         Left            =   960
         Locked          =   -1  'True
         TabIndex        =   42
         Text            =   "Text1"
         Top             =   5280
         Width           =   615
      End
      Begin VB.TextBox txDervs 
         Height          =   285
         Index           =   0
         Left            =   2520
         Locked          =   -1  'True
         TabIndex        =   34
         Text            =   "Text1"
         Top             =   3120
         Width           =   615
      End
      Begin VB.TextBox txDervs 
         Height          =   285
         Index           =   1
         Left            =   2520
         Locked          =   -1  'True
         TabIndex        =   33
         Text            =   "Text1"
         Top             =   3480
         Width           =   615
      End
      Begin VB.TextBox txDervs 
         Height          =   285
         Index           =   2
         Left            =   3960
         Locked          =   -1  'True
         TabIndex        =   32
         Text            =   "Text1"
         Top             =   3120
         Width           =   615
      End
      Begin VB.TextBox txDervs 
         Height          =   285
         Index           =   3
         Left            =   2520
         Locked          =   -1  'True
         TabIndex        =   31
         Text            =   "Text1"
         Top             =   4200
         Width           =   615
      End
      Begin VB.TextBox txDervs 
         Height          =   285
         Index           =   4
         Left            =   2520
         Locked          =   -1  'True
         TabIndex        =   30
         Text            =   "Text1"
         Top             =   4560
         Width           =   615
      End
      Begin VB.TextBox txDervs 
         Height          =   285
         Index           =   5
         Left            =   2520
         Locked          =   -1  'True
         TabIndex        =   29
         Text            =   "Text1"
         Top             =   4920
         Width           =   615
      End
      Begin VB.TextBox txDervs 
         Height          =   285
         Index           =   6
         Left            =   2520
         Locked          =   -1  'True
         TabIndex        =   28
         Text            =   "Text1"
         Top             =   5280
         Width           =   615
      End
      Begin VB.CommandButton cmdUneq 
         Caption         =   "U"
         Height          =   255
         Index           =   7
         Left            =   5280
         TabIndex        =   27
         Top             =   2760
         Width           =   255
      End
      Begin VB.CommandButton cmdUneq 
         Caption         =   "U"
         Height          =   255
         Index           =   6
         Left            =   5280
         TabIndex        =   26
         Top             =   2400
         Width           =   255
      End
      Begin VB.CommandButton cmdUneq 
         Caption         =   "U"
         Height          =   255
         Index           =   5
         Left            =   5280
         TabIndex        =   25
         Top             =   2040
         Width           =   255
      End
      Begin VB.CommandButton cmdUneq 
         Caption         =   "U"
         Height          =   255
         Index           =   4
         Left            =   5280
         TabIndex        =   24
         Top             =   1680
         Width           =   255
      End
      Begin VB.CommandButton cmdUneq 
         Caption         =   "U"
         Height          =   255
         Index           =   3
         Left            =   5280
         TabIndex        =   23
         Top             =   1320
         Width           =   255
      End
      Begin VB.CommandButton cmdUneq 
         Caption         =   "U"
         Height          =   255
         Index           =   2
         Left            =   5280
         TabIndex        =   22
         Top             =   960
         Width           =   255
      End
      Begin VB.CommandButton cmdUneq 
         Caption         =   "U"
         Height          =   255
         Index           =   1
         Left            =   5280
         TabIndex        =   21
         Top             =   600
         Width           =   255
      End
      Begin VB.CommandButton cmdUneq 
         Caption         =   "U"
         Height          =   255
         Index           =   0
         Left            =   5280
         TabIndex        =   20
         Top             =   240
         Width           =   255
      End
      Begin VB.CommandButton cmdDone 
         Caption         =   "Done"
         Height          =   495
         Left            =   4680
         TabIndex        =   19
         Top             =   5040
         Width           =   855
      End
      Begin VB.TextBox txEq 
         Height          =   285
         Index           =   7
         Left            =   840
         Locked          =   -1  'True
         TabIndex        =   17
         Text            =   "Text1"
         Top             =   2760
         Width           =   4335
      End
      Begin VB.TextBox txEq 
         Height          =   285
         Index           =   6
         Left            =   840
         Locked          =   -1  'True
         TabIndex        =   16
         Text            =   "Text1"
         Top             =   2400
         Width           =   4335
      End
      Begin VB.TextBox txEq 
         Height          =   285
         Index           =   5
         Left            =   840
         Locked          =   -1  'True
         TabIndex        =   15
         Text            =   "Text1"
         Top             =   2040
         Width           =   4335
      End
      Begin VB.TextBox txEq 
         Height          =   285
         Index           =   4
         Left            =   840
         Locked          =   -1  'True
         TabIndex        =   14
         Text            =   "Text1"
         Top             =   1680
         Width           =   4335
      End
      Begin VB.TextBox txEq 
         Height          =   285
         Index           =   3
         Left            =   840
         Locked          =   -1  'True
         TabIndex        =   13
         Text            =   "Text1"
         Top             =   1320
         Width           =   4335
      End
      Begin VB.TextBox txEq 
         Height          =   285
         Index           =   2
         Left            =   840
         Locked          =   -1  'True
         TabIndex        =   12
         Text            =   "Text1"
         Top             =   960
         Width           =   4335
      End
      Begin VB.TextBox txEq 
         Height          =   285
         Index           =   1
         Left            =   840
         Locked          =   -1  'True
         TabIndex        =   11
         Text            =   "Text1"
         Top             =   600
         Width           =   4335
      End
      Begin VB.TextBox txEq 
         Height          =   285
         Index           =   0
         Left            =   840
         Locked          =   -1  'True
         TabIndex        =   10
         Text            =   "Text1"
         Top             =   240
         Width           =   4335
      End
      Begin VB.Label Label4 
         Caption         =   "R Magic"
         Height          =   255
         Left            =   3240
         TabIndex        =   68
         Top             =   5280
         Width           =   615
      End
      Begin VB.Label Label3 
         Caption         =   "R Elec"
         Height          =   255
         Left            =   3240
         TabIndex        =   67
         Top             =   4920
         Width           =   495
      End
      Begin VB.Label Label2 
         Caption         =   "R Cold"
         Height          =   255
         Left            =   3240
         TabIndex        =   66
         Top             =   4560
         Width           =   495
      End
      Begin VB.Label lblRFire 
         Caption         =   "R Fire"
         Height          =   255
         Left            =   3240
         TabIndex        =   65
         Top             =   4200
         Width           =   495
      End
      Begin VB.Label lblGold 
         Caption         =   "Gold"
         Height          =   255
         Left            =   3240
         TabIndex        =   61
         Top             =   3840
         Width           =   495
      End
      Begin VB.Label Label1 
         Caption         =   "DR"
         Height          =   255
         Left            =   3240
         TabIndex        =   58
         Top             =   3480
         Width           =   615
      End
      Begin VB.Label lblDam 
         Caption         =   "Damage"
         Height          =   255
         Left            =   1680
         TabIndex        =   56
         Top             =   3840
         Width           =   615
      End
      Begin VB.Label lblStats 
         Caption         =   "Strength"
         Height          =   255
         Index           =   0
         Left            =   120
         TabIndex        =   55
         Top             =   3120
         Width           =   615
      End
      Begin VB.Label lblStats 
         Caption         =   "Dexterity"
         Height          =   255
         Index           =   1
         Left            =   120
         TabIndex        =   54
         Top             =   3480
         Width           =   615
      End
      Begin VB.Label lblStats 
         Caption         =   "Constitution"
         Height          =   255
         Index           =   2
         Left            =   120
         TabIndex        =   53
         Top             =   3840
         Width           =   855
      End
      Begin VB.Label lblStats 
         Caption         =   "Intelligence"
         Height          =   255
         Index           =   3
         Left            =   120
         TabIndex        =   52
         Top             =   4200
         Width           =   855
      End
      Begin VB.Label lblStats 
         Caption         =   "Wisdom"
         Height          =   255
         Index           =   4
         Left            =   120
         TabIndex        =   51
         Top             =   4560
         Width           =   615
      End
      Begin VB.Label lblStats 
         Caption         =   "Charisma"
         Height          =   255
         Index           =   5
         Left            =   120
         TabIndex        =   50
         Top             =   4920
         Width           =   735
      End
      Begin VB.Label lblStats 
         Caption         =   "Reputation"
         Height          =   255
         Index           =   6
         Left            =   120
         TabIndex        =   49
         Top             =   5280
         Width           =   855
      End
      Begin VB.Label lblDervs 
         Caption         =   "Str Attack"
         Height          =   255
         Index           =   0
         Left            =   1680
         TabIndex        =   41
         Top             =   3120
         Width           =   735
      End
      Begin VB.Label lblDervs 
         Caption         =   "Dex Attack"
         Height          =   255
         Index           =   1
         Left            =   1680
         TabIndex        =   40
         Top             =   3480
         Width           =   855
      End
      Begin VB.Label lblDervs 
         Caption         =   "Defense"
         Height          =   255
         Index           =   2
         Left            =   3240
         TabIndex        =   39
         Top             =   3120
         Width           =   735
      End
      Begin VB.Label lblDervs 
         Caption         =   "Hit Points"
         Height          =   255
         Index           =   3
         Left            =   1680
         TabIndex        =   38
         Top             =   4200
         Width           =   735
      End
      Begin VB.Label lblDervs 
         Caption         =   "Speed"
         Height          =   255
         Index           =   4
         Left            =   1680
         TabIndex        =   37
         Top             =   4560
         Width           =   735
      End
      Begin VB.Label lblDervs 
         Caption         =   "Perception"
         Height          =   255
         Index           =   5
         Left            =   1680
         TabIndex        =   36
         Top             =   4920
         Width           =   735
      End
      Begin VB.Label lblDervs 
         Caption         =   "Luck"
         Height          =   255
         Index           =   6
         Left            =   1680
         TabIndex        =   35
         Top             =   5280
         Width           =   735
      End
      Begin VB.Label lblEq 
         Caption         =   "Ring"
         Height          =   255
         Index           =   7
         Left            =   120
         TabIndex        =   9
         Top             =   2760
         Width           =   735
      End
      Begin VB.Label lblEq 
         Caption         =   "Ring"
         Height          =   255
         Index           =   6
         Left            =   120
         TabIndex        =   8
         Top             =   2400
         Width           =   735
      End
      Begin VB.Label lblEq 
         Caption         =   "Boots"
         Height          =   255
         Index           =   5
         Left            =   120
         TabIndex        =   7
         Top             =   2040
         Width           =   735
      End
      Begin VB.Label lblEq 
         Caption         =   "Gauntlets"
         Height          =   255
         Index           =   4
         Left            =   120
         TabIndex        =   6
         Top             =   1680
         Width           =   735
      End
      Begin VB.Label lblEq 
         Caption         =   "Helmet"
         Height          =   255
         Index           =   3
         Left            =   120
         TabIndex        =   5
         Top             =   1320
         Width           =   735
      End
      Begin VB.Label lblEq 
         Caption         =   "Shield"
         Height          =   255
         Index           =   2
         Left            =   120
         TabIndex        =   4
         Top             =   960
         Width           =   735
      End
      Begin VB.Label lblEq 
         Caption         =   "Armor"
         Height          =   255
         Index           =   1
         Left            =   120
         TabIndex        =   3
         Top             =   600
         Width           =   735
      End
      Begin VB.Label lblEq 
         Caption         =   "Weapon"
         Height          =   255
         Index           =   0
         Left            =   120
         TabIndex        =   2
         Top             =   240
         Width           =   735
      End
   End
End
Attribute VB_Name = "frmInven"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Public PickUp As Item
Public Used As String

Private Sub cmdDone_Click()
  If frmCombat.InCombat = 1 Then
    frmCombat.Visible = True
    frmCombat.Refresh
  
    If Used <> "" Then
      Call frmCombat.AddEvent("You use a " & Used)
    Else
      Call frmCombat.AddEvent("You fiddle with your equipment.")
    End If
    Used = ""
    Call frmCombat.RefreshCombat
    Call frmCombat.EnemyAttack
  Else
    RefreshGame
  End If
  
  Unload frmInven
End Sub

Private Sub cmdDrop_Click()
  Dim i As Integer
  Dim j As Integer
  Dim ans As VbMsgBoxResult
  If lstInven.ListIndex = -1 Or Left(lstInven.Text, 1) = "-" Then Exit Sub
  
  For i = 0 To C_INVMAX - 1
    If Not char.Player.Inven(i) Is Nothing Then
      If (i = lstInven.ItemData(lstInven.ListIndex)) Then
        For j = 0 To 7
          If char.Player.Inven(i) Is char.Player.Eq(j) Then
            MsgBox "Cannot discard an equipped item."
            Exit Sub
          End If
        Next j
'Right(char.Player.Inven(i).Text, Len(char.Player.Inven(i).Text) - 3)
        ans = MsgBox(lstInven.Text & vbCrLf & "Discard Permanently?", vbYesNo, "Discard?")
        If ans = vbYes Then
          Call char.Player.RemInven(char.Player.Inven(i))
        End If
        RefreshInven
'        RefreshChar
        Exit For
      End If
    End If
  Next i
  
End Sub

Private Sub cmdID_Click()
  Dim i As Integer
  Dim j As Integer
  Dim it As Item
  Dim exp As Integer
  Dim c As Double
  Dim s As String
  
  If lstInven.ListIndex = -1 Or Left(lstInven.Text, 1) = "-" Then Exit Sub
  i = lstInven.ItemData(lstInven.ListIndex)
  
  If Not char.Player.Inven(i) Is Nothing Then
    Set it = char.Player.Inven(i)
    c = ((char.Player.Dervs(D_PER) + char.Player.Reals(S_INT) + char.Player.Reals(S_REP)) / 30)
    c = c / (c + it.Depth)
    If char.Player.Flags And F_TRUE Then
      c = c * 2
    End If
    If (it.ID = False) And it.LastID > GameDate - Max((30 - (char.Player.Reals(S_INT) \ 10)), 1) Then
      MsgBox "You still have no idea what this item is.", , "Identify"
    ElseIf (it.ID = True) Or (Rnd < c) Or frmGame.ckCombat = 1 Then
      If it.ID = False Then
        exp = (it.Depth + 0) * E_POINTS
        char.Player.Points = char.Player.Points + exp
      Else
        exp = 0
      End If
      it.ID = True
      
      s = "You identify the item!" & vbCrLf
      s = s & JustText(it.Text) & vbCrLf & vbCrLf
            
      If it.Flags And F_BLND Then
        s = s & "Radiant" & vbCrLf
      End If
      If it.Flags And F_COLD Then
        s = s & "Frosty" & vbCrLf
      End If
      If it.Flags And F_CONF Then
        s = s & "Prismatic" & vbCrLf
      End If
      If it.Flags And F_ELEC Then
        s = s & "Electric" & vbCrLf
      End If
      If it.Flags And F_FAST Then
        s = s & "Hasted" & vbCrLf
      End If
      If it.Flags And F_FIRE Then
        s = s & "Flaming" & vbCrLf
      End If
      If it.Flags And F_HYPR Then
        s = s & "Hyper" & vbCrLf
      End If
      If it.Flags And F_LIFE Then
        s = s & "Fast Regeneration" & vbCrLf
      End If
      If it.Flags And F_LONG Then
        s = s & "Integer Range" & vbCrLf
      End If
      If it.Flags And F_MAGI Then
        s = s & "Enchanted" & vbCrLf
      End If
      If it.Flags And F_PIRC Then
        s = s & "Vorpal" & vbCrLf
      End If
      If it.Flags And F_POIS Then
        s = s & "Venomous" & vbCrLf
      End If
      If it.Flags And F_REGN Then
        s = s & "Regeneration" & vbCrLf
      End If
      If it.Flags And F_SLEP Then
        s = s & "Sleep" & vbCrLf
      End If
      If it.Flags And F_SLOW Then
        s = s & "Ensnaring" & vbCrLf
      End If
      If it.Flags And F_STUN Then
        s = s & "Stunning" & vbCrLf
      End If
      If it.Flags And F_TRUE Then
        s = s & "Insightful" & vbCrLf
      End If
      If it.Flags And F_VAMP Then
        s = s & "Vampiric" & vbCrLf
      End If
            
      s = s & vbCrLf & "You gain " & exp & " experience points."
      
      MsgBox s, , "Identify"
    Else
'      MsgBox "You don't know what this item is. (" & Round(((char.Player.Dervs(D_PER) + char.Player.Reals(S_INT) + char.Player.Reals(S_REP)) / 30) / (((char.Player.Dervs(D_PER) + char.Player.Reals(S_INT) + char.Player.Reals(S_REP)) / 30) + it.Depth), 2) * 100 & "%)", , "Identify"
      MsgBox "You don't know what this item is. (" & Round(c, 2) * 100 & "%)", , "Identify"
      it.LastID = GameDate
    End If
    RefreshInven
  End If
End Sub

Private Sub cmdPickUp_Click()
  Call char.Player.AddInven(PickUp)
  Set PickUp = Nothing
  RefreshInven
End Sub

Private Sub cmdUneq_Click(index As Integer)
 char.Player.Eq(index) = Nothing
' Call RefreshChar
 Call RefreshInven
End Sub

Private Sub Form_KeyPress(keyascii As Integer)
  If keyascii = 27 Then
    Call cmdDone_Click
  ElseIf keyascii = Asc("i") Or keyascii = Asc("I") Then
    Call cmdID_Click
  End If
  
  keyascii = 0
End Sub

Private Sub Form_Load()
'  lstInven.Sorted = True
'  Call RefreshChar
  Call RefreshInven
End Sub

Public Sub RefreshInven()
  Dim i As Integer
  Dim T As String
  Dim cur As Integer
    
  cur = lstInven.ListIndex
  
  lstInven.Clear
  
  txGold = char.Player.Gold
  
  For i = 0 To C_INVMAX - 1
    If Not char.Player.Inven(i) Is Nothing Then
      T = ItemText(char.Player.Inven(i))
'      If char.Player.Inven(i).Use = E_NON Then
'        T = T & " (" & char.Player.Inven(i).num & ")"
'      End If
      
      If IsEquipped(char.Player.Inven(i)) <> -1 Then
        T = Left(T, 3) & Chr(128) & " " & JustText(T) ' 128, 164
      End If
      
      lstInven.AddItem (T)
      lstInven.ItemData(lstInven.NewIndex) = i
    End If
  Next i
  
  lstInven.AddItem (E_WEP & "-------- Weapons -----")
  lstInven.AddItem (E_ARM & "-------- Armor -------")
  lstInven.AddItem (E_SLD & "-------- Shields -----")
  lstInven.AddItem (E_HLM & "-------- Helms -------")
  lstInven.AddItem (E_GNT & "-------- Gauntlets ---")
  lstInven.AddItem (E_BTS & "-------- Boots -------")
  lstInven.AddItem (E_RG1 & "-------- Rings -------")
  lstInven.AddItem (E_NON & "-------- Misc. -------")
  lstInven.AddItem (Hex(E_TRD) & "-------- Trade Goods, Max:" & char.Player.Cargo & "")
  
  For i = 0 To lstInven.ListCount - 1
    lstInven.List(i) = JustText(lstInven.List(i))
  Next i

  For i = 0 To 7
    If Not char.Player.Eq(i) Is Nothing Then
      txEq(i).Text = JustText(ItemText(char.Player.Eq(i)))
    ElseIf i = 0 Then
      txEq(i).Text = char.Player.HandsText()
    Else
      txEq(i).Text = ""
    End If
  Next i
  
  If lstInven.ListIndex <> -1 Then
    txCur.Text = lstInven.List(lstInven.ListIndex)
    txValue.Text = Int(char.Player.Inven(lstInven.ItemData(lstInven.ListIndex)).Value)
  Else
    txCur.Text = ""
    txValue.Text = ""
  End If
  
'  For i = 0 To C_RESISTS - 1
'    txRes(i).Text = char.Player.Res(i)
'  Next i
  
  If Not PickUp Is Nothing Then
    cmdPickUp.Enabled = True
    txPickUp.Text = Right(ItemText(PickUp), Len(ItemText(PickUp)) - 3)
  Else
    cmdPickUp.Enabled = False
    txPickUp.Text = ""
  End If

  If cur <> -1 Then
    lstInven.Selected(cur) = True
  End If
  RefreshChar

End Sub


Private Sub Form_Unload(cancel As Integer)
  If frmCombat.InCombat = 1 Then
    frmCombat.Visible = True
  End If
End Sub

Private Sub lstInven_Click()
  If lstInven.ListIndex <> -1 And Left(lstInven.List(lstInven.ListIndex), 1) <> "-" Then
    txCur.Text = lstInven.List(lstInven.ListIndex)
    txValue.Text = Int(char.Player.Inven(lstInven.ItemData(lstInven.ListIndex)).Value)
  Else
    txCur.Text = ""
    txValue.Text = ""
  End If
  
End Sub

Private Sub lstInven_DblClick()
  Dim T As String
  Dim i As Integer
  Dim u As Integer
  Dim nnn As String
  
  If Left(lstInven.Text, 1) = "-" Then
    Exit Sub
  End If
  
  i = lstInven.ItemData(lstInven.ListIndex)
  
'  For i = 0 To C_INVMAX - 1
    If Not char.Player.Inven(i) Is Nothing Then
      If char.Player.Inven(i).Use <> E_NON Then
        u = char.Player.Inven(i).Use
        
        If u = E_RG1 Then
          If char.Player.Eq(E_RG1) Is Nothing Then
            char.Player.Eq(E_RG1) = char.Player.Inven(i)
            If char.Player.Eq(E_RG1) Is char.Player.Eq(E_RG2) Then
              char.Player.Eq(E_RG2) = Nothing
            End If
          Else
            char.Player.Eq(E_RG2) = char.Player.Eq(E_RG1)
            char.Player.Eq(E_RG1) = char.Player.Inven(i)
            If char.Player.Eq(E_RG1) Is char.Player.Eq(E_RG2) Then
              char.Player.Eq(E_RG2) = Nothing
            End If
          End If
        Else
          char.Player.Eq(u) = char.Player.Inven(i)
        End If
'        Exit For
      ElseIf char.Player.Inven(i).Use = E_NON Then
        nnn = char.Player.Inven(i).Name
        Call char.Player.Inven(i).UseF(i)
        If char.Player.Inven(i) Is Nothing Then
          lstInven.ListIndex = -1
        End If
        If frmCombat.InCombat = 1 Then
          Used = nnn
          Call cmdDone_Click
        End If
      End If
    End If
'  Next i
  
'  Call RefreshChar
  Call RefreshInven
End Sub

'Private Sub txEq_DblClick(Index As long)
' char.Player.Eq(Index) = Nothing
' Call RefreshInven
' call refreshchar
'End Sub

Public Sub RefreshChar()
  Dim i As Integer
  
  Call char.Player.CalcDervs
  For i = 0 To 6
    txStats(i).Text = Player.Reals(i)
    txDervs(i).Text = Player.Dervs(i)
  Next i
  txDam.Text = Player.Dervs(D_DAM)
  txDR.Text = Player.Dervs(D_DR)
  txGold.Text = Player.Gold
  
  For i = 0 To C_RESISTS - 1
    txRes(i).Text = char.Player.Res(i)
  Next i
  
  
End Sub

