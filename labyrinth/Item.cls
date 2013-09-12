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
Public BaseName As String
Public Ele As String ' element of item
Public Post As String

Public Att As Integer ' attack
Public Dam As Integer ' damage

Public Def As Integer ' defense
Public DR As Integer ' damage reduction
Public Speed As Integer
Public DMS As Integer
Public Value As Double
Public Depth As Integer
Public Text As String
Public UnIDText As String
Public ID As Boolean
Public LastID As Date
Public num As Integer
Public Attack As String
Private Statistics(0 To 6) As Integer
Public Flags As Long
Public Notes As Variant
Public Bypass As Integer
Public Hits As Integer
Public SkillBonus As Double
'Public CreatedAs As String
Private Resistances(0 To C_RESISTS - 1) As Integer


Public Sub UseF(self As Integer)
  Dim cap As String
  Dim s As String
  Dim remove As Integer
  Dim ic As Integer
  Dim up As Integer
  Dim x As Spell
  Dim i As Integer
  
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
    s = "Strength Increased Permanently By " & up & "."
    Call char.Player.CalcDervs
  ElseIf Name = "Dexterity Potion" Then
    remove = 1
    up = Int(Rnd * 5) + 6
    char.Player.Stats(S_DEX) = char.Player.Stats(S_DEX) + up
    s = "Dexterity Increased Permanently By " & up & "."
    Call char.Player.CalcDervs
  ElseIf Name = "Constitution Potion" Then
    remove = 1
    up = Int(Rnd * 5) + 6
    char.Player.Stats(S_CON) = char.Player.Stats(S_CON) + up
    s = "Constitution Increased Permanently By " & up & "."
    Call char.Player.CalcDervs
  ElseIf Name = "Intelligence Potion" Then
    remove = 1
    up = Int(Rnd * 5) + 6
    char.Player.Stats(S_INT) = char.Player.Stats(S_INT) + up
    s = "Intelligence Increased Permanently By " & up & "."
    Call char.Player.CalcDervs
  ElseIf Name = "Wisdom Potion" Then
    remove = 1
    up = Int(Rnd * 5) + 6
    char.Player.Stats(S_WIS) = char.Player.Stats(S_WIS) + up
    s = "Wisdom Increased Permanently By " & up & "."
    Call char.Player.CalcDervs
  ElseIf Name = "Charisma Potion" Then
    remove = 1
    up = Int(Rnd * 5) + 6
    char.Player.Stats(S_CHA) = char.Player.Stats(S_CHA) + up
    s = "Charisma Increased Permanently By " & up & "."
    Call char.Player.CalcDervs
  ElseIf Left(Name, 14) = "Healing Potion" Then
    remove = 1
    up = Dice(Depth + 1, 10) + 10
    char.Player.Dervs(D_CHP) = Min(char.Player.Dervs(D_CHP) + up, char.Player.Dervs(D_HTP))
    s = "The potion heals " & up & " points."
  ElseIf Left(Name, 11) = "Mana Potion" Then
    remove = 1
    up = Dice(Depth * 2 + 6, 10) + 10
    s = "The potion grants you " & up & " spell points."
    For Each x In char.Player.Spells
      x.Points = Min(x.Points + up, (char.Player.Reals(S_WIS) * 10)) '\ 20) * x.cost)
    Next x
  ElseIf Left(Name, 7) = "Dispipe" And ic = 1 Then
    remove = 1
    For i = 0 To C_COUNTERS - 1
      char.Player.Counts(i) = Max(char.Player.Counts(i) - Depth, 0)
    Next i
    s = "The pipe dispels " & Depth + 1 & " rounds of effects on you."
  ElseIf Left(Name, 6) = "Sapipe" And ic = 1 Then
    remove = 1
    up = Spread((Depth + 1) * 10, 20)
    s = "The pipe saps the strength from your opponent."
    frmCombat.Enemy.Dervs(D_SAT) = Max(frmCombat.Enemy.Dervs(D_SAT) - up, 1)
    frmCombat.Enemy.Dervs(D_DAT) = Max(frmCombat.Enemy.Dervs(D_SAT) - up, 1)
  ElseIf Left(Name, 8) = "Penepipe" And ic = 1 Then
    remove = 1
    up = Spread((Depth + 1) * 2, 20)
    s = "The pipe penetrates your opponent's armor."
    frmCombat.Enemy.Dervs(D_DR) = Max(frmCombat.Enemy.Dervs(D_DR) - up, 0)
  ElseIf Left(Name, 9) = "Targepipe" And ic = 1 Then
    remove = 1
    up = Spread((Depth + 1) * 10, 20)
    s = "The pipe draws your opponent to your weapon."
    frmCombat.Enemy.Dervs(D_DEF) = Max(frmCombat.Enemy.Dervs(D_DEF) - up, 0)
  ElseIf Left(Name, 10) = "Invisipipe" And ic = 1 Then
    remove = 1
    up = Depth + 1
    s = "The pipe turns you invisible!"
    char.Player.Counts(N_INVS) = Max(char.Player.Counts(N_INVS) + up, 0)
  ElseIf Left(Name, 8) = "Escapipe" And ic = 1 Then
    remove = 1
    Call frmCombat.FleeAttempt(1)
  ElseIf Left(Name, 8) = "Telepipe" And ic = 0 Then
    remove = 1
    Do
      up = Int(Rnd * C_LOCS)
    Loop While World.World(up).Depth <> Depth
    s = "You teleport to " & up & "."
    Call MoveTo(up)
  ElseIf Left(Name, 8) = "Townpipe" And ic = 0 Then
    remove = 1
    up = World.Cities(Depth)
    s = "You teleport to " & World.World(up).LCity.Name & "."
    Call MoveTo(up)
  ElseIf BaseName = "Head" Or BaseName = "Torso" Or BaseName = "Arms" Or BaseName = "Legs" Then
    Dim bpHead As Item
    Dim bpTorso As Item
    Dim bpArms As Item
    Dim bpLegs As Item
    remove = 0
    
    If char.Player.InInventory(Me.Ele & "Head") <> -1 Then
      Set bpHead = char.Player.Inven(char.Player.InInventory(Me.Ele & "Head"))
    End If
    If char.Player.InInventory(Me.Ele & "Torso") <> -1 Then
      Set bpTorso = char.Player.Inven(char.Player.InInventory(Me.Ele & "Torso"))
    End If
    If char.Player.InInventory(Me.Ele & "Arms") <> -1 Then
      Set bpArms = char.Player.Inven(char.Player.InInventory(Me.Ele & "Arms"))
    End If
    If char.Player.InInventory(Me.Ele & "Legs") <> -1 Then
      Set bpLegs = char.Player.Inven(char.Player.InInventory(Me.Ele & "Legs"))
    End If
    
    If bpHead Is Nothing Or bpTorso Is Nothing Or bpArms Is Nothing Or bpLegs Is Nothing Then
      s = "You don't have all the body parts you need to make a complete " & Ele & "right now."
    Else
      s = "You construct a " & Ele & "doll!"
      Call char.Player.RemInven(bpHead)
      Call char.Player.RemInven(bpTorso)
      Call char.Player.RemInven(bpArms)
      Call char.Player.RemInven(bpLegs)
      
'Public Sub MakeItem(chance As Double, outof As Double, s As String, Optional A As Integer = 0, Optional b As Integer = 0, Optional flgs As Integer = 0, Optional e As Integer = 0, Optional f As Integer = 0, Optional dep As Integer = -1, Optional Identified As Boolean = False)
      Set bpHead = New Item
      Call bpHead.MakeItem(1, 1, "Doll", Me.Notes, Me.Depth)
      Call char.Player.AddInven(bpHead)
      bpHead.ID = True
    End If
    
  ElseIf InStr(1, Name, "Blessing") Then
    remove = 0
    If Not char.Player.Eq(Me.Notes) Is Nothing Then
      If Me.Att <> -1 Then
        Call char.Player.Eq(Me.Notes).AddPre(100, Me.Att, 1)
      End If
      If Me.Def <> -1 Then
        Call char.Player.Eq(Me.Notes).AddPost(100, Me.Def, 1)
      End If
      s = "The priests bless your item."
'      char.Player.Eq(Me.Notes).Value = char.Player.Eq(Me.Notes).Value * (I_MANT ^ Me.Depth)
'      char.Player.Eq(Me.Notes).SetValue
      char.Player.Eq(Me.Notes).Value = char.Player.Eq(Me.Notes).Value + Me.Value
      char.Player.Eq(Me.Notes).SetText
      char.Player.Eq(Me.Notes).ID = True
    Else
      s = "You need to equip an item before the priests can bless it."
    End If
  ElseIf Name = "Flash Blinder" And ic = 1 Then
    remove = 0
    Call Damage(-1, 3, 0, 0, F_CONF, char.Player, frmCombat.Enemy)
  ElseIf Name = "Map" Then
    remove = 0
    s = "You inspect the map carefully."
    frmGame.txShowRoute.Text = CalcRoute(Str(Me.Att), 1)
    For i = 0 To C_RMAX - 1
      curroute(i) = route(i)
    Next i
    If frmGame.txShowRoute.Text <> "Bad Dest" Then
      frmGame.cmdRoute.Caption = "Move Route"
      frmGame.cmdRoute.Enabled = True
    End If
  ElseIf Name = "Scroll" Then
    Dim newspell As Integer
    newspell = 1
    remove = 1
    
    Dim it As New Spell
    Call it.MakeSpell(Att)
    For Each x In char.Player.Spells
      If x.Key = it.Key Then newspell = 0
    Next x
    If newspell = 1 And ID = True Then
      Call char.Player.Spells.Add(it, it.Key)
      it.Used = Str(CDbl(Now()))
      s = "You add " & it.Key & " to your spellbook."
    ElseIf ID = True Then
      remove = 0
      s = "You already know that spell."
    ElseIf ID = False Then
      remove = 0
      s = "You don't know what spell is on this scroll."
    End If
    
  ElseIf Name = "Drink" Then
    remove = 0
    s = "Mmmm liquid frothy goodness."
  ElseIf Name = "Room for the Night" Then
    remove = 0
    s = "You rest for the night."
    char.Player.Dervs(D_CHP) = Min(char.Player.Dervs(D_HTP), char.Player.Dervs(D_CHP) + Me.Depth * 10 + 15)
    PassTime
  ElseIf BaseName = "Carnival Game" Then
    char.Player.Stats(Me.Notes) = char.Player.Stats(Me.Notes) + 1
    If Notes = S_STR Then
      s = "You feel stronger!"
    ElseIf Notes = S_DEX Then
      s = "You feel more dextrous!"
    ElseIf Notes = S_CON Then
      s = "You feel more healthy!"
    ElseIf Notes = S_INT Then
      s = "You feel smarter!"
    ElseIf Notes = S_WIS Then
      s = "You feel wiser!"
    ElseIf Notes = S_CHA Then
      s = "You feel more beautiful!"
    End If
  ElseIf Name = "Knowledge" Then
    remove = 0
    char.Player.KL(Val(Me.Notes \ 100), Val(Me.Notes) Mod 100) = char.Player.KL(Val(Me.Notes \ 100), Val(Me.Notes) Mod 100) + 50
    s = "You learn all about the " & SelectMonster(Val(Me.Notes \ 100), Val(Me.Notes) Mod 100, 1) & " and its strengths and weaknesses." & vbCrLf & "This new knowledge will surely help you should you happen to need to fight one."
  ElseIf Name = "Wand of Portals" Then
    remove = 0
    If Notes > 0 Then
      If Att = World.Loc Then
        Att = -1
        s = "Portal origin reset to null."
      ElseIf Att = -1 Then
        If Available(World.Loc) <> -1 Then
          s = "Portal origin set to current location (" & World.Loc & ")."
          Att = World.Loc
        Else
          s = "Your current location (" & World.Loc & ") cannot accomodate a portal."
        End If
      ElseIf Att <> -1 Then
        If Available(Att) <> -1 And Available(World.Loc) <> -1 Then
          s = "You create a permanent portal between locations " & Att & " and " & World.Loc & "."
          World.World(Att).Link(Available(Att)) = World.Loc
          World.World(World.Loc).Link(Available(World.Loc)) = Att
          Notes = Notes - 1
          Att = -1
          RefreshGame
        ElseIf Available(Att) = -1 Then
          s = "The origin location can no longer accomodate a portal.  Origin reset to null."
          Att = -1
        ElseIf Available(World.Loc) = -1 Then
          s = "Your current location (" & World.Loc & ") cannot accomodate a portal to your proposed origin (" & Att & ")."
        End If
      End If
    Else
      Name = "Wand of Portals (no charges)"
      Value = 0
      s = "The wand has no charges remaining."
    End If
  ElseIf Name = "Wand of Terrain" Then
    remove = 0
    If Notes > 0 Then
      If Att = World.World(World.Loc).Terrain Then
        Att = -1
        s = "Terrain type reset to null."
      ElseIf Att = -1 Then
        s = "Terrain type set to current terrain (" & TerName(World.World(World.Loc).Terrain) & ")."
        Att = World.World(World.Loc).Terrain
      ElseIf Att <> -1 Then
        s = "You change the terrain of this region to " & TerName(Att) & "."
        For i = 0 To C_LOCS - 1
          If World.World(i).Region = World.World(World.Loc).Region Then
            World.World(i).Terrain = Att
          End If
        Next i
        Att = -1
        Notes = Notes - 1
        RefreshGame
      End If
    Else
      Name = "Wand of Terrain (no charges)"
      Value = 0
      s = "The wand has no charges remaining."
    End If
  ElseIf BaseName = "Foundation" Then
    If World.World(World.Loc).Depth <> Me.Depth Then
      s = "This foundation can only be used in a sector of depth " & Me.Depth & "."
      remove = 0
    ElseIf World.World(World.Loc).Depth = Me.Depth Then
      If World.World(World.Loc).LCity Is Nothing Then
        Set World.World(World.Loc).LCity = New City
        Call World.World(World.Loc).LCity.MakeCastle(World.Loc)
        s = "You lay the foundation for your new castle, " & World.World(World.Loc).LCity.Name & "."
        remove = 1
      Else
        s = "You can only use a building foundation in a sector with nothing else in it."
        remove = 0
      End If
    End If
  Else
    s = "That item cannot be used now."
  End If
  
  If remove = 1 Then
'    num = num - 1
'    If num <= 0 Then
      char.Player.Inven(self) = Nothing
'      frmInven.lstInven.Selected(self) = False
      
'    End If
  End If
  
  If s <> "" Then
    MsgBox s, , cap
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


Public Sub MakeItem(chance As Double, outof As Double, s As String, Optional A As Integer = 0, Optional b As Integer = 0, Optional flgs As Integer = 0, Optional e As Integer = 0, Optional f As Integer = 0, Optional dep As Integer = -1, Optional Identified As Boolean = False)
  Dim ec As Integer
  Dim fc As Integer
  Dim ndr As Integer
  
  If outof <= 0 Then
    Exit Sub
  End If
  
  outof = outof - chance
  If outof > 0 Then
    Exit Sub
  End If
  
  Me.Clear
  
  BaseName = s
  ID = Identified
  
  If dep <> -1 Then
    Depth = dep
  End If
   
  If s = "Knife" Then
    Attack = "NormalDex"
    Use = E_WEP
    Stat = S_DEX
    Att = 0
    Dam = 0
'    Value = Max(50 + Att * 10 + Dam * 20, 100)
    Depth = 0
  ElseIf s = "Short Sword" Then
    Attack = "NormalDex"
    Use = E_WEP
    Stat = S_DEX
    Att = 0
    Dam = 0
'    Value = Max(200 + Att * 20 + Dam * 40, 100)
    Depth = 2
  ElseIf s = "Truncheon" Then
    Attack = "NormalDex"
    Use = E_WEP
    Stat = S_DEX
    Flags = Flags Or F_FAST
    Att = 0
    Dam = 0
'    Value = Max(400 + Att * 40 + Dam * 80, 100)
    Depth = 4
  ElseIf s = "Rapier" Then
    Attack = "NormalDex"
    Use = E_WEP
    Stat = S_DEX
    Att = 0
    Dam = 0
'    Value = Max(1000 + Att * 50 + Dam * 100, 100)
    Depth = 6
  ElseIf s = "Staff" Then
    Attack = "NormalDex"
    Use = E_WEP
    Stat = S_DEX
    Def = 5
    Att = 0
    Dam = 0
'    Value = Max(2000 + Att * 50 + Dam * 100, 100)
'    Value = Value + 20 * Def
    Depth = 8
  ElseIf s = "Sabre" Then
    Attack = "NormalDex"
    Use = E_WEP
    Stat = S_DEX
    Att = 0
    Dam = 0
'    Value = Max(3500 + Att * 50 + Dam * 100, 100)
    Depth = 10
  ElseIf s = "Nunchuckas" Then
    Attack = "NinjaDex"
    Use = E_WEP
    Stat = S_DEX
    Def = 5
    Att = 0
    Dam = 0
'    Value = Max(5000 + Att * 50 + Dam * 100, 100)
'    Value = Value + 20 * Def
    Depth = 12
  ElseIf s = "Katana" Then
    Attack = "NinjaDex"
    Use = E_WEP
    Stat = S_DEX
    Att = 0
    Dam = 0
'    Value = Max(7000 + Att * 50 + Dam * 100, 100)
    Depth = 14
  ElseIf s = "Crystaline Blade" Then
    Attack = "NormalDex"
    Use = E_WEP
    Stat = S_DEX
    Att = 0
    Dam = 0
    Depth = 16
  ElseIf s = "Obsidian Slasher" Then
    Attack = "NormalDex"
    Use = E_WEP
    Stat = S_DEX
    Att = 0
    Dam = 0
    Depth = 18
  ElseIf s = "Dragontooth" Then
    Attack = "NormalDex"
    Use = E_WEP
    Stat = S_DEX
    Att = 0
    Dam = 0
    Depth = 20
  
  ElseIf s = "Short Bow" Then
    Attack = "Bow"
    Use = E_WEP
    Stat = S_DEX
    Flags = Flags Or F_HYPR
    Att = 10
    Dam = -3
'    Value = Max(1000 + Att * 50 + Dam * 100, 100)
    Depth = 4
  ElseIf s = "Long Bow" Then
    Attack = "Bow"
    Use = E_WEP
    Stat = S_DEX
    Flags = Flags Or F_HYPR
    Att = 20
    Dam = -6
'    Value = Max(4000 + Att * 50 + Dam * 100, 100)
    Depth = 9
  ElseIf s = "Great Bow" Then
    Attack = "Bow"
    Use = E_WEP
    Stat = S_DEX
    Flags = Flags Or F_HYPR
    Att = 30
    Dam = -9
'    Value = Max(4000 + Att * 50 + Dam * 100, 100)
    Depth = 14
  ElseIf s = "Meteor Bow" Then
    Attack = "Bow"
    Use = E_WEP
    Stat = S_DEX
    Flags = Flags Or F_HYPR
    Att = 40
    Dam = -12
'    Value = Max(4000 + Att * 50 + Dam * 100, 100)
    Depth = 19
  
  ElseIf s = "Dagger" Then
    Attack = "NormalStr"
    Use = E_WEP
    Stat = S_STR
    Att = 0
    Dam = 0
'    Value = Max(50 + Att * 10 + Dam * 20, 100)
    Depth = 1
  ElseIf s = "Mace" Then
    Attack = "NormalStr"
    Use = E_WEP
    Stat = S_STR
    Att = 0
    Dam = 0
'    Value = Max(200 + Att * 20 + Dam * 40, 100)
    Depth = 3
  ElseIf s = "Longsword" Then
    Attack = "NormalStr"
    Use = E_WEP
    Stat = S_STR
    Att = 0
    Dam = 0
'    Value = Max(400 + Att * 40 + Dam * 80, 100)
    Depth = 5
  ElseIf s = "Battle Axe" Then
    Attack = "NormalStr"
    Use = E_WEP
    Stat = S_STR
    Att = 0
    Dam = 0
'    Value = Max(400 + Att * 40 + Dam * 80, 100)
    Depth = 5
  ElseIf s = "Broadsword" Then
    Attack = "NormalStr"
    Use = E_WEP
    Stat = S_STR
    Att = 0
    Dam = 0
'    Value = Max(1000 + Att * 50 + Dam * 100, 100)
    Depth = 7
  ElseIf s = "Great Axe" Then
    Attack = "NormalStr"
    Use = E_WEP
    Stat = S_STR
    Att = 0
    Dam = 0
'    Value = Max(1000 + Att * 50 + Dam * 100, 100)
    Depth = 7
  ElseIf s = "Bastard Sword" Then
    Attack = "NormalStr"
    Use = E_WEP
    Stat = S_STR
    Att = 0
    Dam = 0
'    Value = Max(2000 + Att * 50 + Dam * 100, 100)
    Depth = 9
  ElseIf s = "Flail" Then
    Attack = "NormalStr"
    Use = E_WEP
    Stat = S_STR
    Att = 0
    Dam = 0
'    Value = Max(3500 + Att * 50 + Dam * 100, 100)
    Depth = 9
  ElseIf s = "Halbard" Then
    Attack = "NormalStr"
    Use = E_WEP
    Stat = S_STR
    Att = 0
    Dam = 0
'    Value = Max(3500 + Att * 50 + Dam * 100, 100)
    Depth = 11
  ElseIf s = "Naginata" Then
    Attack = "NinjaStr"
    Use = E_WEP
    Stat = S_STR
    Att = 0
    Dam = 0
'    Value = Max(5000 + Att * 50 + Dam * 100, 100)
    Depth = 13
  ElseIf s = "Greatsword" Then
    Attack = "NormalStr"
    Use = E_WEP
    Stat = S_STR
    Att = 0
    Dam = 0
    Depth = 15
  ElseIf s = "Stormstriker" Then
    Attack = "NormalStr"
    Use = E_WEP
    Stat = S_STR
    Att = 0
    Dam = 0
    Depth = 17
  ElseIf s = "Heavenly Wrath" Then
    Attack = "NormalStr"
    Use = E_WEP
    Stat = S_STR
    Att = 0
    Dam = 0
    Depth = 19
  ElseIf s = "Galactic Incisor" Then
    Attack = "NormalStr"
    Use = E_WEP
    Stat = S_STR
    Att = 0
    Dam = 0
    Depth = 21
  ElseIf s = "Cantrip Wand" Then
    Attack = "MageStr"
    Use = E_WEP
    Att = 0
    Dam = 0
    Res(R_MAGI) = 10
    Stats(S_INT) = 5 + Int(Rnd * 10)
    Stats(S_WIS) = Int(Rnd * 10)
    Depth = 0
  ElseIf s = "Glowing Wand" Then
    Attack = "MageStr"
    Use = E_WEP
    Att = 0
    Dam = 0
    Res(R_MAGI) = 20
    Stats(S_INT) = 15 + Int(Rnd * 10)
    Stats(S_WIS) = 5 + Int(Rnd * 10)
    Depth = 4
  ElseIf s = "Imbued Wand" Then
    Attack = "MageStr"
    Use = E_WEP
    Att = 0
    Dam = 0
    Res(R_MAGI) = 30
    Stats(S_INT) = 25 + Int(Rnd * 10)
    Stats(S_WIS) = 10 + Int(Rnd * 10)
    Depth = 8
  ElseIf s = "Dweomer Wand" Then
    Attack = "MageStr"
    Use = E_WEP
    Att = 0
    Dam = 0
    Res(R_MAGI) = 40
    Stats(S_INT) = 35 + Int(Rnd * 10)
    Stats(S_WIS) = 15 + Int(Rnd * 10)
    Depth = 12
  ElseIf s = "Ensorceled Wand" Then
    Attack = "MageStr"
    Use = E_WEP
    Att = 0
    Dam = 0
    Res(R_MAGI) = 50
    Stats(S_INT) = 45 + Int(Rnd * 10)
    Stats(S_WIS) = 20 + Int(Rnd * 10)
    Depth = 16
  ElseIf s = "Youthful Rod" Then
    Attack = "MageStr"
    Use = E_WEP
    Att = 0
    Dam = 0
    Res(R_MAGI) = 10
    Stats(S_INT) = 5 + Int(Rnd * 10)
    Stats(S_WIS) = 5 + Int(Rnd * 10)
    Depth = 1
  ElseIf s = "Elder Rod" Then
    Attack = "MageStr"
    Use = E_WEP
    Att = 0
    Dam = 0
    Res(R_MAGI) = 20
    Stats(S_INT) = 15 + Int(Rnd * 10)
    Stats(S_WIS) = 15 + Int(Rnd * 10)
    Depth = 5
  ElseIf s = "Wizened Rod" Then
    Attack = "MageStr"
    Use = E_WEP
    Att = 0
    Dam = 0
    Res(R_MAGI) = 30
    Stats(S_INT) = 25 + Int(Rnd * 10)
    Stats(S_WIS) = 25 + Int(Rnd * 10)
    Depth = 9
  ElseIf s = "Sage Rod" Then
    Attack = "MageStr"
    Use = E_WEP
    Att = 0
    Dam = 0
    Res(R_MAGI) = 40
    Stats(S_INT) = 35 + Int(Rnd * 10)
    Stats(S_WIS) = 35 + Int(Rnd * 10)
    Depth = 13
  ElseIf s = "Ancient Rod" Then
    Attack = "MageStr"
    Use = E_WEP
    Att = 0
    Dam = 0
    Res(R_MAGI) = 50
    Stats(S_INT) = 45 + Int(Rnd * 10)
    Stats(S_WIS) = 45 + Int(Rnd * 10)
    Depth = 17
  ElseIf s = "Apprentice Staff" Then
    Attack = "MageStr"
    Use = E_WEP
    Att = 0
    Dam = 0
    Speed = 5 + Int(Rnd * 10)
    Def = 5 + Int(Rnd * 10)
    Stats(S_INT) = 2 + Int(Rnd * 10)
    Stats(S_WIS) = 2 + Int(Rnd * 10)
    Depth = 2
  ElseIf s = "Mage Staff" Then
    Attack = "MageStr"
    Use = E_WEP
    Att = 0
    Dam = 0
    Speed = 10 + Int(Rnd * 10)
    Def = 10 + Int(Rnd * 10)
    Stats(S_INT) = 12 + Int(Rnd * 10)
    Stats(S_WIS) = 12 + Int(Rnd * 10)
    Depth = 6
  ElseIf s = "Wizard Staff" Then
    Attack = "MageStr"
    Use = E_WEP
    Att = 0
    Dam = 0
    Speed = 15 + Int(Rnd * 10)
    Def = 15 + Int(Rnd * 10)
    Stats(S_INT) = 17 + Int(Rnd * 10)
    Stats(S_WIS) = 17 + Int(Rnd * 10)
    Depth = 10
  ElseIf s = "Sorcerer Staff" Then
    Attack = "MageStr"
    Use = E_WEP
    Att = 0
    Dam = 0
    Speed = 20 + Int(Rnd * 10)
    Def = 20 + Int(Rnd * 10)
    Stats(S_INT) = 22 + Int(Rnd * 10)
    Stats(S_WIS) = 22 + Int(Rnd * 10)
    Depth = 14
  ElseIf s = "Archmage Staff" Then
    Attack = "MageStr"
    Use = E_WEP
    Att = 0
    Dam = 0
    Speed = 25 + Int(Rnd * 10)
    Def = 25 + Int(Rnd * 10)
    Stats(S_INT) = 27 + Int(Rnd * 10)
    Stats(S_WIS) = 27 + Int(Rnd * 10)
    Depth = 18
    
  ElseIf s = "Clothing" Then
    Attack = ""
    Use = E_ARM
    Def = 0
    DR = 0
'    Value = 50 + 10 * Def
    Depth = 0
  ElseIf s = "Padded Leather" Then
    Use = E_ARM
    Def = 0
    DR = 0
'    Value = 100 + 20 * Def + 40 * DR
    Depth = 1
  ElseIf s = "Hard Leather" Then
    Use = E_ARM
    Def = 0
    DR = 0
'    Value = 200 + 40 * Def + 80 * DR
    Depth = 3
  ElseIf s = "Hunting Leather" Then
    Use = E_ARM
    Def = 0
    DR = 0
'    Value = 400 + 50 * Def + 100 * DR
    Depth = 4
  ElseIf s = "Ring Mail" Then
    Use = E_ARM
    Def = 0
    DR = 0
'    Value = 600 + 50 * Def + 100 * DR
    Depth = 6
  ElseIf s = "Scale Mail" Then
    Use = E_ARM
    Def = 0
    DR = 0
'    Value = 1000 + 50 * Def + 100 * DR
    Depth = 7
  ElseIf s = "Chain Mail" Then
    Use = E_ARM
    Def = 0
    DR = 0
'    Value = 1500 + 50 * Def + 100 * DR
    Depth = 9
  ElseIf s = "Brigantine" Then
    Use = E_ARM
    Def = 0
    DR = 0
'    Value = 2500 + 50 * Def + 100 * DR
    Depth = 10
  ElseIf s = "Plate Mail" Then
    Use = E_ARM
    Def = 0
    DR = 0
'    Value = 3500 + 50 * Def + 100 * DR
    Depth = 12
  ElseIf s = "Full Plate" Then
    Use = E_ARM
    Def = 0
    DR = 0
'    Value = 6000 + 50 * Def + 100 * DR
    Depth = 13
  ElseIf s = "Field Plate" Then
    Use = E_ARM
    Def = 0
    DR = 0
'    Value = 7000 + 50 * Def + 100 * DR
    Depth = 15
  
  ElseIf s = "Mithril Chain Mail" Then
    Use = E_ARM
    Def = 0
    DR = 0
'    Value = 10000 + 50 * Def + 100 * DR
    Res(R_FIRE) = 10
    Res(R_COLD) = 10
    Res(R_MAGI) = 10
    Res(R_ELEC) = 10
    Depth = 17
  ElseIf s = "Adamantite Full Plate" Then
    Use = E_ARM
    Def = 0
    DR = 0
'    Value = 15000 + 50 * Def + 100 * DR
    Res(R_FIRE) = 20
    Res(R_COLD) = 20
    Res(R_MAGI) = 20
    Res(R_ELEC) = 20
    Depth = 19
    
  ElseIf s = "Buckler" Then
    Use = E_SLD
    Def = 0
    DMS = 0
'    Value = 100 + 50 * Def + 100 * DR
    Depth = 1
  ElseIf s = "Arm Shield" Then
    Use = E_SLD
    Def = 0
    DMS = 0
'    Value = 500 + 50 * Def + 100 * DR
    Depth = 4
  ElseIf s = "Kite Shield" Then
    Use = E_SLD
    Def = 0
    DMS = 0
'    Value = 1000 + 50 * Def + 100 * DR
    Depth = 7
  ElseIf s = "Tower Shield" Then
    Use = E_SLD
    Def = 0
    DMS = 0
'    Value = 2000 + 50 * Def + 100 * DR
    Depth = 10
  ElseIf s = "Mirror Shield" Then
    Use = E_SLD
    Def = 0
    DMS = 0
    Res(R_MAGI) = 20
'    Value = 4000 + 50 * Def + 100 * DR
    Depth = 13
  ElseIf s = "Displacement Shield" Then
    Use = E_SLD
    Def = 10
    DMS = -2
'    Value = 4000 + 50 * Def + 100 * DR
    Depth = 16
  ElseIf s = "Vortex Shield" Then
    Use = E_SLD
    Def = -10
    DMS = 2
'    Value = 4000 + 50 * Def + 100 * DR
    Depth = 19
    
  ElseIf s = "Sandals" Then
    Use = E_BTS
    Def = 0
    DR = 0
'    Value = 150 + 100 * Def
    Depth = 0
  ElseIf s = "Shoes" Then
    Use = E_BTS
    Def = 0
    DR = 0
'    Value = 400 + 100 * Def
    Depth = 3
  ElseIf s = "Riding Boots" Then
    Use = E_BTS
    Def = 0
    DR = 0
'    Value = 900 + 100 * Def
    Depth = 6
  ElseIf s = "Iron Boots" Then
    Use = E_BTS
    Def = 0
    DR = 0
'    Value = 1800 + 100 * Def
    Depth = 9
  ElseIf s = "War Boots" Then
    Use = E_BTS
    Def = 0
    DR = 0
    Depth = 12
    Stats(S_STR) = Int(Rnd * Depth)
    Stats(S_DEX) = Int(Rnd * Depth)
'    Value = 3500 + 100 * Def
  ElseIf s = "Plate Greaves" Then
    Use = E_BTS
    Def = 0
    DR = 0
'    Value = 3500 + 100 * Def
    Depth = 15
    Stats(S_STR) = Int(Rnd * Depth)
    Stats(S_DEX) = Int(Rnd * Depth)
  ElseIf s = "Battle Greaves" Then
    Use = E_BTS
    Def = 0
    DR = 0
'    Value = 3500 + 100 * Def
    Depth = 18
    Stats(S_STR) = Int(Rnd * Depth)
    Stats(S_DEX) = Int(Rnd * Depth)
    
  ElseIf s = "Leather Gloves" Then
    Use = E_GNT
    Dam = 0
    Def = 0
'    Value = 200 * Dam + 50
    Depth = 0
  ElseIf s = "Brass Knuckles" Then
    Use = E_GNT
    Dam = 1
    Def = 0
'    Value = 200 * Dam + 50
    Depth = 2
  ElseIf s = "Chain Gloves" Then
    Use = E_GNT
    Dam = 0
    Def = 0
'    Value = 200 + 200 * Dam + 50 * Def
    Depth = 4
  ElseIf s = "Plated Gauntlets" Then
    Use = E_GNT
    Dam = 0
    Def = 0
'    Value = 500 + 200 * Dam + 50 * Def
    Depth = 7
  ElseIf s = "Knife Gloves" Then
    Use = E_GNT
    Dam = 2
    Def = 0
'    Value = 1000 + 200 * Dam + 50 * Def
    Depth = 9
  ElseIf s = "Steel Gauntlets" Then
    Use = E_GNT
    Dam = 0
    Def = 0
'    Value = 2000 + 200 * Dam + 50 * Def
    Depth = 11
  ElseIf s = "Set of Cesti" Then
    Use = E_GNT
    Dam = 2
    Def = 0
'    Value = 3500 + 200 * Dam + 50 * Def
    Depth = 14
  ElseIf s = "Adamantium Claws" Then
    Use = E_GNT
    Dam = 4
    Def = 0
'    Value = 3500 + 200 * Dam + 50 * Def
    Depth = 16
  ElseIf s = "Wyrm Bracers" Then
    Use = E_GNT
    Dam = 0
    Def = 10
'    Value = 3500 + 200 * Dam + 50 * Def
    Depth = 18
    
  ElseIf s = "Leather Cap" Then
    Use = E_HLM
    Def = 0
    DR = 0
'    Value = 50 + 100 * Def + 200 * DR
    Depth = 0
  ElseIf s = "Leather Hood" Then
    Use = E_HLM
    Def = 0
    DR = 0
'    Value = 100 + 100 * Def + 200 * DR
    Depth = 2
  ElseIf s = "Chain Coif" Then
    Use = E_HLM
    Def = 0
    DR = 0
'    Value = 200 + 100 * Def + 200 * DR
    Depth = 4
  ElseIf s = "Steel Cap" Then
    Use = E_HLM
    Def = 0
    DR = 0
'    Value = 500 + 100 * Def + 200 * DR
    Depth = 7
  ElseIf s = "Plate Coif" Then
    Use = E_HLM
    Def = 0
    DR = 0
'    Value = 1000 + 100 * Def + 200 * DR
    Depth = 9
  ElseIf s = "Horned Mask" Then
    Use = E_HLM
    Def = 10
    DR = -10
'    Value = 2000 + 100 * Def + 200 * DR
    Depth = 11
  ElseIf s = "Great Helm" Then
    Use = E_HLM
    Def = 0
    DR = 0
'    Value = 4000 + 100 * Def + 200 * DR
    Depth = 14
  ElseIf s = "Full Helm" Then
    Use = E_HLM
    Def = 0
    DR = 0
'    Value = 4000 + 100 * Def + 200 * DR
    Depth = 16
  ElseIf s = "Crested Helm" Then
    Use = E_HLM
    Def = 0
    DR = 0
    Depth = 18
    Stats(S_WIS) = Int(Rnd * Depth)
'    Value = 4000 + 100 * Def + 200 * DR

    
  ElseIf s = "Ring" Then
    Use = E_RG1
    Value = 0 'Depth * 100 + 100
          
    e = Depth * 5 + 5
    f = Depth * 5 + 5
    Depth = 0
  ElseIf s = "Granite Ring" Then
    s = "Ring"
    Use = E_RG1
    Def = PM(A * 2, 25) + 5
    DR = (A \ 4) + 1
    Depth = A + 1
    e = 10
    f = 10
  ElseIf s = "Ruby Ring" Then
    s = "Ring"
    Use = E_RG1
    Att = PM(A * 2, 25) + 5
    Dam = (A \ 4) + 1
    Depth = A + 1
    e = 10
    f = 10
  ElseIf s = "Emerald Ring" Then
    s = "Ring"
    Use = E_RG1
    Stats(S_DEX) = PM(A * 2, 25) + 5
    Speed = PM(A * 2, 25) + 5
    Depth = A + 1
    e = 10
    f = 10
  ElseIf s = "Pearl Ring" Then
    s = "Ring"
    Use = E_RG1
    Stats(S_INT) = PM(A * 2, 25) + 5
    Stats(S_CON) = PM(A * 2, 25) + 5
    Depth = A + 1
    e = 10
    f = 10
  ElseIf s = "Sapphire Ring" Then
    s = "Ring"
    Use = E_RG1
    Stats(S_WIS) = PM(A * 2, 25) + 5
    Speed = PM(A * 2, 25) + 5
    Depth = A + 1
    e = 10
    f = 10
  ElseIf s = "Diamond Ring" Then
    s = "Ring"
    Use = E_RG1
    Stats(S_CHA) = PM(A * 2, 25) + 5
    Stats(S_REP) = PM(A * 2, 25) + 5
    Depth = A + 1
    e = 10
    f = 10
  ElseIf s = "Opal Ring" Then
    s = "Ring"
    Use = E_RG1
    Stats(S_STR) = PM(A * 2, 25) + 5
    DMS = (A \ 4) + 1
    Depth = A + 1
    e = 10
    f = 10
  ElseIf s = " Ring" Then
    s = "Ring"
    Use = E_RG1
    Stats(S_WIS) = A + 5
    Speed = (A \ 4) + 1
    Depth = A + 1
    e = 10
    f = 10
  ElseIf s = "Jeweled Ring" Then
    Use = E_RG1
    Stat = 0
    Stats(S_CHA) = PM(A * 3, 25) + 5
'    Value = Stats(S_CHA) * 15 + 30
    Depth = 0
    Bypass = Int(Rnd * 2)
  ElseIf s = "Strength Potion" Then
    Name = "Strength Potion"
    Use = E_NON
    Depth = 10
    Value = 2000 * (I_MANT ^ Depth)
  ElseIf s = "Dexterity Potion" Then
    Name = "Dexterity Potion"
    Use = E_NON
    Depth = 10
    Value = 2000 * (I_MANT ^ Depth)
  ElseIf s = "Constitution Potion" Then
    Name = "Constitution Potion"
    Use = E_NON
    Depth = 10
    Value = 2000 * (I_MANT ^ Depth)
  ElseIf s = "Intelligence Potion" Then
    Name = "Intelligence Potion"
    Use = E_NON
    Depth = 10
    Value = 2000 * (I_MANT ^ Depth)
  ElseIf s = "Wisdom Potion" Then
    Name = "Wisdom Potion"
    Use = E_NON
    Depth = 10
    Value = 2000 * (I_MANT ^ Depth)
  ElseIf s = "Charisma Potion" Then
    Name = "Charisma Potion"
    Use = E_NON
    Depth = 10
    Value = 2000 * (I_MANT ^ Depth)
  ElseIf s = "Dispipe" Then
    Depth = Max(A, 3)
    Name = "Dispipe L:" & Depth
    Use = E_NON
    Value = 20 * (I_MANT ^ Depth)
  ElseIf s = "Sapipe" Then
    Depth = Max(A, 3)
    Name = "Sapipe L:" & Depth
    Use = E_NON
    Value = 20 * (I_MANT ^ Depth)
  ElseIf s = "Penepipe" Then
    Depth = Max(A, 3)
    Name = "Penepipe L:" & Depth
    Use = E_NON
    Value = 25 * (I_MANT ^ Depth)
  ElseIf s = "Targepipe" Then
    Depth = Max(A, 3)
    Name = "Targepipe L:" & Depth
    Use = E_NON
    Value = 20 * (I_MANT ^ Depth)
  ElseIf s = "Escapipe" Then
    Name = "Escapipe L:3"
    Use = E_NON
    Depth = 3
    Value = 500
    Bypass = 1
  ElseIf s = "Telepipe" Then
    Depth = Max(A, 3)
    Name = "Telepipe L:" & Depth
    Use = E_NON
    Value = 15 * (I_MANT ^ Depth)
  ElseIf s = "Townpipe" Then
    Depth = Max(A, 3)
    Name = "Townpipe L:" & Depth
    Use = E_NON
    Value = 20 * (I_MANT ^ Depth)
  ElseIf s = "Invisipipe" Then
    Depth = Max(A, 3)
    Name = "Invisipipe L:" & Depth
    Use = E_NON
    Value = 20 * (I_MANT ^ Depth)
  ElseIf s = "Healing Potion" Then
    Name = "Healing Potion" & " L:" & A
    Use = E_NON
    Value = 50 * (I_MANT ^ A)
    Depth = A
    Bypass = 1
'    num = 1
  ElseIf s = "Mana Potion" Then
    Name = "Mana Potion" & " L:" & A
    Use = E_NON
    Value = 100 * (I_MANT ^ A)
    Depth = A
    Bypass = 1
'    num = 1
  ElseIf s = "Flash Blinder" Then
    Attack = ""
    Use = E_NON
    Value = 300
    Depth = 2
  ElseIf s = "Sword of Giants" Then
    Attack = "Sword of Giants"
    Use = E_WEP
    Stat = S_STR
    Att = 40 + 2 * A
    Dam = 20 + A
    Stats(S_STR) = 100 + A * 5
    Value = 35000
    Depth = 15
  ElseIf s = "Map" Then
    Post = " to " & A
    Use = E_NON
    Att = A
    Value = 200
    Depth = Max(World.World(Att).Depth - 1, 0)
'    num = 1
  ElseIf s = "Body Part" Then
    Dim qq As Integer
    qq = Int(Rnd * 11)
    Select Case qq
      Case 0 To 1
        BaseName = "Head"
      Case 2 To 5
        BaseName = "Torso"
      Case 5 To 7
        BaseName = "Arms"
      Case 8 To 10
        BaseName = "Legs"
    End Select
    Ele = SelectMonster(A, b, 1) & " "
    Use = E_NON
    Depth = b
    Notes = A
    Value = TG(b)
  ElseIf s = "Doll" Then
    Ele = SelectMonster(A, b, 1) & " "
    Use = E_NON
    Depth = b
'    Notes = A
    Value = TG(b) * 10
  ElseIf s = "Scroll" Then
    Use = E_NON
    If A = M_PROT Then
      Post = " of Protection"
      Depth = M_PROT_D
    ElseIf A = M_MMIS Then
      Post = " of Magic Missile"
      Depth = M_MMIS_D
    ElseIf A = M_FLEE Then
      Post = " of Escape"
      Depth = M_FLEE_D
    ElseIf A = M_HEAL Then
      Post = " of Heal"
      Depth = M_HEAL_D
    ElseIf A = M_TELE Then
      Post = " of Teleport"
      Depth = M_TELE_D
    ElseIf A = M_STUN Then
      Post = " of Stun"
      Depth = M_STUN_D
    ElseIf A = M_TOWN Then
      Post = " of Town Portal"
      Depth = M_TOWN_D
    ElseIf A = M_FAST Then
      Post = " of Haste"
      Depth = M_FAST_D
    ElseIf A = M_SLOW Then
      Post = " of Slow"
      Depth = M_SLOW_D
    ElseIf A = M_BLES Then
      Post = " of Bless"
      Depth = M_BLES_D
    ElseIf A = M_FIRE Then
      Post = " of Fireball"
      Depth = M_FIRE_D
    ElseIf A = M_COLD Then
      Post = " of Ice Storm"
      Depth = M_COLD_D
    ElseIf A = M_ELEC Then
      Post = " of Lighning Bolt"
      Depth = M_ELEC_D
    End If
    Att = A
    Value = 800 * (I_MANT ^ Depth)
'    num = 1
  ElseIf s = "Knowledge" Then
    Post = " of " & SelectMonster(A, b, 1)
    Use = E_SER
    Notes = Str(100 * A + b)
    Value = 10 * (I_MANT ^ b)
    Bypass = 1
  ElseIf s = "Armor Blessing" Then
    Use = E_SER
    e = 0
    f = 0
    Notes = E_ARM
    Att = -1
    Def = -1
    If Rnd * 2 < 1 Then
      Att = AddPre(100)
    Else
      Def = AddPost(100)
    End If
    Bypass = 1
  ElseIf s = "Weapon Blessing" Then
    Use = E_SER
    e = 0
    f = 0
    Notes = E_WEP
    Att = -1
    Def = -1
    If Rnd * 2 < 1 Then
      Att = AddPre(100)
    Else
      Def = AddPost(100)
    End If
    Bypass = 1
  ElseIf s = "Helm Blessing" Then
    Use = E_SER
    e = 0
    f = 0
    Notes = E_HLM
    Att = -1
    Def = -1
    If Rnd * 2 < 1 Then
      Att = AddPre(100)
    Else
      Def = AddPost(100)
    End If
    Bypass = 1
  ElseIf s = "Gauntlet Blessing" Then
    Use = E_SER
    e = 0
    f = 0
    Notes = E_GNT
    Att = -1
    Def = -1
    If Rnd * 2 < 1 Then
      Att = AddPre(100)
    Else
      Def = AddPost(100)
    End If
    Bypass = 1
  ElseIf s = "Boot Blessing" Then
    Use = E_SER
    e = 0
    f = 0
    Notes = E_BTS
    Att = -1
    Def = -1
    If Rnd * 2 < 1 Then
      Att = AddPre(100)
    Else
      Def = AddPost(100)
    End If
    Bypass = 1
  ElseIf s = "Shield Blessing" Then
    Use = E_SER
    e = 0
    f = 0
    Notes = E_SLD
    Att = -1
    Def = -1
    If Rnd * 2 < 1 Then
      Att = AddPre(100)
    Else
      Def = AddPost(100)
    End If
    Bypass = 1
  
  ElseIf s = "Carnival Game" Then
    Use = E_SER
    e = 0
    f = 0
    Notes = A
    If Notes = S_STR Then
      Post = ": Weight Lifting"
    ElseIf Notes = S_DEX Then
      Post = ": Archery"
    ElseIf Notes = S_CON Then
      Post = ": Marathon"
    ElseIf Notes = S_INT Then
      Post = ": Maze"
    ElseIf Notes = S_WIS Then
      Post = ": Riddles"
    ElseIf Notes = S_CHA Then
      Post = ": Beauty Contest"
    End If
    Bypass = 1
  
  ElseIf s = "Room for the Night" Then
    Use = E_SER
    Value = Int(10 * (I_MANT ^ (A)))
    Depth = A
    Bypass = 1
  ElseIf s = "Drink" Then
    Use = E_SER
    Value = Int(2 * (I_MANT ^ (A)))
    Depth = A
    Bypass = 1
    
' artifact weapons
  ElseIf s = "Sting" Then
    Use = E_WEP
    Attack = "Highest"
    Att = 10
    Dam = 2
    Flags = Flags Or F_MAGI
    Depth = 0
  ElseIf s = "Thermal" Then
    Use = E_WEP
    Attack = "Highest"
    Att = 10
    Dam = 4
    Flags = Flags Or F_FIRE
    Depth = 1
  ElseIf s = "Whisper" Then
    Use = E_WEP
    Attack = "Highest"
    Att = 10
    Dam = 4
    Stats(S_INT) = 10
    Flags = Flags Or F_BLND
    Depth = 2
  ElseIf s = "Bloodener" Then
    Use = E_WEP
    Attack = "Highest"
    Att = 10
    Dam = 6
    Flags = Flags Or F_STUN
    Depth = 3
  ElseIf s = "Frostbite" Then
    Use = E_WEP
    Attack = "Highest"
    Att = 10
    Dam = 4
    Flags = Flags Or F_COLD
    Res(R_COLD) = 100
    Depth = 4
  ElseIf s = "Mammoth Blade" Then
    Use = E_WEP
    Attack = "Highest"
    Att = 10
    Dam = 8
    Flags = Flags Or F_LONG
    Depth = 5
  ElseIf s = "Grindel's Torch" Then
    Use = E_WEP
    Attack = "Highest"
    Att = 10
    Dam = 4
    Flags = Flags Or F_MAGI Or F_FIRE
    Res(R_FIRE) = 50
    Stats(S_REP) = 5
    Depth = 6
  ElseIf s = "Hammerhand" Then
    Use = E_WEP
    Attack = "Highest"
    Att = 15
    Dam = 5
    Flags = Flags Or F_STUN
    Stats(S_STR) = 10
    Depth = 7
  ElseIf s = "Enticer" Then
    Use = E_WEP
    Attack = "Highest"
    Att = 20
    Dam = 4
    Stats(S_INT) = 10
    Stats(S_WIS) = 10
    DMS = 3
    Depth = 8
  ElseIf s = "Razor Edge" Then
    Use = E_WEP
    Attack = "Highest"
    Att = 10
    Dam = 4
    Flags = Flags Or F_PIRC
    Depth = 9
  ElseIf s = "Heart Seeker" Then
    Use = E_WEP
    Attack = "Highest"
    Att = 15
    Dam = 4
    Flags = Flags Or F_VAMP
    Stats(S_DEX) = 15
    Depth = 10
  ElseIf s = "Nature's Voice" Then
    Use = E_WEP
    Attack = "Highest"
    Att = 10
    Dam = 4
    Flags = Flags Or F_POIS Or F_REGN
    Depth = 11
  ElseIf s = "Swiftstrike" Then
    Use = E_WEP
    Attack = "Highest"
    Att = 10
    Dam = 4
    Speed = 20
    Stats(S_DEX) = 10
    Flags = Flags Or F_FAST
    Depth = 12
  ElseIf s = "Runesword" Then
    Use = E_WEP
    Attack = "Highest"
    Att = 10
    Dam = 4
    Flags = Flags Or F_MAGI Or F_FIRE Or F_COLD Or F_ELEC
    Res(R_COLD) = 20
    Res(R_FIRE) = 20
    Res(R_MAGI) = 20
    Res(R_ELEC) = 20
    Depth = 13
  ElseIf s = "Mindless Abandon" Then
    Use = E_WEP
    Attack = "Highest"
    Att = 20
    Dam = 8
    Flags = Flags Or F_CONF
    Speed = 20
    Stats(S_INT) = -50
    Stats(S_WIS) = -50
    Depth = 14
  ElseIf s = "Snickersnee" Then
    Use = E_WEP
    Attack = "Highest"
    Att = 15
    Dam = 4
    Flags = Flags Or F_HYPR
    Depth = 15
  ElseIf s = "Dracoclaw" Then
    Use = E_WEP
    Attack = "Highest"
    Att = 10
    Dam = 6
    Flags = Flags Or F_FIRE Or F_REGN
    Res(R_FIRE) = 50
    Depth = 16
  ElseIf s = "The Integer Goodnight" Then
    Use = E_WEP
    Attack = "Highest"
    Att = 10
    Dam = 4
    Flags = Flags Or F_SLEP Or F_BLND Or F_SLOW Or F_STUN
    Depth = 17
  ElseIf s = "Lord Protector" Then
    Use = E_WEP
    Attack = "Highest"
    Att = 10
    Dam = 4
    Def = 20
    DR = 5
    Flags = Flags Or F_REGN
    Depth = 18
  ElseIf s = "Magisword" Then
    Use = E_WEP
    Attack = "Highest"
    Att = 10
    Dam = 4
    Stats(S_INT) = 20
    Stats(S_WIS) = 20
    Flags = Flags Or F_MAGI
    Depth = 19
  ElseIf s = "Hellfire" Then
    Use = E_WEP
    Attack = "Highest"
    Att = 20
    Dam = 10
    Flags = Flags Or F_FIRE Or F_BLND
    Res(R_FIRE) = -50
    Depth = 20
  ElseIf s = "Eternal Dawn" Then
    Use = E_WEP
    Attack = "Highest"
    Att = 30
    Dam = 15
    Stats(S_STR) = 10
    Stats(S_DEX) = 10
    Stats(S_CON) = 10
    Stats(S_INT) = 10
    Stats(S_WIS) = 10
    Stats(S_CHA) = 10
    Flags = Flags Or F_MAGI Or F_PIRC Or F_LIFE
    Depth = 21
' artifact armor
  ElseIf s = "Lintel's Leather" Then
    Use = E_ARM
    Def = 8
    DR = 2
    Stats(S_REP) = 5
    Flags = Flags Or F_REGN
    Depth = 0
  ElseIf s = "Heartguard" Then
    Use = E_ARM
    Def = 8
    DR = 2
    Flags = Flags Or F_PIRC
    Depth = 1
  ElseIf s = "Artful Dodger" Then
    Use = E_ARM
    Def = 12
    DR = 2
    Stats(S_DEX) = 10
    Flags = Flags Or F_LONG
    Depth = 2
  ElseIf s = "Night's Cloak" Then
    Use = E_ARM
    Def = 8
    DR = 2
    Flags = Flags Or F_BLND Or F_CONF Or F_SLEP Or F_POIS Or F_VAMP
    Depth = 3
  ElseIf s = "Wyvernskin" Then
    Use = E_ARM
    Def = 8
    DR = 3
    Stats(S_CON) = 10
    Flags = Flags
    Depth = 4
  ElseIf s = "Chain of Wrath" Then
    Use = E_ARM
    Def = 8
    DR = 2
    Stats(S_STR) = 10
    Flags = Flags Or F_STUN
    Depth = 5
  ElseIf s = "Redemption" Then
    Use = E_ARM
    Def = 8
    DR = 2
    Stats(S_WIS) = 15
    Flags = Flags Or F_REGN Or F_VAMP
    Depth = 6
  ElseIf s = "Counterstrike" Then
    Use = E_ARM
    Def = 8
    DR = 2
    Att = 5
    Dam = 2
    Speed = 10
    DMS = 3
    Flags = Flags
    Depth = 7
  ElseIf s = "Mage Plate" Then
    Use = E_ARM
    Def = 8
    DR = 2
    Stats(S_INT) = 10
    Stats(S_WIS) = 10
    Res(R_MAGI) = 20
    Res(R_FIRE) = 10
    Res(R_ELEC) = 10
    Res(R_COLD) = 10
    Flags = Flags
    Depth = 8
  ElseIf s = "Treebark" Then
    Use = E_ARM
    Def = 12
    DR = 3
    Flags = Flags Or F_REGN Or F_POIS
    Depth = 9
  ElseIf s = "Hidden Dragon" Then
    Use = E_ARM
    Def = 0
    DR = 0
    Dam = 5
    Res(R_FIRE) = 20
    Flags = Flags
    Depth = 10
  ElseIf s = "Light Gatherer" Then
    Use = E_ARM
    Def = 8
    DR = 2
    Stats(S_INT) = 20
    Res(R_ELEC) = 20
    Flags = Flags Or F_FAST Or F_VAMP
    Depth = 11
  ElseIf s = "Princely Garments" Then
    Use = E_ARM
    Def = 8
    DR = 2
    Stats(S_REP) = 10
    Stats(S_CHA) = 50
    Flags = Flags Or F_POIS Or F_CONF
    Depth = 12
  ElseIf s = "Giant Breastplate" Then
    Use = E_ARM
    Def = 12
    DR = 4
    Stats(S_STR) = 15
    Stats(S_CON) = 15
    Speed = -10
    Flags = Flags
    Depth = 13
  ElseIf s = "Iceplate" Then
    Use = E_ARM
    Def = 12
    DR = 2
    Res(R_COLD) = 100
    Flags = Flags Or F_STUN Or F_SLEP
    Depth = 14
  ElseIf s = "Fire Warden" Then
    Use = E_ARM
    Def = 12
    DR = 2
    Res(R_FIRE) = 100
    Flags = Flags Or F_REGN
    Depth = 15
  ElseIf s = "Silksheath" Then
    Use = E_ARM
    Def = 15
    DR = 0
    Speed = 20
    Flags = Flags Or F_FAST
    Depth = 16
  ElseIf s = "Shell of Carmuth" Then
    Use = E_ARM
    Def = -10
    DR = 10
    Stats(S_REP) = 5
    Flags = Flags
    Depth = 17
  ElseIf s = "The Quickening" Then
    Use = E_ARM
    Def = 8
    DR = 2
    Flags = Flags Or F_HYPR Or F_SLOW Or F_SLEP Or F_CONF Or F_BLND
    Depth = 18
  ElseIf s = "Diamondine Swath" Then
    Use = E_ARM
    Def = 12
    DR = 3
    Stats(S_DEX) = 15
    Stats(S_CON) = 15
    Stats(S_CHA) = 15
    Flags = Flags Or F_PIRC
    Depth = 19
  ElseIf s = "Dragonscale" Then
    Use = E_ARM
    Def = 15
    DR = 4
    Stats(S_STR) = 20
    Res(R_FIRE) = 100
    Res(R_MAGI) = 100
    Flags = Flags Or F_PIRC
    Depth = 20
  ElseIf s = "Archangel's Garb" Then
    Use = E_ARM
    Def = 15
    DR = 5
    Speed = 50
    Stats(S_STR) = 10
    Stats(S_DEX) = 10
    Stats(S_CON) = 10
    Stats(S_INT) = 10
    Stats(S_WIS) = 10
    Stats(S_CHA) = 10
    Flags = Flags Or F_PIRC Or F_LIFE Or F_VAMP
    Depth = 21
' artifact boots
  ElseIf s = "Walking Shoes" Then
    Use = E_BTS
    Def = 2
    DR = 1
    Flags = Flags Or F_FAST
    Depth = 0
  ElseIf s = "Hoppers" Then
    Use = E_BTS
    Def = 3
    DR = 1
    Stats(S_DEX) = 5
    Flags = Flags Or F_SLOW Or F_STUN
    Depth = 1
  ElseIf s = "Glass Slippers" Then
    Use = E_BTS
    Def = 5
    DR = 0
    Flags = Flags Or F_PIRC Or F_SLEP
    Depth = 2
  ElseIf s = "Corwen's Footwear" Then
    Use = E_BTS
    Def = 2
    DR = 1
    Att = 5
    Stats(S_REP) = 5
    Res(R_MAGI) = 20
    Flags = Flags Or F_CONF
    Depth = 3
  ElseIf s = "Griffonhide Boots" Then
    Use = E_BTS
    Def = 2
    DR = 3
    Flags = Flags Or F_POIS
    Depth = 4
  ElseIf s = "Bladed Boots" Then
    Use = E_BTS
    Def = 2
    DR = 1
    Dam = 2
    DMS = 1
    Flags = Flags Or F_SLOW
    Depth = 5
  ElseIf s = "Shimmering Shoes" Then
    Use = E_BTS
    Def = 2
    DR = 1
    Stats(S_CHA) = 20
    Flags = Flags Or F_BLND
    Depth = 6
  ElseIf s = "Boots of Peace" Then
    Use = E_BTS
    Def = 2
    DR = 1
    Stats(S_WIS) = 10
    Stats(S_INT) = 10
    Flags = Flags Or F_VAMP
    Depth = 7
  ElseIf s = "Fire Walkers" Then
    Use = E_BTS
    Def = 2
    DR = 1
    Res(R_FIRE) = 30
    Flags = Flags Or F_REGN
    Depth = 8
  ElseIf s = "Shadow Dancers" Then
    Use = E_BTS
    Def = 5
    DR = 1
    Flags = Flags Or F_SLOW Or F_PIRC Or F_LONG
    Depth = 9
  ElseIf s = "Jeweled Greaves" Then
    Use = E_BTS
    Def = 3
    DR = 2
    Stats(S_CHA) = 10
    Flags = Flags Or F_CONF Or F_SLEP
    Depth = 10
  ElseIf s = "Blade Dancers" Then
    Use = E_BTS
    Def = 2
    DR = 1
    Att = 5
    Dam = 1
    DMS = 2
    Flags = Flags Or F_FAST
    Depth = 11
  ElseIf s = "Bloodstriders" Then
    Use = E_BTS
    Def = 2
    DR = 1
    Stats(S_STR) = 15
    Flags = Flags Or F_STUN
    Depth = 12
  ElseIf s = "Insulators" Then
    Use = E_BTS
    Def = 2
    DR = 1
    Res(R_ELEC) = 100
    Flags = Flags
    Depth = 13
  ElseIf s = "Stone Shoes" Then
    Use = E_BTS
    Def = 2
    DR = 1
    Speed = -10
    Stats(S_CON) = 10
    Stats(S_STR) = 5
    Flags = Flags Or F_STUN
    Depth = 14
  ElseIf s = "Relentless Pursuits" Then
    Use = E_BTS
    Def = 2
    DR = 1
    Speed = 20
    Flags = Flags Or F_SLOW Or F_STUN Or F_SLEP Or F_BLND Or F_CONF
    Depth = 15
  ElseIf s = "Boots of Jumping and Leaping" Then
    Use = E_BTS
    Def = 2
    DR = 1
    Flags = Flags Or F_HYPR Or F_LONG
    Depth = 16
  ElseIf s = "Suresteps" Then
    Use = E_BTS
    Def = 5
    DR = 1
    Stats(S_DEX) = 10
    Stats(S_INT) = 10
    Flags = Flags Or F_CONF
    Depth = 17
  ElseIf s = "Lightfoots" Then
    Use = E_BTS
    Def = 2
    DR = 1
    Res(R_MAGI) = 25
    Res(R_FIRE) = 20
    Flags = Flags Or F_POIS Or F_SLOW
    Depth = 18
  ElseIf s = "Mercurian Greaves" Then
    Use = E_BTS
    Def = 5
    DR = 1
    Speed = 100
    Flags = Flags Or F_LIFE
    Depth = 19
  ElseIf s = "Brimstones" Then
    Use = E_BTS
    Def = 2
    DR = 5
    Res(R_FIRE) = 50
    Res(S_STR) = 20
    Flags = Flags Or F_BLND Or F_PIRC
    Depth = 20
  ElseIf s = "Dusty Sandals" Then
    Use = E_BTS
    Def = 5
    DR = 3
    Res(R_FIRE) = 20
    Res(R_COLD) = 20
    Res(R_ELEC) = 20
    Res(R_MAGI) = 20
    Flags = Flags Or F_LIFE Or F_VAMP
    Depth = 21
' artifact gauntlets
  ElseIf s = "Nimble Fingers" Then
    Use = E_GNT
    Dam = 1
    Def = 1
    Stats(S_DEX) = 10
    Flags = Flags
    Depth = 0
  ElseIf s = "Mitts of Lysender" Then
    Use = E_GNT
    Dam = 1
    Def = 5
    Stats(S_REP) = 5
    Stats(S_STR) = 5
    Flags = Flags
    Depth = 1
  ElseIf s = "Cat's Claws" Then
    Use = E_GNT
    Dam = 3
    Def = 1
    Speed = 5
    Flags = Flags
    Depth = 2
  ElseIf s = "Electric Hands" Then
    Use = E_GNT
    Dam = 1
    Def = 1
    Res(R_ELEC) = 20
    Flags = Flags Or F_ELEC
    Depth = 3
  ElseIf s = "Detachers" Then
    Use = E_GNT
    Dam = 1
    Def = 1
    Flags = Flags Or F_PIRC
    Depth = 4
  ElseIf s = "Sloweners" Then
    Use = E_GNT
    Dam = 1
    Def = 1
    Flags = Flags Or F_SLOW
    Depth = 5
  ElseIf s = "Four-Fingered Freaks" Then
    Use = E_GNT
    Dam = 4
    Def = 4
    Stats(S_CHA) = -20
    Flags = Flags
    Depth = 6
  ElseIf s = "Greenthumbs" Then
    Use = E_GNT
    Dam = 1
    Def = 3
    Flags = Flags Or F_REGN
    Depth = 7
  ElseIf s = "Icy Hands of Death" Then
    Use = E_GNT
    Dam = 1
    Def = 1
    Flags = Flags Or F_POIS
    Depth = 8
  ElseIf s = "Dweomer Grips" Then
    Use = E_GNT
    Dam = 1
    Def = 1
    Res(R_MAGI) = 25
    Flags = Flags Or F_MAGI
    Depth = 9
  ElseIf s = "Gauntlets of Ogre Power" Then
    Use = E_GNT
    Dam = 1
    Def = 1
    Stats(S_STR) = 15
    Flags = Flags Or F_STUN
    Depth = 10
  ElseIf s = "Dark Gifts" Then
    Use = E_GNT
    Dam = 2
    Def = 2
    Flags = Flags Or F_VAMP
    Depth = 11
  ElseIf s = "Tildin's Defense" Then
    Use = E_GNT
    Dam = 1
    Def = 1
    Stats(S_REP) = 5
    Res(R_MAGI) = 20
    Res(R_ELEC) = 20
    Res(R_FIRE) = 20
    Res(R_COLD) = 20
    Flags = Flags
    Depth = 12
  ElseIf s = "Dartcatchers" Then
    Use = E_GNT
    Dam = 0
    Def = 10
    Flags = Flags Or F_FAST
    Depth = 13
  ElseIf s = "Bonecrushers" Then
    Use = E_GNT
    Dam = 1
    Def = 1
    Stats(S_STR) = 25
    Flags = Flags Or F_SLOW
    Depth = 14
  ElseIf s = "Eye Gougers" Then
    Use = E_GNT
    Dam = 1
    Def = 1
    Flags = Flags Or F_BLND Or F_CONF
    Depth = 15
  ElseIf s = "Flameholders" Then
    Use = E_GNT
    Dam = 1
    Def = 1
    Res(R_FIRE) = 30
    Flags = Flags Or F_FIRE
    Depth = 16
  ElseIf s = "Magefists" Then
    Use = E_GNT
    Dam = 1
    Def = 1
    Stats(S_INT) = 15
    Stats(S_WIS) = 15
    Flags = Flags Or F_MAGI
    Depth = 17
  ElseIf s = "Blood Siphons" Then
    Use = E_GNT
    Dam = 3
    Def = 1
    Flags = Flags Or F_VAMP
    Depth = 18
  ElseIf s = "Crystal Claws" Then
    Use = E_GNT
    Dam = 5
    Def = 2
    DMS = 5
    Flags = Flags Or F_PIRC
    Depth = 19
  ElseIf s = "Soulblighters" Then
    Use = E_GNT
    Dam = 4
    Def = 1
    Stats(S_INT) = 10
    Stats(S_CHA) = 15
    Flags = Flags Or F_CONF Or F_SLEP Or F_COLD
    Depth = 20
  ElseIf s = "Hands of God" Then
    Use = E_GNT
    Dam = 5
    Def = 5
    Stats(S_DEX) = 20
    Stats(S_STR) = 20
    Stats(S_CON) = 20
    Flags = Flags Or F_STUN Or F_BLND
    Depth = 21
' artifact helms
  ElseIf s = "Skull Cap" Then
    Use = E_HLM
    Def = 2
    DR = 1
    Flags = Flags Or F_VAMP Or F_POIS
    Depth = 0
  ElseIf s = "Crescent Gear" Then
    Use = E_HLM
    Def = 2
    DR = 1
    Flags = Flags Or F_LIFE
    Depth = 1
  ElseIf s = "Wolfscalp" Then
    Use = E_HLM
    Def = 2
    DR = 1
    Stats(S_STR) = 5
    Stats(S_DEX) = 5
    Flags = Flags
    Depth = 2
  ElseIf s = "Lighting Rod" Then
    Use = E_HLM
    Def = 2
    DR = 1
    DMS = 1
    Flags = Flags Or F_CONF
    Res(R_ELEC) = 25
    Depth = 3
  ElseIf s = "Velvet Hood" Then
    Use = E_HLM
    Def = 4
    DR = 1
    Flags = Flags Or F_SLEP Or F_SLOW
    Depth = 4
  ElseIf s = "Sunshade" Then
    Use = E_HLM
    Def = 2
    DR = 1
    Flags = Flags Or F_BLND
    Res(R_FIRE) = 25
    Depth = 5
  ElseIf s = "Truesight" Then
    Use = E_HLM
    Def = 3
    DR = 2
    Flags = Flags Or F_TRUE Or F_CONF
    Depth = 6
  ElseIf s = "Helm of Brilliance" Then
    Use = E_HLM
    Def = 2
    DR = 1
    Flags = Flags
    Stats(S_INT) = 10
    Res(R_MAGI) = 20
    Depth = 7
  ElseIf s = "The Awakener" Then
    Use = E_HLM
    Def = 2
    DR = 1
    Flags = Flags Or F_SLEP Or F_STUN Or F_SLOW Or F_CONF Or F_BLND
    Depth = 8
  ElseIf s = "Lunar Eclipse" Then
    Use = E_HLM
    Def = 2
    DR = 1
    Stats(S_WIS) = 15
    Res(R_COLD) = 25
    Flags = Flags
    Depth = 9
  ElseIf s = "Plumed Hat" Then
    Use = E_HLM
    Def = 2
    DR = 1
    Flags = Flags
    Stats(S_CHA) = 10
    Stats(S_REP) = 10
    Depth = 10
  ElseIf s = "Winged Helm" Then
    Use = E_HLM
    Def = 2
    DR = 2
    Speed = 15
    Flags = Flags Or F_FAST
    Depth = 11
  ElseIf s = "Hothead" Then
    Use = E_HLM
    Def = 4
    DR = 2
    Res(R_FIRE) = 50
    Flags = Flags Or F_BLND Or F_REGN
    Depth = 12
  ElseIf s = "Oakenhelm" Then
    Use = E_HLM
    Def = 2
    DR = 1
    Flags = Flags Or F_LIFE Or F_POIS
    Depth = 13
  ElseIf s = "Platinum Ruby Veil" Then
    Use = E_HLM
    Def = 2
    DR = 1
    Flags = Flags
    Stats(S_STR) = 15
    Stats(S_WIS) = 15
    Depth = 14
  ElseIf s = "Plain Circlet" Then
    Use = E_HLM
    Def = 5
    DR = 1
    Flags = Flags
    Res(R_MAGI) = 10
    Res(R_FIRE) = 10
    Res(R_COLD) = 10
    Res(R_ELEC) = 10
    Stats(S_CHA) = 50
    Depth = 15
  ElseIf s = "Pentil's Gear" Then
    Use = E_HLM
    Def = 2
    DR = 1
    Flags = Flags Or F_HYPR
    Stats(S_REP) = 5
    Depth = 16
  ElseIf s = "Wizard's Cone" Then
    Use = E_HLM
    Def = 2
    DR = 1
    Stats(S_INT) = 20
    Stats(S_WIS) = 20
    Res(R_MAGI) = 30
    Flags = Flags
    Depth = 17
  ElseIf s = "Crown of Radiance" Then
    Use = E_HLM
    Def = 3
    DR = 2
    Flags = Flags Or F_CONF Or F_PIRC Or F_POIS Or F_STUN
    Stats(S_REP) = 10
    Stats(S_CHA) = 10
    Res(R_ELEC) = 20
    Res(R_FIRE) = 20
    Depth = 18
  ElseIf s = "Dragon Ribbon" Then
    Use = E_HLM
    Def = 10
    DR = 5
    DMS = 2
    Flags = Flags
    Stats(S_STR) = 10
    Res(R_FIRE) = 25
    Depth = 19
  ElseIf s = "Fearsome Visage" Then
    Use = E_HLM
    Def = 15
    DR = 1
    Flags = Flags Or F_BLND Or F_SLEP Or F_CONF Or F_VAMP
    Stats(S_CHA) = 15
    Stats(S_DEX) = 10
    Stats(S_CON) = 10
    Depth = 20
  ElseIf s = "Angelic Halo" Then
    Use = E_HLM
    Def = 5
    DR = 2
    Flags = Flags Or F_LIFE
    Res(R_FIRE) = 30
    Res(R_COLD) = 30
    Res(R_ELEC) = 30
    Stats(S_INT) = 15
    Stats(S_WIS) = 15
    Stats(S_CHA) = 15
    Stats(S_REP) = 15
    Depth = 21
' artifact shields
  ElseIf s = "Skinguard" Then
    Use = E_SLD
    Def = 5
    DR = 2
    DMS = 1
    Flags = Flags
    Depth = 0
  ElseIf s = "Killian's Blanket" Then
    Use = E_SLD
    Def = 2
    DMS = 1
    Flags = Flags Or F_SLEP
    Stats(S_REP) = 5
    Depth = 1
  ElseIf s = "Ironarm" Then
    Use = E_SLD
    Def = 2
    DMS = 1
    Stats(S_STR) = 5
    Flags = Flags Or F_STUN
    Depth = 2
  ElseIf s = "Reflector" Then
    Use = E_SLD
    Def = 2
    DMS = 2
    Res(R_FIRE) = 10
    Res(R_ELEC) = 10
    Res(R_COLD) = 10
    Res(R_MAGI) = 10
    Flags = Flags
    Depth = 3
  ElseIf s = "Lodestone Shield" Then
    Use = E_SLD
    Def = 10
    DMS = 1
    Speed = -10
    Flags = Flags Or F_SLOW
    Depth = 4
  ElseIf s = "Ignitor" Then
    Use = E_SLD
    Def = 2
    DMS = 2
    Res(R_FIRE) = 30
    Flags = Flags Or F_PIRC
    Depth = 5
  ElseIf s = "Spiked Basher" Then
    Use = E_SLD
    Def = 2
    DMS = 5
    Flags = Flags
    Depth = 6
  ElseIf s = "Hornarm" Then
    Use = E_SLD
    Def = 2
    DMS = 2
    Res(R_COLD) = 25
    Flags = Flags Or F_CONF Or F_POIS
    Depth = 7
  ElseIf s = "Friend in Need" Then
    Use = E_SLD
    Def = 2
    DMS = 1
    Flags = Flags Or F_REGN
    Stats(S_CON) = 10
    Depth = 8
  ElseIf s = "Shield of Faith" Then
    Use = E_SLD
    Def = 2
    DMS = 1
    Flags = Flags
    Stats(S_INT) = 10
    Stats(S_WIS) = 10
    Depth = 9
  ElseIf s = "Twinshield" Then
    Use = E_SLD
    Def = 10
    DMS = 1
    Flags = Flags Or F_PIRC
    Depth = 10
  ElseIf s = "Ice Mirror" Then
    Use = E_SLD
    Def = 2
    DMS = 1
    Res(R_COLD) = 35
    Stats(S_CHA) = 10
    Flags = Flags Or F_BLND Or F_VAMP
    Depth = 11
  ElseIf s = "Hope of Corgan" Then
    Use = E_SLD
    Def = 2
    DMS = 1
    DR = 5
    Flags = Flags Or F_REGN
    Stats(S_REP) = 5
    Depth = 12
  ElseIf s = "Foe's Lament" Then
    Use = E_SLD
    Def = 10
    DMS = 5
    Flags = Flags
    Depth = 13
  ElseIf s = "Mithril Salute" Then
    Use = E_SLD
    Def = 2
    DMS = 1
    Flags = Flags Or F_PIRC Or F_POIS Or F_SLOW
    Stats(S_REP) = 10
    Stats(S_CHA) = 10
    Res(R_MAGI) = 10
    Res(R_COLD) = 10
    Res(R_FIRE) = 10
    Res(R_ELEC) = 10
    Depth = 14
  ElseIf s = "Bladeblocker" Then
    Use = E_SLD
    Def = 15
    DMS = 2
    Speed = 20
    Flags = Flags Or F_LONG
    Depth = 15
  ElseIf s = "Starfield" Then
    Use = E_SLD
    Def = 2
    DMS = 1
    Flags = Flags Or F_FAST
    Stats(S_INT) = 10
    Stats(S_DEX) = 10
    Depth = 16
  ElseIf s = "Fierce Defender" Then
    Use = E_SLD
    Def = 2
    DMS = 5
    Att = 5
    Dam = 2
    Flags = Flags
    Depth = 17
  ElseIf s = "Sword Router" Then
    Use = E_SLD
    Def = 10
    DMS = 1
    DR = 5
    Flags = Flags Or F_PIRC Or F_STUN Or F_VAMP
    Depth = 18
  ElseIf s = "Shield of the Rising Phoenix" Then
    Use = E_SLD
    Def = 5
    DMS = 3
    Stats(S_CON) = 10
    Res(R_FIRE) = 50
    Flags = Flags Or F_LIFE Or F_POIS Or F_BLND
    Depth = 19
  ElseIf s = "Darkrock" Then
    Use = E_SLD
    Def = 5
    DMS = 2
    DR = 2
    Flags = Flags Or F_VAMP Or F_TRUE Or F_CONF
    Res(R_MAGI) = 25
    Res(R_COLD) = 25
    Stats(S_STR) = 10
    Stats(S_WIS) = 10
    Depth = 20
  ElseIf s = "Wings of the Seraphim" Then
    Use = E_SLD
    Def = 10
    DMS = 5
    Res(R_FIRE) = 25
    Res(R_ELEC) = 25
    Stats(S_CON) = 15
    Stats(S_REP) = 10
    Stats(S_INT) = 10
    Flags = Flags Or F_LONG Or F_BLND Or F_HYPR
    Depth = 21
' terrain collectables
  ElseIf s = "Gemstone" Then
  ElseIf s = "Flower" Then
  ElseIf s = "Bone" Then
  ElseIf s = "Leaf" Then
' trade goods
  ElseIf s = "Wood" Then
    Use = E_TRD
    Att = G_WOOD
    Depth = A
    ID = True
    Value = I_BASE * 1 * A * (I_MANT ^ Depth)
    Post = " Depth " & Depth
  ElseIf s = "Food" Then
    Use = E_TRD
    Att = G_FOOD
    Depth = A
    ID = True
    Value = I_BASE * 1 * A * (I_MANT ^ Depth)
    Post = " Depth " & Depth
  ElseIf s = "Metal Ore" Then
    Use = E_TRD
    Att = G_ORES
    Depth = A
    ID = True
    Value = I_BASE * 1 * A * (I_MANT ^ Depth)
    Post = " Depth " & Depth
  ElseIf s = "Gemstones" Then
    Use = E_TRD
    Att = G_GEMS
    Depth = A
    ID = True
    Value = I_BASE * 3 * A * (I_MANT ^ Depth)
    Post = " Depth " & Depth
  ElseIf s = "Artifacts" Then
    Use = E_TRD
    Att = G_ARTS
    Depth = A
    ID = True
    Value = I_BASE * 5 * A * (I_MANT ^ Depth)
    Post = " Depth " & Depth
  ElseIf s = "Weapons" Then
    Use = E_TRD
    Att = G_WEPS
    Depth = A
    ID = True
    Value = I_BASE * 2 * A * (I_MANT ^ Depth)
    Post = " Depth " & Depth
  ElseIf s = "Medicine" Then
    Use = E_TRD
    Att = G_MEDS
    Depth = A
    ID = True
    Value = I_BASE * 2 * A * (I_MANT ^ Depth)
    Post = " Depth " & Depth
' wands
  ElseIf s = "Wand of Portals" Then
    Use = E_NON
    Att = -1
    Notes = Int(Rnd * 10) + 5
    Value = 10000
    Depth = 10
  ElseIf s = "Wand of Terrain" Then
    Use = E_NON
    Att = -1
    Notes = Int(Rnd * 10) + 5
    Value = 10000
    Depth = 10
  ElseIf s = "Foundation" Then
    Use = E_NON
    Att = -1
    Depth = A
    Value = I_BASE * 10 * A * (I_MANT ^ Depth)
    Post = " Depth " & Depth
  Else
    Name = "Doodad, probably an error"
    Use = E_NON
    Stat = S_STR
    Text = Use & ": Doodad, probably an error"
  End If
  
  If Use = E_WEP Then
    If Stat = S_DEX Then
      Att = Max(0, Att + Int(PM((Depth + 1) * 4.55, 20)))
      Dam = Max(0, Dam + Int(PM((Depth + 1) * 1.46, 20)) + 2)
    ElseIf Stat = S_STR Then
      Att = Max(0, Att + Int(PM((Depth + 1) * 3.5, 20)))
      Dam = Max(0, Dam + Int(PM((Depth + 1) * 1.75, 20)) + 2)
    ElseIf Attack = "MageStr" Then
      Att = Max(0, Att + Int(PM((Depth + 1) * 3, 20)))
      Dam = Max(0, Dam + Int(PM((Depth + 1) * 1.2, 20)) + 2)
    Else
      Att = Max(0, Att + Int(PM((Depth + 1) * 4.55, 20)))
      Dam = Max(0, Dam + Int(PM((Depth + 1) * 1.75, 20)) + 2)
    End If
  ElseIf Use = E_ARM Then
    Def = Max(0, Def + Int(PM((Depth + 1) * 4, 20)))
    DR = Max(0, DR + Int(PM((Depth + 1) * 0.6, 20)))
  ElseIf Use = E_SLD Then
    Def = Max(0, Def + Int(PM((Depth + 1) * 1.25, 20)) + 1)
'    DR = Max(0, DR + Int(pm((Depth + 1) * 0.25, 20)) + Int(Rnd * 2))
    DMS = Max(0, DMS + Int(PM((Depth + 1) * 0.25, 20)) + Int(Rnd * 2))
  ElseIf Use = E_GNT Then
    Def = Max(0, Def + Int(PM((Depth + 1) \ 2, 20)) + 2 + Int(Rnd * 2))
    Dam = Max(0, Dam + Int(PM((Depth + 1) \ 2, 20)) + Int(Rnd * 2))
  ElseIf Use = E_HLM Then
    Def = Max(0, Def + Int(PM((Depth + 1) * 1, 20)))
    DR = Max(0, DR + Int(PM((Depth + 1) * 0.25, 20)))
  ElseIf Use = E_BTS Then
    Def = Max(0, Def + Int(PM((Depth + 1) * 0.65, 20)))
    DR = Max(0, DR + Int(PM((Depth + 1) * 0.25, 20)))
  End If
  
'  BaseName = S
  UnIDText = Use & ": " & BaseName
  
  If e > 0 Then
    Do
      Call Me.AddPre(e)
      e = e \ 2
    Loop While Int(Rnd * 100) < e
  End If
  
  If f > 0 Then
    Do
      Call Me.AddPost(f)
      f = f \ 2
    Loop While Int(Rnd * 100) < f
  End If
  
  If Name = "" Then
    Name = Ele & BaseName & Post
  End If
  Flags = Flags Or flgs
  
'  If Name = "" Then
'    Name = Ele & S & Post
'  Else
'    Name = Ele & Name & Post
'  End If
'  Text = Use & ": " & Name
  
  If num = 0 Then num = 1
  
  Call SetText
  
  If BaseName = "Scroll" Then
    Name = "Scroll"
  ElseIf BaseName = "Map" Then
    Name = "Map"
  ElseIf BaseName = "Knowledge" Then
    Name = "Knowledge"
  ElseIf BaseName = "Foundation" Then
    Name = "Foundation"
  End If
   
  If Value = 0 Then
    Call SetValue
  End If
  
'  If S = "Healing Potion" Then
'    Dim eoinvu As Integer
'    eoinvu = Value
  'End If
  
End Sub

Public Function AddPre(e As Integer, Optional ec As Integer = -1, Optional times As Integer = 10) As Integer
  Dim i As Integer
  
  AddPre = -1
  If Int(Rnd * 100) < e Then
    If Use = E_RG1 Then
      Depth = Depth + 7
    Else
      Depth = Depth + 0
    End If
prehack:
    If ec = -1 Then ec = Int(Rnd * 16)
    If ec = 0 And InStr(1, Text, "Flame ") = 0 Then
      Ele = Ele & "Flame "
      Flags = Flags Or F_FIRE
      Res(R_FIRE) = Res(R_FIRE) + Rnd * (Me.Depth + 5) + 5
    ElseIf ec = 1 And InStr(1, Text, "Frost ") = 0 Then
      Ele = Ele & "Frost "
      Flags = Flags Or F_COLD
      Res(R_COLD) = Res(R_COLD) + Rnd * (Me.Depth + 5) + 5
    ElseIf ec = 2 And InStr(1, Text, "Electric ") = 0 Then
      Ele = Ele & "Electric "
      Flags = Flags Or F_ELEC
      Res(R_ELEC) = Res(R_ELEC) + Rnd * (Me.Depth + 5) + 5
    ElseIf ec = 3 And InStr(1, Text, "Prismatic ") = 0 Then
      Ele = Ele & "Prismatic "
      Flags = Flags Or F_CONF
      Res(R_MAGI) = Res(R_MAGI) + Rnd * (Me.Depth + 5) + 5
    ElseIf ec = 4 And InStr(1, Text, "Vorpal ") = 0 Then
      Ele = Ele & "Vorpal "
      Flags = Flags Or F_PIRC
      DR = DR * 2
    ElseIf ec = 5 And InStr(1, Text, "Ensnaring ") = 0 Then
      Ele = Ele & "Ensnaring "
      Flags = Flags Or F_SLOW
    ElseIf ec = 6 And InStr(1, Text, "Venomous ") = 0 Then
      Ele = Ele & "Venomous "
      Flags = Flags Or F_POIS
    ElseIf ec = 7 And InStr(1, Text, "King's ") = 0 Then
      Ele = Ele & "King's "
      Att = Att + Int(Rnd * Me.Depth) + 1
      Dam = Dam + Int(Rnd * (Me.Depth)) \ 2 + 1
    ElseIf ec = 8 And InStr(1, Text, "Defender's ") = 0 Then
      Ele = Ele & "Defender's "
      DR = DR + Int(Rnd * (Me.Depth)) \ 2 + 1
      Def = Def + Int(Rnd * (Me.Depth)) + 1
    ElseIf ec = 9 And InStr(1, Text, "Enchanted ") = 0 Then
      Ele = Ele & "Enchanted "
      Flags = Flags Or F_MAGI
      Att = Att + PM(Me.Depth \ 2, 50) + 1
    ElseIf ec = 10 And InStr(1, Text, "Arcane ") = 0 Then
      Ele = Ele & "Arcane "
      Flags = Flags Or F_FIRE Or F_COLD Or F_ELEC Or F_MAGI
      Res(R_FIRE) = Res(R_FIRE) + Rnd * -20 - 1
      Res(R_COLD) = Res(R_COLD) + Rnd * -20 - 1
      Res(R_ELEC) = Res(R_ELEC) + Rnd * -20 - 1
      Res(R_MAGI) = Res(R_MAGI) + Rnd * -20 - 1
      Depth = Depth + 1
      If Use <> E_WEP Then
        Res(R_FIRE) = -Res(R_FIRE)
        Res(R_COLD) = -Res(R_COLD)
        Res(R_ELEC) = -Res(R_ELEC)
        Res(R_MAGI) = -Res(R_MAGI)
        Me.Depth = Me.Depth - 1
      End If
    ElseIf ec = 11 And InStr(1, Text, "Vampiric ") = 0 Then
      Ele = Ele & "Vampiric "
      Flags = Flags Or F_VAMP
    ElseIf ec = 12 And InStr(1, Text, "Holy ") = 0 Then
      Ele = Ele & "Holy "
      Flags = Flags Or F_LIFE
      Depth = Depth + 1
    ElseIf ec = 13 And InStr(1, Text, "Insightful ") = 0 Then
      Ele = Ele & "Insightful "
      Flags = Flags Or F_TRUE
      Stats(S_INT) = Stats(S_INT) + Int(Rnd * Depth) + 1
    ElseIf ec = 14 And InStr(1, Text, "Vengeful ") = 0 Then
      Ele = Ele & "Vengeful "
      DMS = DMS + Int(Rnd * Depth) \ 2 + 1
    ElseIf ec = 15 And InStr(1, Text, "Brilliant ") = 0 Then
      Ele = Ele & "Brilliant "
      Flags = Flags Or F_BLND
    Else
      i = i + 1
      If i < times Then
        ec = -1
        GoTo prehack
      Else
        AddPre = -1
      If Use = E_RG1 Then
        Depth = Depth - 7
      Else
        Depth = Depth + 0
      End If
        Exit Function
      End If
    End If
    If Use = E_RG1 Then
      Depth = Depth + 0
    Else
      Depth = Depth + 1
    End If
    AddPre = ec

  End If
  
  Name = Ele & BaseName & Post
'  Text = Use & ": " & Name
  Call SetText
End Function

Public Function AddPost(f As Integer, Optional fc = -1, Optional times As Integer = 10) As Integer
  Dim i As Integer
  
  AddPost = -1
  If Int(Rnd * 100) < f Then
    If Use = E_RG1 Then
      Depth = Depth + 7
    Else
      Depth = Depth + 0
    End If
posthack:
    If fc = -1 Then fc = Int(Rnd * 21)
    If fc = 0 And InStr(1, Text, " of Agility") = 0 Then
      Post = Post & " of Agility"
      Stats(S_DEX) = Stats(S_DEX) + Int((Rnd * Me.Depth + 5) + (Rnd * 2 + 1))
    ElseIf fc = 1 And InStr(1, Text, " of Strength") = 0 Then
      Post = Post & " of Strength"
      Stats(S_STR) = Stats(S_STR) + Int((Rnd * Me.Depth + 5) + (Rnd * 2 + 1))
    ElseIf fc = 2 And InStr(1, Text, " of Health") = 0 Then
      Post = Post & " of Health"
      Stats(S_CON) = Stats(S_CON) + Int((Rnd * Me.Depth + 5) + (Rnd * 2 + 1))
    ElseIf fc = 3 And InStr(1, Text, " of Genius") = 0 Then
      Post = Post & " of Genius"
      Stats(S_INT) = Stats(S_INT) + Int((Rnd * Me.Depth + 5) + (Rnd * 2 + 1))
    ElseIf fc = 4 And InStr(1, Text, " of Wisdom") = 0 Then
      Post = Post & " of Wisdom"
      Stats(S_WIS) = Stats(S_WIS) + Int((Rnd * Me.Depth + 5) + (Rnd * 2 + 1))
    ElseIf fc = 5 And InStr(1, Text, " of Beauty") = 0 Then
      Post = Post & " of Beauty"
      Stats(S_CHA) = Stats(S_CHA) + Int((Rnd * Me.Depth + 5) + (Rnd * 2 + 1))
    ElseIf fc = 6 And InStr(1, Text, " of Speed") = 0 Then
      Post = Post & " of Speed"
      Speed = Speed + Int((Rnd * Me.Depth + 5) + (Rnd * 2 + 2))
    ElseIf fc = 7 And InStr(1, Text, " of Shielding") = 0 Then
      Post = Post & " of Shielding"
      Def = Def + ((Rnd * Me.Depth)) + 5
      ' deal with at bottom
    ElseIf fc = 8 And InStr(1, Text, " of Reknown") = 0 Then
      Post = Post & " of Reknown"
      Stats(S_REP) = Stats(S_REP) + (Rnd * Me.Depth + 5) + (Rnd * 2 + 1)
    ElseIf fc = 9 And InStr(1, Text, " of Absorption") = 0 Then
      Post = Post & " of Absorption"
      DR = DR + ((Rnd * Me.Depth) \ 2) + 1
      ' deal with at bottom
    ElseIf fc = 10 And InStr(1, Text, " of Regeneration") = 0 Then
      Post = Post & " of Regeneration"
      Flags = Flags Or F_REGN
'      Value = Value + C_STATCOST * 7
    ElseIf fc = 11 And InStr(1, Text, " of Life") = 0 Then
      Post = Post & " of Life"
      Flags = Flags Or F_LIFE
'      Value = Value + C_STATCOST * 33
      Depth = Depth + 1
    ElseIf fc = 12 And InStr(1, Text, " of Haste") = 0 Then
      Post = Post & " of Haste"
      Flags = Flags Or F_FAST
'      Value = Value + C_STATCOST * 7
    ElseIf fc = 13 And InStr(1, Text, " of Hyper") = 0 Then
      Post = Post & " of Hyper"
      Flags = Flags Or F_HYPR
'      Value = Value + C_STATCOST * 33
      Depth = Depth + 1
    ElseIf fc = 14 And InStr(1, Text, " of the Magi") = 0 Then
      Post = Post & " of the Magi"
      Stats(S_INT) = Stats(S_INT) + (Rnd * Me.Depth + 1)
      Stats(S_WIS) = Stats(S_WIS) + (Rnd * Me.Depth + 1)
'      Stats(S_STR) = -(Rnd * Me.Depth + 1) * (Rnd * 4 + 1)
      Depth = Depth + 1
    ElseIf fc = 15 And InStr(1, Text, " of War") = 0 Then
      Post = Post & " of War"
      Stats(S_DEX) = Stats(S_DEX) + (Rnd * Me.Depth + 1)
      Stats(S_STR) = Stats(S_STR) + (Rnd * Me.Depth + 1)
'      Stats(S_INT) = -(Rnd * Me.Depth + 1) * (Rnd * 4 + 1)
      Depth = Depth + 1
    ElseIf fc = 16 And InStr(1, Text, " of Thieves") = 0 Then
      Post = Post & " of Thieves"
      Stats(S_DEX) = Stats(S_DEX) + (Rnd * Me.Depth + 5) + (Rnd * 10 + 1)
      Stats(S_REP) = Stats(S_REP) - ((Rnd * Me.Depth + 1) + (Rnd * 8 + 1))
      Depth = Depth + 1
    ElseIf fc = 17 And InStr(1, Text, " of Maiming") = 0 Then
      Post = Post & " of Maiming"
      Dam = Dam + Int(Rnd * Me.Depth) + 1
    ElseIf fc = 18 And InStr(1, Text, " of Guiding") = 0 Then
      Post = Post & " of Guiding"
      Att = Att + Int(Rnd * Me.Depth * 2) + 1
    ElseIf fc = 19 And InStr(1, Text, " of Reflection") = 0 Then
      Post = Post & " of Reflection"
      Res(R_FIRE) = Res(R_FIRE) + Rnd * Me.Depth + 5
      Res(R_COLD) = Res(R_COLD) + Rnd * Me.Depth + 5
      Res(R_ELEC) = Res(R_ELEC) + Rnd * Me.Depth + 5
      Res(R_MAGI) = Res(R_MAGI) + Rnd * Me.Depth + 5
    ElseIf fc = 20 And InStr(1, Text, " of Vengeance") = 0 Then
      Post = Post & " of Vengeance"
      DMS = DMS + Int(Rnd * Depth) \ 2 + 1
    ElseIf fc = 21 And InStr(1, Text, " of Radiance") = 0 Then
      Post = Post & " of Radiance"
      Flags = Flags & F_BLND
      DMS = DMS + Int(Rnd * Depth) \ 3 + 1
    Else
      i = i + 1
      If i < times Then
        fc = -1
        GoTo posthack
      Else
        AddPost = -1
      If Use = E_RG1 Then
        Depth = Depth - 7
      Else
        Depth = Depth + 0
      End If
        Exit Function
      End If
    End If
    If Use = E_RG1 Then
      Depth = Depth + 0
    Else
      Depth = Depth + 1
    End If
    AddPost = fc
  End If
  
  Name = Ele & BaseName & Post
'  Text = Use & ": " & Name
  Call SetText
End Function

Public Sub SetValue()
  Dim i As Integer
  Value = I_BASE * Depth
  Value = Value + Max(0, I_ATT * Att * (I_MANT ^ Depth))
  Value = Value + Max(0, I_DEF * Def * (I_MANT ^ Depth))
  Value = Value + Max(0, I_DAM * Dam * (I_MANT ^ Depth))
  Value = Value + Max(0, I_DR * DR * (I_MANT ^ Depth))
  Value = Value + Max(0, I_DR * DMS * (I_MANT ^ Depth))
  Value = Value + Max(0, (I_STAT) * Speed * (I_MANT ^ Depth))
  
  For i = 0 To C_RESISTS - 1
    Value = Value + Max(0, I_RES * Res(i) * (I_MANT ^ Depth))
  Next i

  For i = 0 To C_STATS - 1
    If i = S_CHA Then
      Value = Value + Max(0, (I_STAT / 10) * Stats(i) * (I_MANT ^ Depth))
    Else
      Value = Value + Max(0, I_STAT * Stats(i) * (I_MANT ^ Depth))
    End If
  Next i

  If Flags <> 0 Then Value = Value + I_FLAG * (I_MANT ^ Depth)

  If Attack = "MageStr" Then
    Value = Value / 3
  End If
  
  If Attack = "Bow" Then
    Value = Value / 2
  End If
  
  If Use = E_RG1 Then
    Value = Value / 3
  End If
  
  Value = Round(Value, 0)

End Sub

Public Sub SetText()
 
  Text = Hex(Use) & ": "
  
  If Use = E_WEP Then
    If SkillBonus < 0.1 Then
      Text = Text
    ElseIf SkillBonus < 0.2 Then
      Text = Text & "[Familiar] "
    ElseIf SkillBonus < 0.3 Then
      Text = Text & "[Basic] "
    ElseIf SkillBonus < 0.4 Then
      Text = Text & "[Adept] "
    ElseIf SkillBonus < 0.5 Then
      Text = Text & "[Skilled] "
    ElseIf SkillBonus < 0.6 Then
      Text = Text & "[Master] "
    ElseIf SkillBonus >= 0.6 Then
      Text = Text & "[Perfect] "
    End If
  End If
  
  Text = Text & Name
  
'  If Ele <> "" Then Value = Value * 1.5
'  If Post <> "" Then Value = Value * 1
  
    'att =
    'dam =
    'def =
    'dr =
  If Att <> 0 And Use <> E_NON And Use <> E_SER And Use <> E_TRD Then
    If Stat = S_STR Then
      Text = Text & " StAt:" & Att
    ElseIf Stat = S_DEX Then
      Text = Text & " DxAt:" & Att
    Else
      Text = Text & " Att:" & Att
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
  If DMS <> 0 Then
    Text = Text & " DS:" & DMS
  End If
  
  If Stats(S_STR) <> 0 Then
    Text = Text & " St:" & Stats(S_STR)
'    Value = Value + C_STATCOST * Stats(S_STR)
  End If
  If Stats(S_DEX) <> 0 Then
    Text = Text & " Dx:" & Stats(S_DEX)
'    Value = Value + C_STATCOST * Stats(S_DEX)
  End If
  If Stats(S_CON) <> 0 Then
    Text = Text & " Cn:" & Stats(S_CON)
'    Value = Value + C_STATCOST * Stats(S_CON)
  End If
  If Stats(S_INT) <> 0 Then
    Text = Text & " In:" & Stats(S_INT)
'    Value = Value + C_STATCOST * Stats(S_INT)
  End If
  If Stats(S_WIS) <> 0 Then
    Text = Text & " Wi:" & Stats(S_WIS)
'    Value = Value + C_STATCOST * Stats(S_WIS)
  End If
  If Stats(S_CHA) <> 0 Then
    Text = Text & " Ch:" & Stats(S_CHA)
'    Value = Value + C_STATCOST * Stats(S_CHA)
  End If
  If Stats(S_REP) <> 0 Then
    Text = Text & " Rp:" & Stats(S_REP)
'    Value = Value + C_STATCOST * Stats(S_REP)
  End If
  If Speed <> 0 Then
    Text = Text & " Sp:" & Speed
'    Value = Value + C_STATCOST * Speed \ 2
  End If
  
  If Res(R_FIRE) <> 0 Then
    Text = Text & " RF:" & Res(R_FIRE)
'    Value = Value + 30 * Res(R_FIRE)
  End If
  If Res(R_COLD) <> 0 Then
    Text = Text & " RC:" & Res(R_COLD)
'    Value = Value + 30 * Res(R_COLD)
  End If
  If Res(R_ELEC) <> 0 Then
    Text = Text & " RE:" & Res(R_ELEC)
'    Value = Value + 30 * Res(R_ELEC)
  End If
  If Res(R_MAGI) <> 0 Then
    Text = Text & " RM:" & Res(R_MAGI)
'    Value = Value + 30 * Res(R_MAGI)
  End If
  
  If Use = E_SER Then Text = Use & ": " & Name

End Sub

Public Sub Create(ByVal T As Integer, ByVal dep As Integer, Optional ByVal mindep As Integer = -1, Optional ByVal mchance = 20)
  Dim r As Double
  Dim r2 As Double
  Dim e As Integer
  Dim p As Integer
  Dim dif As Integer
  Dim Ele As String
  Dim flgs As Integer
  Dim c As Integer
  Dim i As Integer
'  Dim Bypass As long
  Dim ErrorCounter As Integer
  Dim tomake As Integer
  Dim counter As Integer
  
'  For i = 0 To d
'    r = r + Int(Rnd * 100) + 1
'  Next i
  
  Me.Bypass = 0
  dep = Max(dep, 0) + 1
  Me.Depth = dep
  
  If mindep = -1 Then
    mindep = Max(0, dep - 5)
  Else
    mindep = Max(0, mindep)
  End If
'  If T = S_WEP Or T = S_ARM Then
'    mindep = Max(0, mindep)
'  Else
'    mindep = 0
'  End If
'  c = Min((2 ^ Min(d - (r \ 50), 10)) * 5, 100)
'  c = (dep + 1) * (Int(Rnd * 3) + 1)
  c = mchance ' chance of magic
AGAIN:
  If T = S_TRAN Or T = S_CAST Then
    tomake = Int(Rnd * 4)
  Else
    tomake = T
  End If
  If tomake = S_WEP Then
    r = (Rnd * 44)
        
        Call Me.MakeItem(1, r, "Knife", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Rapier", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Short Sword", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Short Bow", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Long Bow", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Great Bow", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Meteor Bow", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Sabre", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Katana", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Nunchuckas", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Staff", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Truncheon", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Dagger", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Longsword", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Broadsword", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Battle Axe", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Great Axe", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Greatsword", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Bastard Sword", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Mace", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Flail", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Naginata", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Halbard", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Stormstriker", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Heavenly Wrath", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Galactic Incisor", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Crystaline Blade", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Obsidian Slasher", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Dragontooth", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Cantrip Wand", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Glowing Wand", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Imbued Wand", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Dweomer Wand", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Ensorceled Wand", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Youthful Rod", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Elder Rod", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Wizened Rod", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Sage Rod", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Ancient Rod", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Apprentice Staff", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Mage Staff", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Wizard Staff", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Sorcerer Staff", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Archmage Staff", 0, 0, 0, c, c)
        Call Me.MakeItem(100, r, "Doodad")
  ElseIf tomake = S_ARM Then
    r = (Rnd * 29)
        Call Me.MakeItem(1, r, "Adamantite Full Plate", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Clothing", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Padded Leather", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Hard Leather", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Hunting Leather", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Ring Mail", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Scale Mail", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Chain Mail", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Brigantine", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Plate Mail", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Full Plate", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Field Plate", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Mithril Chain Mail", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Leather Cap", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Leather Hood", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Chain Coif", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Steel Cap", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Plate Coif", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Horned Mask", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Great Helm", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Full Helm", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Crested Helm", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Buckler", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Arm Shield", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Kite Shield", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Tower Shield", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Mirror Shield", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Displacement Shield", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Vortex Shield", 0, 0, 0, c, c)
        Call Me.MakeItem(100, r, "Doodad")
  ElseIf tomake = S_GEN Then
     r = (Rnd * 17)
        Call Me.MakeItem(1, r, "Sandals", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Shoes", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Riding Boots", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Iron Boots", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "War Boots", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Plate Greaves", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Battle Greaves", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Leather Gloves", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Brass Knuckles", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Chain Gloves", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Plated Gauntlets", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Knife Gloves", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Steel Gauntlets", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Set of Cesti", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Adamantium Claws", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Wyrm Bracers", 0, 0, 0, c, c)
        Call Me.MakeItem(1, r, "Foundation", dep)
        Call Me.MakeItem(100, r, "Doodad")
  ElseIf tomake = S_MAG Then
    r = Int(Rnd * 100) + 1
    Select Case r
      Case 1 To 30 ' rings
        r2 = Int(Rnd * 100) + 1
        Select Case r2
          Case 1 To 20
            Call Me.MakeItem(1, 1, "Ring", 0, 0, 0, c, c, Me.Depth)
'            Me.Depth = Max(Me.Depth - 4, 0)
          Case 21 To 30
            Call Me.MakeItem(1, 1, "Granite Ring", Int(Rnd * (dep - mindep + 1) + mindep))
          Case 31 To 40
            Call Me.MakeItem(1, 1, "Ruby Ring", Int(Rnd * (dep - mindep + 1) + mindep))
          Case 41 To 50
            Call Me.MakeItem(1, 1, "Emerald Ring", Int(Rnd * (dep - mindep + 1) + mindep))
          Case 51 To 60
            Call Me.MakeItem(1, 1, "Pearl Ring", Int(Rnd * (dep - mindep + 1) + mindep))
          Case 61 To 70
            Call Me.MakeItem(1, 1, "Diamond Ring", Int(Rnd * (dep - mindep + 1) + mindep))
          Case 71 To 80
            Call Me.MakeItem(1, 1, "Sapphire Ring", Int(Rnd * (dep - mindep + 1) + mindep))
          Case 81 To 90
            Call Me.MakeItem(1, 1, "Opal Ring", Int(Rnd * (dep - mindep + 1) + mindep))
          Case 91 To 100
            Call Me.MakeItem(1, 1, "Jeweled Ring", Int(Rnd * (dep - mindep + 1) + mindep))
        End Select
      Case 31 To 50 ' healing/mana potions
        r2 = Int(Rnd * 100) + 1
        Select Case r2
          Case 1 To 50
            Call Me.MakeItem(1, 1, "Healing Potion", Int(Rnd * (dep - mindep + 1) + mindep))
          Case 51 To 100
            Call Me.MakeItem(1, 1, "Mana Potion", Int(Rnd * (dep - mindep + 1) + mindep))
        End Select
      Case 51 To 80 ' spell scrolls
        r2 = (Rnd * 13)
            Call Me.MakeItem(1, r2, "Scroll", M_MMIS)
            Call Me.MakeItem(1, r2, "Scroll", M_HEAL)
            Call Me.MakeItem(1, r2, "Scroll", M_TELE)
            Call Me.MakeItem(1, r2, "Scroll", M_STUN)
            Call Me.MakeItem(1, r2, "Scroll", M_TOWN)
            Call Me.MakeItem(1, r2, "Scroll", M_FAST)
            Call Me.MakeItem(1, r2, "Scroll", M_SLOW)
            Call Me.MakeItem(1, r2, "Scroll", M_BLES)
            Call Me.MakeItem(1, r2, "Scroll", M_FIRE)
            Call Me.MakeItem(1, r2, "Scroll", M_COLD)
            Call Me.MakeItem(1, r2, "Scroll", M_ELEC)
            Call Me.MakeItem(1, r2, "Scroll", M_PROT)
            Call Me.MakeItem(1, r2, "Scroll", M_FLEE)
      Case 81 To 100 ' one-use items
        r2 = (Rnd * 8)
            Call Me.MakeItem(1, r2, "Dispipe", Int(Rnd * (dep - mindep + 1) + mindep))
            Call Me.MakeItem(1, r2, "Sapipe", Int(Rnd * (dep - mindep + 1) + mindep))
            Call Me.MakeItem(1, r2, "Penepipe", Int(Rnd * (dep - mindep + 1) + mindep))
            Call Me.MakeItem(1, r2, "Targepipe", Int(Rnd * (dep - mindep + 1) + mindep))
            Call Me.MakeItem(1, r2, "Escapipe", Int(Rnd * (dep - mindep + 1) + mindep))
            Call Me.MakeItem(1, r2, "Telepipe", Int(Rnd * (dep - mindep + 1) + mindep))
            Call Me.MakeItem(1, r2, "Townpipe", Int(Rnd * (dep - mindep + 1) + mindep))
            Call Me.MakeItem(1, r2, "Invisipipe", Int(Rnd * (dep - mindep + 1) + mindep))
    End Select
  ElseIf tomake = S_INN Then
    Call Me.MakeItem(1, 1, "Room for the Night", dep)
  ElseIf tomake = S_MRK Then
    r = 0
    For i = 0 To G_MAX - 1
      r = r + 2 - World.World(mchance).LCity.Stores(S_MRK).TGP(i)
    Next i
    r2 = (Rnd * r)
    Call Me.MakeItem(2 - World.World(mchance).LCity.Stores(S_MRK).TGP(G_WOOD), r2, "Wood", Int(Rnd * (dep - mindep + 1) + mindep), , , , , , True)
    Call Me.MakeItem(2 - World.World(mchance).LCity.Stores(S_MRK).TGP(G_FOOD), r2, "Food", Int(Rnd * (dep - mindep + 1) + mindep), , , , , , True)
    Call Me.MakeItem(2 - World.World(mchance).LCity.Stores(S_MRK).TGP(G_ORES), r2, "Metal Ore", Int(Rnd * (dep - mindep + 1) + mindep), , , , , , True)
    Call Me.MakeItem(2 - World.World(mchance).LCity.Stores(S_MRK).TGP(G_GEMS), r2, "Gemstones", Int(Rnd * (dep - mindep + 1) + mindep), , , , , , True)
    Call Me.MakeItem(2 - World.World(mchance).LCity.Stores(S_MRK).TGP(G_ARTS), r2, "Artifacts", Int(Rnd * (dep - mindep + 1) + mindep), , , , , , True)
    Call Me.MakeItem(2 - World.World(mchance).LCity.Stores(S_MRK).TGP(G_WEPS), r2, "Weapons", Int(Rnd * (dep - mindep + 1) + mindep), , , , , , True)
    Call Me.MakeItem(2 - World.World(mchance).LCity.Stores(S_MRK).TGP(G_MEDS), r2, "Medicine", Int(Rnd * (dep - mindep + 1) + mindep), , , , , , True)
    

  ElseIf tomake = S_ACAD Then
    Call Me.MakeItem(1, 1, "Knowledge", Int(Rnd * T_MAX + 1) Mod T_MAXUSED, Int(Rnd * 21))
  ElseIf tomake = S_TEMP Then
    r = (Rnd * 6)
        Call Me.MakeItem(1, r, "Weapon Blessing", , , , , , 0)
        Call Me.MakeItem(1, r, "Armor Blessing", , , , , , 0)
        Call Me.MakeItem(1, r, "Shield Blessing", , , , , , 0)
        Call Me.MakeItem(1, r, "Gauntlet Blessing", , , , , , 0)
        Call Me.MakeItem(1, r, "Boot Blessing", , , , , , 0)
        Call Me.MakeItem(1, r, "Helm Blessing", , , , , , 0)
  ElseIf tomake = S_CARN Then
    Call Me.MakeItem(1, 1, "Carnival Game", Int(Rnd * 6))
  End If
  
'  If (Me.Value < C_VALUEPERLEVEL * (mindep) Or Me.Value > C_VALUEPERLEVEL * (Me.Depth + 1)) And bypass = 0 Then
  If (Me.Depth < mindep Or Me.Depth > dep) And Me.Bypass = 0 Then
'    Dim ans As VbMsgBoxResult
'    ans = vbOK
    
'    ErrorCounter = ErrorCounter + 1
'    If ErrorCounter Mod 15 = 14 Then
'      ans = MsgBox("ERROR: " & vbTab & ErrorCounter & vbCrLf & "Range:" & vbTab & mindep & " - " & dep & vbCrLf & "Type:" & vbTab & T & vbCrLf & "D Gen'd:" & vbTab & Me.Depth, vbOKCancel)
'    End If
'    If ans = vbOK Then
      counter = counter + 1
      If counter > 199 And counter Mod 200 = 0 Then
        Call MsgBox("Possible item creation error" & vbCrLf & "Tries: " & counter & vbCrLf & "Type: " & tomake & vbCrLf & "Depth: " & mindep & "-" & dep)
      End If
      GoTo AGAIN
'    Else
'      ans = vbCancel
'    End If
  End If
  
End Sub

Public Sub CreateArtifact(maketype As Integer, Depth As Integer)
  If maketype = E_WEP Then
    Select Case Depth
      Case 0
        Call Me.MakeItem(1, 1, "Sting")
      Case 1
        Call Me.MakeItem(1, 1, "Thermal")
      Case 2
        Call Me.MakeItem(1, 1, "Whisper")
      Case 3
        Call Me.MakeItem(1, 1, "Bloodener")
      Case 4
        Call Me.MakeItem(1, 1, "Frostbite")
      Case 5
        Call Me.MakeItem(1, 1, "Mammoth Blade")
      Case 6
        Call Me.MakeItem(1, 1, "Grindel's Torch")
      Case 7
        Call Me.MakeItem(1, 1, "Hammerhand")
      Case 8
        Call Me.MakeItem(1, 1, "Enticer")
      Case 9
        Call Me.MakeItem(1, 1, "Razor Edge")
      Case 10
        Call Me.MakeItem(1, 1, "Heart Seeker")
      Case 11
        Call Me.MakeItem(1, 1, "Nature's Voice")
      Case 12
        Call Me.MakeItem(1, 1, "Swiftstrike")
      Case 13
        Call Me.MakeItem(1, 1, "Runesword")
      Case 14
        Call Me.MakeItem(1, 1, "Mindless Abandon")
      Case 15
        Call Me.MakeItem(1, 1, "Snickersnee")
      Case 16
        Call Me.MakeItem(1, 1, "Dracoclaw")
      Case 17
        Call Me.MakeItem(1, 1, "The Integer Goodnight")
      Case 18
        Call Me.MakeItem(1, 1, "Lord Protector")
      Case 19
        Call Me.MakeItem(1, 1, "Magisword")
      Case 20
        Call Me.MakeItem(1, 1, "Hellfire")
      Case 21
        Call Me.MakeItem(1, 1, "Eternal Dawn")
    End Select
  ElseIf maketype = E_ARM Then
    Select Case Depth
      Case 0
        Call Me.MakeItem(1, 1, "Lintel's Leather")
      Case 1
        Call Me.MakeItem(1, 1, "Heartguard")
      Case 2
        Call Me.MakeItem(1, 1, "Artful Dodger")
      Case 3
        Call Me.MakeItem(1, 1, "Night's Cloak")
      Case 4
        Call Me.MakeItem(1, 1, "Wyvernskin")
      Case 5
        Call Me.MakeItem(1, 1, "Chain of Wrath")
      Case 6
        Call Me.MakeItem(1, 1, "Redemption")
      Case 7
        Call Me.MakeItem(1, 1, "Counterstrike")
      Case 8
        Call Me.MakeItem(1, 1, "Mage Plate")
      Case 9
        Call Me.MakeItem(1, 1, "Treebark")
      Case 10
        Call Me.MakeItem(1, 1, "Hidden Dragon")
      Case 11
        Call Me.MakeItem(1, 1, "Light Gatherer")
      Case 12
        Call Me.MakeItem(1, 1, "Princely Garments")
      Case 13
        Call Me.MakeItem(1, 1, "Giant Breastplate")
      Case 14
        Call Me.MakeItem(1, 1, "Iceplate")
      Case 15
        Call Me.MakeItem(1, 1, "Fire Warden")
      Case 16
        Call Me.MakeItem(1, 1, "Silksheath")
      Case 17
        Call Me.MakeItem(1, 1, "Shell of Carmuth")
      Case 18
        Call Me.MakeItem(1, 1, "The Quickening")
      Case 19
        Call Me.MakeItem(1, 1, "Diamondine Swath")
      Case 20
        Call Me.MakeItem(1, 1, "Dragonscale")
      Case 21
        Call Me.MakeItem(1, 1, "Archangel's Garb")
    End Select
  ElseIf maketype = E_BTS Then
    Select Case Depth
      Case 0
        Call Me.MakeItem(1, 1, "Walking Shoes")
      Case 1
        Call Me.MakeItem(1, 1, "Hoppers")
      Case 2
        Call Me.MakeItem(1, 1, "Glass Slippers")
      Case 3
        Call Me.MakeItem(1, 1, "Corwen's Footwear")
      Case 4
        Call Me.MakeItem(1, 1, "Griffonhide Boots")
      Case 5
        Call Me.MakeItem(1, 1, "Bladed Boots")
      Case 6
        Call Me.MakeItem(1, 1, "Shimmering Shoes")
      Case 7
        Call Me.MakeItem(1, 1, "Boots of Peace")
      Case 8
        Call Me.MakeItem(1, 1, "Fire Walkers")
      Case 9
        Call Me.MakeItem(1, 1, "Shadow Dancers")
      Case 10
        Call Me.MakeItem(1, 1, "Jeweled Greaves")
      Case 11
        Call Me.MakeItem(1, 1, "Blade Dancers")
      Case 12
        Call Me.MakeItem(1, 1, "Bloodstriders")
      Case 13
        Call Me.MakeItem(1, 1, "Insulators")
      Case 14
        Call Me.MakeItem(1, 1, "Stone Shoes")
      Case 15
        Call Me.MakeItem(1, 1, "Relentless Pursuits")
      Case 16
        Call Me.MakeItem(1, 1, "Boots of Jumping and Leaping")
      Case 17
        Call Me.MakeItem(1, 1, "Suresteps")
      Case 18
        Call Me.MakeItem(1, 1, "Lightfoots")
      Case 19
        Call Me.MakeItem(1, 1, "Mercurian Greaves")
      Case 20
        Call Me.MakeItem(1, 1, "Brimstones")
      Case 21
        Call Me.MakeItem(1, 1, "Dusty Sandals")
    End Select
  ElseIf maketype = E_GNT Then
    Select Case Depth
      Case 0
        Call Me.MakeItem(1, 1, "Nimble Fingers")
      Case 1
        Call Me.MakeItem(1, 1, "Mitts of Lysender")
      Case 2
        Call Me.MakeItem(1, 1, "Cat's Claws")
      Case 3
        Call Me.MakeItem(1, 1, "Electric Hands")
      Case 4
        Call Me.MakeItem(1, 1, "Detachers")
      Case 5
        Call Me.MakeItem(1, 1, "Sloweners")
      Case 6
        Call Me.MakeItem(1, 1, "Four-Fingered Freaks")
      Case 7
        Call Me.MakeItem(1, 1, "Greenthumbs")
      Case 8
        Call Me.MakeItem(1, 1, "Icy Hands of Death")
      Case 9
        Call Me.MakeItem(1, 1, "Dweomer Grips")
      Case 10
        Call Me.MakeItem(1, 1, "Gauntlets of Ogre Power")
      Case 11
        Call Me.MakeItem(1, 1, "Dark Gifts")
      Case 12
        Call Me.MakeItem(1, 1, "Tildin's Defense")
      Case 13
        Call Me.MakeItem(1, 1, "Dartcatchers")
      Case 14
        Call Me.MakeItem(1, 1, "Bonecrushers")
      Case 15
        Call Me.MakeItem(1, 1, "Eye Gougers")
      Case 16
        Call Me.MakeItem(1, 1, "Flameholders")
      Case 17
        Call Me.MakeItem(1, 1, "Magefists")
      Case 18
        Call Me.MakeItem(1, 1, "Blood Siphons")
      Case 19
        Call Me.MakeItem(1, 1, "Crystal Claws")
      Case 20
        Call Me.MakeItem(1, 1, "Soulstealers")
      Case 21
        Call Me.MakeItem(1, 1, "Hands of God")
    End Select
  ElseIf maketype = E_HLM Then
    Select Case Depth
      Case 0
        Call Me.MakeItem(1, 1, "Skull Cap")
      Case 1
        Call Me.MakeItem(1, 1, "Crescent Gear")
      Case 2
        Call Me.MakeItem(1, 1, "Wolfscalp")
      Case 3
        Call Me.MakeItem(1, 1, "Lighting Rod")
      Case 4
        Call Me.MakeItem(1, 1, "Velvet Hood")
      Case 5
        Call Me.MakeItem(1, 1, "Sunshade")
      Case 6
        Call Me.MakeItem(1, 1, "Truesight")
      Case 7
        Call Me.MakeItem(1, 1, "Helm of Brilliance")
      Case 8
        Call Me.MakeItem(1, 1, "The Awakener")
      Case 9
        Call Me.MakeItem(1, 1, "Lunar Eclipse")
      Case 10
        Call Me.MakeItem(1, 1, "Plumed Hat")
      Case 11
        Call Me.MakeItem(1, 1, "Winged Helm")
      Case 12
        Call Me.MakeItem(1, 1, "Hothead")
      Case 13
        Call Me.MakeItem(1, 1, "Oakenhelm")
      Case 14
        Call Me.MakeItem(1, 1, "Platinum Ruby Veil")
      Case 15
        Call Me.MakeItem(1, 1, "Plain Circlet")
      Case 16
        Call Me.MakeItem(1, 1, "Pentil's Gear")
      Case 17
        Call Me.MakeItem(1, 1, "Wizard's Cone")
      Case 18
        Call Me.MakeItem(1, 1, "Crown of Radiance")
      Case 19
        Call Me.MakeItem(1, 1, "Dragon Ribbon")
      Case 20
        Call Me.MakeItem(1, 1, "Fearsome Visage")
      Case 21
        Call Me.MakeItem(1, 1, "Angelic Halo")
    End Select
  ElseIf maketype = E_SLD Then
    Select Case Depth
      Case 0
        Call Me.MakeItem(1, 1, "Skinguard")
      Case 1
        Call Me.MakeItem(1, 1, "Killian's Blanket")
      Case 2
        Call Me.MakeItem(1, 1, "Ironarm")
      Case 3
        Call Me.MakeItem(1, 1, "Reflector")
      Case 4
        Call Me.MakeItem(1, 1, "Lodestone Shield")
      Case 5
        Call Me.MakeItem(1, 1, "Ignitor")
      Case 6
        Call Me.MakeItem(1, 1, "Spiked Basher")
      Case 7
        Call Me.MakeItem(1, 1, "Hornarm")
      Case 8
        Call Me.MakeItem(1, 1, "Friend in Need")
      Case 9
        Call Me.MakeItem(1, 1, "Shield of Faith")
      Case 10
        Call Me.MakeItem(1, 1, "Twinshield")
      Case 11
        Call Me.MakeItem(1, 1, "Ice Mirror")
      Case 12
        Call Me.MakeItem(1, 1, "Hope of Corgan")
      Case 13
        Call Me.MakeItem(1, 1, "Foe's Lament")
      Case 14
        Call Me.MakeItem(1, 1, "Mithril Salute")
      Case 15
        Call Me.MakeItem(1, 1, "Bladeblocker")
      Case 16
        Call Me.MakeItem(1, 1, "Starfield")
      Case 17
        Call Me.MakeItem(1, 1, "Fierce Defender")
      Case 18
        Call Me.MakeItem(1, 1, "Sword Router")
      Case 19
        Call Me.MakeItem(1, 1, "Shield of the Rising Phoenix")
      Case 20
        Call Me.MakeItem(1, 1, "Darkrock")
      Case 21
        Call Me.MakeItem(1, 1, "Wings of the Seraphim")
    End Select
  Else
    Call Me.MakeItem(1, 1, "Sting")
  End If
End Sub

Public Sub CreateWand()
  Dim r As Integer
  r = Int(Rnd * 100)
  Select Case r
    Case 0 To 49
      Call Me.MakeItem(1, 1, "Wand of Portals")
    Case 50 To 99
      Call Me.MakeItem(1, 1, "Wand of Terrain")
  End Select
    
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
  DMS = 0
  
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

  Hits = 0
  SkillBonus = 0

End Sub
