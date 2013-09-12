Attribute VB_Name = "events"
Option Explicit
Public Function GuardsStop() As Integer
  Dim s As String
  
  If frmGame.ckCombat.Value = 1 Then Exit Function
  
  s = s & "The city guards prevent you from resting" & vbCrLf
  s = s & "on the street, but they cheerfully direct" & vbCrLf
  s = s & "you to the nearest inn."
  MsgBox s, , "City Watch"
  frmGame.AddEvent ("Harrassed by " & World.World(Loc).LCity.Name & " city watch.")
  GuardsStop = 1
End Function


Public Function Damage(ByVal Att As Integer, ByVal Dam As Integer, ByVal Def As Integer, ByVal DR As Integer, ByVal Flags As Long, A As Object, T As Object) As Integer
  Dim hit As Integer
  Dim subj As String
  Dim AttLev As Integer
  Dim TarLev As Integer
  Dim attr As String
  
  If T.Name = "Player" Then
    subj = "You are"
    attr = "The " & T.Name & " is"
    AttLev = A.Depth
    TarLev = T.Reals(S_REP) \ 10
  Else
    subj = "The " & T.Name & " is"
    attr = "You are"
    TarLev = T.Depth
    AttLev = A.Stats(S_REP) \ 10
    Att = Att * (1 + (A.KH(T.Terrain, T.Depth) / 100) + (A.KL(T.Terrain, T.Depth) / 100))
  End If
    
  If T.Counts(N_COLD) > 0 Then
    Call frmCombat.AddEvent(subj & " encased in frost!")
    Def = Int(CDbl(Def) * (1# - (0.1 * CDbl(T.Counts(N_COLD))))) 'Def - 5 * T.Counts(N_COLD)
  End If
  
  If A.Counts(N_BLND) > 0 Then
    Call frmCombat.AddEvent(attr & " fighting blind!")
    Att = Int(CDbl(Att) * (1# - (0.1 * CDbl(A.Counts(N_BLND)))))
  End If
  
  If A.Counts(N_BLES) > 0 Then
    Call frmCombat.AddEvent(attr & " imbued with holy power!")
    Att = Int(Att * 2)
  End If
  
  If T.Counts(N_BLES) > 0 Then
    Call frmCombat.AddEvent(subj & " protected by holy power!")
    Def = Int(Def * 2)
  End If
  
  If T.Counts(N_PROT) > 0 Then
    Call frmCombat.AddEvent(subj & " surrounded by a Circle of Protection!")
    Def = Def + T.Reals(S_INT) \ 10
    DR = DR + T.Reals(S_INT) \ 25
  End If
  
  If T.Counts(N_INVS) > 0 Then
    Call frmCombat.AddEvent(subj & " invisible!")
    Def = Int(CDbl(Def) * (1# + (0.1 * CDbl(T.Counts(N_INVS)))))
  End If
  
  hit = Int(Rnd * (Att + Def)) + 1
  If hit <= Att Or Att = -1 Then
    
    If Att = -1 Then
      Damage = 0
    Else
      If A.Counts(N_BLES) > 0 Then
        Dam = Int(Dam * 2)
      End If
      
      If T.Counts(N_BLES) > 0 Then
        DR = Int(DR * 2)
      End If
        
      If (Flags And F_PIRC) And Not (T.Flags And F_PIRC) Then
        Damage = Spread(Dam - (DR / 2), 20) '(((Rnd * Dam) + 1 + (Dam / 2))) '  * Sqr(Att / Max(Def, 1))
        If Int(Rnd * 10) = 0 Then
          Call frmCombat.AddEvent(subj & " !")
          Damage = Damage * 2
        End If
      Else
        Damage = Spread(Dam - DR, 20) ' * Sqr(Att / Max(Def, 1))
      End If
    End If
    
    If (Flags And F_FIRE) Then
'      Damage = Damage + Max(0, Int(Damage * (0.5 * (100 - T.Res(R_FIRE)) / 100)))
      Damage = Damage * 1.5 * (100 - T.Res(R_FIRE)) / 100
      Call frmCombat.AddEvent(subj & " engulfed in flames!")
    End If
      
    If (Flags And F_COLD) Then
'      Damage = Damage + Max(0, Int(Damage * (0.25 * (100 - T.Res(R_COLD)) / 100)))
      Damage = Damage * 1.25 * (100 - T.Res(R_COLD)) / 100
      Call frmCombat.AddEvent(subj & " raked with freezing winds!")
'      T.Counts(N_COLD) = T.Counts(N_COLD) + Max(0, Int(Rnd * 5) * (100 - T.Res(R_COLD)) \ 100 - 1)
      If Rnd * 100 > T.Res(R_COLD) Then
        T.Counts(N_COLD) = Max(Int(Rnd * AttLev / 2) + 2, T.Counts(N_COLD))
      End If
    End If
    
    If (Flags And F_ELEC) Then
'      Damage = Damage + Max(0, Int(Damage * (0.25 * (100 - T.Res(R_ELEC)) / 100)))
      Damage = Damage * 1.25 * (100 - T.Res(R_ELEC)) / 100
      
      Call frmCombat.AddEvent(subj & " jolted with electricity!")
'      T.Counts(N_CONF) = T.Counts(N_CONF) + Max(0, Int(Rnd * 5) * (100 - T.Res(R_ELEC)) \ 100)
      If Rnd * 100 > T.Res(R_ELEC) Then
        T.Counts(N_CONF) = Max(Int(Rnd * AttLev / 2) + 2, T.Counts(N_CONF))
      End If
    End If
    
    If (Flags And F_MAGI) Then
'      Damage = Damage + Max(0, Int(Damage * (0.5 * (100 - T.Res(R_MAGI)) / 100)))
      Damage = Damage * 1.5 * (100 - T.Res(R_MAGI)) / 100
      Call frmCombat.AddEvent(subj & " consumed by magical force!")
    End If
    
    If (Flags And (F_MAGI Or F_FIRE Or F_COLD Or F_ELEC)) = 135 Then
      Damage = Damage \ 1.75
    End If
    
    If (Flags And F_CONF) Then
'      T.Counts(N_CONF) = T.Counts(N_CONF) + Max(0, Int(Rnd * Dam) + Dam \ 2)
      If Not SavingThrow(F_CONF, Flags, T.Flags, AttLev, TarLev) Then
        T.Counts(N_CONF) = Max(Int(Rnd * AttLev) + 2, T.Counts(N_CONF))
        Call frmCombat.AddEvent(subj & " confused!")
      Else
        Call frmCombat.AddEvent(subj & " not confused!")
      End If
    End If
    
    If (Flags And F_POIS) Then
'      T.Counts(N_POIS) = T.Counts(N_POIS) + Max(0, Int(Rnd * Dam) + Dam \ 2)
      If Not SavingThrow(F_POIS, Flags, T.Flags, AttLev, TarLev) Then
        T.Counts(N_POIS) = Max(Int(Rnd * AttLev) + 5, T.Counts(N_POIS))
        Call frmCombat.AddEvent(subj & " poisoned!")
      Else
        Call frmCombat.AddEvent(subj & " not poisoned!")
      End If
    End If
        
    If (Flags And F_SLOW) Then
'      T.Counts(N_SLOW) = T.Counts(N_SLOW) + Int(Rnd * Dam) + Dam \ 2
      If Not SavingThrow(F_SLOW, Flags, T.Flags, AttLev, TarLev) Then
        T.Counts(N_SLOW) = Max(Int(Rnd * AttLev) + 2, T.Counts(N_SLOW))
        Call frmCombat.AddEvent(subj & " slowed!")
      Else
        Call frmCombat.AddEvent(subj & " not slowed down!")
      End If
    End If
    
    If (Flags And F_BLND) Then
'      T.Counts(N_BLND) = T.Counts(N_BLND) + Int(Rnd * Dam) + Dam \ 2
      If Not SavingThrow(F_BLND, Flags, T.Flags, AttLev, TarLev) Then
        T.Counts(N_BLND) = Max(Int(Rnd * AttLev) + 3, T.Counts(N_BLND))
        Call frmCombat.AddEvent(subj & " blinded!")
      Else
        Call frmCombat.AddEvent(subj & " not blinded!")
      End If
    End If
    
    If (Flags And F_SLEP) Then
'      T.Counts(N_SLEP) = T.Counts(N_SLEP) + Int(Rnd * Dam) + Dam \ 2
      If Not SavingThrow(F_SLEP, Flags, T.Flags, AttLev, TarLev) Then
        T.Counts(N_SLEP) = Max(Int(Rnd * AttLev) + 2, T.Counts(N_SLEP))
        Call frmCombat.AddEvent(subj & " put to sleep!")
      Else
        Call frmCombat.AddEvent(subj & " not sleepy!")
      End If
    End If
    
    If (Flags And F_STUN) Then
      If Not SavingThrow(F_STUN, Flags, T.Flags, AttLev, TarLev) Then
        If T Is frmCombat.Enemy Then
          frmCombat.ETime = frmCombat.ETime - 1000
        ElseIf T Is frmCombat.Player Then
          frmCombat.PTime = frmCombat.PTime - 1000
        End If
        Call frmCombat.AddEvent(subj & " stunned!")
      Else
        Call frmCombat.AddEvent(subj & " not stunned!")
      End If
    End If
    
    If Att <> -1 Then
      If Damage < 1 Then Damage = 1
    End If
    
    If (Flags And F_VAMP) Then
      If Not SavingThrow(F_VAMP, Flags, T.Flags, AttLev, TarLev) Then
        A.Dervs(D_CHP) = Min(A.Dervs(D_CHP) + Damage \ 5, A.Dervs(D_HTP))
        Call frmCombat.AddEvent(subj & " drained of lifeforce!")
      Else
        Call frmCombat.AddEvent(subj & " not drained of lifeforce!")
      End If
    End If
    
    T.Dervs(D_CHP) = T.Dervs(D_CHP) - Damage
    
    If T.Counts(N_SLEP) > 0 And Damage >= 0 Then
      T.Counts(N_SLEP) = T.Counts(N_SLEP) - ((Damage \ 10) + 1)
    End If
    
    Exit Function
  Else
    Damage = 0
    Call frmCombat.AddEvent("No damage!")
    Exit Function
  End If
End Function

Public Function SavingThrow(ByVal AT As Long, ByVal AF As Long, ByVal TF As Long, ByVal AL As Integer, ByVal TL As Integer) As Boolean
                          ' attack type, att flags, targ flags, att level,     targ level
'SavingThrow(F_POIS, Flags, T.Flags, AttLev, TarLev)
  If (AT And AF) = 0 Then
    SavingThrow = True
    Exit Function
  End If
  
  If (AT And TF) Then
'    SavingThrow = True
'    Exit Function
    TL = TL * 2
  End If
'  Else
  If Int(Rnd * ((AL + 1) + (TL + 1))) < TL + 1 Then
    SavingThrow = True
    Exit Function
  Else
    SavingThrow = False
    Exit Function
  End If
End Function

Public Function MagicSave(Res As Integer) As Integer
  If Int(Rnd * 100) < Res Then
    MagicSave = 1
  Else
    MagicSave = 0
  End If
End Function

Public Sub RestockAllStores()
  Dim i As Integer
  Dim j As Integer
  Dim r As Integer
  Dim CS As City
  
  frmGame.AddEvent ("Please wait...")
  
  For i = 0 To C_LOCS - 1
    frmGame.txLoc = i
    frmGame.txLoc.Refresh
    If Not World.World(i).LCity Is Nothing Then
      Set CS = World.World(i).LCity
      If CS.T = "City" Then
        For j = 0 To C_STORES - 1
          If CS.Stores(j).T <> -1 Then
            Call CS.Stores(j).Stock
          End If
        Next j
      Else
        Call CS.Stores(0).Stock
      End If
      If CS.T = "Castle" Then
        CS.Conts = CLng(CS.Conts * (1 + (CS.Castle(B_BANK) * (0.05) + (World.World(i).Depth / 100))) + (I_BASE * I_MANT * (CS.Castle(B_MARK) + World.World(i).Depth)))
        If CS.Castle(B_TRAN) > 0 Then
          CS.Pop = Min(CS.Pop + World.World(i).Depth * (2 ^ CS.Castle(B_TRAN)), (World.World(i).Depth ^ 2) * CS.Castle(B_TRAN) * 10)
        End If
        
        If Int(Rnd * 100) > 75 + 5 * CS.Castle(B_WALL) Then
          r = Int(Rnd * B_CAST)
          If r = B_BANK Then
            If CS.Castle(B_BANK) > 0 Then
              If Rnd * 2 = 0 Then
                CS.Castle(B_BANK) = CS.Castle(B_BANK) - 1
                frmGame.AddEvent ("Your castle " & CS.Name & " in sector " & i & " was attacked!")
                frmGame.AddEvent (" The Bank was damaged!")
              Else
                CS.Conts = 0
                frmGame.AddEvent ("Your castle " & CS.Name & " in sector " & i & " was attacked!")
                frmGame.AddEvent (" The Bank was robbed!")
              End If
            End If
          ElseIf r = B_MARK Then
            If CS.Castle(B_MARK) > 0 Then
              If Rnd * 2 = 0 Then
                CS.Castle(B_MARK) = CS.Castle(B_MARK) - 1
                frmGame.AddEvent ("Your castle " & CS.Name & " in sector " & i & " was attacked!")
                frmGame.AddEvent (" The Market was damaged!")
              Else
                CS.Conts = CS.Conts * 0.5
                frmGame.AddEvent ("Your castle " & CS.Name & " in sector " & i & " was attacked!")
                frmGame.AddEvent (" The Market was robbed!")
              End If
            End If
          ElseIf r = B_SPEC Then
          ElseIf r = B_TRAN Then
            If CS.Castle(B_TRAN) > 0 Then
              If Rnd * 2 = 0 Then
                CS.Castle(B_TRAN) = CS.Castle(B_TRAN) - 1
                frmGame.AddEvent ("Your castle " & CS.Name & " in sector " & i & " was attacked!")
                frmGame.AddEvent (" The Trainer was damaged!")
              Else
                CS.Pop = 0
                frmGame.AddEvent ("Your castle " & CS.Name & " in sector " & i & " was attacked!")
                frmGame.AddEvent (" The Trainer was disrupted!")
              End If
            End If
          ElseIf r = B_WALL Then
            If CS.Castle(B_WALL) > 0 Then
              CS.Castle(B_WALL) = CS.Castle(B_WALL) - 1
              frmGame.AddEvent ("Your castle " & CS.Name & " in sector " & i & " was attacked!")
              frmGame.AddEvent (" The Wall was damaged!")
            End If
          End If
        End If
      End If
    End If
  Next i
  
  frmGame.AddEvent ("All stores restocked.")
  
End Sub

Public Sub MovePeople()
  Dim i As Integer
  Dim d As Integer
  Dim c As Integer
  
  For i = 0 To C_PEOPLE - 1
    If People(i).Loc <> -1 Then
      
      d = Int(Rnd * C_MAXCONNECTS)
      For c = 0 To 5
        While (World.World(People(i).Loc).Link(d) = -1)
          d = Int(Rnd * C_MAXCONNECTS)
        Wend
        If People(i).PrefTer <> T_ALL Then
          If World.World(World.World(People(i).Loc).Link(d)).Terrain = People(i).PrefTer Then
            Exit For
          End If
        Else
          Exit For
        End If
      Next c
      
      d = World.World(People(i).Loc).Link(d)
      If (Int(Rnd * 100) < People(i).RoadChance And World.World(d).Road = 1) Or (Int(Rnd * 100) < People(i).NoRoadChance And World.World(d).Road = 0) Then
        If Loc = People(i).Loc Or Loc = d Then
          frmGame.AddEvent (People(i).Name & " moves to " & d)
        End If
        
        People(i).Loc = d
        People(i).Known(d) = 1
        
      End If
      
    End If
  Next i

End Sub

Public Sub PassTime()
  Dim i As Integer
  Dim d As Integer
  Dim c As Integer
  Dim x As Spell
  Static killsector As Integer
  GameDate = DateAdd("d", 1, GameDate)
  If Day(GameDate) = 1 Then
    RestockAllStores
  End If
  
  If Month(GameDate) > 1 And Day(GameDate) Mod 5 = 0 And C_KILLSECTOR = 1 Then
    For i = 0 To C_LOCS - 1
      For d = 0 To 4
        If World.World(i).Link(d) = killsector Then
          World.World(i).Link(d) = -1
        End If
      Next d
    Next i
    killsector = killsector + 1
  End If
  
  If Int(Rnd * char.Player.Dervs(D_HTP)) < char.Player.Dervs(D_HTP) - char.Player.Dervs(D_CHP) Then
      char.Player.Dervs(D_CHP) = Min(char.Player.Dervs(D_CHP) + 1, char.Player.Dervs(D_HTP))
  End If
  If ((char.Player.Flags And F_REGN) And (Int(Rnd * 2) = 0)) Then
      char.Player.Dervs(D_CHP) = Min(char.Player.Dervs(D_CHP) + 1, char.Player.Dervs(D_HTP))
  End If
  If ((char.Player.Flags And F_LIFE)) Then
      char.Player.Dervs(D_CHP) = Min(char.Player.Dervs(D_CHP) + 1, char.Player.Dervs(D_HTP))
  End If
  
  If char.Player.Dervs(D_CHP) > char.Player.Dervs(D_HTP) Then char.Player.Dervs(D_CHP) = char.Player.Dervs(D_CHP) - 1
  If Int(Rnd * 200) < char.Player.Dervs(D_LUK) Or (Int(Rnd * 40) < char.Player.Reals(S_REP) And Int(Rnd * 40) < char.Player.Reals(S_CHA)) Then char.Player.Gold = char.Player.Gold + 1
  
  For Each x In char.Player.Spells
    x.Points = Min(x.Points + char.Player.Reals(S_INT), (char.Player.Reals(S_WIS) * 10)) '\ 20) * x.cost)
  Next x
  
  MovePeople
    
  RefreshGame
End Sub

Public Sub Encounter()
  Dim dep As Integer
  Dim monstername As String
  Dim ambush As Integer
  Dim A As Integer
  Dim te As String
  Dim ans As VbMsgBoxResult
  Dim flee As Integer
  dep = World.World(Loc).Depth - World.World(Loc).Road
  
  If Int(Rnd * (100)) < 40 And frmGame.ckCombat.Value = False And dep >= 0 Then
    If Int(Rnd * 100) < 33 Then
      A = Int(Rnd * 5)
      If World.World(Loc).Link(A) <> -1 Then
        monstername = SelectMonster(World.World(World.World(Loc).Link(A)).Terrain, dep)
      Else
        monstername = SelectMonster(World.World(Loc).Terrain, dep)
      End If
    Else
      monstername = SelectMonster(World.World(Loc).Terrain, dep)
    End If
    
    A = Int(Rnd * 200)
    
    If A < (char.Player.Dervs(D_PER) - dep * 10) Then
      ambush = 1
      flee = -100
      te = "You have ambushed a " & monstername & vbCrLf & "Do you want to fight?"
    ElseIf A > 200 - (dep * 10) + char.Player.Dervs(D_PER) Then
      ambush = 2
      flee = 100
      te = "You have been ambushed by a " & monstername & vbCrLf & "Do you want to fight?"
    Else
      ambush = 0
      flee = 0
      te = "You encounter a " & monstername & vbCrLf & "Do you want to fight?"
    End If
    
    ans = MsgBox(te, vbYesNo + vbCritical + vbQuestion, "Encounter")
        
    If ans = vbNo Then
      If Int(Rnd * 200) < Player.Dervs(D_LUK) Then
        MsgBox "You escape the " & monstername & "'s notice through pure luck."
        Exit Sub
      ElseIf Int(Rnd * (Player.Dervs(D_SPD) + (dep + 1) * 10) + flee) <= Player.Dervs(D_SPD) Then
        MsgBox "You manage to evade the " & monstername & ".", , "Encounter"
        Exit Sub
      Else
        MsgBox "You are unable to escape!", , "Encounter"
      End If
    End If
    
    Call frmCombat.StartCombat(monstername, ambush, frmGame)
  End If
End Sub

Public Function SelectMonster(te As Integer, d As Integer, Optional fixed As Integer = 0) As String
  Dim dep As Integer
  Dim ter As Integer
  If te > T_MAXUSED And te < T_ALL Then
    ter = (te - 1) Mod T_MAXUSED
  Else
    ter = te
  End If
  dep = d
  If ter < T_ALL And fixed = 0 Then
    If Int(Rnd * 100) < 15 Then dep = d + 1
    If Int(Rnd * 100) < 5 Then ter = T_ALL
  End If
'  SelectMonster = "Goblin"
'  Exit Function
  Select Case ter
    Case T_FOR
      Select Case dep
        Case 0
          SelectMonster = "Wild Boar"
        Case 1
          SelectMonster = "Brown Bear"
        Case 2
          SelectMonster = "Pixie"
        Case 3
          SelectMonster = "Shadow Wolf"
        Case 4
          SelectMonster = "Druid Acolyte"
        Case 5
          SelectMonster = "Dryad"
        Case 6
          SelectMonster = "Lightning Bug"
        Case 7
          SelectMonster = "Dark Elf"
        Case 8
          SelectMonster = "Wood Golem"
        Case 9
          SelectMonster = "Vine Grappler"
        Case 10
          SelectMonster = "Forest Troll"
        Case 11
          SelectMonster = "Gaping Maw"
        Case 12
          SelectMonster = "Master Druid"
        Case 13
          SelectMonster = "Dark Elven Ranger"
        Case 14
          SelectMonster = "Treant"
        Case 15
          SelectMonster = "Razor Leaf"
        Case 16
          SelectMonster = "Baby Green Dragon"
        Case 17
          SelectMonster = "Wyvern"
        Case 18
          SelectMonster = "Great Druid"
        Case 19
          SelectMonster = "Green Dragon"
        Case 20
          SelectMonster = "Shadow Walker"
        Case Else
          SelectMonster = "Doodad"
      End Select
    Case T_DES
      Select Case dep
        Case 0
          SelectMonster = "Sand Scorpion"
        Case 1
          SelectMonster = "Dune Dweller"
        Case 2
          SelectMonster = "Sand Shark"
        Case 3
          SelectMonster = "Lesser Basilisk"
        Case 4
          SelectMonster = "Water Pirate"
        Case 5
          SelectMonster = "Bone Eater"
        Case 6
          SelectMonster = "Glass Golem"
        Case 7
          SelectMonster = "Whirling Dervish"
        Case 8
          SelectMonster = "Towering Inferno"
        Case 9
          SelectMonster = "Sun Worshipper"
        Case 10
          SelectMonster = "Sand Golem"
        Case 11
          SelectMonster = "Desert Raider"
        Case 12
          SelectMonster = "Lesser Djinn"
        Case 13
          SelectMonster = "Sun Priest"
        Case 14
          SelectMonster = "Greater Basilisk"
        Case 15
          SelectMonster = "Mummy"
        Case 16
          SelectMonster = "Baby Blue Dragon"
        Case 17
          SelectMonster = "Greater Djinn"
        Case 18
          SelectMonster = "Dust Devil"
        Case 19
          SelectMonster = "Blue Dragon"
        Case 20
          SelectMonster = "Desert Marauder"
      End Select
    Case T_PLN
      Select Case dep
        Case 0
          SelectMonster = "Jackal"
        Case 1
          SelectMonster = "Giant Killer Bee"
        Case 2
          SelectMonster = "Cattle Rustler"
        Case 3
          SelectMonster = "Baby Tremor"
        Case 4
          SelectMonster = "Skeletal Soldier"
        Case 5
          SelectMonster = "Cannibal Warrior"
        Case 6
          SelectMonster = "Bull Lion"
        Case 7
          SelectMonster = "Grass Golem"
        Case 8
          SelectMonster = "Werewolf"
        Case 9
          SelectMonster = "Cannibal Shaman"
        Case 10
          SelectMonster = "Vulture Swarm"
        Case 11
          SelectMonster = "Giant Tremor"
        Case 12
          SelectMonster = "Cannibal Chief"
        Case 13
          SelectMonster = "Wildfire"
        Case 14
          SelectMonster = "Corpse Golem"
        Case 15
          SelectMonster = "Manticore"
        Case 16
          SelectMonster = "Baby Brass Dragon"
        Case 17
          SelectMonster = "Celestial Spirit"
        Case 18
          SelectMonster = "Phoenix"
        Case 19
          SelectMonster = "Brass Dragon"
        Case 20
          SelectMonster = "Whispering Wind"
      End Select
    Case T_HIL
      Select Case dep
        Case 0
          SelectMonster = "Dingo"
        Case 1
          SelectMonster = "Fighting Falcon"
        Case 2
          SelectMonster = "Fire Ant"
        Case 3
          SelectMonster = "Herdsman"
        Case 4
          SelectMonster = "Illusionary"
        Case 5
          SelectMonster = "Spitting Snake"
        Case 6
          SelectMonster = "Cheetah"
        Case 7
          SelectMonster = "Huntsman"
        Case 8
          SelectMonster = "Centipede"
        Case 9
          SelectMonster = "Hill Giant"
        Case 10
          SelectMonster = "Barrow Wight"
        Case 11
          SelectMonster = "Hedge Wizard"
        Case 12
          SelectMonster = "Hill Troll"
        Case 13
          SelectMonster = "Living Hill"
        Case 14
          SelectMonster = "Warsman"
        Case 15
          SelectMonster = "Wild Beast"
        Case 16
          SelectMonster = "Baby Copper Dragon"
        Case 17
          SelectMonster = "Phantom Flyer"
        Case 18
          SelectMonster = "Integer Walker"
        Case 19
          SelectMonster = "Copper Dragon"
        Case 20
          SelectMonster = "Gargantuan"
      End Select
    Case T_JUN
      Select Case dep
        Case 0
          SelectMonster = "Nail Blossom"
        Case 1
          SelectMonster = "Tree Python"
        Case 2
          SelectMonster = "Black Jaguar"
        Case 3
          SelectMonster = "Tiny Pygmy"
        Case 4
          SelectMonster = "War Elephant"
        Case 5
          SelectMonster = "Witch Doctor"
        Case 6
          SelectMonster = "Panthaur"
        Case 7
          SelectMonster = "Pygmy Hunter"
        Case 8
          SelectMonster = "Branchlurker"
        Case 9
          SelectMonster = "Slash Burner"
        Case 10
          SelectMonster = "Razor Lily"
        Case 11
          SelectMonster = "Burrowing Beetle"
        Case 12
          SelectMonster = "Fire Flower"
        Case 13
          SelectMonster = "Treefeller"
        Case 14
          SelectMonster = "Hardwood Fist"
        Case 15
          SelectMonster = "Giant Pygmy"
        Case 16
          SelectMonster = "Baby Purple Dragon"
        Case 17
          SelectMonster = "Green Knight"
        Case 18
          SelectMonster = "Emerald Giant"
        Case 19
          SelectMonster = "Purple Dragon"
        Case 20
          SelectMonster = "Vast Entangler"
      End Select
    Case T_MTN
      Select Case dep
        Case 0
          SelectMonster = "Rubble"
        Case 1
          SelectMonster = "Mountaineer"
        Case 2
          SelectMonster = "Hill Bandit"
        Case 3
          SelectMonster = "Rock Gorger"
        Case 4
          SelectMonster = "Shockrock"
        Case 5
          SelectMonster = "Redhat"
        Case 6
          SelectMonster = "Stonesinger"
        Case 7
          SelectMonster = "Wallvise"
        Case 8
          SelectMonster = "Blind Monk"
        Case 9
          SelectMonster = "Duegar Berserker"
        Case 10
          SelectMonster = "Credible Hulk"
        Case 11
          SelectMonster = "Magma Spout"
        Case 12
          SelectMonster = "Silent Monk"
        Case 13
          SelectMonster = "Mountain Troll"
        Case 14
          SelectMonster = "Cloudkiller"
        Case 15
          SelectMonster = "Duegar King"
        Case 16
          SelectMonster = "Baby Red Dragon"
        Case 17
          SelectMonster = "Lavalisp"
        Case 18
          SelectMonster = "Roc"
        Case 19
          SelectMonster = "Red Dragon"
        Case 20
          SelectMonster = "Marauding Avalanche"
      End Select
    Case T_SWP
      Select Case dep
        Case 0
          SelectMonster = "Gulp Froggy"
        Case 1
          SelectMonster = "Tree Shadow"
        Case 2
          SelectMonster = "Water Bug"
        Case 3
          SelectMonster = "Slime Climber"
        Case 4
          SelectMonster = "Quick Sander"
        Case 5
          SelectMonster = "Vampire Mosquito"
        Case 6
          SelectMonster = "Willow Wisp"
        Case 7
          SelectMonster = "Hidden Tentacle"
        Case 8
          SelectMonster = "Carrion Crawler"
        Case 9
          SelectMonster = "Dark Naiad"
        Case 10
          SelectMonster = "Mud Witch"
        Case 11
          SelectMonster = "Babeater"
        Case 12
          SelectMonster = "Weeping Willow"
        Case 13
          SelectMonster = "Black Ooze"
        Case 14
          SelectMonster = "Gaseous Emission"
        Case 15
          SelectMonster = "Bog Wraith"
        Case 16
          SelectMonster = "Baby Black Dragon"
        Case 17
          SelectMonster = "Acidic Slime"
        Case 18
          SelectMonster = "Old Man Willow"
        Case 19
          SelectMonster = "Black Dragon"
        Case 20
          SelectMonster = "Black Bog Creature"
      End Select
    Case T_TUN
      Select Case dep
        Case 0
          SelectMonster = "Snow Bunny"
        Case 1
          SelectMonster = "Manrus"
        Case 2
          SelectMonster = "Beastadon"
        Case 3
          SelectMonster = "Snow Eagle"
        Case 4
          SelectMonster = "White Wolf"
        Case 5
          SelectMonster = "Cavern Creeper"
        Case 6
          SelectMonster = "Flickering Doom"
        Case 7
          SelectMonster = "Crazed Mammoth"
        Case 8
          SelectMonster = "Snow Drift"
        Case 9
          SelectMonster = "Living Icicle"
        Case 10
          SelectMonster = "Howling Madman"
        Case 11
          SelectMonster = "Ice Wight"
        Case 12
          SelectMonster = "Snowblind Enchantress"
        Case 13
          SelectMonster = "Ice Troll"
        Case 14
          SelectMonster = "Frigid Elf Maiden"
        Case 15
          SelectMonster = "Snow Ghast"
        Case 16
          SelectMonster = "Baby White Dragon"
        Case 17
          SelectMonster = "Freezing Flame"
        Case 18
          SelectMonster = "Abominable Snowman"
        Case 19
          SelectMonster = "White Dragon"
        Case 20
          SelectMonster = "Blizzard Beast"
      End Select
    Case T_ALL
      SelectMonster = "Thief"
    Case T_GHOST
      SelectMonster = "Ghost"
    Case T_GOBLIN
      SelectMonster = "Goblin"
  End Select
End Function
