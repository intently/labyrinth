Option Strict Off
Option Explicit On
Friend Class City
	Public Name As String
	Public Size As Short
	Public Pop As Integer
	Public Owner As Short
	'UPGRADE_NOTE: Loc was upgraded to Loc_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Public Loc_Renamed As Short
	Public T As String
	Public Desc As String
	Public Conts As Double
	Public Depth As Short
	Public Button As String
	Public LastExplored As Date
	Private CastleStuff(5) As Short
	'UPGRADE_WARNING: Arrays can't be declared with New. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC9D3AE5-6B95-4B43-91C7-28276302A5E8"'
	Private LocalStores(5) As New Store
	
	'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub Class_Initialize_Renamed()
		Dim i As Short
		
		Size = -1
		T = "None"
		Name = "None"
		
	End Sub
	Public Sub New()
		MyBase.New()
		Class_Initialize_Renamed()
	End Sub
	
	Public Sub MakeCity(ByRef l As Short, Optional ByRef makesize As Object = -1)
		Dim i As Short
		If l = 0 Then
			Size = 3
			Name = "Centris"
			Pop = 95000 + Int(Rnd() * 100) * 100
			Desc = "The great city of " & Name & " is located at the center of the Labyrinth.  Its guards patrol the nearby roads and keep the monsters at bay.  It is stable and safe.  And boring."
		Else
			'UPGRADE_WARNING: Couldn't resolve default property of object makesize. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If makesize = -1 Then
				Size = Int(Rnd() * 3) - Int(Rnd() * 2)
			Else
				'UPGRADE_WARNING: Couldn't resolve default property of object makesize. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Size = makesize
			End If
			If Size < 0 Then Size = 0
			
			If Size = 0 Then Pop = 1000 + Int(Rnd() * 40) * 100
			If Size = 1 Then Pop = 5000 + Int(Rnd() * 40) * 250
			If Size = 2 Then Pop = 15000 + Int(Rnd() * 40) * 250
			Name = CityName(Size)
			Desc = CityDesc(Size)
			
		End If
		
		Owner = -1
		T = "City"
		Loc_Renamed = l
		'UPGRADE_WARNING: Couldn't resolve default property of object World.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Depth = World.World(l).Depth
		Button = "Enter City"
		
		For i = 0 To C_STORES - 1
			If Int(Rnd() * 3) <= Size Or i = S_INN Or i = S_MRK Then
				'      Set Stores(i) = New Store
				Stores(i).T = i
				Stores(i).Loc_Renamed = Loc_Renamed
				Stores(i).Depth = Depth
				Stores(i).Stock()
				Stores(i).TGPSet()
			Else
				Stores(i).T = -1
			End If
		Next i
		
	End Sub
	Public Sub MakeCastle(ByRef l As Short)
		T = "Castle"
		Name = InputBox("What do you want to name your new castle?", "Name Your Castle")
		
		If Name = "" Then
			Name = "Unnamed"
		End If
		
		'UPGRADE_WARNING: Couldn't resolve default property of object World.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Depth = World.World(l).Depth
		Loc_Renamed = l
		Desc = "You have built a castle here.  It is currently little more than a foundation."
		Conts = 0
		Pop = 0
		Button = "Castle"
		
		Stores(0).T = S_CAST
		Stores(0).Loc_Renamed = Loc_Renamed
		Stores(0).Depth = Depth
		Stores(0).Stock()
	End Sub
	
	Public Sub MakeHauntedHouse(ByRef l As Short)
		T = "Haunted House"
		Name = ""
		'UPGRADE_WARNING: Couldn't resolve default property of object World.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Depth = World.World(l).Depth
		Loc_Renamed = l
		Desc = "Spooky creaks and howls emanate from the ruined (and obviously haunted) edifice before you."
		Conts = 0
		Button = "Haunted House"
	End Sub
	Public Sub MakeTransmuter(ByRef l As Short)
		T = "Mystic Sage"
		Name = ""
		'UPGRADE_WARNING: Couldn't resolve default property of object World.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Depth = World.World(l).Depth
		Loc_Renamed = l
		Desc = "A tiny hut stands (barely) before you, with a thin whisp of smoke rising above.  A wily old sage lives within, and is willing to serve you, for a price."
		Conts = 0
		Button = "Mystic Sage"
		
		Stores(0).T = S_TRAN
		Stores(0).Loc_Renamed = Loc_Renamed
		Stores(0).Depth = Depth
		Stores(0).Stock()
	End Sub
	Public Sub MakeCarnival(ByRef l As Short)
		T = "Carnival"
		Name = ""
		'UPGRADE_WARNING: Couldn't resolve default property of object World.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Depth = World.World(l).Depth
		Loc_Renamed = l
		Desc = "A small circus is laid out before you, with games and performers, and even some scary wild animals."
		Conts = 0
		Button = "Carnival"
		
		Stores(0).T = S_CARN
		Stores(0).Loc_Renamed = Loc_Renamed
		Stores(0).Depth = Depth
		Stores(0).Stock()
	End Sub
	Public Sub MakeAcademy(ByRef l As Short)
		T = "Academy"
		Name = ""
		'UPGRADE_WARNING: Couldn't resolve default property of object World.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Depth = World.World(l).Depth
		Loc_Renamed = l
		Desc = "This academy is a bastion of learning amidst the chaos that surrounds it.  Perhaps even you could learn something of value here."
		Conts = 0
		Button = "Academy"
		
		Stores(0).T = S_ACAD
		Stores(0).Loc_Renamed = Loc_Renamed
		Stores(0).Depth = Depth
		Stores(0).Stock()
	End Sub
	Public Sub MakeTemple(ByRef l As Short)
		T = "Temple"
		Name = ""
		'UPGRADE_WARNING: Couldn't resolve default property of object World.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Depth = World.World(l).Depth
		Loc_Renamed = l
		Desc = "Mighty marble columns stand watch over this temple.  The beautiful statues and fountains are in strong contrast to the surrounding wilderness, and the attending priests seem wise, and able to help you in many matters."
		Conts = 0
		Button = "Temple"
		
		Stores(0).T = S_TEMP
		Stores(0).Loc_Renamed = Loc_Renamed
		Stores(0).Depth = Depth
		Stores(0).Stock()
	End Sub
	
	Public Sub MakeGoblinMine(ByRef l As Short)
		T = "Goblin Mine"
		Name = ""
		'UPGRADE_WARNING: Couldn't resolve default property of object World.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Depth = World.World(l).Depth
		Loc_Renamed = l
		Desc = "An open mine shaft drops down into the dark earth.  Far below, the sound of metal on metal can be heard incessantly ringing."
		Conts = 0
		Button = "Goblin Mine"
	End Sub
	
	Public Sub MakeSlums(ByRef l As Short)
		T = "Slums"
		Name = ""
		'UPGRADE_WARNING: Couldn't resolve default property of object World.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Depth = World.World(l).Depth
		Loc_Renamed = l
		Desc = "These slums seeth with hidden villainy... and with opportunity for the adventurous."
		Button = "Explore Slums"
	End Sub
	
	Public Sub MakeCrossroad(ByRef i As Short)
		T = "Crossroad"
		Name = ""
		'UPGRADE_WARNING: Couldn't resolve default property of object World.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Depth = World.World(i).Depth
		Loc_Renamed = i
		Desc = "Where many roads converge there too do their travelers.  Many people of all sorts pass on their ways, and a few low buildings beckon to travelers who seek comfort and rest."
		
		Button = "Crossroad"
		
		Stores(S_INN).T = S_INN
		Stores(S_INN).Loc_Renamed = i
		Stores(S_INN).Depth = Depth
		Stores(S_INN).Stock()
		
	End Sub
	
	Public Sub MakeFairyPond(ByRef i As Short)
		T = "Fairy Pond"
		Name = ""
		'UPGRADE_WARNING: Couldn't resolve default property of object World.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Depth = World.World(i).Depth
		Loc_Renamed = i
		Desc = "There is an unnaturally pristine pond here.  In contrast to the wild surrounding terrain, the pond looks well-ordered and peaceful."
		Conts = Int(Rnd() * 31) + 1
		Button = "Fairy Pond"
	End Sub
	
	Public Sub MakeRuins(ByRef i As Short)
		T = "Ancient Ruins"
		Name = ""
		'UPGRADE_WARNING: Couldn't resolve default property of object World.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Depth = World.World(i).Depth
		Loc_Renamed = i
		Desc = "A ruined castle stands before you, it's ancient halls and towers beckoning to be explored."
		Conts = 100
		Button = "Explore"
	End Sub
	
	Public Sub MakeGraveyard(ByRef i As Short)
		T = "Monster Graveyard"
		Name = ""
		'UPGRADE_WARNING: Couldn't resolve default property of object World.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Depth = World.World(i).Depth
		Loc_Renamed = i
		Desc = "You are surrounded by the bones and corpses of an untold number of vanquished beasts.  It's a disgusting scene, but you may find something useful."
		Conts = 100
		Button = "Explore"
	End Sub
	
	
	Public Property Stores(ByVal i As Short) As Store
		Get
			Stores = LocalStores(i)
		End Get
		Set(ByVal Value As Store)
			LocalStores(i) = Value
		End Set
	End Property
	
	
	Public Property Castle(ByVal i As Short) As Short
		Get
			Castle = CastleStuff(i)
		End Get
		Set(ByVal Value As Short)
			CastleStuff(i) = Value
		End Set
	End Property
End Class