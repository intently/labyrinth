VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "City"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Option Explicit
Public Name As String
Public Size As Integer
Public Pop As Long
Public Owner As Integer
Public Loc As Integer
Public T As String
Public Desc As String
Public Conts As Double
Public Depth As Integer
Public Button As String
Public LastExplored As Date
Private CastleStuff(0 To 5) As Integer
Private LocalStores(0 To 5) As New Store

Private Sub Class_Initialize()
  Dim i As Integer
    
  Size = -1
  T = "None"
  Name = "None"
  
End Sub

Public Sub MakeCity(l As Integer, Optional makesize = -1)
  Dim i As Integer
  If l = 0 Then
    Size = 3
    Name = "Centris"
    Pop = 95000 + Int(Rnd * 100) * 100
    Desc = "The great city of " & Name & " is located at the center of the Labyrinth.  Its guards patrol the nearby roads and keep the monsters at bay.  It is stable and safe.  And boring."
  Else
    If makesize = -1 Then
      Size = Int(Rnd * 3) - Int(Rnd * 2)
    Else
      Size = makesize
    End If
    If Size < 0 Then Size = 0
    
    If Size = 0 Then Pop = 1000 + Int(Rnd * 40) * 100
    If Size = 1 Then Pop = 5000 + Int(Rnd * 40) * 250
    If Size = 2 Then Pop = 15000 + Int(Rnd * 40) * 250
    Name = CityName(Size)
    Desc = CityDesc(Size)
  
  End If

  Owner = -1
  T = "City"
  Loc = l
  Depth = World.World(l).Depth
  Button = "Enter City"
  
  For i = 0 To C_STORES - 1
    If Int(Rnd * 3) <= Size Or i = S_INN Or i = S_MRK Then
'      Set Stores(i) = New Store
      Stores(i).T = i
      Stores(i).Loc = Loc
      Stores(i).Depth = Depth
      Stores(i).Stock
      Stores(i).TGPSet
    Else
      Stores(i).T = -1
    End If
  Next i
  
End Sub
Public Sub MakeCastle(l As Integer)
  T = "Castle"
  Name = InputBox("What do you want to name your new castle?", "Name Your Castle")
  
  If Name = "" Then
    Name = "Unnamed"
  End If
  
  Depth = World.World(l).Depth
  Loc = l
  Desc = "You have built a castle here.  It is currently little more than a foundation."
  Conts = 0
  Pop = 0
  Button = "Castle"
  
  Stores(0).T = S_CAST
  Stores(0).Loc = Loc
  Stores(0).Depth = Depth
  Stores(0).Stock
End Sub

Public Sub MakeHauntedHouse(l As Integer)
  T = "Haunted House"
  Name = ""
  Depth = World.World(l).Depth
  Loc = l
  Desc = "Spooky creaks and howls emanate from the ruined (and obviously haunted) edifice before you."
  Conts = 0
  Button = "Haunted House"
End Sub
Public Sub MakeTransmuter(l As Integer)
  T = "Mystic Sage"
  Name = ""
  Depth = World.World(l).Depth
  Loc = l
  Desc = "A tiny hut stands (barely) before you, with a thin whisp of smoke rising above.  A wily old sage lives within, and is willing to serve you, for a price."
  Conts = 0
  Button = "Mystic Sage"
  
  Stores(0).T = S_TRAN
  Stores(0).Loc = Loc
  Stores(0).Depth = Depth
  Stores(0).Stock
End Sub
Public Sub MakeCarnival(l As Integer)
  T = "Carnival"
  Name = ""
  Depth = World.World(l).Depth
  Loc = l
  Desc = "A small circus is laid out before you, with games and performers, and even some scary wild animals."
  Conts = 0
  Button = "Carnival"
  
  Stores(0).T = S_CARN
  Stores(0).Loc = Loc
  Stores(0).Depth = Depth
  Stores(0).Stock
End Sub
Public Sub MakeAcademy(l As Integer)
  T = "Academy"
  Name = ""
  Depth = World.World(l).Depth
  Loc = l
  Desc = "This academy is a bastion of learning amidst the chaos that surrounds it.  Perhaps even you could learn something of value here."
  Conts = 0
  Button = "Academy"
  
  Stores(0).T = S_ACAD
  Stores(0).Loc = Loc
  Stores(0).Depth = Depth
  Stores(0).Stock
End Sub
Public Sub MakeTemple(l As Integer)
  T = "Temple"
  Name = ""
  Depth = World.World(l).Depth
  Loc = l
  Desc = "Mighty marble columns stand watch over this temple.  The beautiful statues and fountains are in strong contrast to the surrounding wilderness, and the attending priests seem wise, and able to help you in many matters."
  Conts = 0
  Button = "Temple"
  
  Stores(0).T = S_TEMP
  Stores(0).Loc = Loc
  Stores(0).Depth = Depth
  Stores(0).Stock
End Sub

Public Sub MakeGoblinMine(l As Integer)
  T = "Goblin Mine"
  Name = ""
  Depth = World.World(l).Depth
  Loc = l
  Desc = "An open mine shaft drops down into the dark earth.  Far below, the sound of metal on metal can be heard incessantly ringing."
  Conts = 0
  Button = "Goblin Mine"
End Sub

Public Sub MakeSlums(l As Integer)
  T = "Slums"
  Name = ""
  Depth = World.World(l).Depth
  Loc = l
  Desc = "These slums seeth with hidden villainy... and with opportunity for the adventurous."
  Button = "Explore Slums"
End Sub

Public Sub MakeCrossroad(i As Integer)
  T = "Crossroad"
  Name = ""
  Depth = World.World(i).Depth
  Loc = i
  Desc = "Where many roads converge there too do their travelers.  Many people of all sorts pass on their ways, and a few low buildings beckon to travelers who seek comfort and rest."
  
  Button = "Crossroad"
  
  Stores(S_INN).T = S_INN
  Stores(S_INN).Loc = i
  Stores(S_INN).Depth = Depth
  Stores(S_INN).Stock

End Sub

Public Sub MakeFairyPond(i As Integer)
  T = "Fairy Pond"
  Name = ""
  Depth = World.World(i).Depth
  Loc = i
  Desc = "There is an unnaturally pristine pond here.  In contrast to the wild surrounding terrain, the pond looks well-ordered and peaceful."
  Conts = Int(Rnd * 31) + 1
  Button = "Fairy Pond"
End Sub

Public Sub MakeRuins(i As Integer)
  T = "Ancient Ruins"
  Name = ""
  Depth = World.World(i).Depth
  Loc = i
  Desc = "A ruined castle stands before you, it's ancient halls and towers beckoning to be explored."
  Conts = 100
  Button = "Explore"
End Sub

Public Sub MakeGraveyard(i As Integer)
  T = "Monster Graveyard"
  Name = ""
  Depth = World.World(i).Depth
  Loc = i
  Desc = "You are surrounded by the bones and corpses of an untold number of vanquished beasts.  It's a disgusting scene, but you may find something useful."
  Conts = 100
  Button = "Explore"
End Sub

Public Property Let Stores(i As Integer, v As Store)
  Set LocalStores(i) = v
End Property

Public Property Get Stores(i As Integer) As Store
  Set Stores = LocalStores(i)
End Property

Public Property Let Castle(i As Integer, v As Integer)
  CastleStuff(i) = v
End Property

Public Property Get Castle(i As Integer) As Integer
  Castle = CastleStuff(i)
End Property

