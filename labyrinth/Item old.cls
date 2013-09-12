VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "Item"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Option Explicit

Public Name As String
Public Use As Integer ' type of item
Public Stat As Integer ' stat used by item
Public Ele As String ' element of item
Public Post As String

Public Att As Integer ' attack
Public Dam As Integer ' damage

Public Def As Integer ' defense
Public DR As Integer ' damage reduction
Public Speed As Integer
Public Value As Long
Public Depth As Integer
Public Text As String
Public UnIDText As String
Public ID As Boolean
Public LastID As Date
Public num As Integer
Public Attack As String
Private Statistics(0 To 6) As Integer
Public Flags As Long
Public CreatedAs As String
Private Resistances(0 To C_RESISTS - 1) As Integer


Public Sub UseF(self As Integer)
  Dim cap As String
  Dim S As String
  Dim remove As Integer
  Dim ic As Integer
  Dim up As Integer
  Dim x As Spell
  
  If frmCombat Is Nothing Then
    ic = 0
  Else
    ic = frmCombat.InCombat
  End If
  
  
  cap = "Use " & Name
  
  If Name = "Strength Potion" Then
    remove = 1
    up = Int(Rnd * 5) + 6
    char.Player.Stats(S_STR) = char.Player.Stats(S_STR) + up
    S = "Strength Increased Permanently By " & up & "."
  ElseIf Left(Name, 14) = "Healing Potion" Then
    remove = 1
    up = Dice(Depth + 1, 10) + 10
    char.Player.Dervs(D_CHP) = Min(char.Player.Dervs(D_CHP) + up, char.Player.Dervs(D_HTP))
    S = "The potion heals " & up & " points."
  ElseIf Name = "Flash Blinder" And ic = 1 Then
    remove = 0
    Call Damage(-1, 3, 0, 0, F_CONF, char.Player, frmCombat.Enemy)
  ElseIf Name = "Map" Then
    remove = 0
    S = "You inspect the map carefully."
    frmGame.txShowRoute.Text = CalcRoute(Me.Att, 1)
    If frmGame.txShowRoute.Text <> "Bad Dest" Then
      frmGame.cmdRoute.Caption = "Move Route"
      frmGame.cmdRoute.Enabled = True
    End If
  ElseIf Name = "Scroll" Then
    Dim newspell As Integer
    newspell = 1
    remove = 1
    
    Dim It As New Spell
    Call It.MakeSpell(Att)
    For Each x In char.Player.Spells
      If x.Key = It.Key Then newspell = 0
    Next x
    If newspell = 1 And ID = True Then
      Call char.Player.Spells.Add(It, It.Key)
      S = "You add " & It.Key & " to your spellbook."
    ElseIf ID = True Then
      remove = 0
      S = "You already know that spell."
    ElseIf ID = False Then
      remove = 0
      S = "You don't know what spell is on this scroll."
    End If
    
  ElseIf Name = "Drink" Then
    remove = 0
    S = "Mmmm liquid frothy goodness."
  ElseIf Name = "Room for the Night" Then
    remove = 0
    S = "You rest for the night."
    char.Player.Dervs(D_CHP) = char.Player.Dervs(D_HTP)
    PassTime
  Else
    S = "That item cannot be used now."
  End If
  
  If remove = 1 Then
'    num = num - 1
'    If num <= 0 Then
      char.Player.Inven(self) = Nothing
'    End If
  End If
  
  If S <> "" Then
    MsgBox S, , cap
  End If
End Sub



    'attack = ""
    'Use =
    'Stat =
    'att =
    'dam =
    'def =
    'dr =
    'text = Use & ": " & name & ""
    'value
    'depth
    'num


Public Sub MakeItem(S As String, Optional a As Integer = 0, Optional b As Integer = 0, Optional flgs As Long = 0, Optional e As Long = 0, Optional f As Long = 0, Optional dep As Integer = -1, Optional Identified As Boolean = False)
  Dim ec As Integer
  Dim fc As Integer
  Dim ndr As Integer
  
  Me.Clear
  
  CreatedAs = S
  ID = Identified
  
  If dep <> -1 Then
    Depth = dep
  End If
   
  If S = "Knife" Then
    Attack = "NormalDex"
    Use = E_WEP
    Stat = S_DEX
    Att = Max(Int(Rnd * 8), 5)
    Dam = Max(Int(Rnd * 5), 2)
    Value = Max(50 + Att * 10 + Dam * 20, 100)
'    Depth = 0
  ElseIf S = "Short Sword" Then
    Attack = "NormalDex"
    Use = E_WEP
    Stat = S_DEX
    Att = Max(Int(Rnd * 14), 7)
    Dam = Max(Int(Rnd * 6), 3)
    Value = Max(200 + Att * 20 + Dam * 40, 100)
  ElseIf S = "Truncheon" Then
    Attack = "NormalDex"
    Use = E_WEP
    Stat = S_DEX
    Flags = Flags Or F_FAST
    Att = Max(Int(Rnd * 20), 12)
    Dam = Max(Int(Rnd * 8), 5)
    Value = Max(400 + Att * 40 + Dam * 80, 100)
  ElseIf S = "Rapier" Then
    Attack = "NormalDex"
    Use = E_WEP
    Stat = S_DEX
    Att = Max(Int(Rnd * 30), 22)
    Dam = Max(Int(Rnd * 16), 8)
    Value = Max(1000 + Att * 50 + Dam * 100, 100)
  ElseIf S = "Staff" Then
    Attack = "NormalDex"
    Use = E_WEP
    Stat = S_DEX
    Def = 5
    Att = Max(Int(Rnd * 45), 29)
    Dam = Max(Int(Rnd * 20), 13)
    Value = Max(2000 + Att * 50 + Dam * 100, 100)
    Value = Value + 20 * Def
  ElseIf S = "Sabre" Then
    Attack = "NormalDex"
    Use = E_WEP
    Stat = S_DEX
    Att = Max(Int(Rnd * 45), 35)
    Dam = Max(Int(Rnd * 21), 13)
    Value = Max(3500 + Att * 50 + Dam * 100, 100)
  ElseIf S = "Nunchuckas" Then
    Attack = "NinjaDex"
    Use = E_WEP
    Stat = S_DEX
    Def = 5
    Att = Max(Int(Rnd * 60), 40)
    Dam = Max(Int(Rnd * 30), 20)
    Value = Max(5000 + Att * 50 + Dam * 100, 100)
    Value = Value + 20 * Def
  ElseIf S = "Katana" Then
    Attack = "NinjaDex"
    Use = E_WEP
    Stat = S_DEX
    Att = Max(Int(Rnd * 70), 55)
    Dam = Max(Int(Rnd * 35), 25)
    Value = Max(7000 + Att * 50 + Dam * 100, 100)
  
  ElseIf S = "Short Bow" Then
    Attack = "Bow"
    Use = E_WEP
    Stat = S_DEX
    Flags = Flags Or F_HYPR
    Att = Max(Int(Rnd * 30), 20)
    Dam = Max(Int(Rnd * 6), 3)
    Value = Max(1000 + Att * 50 + Dam * 100, 100)
  ElseIf S = "Long Bow" Then
    Attack = "Bow"
    Use = E_WEP
    Stat = S_DEX
    Flags = Flags Or F_HYPR
    Att = Max(Int(Rnd * 40), 25)
    Dam = Max(Int(Rnd * 8), 5)
    Value = Max(4000 + Att * 50 + Dam * 100, 100)
  
  ElseIf S = "Dagger" Then
    Attack = "NormalStr"
    Use = E_WEP
    Stat = S_STR
    Att = Max(Int(Rnd * 8), 5)
    Dam = Max(Int(Rnd * 5), 2)
    Value = Max(50 + Att * 10 + Dam * 20, 100)
'    Depth = 0
  ElseIf S = "Mace" Then
    Attack = "NormalStr"
    Use = E_WEP
    Stat = S_STR
    Att = Max(Int(Rnd * 12), 6)
    Dam = Max(Int(Rnd * 7), 3)
    Value = Max(200 + Att * 20 + Dam * 40, 100)
  ElseIf S = "Longsword" Then
    Attack = "NormalStr"
    Use = E_WEP
    Stat = S_STR
    Att = Max(Int(Rnd * 20), 12)
    Dam = Max(Int(Rnd * 10), 6)
    Value = Max(400 + Att * 40 + Dam * 80, 100)
  ElseIf S = "Battle Axe" Then
    Attack = "NormalStr"
    Use = E_WEP
    Stat = S_STR
    Att = Max(Int(Rnd * 18), 10)
    Dam = Max(Int(Rnd * 16), 8)
    Value = Max(400 + Att * 40 + Dam * 80, 100)
  ElseIf S = "Broadsword" Then
    Attack = "NormalStr"
    Use = E_WEP
    Stat = S_STR
    Att = Max(Int(Rnd * 26), 18)
    Dam = Max(Int(Rnd * 16), 10)
    Value = Max(1000 + Att * 50 + Dam * 100, 100)
  ElseIf S = "Great Axe" Then
    Attack = "NormalStr"
    Use = E_WEP
    Stat = S_STR
    Att = Max(Int(Rnd * 22), 15)
    Dam = Max(Int(Rnd * 22), 14)
    Value = Max(1000 + Att * 50 + Dam * 100, 100)
  ElseIf S = "Bastard Sword" Then
    Attack = "NormalStr"
    Use = E_WEP
    Stat = S_STR
    Att = Max(Int(Rnd * 36), 25)
    Dam = Max(Int(Rnd * 22), 15)
    Value = Max(2000 + Att * 50 + Dam * 100, 100)
  ElseIf S = "Flail" Then
    Attack = "NormalStr"
    Use = E_WEP
    Stat = S_STR
    Att = Max(Int(Rnd * 40), 30)
    Dam = Max(Int(Rnd * 23), 15)
    Value = Max(3500 + Att * 50 + Dam * 100, 100)
  ElseIf S = "Halberd" Then
    Attack = "NormalStr"
    Use = E_WEP
    Stat = S_STR
    Att = Max(Int(Rnd * 38), 28)
    Dam = Max(Int(Rnd * 25), 18)
    Value = Max(3500 + Att * 50 + Dam * 100, 100)
  ElseIf S = "Naginata" Then
    Attack = "NinjaStr"
    Use = E_WEP
    Stat = S_STR
    Att = Max(Int(Rnd * 50), 35)
    Dam = Max(Int(Rnd * 33), 25)
    Value = Max(5000 + Att * 50 + Dam * 100, 100)
  ElseIf S = "Greatsword" Then
    Attack = "NormalStr"
    Use = E_WEP
    Stat = S_STR
    Att = Max(Int(Rnd * 60), 45)
    Dam = Max(Int(Rnd * 40), 30)
    Value = Max(7000 + Att * 50 + Dam * 100, 100)
    
  ElseIf S = "Clothing" Then
    Attack = ""
    Use = E_ARM
    Def = 4 + Int(Rnd * 3)
    Value = 50 + 10 * Def
  ElseIf S = "Padded Leather" Then
    Use = E_ARM
    Def = 6 + Int(Rnd * 3)
    DR = Int(Rnd * 2)
    Value = 100 + 20 * Def + 40 * DR
  ElseIf S = "Hard Leather" Then
    Use = E_ARM
    Def = 8 + Int(Rnd * 5)
    DR = Int(Rnd * 2) + 1
    Value = 200 + 40 * Def + 80 * DR
  ElseIf S = "Hunting Leather" Then
    Use = E_ARM
    Def = 11 + Int(Rnd * 5)
    DR = Int(Rnd * 3) + 2
    Value = 400 + 50 * Def + 100 * DR
  ElseIf S = "Ring Mail" Then
    Use = E_ARM
    Def = 15 + Int(Rnd * 5)
    DR = Int(Rnd * 3) + 2
    Value = 600 + 50 * Def + 100 * DR
  ElseIf S = "Scale Mail" Then
    Use = E_ARM
    Def = 20 + Int(Rnd * 5)
    DR = Int(Rnd * 3) + 3
    Value = 1000 + 50 * Def + 100 * DR
  ElseIf S = "Chain Mail" Then
    Use = E_ARM
    Def = 25 + Int(Rnd * 6)
    DR = Int(Rnd * 3) + 4
    Value = 1500 + 50 * Def + 100 * DR
  ElseIf S = "Brigantine" Then
    Use = E_ARM
    Def = 31 + Int(Rnd * 5)             '15
    DR = Int(Rnd * 4) + 4
    Value = 2500 + 50 * Def + 100 * DR
  ElseIf S = "Plate Mail" Then
    Use = E_ARM
    Def = 38 + Int(Rnd * 5)
    DR = Int(Rnd * 3) + 5
    Value = 3500 + 50 * Def + 100 * DR
  ElseIf S = "Full Plate" Then
    Use = E_ARM
    Def = 45 + Int(Rnd * 5)              '20
    DR = Int(Rnd * 3) + 6
    Value = 6000 + 50 * Def + 100 * DR
  ElseIf S = "Field Plate" Then
    Use = E_ARM
    Def = 53 + Int(Rnd * 5)               '25
    DR = Int(Rnd * 3) + 7
    Value = 7000 + 50 * Def + 100 * DR
  
  ElseIf S = "Mithril Chain Mail" Then
    Use = E_ARM
    Def = 40 + Int(Rnd * 10)
    DR = Int(Rnd * 3) + 5
    Value = 10000 + 50 * Def + 100 * DR
    Res(R_FIRE) = 20
    Res(R_COLD) = 20
    Res(R_MAGI) = 20
    Res(R_ELEC) = 20
  ElseIf S = "Adamantite Full Plate" Then
    Use = E_ARM
    Def = 60 + Int(Rnd * 15)
    DR = Int(Rnd * 3) + 10
    Value = 15000 + 50 * Def + 100 * DR
    
  ElseIf S = "Buckler" Then
    Use = E_SLD
    Def = 1 + Int(Rnd * 3)
    DR = Int(Rnd * 2)
    Value = 100 + 50 * Def + 100 * DR
  ElseIf S = "Arm Shield" Then
    Use = E_SLD
    Def = 3 + Int(Rnd * 3)
    DR = Int(Rnd * 2) + 1
    Value = 500 + 50 * Def + 100 * DR
  ElseIf S = "Kite Shield" Then
    Use = E_SLD
    Def = 6 + Int(Rnd * 3)
    DR = Int(Rnd * 2) + 2
    Value = 1000 + 50 * Def + 100 * DR
  ElseIf S = "Tower Shield" Then
    Use = E_SLD
    Def = 10 + Int(Rnd * 5)
    DR = Int(Rnd * 3) + 2
    Value = 2000 + 50 * Def + 100 * DR
  ElseIf S = "Mirror Shield" Then
    Use = E_SLD
    Def = 13 + Int(Rnd * 5)
    DR = Int(Rnd * 3) + 3
    Value = 4000 + 50 * Def + 100 * DR
    
  ElseIf S = "Sandals" Then
    Use = E_BTS
    Def = Int(Rnd * 2)
    Value = 150 + 100 * Def
  ElseIf S = "Shoes" Then
    Use = E_BTS
    Def = Int(Rnd * 3)
    Value = 400 + 100 * Def
  ElseIf S = "Riding Boots" Then
    Use = E_BTS
    Def = 2 + Int(Rnd * 5)
    Value = 900 + 100 * Def
  ElseIf S = "Iron Boots" Then
    Use = E_BTS
    Def = 3 + Int(Rnd * 6)
    Value = 1800 + 100 * Def
  ElseIf S = "War Boots" Then
    Use = E_BTS
    Def = 4 + Int(Rnd * 7)
    Stats(S_STR) = Int(Rnd * Depth)
    Stats(S_DEX) = Int(Rnd * Depth)
    Value = 3500 + 100 * Def
    
  ElseIf S = "Leather Gloves" Then
    Use = E_GNT
    Dam = 0 + Int(Rnd * 3)
    Def = 1
    Value = 200 * Dam + 50
  ElseIf S = "Brass Knuckles" Then
    Use = E_GNT
    Dam = 1 + Int(Rnd * 3)
    Def = 1
    Value = 200 * Dam + 50
  ElseIf S = "Chain Gloves" Then
    Use = E_GNT
    Dam = 1 + Int(Rnd * 2)
    Def = 4 + Int(Rnd * 3)
    Value = 200 + 200 * Dam + 50 * Def
  ElseIf S = "Plated Gauntlets" Then
    Use = E_GNT
    Dam = 2 + Int(Rnd * 2)
    Def = 6 + Int(Rnd * 4)
    Value = 500 + 200 * Dam + 50 * Def
  ElseIf S = "Knife Gloves" Then
    Use = E_GNT
    Dam = 3 + Int(Rnd * 3)
    Def = 4 + Int(Rnd * 2)
    Value = 1000 + 200 * Dam + 50 * Def
  ElseIf S = "Steel Gauntlets" Then
    Use = E_GNT
    Dam = 2 + Int(Rnd * 3)
    Def = 8 + Int(Rnd * 4)
    Value = 2000 + 200 * Dam + 50 * Def
  ElseIf S = "Set of Cesti" Then
    Use = E_GNT
    Dam = 4 + Int(Rnd * 4)
    Def = 6 + Int(Rnd * 2)
    Value = 3500 + 200 * Dam + 50 * Def
    
  ElseIf S = "Leather Cap" Then
    Use = E_HLM
    Def = 1 + Int(Rnd * 2)
    DR = 0
    Value = 50 + 100 * Def + 200 * DR
  ElseIf S = "Leather Hood" Then
    Use = E_HLM
    Def = 2 + Int(Rnd * 2)
    DR = 0
    Value = 100 + 100 * Def + 200 * DR
  ElseIf S = "Chain Coif" Then
    Use = E_HLM
    Def = 3 + Int(Rnd * 3)
    DR = Int(Rnd * 2)
    Value = 200 + 100 * Def + 200 * DR
  ElseIf S = "Steel Cap" Then
    Use = E_HLM
    Def = 4 + Int(Rnd * 3)
    DR = Int(Rnd * 3)
    Value = 500 + 100 * Def + 200 * DR
  ElseIf S = "Plate Coif" Then
    Use = E_HLM
    Def = 6 + Int(Rnd * 3)
    DR = 1 + Int(Rnd * 3)
    Value = 1000 + 100 * Def + 200 * DR
  ElseIf S = "Horned Mask" Then
    Use = E_HLM
    Def = 12 + Int(Rnd * 2)
    DR = 0
    Value = 2000 + 100 * Def + 200 * DR
  ElseIf S = "Great Helm" Then
    Use = E_HLM
    Def = 10 + Int(Rnd * 3)
    DR = 2 + Int(Rnd * 3)
    Value = 4000 + 100 * Def + 200 * DR
    
  ElseIf S = "Ring" Then
    Use = E_RG1
    Value = 0 'Depth * 100 + 100
    If Int(Rnd * 100) < 10 Then
      e = 100
      f = 100
    Else
      If Int(Rnd * 100) < 50 Then
        e = 100
      Else
        f = 100
      End If
    End If
  ElseIf S = "Ring of Protection" Then
    Name = "Ring of Protection, +" & a
    Use = E_RG1
    Def = 5 * a
    DR = a
    Value = a * 1500
    Depth = 5
  ElseIf S = "Plain Ring" Then
    Use = E_RG1
    Stat = 0
    Stats(S_CHA) = Int(Rnd * 5) + 6
    Value = Stats(S_CHA) * 15 + 30
    Depth = 0
  ElseIf S = "Strength Potion" Then
    Name = "Strength Potion"
    Use = E_NON
    Value = 3500
    Depth = 5
'    num = A
  ElseIf S = "Healing Potion" Then
    Name = "Healing Potion" & " L:" & a
    Use = E_NON
    Value = 100 * (a + 1)
    Depth = a
'    num = 1
  ElseIf S = "Flash Blinder" Then
    Attack = ""
    Use = E_NON
    Value = 300
    Depth = 2
  ElseIf S = "Sword of Giants" Then
    Attack = "Sword of Giants"
    Use = E_WEP
    Stat = S_STR
    Att = 40 + 2 * a
    Dam = 20 + a
    Stats(S_STR) = 100 + a * 5
    Value = 35000
    Depth = 15
  ElseIf S = "Map" Then
    Post = " to " & a
    Use = E_NON
    Att = a
    Value = 200
    Depth = 0
'    num = 1
  ElseIf S = "Scroll" Then
    Use = E_NON
    If a = M_MMIS Then
      Post = " of Magic Missile"
      Value = 1500
    ElseIf a = M_HEAL Then
      Post = " of Heal"
      Value = 2000
    ElseIf a = M_TELE Then
      Post = " of Teleport"
      Value = 2000
    ElseIf a = M_STUN Then
      Post = " of Stun"
      Value = 5000
    ElseIf a = M_TOWN Then
      Post = " of Town Portal"
      Value = 2500
    ElseIf a = M_FAST Then
      Post = " of Haste"
      Value = 3000
    ElseIf a = M_SLOW Then
      Post = " of Slow"
      Value = 2000
    ElseIf a = M_BLES Then
      Post = " of Bless"
      Value = 6000
    ElseIf a = M_FIRE Then
      Post = " of Fireball"
      Value = 3500
    ElseIf a = M_COLD Then
      Post = " of Ice Storm"
      Value = 3500
    ElseIf a = M_ELEC Then
      Post = " of Lighning Bolt"
      Value = 3500
    End If
    Att = a
'    num = 1
  ElseIf S = "Room for the Night" Then
    Use = E_SER
    Value = Int(10 * (1.3 ^ (a)))
    Depth = a
  ElseIf S = "Drink" Then
    Use = E_SER
    Value = Int(2 * (1.3 ^ (a)))
    Depth = a
  Else
    Name = "Doodad, probably an error"
    Use = E_NON
    Stat = S_STR
    Text = Use & ": Doodad, probably an error"
  End If
  
  If Int(Rnd * 100) < e Then
    ec = Int(Rnd * 8)
    If ec = 0 Then
      Ele = "Flame "
      Flags = Flags Or F_FIRE
      Res(R_FIRE) = Rnd * (Me.Depth + 5) + 5
    ElseIf ec = 1 Then
      Ele = "Frost "
      Flags = Flags Or F_COLD
      Res(R_COLD) = Rnd * (Me.Depth + 5) + 5
    ElseIf ec = 2 Then
      Ele = "Electric "
      Flags = Flags Or F_ELEC
      Res(R_ELEC) = Rnd * (Me.Depth + 5) + 5
    ElseIf ec = 3 Then
      Ele = "Prismatic "
      Flags = Flags Or F_CONF
      Res(R_MAGI) = Rnd * (Me.Depth + 5) + 5
    ElseIf ec = 4 Then
      Ele = "Vorpal "
      Flags = Flags Or F_PIRC
      DR = DR * 2
    ElseIf ec = 5 Then
      Ele = "Gravity "
      Flags = Flags Or F_SLOW
    ElseIf ec = 6 Then
      Ele = "Poison "
      Flags = Flags Or F_POIS
    ElseIf ec = 7 And Int(Rnd * 200) < e Then
      Ele = "Arcane "
      Flags = Flags Or F_FIRE Or F_COLD Or F_ELEC Or F_MAGI
      Res(R_FIRE) = Rnd * -20 - 1
      Res(R_COLD) = Rnd * -20 - 1
      Res(R_ELEC) = Rnd * -20 - 1
      Res(R_MAGI) = Rnd * -20 - 1
    End If
  End If
  
  If Int(Rnd * 100) < f Then
    fc = Int(Rnd * 13)
    If fc = 0 Then
      Post = " of Agility"
      Stats(S_DEX) = Int((Rnd * Me.Depth + 5) * (Rnd * 2 + 1))
    ElseIf fc = 1 Then
      Post = " of Strength"
      Stats(S_STR) = Int((Rnd * Me.Depth + 5) * (Rnd * 2 + 1))
    ElseIf fc = 2 Then
      Post = " of Health"
      Stats(S_CON) = Int((Rnd * Me.Depth + 5) * (Rnd * 2 + 1))
    ElseIf fc = 3 Then
      Post = " of Genius"
      Stats(S_INT) = Int((Rnd * Me.Depth + 5) * (Rnd * 2 + 1))
    ElseIf fc = 4 Then
      Post = " of Wisdom"
      Stats(S_WIS) = Int((Rnd * Me.Depth + 5) * (Rnd * 2 + 1))
    ElseIf fc = 5 Then
      Post = " of Beauty"
      Stats(S_CHA) = Int((Rnd * Me.Depth + 5) * (Rnd * 2 + 1))
    ElseIf fc = 6 Then
      Post = " of Speed"
      Speed = Int((Rnd * Me.Depth + 5) * (Rnd * 2 + 2))
    ElseIf fc = 7 Then
      Post = " of Shielding"
      ' deal with at bottom
    ElseIf fc = 8 Then
      Post = " of Reknown"
      Stats(S_REP) = (Rnd * Me.Depth + 5) * (Rnd * 2 + 1)
    ElseIf fc = 9 Then
      Post = " of Absorption"
      ' deal with at bottom
    ElseIf fc = 10 Then
      Post = " of Regeneration"
      Flags = Flags Or F_REGN
      Value = Value + C_STATCOST * 7
    ElseIf fc = 11 Then
      Post = " of Life"
      Flags = Flags Or F_LIFE
      Value = Value + C_STATCOST * 33
    ElseIf fc = 12 Then
      Post = " of Haste"
      Flags = Flags Or F_FAST
      Value = Value + C_STATCOST * 7
    ElseIf fc = 13 Then
      Post = " of Hyper"
      Flags = Flags Or F_HYPR
      Value = Value + C_STATCOST * 33
    ElseIf fc = 14 Then
      Post = " of the Magi"
      Stats(S_INT) = (Rnd * Me.Depth + 1) * (Rnd * 4 + 1)
      Stats(S_WIS) = (Rnd * Me.Depth + 1) * (Rnd * 4 + 1)
'      Stats(S_STR) = -(Rnd * Me.Depth + 1) * (Rnd * 4 + 1)
    ElseIf fc = 15 Then
      Post = " of War"
      Stats(S_DEX) = (Rnd * Me.Depth + 1) * (Rnd * 4 + 1)
      Stats(S_STR) = (Rnd * Me.Depth + 1) * (Rnd * 4 + 1)
'      Stats(S_INT) = -(Rnd * Me.Depth + 1) * (Rnd * 4 + 1)
    ElseIf fc = 16 Then
      Post = " of Thieves"
      Stats(S_DEX) = (Rnd * Me.Depth + 1) * (Rnd * 8 + 1)
      Stats(S_REP) = -((Rnd * Me.Depth + 1) * (Rnd * 8 + 1))
    End If
  End If
  
  Flags = Flags Or flgs
  UnIDText = Use & ": " & S
  If Name = "" Then
    Name = Ele & S & Post
  Else
    Name = Ele & Name & Post
  End If
  Text = Use & ": " & Name
  
  If num = 0 Then num = 1
   
  If S = "Scroll" Then
    Name = "Scroll"
  ElseIf S = "Map" Then
    Name = "Map"
  End If
  
  If Ele <> "" Then Value = Value * 1.5
  If Ele = "Arcane " Then
    Value = Value * 1.5
    If Use <> E_WEP Then
      Res(R_FIRE) = -Res(R_FIRE)
      Res(R_COLD) = -Res(R_COLD)
      Res(R_ELEC) = -Res(R_ELEC)
      Res(R_MAGI) = -Res(R_MAGI)
    End If
  End If
  If Post <> "" Then Value = Value * 1
  
  If Post = " of Absorption" Then
    ndr = ((Rnd * Me.Depth) \ 2) + 1
    DR = DR + ndr
    Value = Value + ndr * C_STATCOST * 2
  ElseIf Post = " of Shielding" Then
    ndr = ((Rnd * Me.Depth)) + 5
    Def = Def + ndr
    Value = Value + ndr * C_STATCOST \ 2
  End If
    'att =
    'dam =
    'def =
    'dr =
  If Att <> 0 And Use <> E_NON And Use <> E_SER Then
    If Stat = S_STR Then
      Text = Text & " StAt:" & Att
    ElseIf Stat = S_DEX Then
      Text = Text & " DxAt:" & Att
    End If
  End If
  If Dam <> 0 Then
    Text = Text & " Dm:" & Dam
  End If
  If Def <> 0 Then
    Text = Text & " Df:" & Def
  End If
  If DR <> 0 Then
    Text = Text & " DR:" & DR
  End If
  
  If Stats(S_STR) <> 0 Then
    Text = Text & " St:" & Stats(S_STR)
    Value = Value + C_STATCOST * Stats(S_STR)
  End If
  If Stats(S_DEX) <> 0 Then
    Text = Text & " Dx:" & Stats(S_DEX)
    Value = Value + C_STATCOST * Stats(S_DEX)
  End If
  If Stats(S_CON) <> 0 Then
    Text = Text & " Cn:" & Stats(S_CON)
    Value = Value + C_STATCOST * Stats(S_CON)
  End If
  If Stats(S_INT) <> 0 Then
    Text = Text & " In:" & Stats(S_INT)
    Value = Value + C_STATCOST * Stats(S_INT)
  End If
  If Stats(S_WIS) <> 0 Then
    Text = Text & " Wi:" & Stats(S_WIS)
    Value = Value + C_STATCOST * Stats(S_WIS)
  End If
  If Stats(S_CHA) <> 0 Then
    Text = Text & " Ch:" & Stats(S_CHA)
    Value = Value + C_STATCOST * Stats(S_CHA)
  End If
  If Stats(S_REP) <> 0 Then
    Text = Text & " Rp:" & Stats(S_REP)
    Value = Value + C_STATCOST * Stats(S_REP)
  End If
  If Speed <> 0 Then
    Text = Text & " Sp:" & Speed
    Value = Value + C_STATCOST * Speed \ 2
  End If
  
  If Res(R_FIRE) <> 0 Then
    Text = Text & " RF:" & Res(R_FIRE)
    Value = Value + 30 * Res(R_FIRE)
  End If
  If Res(R_COLD) <> 0 Then
    Text = Text & " RC:" & Res(R_COLD)
    Value = Value + 30 * Res(R_COLD)
  End If
  If Res(R_ELEC) <> 0 Then
    Text = Text & " RE:" & Res(R_ELEC)
    Value = Value + 30 * Res(R_ELEC)
  End If
  If Res(R_MAGI) <> 0 Then
    Text = Text & " RM:" & Res(R_MAGI)
    Value = Value + 30 * Res(R_MAGI)
  End If
  
  If S = "Healing Potion" Then
    Dim eoinvu As Integer
    eoinvu = Value
  End If
  
End Sub

Public Sub Create(ByVal T As Integer, ByVal dep As Integer, Optional ByVal mindep As Integer = -1)
  Dim r As Integer
  Dim e As Integer
  Dim p As Integer
  Dim dif As Integer
  Dim Ele As String
  Dim flgs As Long
  Dim c As Long
  Dim bypass As Integer
  
'  For i = 0 To d
'    r = r + Int(Rnd * 100) + 1
'  Next i
  
  bypass = 0
  dep = Max(dep, 0)
  Me.Depth = dep
  
  If mindep = -1 Then
    mindep = Max(0, dep - 4)
  Else
    mindep = Max(0, mindep)
  End If
'  If T = S_WEP Or T = S_ARM Then
'    mindep = Max(0, mindep)
'  Else
'    mindep = 0
'  End If
'  c = Min((2 ^ Min(d - (r \ 50), 10)) * 5, 100)
  c = (dep + 1) * (Int(Rnd * 3) + 1)
AGAIN:
  If T = S_WEP Then
    r = Int(Rnd * 21)
    Select Case r
      Case 0
        Call Me.MakeItem("Knife", 0, 0, 0, c, c)
      Case 1
        Call Me.MakeItem("Rapier", 0, 0, 0, c, c)
      Case 2
        Call Me.MakeItem("Short Sword", 0, 0, 0, c, c)
      Case 3
        Call Me.MakeItem("Short Bow", 0, 0, 0, c, c)
      Case 4
        Call Me.MakeItem("Long Bow", 0, 0, 0, c, c)
      Case 5
        Call Me.MakeItem("Sabre", 0, 0, 0, c, c)
      Case 6
        Call Me.MakeItem("Katana", 0, 0, 0, c, c)
      Case 7
        Call Me.MakeItem("Nunchuckas", 0, 0, 0, c, c)
      Case 8
        Call Me.MakeItem("Staff", 0, 0, 0, c, c)
      Case 9
        Call Me.MakeItem("Truncheon", 0, 0, 0, c, c)
      Case 10
        Call Me.MakeItem("Dagger", 0, 0, 0, c, c)
      Case 11
        Call Me.MakeItem("Longsword", 0, 0, 0, c, c)
      Case 12
        Call Me.MakeItem("Broadsword", 0, 0, 0, c, c)
      Case 13
        Call Me.MakeItem("Battle Axe", 0, 0, 0, c, c)
      Case 14
        Call Me.MakeItem("Great Axe", 0, 0, 0, c, c)
      Case 15
        Call Me.MakeItem("Greatsword", 0, 0, 0, c, c)
      Case 16
        Call Me.MakeItem("Bastard Sword", 0, 0, 0, c, c)
      Case 17
        Call Me.MakeItem("Mace", 0, 0, 0, c, c)
      Case 18
        Call Me.MakeItem("Flail", 0, 0, 0, c, c)
      Case 19
        Call Me.MakeItem("Naginata", 0, 0, 0, c, c)
      Case 20
        Call Me.MakeItem("Halberd", 0, 0, 0, c, c)
      Case Else
        Call Me.MakeItem("Doodad")
    End Select
  ElseIf T = S_ARM Then
    r = Int(Rnd * 25)
    Select Case r
      Case 0
        Call Me.MakeItem("Adamantite Full Plate", 0, 0, 0, c, c)
      Case 1
        Call Me.MakeItem("Clothing", 0, 0, 0, c, c)
      Case 2
        Call Me.MakeItem("Padded Leather", 0, 0, 0, c, c)
      Case 3
        Call Me.MakeItem("Hard Leather", 0, 0, 0, c, c)
      Case 4
        Call Me.MakeItem("Hunting Leather", 0, 0, 0, c, c)
      Case 5
        Call Me.MakeItem("Ring Mail", 0, 0, 0, c, c)
      Case 6
        Call Me.MakeItem("Scale Mail", 0, 0, 0, c, c)
      Case 7
        Call Me.MakeItem("Chain Mail", 0, 0, 0, c, c)
      Case 8
        Call Me.MakeItem("Brigantine", 0, 0, 0, c, c)
      Case 9
        Call Me.MakeItem("Plate Mail", 0, 0, 0, c, c)
      Case 10
        Call Me.MakeItem("Full Plate", 0, 0, 0, c, c)
      Case 11
        Call Me.MakeItem("Field Plate", 0, 0, 0, c, c)
      Case 12
        Call Me.MakeItem("Mithril Chain Mail", 0, 0, 0, c, c)
      Case 13
        Call Me.MakeItem("Leather Cap", 0, 0, 0, c, c)
      Case 14
        Call Me.MakeItem("Leather Hood", 0, 0, 0, c, c)
      Case 15
        Call Me.MakeItem("Chain Coif", 0, 0, 0, c, c)
      Case 16
        Call Me.MakeItem("Steel Cap", 0, 0, 0, c, c)
      Case 17
        Call Me.MakeItem("Plate Coif", 0, 0, 0, c, c)
      Case 18
        Call Me.MakeItem("Horned Mask", 0, 0, 0, c, c)
      Case 19
        Call Me.MakeItem("Great Helm", 0, 0, 0, c, c)
      Case 20
        Call Me.MakeItem("Buckler", 0, 0, 0, c, c)
      Case 21
        Call Me.MakeItem("Arm Shield", 0, 0, 0, c, c)
      Case 22
        Call Me.MakeItem("Kite Shield", 0, 0, 0, c, c)
      Case 23
        Call Me.MakeItem("Tower Shield", 0, 0, 0, c, c)
      Case 24
        Call Me.MakeItem("Mirror Shield", 0, 0, 0, c, c)
      Case Else
        Call Me.MakeItem("Doodad")
    End Select
  ElseIf T = S_GEN Then
     r = Int(Rnd * 12)
    Select Case r
      Case 0
        Call Me.MakeItem("Sandals", 0, 0, 0, c, c)
      Case 1
        Call Me.MakeItem("Shoes", 0, 0, 0, c, c)
      Case 2
        Call Me.MakeItem("Riding Boots", 0, 0, 0, c, c)
      Case 3
        Call Me.MakeItem("Iron Boots", 0, 0, 0, c, c)
      Case 4
        Call Me.MakeItem("War Boots", 0, 0, 0, c, c)
      Case 5
        Call Me.MakeItem("Leather Gloves", 0, 0, 0, c, c)
      Case 6
        Call Me.MakeItem("Brass Knuckles", 0, 0, 0, c, c)
      Case 7
        Call Me.MakeItem("Chain Gloves", 0, 0, 0, c, c)
      Case 8
        Call Me.MakeItem("Plated Gauntlets", 0, 0, 0, c, c)
      Case 9
        Call Me.MakeItem("Knife Gloves", 0, 0, 0, c, c)
      Case 10
        Call Me.MakeItem("Steel Gauntlets", 0, 0, 0, c, c)
      Case 11
        Call Me.MakeItem("Set of Cesti", 0, 0, 0, c, c)
      Case Else
        Call Me.MakeItem("Doodad")
    End Select
  ElseIf T = S_MAG Then
    r = Int(Rnd * 21)
    Select Case r
      Case 0 To 4
        Call Me.MakeItem("Ring", 0, 0, 0, c, c)
      Case 5 To 9
        Call Me.MakeItem("Healing Potion", Int(Rnd * (dep - mindep + 1) + mindep))
        bypass = 1
      Case 10
        Call Me.MakeItem("Scroll", M_MMIS)
      Case 11
        Call Me.MakeItem("Scroll", M_HEAL)
      Case 12
        Call Me.MakeItem("Scroll", M_TELE)
      Case 13
        Call Me.MakeItem("Scroll", M_STUN)
      Case 14
        Call Me.MakeItem("Scroll", M_TOWN)
      Case 15
        Call Me.MakeItem("Scroll", M_FAST)
      Case 16
        Call Me.MakeItem("Scroll", M_SLOW)
      Case 17
        Call Me.MakeItem("Scroll", M_BLES)
      Case 18
        Call Me.MakeItem("Scroll", M_FIRE)
      Case 19
        Call Me.MakeItem("Scroll", M_COLD)
      Case 20
        Call Me.MakeItem("Scroll", M_ELEC)
    End Select
  ElseIf T = S_INN Then
    Call Me.MakeItem("Room for the Night", dep)
    bypass = 1
  ElseIf T = S_TAV Then
    Call Me.MakeItem("Drink", dep)
    bypass = 1
  End If
  
  If (Me.Value < C_VALUEPERLEVEL * (mindep) Or Me.Value > C_VALUEPERLEVEL * (Me.Depth + 1)) And bypass = 0 Then
    GoTo AGAIN
  End If
  
End Sub

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

Public Sub Class_Initialize()
'  num = 1
End Sub

Public Sub Clear()
  Dim i As Integer
  
  Name = ""
  Use = -1
  Stat = -1
  Ele = ""
  Post = ""
  
  Att = 0
  Dam = 0
  
  Def = 0
  DR = 0
  Speed = 0
  Value = 0
'  Depth = 0
  Text = ""
  UnIDText = ""
  ID = False
  LastID = 0
  num = 0
  Attack = 0
  For i = 0 To 6
    Statistics(i) = 0
  Next i
  Flags = 0
  For i = 0 To C_RESISTS - 1
    Resistances(i) = 0
  Next i

End Sub
