VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "Character"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Option Explicit
Public XP As Integer
Public Gold As Double
Public LockPoints As Integer
Public Points As Long
Public Name As String
Public LastTown As Integer

Private r(0 To 6) As Integer
Private Statistics(0 To 6) As Integer
Private Derived(0 To 10) As Integer
Private Inventory(0 To C_INVMAX - 1) As Item
Private Equipped(0 To 7) As Item
Public Flags As Integer
Private Counters(0 To C_COUNTERS - 1) As Integer
Public Dropping As Integer
Public CombatUsing As Integer
Private Resistances(0 To C_RESISTS - 1) As Integer
Public Spells As New Collection

Private KillHistory(0 To T_MAX, 0 To 20) As Integer
Private KillLearned(0 To T_MAX, 0 To 20) As Integer
Private RecentKills(0 To 9) As String
Public Kills As Integer

Public HandHits As Integer
Public HandSkill As Double

Public Cargo As Integer

Public Sub Cast(sp As String)
  Dim tocast As Spell
  Dim ic As Integer
  Dim s As String
  Dim cap As String
  Dim d As Integer
  
  If frmCombat Is Nothing Then
    ic = 0
  Else
    ic = frmCombat.InCombat
  End If
  Set tocast = Spells.Item(sp)
  cap = "Cast " & tocast.Key
    
  If tocast.Points < tocast.cost Then
    MsgBox "You don't have that spell memorized.", , "Casting " & sp
    Exit Sub
  End If
  
  If Rnd * (tocast.Depth * 10 + Reals(S_INT) + tocast.Skill) <= tocast.Depth * 10 Then
    If Rnd * (tocast.Depth * 10 + Reals(S_WIS)) > tocast.Depth * 10 Then
      tocast.Skill = tocast.Skill + 1
    End If
    
    If ic = 1 Then
      Call frmCombat.AddEvent("The spell fizzles!", 0)
    Else
      Call MsgBox("The spell fizzles!")
    End If
    tocast.Points = tocast.Points - tocast.cost
    tocast.Used = Str(CDbl(Now()))
    Exit Sub
  End If
    
  If sp = "Magic Missile" And ic = 1 Then
    Call frmCombat.AddEvent("You cast Magic Missile.", 0)
    d = Damage(Reals(S_INT) * 2, Reals(S_INT) / 3, 0, frmCombat.Enemy.Dervs(D_DR), F_MAGI, Me, frmCombat.Enemy)
    If d <> 0 Then Call frmCombat.AddEvent("The " & frmCombat.Enemy.Name & " is blasted for " & d & " damage.", 0)
    If d = 0 Then Call frmCombat.AddEvent("Your Magic Missiles are harmlessly absorbed.", 0)
  ElseIf sp = "Sparkler" And ic = 1 Then
    Call frmCombat.AddEvent("You cast Sparkler.", 0)
    d = Damage(Reals(S_INT), Reals(S_INT) / 4, 0, frmCombat.Enemy.Dervs(D_DR), 0, Me, frmCombat.Enemy)
    If d <> 0 Then Call frmCombat.AddEvent("Your Sparkler engulfs the " & frmCombat.Enemy.Name & " for " & d & " damage.", 0)
    If d = 0 Then Call frmCombat.AddEvent("Your Sparkler has no effect.", 0)
  
  ElseIf sp = "Escape" And ic = 1 Then
    Call frmCombat.AddEvent("You cast Escape.", 0)
    Call frmCombat.FleeAttempt(1)
  
  ElseIf sp = "Protection" And ic = 1 Then
    Call frmCombat.AddEvent("You cast Protection. Def+" & Reals(S_INT) \ 10 & " DR+" & Reals(S_INT) \ 25, 0)
    Counts(N_PROT) = Reals(S_INT) \ 5
  
  ElseIf sp = "Fireball" And ic = 1 Then
    Call frmCombat.AddEvent("You cast Fireball.", 0)
    d = Damage(Reals(S_INT) * 2, Reals(S_INT) / 2, frmCombat.Enemy.Dervs(D_DEF), frmCombat.Enemy.Dervs(D_DR), F_FIRE, Me, frmCombat.Enemy)
    If d <> 0 Then Call frmCombat.AddEvent("The " & frmCombat.Enemy.Name & " is fried for " & d & " damage.", 0)
    If d = 0 Then Call frmCombat.AddEvent("Your Fireball misses.", 0)
  ElseIf sp = "Ice Storm" And ic = 1 Then
    Call frmCombat.AddEvent("You cast Ice Storm.", 0)
    d = Damage(Reals(S_INT) * 2, Reals(S_INT) / 2, frmCombat.Enemy.Dervs(D_DEF), frmCombat.Enemy.Dervs(D_DR), F_COLD, Me, frmCombat.Enemy)
    If d <> 0 Then Call frmCombat.AddEvent("The " & frmCombat.Enemy.Name & " is frozen for " & d & " damage.", 0)
    If d = 0 Then Call frmCombat.AddEvent("Your Ice Storm dissipates harmlessly.", 0)
  ElseIf sp = "Lightning Bolt" And ic = 1 Then
    Call frmCombat.AddEvent("You cast Lightning bolt.", 0)
    d = Damage(Reals(S_INT) * 2, Reals(S_INT) / 2, frmCombat.Enemy.Dervs(D_DEF), frmCombat.Enemy.Dervs(D_DR), F_ELEC, Me, frmCombat.Enemy)
    If d <> 0 Then Call frmCombat.AddEvent("The " & frmCombat.Enemy.Name & " is electrocuted for " & d & " damage.", 0)
    If d = 0 Then Call frmCombat.AddEvent("Your Lightning Bolt strikes wide.", 0)
  
  ElseIf sp = "Heal" Then
    d = Int(Rnd * ((Reals(S_INT) + Reals(S_WIS)) \ 2)) + 1 + ((Reals(S_INT) + Reals(S_WIS)) \ 4)
    If ic = 0 Then
      s = "You heal " & d & " points of damage."
      move.RefreshGame
    ElseIf ic = 1 Then
      Call frmCombat.AddEvent("You cast Heal, and recover " & d & " hit points.", 0)
    End If
    Dervs(D_CHP) = Min(Dervs(D_CHP) + d, Dervs(D_HTP))
  ElseIf sp = "Teleport" And ic = 0 Then
    d = Int(Rnd * C_LOCS)
    s = "You teleport to " & d & "."
    MoveTo (d)
  ElseIf sp = "Haste" And ic = 1 Then
    Counts(N_FAST) = Reals(S_INT) \ 10
    Call frmCombat.AddEvent("You feel yourself speed up.", 0)
  ElseIf sp = "Slow" And ic = 1 Then
    If MagicSave(frmCombat.Enemy.Res(R_MAGI)) = 0 Then
      frmCombat.Enemy.Counts(N_SLOW) = Reals(S_INT) \ 10
      Call frmCombat.AddEvent("The " & frmCombat.Enemy.Name & " is slowed!", 0)
    Else
      Call frmCombat.AddEvent("The " & frmCombat.Enemy.Name & " is not affected!", 0)
    End If
  ElseIf sp = "Stun" And ic = 1 Then
    If MagicSave(frmCombat.Enemy.Res(R_MAGI)) = 0 Then
      frmCombat.ETime = frmCombat.ETime - Reals(S_INT) * 50
      Call frmCombat.AddEvent("The " & frmCombat.Enemy.Name & " is stunned!", 0)
    Else
      Call frmCombat.AddEvent("The " & frmCombat.Enemy.Name & " is not affected!", 0)
    End If
  ElseIf sp = "Bless" And ic = 1 Then
    Call frmCombat.AddEvent("You feel yourself surrounded with holy power.", 0)
    Counts(N_BLES) = Reals(S_INT) \ 10
  ElseIf sp = "Town Portal" And ic = 0 Then
    d = World.Cities(Int(Rnd * UBound(World.Cities)))
'    d = LastTown
    While World.World(d).LCity.T <> "City" Or World.World(d).Explored = 0
      d = World.Cities(Int(Rnd * UBound(World.Cities)))
    Wend
    s = "You teleport to " & World.World(d).LCity.Name & "."
    Call MoveTo(d)
  Else
    s = "That spell cannot be cast now."
  End If
  
  If s <> "That spell cannot be cast now." Then
    If Rnd * (tocast.Depth * 10 + Reals(S_WIS)) > tocast.Depth * 10 Then
      tocast.Skill = tocast.Skill + 1
    End If
    
    tocast.Points = tocast.Points - tocast.cost
    tocast.Used = Str(CDbl(Now()))
  End If
  
  If s <> "" Then
    MsgBox s, , cap
  End If
  
  If ic = 0 Then move.RefreshGame
    
End Sub

Public Function GetTreasure(T As Integer, Special As Integer) As String
  Dim s As String
  Dim g As Integer
  Dim it As Item
  Dim r As Integer
  If Special > 0 And T >= 0 Then
    g = TG(T)
'    g = Int(Rnd * (C_VALUEPERLEVEL / 20) + (C_VALUEPERLEVEL / 40))
    s = "You collect " & g & " gold!"
    r = Int(Rnd * 100)
    If Special = 2 Then r = 0
    Select Case r
      Case 0 To 15
        Set it = New Item
        Call it.Create(Int(Rnd * 4), T + Max(0, (Int(Rnd * 6)) - 4), T - 5 + Max(0, (Int(Rnd * 6)) - 4))
      Case 16 To 30
        Set it = New Item
        Call it.MakeItem(1, 1, "Body Part", frmCombat.Enemy.Terrain, frmCombat.Enemy.Depth, , , , , True)
      Case 31 To 36
        If Rnd * 20 <= T Then
          Set it = New Item
          Call it.CreateWand
        End If
      Case 37 To 97
      Case 98 To 99
        Set it = New Item
        Call it.CreateArtifact(Int(Rnd * 6), Max(T - 1 + Int(Rnd * 3), 0))
    End Select
  ElseIf Special = -1 Then
    g = 0
    s = "You find nothing!"
  Else
    g = 0
    s = "Blank treasure."
  End If
  
  Me.Gold = Me.Gold + g
  If Not it Is Nothing Then
    s = s & " You find a " & JustText(ItemText(it)) & "."
    Call Me.AddInven(it)
  End If
  
  GetTreasure = s
End Function

Public Function DoAttack(s As String, T As Monster) As String
  Dim d As Integer
  Dim ff As Integer
  Dim longrange As Integer
  Dim t1 As Double
  
  longrange = 0
  
  If (Counts(N_CONF) > 0) And Int(Rnd * 2) = 0 Then
    DoAttack = "You flail around in confusion."
    Exit Function
  End If
    
'  If Me.Eq(E_WEP) Is Nothing Then
'    s = "Punch"
'  End If
  
  If Not Eq(E_WEP) Is Nothing Then
    ff = ff Or Eq(E_WEP).Flags
  End If
  
  If Not Eq(E_GNT) Is Nothing Then
    ff = ff Or Eq(E_GNT).Flags
  End If
  
  If s = "Punch" Then
    If Int(Rnd * 3) = 0 Then
      If Rnd * (Dervs(D_SAT) + Dervs(D_DAT)) < Dervs(D_SAT) Then
        t1 = 1
      Else
        frmCombat.PTime = frmCombat.PTime + 100
      End If
      
      If Not Eq(E_BTS) Is Nothing Then
        ff = Eq(E_BTS).Flags
      End If
      
      d = Damage(Max(Dervs(D_SAT), Dervs(D_DAT)) * (1 + HandSkill), (Dervs(D_DAM) + t1) * (1.5 + HandSkill), T.Dervs(D_DEF), T.Dervs(D_DR), ff, Me, T)
      If d > 0 Then
        DoAttack = "You kick the " & T.Name & " for " & d & " damage."
        Call IncWeap
      End If
      If d <= 0 Then DoAttack = "Your kick goes wide."
    Else
      If Rnd * (Dervs(D_SAT) + Dervs(D_DAT)) < Dervs(D_SAT) Then
        t1 = 1
      Else
        frmCombat.PTime = frmCombat.PTime + 100
      End If
      
      frmCombat.PTime = frmCombat.PTime + 250
      
      If Not Eq(E_GNT) Is Nothing Then
        ff = Eq(E_GNT).Flags
      End If
      
      d = Damage(Max(Dervs(D_SAT), Dervs(D_DAT)) * (1 + HandSkill), (Dervs(D_DAM) + t1) * (1 + HandSkill), T.Dervs(D_DEF), T.Dervs(D_DR), ff, Me, T)
      If d > 0 Then
        DoAttack = "You punch the " & T.Name & " for " & d & " damage."
        Call IncWeap
      End If
      If d <= 0 Then DoAttack = "Your punch goes wide."
    End If
'    Exit Function
  ElseIf s = "Highest" Or s = "MageStr" Then
    d = Damage(Max(Dervs(D_SAT), Dervs(D_DAT)), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), ff, Me, T)
    If d > 0 Then
      DoAttack = "You hit the " & T.Name & " for " & d & " damage."
      Call IncWeap
    End If
    If d <= 0 Then DoAttack = "You swing and miss."
  ElseIf s = "NormalStr" Then
    d = Damage(Dervs(D_SAT), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), ff, Me, T)
    If d > 0 Then
      DoAttack = "You hit the " & T.Name & " for " & d & " damage."
      Call IncWeap
    End If
    If d <= 0 Then DoAttack = "You swing and miss."
'    Exit Function
  ElseIf s = "NormalDex" Then
    d = Damage(Dervs(D_DAT), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), ff, Me, T)
    If d > 0 Then
      DoAttack = "You hit the " & T.Name & " for " & d & " damage."
      Call IncWeap
    End If
    If d <= 0 Then DoAttack = "You swing and miss."
'    Exit Function
  ElseIf s = "Bow" Then
    d = Damage(Dervs(D_DAT), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), ff, Me, T)
    If d > 0 Then
      DoAttack = "You shoot the " & T.Name & " for " & d & " damage."
      Call IncWeap
    End If
    If d <= 0 Then DoAttack = "You fire and miss."
'    frmCombat.PTime = frmCombat.PTime + 250
    longrange = 1
'    Exit Function
  ElseIf s = "NinjaDex" Then
    d = Damage(Dervs(D_DAT), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), ff, Me, T)
    If Int(Rnd * 5) = 0 And d > 0 Then
      d = d + Damage(Dervs(D_DAT), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), Eq(0).Flags, Me, T)
      Call frmCombat.AddEvent("Critical Hit!", 0)
    End If
    If d > 0 Then
      DoAttack = "You hit the " & T.Name & " for " & d & " damage."
      Call IncWeap
    End If
    If d <= 0 Then DoAttack = "You swing and miss."
'    Exit Function
  ElseIf s = "NinjaStr" Then
    d = Damage(Dervs(D_SAT), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), ff, Me, T)
    If Int(Rnd * 6) = 0 And d > 0 Then
      d = d + Damage(Dervs(D_DAT), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), ff, Me, T)
      Call frmCombat.AddEvent("Critical Hit!", 0)
    End If
    If d > 0 Then
      DoAttack = "You hit the " & T.Name & " for " & d & " damage."
      Call IncWeap
    End If
    If d <= 0 Then DoAttack = "You swing and miss."
'    Exit Function
  ElseIf s = "Sword of Giants" Then
    d = Damage(Dervs(D_SAT), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), F_ELEC, Me, T)
    If d > 0 Then
      DoAttack = "You slash the " & T.Name & " with the Sowrd of Giants for " & d & " electrical damage."
      Call IncWeap
    End If
    If d <= 0 Then DoAttack = "You miss with the Fire Bomb."
'    Exit Function
  ElseIf s = "FireBomb" Then
    d = Damage(10, 2, T.Dervs(D_DEF), T.Dervs(D_DR), F_FIRE, Me, T)
    If d > 0 Then DoAttack = "You throw a Fire Bomb at the " & T.Name & " for " & d & " fire damage."
    If d <= 0 Then DoAttack = "You miss with the Fire Bomb."
    longrange = 1
'    Exit Function
  Else
    DoAttack = "You do nothing."
    Exit Function
  End If
  
  If longrange = 0 And d <> 0 And T.Dervs(D_DMS) <> 0 And (Not Flags And F_LONG) Then
    DoAttack = DoAttack & " " & Damage(100, T.Dervs(D_DMS), 0, 0, 0, T, Me) & " point counter."
  End If
End Function

Public Sub IncWeap()
  If Rnd > frmCombat.Enemy.Depth * 10 / (char.Player.Reals(S_REP) + 1) Then
    Exit Sub
  End If
  
  If Eq(E_WEP) Is Nothing Then
    HandHits = HandHits + 1
    If HandHits >= ((HandSkill + 0.1) / 0.1) * 10 Then
      HandHits = 0
      HandSkill = HandSkill + 0.1
      Call frmCombat.AddEvent("You improve your martial arts skill!", 0)
    End If
    Exit Sub
  End If
  
  Eq(E_WEP).Hits = Eq(E_WEP).Hits + 1
  If Eq(E_WEP).Hits >= ((Eq(E_WEP).SkillBonus + 0.1) / 0.1) * 10 Then
    Eq(E_WEP).Hits = 0
    Eq(E_WEP).SkillBonus = Eq(E_WEP).SkillBonus + 0.1
    
    Eq(E_WEP).Att = (Eq(E_WEP).Att / (Eq(E_WEP).SkillBonus + 0.9)) * (Eq(E_WEP).SkillBonus + 1) ' + 1
    Eq(E_WEP).Dam = (Eq(E_WEP).Dam / (Eq(E_WEP).SkillBonus + 0.9)) * (Eq(E_WEP).SkillBonus + 1) ' + 0.5
    Eq(E_WEP).Def = (Eq(E_WEP).Def / (Eq(E_WEP).SkillBonus + 0.9)) * (Eq(E_WEP).SkillBonus + 1) ' + 1
    Eq(E_WEP).DR = (Eq(E_WEP).DR / (Eq(E_WEP).SkillBonus + 0.9)) * (Eq(E_WEP).SkillBonus + 1) ' + 0.5
    Eq(E_WEP).DMS = (Eq(E_WEP).DMS / (Eq(E_WEP).SkillBonus + 0.9)) * (Eq(E_WEP).SkillBonus + 1) ' + 0.5
      
    Call frmCombat.AddEvent("You feel more skilled with your weapon!", 0)
    Eq(E_WEP).SetText
  End If
    
End Sub

Public Function HandsText()
    If HandSkill = 0# Then
      HandsText = HandsText & "[Grasshopper] "
    ElseIf HandSkill <= 0.21 Then
      HandsText = HandsText & "[Novice] "
    ElseIf HandSkill <= 0.41 Then
      HandsText = HandsText & "[Initiate] "
    ElseIf HandSkill <= 0.61 Then
      HandsText = HandsText & "[Acolyte] "
    ElseIf HandSkill <= 0.81 Then
      HandsText = HandsText & "[Adept] "
    ElseIf HandSkill <= 1.01 Then
      HandsText = HandsText & "[Master of Grass] "
    ElseIf HandSkill <= 1.21 Then
      HandsText = HandsText & "[Master of Leaves] "
    ElseIf HandSkill <= 1.41 Then
      HandsText = HandsText & "[Master of Breezes] "
    ElseIf HandSkill <= 1.61 Then
      HandsText = HandsText & "[Master of Winds] "
    ElseIf HandSkill <= 1.81 Then
      HandsText = HandsText & "[Master of Streams] "
    ElseIf HandSkill <= 2.01 Then
      HandsText = HandsText & "[Master of Rivers] "
    ElseIf HandSkill <= 2.21 Then
      HandsText = HandsText & "[Master of Sparks] "
    ElseIf HandSkill <= 2.41 Then
      HandsText = HandsText & "[Master of Flames] "
    ElseIf HandSkill <= 3.01 Then
      HandsText = HandsText & "[Master of Elements] "
    Else
      HandsText = HandsText & "[Grand Master] "
    End If
    
    Call CalcDervs
    
    HandsText = HandsText & "Hands and Feet"
    HandsText = HandsText & " Att:" & Int(Max(Dervs(D_SAT), Dervs(D_DAT)) * (1 + HandSkill))
    HandsText = HandsText & " Dm:" & Int(Dervs(D_DAM) * (1 + HandSkill))

End Function

Public Sub Class_Initialize()
  Dim i As Integer
  Points = 600
  LockPoints = 0
  Name = "Player"
  XP = 0
  Stats(S_STR) = 10
  Stats(S_DEX) = 10
  Stats(S_CON) = 10
  Stats(S_INT) = 10
  Stats(S_WIS) = 10
  Stats(S_CHA) = 10
  Stats(S_REP) = 0
  
  HandHits = 0
  HandSkill = 0
  
  Cargo = 1
  
  Call CalcDervs
  Dervs(D_CHP) = Dervs(D_HTP)
  Gold = 2000
  Flags = 0
'  For i = 0 To C_SPELLS - 1
'    Spells(i) = -1
'  Next i
  
  Dim Knife As New Item
  Dim Dagger As New Item
  Dim Ring1 As New Item
  Dim Ring2 As New Item
  Dim Armor As New Item
  Dim Potion As New Item
'  Dim Map As New Item
'  Dim MM As New Spell
'  Dim Heal As New Spell
'  Dim TeleS As New Item
'  Dim HealS As New Item
'  Dim doll As New Item
Dim Spark As New Spell
  
  Call Knife.MakeItem(1, 1, "Knife", , , , 0, 0, 0, False)
'  Call Dagger.Me.MakeItem(1,1, "Leather Gloves", , , , 100, 100, 10)
  Call Ring1.MakeItem(1, 1, "Healing Potion", 0)
  Call Ring2.MakeItem(1, 1, "Healing Potion", 0)
  Call Armor.MakeItem(1, 1, "Clothing", , , , , , , False)
  Call Potion.MakeItem(1, 1, "Healing Potion", 0)
'  Call Map.Me.MakeItem(1,1, "Map", 999)
'  Call MM.MakeSpell(M_MMIS)
  Call Spark.MakeSpell(M_SPRK)
'  Call Heal.MakeSpell(M_HEAL)
'  Call TeleS.Me.MakeItem(1,1, "Scroll", M_TELE)
'  Call HealS.Me.MakeItem(1,1, "Scroll", M_HEAL)
'  Call doll.Me.MakeItem(1,1, "Wand of Terrain")
'  Call Tele.MakeSpell("Teleport")
  
      
'  Call Me.AddInven(Knife)
  Call Me.AddInven(Potion)
  Call Me.AddInven(Ring1)
  Call Me.AddInven(Ring2)
'  Call Me.AddInven(Armor)
'  Call Me.AddInven(Map)
'  Call Me.Spells.Add(MM, MM.Key)
  Call Me.Spells.Add(Spark, Spark.Key)
'  Call Me.Spells.Add(Heal, Heal.Key)
'  Call Me.AddInven(TeleS)
'  Call Me.AddInven(HealS)
'  Call Me.AddInven(doll)
'  Call Me.Spells.Add(Tele, Tele.Key)
  
End Sub

Public Function AddInven(T As Item, Optional n As Integer = -1) As Integer
  Dim i As Integer
  Dim ans As VbMsgBoxResult
tryagain:
'  For i = 0 To C_INVMAX - 1
'    If Not Me.Inven(i) Is Nothing Then
'      If Me.Inven(i).Text = T.Text And Me.Inven(i).Use = E_NON And T.Use = E_NON Then
'        If n = -1 Then
'          Me.Inven(i).num = Me.Inven(i).num + T.num
'          AddInven = i
'          Set T = Nothing
'        Else
'          Me.Inven(i).num = Me.Inven(i).num + n
'          AddInven = i
'        End If
'        Exit Function
'      End If
'    End If
'  Next i
  If T.Use = E_TRD Then
    If Cargo = 0 Then
      Call MsgBox("You can't carry any cargo yet!  Increase your reputation.", , "Cargo Full")
      AddInven = -1
      Exit Function
    End If
    If TGCount() < Cargo Then
      For i = 0 To C_INVMAX - 1
        If Me.Inven(i) Is Nothing Then
          Me.Inven(i) = T
          AddInven = i
    '      Set T = Nothing
          Exit Function
        End If
      Next i
    Else
      Call MsgBox("Your cargo is full." & vbCrLf & "Discard something from your caravan to load up:" & vbCrLf & Right(T.Text, Len(T.Text) - 3), , "Cargo Full")
      
      frmInven.Visible = True
      Set frmInven.PickUp = T
      frmInven.RefreshInven
      
      AddInven = -1
      Exit Function
    End If
  Else
    For i = 0 To C_INVMAX - 1
      If Me.Inven(i) Is Nothing Then
        Me.Inven(i) = T
        AddInven = i
  '      Set T = Nothing
        Exit Function
      End If
    Next i
  End If
  
  Call MsgBox("Your inventory is full." & vbCrLf & "Drop something if you want to pick up" & vbCrLf & Right(T.Text, Len(T.Text) - 3), , "Inventory Full")
  
  frmInven.Visible = True
  Set frmInven.PickUp = T
  frmInven.RefreshInven
  
  AddInven = -1
End Function

Public Function RemInven(T As Item, Optional n As Integer = -1) As Integer
  Dim i As Integer
  
  For i = 0 To C_INVMAX - 1
    If Me.Inven(i) Is T Then
      If IsEquipped(T) <> -1 Then
        Me.Eq(IsEquipped(T)) = Nothing
      End If
      
'      If n = -1 Then
        Me.Inven(i) = Nothing
'      Else
'        Me.Inven(i).num = Me.Inven(i).num - n
'        If Me.Inven(i).num <= 0 Then Call RemInven(T)
'      End If
      RemInven = i
      Exit Function
      
    End If
  Next i

End Function

Public Sub CalcDervs()
  Dim i As Integer
  Dim j As Integer
  
  For i = 0 To 6
    Reals(i) = Stats(i)
  Next i
  For i = 0 To C_RESISTS - 1
    Res(i) = 0
  Next i
  
  For i = 0 To 6
    For j = 0 To 7
      If Not Eq(j) Is Nothing Then
        Reals(i) = Max(Reals(i) + Eq(j).Stats(i), 1)
      End If
    Next j
  Next i
  
  Dervs(D_SAT) = Int((Reals(S_STR) * 2 + Reals(S_DEX) * 1) / 3)
  Dervs(D_DAT) = Int((Reals(S_STR) * 1 + Reals(S_DEX) * 3) / 4)
  Dervs(D_DEF) = Int((Reals(S_DEX) + Reals(S_CON) * 2 + Reals(S_INT) + Reals(S_WIS) * 2) / 6)
  Dervs(D_HTP) = Int((Reals(S_STR) + Reals(S_CON) * 3) / 4) + 5
  Dervs(D_SPD) = Int((Reals(S_DEX) * 2 + Reals(S_INT) * 2) / 4)
  Dervs(D_PER) = Int((Reals(S_INT) + Reals(S_WIS) * 3) / 4)
  Dervs(D_LUK) = Int((Reals(S_STR) + Reals(S_DEX) + Reals(S_CON) + Reals(S_INT) + 2 * Reals(S_WIS) + 2 * Reals(S_CHA) + Reals(S_REP)) / 9)
  Dervs(D_DAM) = Int((Reals(S_STR) * 2 + Reals(S_DEX)) / 15)
  Dervs(D_DR) = Int(Reals(S_CON) / 15)
  Dervs(D_DMS) = 0
  
  Cargo = Int(Reals(S_REP) / 10)
  
  For j = 0 To 7
    If Not Eq(j) Is Nothing Then
      If Eq(j).Stat = S_STR Then
        Dervs(D_SAT) = Dervs(D_SAT) + Eq(j).Att
      ElseIf Eq(j).Stat = S_DEX Then
        Dervs(D_DAT) = Dervs(D_DAT) + Eq(j).Att
      Else
        Dervs(D_SAT) = Dervs(D_SAT) + Eq(j).Att
        Dervs(D_DAT) = Dervs(D_DAT) + Eq(j).Att
      End If
      
      Dervs(D_DEF) = Dervs(D_DEF) + Eq(j).Def
      Dervs(D_DAM) = Dervs(D_DAM) + Eq(j).Dam
      Dervs(D_DR) = Dervs(D_DR) + Eq(j).DR
      Dervs(D_SPD) = Dervs(D_SPD) + Eq(j).Speed
      Dervs(D_DMS) = Dervs(D_DMS) + Eq(j).DMS
      
      For i = 0 To C_RESISTS - 1
        Res(i) = Res(i) + Eq(j).Res(i)
      Next i
      
      If j <> E_WEP Then
        Flags = Flags Or Eq(j).Flags
      End If
    End If
  Next j
  
  
End Sub

Public Function InInventory(Target As String) As Integer
  Dim i As Integer
  
  For i = 0 To UBound(Inventory)
    If Not Inventory(i) Is Nothing Then
      If InStr(1, Inventory(i).Text, Target) Then
        InInventory = i
        Exit Function
      End If
    End If
  Next i
  InInventory = -1
End Function

Public Function TGCount() As Integer
  Dim i
  
  TGCount = 0
    
  For i = 0 To UBound(Inventory)
    If Not Inventory(i) Is Nothing Then
      If Inventory(i).Use = E_TRD Then
        TGCount = TGCount + 1
      End If
    End If
  Next i
End Function

Public Property Let Counts(i As Integer, v As Integer)
  Counters(i) = v
End Property

Public Property Get Counts(i As Integer) As Integer
  Counts = Counters(i)
End Property

Public Property Let KH(i As Integer, j As Integer, v As Integer)
  KillHistory(i, j) = v
End Property

Public Property Get KH(i As Integer, j As Integer) As Integer
  KH = KillHistory(i, j)
End Property
Public Property Let KL(i As Integer, j As Integer, v As Integer)
  KillLearned(i, j) = v
End Property

Public Property Get KL(i As Integer, j As Integer) As Integer
  KL = KillLearned(i, j)
End Property

Public Property Let RK(i As Integer, v As String)
  RecentKills(i) = v
End Property

Public Property Get RK(i As Integer) As String
  RK = RecentKills(i)
End Property

'Public Property Let Flags(i As long, v As long)
'  FlagsEffects(i) = v
'End Property

'Public Property Get Flags(i As long) As long
'  Flags = FlagsEffects(i)
'End Property

Public Property Let Reals(i As Integer, v As Integer)
  r(i) = v
End Property

Public Property Get Reals(i As Integer) As Integer
  Reals = r(i)
End Property

Public Property Let Dervs(i As Integer, v As Integer)
  Derived(i) = v
End Property

Public Property Get Dervs(i As Integer) As Integer
  Dervs = Derived(i)
End Property

Public Property Let Stats(i As Integer, v As Integer)
  Statistics(i) = v
End Property

Public Property Get Stats(i As Integer) As Integer
  Stats = Statistics(i)
End Property
Public Property Let Res(i As Integer, v As Integer)
  Resistances(i) = v
End Property

Public Property Get Res(i As Integer) As Integer
  Res = Resistances(i)
End Property

Public Property Let Inven(i As Integer, v As Item)
  Set Inventory(i) = v
End Property

Public Property Get Inven(i As Integer) As Item
'  If Inventory(i) = 0 Then
'    Set Inven = Nothing
'   Else
    Set Inven = Inventory(i)
'  End If
End Property
Public Property Let Eq(i As Integer, v As Item)
  Set Equipped(i) = v
End Property

Public Property Get Eq(i As Integer) As Item
  Set Eq = Equipped(i)
End Property

'Public Property Let Spells(i As long, v As long)
'  Set MagicSpells(i) = v
'End Property

'Public Property Get Spells(i As long) As long
'  Set Spells = MagicSpells(i)
'End Property


