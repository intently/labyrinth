VERSION 5.00
Object = "{DC4027A0-633A-11D1-943D-444553540000}#1.0#0"; "ctlist32.ocx"
Begin VB.Form frmCombat 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Combat"
   ClientHeight    =   7650
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   5715
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   ScaleHeight     =   7650
   ScaleWidth      =   5715
   StartUpPosition =   2  'CenterScreen
   Begin CTLISTLibCtl.ctList lstSpells 
      Height          =   3735
      Left            =   0
      TabIndex        =   10
      TabStop         =   0   'False
      Top             =   3900
      Width           =   5685
      _Version        =   65536
      _ExtentX        =   10028
      _ExtentY        =   6588
      _StockProps     =   77
      BackColor       =   16777215
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BeginProperty TitleFont {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BeginProperty HeaderFont {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      TitleBackImage  =   "frmCombat.frx":0000
      HeaderPicture   =   "frmCombat.frx":001C
      Picture         =   "frmCombat.frx":0038
      CheckPicDown    =   "frmCombat.frx":0054
      CheckPicUp      =   "frmCombat.frx":0070
      BreakChar       =   "|"
      HeaderAlign     =   0
      SortDirection   =   1
      SortColumn      =   2
      ShowHeader      =   -1  'True
      AlternateColor  =   -1  'True
      HorzGridLines   =   -1  'True
      VertGridLines   =   -1  'True
      SortArrows      =   0   'False
      HeaderData      =   "frmCombat.frx":008C
   End
   Begin VB.CommandButton cmdLook 
      Caption         =   "Examine"
      Height          =   255
      Left            =   1680
      TabIndex        =   5
      Top             =   3000
      Width           =   975
   End
   Begin VB.CommandButton cmdWait 
      Caption         =   "Wait"
      Height          =   495
      Left            =   1500
      TabIndex        =   2
      Top             =   3360
      Width           =   1215
   End
   Begin VB.TextBox txEnemyName 
      Height          =   285
      Left            =   3750
      Locked          =   -1  'True
      TabIndex        =   8
      TabStop         =   0   'False
      Text            =   "Text1"
      Top             =   3000
      Width           =   1935
   End
   Begin VB.TextBox txHP 
      Alignment       =   1  'Right Justify
      Height          =   285
      Left            =   720
      Locked          =   -1  'True
      TabIndex        =   7
      TabStop         =   0   'False
      Text            =   "Text1"
      Top             =   3000
      Width           =   855
   End
   Begin VB.CommandButton cmdRun 
      Caption         =   "Flee"
      Height          =   495
      Left            =   4500
      TabIndex        =   4
      Top             =   3360
      Width           =   1215
   End
   Begin VB.CommandButton cmdInven 
      Caption         =   "Inventory"
      Height          =   495
      Left            =   3000
      TabIndex        =   3
      Top             =   3360
      Width           =   1215
   End
   Begin VB.CommandButton cmdAttack 
      Caption         =   "Attack"
      Height          =   495
      Left            =   0
      TabIndex        =   1
      Top             =   3360
      Width           =   1215
   End
   Begin VB.ListBox lstEvents 
      Height          =   2985
      Left            =   0
      TabIndex        =   0
      TabStop         =   0   'False
      Top             =   0
      Width           =   5685
   End
   Begin VB.Label lblEnemyName 
      Caption         =   "Enemy Name"
      Height          =   255
      Left            =   2760
      TabIndex        =   9
      Top             =   3000
      Width           =   975
   End
   Begin VB.Label lblHP 
      Caption         =   "Hit Points"
      Height          =   255
      Left            =   0
      TabIndex        =   6
      Top             =   3000
      Width           =   855
   End
End
Attribute VB_Name = "frmCombat"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Public Turn As Integer
Public Enemy As Monster
Public Player As Character
Public PTime As Integer
Public ETime As Integer
Public InCombat As Integer
Public lastForm As Form

Public Sub AddEvent(s As String, Optional W As Integer = -1)
  Static lastturn As Integer
  Dim pre As String
  
  If W = 1 Then
    pre = " + "
  ElseIf W = 0 Then
    pre = " * "
  ElseIf W = -1 Then
    pre = "   "
  End If
  
  If s = "" Then Exit Sub
  If lastturn <> Turn Then
    Call lstEvents.AddItem(Turn & " ------------------------------------------------", lstEvents.ListCount)
    lastturn = Turn
  End If
  
  Call lstEvents.AddItem(pre & s, lstEvents.ListCount)
  While lstEvents.ListCount > 200
    lstEvents.RemoveItem (0)
  Wend
  lstEvents.ListIndex = lstEvents.ListCount - 1
End Sub

Public Sub EndCombat()
  Dim s As String
  Dim d As Integer
  Dim i As Integer
  Dim m As Double
  If Player.Dervs(D_CHP) <= 0 Then
    AddEvent ("You are defeated.")
    frmGame.AddEvent ("Defeated in combat by " & Enemy.Name & ".")
    d = 10 + (Player.Stats(S_REP) \ 20)
    Player.Stats(S_REP) = Max(Player.Stats(S_REP) - d, 0)
    Player.CalcDervs
    AddEvent ("You have been defeated in combat.")
    If C_HARDDEATH = 1 Then
      AddEvent ("Game over!")
    Else
      Player.Dervs(D_CHP) = Player.Dervs(D_HTP)
      AddEvent ("Your reputation decreases by " & d & ".")
      d = CLng(Player.Gold / 2)
      Player.Gold = Max(Player.Gold - d, 0)
      AddEvent ("You lose " & d & " gold coins.")
      AddEvent ("You have been returned to Centris.")
      World.Loc = 0
      frmGame.cmdRoute.Caption = "Calc. Route"
    End If
  ElseIf Enemy.Dervs(D_CHP) <= 0 Then
    m = 1
    For i = 0 To 9
      If Player.RK(i) = Enemy.Name Then m = m * 0.85
    Next i
    
    m = m * (0.8 ^ Max((Player.Reals(S_REP) \ 10) - (Enemy.Depth), 0))
    
    AddEvent ("You win!")
    AddEvent ("Gain " & CInt(Enemy.Points * m) & " experience points.")
    Player.Points = Player.Points + CInt(Enemy.Points * m)
    
    Player.RK(Player.Kills Mod 10) = Enemy.Name
    Player.Kills = Player.Kills + 1
    Player.KH(Enemy.Terrain, Enemy.Depth) = Player.KH(Enemy.Terrain, Enemy.Depth) + 1
    
    AddEvent (Player.GetTreasure(Enemy.Depth, Enemy.Treasure))
    If Int(Rnd * 10) + (Enemy.Depth) * 10 + 1 > Player.Stats(S_REP) Then
      Player.Stats(S_REP) = Player.Stats(S_REP) + 1
      Player.CalcDervs
      AddEvent ("Your reputation increases!")
    End If
    If Enemy.Terrain = T_GHOST Then
      World.World(Loc).LCity.Conts = World.World(Loc).LCity.Conts + 1
    End If
    frmGame.AddEvent ("Killed " & Enemy.Name & " in combat.")
  Else
    AddEvent ("You escape!")
    frmGame.AddEvent ("Escaped from " & Enemy.Name & ".")
    ETime = 0
  End If
  
  cmdRun.Enabled = False
  cmdInven.Enabled = False
'  cmdSpell.Enabled = False
  cmdWait.Enabled = False
  cmdAttack.Caption = "Exit"
  
  RefreshGame
End Sub

Public Sub Regen(A As Object)
  Dim x As Spell

  If A Is Enemy And A.Flags And F_REGN Then
    A.Dervs(D_CHP) = Min(A.Dervs(D_CHP) + 1, A.Dervs(D_HTP))
  ElseIf A Is Player Then
    If Not A.Eq(E_WEP) Is Nothing Then
      If (A.Eq(E_WEP).Flags And F_LIFE) Then
        A.Dervs(D_CHP) = Min(A.Dervs(D_CHP) + Int(Rnd * A.Reals(S_CON)) \ 10, A.Dervs(D_HTP))
      ElseIf (A.Eq(E_WEP).Flags And F_REGN) And Int(Rnd * 2) = 0 Then
        A.Dervs(D_CHP) = Min(A.Dervs(D_CHP) + Int(Rnd * A.Reals(S_CON)) \ 10, A.Dervs(D_HTP))
      End If
    End If
  
'    For Each x In char.Player.Spells
'      x.Points = Min(x.Points + char.Player.Reals(S_INT) \ 10, (char.Player.Reals(S_WIS) * 10)) '\ 20) * x.cost)
'    Next x
    
  End If
End Sub


Public Function NextTurn() As Integer ' returns 0 for player, 1 for enemy
  Dim i As Integer
  Dim Padd As Integer
  Dim Eadd As Integer
  Dim d As Integer
  Dim conf As Boolean
  
  Turn = Turn + 1
  
  If Player.Dervs(D_CHP) <= 0 Or Enemy.Dervs(D_CHP) <= 0 Then
    EndCombat
    NextTurn = 0
    Exit Function
  End If
  
  While InCombat = 1
    Padd = Spread(Player.Dervs(D_SPD), 20) 'Int(Rnd * Player.Dervs(D_SPD)) + 1 + Player.Dervs(D_SPD) \ 2
    Eadd = Spread(Enemy.Dervs(D_SPD), 20) ' Int(Rnd * Enemy.Dervs(D_SPD)) + 1 + Enemy.Dervs(D_SPD) \ 2
    If Player.Counts(N_SLOW) > 0 Then
      Padd = Padd \ 2
    End If
    If Player.Counts(N_FAST) > 0 Then
      Padd = Padd * 2
    End If
    If Player.Counts(N_SLEP) > 0 Then
      Padd = 0
'      Player.Counts(N_SLEP) = Player.Counts(N_SLEP) - 1
    End If
    If Enemy.Counts(N_SLOW) > 0 Then
      Eadd = Eadd \ 2
    End If
    If Enemy.Counts(N_FAST) > 0 Then
      Eadd = Eadd * 2
    End If
    If Enemy.Counts(N_SLEP) > 0 Then
      Eadd = 0
'      Enemy.Counts(N_SLEP) = Enemy.Counts(N_SLEP) - 1
    End If
    
    PTime = PTime + Padd
    ETime = ETime + Eadd
    
    If (PTime >= 1000 And ETime < 1000) Or (ETime >= 1000 And PTime >= 1000 And PTime >= ETime) Then
      PTime = PTime - 1000
      NextTurn = 0
      If Player.Counts(N_DETH) > 1 Then AddEvent (Player.Counts(N_DETH) - 1 & " turns left to live!")
      If Player.Counts(N_DETH) = 1 Then
        Player.Dervs(D_CHP) = 0
        EndCombat
        NextTurn = 0
        Exit Function
      End If
      If Player.Counts(N_POIS) >= 1 Then
        d = Damage(1, Enemy.Depth, 0, 0, 0, Enemy, Player)
        AddEvent ("You take " & d & " poison damage!")
        RefreshCombat
      End If
      Call Regen(Player)
      
      Call DecCounters(Player)
    
      If Player.Counts(N_CONF) > 0 Then
        If SavingThrow(F_CONF, F_CONF, Player.Flags, Enemy.Depth, Player.Reals(S_REP) \ 10) = False Then
          Call AddEvent("You are confused!", 0)
          conf = True
        Else
          Call AddEvent("You have a moment of clarity!", 0)
          conf = False
        End If
      End If
      If Player.Counts(N_SLOW) > 0 Then
          Call AddEvent("You're moving slowly!", 0)
      End If
      If Player.Counts(N_FAST) > 0 Then
          Call AddEvent("You're moving quickly!", 0)
      End If
      If Player.Counts(N_SLEP) > 0 Then
          Call AddEvent("You're asleep!", 0)
          conf = True
  '      Player.Counts(N_SLEP) = Player.Counts(N_SLEP) - 1
      End If
      
      If conf = True Then
        PTime = PTime
      Else
        Exit Function
      End If
    ElseIf (ETime >= 1000 And PTime < 1000) Or (ETime >= 1000 And PTime >= 1000 And ETime > PTime) Then
      ETime = ETime - 1000
      NextTurn = 1
      If Enemy.Counts(N_DETH) > 1 Then AddEvent (Enemy.Counts(N_DETH) - 1 & " turns left for your enemy to live!")
      If Enemy.Counts(N_DETH) = 1 Then
        Enemy.Dervs(D_CHP) = 0
        EndCombat
        NextTurn = 0
        Exit Function
      End If
      If Enemy.Counts(N_POIS) >= 1 Then
        If Not Player.Eq(E_WEP) Is Nothing Then
          d = Damage(1, Player.Eq(E_WEP).Depth, 0, 0, 0, Player, Enemy)
        Else
          d = Damage(1, 1, 0, 0, 0, Player, Enemy)
        End If
        AddEvent ("The " & Enemy.Name & " takes " & d & " poison damage!")
      End If
      Call Regen(Enemy)
      
      Call DecCounters(Enemy)
      Exit Function
'    ElseIf ETime >= 1000 And PTime >= 1000 Then
'      If ETime > PTime Then
'        ETime = ETime - 1000
'        NextTurn = 1
'        Call DecCounters(Enemy)
'        Exit Function
'      Else
'        PTime = PTime - 1000
'        NextTurn = 0
'        Call DecCounters(Player)
'        Exit Function
'      End If
    End If
  Wend
End Function

Public Sub DecCounters(e As Object)
  Dim i As Integer
  For i = 0 To C_COUNTERS - 1
    e.Counts(i) = Max(e.Counts(i) - 1, 0)
  Next i
End Sub

Public Sub EnemyAttack()
  Dim conf As Boolean
  
  If NextTurn() = 0 Then Exit Sub
  
  Dim A As Integer
  Dim i As Integer
  A = Int(Rnd * 100) + 1
  
  For i = 0 To C_MAXATTACKS - 1
    A = A - Enemy.AttP(i)
    If A <= 0 Then Exit For
  Next i
  
  If Enemy.Counts(N_CONF) > 0 Then
    If SavingThrow(F_CONF, F_CONF, Enemy.Flags, Player.Reals(S_REP) \ 10, Enemy.Depth) = False Then
      Call AddEvent("The " & Enemy.Name & " flails around in confusion.", 1)
      conf = True
    Else
      Call AddEvent("The " & Enemy.Name & " has a moment of clarity.", 1)
      conf = False
    End If
  End If
    If Enemy.Counts(N_SLOW) > 0 Then
      Call AddEvent("The " & Enemy.Name & " is moving slowly.", 1)
    End If
    If Enemy.Counts(N_FAST) > 0 Then
      Call AddEvent("The " & Enemy.Name & " is moving quickly.", 1)
    End If
    If Enemy.Counts(N_SLEP) > 0 Then
      Call AddEvent("The " & Enemy.Name & " is asleep.", 1)
      conf = True
'      Enemy.Counts(N_SLEP) = Enemy.Counts(N_SLEP) - 1
    End If
  
  If conf = False Then
    Call AddEvent(Enemy.DoAttack(Enemy.Atts(i), Player), 1)
  End If
  Call RefreshCombat
  If Player.Dervs(D_CHP) <= 0 Then
    EndCombat
  Else
    Call EnemyAttack
  End If
  Exit Sub
  
End Sub

Public Sub RefreshCombat()
  txHP.Text = Player.Dervs(D_CHP) & "/" & Player.Dervs(D_HTP)
  RefreshSpells
End Sub

Private Sub cmdAttack_Click()
  Dim s As String
  Dim conf As Boolean
  
  If cmdAttack.Caption = "Exit" Then
    frmCombat.Visible = False
    
    cmdRun.Enabled = True
    cmdInven.Enabled = True
    cmdWait.Enabled = True
    cmdAttack.Caption = "Attack"
    
    InCombat = 0
    If C_HARDDEATH = 1 And Player.Dervs(D_CHP) <= 0 Then
      End
    Else
      lastForm.Visible = True
      Exit Sub
    End If
  End If
  
  If Player.Eq(E_WEP) Is Nothing Then
    s = "Punch"
    If (Player.Flags And F_HYPR) Then
      PTime = PTime + 500
    ElseIf (Player.Flags And F_FAST) Then
      PTime = PTime + 250
    End If
  Else
    s = Player.Eq(E_WEP).Attack
    If (Player.Eq(E_WEP).Flags And F_HYPR) Or (Player.Flags And F_HYPR) Then
      PTime = PTime + 500
    ElseIf (Player.Eq(E_WEP).Flags And F_FAST) Or (Player.Flags And F_FAST) Then
      PTime = PTime + 250
    End If
  End If
  
'  If Player.Counts(N_CONF) > 0 Then
'    If SavingThrow(F_CONF, F_CONF, Player.Flags, Enemy.Depth, Player.Reals(S_REP) \ 10) = False Then
'      Call AddEvent("You are confused!", 0)
'      conf = True
'    Else
'      Call AddEvent("You have a moment of clarity!", 0)
'      conf = False
'    End If
'  End If
  
  If conf = False Then
    Call AddEvent(Player.DoAttack(s, Enemy), 0)
  End If
'  Call AddEvent(Player.DoAttack(S, Enemy), 0)
  Call RefreshCombat
  Call EnemyAttack
End Sub

Public Sub StartCombat(s As String, ambush As Integer, lf As Form)
  Dim i As Integer
  frmCombat.Refresh
  
  Set Enemy = New Monster
  Call Enemy.MakeMonster(s)
  Set Player = char.Player
  Set lastForm = lf

  For i = 0 To C_COUNTERS - 1
    Enemy.Counts(i) = 0
    Player.Counts(i) = 0
  Next i

  InCombat = 1
  PTime = 0
  ETime = 0
  Turn = 1
  
  If ambush = 1 Then
    PTime = PTime + 1000
  ElseIf ambush = 2 Then
    ETime = ETime + 1000
  End If

  txEnemyName.Text = Enemy.Name
  lstEvents.Clear
  
  AddEvent ("Entering combat with " & Enemy.Name)
    
  lastForm.Visible = False
  frmInven.Visible = False
  frmCombat.Visible = True
  cmdRun.SetFocus
  Call RefreshCombat
  
  Call EnemyAttack

End Sub

Private Sub cmdInven_Click()
  frmInven.Visible = True
  frmCombat.Visible = False
  frmInven.RefreshInven
End Sub

Private Sub cmdLook_Click()
  Dim off As Integer
  
'  off = (400 - Player.Dervs(D_PER) - Player.Reals(S_REP)) \ 4
  off = Min(Max(100 - (((Player.Dervs(D_PER) - Enemy.Depth * 10) * 100) / ((Enemy.Depth + 1) * 10)) / 4 - (((Player.Reals(S_REP) - Enemy.Depth * 10) * 100) / ((Enemy.Depth + 1) * 10)) / 4 - Player.KH(Enemy.Terrain, Enemy.Depth) - Player.KL(Enemy.Terrain, Enemy.Depth), 0), 100)
  If Player.Flags And F_TRUE Then
    off = off \ 2
  End If
  
  Call DispMonster(Enemy, off)
End Sub

Private Sub cmdRun_Click()
  Call FleeAttempt(0)
End Sub

Public Sub FleeAttempt(Optional EscapeSpell As Integer = 0)
  Dim m As Integer
 
  If EscapeSpell = 1 Then
    m = 2
  Else
    m = 1
  End If
  
  If Int(Rnd * 200) < Player.Dervs(D_LUK) * m Then
    Call EndCombat
    Exit Sub
  ElseIf Int(Rnd * (Player.Dervs(D_SPD) * m + Enemy.Dervs(D_SPD))) <= Player.Dervs(D_SPD) * m Then
    Call EndCombat
    Exit Sub
  Else
    Call AddEvent("You try to escape, but you don't get away!")
  End If
  
  Call RefreshCombat
  Call EnemyAttack

End Sub

Private Sub cmdSpell_Click()
  Call frmMagic.RefreshSpells
  frmMagic.Visible = True
  frmCombat.Visible = False
  frmMagic.SetFocus
End Sub

Private Sub cmdWait_Click()
  Dim s As String
  
  Call AddEvent("You wait.")
  Call RefreshCombat
  Call EnemyAttack
End Sub

Private Sub Form_Load()
'  Call StartCombat
End Sub

Private Sub Form_Unload(cancel As Integer)
  If InCombat = 1 Then
    cancel = 1
  End If
End Sub

Public Sub RefreshSpells()
  Dim s As String
  Dim avail As Integer
  Dim pts As Integer
  Dim x As Spell
  Dim nIndex As Integer
  
  Call lstSpells.ClearList

  For Each x In char.Player.Spells
    avail = x.Points \ x.cost
    pts = x.Points Mod x.cost
    
'    s = "(" & avail & "/" & Player.Reals(S_WIS) * 10 \ x.cost & ")|" & Int((char.Player.Reals(S_INT) + x.Skill) / (x.Depth * 10 + char.Player.Reals(S_INT) + x.Skill) * 100) & "|" & x.Key & "|" & x.Desc & "|" & (x.Used) '& " [" & pts & "/" & x.cost & "]"
    s = "(" & avail & "/" & Player.Reals(S_WIS) * 10 \ x.cost & ")|" & Int((char.Player.Reals(S_INT) + x.Skill) / (x.Depth * 10 + char.Player.Reals(S_INT) + x.Skill) * 100) & "|" & x.Key & "|" & x.Desc & "|" & (x.Depth) '& " [" & pts & "/" & x.cost & "]"
    
    nIndex = lstSpells.AddItem(s)
'    lstSpells.ListCargo(nIndex) = x.Used
'    lstSpells.List(lstSpells.NewIndex) = x.Used & "|" & "(" & avail & "/" & Player.Reals(S_WIS) * 10 \ x.cost & ") " & lstSpells.List(lstSpells.NewIndex) & " [" & pts & "/" & x.cost & "]"
    
  Next x
  lstSpells.SortColumn = 5
'  lstSpells.SortDirection = SortAscend
  Call ctListSort(lstSpells, 5)
'  lstSpells.SortList
End Sub

Private Sub lstSpells_Change(ByVal nIndex As Integer)
  lstSpells.Tag = nIndex
End Sub

Private Sub lstSpells_DblClick()
  Dim sp As String
  Dim l As String
  Dim r As String
  
  If cmdAttack.Caption = "Exit" Then Exit Sub
  
'  l = Left(lstSpells.ListText(Val(lstSpells.Tag)), InStr(1, lstSpells.ListText(Val(lstSpells.Tag)), "[", vbTextCompare) - 2)
'  r = Right(l, Len(l) - InStr(1, l, ")", vbTextCompare) - 1)
  
  sp = lstSpells.ListColumnText(Val(lstSpells.Tag), 3)
    
  'lstSpells.ListCargo(lstSpells.Tag) = Str(CDbl(Now()))
  char.Player.Spells(sp).Used = Str(CDbl(Now()))
    
  Call char.Player.Cast(sp)
  
'  frmMagic.Visible = False
  If frmCombat.InCombat = 1 Then
    frmCombat.Visible = True
    Call frmCombat.RefreshCombat
    Call frmCombat.EnemyAttack
  End If
'  frmGame.SetFocus
End Sub

