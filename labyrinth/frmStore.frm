VERSION 5.00
Begin VB.Form frmStore 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Store"
   ClientHeight    =   6525
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   10800
   KeyPreview      =   -1  'True
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   ScaleHeight     =   6525
   ScaleWidth      =   10800
   StartUpPosition =   2  'CenterScreen
   Begin VB.Frame frCurrent 
      Caption         =   "Current Item"
      Height          =   615
      Left            =   0
      TabIndex        =   6
      Top             =   5880
      Width           =   10785
      Begin VB.TextBox txCur 
         Height          =   285
         Left            =   120
         Locked          =   -1  'True
         TabIndex        =   7
         Text            =   "Text1"
         Top             =   240
         Width           =   10545
      End
   End
   Begin VB.Frame frStore 
      Caption         =   "Frame1"
      Height          =   5895
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   10785
      Begin VB.CommandButton cmdID 
         Caption         =   "Identify"
         Height          =   255
         Left            =   2040
         TabIndex        =   8
         Top             =   240
         Width           =   1335
      End
      Begin VB.CommandButton cmdDone 
         Caption         =   "Done"
         Height          =   255
         Left            =   9300
         TabIndex        =   5
         Top             =   240
         Width           =   1335
      End
      Begin VB.TextBox txGold 
         Alignment       =   1  'Right Justify
         Height          =   285
         Left            =   960
         Locked          =   -1  'True
         TabIndex        =   4
         Text            =   "Text1"
         Top             =   240
         Width           =   975
      End
      Begin VB.ListBox lstStore 
         Height          =   5130
         Left            =   5460
         Sorted          =   -1  'True
         TabIndex        =   2
         Top             =   600
         Width           =   5175
      End
      Begin VB.ListBox lstInven 
         Height          =   5130
         Left            =   120
         Sorted          =   -1  'True
         TabIndex        =   1
         Top             =   600
         Width           =   5175
      End
      Begin VB.Label lblGold 
         Caption         =   "Gold Coins"
         Height          =   255
         Left            =   120
         TabIndex        =   3
         Top             =   240
         Width           =   855
      End
   End
End
Attribute VB_Name = "frmStore"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Public s As Store

Public Sub LoadStore(l As Integer, i As Integer)
  Set s = World.World(l).LCity.Stores(i)
  
  RefreshStore
End Sub

Public Sub RefreshStore()
  Dim i As Integer
  Dim T As String
  
  lstInven.Clear
  lstStore.Clear
  
  txGold.Text = char.Player.Gold
  frStore.Caption = ""
  
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
  For i = 0 To C_INVMAX - 1
    If Not s.Inven(i) Is Nothing Then
      
      T = ItemText(s.Inven(i))
'      T = "[" & Price(S.Inven(i), 1) & "]  " & JustText(T)
'      If S.Inven(i).Use = E_NON Then
'        T = T & " (" & S.Inven(i).num & ")"
'      End If
      
      Call lstStore.AddItem(T)
      lstStore.ItemData(lstStore.NewIndex) = i
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
  
  lstStore.AddItem (E_WEP & "-------- Weapons -----")
  lstStore.AddItem (E_ARM & "-------- Armor -------")
  lstStore.AddItem (E_SLD & "-------- Shields -----")
  lstStore.AddItem (E_HLM & "-------- Helms -------")
  lstStore.AddItem (E_GNT & "-------- Gauntlets ---")
  lstStore.AddItem (E_BTS & "-------- Boots -------")
  lstStore.AddItem (E_RG1 & "-------- Rings -------")
  lstStore.AddItem (E_NON & "-------- Misc. -------")
  lstStore.AddItem (Hex(E_TRD) & "-------- Trade Goods -")
  
  For i = 0 To lstInven.ListCount - 1
    If Left(JustText(lstInven.List(i)), 1) <> "-" Then
      If char.Player.Inven(lstInven.ItemData(i)).Use = E_TRD Then
        lstInven.List(i) = "[" & PadSpaces(TGPrice(char.Player.Inven(lstInven.ItemData(i)), s, 0), 10) & "]  " & JustText(lstInven.List(i))
      Else
        lstInven.List(i) = "[" & PadSpaces(Price(char.Player.Inven(lstInven.ItemData(i)).Value, 0), 10) & "]  " & JustText(lstInven.List(i))
      End If
    Else
      lstInven.List(i) = JustText(lstInven.List(i))
    End If
  Next i
  For i = 0 To lstStore.ListCount - 1
    If Left(JustText(lstStore.List(i)), 1) <> "-" Then
      Dim it As Item
      Set it = s.Inven(lstStore.ItemData(i))
      
      If it.Use = E_SER Then
        If InStr(1, it.BaseName, "Blessing") Then
          If Not char.Player.Eq(it.Notes) Is Nothing Then
            it.Value = Price(char.Player.Eq(it.Notes).Value, 1) * (I_MANT ^ (it.Depth)) - Price(char.Player.Eq(it.Notes).Value, 0)
          Else
            it.Value = 0
          End If
        ElseIf InStr(1, it.BaseName, "Carnival Game") Then
            it.Value = AtrCost(char.Player.Stats(it.Notes) + 1) * 4 * (I_MANT ^ (char.Player.Stats(it.Notes) / 10))
        End If
      End If
      
      If it.Use = E_TRD Then
        lstStore.List(i) = "[" & PadSpaces(TGPrice(s.Inven(lstStore.ItemData(i)), s, 1), 10) & "]  " & JustText(lstStore.List(i))
      Else
        lstStore.List(i) = "[" & PadSpaces(Price(s.Inven(lstStore.ItemData(i)).Value, 1), 10) & "]  " & JustText(lstStore.List(i))
      End If
      
    Else
      lstStore.List(i) = JustText(lstStore.List(i))
    End If
  Next i
  
  For i = 0 To lstStore.ListCount - 2
    If Left(lstStore.List(i), 1) = "-" And Left(lstStore.List(i + 1), 1) = "-" Then
      Call lstStore.RemoveItem(i)
      i = i - 1
    End If
  Next i

  If Left(lstStore.List(lstStore.ListCount - 1), 1) = "-" Then
    Call lstStore.RemoveItem(lstStore.ListCount - 1)
  End If

  If lstInven.ListIndex <> -1 Then
    txCur.Text = lstInven.List(lstInven.ListIndex)
  ElseIf lstStore.ListIndex <> -1 Then
    txCur.Text = lstStore.List(lstStore.ListIndex)
  Else
    txCur.Text = ""
  End If


End Sub

Private Sub cmdDone_Click()
  frmStore.Visible = False
  Unload frmStore
End Sub

Private Sub cmdID_Click()
  Dim Res As VbMsgBoxResult
  Dim d As String
  Dim it As Item
  Dim index As Integer
  Dim cost As Double
  
  If lstInven.ListIndex = -1 Or Left(lstInven.List(lstInven.ListIndex), 1) = "-" Then Exit Sub

  index = lstInven.ItemData(lstInven.ListIndex)
  Set it = char.Player.Inven(index)
  
  d = JustText(ItemText(it))
  cost = Price(it.Value \ 10, 1)
  
  Res = MsgBox("Do you wish to identify:" & vbCrLf & d & vbCrLf & "For " & cost & " gold coins?", vbYesNo, "Buy Item")
  
  If Res = vbYes And char.Player.Gold >= cost Then
    char.Player.Gold = char.Player.Gold - cost
    it.ID = True
  ElseIf Res = vbYes Then
    MsgBox "You don't have enough gold!", , "Identify"
  End If
  
  RefreshStore

End Sub

Private Sub Form_KeyPress(keyascii As Integer)
  If keyascii = 27 Then
    Call cmdDone_Click
  ElseIf keyascii = Asc("i") Or keyascii = Asc("I") Then
    Call cmdID_Click
  End If
End Sub

Private Sub lstInven_DblClick()
  Dim Res As VbMsgBoxResult
  Dim d As String
  Dim it As Item
  Dim index As Integer
  Dim cost As Long
  
  If Left(lstInven.List(lstInven.ListIndex), 1) = "-" Then Exit Sub
  
  index = lstInven.ItemData(lstInven.ListIndex)
  Set it = char.Player.Inven(index)
  
  d = JustText(ItemText(it))
  
  If it.Use = E_TRD Then
    cost = TGPrice(it, s, 0)
  Else
    cost = Price(it.Value, 0)
  End If
  
  Res = MsgBox("Do you wish to sell:" & vbCrLf & d & vbCrLf & "For " & cost & " gold coins?", vbYesNo, "Sell Item")
  
  If Res = vbYes Then
    it.ID = True
    Call s.AddInven(it, 1)
    Call char.Player.RemInven(it, 1)
    char.Player.Gold = char.Player.Gold + cost
    Call char.Player.CalcDervs
  End If
  RefreshStore
End Sub

Private Sub lstStore_DblClick()
  Dim Res As VbMsgBoxResult
  Dim d As String
  Dim it As Item
  Dim index As Integer
  Dim cost As Double
  
  index = lstStore.ItemData(lstStore.ListIndex)
  Set it = s.Inven(index)
  
  d = JustText(ItemText(it))
  
  If s.Inven(index).Use = E_TRD Then
    cost = TGPrice(s.Inven(index), s, 1)
  Else
    cost = Price(s.Inven(index).Value, 1)
  End If
  
  Res = MsgBox("Do you wish to buy:" & vbCrLf & d & vbCrLf & "For " & cost & " gold coins?", vbYesNo, "Buy Item")
  
  If Res = vbYes And char.Player.Gold >= cost And it.Use = E_SER Then
    char.Player.Gold = char.Player.Gold - cost
    Call it.UseF(-1)
  ElseIf Res = vbYes And char.Player.Gold >= cost Then
    it.ID = True
    Call char.Player.AddInven(it, 1)
    Call s.RemInven(it, 1)
    char.Player.Gold = char.Player.Gold - cost
  ElseIf Res = vbYes Then
    MsgBox "You don't have enough gold!", , "Buy Item"
  End If
  
  RefreshStore
End Sub
Private Sub lstInven_Click()
  If lstInven.ListIndex <> -1 And Left(lstInven.List(lstInven.ListIndex), 1) <> "-" Then
    txCur.Text = lstInven.List(lstInven.ListIndex)
  Else
    txCur.Text = ""
  End If
  
End Sub
Private Sub lstStore_Click()
  If lstStore.ListIndex <> -1 And Left(lstStore.List(lstStore.ListIndex), 1) <> "-" Then
    txCur.Text = lstStore.List(lstStore.ListIndex)
  Else
    txCur.Text = ""
  End If
  
End Sub

