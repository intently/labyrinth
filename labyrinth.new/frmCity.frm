VERSION 5.00
Begin VB.Form frmCity 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "City"
   ClientHeight    =   3870
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   3510
   KeyPreview      =   -1  'True
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   ScaleHeight     =   3870
   ScaleWidth      =   3510
   StartUpPosition =   2  'CenterScreen
   Begin VB.Frame frInfo 
      Height          =   3855
      Left            =   0
      TabIndex        =   7
      Top             =   0
      Width           =   1935
      Begin VB.TextBox txInfo 
         Height          =   2895
         Left            =   120
         MultiLine       =   -1  'True
         TabIndex        =   9
         Text            =   "frmCity.frx":0000
         Top             =   240
         Width           =   1695
      End
      Begin VB.CommandButton cmdLeave 
         Caption         =   "Leave"
         Height          =   495
         Left            =   360
         TabIndex        =   8
         Top             =   3240
         Width           =   1215
      End
   End
   Begin VB.Frame frCity 
      Caption         =   "Buildings"
      Height          =   3855
      Left            =   2040
      TabIndex        =   0
      Top             =   0
      Width           =   1455
      Begin VB.CommandButton cmdStores 
         Caption         =   "Magic Shop"
         Height          =   495
         Index           =   3
         Left            =   120
         TabIndex        =   4
         Top             =   2040
         Width           =   1215
      End
      Begin VB.CommandButton cmdStores 
         Caption         =   "Inn"
         Height          =   495
         Index           =   4
         Left            =   120
         TabIndex        =   5
         Top             =   2640
         Width           =   1215
      End
      Begin VB.CommandButton cmdStores 
         Caption         =   "General Store"
         Height          =   495
         Index           =   2
         Left            =   120
         TabIndex        =   3
         Top             =   1440
         Width           =   1215
      End
      Begin VB.CommandButton cmdStores 
         Caption         =   "Armor"
         Height          =   495
         Index           =   1
         Left            =   120
         TabIndex        =   2
         Top             =   840
         Width           =   1215
      End
      Begin VB.CommandButton cmdStores 
         Caption         =   "Weapons"
         Height          =   495
         Index           =   0
         Left            =   120
         TabIndex        =   1
         Top             =   240
         Width           =   1215
      End
      Begin VB.CommandButton cmdStores 
         Caption         =   "Market"
         Height          =   495
         Index           =   5
         Left            =   120
         TabIndex        =   6
         Top             =   3240
         Width           =   1215
      End
      Begin VB.CommandButton cmdExplore 
         Caption         =   "Explore"
         Height          =   495
         Left            =   120
         TabIndex        =   10
         Top             =   3240
         Width           =   1215
      End
   End
End
Attribute VB_Name = "frmCity"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Public LCity As City
Public t_Build As Integer

Private Sub cmdExplore_Click()
  Dim monstername As String
  Dim i As Integer
  Dim it As Item
  
  If LCity.T = "Haunted House" Then
    monstername = SelectMonster(T_GHOST, LCity.Conts)
    Call frmCombat.StartCombat(monstername, LCity.Conts, frmCity)
  ElseIf LCity.T = "Fairy Pond" Then
    If Day(GameDate) = LCity.Conts Then
      Dim offer As Integer
      Dim cost As Long
      Dim ans As VbMsgBoxResult
      char.Player.Dervs(D_CHP) = char.Player.Dervs(D_HTP)
      MsgBox "You drink from the pure, clear water." & vbCrLf & "Your hit points are restored!", , "Fairy Pond"
      
      ans = MsgBox("As you raise your head from the water," & vbCrLf & "you find yourself eye to eye" & vbCrLf & "with tiny winged woman." & vbCrLf & "In a musical voice, she offers to" & vbCrLf & "use her magic on your behalf for a" & vbCrLf & "token from your treasure." & vbCrLf & vbCrLf & "Do you accept?", vbYesNo, "Fairy Encounter")
      If ans = vbYes Then
        offer = Int(Rnd * (C_STATS + 1))
        cost = Int(Rnd * 100) * char.Player.Reals(S_REP)
        If cost > char.Player.Gold Then
          MsgBox "The fairy laughs at your pitiful treasure, and disappears!", , "Fairy Encounter"
        Else
          char.Player.Gold = char.Player.Gold - cost
          If offer < C_STATS Then
            char.Player.Stats(offer) = char.Player.Stats(offer) + 1
          Else
            For i = 0 To C_STATS - 1
              char.Player.Stats(i) = char.Player.Stats(i) + 1
            Next i
          End If
          MsgBox "The fairy waves her tiny hand at you" & vbCrLf & "and you feel a tingle run through your body." & vbCrLf & "She then disappears, and your purse feels lighter.", , "Fairy Encounter"
        End If
      Else
        MsgBox "The fairy sticks out her tiny tongue at you and disappears.", , "Fairy Encounter"
      End If
      LCity.Conts = Int(Rnd * 31) + 1
    Else
      char.Player.Dervs(D_CHP) = char.Player.Dervs(D_HTP)
      MsgBox "You drink from the pure, clear water." & vbCrLf & "Your hit points are restored!", , "Fairy Pond"
    End If
  ElseIf LCity.T = "Goblin Mine" Then
    If Int(Rnd * 35) > LCity.Conts Then
      MsgBox "As you are scrounging around the mine, you are discovered!"
      monstername = SelectMonster(T_GOBLIN, LCity.Conts)
      Call frmCombat.StartCombat(monstername, LCity.Conts, frmCity)
      LCity.Conts = Max(LCity.Conts - 5, 0)
    Else
      Dim g As Integer
      g = TG(LCity.Depth)
      MsgBox "You search the mine and find " & g & " gold coins!"
      Player.Gold = Player.Gold + g
      LCity.Conts = Max(LCity.Conts - 2, 0)
    End If
  ElseIf LCity.T = "Mystic Sage" Then
    frmStore.Visible = True
    Call frmStore.LoadStore(Loc, 0)
  ElseIf LCity.T = "Temple" Then
    frmStore.Visible = True
    Call frmStore.LoadStore(Loc, 0)
  ElseIf LCity.T = "Academy" Then
    frmStore.Visible = True
    Call frmStore.LoadStore(Loc, 0)
  ElseIf LCity.T = "Carnival" Then
    frmStore.Visible = True
    Call frmStore.LoadStore(Loc, 0)
  ElseIf LCity.T = "Ancient Ruins" Then
    If Int(Rnd * 100) < LCity.Conts Then
      Set it = New Item
      Call it.Create(Int(Rnd * 4), Min(LCity.Depth + 1 + Int(Rnd * 3), 21))
      it.Value = Int(it.Value / 2)
      it.ID = False
      
      Call MsgBox("You find a " & JustText(ItemText(it)) & " hidden amidst the ruins!", , "You find an item!")
          
      Call char.Player.AddInven(it)
      LCity.Conts = 0
    Else
      Call MsgBox("You wander around for a while, but you don't find anything.", , "You find nothing!")
      LCity.Conts = 0
    End If
  ElseIf LCity.T = "Monster Graveyard" Then
    If Int(Rnd * 10) + 1 < LCity.Conts Then
      Set it = New Item
      Call it.MakeItem(1, 1, "Body Part", Int(Rnd * T_MAXUSED), Max(0, Min(20, Int(LCity.Conts / 20) - 2 + LCity.Depth)), , , , , True)
      
      it.Value = Int(it.Value / 2)
      it.ID = True
      
      Call MsgBox("You find " & JustText(ItemText(it)) & " in plain sight!", , "You find an item!")
          
      Call char.Player.AddInven(it)
      LCity.Conts = Max(LCity.Conts - 10, 0)
    Else
      Call MsgBox("You wander around for a while, but you don't find anything.", , "You find nothing!")
      LCity.Conts = Max(LCity.Conts - 10, 0)
    End If
  End If
  RefreshCity
End Sub

Private Sub cmdExplore_GotFocus()
  RefreshCity
End Sub

Private Sub cmdLeave_Click()
  LCity.LastExplored = GameDate
  
  frmGame.Visible = True
  RefreshGame
  Unload frmCity
  Unload frmStore
End Sub

Private Sub cmdStores_Click(index As Integer)
  Dim cost As Double
  Dim st As String
  Dim ans As VbMsgBoxResult
  
  If LCity.T = "City" Then
    frmStore.Visible = True
    Call frmStore.LoadStore(Loc, index)
  ElseIf LCity.T = "Castle" Then
    If cmdStores(index).Caption = "Bank" Then
      If t_Build = 1 And LCity.Castle(B_BANK) < 3 Then
        cost = I_BASE * 2 * (I_MANT ^ (LCity.Depth + LCity.Castle(B_BANK)))
        If char.Player.Gold >= I_BASE * 2 * (I_MANT ^ (LCity.Depth + LCity.Castle(B_BANK))) Then
          ans = MsgBox("Do you want to spend " & cost & " to upgrade your Bank?" & vbCrLf & "You have " & char.Player.Gold & " gold.", vbYesNo, "Bank Upgrade")
          
          If ans = vbYes Then
            char.Player.Gold = char.Player.Gold - cost
            LCity.Castle(B_BANK) = LCity.Castle(B_BANK) + 1
          Else
            
          End If
        Else
          Call MsgBox("You don't have the " & cost & " gold in your inventory required to upgrade your Bank.")
        End If
      Else 'If LCity.Castle(B_BANK) > 0 Then
        st = InputBox("Deposit how much gold?" & vbCrLf & "(Use negative numbers to make withdrawls.)" & vbCrLf & vbCrLf & "Money on hand: " & char.Player.Gold & vbCrLf & "Money in bank: " & LCity.Conts, "Bank Transaction", "0")
        If Left(st, 1) <> "-" Then
          st = "0" & st
        End If
'        If Len(st) > 0 Then
          cost = Int(CDbl(Val(st)))
'        Else
'          cost = 0
'        End If
'        cost = Int(cost)
        If cost < 0 Then
          cost = Abs(cost)
          If cost > LCity.Conts Then
            cost = LCity.Conts
            Call MsgBox("You only have " & cost & " gold in the bank here.", , "Not enough funds!")
          End If
          char.Player.Gold = char.Player.Gold + cost
          LCity.Conts = LCity.Conts - cost
          Call MsgBox("You withdraw " & cost & " gold from the bank.", , "Withdrawl")
        Else
          If cost > char.Player.Gold Then
            cost = char.Player.Gold
            Call MsgBox("You only have " & cost & " gold with you.", , "Not enough gold!")
          End If
          char.Player.Gold = char.Player.Gold - cost
          LCity.Conts = LCity.Conts + cost
          Call MsgBox("You deposit " & cost & " gold into the bank.", , "Deposit")
        End If
      End If
      t_Build = 0
    ElseIf cmdStores(index).Caption = "Market" Then
      If t_Build = 1 And LCity.Castle(B_MARK) < 3 Then
        cost = I_BASE * 2 * (I_MANT ^ (LCity.Depth + LCity.Castle(B_MARK)))
        If char.Player.Gold >= I_BASE * 2 * (I_MANT ^ (LCity.Depth + LCity.Castle(B_MARK))) Then
          ans = MsgBox("Do you want to spend " & cost & " to upgrade your Market?" & vbCrLf & "You have " & char.Player.Gold & " gold.", vbYesNo, "Market Upgrade")
          
          If ans = vbYes Then
            char.Player.Gold = char.Player.Gold - cost
            LCity.Castle(B_MARK) = LCity.Castle(B_MARK) + 1
            LCity.Stores(0).Depth = LCity.Stores(0).Depth + 1
          Else
            
          End If
        Else
          Call MsgBox("You don't have the " & cost & " gold in your inventory required to upgrade your Market.")
        End If
      Else
        frmStore.Visible = True
        Call frmStore.LoadStore(Loc, 0)
      End If
      t_Build = 0
    ElseIf cmdStores(index).Caption = "Trainer" Then
      If t_Build = 1 And LCity.Castle(B_TRAN) < 3 Then
        cost = I_BASE * 2 * (I_MANT ^ (LCity.Depth + LCity.Castle(B_TRAN)))
        If char.Player.Gold >= I_BASE * 2 * (I_MANT ^ (LCity.Depth + LCity.Castle(B_TRAN))) Then
          ans = MsgBox("Do you want to spend " & cost & " to upgrade your Trainer?" & vbCrLf & "You have " & char.Player.Gold & " gold.", vbYesNo, "Trainer Upgrade")
          
          If ans = vbYes Then
            char.Player.Gold = char.Player.Gold - cost
            LCity.Castle(B_TRAN) = LCity.Castle(B_TRAN) + 1
          Else
            
          End If
        Else
          Call MsgBox("You don't have the " & cost & " gold in your inventory required to upgrade your Trainer.")
        End If
      Else
        If LCity.Pop > 0 Then
          Call MsgBox("You undergo rigorous training, and gain " & LCity.Pop & " experience points.", , "Trainer")
          char.Player.Points = char.Player.Points + LCity.Pop
          LCity.Pop = 0
        Else
          Call MsgBox("There is nothing more you can learn here, now.", , "Trainer")
        End If
      End If
      t_Build = 0
    ElseIf cmdStores(index).Caption = "Defense" Then
      If t_Build = 1 And LCity.Castle(B_WALL) < 3 Then
        cost = I_BASE * 2 * (I_MANT ^ (LCity.Depth + LCity.Castle(B_WALL)))
        If char.Player.Gold >= I_BASE * 2 * (I_MANT ^ (LCity.Depth + LCity.Castle(B_WALL))) Then
          ans = MsgBox("Do you want to spend " & cost & " to upgrade your Defense?" & vbCrLf & "You have " & char.Player.Gold & " gold.", vbYesNo, "Defense Upgrade")
          
          If ans = vbYes Then
            char.Player.Gold = char.Player.Gold - cost
            LCity.Castle(B_WALL) = LCity.Castle(B_WALL) + 1
          Else
            
          End If
        Else
          Call MsgBox("You don't have the " & cost & " gold in your inventory required to upgrade your Defense.")
        End If
      Else
        Dim s As String
        
        s = "Current defensive level: " & LCity.Castle(B_WALL) & "." & vbCrLf & vbCrLf
        If LCity.Castle(B_BANK) > 0 Then
          s = s & "Current monthly interest rate: " & Round((1 + (LCity.Castle(B_BANK) * (0.05) + (LCity.Depth / 100))), 2) & "%" & vbCrLf
        End If
        If LCity.Castle(B_MARK) > 0 Then
          s = s & "Current monthly store income: " & Round(I_BASE * I_MANT ^ (LCity.Castle(B_MARK) + (LCity.Depth - 1)), 0)
        End If
        Call MsgBox(s, , "Defense Report")
      End If
      t_Build = 0
    ElseIf cmdStores(index).Caption = "Special" Then
      t_Build = 0
    ElseIf cmdStores(index).Caption = "Build" Then
      If t_Build = 0 Then
        t_Build = 1
        Call MsgBox("Click the button for the structure you want to build or upgrade.", , "Building Activated")
      Else
        t_Build = 0
        Call MsgBox("Build cancelled.", , "Building cancelled")
      End If
    End If
    RefreshCity
  End If
End Sub

Public Sub RefreshCity()
  Dim i As Integer
  
  frmGame.Visible = False
  
  Set LCity = World.World(Loc).LCity
  frInfo.Caption = LCity.Name
  frmCity.Caption = LCity.T
  txInfo.Text = ""
    
  If LCity.T = "City" Then
    For i = 0 To C_STORES - 1
      If LCity.Stores(i).T <> -1 Then
        cmdStores(i).Enabled = True
      Else
        cmdStores(i).Enabled = False
      End If
    Next i
    
    cmdStores(0).Caption = "Weapons"
    cmdStores(1).Caption = "Armor"
    cmdStores(2).Caption = "General Store"
    cmdStores(3).Caption = "Magic Shop"
    cmdStores(4).Caption = "Inn"
    cmdStores(5).Caption = "Market"
    
    cmdExplore.Visible = False
    txInfo.Text = txInfo.Text & "The City of " & LCity.Name & "." & vbCrLf
    txInfo.Text = txInfo.Text & LCity.Desc & vbCrLf
  ElseIf LCity.T = "Castle" Then
  
    If LCity.Castle(B_BANK) > 0 Or t_Build = 1 Then
      cmdStores(0).Enabled = True
    Else
      cmdStores(0).Enabled = False
    End If
    
    If LCity.Castle(B_MARK) > 0 Or t_Build = 1 Then
      cmdStores(1).Enabled = True
    Else
      cmdStores(1).Enabled = False
    End If
    
    If LCity.Castle(B_TRAN) > 0 Or t_Build = 1 Then
      cmdStores(2).Enabled = True
    Else
      cmdStores(2).Enabled = False
    End If
    
    If LCity.Castle(B_WALL) > 0 Or t_Build = 1 Then
      cmdStores(3).Enabled = True
    Else
      cmdStores(3).Enabled = False
    End If
    
    If LCity.Castle(B_SPEC) > 0 Or t_Build = 1 Then
      cmdStores(4).Enabled = True
    Else
      cmdStores(4).Enabled = False
    End If
  
    cmdStores(0).Caption = "Bank"
    cmdStores(1).Caption = "Market"
    cmdStores(2).Caption = "Trainer"
    cmdStores(3).Caption = "Defense"
    cmdStores(4).Caption = "Special"
    cmdStores(5).Caption = "Build"
    
    cmdExplore.Visible = False
    
    i = LCity.Castle(B_BANK) + LCity.Castle(B_MARK) + LCity.Castle(B_SPEC) + LCity.Castle(B_TRAN) + LCity.Castle(B_WALL)
    
    If i = 0 Then
      LCity.Desc = "You have built a castle here.  It is currently little more than a foundation."
    ElseIf i < 5 Then
      LCity.Desc = "You have built a castle here.  It isn't very developed yet, but construction is coming along nicely."
    ElseIf i < 10 Then
      LCity.Desc = "You have built a castle here.  You have built several buildings, and the castle is quite imposing."
    ElseIf i < 15 Then
      LCity.Desc = "You have built a castle here.  Few other castles can match its excellence."
    ElseIf i = 15 Then
      LCity.Desc = "You have built a castle here.  Construction is complete, and your castle reigns supreme over the surrounding countryside."
    End If
    
    LCity.Desc = LCity.Desc & vbCrLf
    LCity.Desc = LCity.Desc & LCity.Castle(B_BANK) & ": Bank level" & vbCrLf
    LCity.Desc = LCity.Desc & LCity.Castle(B_MARK) & ": Market level" & vbCrLf
    LCity.Desc = LCity.Desc & LCity.Castle(B_TRAN) & ": Trainer level" & vbCrLf
    LCity.Desc = LCity.Desc & LCity.Castle(B_WALL) & ": Defense level" & vbCrLf
    LCity.Desc = LCity.Desc & LCity.Castle(B_SPEC) & ": Special level" & vbCrLf
    
    txInfo.Text = txInfo.Text & LCity.Name & vbCrLf
    txInfo.Text = txInfo.Text & LCity.Desc & vbCrLf
  Else
    For i = 0 To C_STORES - 1
      cmdStores(i).Enabled = False
      cmdStores(i).Visible = False
    Next i
    cmdExplore.Visible = True
    frInfo.Caption = LCity.T
    txInfo.Text = LCity.Desc

    If LCity.T = "Haunted House" Then
      If LCity.Conts = 0 Then
        txInfo.Text = txInfo.Text & vbCrLf & vbCrLf & "You have not yet explored this Haunted House." & vbCrLf & vbCrLf & "Click the 'Explore' button to enter."
      ElseIf LCity.Conts < 21 Then
        txInfo.Text = txInfo.Text & vbCrLf & vbCrLf & "Click the 'Explore' button to enter."
      ElseIf LCity.Conts >= 21 Then
        txInfo.Text = txInfo.Text & vbCrLf & vbCrLf & "You have already vanquished the spirits from this once-Haunted House."
        cmdExplore.Enabled = False
      End If
    ElseIf LCity.T = "Fairy Pond" Then
    ElseIf LCity.T = "Crossroad" Then
      cmdExplore.Visible = False
      cmdStores(S_INN).Enabled = True
      cmdStores(S_INN).Visible = True
    ElseIf LCity.T = "Goblin Mine" Then
      LCity.Conts = Min(30, LCity.Conts + GameDate - LCity.LastExplored)
      If LCity.Conts = 30 Then
        txInfo.Text = txInfo.Text & vbCrLf & vbCrLf & "There does not appear to be much activity." & vbCrLf & vbCrLf & "Click the 'Explore' button to enter."
      ElseIf LCity.Conts >= 20 And LCity.Conts < 30 Then
        txInfo.Text = txInfo.Text & vbCrLf & vbCrLf & "You hear goblin patrols moving beneath you." & vbCrLf & vbCrLf & "Click the 'Explore' button to enter."
      ElseIf LCity.Conts >= 10 And LCity.Conts < 20 Then
        txInfo.Text = txInfo.Text & vbCrLf & vbCrLf & "You hear the sounds of shouting and running coming from the mine." & vbCrLf & vbCrLf & "Click the 'Explore' button to enter."
      ElseIf LCity.Conts > 0 And LCity.Conts < 10 Then
        txInfo.Text = txInfo.Text & vbCrLf & vbCrLf & "You see goblins searching about for an intruder." & vbCrLf & vbCrLf & "Click the 'Explore' button to enter."
      ElseIf LCity.Conts = 0 Then
        txInfo.Text = txInfo.Text & vbCrLf & vbCrLf & "Goblin guards are actively patrolling the mine enterance." & vbCrLf & vbCrLf & "Click the 'Explore' button to enter."
      End If
    ElseIf LCity.T = "Mystic Sage" Then
    
    ElseIf LCity.T = "Ancient Ruins" Then
      LCity.Conts = Min(100, LCity.Conts + GameDate - LCity.LastExplored)
    
      If LCity.Conts = 100 Then
        txInfo.Text = txInfo.Text & vbCrLf & vbCrLf & "Your treasure-sense is tingling."
      ElseIf LCity.Conts >= 75 Then
        txInfo.Text = txInfo.Text & vbCrLf & vbCrLf & "There's treasure in there somewhere, you can feel it."
      ElseIf LCity.Conts >= 50 Then
        txInfo.Text = txInfo.Text & vbCrLf & vbCrLf & "You've got a good feeling about this place."
      ElseIf LCity.Conts >= 25 Then
        txInfo.Text = txInfo.Text & vbCrLf & vbCrLf & "You don't feel like searching this place again."
      Else
        txInfo.Text = txInfo.Text & vbCrLf & vbCrLf & "You've been up and down every corridor, you doubt there's anything left."
      End If
    ElseIf LCity.T = "Monster Graveyard" Then
      LCity.Conts = Min(100, LCity.Conts + GameDate - LCity.LastExplored)
    
      If LCity.Conts = 100 Then
        txInfo.Text = txInfo.Text & vbCrLf & vbCrLf & "There are amazing pieces all around you!"
      ElseIf LCity.Conts >= 75 Then
        txInfo.Text = txInfo.Text & vbCrLf & vbCrLf & "A few well-preserved monster parts are scattered around."
      ElseIf LCity.Conts >= 50 Then
        txInfo.Text = txInfo.Text & vbCrLf & vbCrLf & "There are some good parts, but you'll have to dig."
      ElseIf LCity.Conts >= 25 Then
        txInfo.Text = txInfo.Text & vbCrLf & vbCrLf & "The place is nearly picked clean."
      Else
        txInfo.Text = txInfo.Text & vbCrLf & vbCrLf & "All that's left is garbage."
      End If
      
    End If
  End If
  
  LCity.LastExplored = GameDate
  
End Sub


Private Sub Form_Load()
  t_Build = 0
  RefreshCity
End Sub
Private Sub Form_KeyPress(keyascii As Integer)
  If keyascii = 27 Then
    Call cmdLeave_Click
  End If
End Sub

