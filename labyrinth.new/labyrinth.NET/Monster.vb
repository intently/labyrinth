Option Strict Off
Option Explicit On
Friend Class Monster
	Private Derived(10) As Short
	Public Points As Short
	Public Name As String
	Public Treasure As Short
	Public Depth As Short
	Public Terrain As Short
	
	Private AttPers(C_MAXATTACKS - 1) As Short
	Private Attacks(C_MAXATTACKS - 1) As String
	Public Flags As Integer
	Private Counters(C_COUNTERS - 1) As Short
	Private Resistances(C_RESISTS - 1) As Short
	
	'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Public Sub Class_Initialize_Renamed()
		Name = "None"
		Depth = 0
		Dervs(D_SAT) = 0
		Dervs(D_DAT) = 0
		Dervs(D_DEF) = 0
		Dervs(D_HTP) = 0
		Dervs(D_SPD) = 0
		Dervs(D_DAM) = 0
		Dervs(D_DR) = 0
		Dervs(D_DMS) = 0
		Terrain = 0
		AttP(0) = 100
		Atts(0) = "None"
	End Sub
	Public Sub New()
		MyBase.New()
		Class_Initialize_Renamed()
	End Sub
	
	Public Sub MakeMonster(ByRef s As String, Optional ByRef A As Short = 0, Optional ByRef b As Short = 0)
		
		If s = "Sand Scorpion" Then
			Name = s
			Depth = 0
			Dervs(D_SAT) = Spread(100, 10)
			Dervs(D_DEF) = Spread(100, 10)
			Dervs(D_SPD) = Spread(110, 10)
			Dervs(D_HTP) = Spread(90, 10)
			Dervs(D_DAM) = Spread(100, 10)
			Dervs(D_DR) = Spread(110, 10)
			Terrain = T_DES
			AttP(0) = 80
			Atts(0) = "Bite"
			AttP(1) = 20
			Atts(1) = "Poison Sting"
			Res(R_FIRE) = 50
		ElseIf s = "Dune Dweller" Then 
			Depth = 1
			Name = s
			Dervs(D_SAT) = Spread(90, 10)
			Dervs(D_DEF) = Spread(85, 10)
			Dervs(D_HTP) = Spread(85, 15)
			Dervs(D_SPD) = Spread(120, 10)
			Dervs(D_DAM) = Spread(133, 15)
			Dervs(D_DR) = Spread(115, 10)
			Terrain = T_DES
			AttP(0) = 80
			Atts(0) = "Normal"
			AttP(1) = 20
			Atts(1) = "Throw Sand"
			Res(R_FIRE) = 50
		ElseIf s = "Sand Shark" Then 
			Depth = 2
			Name = s
			Dervs(D_SAT) = Spread(95, 10)
			Dervs(D_DEF) = Spread(110, 10)
			Dervs(D_HTP) = Spread(95, 10)
			Dervs(D_SPD) = Spread(200, 10)
			Dervs(D_DAM) = Spread(110, 10)
			Dervs(D_DR) = Spread(110, 10)
			Terrain = T_DES
			AttP(0) = 70
			Atts(0) = "Leap"
			AttP(1) = 30
			Atts(1) = "Throw Sand"
			Res(R_FIRE) = 50
		ElseIf s = "Lesser Basilisk" Then 
			Name = s
			Depth = 3
			Dervs(D_SAT) = Spread(115, 10)
			Dervs(D_DEF) = Spread(110, 10)
			Dervs(D_HTP) = Spread(120, 10)
			Dervs(D_SPD) = Spread(75, 10)
			Dervs(D_DAM) = Spread(100, 10)
			Dervs(D_DR) = Spread(115, 10)
			Terrain = T_DES
			AttP(0) = 70
			Atts(0) = "Bite"
			AttP(1) = 30
			Atts(1) = "Stone Gaze"
			Res(R_FIRE) = 50
		ElseIf s = "Water Pirate" Then 
			Name = s
			Depth = 4
			Dervs(D_SAT) = Spread(110, 10)
			Dervs(D_DEF) = Spread(90, 10)
			Dervs(D_HTP) = Spread(70, 10)
			Dervs(D_SPD) = Spread(110, 10)
			Dervs(D_DAM) = Spread(100, 10)
			Dervs(D_DR) = Spread(90, 10)
			Terrain = T_DES
			AttP(0) = 50
			Atts(0) = "Normal"
			AttP(1) = 30
			Atts(1) = "Flame Thrower"
			AttP(2) = 20
			Atts(2) = "Heal"
			Res(R_FIRE) = 50
		ElseIf s = "Bone Eater" Then 
			Name = s
			Depth = 5
			Dervs(D_SAT) = Spread(100, 10)
			Dervs(D_DAT) = Spread(100, 10)
			Dervs(D_DEF) = Spread(100, 10)
			Dervs(D_HTP) = Spread(100, 10)
			Dervs(D_SPD) = Spread(100, 10)
			Dervs(D_DAM) = Spread(100, 10)
			Dervs(D_DR) = Spread(100, 10)
			Terrain = T_DES
			AttP(0) = 90
			Atts(0) = "Normal"
			AttP(1) = 10
			Atts(1) = "Three-Quarters"
			Res(R_FIRE) = 50
		ElseIf s = "Glass Golem" Then 
			Name = s
			Depth = 6
			Dervs(D_SAT) = Spread(115, 10)
			Dervs(D_DEF) = Spread(85, 10)
			Dervs(D_HTP) = Spread(85, 10)
			Dervs(D_SPD) = Spread(110, 10)
			Dervs(D_DAM) = Spread(110, 10)
			Dervs(D_DR) = Spread(85, 10)
			Terrain = T_DES
			Flags = Flags Or F_VAMP
			AttP(0) = 85
			Atts(0) = "NinjaStr"
			AttP(1) = 15
			Atts(1) = "Shatter"
			Res(R_FIRE) = 50
		ElseIf s = "Whirling Dervish" Then 
			Name = s
			Depth = 7
			Dervs(D_SAT) = Spread(110, 10)
			Dervs(D_DEF) = Spread(90, 10)
			Dervs(D_HTP) = Spread(100, 10)
			Dervs(D_SPD) = Spread(115, 10)
			Dervs(D_DAM) = Spread(50, 0)
			Dervs(D_DR) = Spread(115, 10)
			Terrain = T_DES
			AttP(0) = 50
			Atts(0) = "Blade Tornado"
			AttP(1) = 50
			Atts(1) = "Increase Speed"
			Res(R_FIRE) = 50
		ElseIf s = "Towering Inferno" Then 
			Name = s
			Depth = 8
			Dervs(D_SAT) = Spread(115, 10)
			Dervs(D_DEF) = Spread(115, 10)
			Dervs(D_HTP) = Spread(110, 20)
			Dervs(D_SPD) = Spread(100, 10)
			Dervs(D_DAM) = Spread(110, 10)
			Dervs(D_DR) = Spread(110, 10)
			Terrain = T_DES
			AttP(0) = 100
			Atts(0) = "Flame Thrower"
			Res(R_FIRE) = 100
			Res(R_COLD) = -50
		ElseIf s = "Sun Worshipper" Then 
			Name = s
			Depth = 9
			Dervs(D_SAT) = Spread(100, 10)
			Dervs(D_DEF) = Spread(90, 10)
			Dervs(D_HTP) = Spread(90, 10)
			Dervs(D_SPD) = Spread(115, 0)
			Dervs(D_DAM) = Spread(100, 10)
			Dervs(D_DR) = Spread(95, 10)
			Terrain = T_DES
			AttP(0) = 20
			Atts(0) = "Solar Flare"
			AttP(1) = 50
			Atts(1) = "Normal"
			AttP(2) = 30
			Atts(2) = "Solar Eclipse"
			Res(R_FIRE) = 50
		ElseIf s = "Sand Golem" Then 
			Name = s
			Depth = 10
			Dervs(D_SAT) = Spread(110, 10)
			Dervs(D_DEF) = Spread(110, 10)
			Dervs(D_HTP) = Spread(85, 10)
			Dervs(D_SPD) = Spread(85, 10)
			Dervs(D_DAM) = Spread(115, 10)
			Dervs(D_DR) = Spread(110, 10)
			Terrain = T_DES
			Flags = Flags Or F_VAMP
			AttP(0) = 30
			Atts(0) = "Heal"
			AttP(1) = 20
			Atts(1) = "Sand Blaster"
			AttP(2) = 50
			Atts(2) = "Normal"
			Res(R_FIRE) = 50
			Res(R_COLD) = -50
		ElseIf s = "Desert Raider" Then 
			Name = s
			Depth = 11
			Dervs(D_SAT) = Spread(110, 10)
			Dervs(D_DEF) = Spread(105, 10)
			Dervs(D_HTP) = Spread(90, 10)
			Dervs(D_SPD) = Spread(115, 10)
			Dervs(D_DAM) = Spread(95, 10)
			Dervs(D_DR) = Spread(105, 10)
			Terrain = T_DES
			AttP(0) = 70
			Atts(0) = "Normal"
			AttP(1) = 30
			Atts(1) = "Steal"
			Res(R_FIRE) = 50
		ElseIf s = "Lesser Djinn" Then 
			Name = s
			Depth = 12
			Dervs(D_SAT) = Spread(95, 10)
			Dervs(D_DEF) = Spread(110, 10)
			Dervs(D_HTP) = Spread(80, 10)
			Dervs(D_SPD) = Spread(120, 10)
			Dervs(D_DAM) = Spread(105, 10)
			Dervs(D_DR) = Spread(95, 10)
			Terrain = T_DES
			AttP(0) = 20
			Atts(0) = "Sleep"
			AttP(1) = 20
			Atts(1) = "Three Wishes"
			AttP(2) = 60
			Atts(2) = "Normal"
			Res(R_FIRE) = 50
			Res(R_ELEC) = -50
		ElseIf s = "Sun Priest" Then 
			Name = s
			Depth = 13
			Dervs(D_SAT) = Spread(100, 10)
			Dervs(D_DEF) = Spread(95, 10)
			Dervs(D_HTP) = Spread(95, 10)
			Dervs(D_SPD) = Spread(110, 10)
			Dervs(D_DAM) = Spread(100, 10)
			Dervs(D_DR) = Spread(95, 10)
			Terrain = T_DES
			AttP(0) = 30
			Atts(0) = "Solar Flare"
			AttP(1) = 40
			Atts(1) = "Heal"
			AttP(2) = 30
			Atts(2) = "Solar Eclipse"
			Res(R_FIRE) = 50
		ElseIf s = "Greater Basilisk" Then 
			Name = s
			Depth = 14
			Dervs(D_SAT) = Spread(115, 15)
			Dervs(D_DEF) = Spread(105, 10)
			Dervs(D_HTP) = Spread(110, 10)
			Dervs(D_SPD) = Spread(85, 10)
			Dervs(D_DAM) = Spread(100, 10)
			Dervs(D_DR) = Spread(110, 10)
			Terrain = T_DES
			AttP(0) = 70
			Atts(0) = "Bite"
			AttP(1) = 30
			Atts(1) = "Stone Gaze"
			Res(R_FIRE) = 50
		ElseIf s = "Mummy" Then 
			Name = s
			Depth = 15
			Dervs(D_SAT) = Spread(90, 10)
			Dervs(D_DEF) = Spread(100, 10)
			Dervs(D_HTP) = Spread(85, 10)
			Dervs(D_SPD) = Spread(90, 10)
			Dervs(D_DAM) = Spread(105, 10)
			Dervs(D_DR) = Spread(105, 10)
			Terrain = T_DES
			AttP(0) = 20
			Atts(0) = "Half"
			AttP(1) = 20
			Atts(1) = "Stun Attack"
			AttP(2) = 60
			Atts(2) = "Normal"
			Res(R_FIRE) = -50
		ElseIf s = "Baby Blue Dragon" Then 
			Name = s
			Depth = 16
			Dervs(D_SAT) = Spread(110, 10)
			Dervs(D_DEF) = Spread(115, 10)
			Dervs(D_HTP) = Spread(90, 10)
			Dervs(D_SPD) = Spread(100, 15)
			Dervs(D_DAM) = Spread(95, 10)
			Dervs(D_DR) = Spread(95, 10)
			Terrain = T_DES
			AttP(0) = 60
			Atts(0) = "Dragon Claw"
			AttP(1) = 30
			Atts(1) = "Dragon Bite"
			AttP(2) = 10
			Atts(2) = "Blue Dragon Breath"
			Res(R_FIRE) = 75
			Res(R_MAGI) = 50
		ElseIf s = "Greater Djinn" Then 
			Name = s
			Depth = 17
			Dervs(D_SAT) = Spread(95, 10)
			Dervs(D_DEF) = Spread(105, 15)
			Dervs(D_HTP) = Spread(90, 10)
			Dervs(D_SPD) = Spread(110, 10)
			Dervs(D_DAM) = Spread(105, 10)
			Dervs(D_DR) = Spread(95, 10)
			Terrain = T_DES
			AttP(0) = 30
			Atts(0) = "Sleep"
			AttP(1) = 30
			Atts(1) = "Three Wishes"
			AttP(2) = 40
			Atts(2) = "Normal"
			Res(R_FIRE) = 50
			Res(R_ELEC) = -50
		ElseIf s = "Dust Devil" Then 
			Name = s
			Depth = 18
			Dervs(D_SAT) = Spread(110, 10)
			Dervs(D_DEF) = Spread(90, 10)
			Dervs(D_HTP) = Spread(100, 10)
			Dervs(D_SPD) = Spread(110, 10)
			Dervs(D_DAM) = Spread(110, 10)
			Dervs(D_DR) = Spread(95, 10)
			Terrain = T_DES
			AttP(0) = 20
			Atts(0) = "Hell Fury"
			AttP(1) = 20
			Atts(1) = "Quarter"
			AttP(2) = 60
			Atts(2) = "Normal"
			Res(R_FIRE) = 100
			Res(R_MAGI) = 100
			Res(R_COLD) = -50
		ElseIf s = "Blue Dragon" Then 
			Name = s
			Depth = 19
			Dervs(D_SAT) = Spread(110, 15)
			Dervs(D_DEF) = Spread(110, 15)
			Dervs(D_HTP) = Spread(95, 10)
			Dervs(D_SPD) = Spread(105, 10)
			Dervs(D_DAM) = Spread(100, 10)
			Dervs(D_DR) = Spread(100, 10)
			Terrain = T_DES
			AttP(0) = 40
			Atts(0) = "Dragon Claw"
			AttP(1) = 35
			Atts(1) = "Dragon Bite"
			AttP(2) = 15
			Atts(2) = "Blue Dragon Breath"
			AttP(3) = 10
			Atts(3) = "Heal"
			Res(R_FIRE) = 75
			Res(R_MAGI) = 75
		ElseIf s = "Desert Marauder" Then 
			Name = s
			Depth = 20
			Dervs(D_SAT) = Spread(110, 10)
			Dervs(D_DEF) = Spread(100, 10)
			Dervs(D_HTP) = Spread(100, 10)
			Dervs(D_SPD) = Spread(110, 10)
			Dervs(D_DAM) = Spread(105, 10)
			Dervs(D_DR) = Spread(95, 10)
			Terrain = T_DES
			AttP(0) = 60
			Atts(0) = "NinjaStr"
			AttP(1) = 30
			Atts(1) = "Steal"
			AttP(2) = 10
			Atts(2) = "Death"
			Res(R_FIRE) = 100
			
		ElseIf s = "Wild Boar" Then 
			Depth = 0
			Name = s
			Dervs(D_SAT) = Spread(110, 10)
			Dervs(D_DEF) = Spread(90, 10)
			Dervs(D_HTP) = Spread(100, 10)
			Dervs(D_SPD) = Spread(100, 10)
			Dervs(D_DAM) = Spread(110, 10)
			Dervs(D_DR) = Spread(100, 10)
			Terrain = T_FOR
			AttP(0) = 80
			Atts(0) = "Leap"
			AttP(1) = 20
			Atts(1) = "Charge"
		ElseIf s = "Brown Bear" Then 
			Name = s
			Depth = 1
			Dervs(D_SAT) = Spread(100, 10)
			Dervs(D_DEF) = Spread(110, 10)
			Dervs(D_HTP) = Spread(110, 10)
			Dervs(D_SPD) = Spread(100, 10)
			Dervs(D_DAM) = Spread(120, 10)
			Dervs(D_DR) = Spread(120, 10)
			Terrain = T_FOR
			AttP(0) = 60
			Atts(0) = "Normal"
			AttP(1) = 40
			Atts(1) = "Bite"
		ElseIf s = "Pixie" Then 
			Name = s
			Depth = 2
			Dervs(D_SAT) = Spread(90, 10)
			Dervs(D_DEF) = Spread(110, 10)
			Dervs(D_HTP) = Spread(85, 10)
			Dervs(D_SPD) = Spread(115, 10)
			Dervs(D_DAM) = Spread(100, 10)
			Dervs(D_DR) = Spread(120, 10)
			Terrain = T_FOR
			AttP(0) = 75
			Atts(0) = "Normal"
			AttP(1) = 25
			Atts(1) = "Magic Dust"
			Res(R_MAGI) = 50
		ElseIf s = "Shadow Wolf" Then 
			Name = s
			Depth = 3
			Dervs(D_SAT) = Spread(110, 10)
			Dervs(D_DEF) = Spread(90, 10)
			Dervs(D_HTP) = Spread(95, 10)
			Dervs(D_SPD) = Spread(110, 10)
			Dervs(D_DAM) = Spread(100, 10)
			Dervs(D_DR) = Spread(100, 10)
			Terrain = T_FOR
			AttP(0) = 30
			Atts(0) = "Leap"
			AttP(1) = 30
			Atts(1) = "Bite"
			AttP(2) = 30
			Atts(2) = "NinjaStr"
			AttP(3) = 10
			Atts(3) = "Increase Speed"
			Res(R_FIRE) = -25
			Res(R_COLD) = 25
		ElseIf s = "Druid Acolyte" Then 
			Name = s
			Depth = 4
			Dervs(D_SAT) = Spread(110, 10)
			Dervs(D_DEF) = Spread(90, 10)
			Dervs(D_HTP) = Spread(90, 10)
			Dervs(D_SPD) = Spread(100, 10)
			Dervs(D_DAM) = Spread(110, 10)
			Dervs(D_DR) = Spread(110, 10)
			Terrain = T_FOR
			Flags = Flags Or F_VAMP
			AttP(0) = 30
			Atts(0) = "Heal"
			AttP(1) = 30
			Atts(1) = "Entangle"
			AttP(2) = 40
			Atts(2) = "Normal"
			Res(R_MAGI) = 25
			Res(R_COLD) = 25
			Res(R_FIRE) = 25
		ElseIf s = "Dryad" Then 
			Name = s
			Depth = 5
			Dervs(D_SAT) = Spread(90, 10)
			Dervs(D_DEF) = Spread(110, 10)
			Dervs(D_HTP) = Spread(90, 10)
			Dervs(D_SPD) = Spread(110, 10)
			Dervs(D_DAM) = Spread(90, 10)
			Dervs(D_DR) = Spread(115, 10)
			Terrain = T_FOR
			AttP(0) = 10
			Atts(0) = "Invisible"
			AttP(1) = 40
			Atts(1) = "Entangle"
			AttP(2) = 50
			Atts(2) = "Normal"
			Res(R_FIRE) = -25
		ElseIf s = "Lightning Bug" Then 
			Name = s
			Depth = 6
			Dervs(D_SAT) = Spread(110, 10)
			Dervs(D_DEF) = Spread(95, 10)
			Dervs(D_HTP) = Spread(110, 10)
			Dervs(D_SPD) = Spread(90, 10)
			Dervs(D_DAM) = Spread(110, 10)
			Dervs(D_DR) = Spread(90, 10)
			Terrain = T_FOR
			AttP(0) = 30
			Atts(0) = "Electric Shock"
			AttP(1) = 70
			Atts(1) = "Bite"
			Res(R_ELEC) = 100
		ElseIf s = "Dark Elf" Then 
			Name = s
			Depth = 7
			Dervs(D_SAT) = Spread(110, 10)
			Dervs(D_DEF) = Spread(110, 10)
			Dervs(D_HTP) = Spread(90, 10)
			Dervs(D_SPD) = Spread(110, 10)
			Dervs(D_DAM) = Spread(110, 10)
			Dervs(D_DR) = Spread(90, 10)
			Terrain = T_FOR
			AttP(0) = 90
			Atts(0) = "NinjaStr"
			AttP(1) = 10
			Atts(1) = "Three-Quarters"
			Res(R_MAGI) = 25
		ElseIf s = "Wood Golem" Then 
			Name = s
			Depth = 8
			Dervs(D_SAT) = Spread(110, 10)
			Dervs(D_DEF) = Spread(110, 10)
			Dervs(D_HTP) = Spread(105, 10)
			Dervs(D_SPD) = Spread(80, 10)
			Dervs(D_DAM) = Spread(110, 10)
			Dervs(D_DR) = Spread(110, 10)
			Terrain = T_FOR
			Flags = Flags Or F_VAMP
			AttP(0) = 50
			Atts(0) = "Splinters"
			AttP(1) = 50
			Atts(1) = "Stun Attack"
			Res(R_FIRE) = -50
			Res(R_ELEC) = 50
			Res(R_COLD) = 25
		ElseIf s = "Vine Grappler" Then 
			Name = s
			Depth = 9
			Dervs(D_SAT) = Spread(100, 10)
			Dervs(D_DEF) = Spread(100, 10)
			Dervs(D_HTP) = Spread(115, 10)
			Dervs(D_SPD) = Spread(90, 10)
			Dervs(D_DAM) = Spread(110, 10)
			Dervs(D_DR) = Spread(95, 10)
			Terrain = T_FOR
			AttP(0) = 15
			Atts(0) = "Poison Sting"
			AttP(1) = 30
			Atts(1) = "Entangle"
			AttP(2) = 55
			Atts(2) = "Normal"
			Res(R_FIRE) = -50
		ElseIf s = "Forest Troll" Then 
			Name = s
			Depth = 10
			Dervs(D_SAT) = Spread(115, 10)
			Dervs(D_DEF) = Spread(110, 10)
			Dervs(D_HTP) = Spread(110, 10)
			Dervs(D_SPD) = Spread(85, 10)
			Dervs(D_DAM) = Spread(100, 10)
			Dervs(D_DR) = Spread(100, 10)
			Flags = Flags Or F_REGN
			Terrain = T_FOR
			AttP(0) = 20
			Atts(0) = "Stun Attack"
			AttP(1) = 30
			Atts(1) = "Heal"
			AttP(2) = 50
			Atts(2) = "Normal"
			Res(R_FIRE) = -50
			Res(R_COLD) = 15
			Res(R_ELEC) = 15
			Res(R_MAGI) = 15
		ElseIf s = "Gaping Maw" Then 
			Name = s
			Depth = 11
			Dervs(D_SAT) = Spread(100, 10)
			Dervs(D_DEF) = Spread(100, 10)
			Dervs(D_HTP) = Spread(100, 10)
			Dervs(D_SPD) = Spread(80, 10)
			Dervs(D_DAM) = Spread(140, 10)
			Dervs(D_DR) = Spread(100, 10)
			Terrain = T_FOR
			AttP(0) = 100
			Atts(0) = "Swallow"
		ElseIf s = "Master Druid" Then 
			Name = s
			Depth = 12
			Dervs(D_SAT) = Spread(110, 10)
			Dervs(D_DEF) = Spread(90, 10)
			Dervs(D_HTP) = Spread(90, 10)
			Dervs(D_SPD) = Spread(105, 10)
			Dervs(D_DAM) = Spread(110, 10)
			Dervs(D_DR) = Spread(90, 10)
			Terrain = T_FOR
			Flags = Flags Or F_VAMP
			AttP(0) = 30
			Atts(0) = "Heal"
			AttP(1) = 20
			Atts(1) = "Entangle"
			AttP(2) = 30
			Atts(2) = "Normal"
			AttP(3) = 20
			Atts(3) = "Flame Thrower"
			Res(R_MAGI) = 50
			Res(R_COLD) = 50
			Res(R_FIRE) = 50
		ElseIf s = "Dark Elven Ranger" Then 
			Name = s
			Depth = 13
			Dervs(D_SAT) = Spread(110, 10)
			Dervs(D_DEF) = Spread(110, 10)
			Dervs(D_HTP) = Spread(90, 10)
			Dervs(D_SPD) = Spread(105, 10)
			Dervs(D_DAM) = Spread(105, 10)
			Dervs(D_DR) = Spread(95, 10)
			Terrain = T_FOR
			AttP(0) = 50
			Atts(0) = "NinjaStr"
			AttP(1) = 10
			Atts(1) = "Half"
			AttP(2) = 15
			Atts(2) = "Entangle"
			AttP(3) = 25
			Atts(3) = "Bow"
			Res(R_MAGI) = 50
		ElseIf s = "Treant" Then 
			Name = s
			Depth = 14
			Dervs(D_SAT) = Spread(115, 10)
			Dervs(D_DEF) = Spread(110, 10)
			Dervs(D_HTP) = Spread(110, 10)
			Dervs(D_SPD) = Spread(80, 10)
			Dervs(D_DAM) = Spread(110, 10)
			Dervs(D_DR) = Spread(110, 10)
			Terrain = T_FOR
			Flags = Flags Or F_VAMP
			AttP(0) = 35
			Atts(0) = "Splinters"
			AttP(1) = 35
			Atts(1) = "Stun Attack"
			AttP(2) = 20
			Atts(2) = "Entangle"
			AttP(3) = 10
			Atts(3) = "Heal"
			Res(R_FIRE) = -25
			Res(R_ELEC) = 60
			Res(R_COLD) = 35
		ElseIf s = "Razor Leaf" Then 
			Name = s
			Depth = 15
			Dervs(D_SAT) = Spread(100, 15)
			Dervs(D_DEF) = Spread(90, 10)
			Dervs(D_HTP) = Spread(100, 10)
			Dervs(D_SPD) = Spread(100, 10)
			Dervs(D_DAM) = Spread(50, 10)
			Dervs(D_DR) = Spread(105, 10)
			Terrain = T_FOR
			AttP(0) = 50
			Atts(0) = "Blade Tornado"
			AttP(1) = 50
			Atts(1) = "Increase Speed"
			Res(R_FIRE) = -25
		ElseIf s = "Baby Green Dragon" Then 
			Name = s
			Depth = 16
			Dervs(D_SAT) = Spread(110, 10)
			Dervs(D_DEF) = Spread(90, 10)
			Dervs(D_HTP) = Spread(110, 10)
			Dervs(D_SPD) = Spread(100, 10)
			Dervs(D_DAM) = Spread(95, 10)
			Dervs(D_DR) = Spread(95, 10)
			Terrain = T_FOR
			AttP(0) = 60
			Atts(0) = "Dragon Claw"
			AttP(1) = 30
			Atts(1) = "Dragon Bite"
			AttP(2) = 10
			Atts(2) = "Green Dragon Breath"
			Res(R_FIRE) = 50
			Res(R_MAGI) = 50
		ElseIf s = "Wyvern" Then 
			Name = s
			Depth = 17
			Dervs(D_SAT) = Spread(90, 10)
			Dervs(D_DEF) = Spread(115, 10)
			Dervs(D_HTP) = Spread(95, 10)
			Dervs(D_SPD) = Spread(110, 10)
			Dervs(D_DAM) = Spread(95, 10)
			Dervs(D_DR) = Spread(100, 10)
			Terrain = T_DES
			AttP(0) = 30
			Atts(0) = "Bite"
			AttP(1) = 30
			Atts(1) = "Leap"
			AttP(2) = 40
			Atts(2) = "Poison Sting"
			Res(R_ELEC) = 25
			Res(R_MAGI) = 25
		ElseIf s = "Great Druid" Then 
			Name = s
			Depth = 18
			Dervs(D_SAT) = Spread(115, 15)
			Dervs(D_DEF) = Spread(85, 10)
			Dervs(D_HTP) = Spread(100, 10)
			Dervs(D_SPD) = Spread(105, 10)
			Dervs(D_DAM) = Spread(110, 10)
			Dervs(D_DR) = Spread(110, 10)
			Terrain = T_FOR
			Flags = Flags Or F_VAMP
			AttP(0) = 30
			Atts(0) = "Heal"
			AttP(1) = 10
			Atts(1) = "Entangle"
			AttP(2) = 20
			Atts(2) = "Normal"
			AttP(3) = 20
			Atts(3) = "Flame Thrower"
			AttP(4) = 20
			Atts(4) = "Ice Blast"
			Res(R_MAGI) = 75
			Res(R_COLD) = 75
			Res(R_FIRE) = 75
		ElseIf s = "Green Dragon" Then 
			Name = s
			Depth = 19
			Dervs(D_SAT) = Spread(115, 10)
			Dervs(D_DEF) = Spread(90, 10)
			Dervs(D_HTP) = Spread(110, 10)
			Dervs(D_SPD) = Spread(110, 10)
			Dervs(D_DAM) = Spread(100, 10)
			Dervs(D_DR) = Spread(100, 10)
			Terrain = T_FOR
			AttP(0) = 40
			Atts(0) = "Dragon Claw"
			AttP(1) = 35
			Atts(1) = "Dragon Bite"
			AttP(2) = 15
			Atts(2) = "Green Dragon Breath"
			AttP(3) = 10
			Atts(3) = "Heal"
			Res(R_FIRE) = 75
			Res(R_MAGI) = 75
		ElseIf s = "Shadow Walker" Then 
			Name = s
			Depth = 20
			Dervs(D_SAT) = Spread(110, 15)
			Dervs(D_DEF) = Spread(115, 15)
			Dervs(D_HTP) = Spread(90, 10)
			Dervs(D_SPD) = Spread(105, 10)
			Dervs(D_DAM) = Spread(110, 10)
			Dervs(D_DR) = Spread(110, 10)
			Terrain = T_DES
			AttP(0) = 60
			Atts(0) = "NinjaStr"
			AttP(1) = 30
			Atts(1) = "Invisible"
			AttP(2) = 10
			Atts(2) = "Death"
			Res(R_MAGI) = 100
			Res(R_FIRE) = 50
			Res(R_ELEC) = 50
			Res(R_COLD) = 50
			
		ElseIf s = "Jackal" Then 
			Name = s
			Depth = 0
			Dervs(D_SAT) = Spread(90, 10)
			Dervs(D_DEF) = Spread(90, 10)
			Dervs(D_HTP) = Spread(100, 10)
			Dervs(D_SPD) = Spread(225, 25)
			Dervs(D_DAM) = Spread(70, 10)
			Dervs(D_DR) = Spread(70, 10)
			Terrain = T_PLN
			AttP(0) = 50
			Atts(0) = "Bite"
			AttP(1) = 50
			Atts(1) = "Leap"
			Res(R_FIRE) = -50
		ElseIf s = "Giant Killer Bee" Then 
			Name = s
			Depth = 1
			Dervs(D_SAT) = Spread(90, 10)
			Dervs(D_DEF) = Spread(110, 10)
			Dervs(D_HTP) = Spread(90, 10)
			Dervs(D_SPD) = Spread(150, 10)
			Dervs(D_DAM) = Spread(100, 10)
			Dervs(D_DR) = Spread(100, 10)
			Terrain = T_PLN
			AttP(0) = 100
			Atts(0) = "Poison Sting"
			Res(R_ELEC) = 50
			Res(R_COLD) = -50
		ElseIf s = "Cattle Rustler" Then 
			Name = s
			Depth = 2
			Dervs(D_SAT) = Spread(130, 10)
			Dervs(D_DEF) = Spread(90, 10)
			Dervs(D_HTP) = Spread(120, 10)
			Dervs(D_SPD) = Spread(100, 10)
			Dervs(D_DAM) = Spread(115, 10)
			Dervs(D_DR) = Spread(120, 10)
			Terrain = T_PLN
			AttP(0) = 30
			Atts(0) = "Lasso"
			AttP(1) = 70
			Atts(1) = "Normal"
		ElseIf s = "Baby Tremor" Then 
			Name = s
			Depth = 3
			Dervs(D_SAT) = Spread(90, 10)
			Dervs(D_DEF) = Spread(110, 10)
			Dervs(D_HTP) = Spread(90, 10)
			Dervs(D_SPD) = Spread(120, 10)
			Dervs(D_DAM) = Spread(90, 10)
			Dervs(D_DR) = Spread(125, 10)
			Terrain = T_PLN
			AttP(0) = 30
			Atts(0) = "Throw Sand"
			AttP(1) = 40
			Atts(1) = "Normal"
			AttP(2) = 30
			Atts(2) = "Earthquake"
			Res(R_ELEC) = 100
		ElseIf s = "Skeletal Soldier" Then 
			Name = s
			Depth = 4
			Dervs(D_SAT) = Spread(115, 10)
			Dervs(D_DEF) = Spread(110, 10)
			Dervs(D_HTP) = Spread(100, 10)
			Dervs(D_SPD) = Spread(75, 10)
			Dervs(D_DAM) = Spread(100, 10)
			Dervs(D_DR) = Spread(110, 10)
			Flags = Flags Or F_VAMP
			Terrain = T_PLN
			AttP(0) = 30
			Atts(0) = "Drain"
			AttP(1) = 70
			Atts(1) = "Normal"
			Res(R_FIRE) = -50
			Res(R_COLD) = 100
			Res(R_ELEC) = 100
		ElseIf s = "Cannibal Warrior" Then 
			Name = s
			Depth = 5
			Dervs(D_SAT) = Spread(100, 10)
			Dervs(D_DEF) = Spread(90, 10)
			Dervs(D_HTP) = Spread(110, 10)
			Dervs(D_SPD) = Spread(85, 10)
			Dervs(D_DAM) = Spread(115, 10)
			Dervs(D_DR) = Spread(80, 10)
			Terrain = T_PLN
			AttP(0) = 30
			Atts(0) = "Blowgun"
			AttP(1) = 60
			Atts(1) = "Normal"
			AttP(2) = 10
			Atts(2) = "Swallow"
		ElseIf s = "Bull Lion" Then 
			Name = s
			Depth = 6
			Dervs(D_SAT) = Spread(110, 10)
			Dervs(D_DEF) = Spread(90, 10)
			Dervs(D_HTP) = Spread(110, 10)
			Dervs(D_SPD) = Spread(95, 10)
			Dervs(D_DAM) = Spread(110, 10)
			Dervs(D_DR) = Spread(90, 10)
			Terrain = T_PLN
			AttP(0) = 30
			Atts(0) = "Leap"
			AttP(1) = 40
			Atts(1) = "Bite"
			AttP(2) = 30
			Atts(2) = "Claw"
		ElseIf s = "Grass Golem" Then 
			Name = s
			Depth = 7
			Dervs(D_SAT) = Spread(90, 10)
			Dervs(D_DEF) = Spread(115, 10)
			Dervs(D_HTP) = Spread(115, 10)
			Dervs(D_SPD) = Spread(90, 10)
			Dervs(D_DAM) = Spread(110, 10)
			Dervs(D_DR) = Spread(90, 10)
			Terrain = T_PLN
			Flags = Flags Or F_VAMP
			AttP(0) = 70
			Atts(0) = "Normal"
			AttP(1) = 20
			Atts(1) = "Entangle"
			AttP(2) = 10
			Atts(2) = "Sleep"
			Res(R_FIRE) = -100
			Res(R_ELEC) = 100
		ElseIf s = "Werewolf" Then 
			Name = s
			Depth = 8
			Dervs(D_SAT) = Spread(110, 10)
			Dervs(D_DEF) = Spread(90, 10)
			Dervs(D_HTP) = Spread(115, 10)
			Dervs(D_SPD) = Spread(110, 15)
			Dervs(D_DAM) = Spread(95, 10)
			Dervs(D_DR) = Spread(100, 10)
			Terrain = T_PLN
			AttP(0) = 35
			Atts(0) = "Leap"
			AttP(1) = 35
			Atts(1) = "Bite"
			AttP(2) = 30
			Atts(2) = "Heal"
			Res(R_FIRE) = -50
		ElseIf s = "Cannibal Shaman" Then 
			Name = s
			Depth = 9
			Dervs(D_SAT) = Spread(100, 10)
			Dervs(D_DEF) = Spread(95, 10)
			Dervs(D_HTP) = Spread(110, 10)
			Dervs(D_SPD) = Spread(95, 10)
			Dervs(D_DAM) = Spread(115, 10)
			Dervs(D_DR) = Spread(85, 10)
			Terrain = T_PLN
			AttP(0) = 30
			Atts(0) = "Blowgun"
			AttP(1) = 30
			Atts(1) = "Normal"
			AttP(2) = 10
			Atts(2) = "Swallow"
			AttP(3) = 30
			Atts(3) = "Heal"
		ElseIf s = "Vulture Swarm" Then 
			Name = s
			Depth = 10
			Dervs(D_SAT) = Spread(100, 10)
			Dervs(D_DEF) = Spread(110, 10)
			Dervs(D_HTP) = Spread(110, 10)
			Dervs(D_SPD) = Spread(90, 10)
			Dervs(D_DAM) = Spread(66, 10)
			Dervs(D_DR) = Spread(100, 10)
			Terrain = T_PLN
			AttP(0) = 100
			Atts(0) = "Swarm"
			Res(R_ELEC) = 50
			Res(R_COLD) = -50
		ElseIf s = "Giant Tremor" Then 
			Name = s
			Depth = 11
			Dervs(D_SAT) = Spread(90, 10)
			Dervs(D_DEF) = Spread(110, 10)
			Dervs(D_HTP) = Spread(95, 10)
			Dervs(D_SPD) = Spread(115, 10)
			Dervs(D_DAM) = Spread(90, 10)
			Dervs(D_DR) = Spread(125, 10)
			Terrain = T_PLN
			AttP(0) = 30
			Atts(0) = "Throw Sand"
			AttP(1) = 20
			Atts(1) = "Normal"
			AttP(2) = 50
			Atts(2) = "Earthquake"
			Res(R_ELEC) = 100
		ElseIf s = "Cannibal Chief" Then 
			Name = s
			Depth = 12
			Dervs(D_SAT) = Spread(115, 10)
			Dervs(D_DEF) = Spread(110, 10)
			Dervs(D_HTP) = Spread(110, 10)
			Dervs(D_SPD) = Spread(110, 10)
			Dervs(D_DAM) = Spread(110, 10)
			Dervs(D_DR) = Spread(100, 10)
			Terrain = T_PLN
			AttP(0) = 30
			Atts(0) = "Blowgun"
			AttP(1) = 50
			Atts(1) = "NinjaStr"
			AttP(2) = 20
			Atts(2) = "Swallow"
		ElseIf s = "Wildfire" Then 
			Name = s
			Depth = 13
			Dervs(D_SAT) = Spread(115, 10)
			Dervs(D_DEF) = Spread(110, 10)
			Dervs(D_HTP) = Spread(90, 10)
			Dervs(D_SPD) = Spread(110, 10)
			Dervs(D_DAM) = Spread(100, 10)
			Dervs(D_DR) = Spread(100, 10)
			Terrain = T_PLN
			AttP(0) = 60
			Atts(0) = "Flame Thrower"
			AttP(1) = 20
			Atts(1) = "Half"
			AttP(2) = 20
			Atts(2) = "Increase Speed"
		ElseIf s = "Corpse Golem" Then 
			Name = s
			Depth = 14
			Dervs(D_SAT) = Spread(115, 10)
			Dervs(D_DEF) = Spread(110, 10)
			Dervs(D_HTP) = Spread(110, 10)
			Dervs(D_SPD) = Spread(50, 10)
			Dervs(D_DAM) = Spread(115, 10)
			Dervs(D_DR) = Spread(115, 10)
			Terrain = T_PLN
			Flags = Flags Or F_VAMP
			AttP(0) = 40
			Atts(0) = "Drain"
			AttP(1) = 40
			Atts(1) = "Stun Attack"
			AttP(2) = 20
			Atts(2) = "Hurl Corpse"
			Res(R_ELEC) = 100
			Res(R_COLD) = 100
			Res(R_FIRE) = -50
			Res(R_MAGI) = -50
		ElseIf s = "Manticore" Then 
			Name = s
			Depth = 15
			Dervs(D_SAT) = Spread(90, 10)
			Dervs(D_DEF) = Spread(90, 5)
			Dervs(D_HTP) = Spread(105, 10)
			Dervs(D_SPD) = Spread(110, 10)
			Dervs(D_DAM) = Spread(110, 10)
			Dervs(D_DR) = Spread(90, 10)
			Terrain = T_PLN
			AttP(0) = 50
			Atts(0) = "Poison Sting"
			AttP(1) = 25
			Atts(1) = "Claw"
			AttP(2) = 25
			Atts(2) = "Bite"
			Res(R_MAGI) = 100
		ElseIf s = "Baby Brass Dragon" Then 
			Name = s
			Depth = 16
			Dervs(D_SAT) = Spread(110, 15)
			Dervs(D_DEF) = Spread(85, 10)
			Dervs(D_HTP) = Spread(105, 10)
			Dervs(D_SPD) = Spread(105, 10)
			Dervs(D_DAM) = Spread(110, 10)
			Dervs(D_DR) = Spread(95, 10)
			Terrain = T_PLN
			AttP(0) = 60
			Atts(0) = "Dragon Claw"
			AttP(1) = 30
			Atts(1) = "Dragon Bite"
			AttP(2) = 10
			Atts(2) = "Brass Dragon Breath"
			Res(R_FIRE) = 100
			Res(R_MAGI) = 25
		ElseIf s = "Celestial Spirit" Then 
			Name = s
			Depth = 17
			Dervs(D_SAT) = Spread(80, 10)
			Dervs(D_DEF) = Spread(115, 10)
			Dervs(D_HTP) = Spread(70, 10)
			Dervs(D_SPD) = Spread(130, 10)
			Dervs(D_DAM) = Spread(100, 10)
			Dervs(D_DR) = Spread(120, 10)
			Terrain = T_PLN
			AttP(0) = 25
			Atts(0) = "Flame Thrower"
			AttP(1) = 25
			Atts(1) = "Ice Blast"
			AttP(2) = 25
			Atts(2) = "Electric Shock"
			AttP(3) = 25
			Atts(3) = "Mana Storm"
			Res(R_FIRE) = 50
			Res(R_COLD) = 50
			Res(R_ELEC) = 50
			Res(R_MAGI) = 50
		ElseIf s = "Phoenix" Then 
			Name = s
			Depth = 18
			Dervs(D_SAT) = Spread(120, 10)
			Dervs(D_DEF) = Spread(90, 10)
			Dervs(D_HTP) = Spread(105, 10)
			Dervs(D_SPD) = Spread(115, 10)
			Dervs(D_DAM) = Spread(100, 10)
			Dervs(D_DR) = Spread(85, 10)
			Terrain = T_PLN
			AttP(0) = 30
			Atts(0) = "Flame Thrower"
			AttP(1) = 40
			Atts(1) = "Solar Flare"
			AttP(2) = 30
			Atts(2) = "Heal"
			Res(R_FIRE) = 100
			Res(R_COLD) = -50
		ElseIf s = "Brass Dragon" Then 
			Name = s
			Depth = 19
			Dervs(D_SAT) = Spread(115, 10)
			Dervs(D_DEF) = Spread(85, 10)
			Dervs(D_HTP) = Spread(110, 10)
			Dervs(D_SPD) = Spread(110, 10)
			Dervs(D_DAM) = Spread(110, 10)
			Dervs(D_DR) = Spread(90, 10)
			Terrain = T_PLN
			AttP(0) = 40
			Atts(0) = "Dragon Claw"
			AttP(1) = 35
			Atts(1) = "Dragon Bite"
			AttP(2) = 15
			Atts(2) = "Brass Dragon Breath"
			AttP(3) = 10
			Atts(3) = "Heal"
			Res(R_FIRE) = 100
			Res(R_MAGI) = 75
		ElseIf s = "Whispering Wind" Then 
			Name = s
			Depth = 20
			Dervs(D_SAT) = Spread(90, 10)
			Dervs(D_DEF) = Spread(110, 10)
			Dervs(D_HTP) = Spread(75, 10)
			Dervs(D_SPD) = Spread(130, 10)
			Dervs(D_DAM) = Spread(100, 10)
			Dervs(D_DR) = Spread(110, 10)
			Terrain = T_PLN
			AttP(0) = 20
			Atts(0) = "Invisible"
			AttP(1) = 60
			Atts(1) = "Half"
			AttP(2) = 20
			Atts(2) = "NinjaStr"
			Res(R_FIRE) = 50
			Res(R_COLD) = 50
			Res(R_ELEC) = 50
			Res(R_MAGI) = 50
			
		ElseIf s = "Dingo" Then 
			Name = s
			Depth = 0
			Dervs(D_SAT) = Spread(130, 10)
			Dervs(D_DEF) = Spread(140, 10)
			Dervs(D_HTP) = Spread(120, 10)
			Dervs(D_SPD) = Spread(50, 10)
			Dervs(D_DAM) = Spread(100, 10)
			Dervs(D_DR) = Spread(100, 10)
			Terrain = T_HIL
			AttP(0) = 50
			Atts(0) = "Bite"
			AttP(1) = 50
			Atts(1) = "Leap"
		ElseIf s = "Fighting Falcon" Then 
			Name = s
			Depth = 1
			Dervs(D_SAT) = Spread(90, 10)
			Dervs(D_DEF) = Spread(110, 10)
			Dervs(D_HTP) = Spread(90, 10)
			Dervs(D_SPD) = Spread(125, 10)
			Dervs(D_DAM) = Spread(110, 10)
			Dervs(D_DR) = Spread(90, 10)
			Terrain = T_HIL
			AttP(0) = 30
			Atts(0) = "Dive"
			AttP(1) = 70
			Atts(1) = "Claw"
			Res(R_ELEC) = 50
		ElseIf s = "Fire Ant" Then 
			Name = s
			Depth = 2
			Dervs(D_SAT) = Spread(115, 10)
			Dervs(D_DEF) = Spread(110, 10)
			Dervs(D_HTP) = Spread(85, 10)
			Dervs(D_SPD) = Spread(90, 10)
			Dervs(D_DAM) = Spread(100, 10)
			Dervs(D_DR) = Spread(115, 10)
			Terrain = T_HIL
			AttP(0) = 50
			Atts(0) = "Bite"
			AttP(1) = 25
			Atts(1) = "Flame Thrower"
			AttP(2) = 25
			Atts(2) = "Pincer"
			Res(R_FIRE) = 100
		ElseIf s = "Herdsman" Then 
			Name = s
			Depth = 3
			Dervs(D_SAT) = Spread(120, 10)
			Dervs(D_DEF) = Spread(95, 10)
			Dervs(D_HTP) = Spread(110, 10)
			Dervs(D_SPD) = Spread(90, 10)
			Dervs(D_DAM) = Spread(120, 10)
			Dervs(D_DR) = Spread(120, 10)
			Terrain = T_HIL
			AttP(0) = 25
			Atts(0) = "Cattle Prod"
			AttP(1) = 75
			Atts(1) = "Normal"
		ElseIf s = "Illusionary" Then 
			Name = s
			Depth = 4
			Dervs(D_SAT) = Spread(90, 10)
			Dervs(D_DEF) = Spread(120, 10)
			Dervs(D_HTP) = Spread(90, 10)
			Dervs(D_SPD) = Spread(95, 10)
			Dervs(D_DAM) = Spread(100, 10)
			Dervs(D_DR) = Spread(120, 10)
			Terrain = T_HIL
			AttP(0) = 25
			Atts(0) = "Invisible"
			AttP(1) = 25
			Atts(1) = "Illusion"
			AttP(2) = 50
			Atts(2) = "Mana Storm"
			Res(R_MAGI) = 100
		ElseIf s = "Spitting Snake" Then 
			Name = s
			Depth = 5
			Dervs(D_SAT) = Spread(90, 10)
			Dervs(D_DEF) = Spread(125, 10)
			Dervs(D_HTP) = Spread(90, 10)
			Dervs(D_SPD) = Spread(95, 10)
			Dervs(D_DAM) = Spread(100, 10)
			Dervs(D_DR) = Spread(115, 10)
			Terrain = T_HIL
			AttP(0) = 75
			Atts(0) = "Bite"
			AttP(1) = 25
			Atts(1) = "Spit Poison"
			Res(R_COLD) = -25
			Res(R_FIRE) = -25
		ElseIf s = "Cheetah" Then 
			Name = s
			Depth = 6
			Dervs(D_SAT) = Spread(95, 5)
			Dervs(D_DEF) = Spread(110, 10)
			Dervs(D_HTP) = Spread(90, 10)
			Dervs(D_SPD) = Spread(190, 10)
			Dervs(D_DAM) = Spread(70, 10)
			Dervs(D_DR) = Spread(100, 10)
			Terrain = T_HIL
			AttP(0) = 50
			Atts(0) = "Bite"
			AttP(1) = 50
			Atts(1) = "Leap"
		ElseIf s = "Huntsman" Then 
			Name = s
			Depth = 7
			Dervs(D_SAT) = Spread(105, 10)
			Dervs(D_DEF) = Spread(90, 10)
			Dervs(D_HTP) = Spread(110, 10)
			Dervs(D_SPD) = Spread(105, 10)
			Dervs(D_DAM) = Spread(110, 10)
			Dervs(D_DR) = Spread(110, 10)
			Terrain = T_HIL
			AttP(0) = 25
			Atts(0) = "Cattle Prod"
			AttP(1) = 25
			Atts(1) = "Normal"
			AttP(2) = 50
			Atts(2) = "Bow"
		ElseIf s = "Centipede" Then 
			Name = s
			Depth = 8
			Dervs(D_SAT) = Spread(110, 10)
			Dervs(D_DEF) = Spread(85, 10)
			Dervs(D_HTP) = Spread(115, 10)
			Dervs(D_SPD) = Spread(80, 10)
			Dervs(D_DAM) = Spread(110, 10)
			Dervs(D_DR) = Spread(90, 10)
			Terrain = T_HIL
			AttP(0) = 30
			Atts(0) = "Poison Sting"
			AttP(1) = 40
			Atts(1) = "Bite"
			AttP(2) = 30
			Atts(2) = "Suck Blood"
		ElseIf s = "Hill Giant" Then 
			Name = s
			Depth = 9
			Dervs(D_SAT) = Spread(120, 10)
			Dervs(D_DEF) = Spread(90, 10)
			Dervs(D_HTP) = Spread(115, 10)
			Dervs(D_SPD) = Spread(80, 10)
			Dervs(D_DAM) = Spread(110, 10)
			Dervs(D_DR) = Spread(110, 10)
			Terrain = T_HIL
			AttP(0) = 80
			Atts(0) = "Stun Attack"
			AttP(1) = 20
			Atts(1) = "Throw Rock"
		ElseIf s = "Barrow Wight" Then 
			Name = s
			Depth = 10
			Dervs(D_SAT) = Spread(90, 10)
			Dervs(D_DEF) = Spread(90, 10)
			Dervs(D_HTP) = Spread(115, 10)
			Dervs(D_SPD) = Spread(100, 10)
			Dervs(D_DAM) = Spread(110, 10)
			Dervs(D_DR) = Spread(110, 10)
			Terrain = T_HIL
			Flags = Flags Or F_VAMP
			AttP(0) = 40
			Atts(0) = "Drain"
			AttP(1) = 40
			Atts(1) = "Normal"
			AttP(2) = 20
			Atts(2) = "Ice Blast"
			Res(R_ELEC) = 100
			Res(R_COLD) = 100
			Res(R_MAGI) = 100
		ElseIf s = "Hedge Wizard" Then 
			Name = s
			Depth = 11
			Dervs(D_SAT) = Spread(90, 10)
			Dervs(D_DEF) = Spread(110, 10)
			Dervs(D_HTP) = Spread(80, 10)
			Dervs(D_SPD) = Spread(100, 10)
			Dervs(D_DAM) = Spread(100, 10)
			Dervs(D_DR) = Spread(100, 10)
			Terrain = T_HIL
			AttP(0) = 20
			Atts(0) = "Half"
			AttP(1) = 20
			Atts(1) = "Sand Blaster"
			AttP(2) = 20
			Atts(2) = "Sleep"
			AttP(3) = 20
			Atts(3) = "Earthquake"
			AttP(4) = 20
			Atts(4) = "Blinding Flash"
			Res(R_MAGI) = 100
		ElseIf s = "Hill Troll" Then 
			Name = s
			Depth = 12
			Dervs(D_SAT) = Spread(110, 10)
			Dervs(D_DEF) = Spread(110, 10)
			Dervs(D_HTP) = Spread(100, 10)
			Dervs(D_SPD) = Spread(85, 10)
			Dervs(D_DAM) = Spread(110, 10)
			Dervs(D_DR) = Spread(100, 10)
			Flags = Flags Or F_REGN
			Terrain = T_HIL
			AttP(0) = 20
			Atts(0) = "Stun Attack"
			AttP(1) = 30
			Atts(1) = "Heal"
			AttP(2) = 50
			Atts(2) = "Normal"
			Res(R_FIRE) = -50
		ElseIf s = "Living Hill" Then 
			Name = s
			Depth = 13
			Dervs(D_SAT) = Spread(115, 10)
			Dervs(D_DEF) = Spread(110, 10)
			Dervs(D_HTP) = Spread(200, 10)
			Dervs(D_SPD) = Spread(50, 5)
			Dervs(D_DAM) = Spread(100, 10)
			Dervs(D_DR) = Spread(110, 10)
			Flags = Flags
			Terrain = T_HIL
			AttP(0) = 20
			Atts(0) = "Stun Attack"
			AttP(1) = 10
			Atts(1) = "Entangle"
			AttP(2) = 50
			Atts(2) = "Swallow"
			AttP(3) = 20
			Atts(3) = "Earthquake"
			Res(R_FIRE) = 50
			Res(R_ELEC) = 100
		ElseIf s = "Warsman" Then 
			Name = s
			Depth = 14
			Dervs(D_SAT) = Spread(120, 10)
			Dervs(D_DEF) = Spread(90, 10)
			Dervs(D_HTP) = Spread(105, 10)
			Dervs(D_SPD) = Spread(105, 10)
			Dervs(D_DAM) = Spread(105, 10)
			Dervs(D_DR) = Spread(100, 10)
			Flags = Flags
			Terrain = T_HIL
			AttP(0) = 15
			Atts(0) = "NinjaStr"
			AttP(1) = 20
			Atts(1) = "Blowgun"
			AttP(2) = 15
			Atts(2) = "Charge"
			AttP(3) = 50
			Atts(3) = "Normal"
		ElseIf s = "Wild Beast" Then 
			Name = s
			Depth = 15
			Dervs(D_SAT) = Spread(110, 10)
			Dervs(D_DEF) = Spread(95, 10)
			Dervs(D_HTP) = Spread(105, 10)
			Dervs(D_SPD) = Spread(112, 8)
			Dervs(D_DAM) = Spread(110, 10)
			Dervs(D_DR) = 0
			Flags = Flags
			Terrain = T_HIL
			AttP(0) = 25
			Atts(0) = "Suck Blood"
			AttP(1) = 30
			Atts(1) = "Leap"
			AttP(2) = 20
			Atts(2) = "Charge"
			AttP(3) = 25
			Atts(3) = "Bite"
		ElseIf s = "Baby Copper Dragon" Then 
			Name = s
			Depth = 16
			Dervs(D_SAT) = Spread(110, 10)
			Dervs(D_DEF) = Spread(90, 10)
			Dervs(D_HTP) = Spread(110, 10)
			Dervs(D_SPD) = Spread(110, 10)
			Dervs(D_DAM) = Spread(110, 10)
			Dervs(D_DR) = Spread(100, 10)
			Terrain = T_HIL
			AttP(0) = 60
			Atts(0) = "Dragon Claw"
			AttP(1) = 30
			Atts(1) = "Dragon Bite"
			AttP(2) = 10
			Atts(2) = "Copper Dragon Breath"
			Res(R_FIRE) = 100
			Res(R_MAGI) = 50
		ElseIf s = "Phantom Flyer" Then 
			Name = s
			Depth = 17
			Dervs(D_SAT) = Spread(90, 10)
			Dervs(D_DEF) = Spread(100, 10)
			Dervs(D_HTP) = Spread(90, 10)
			Dervs(D_SPD) = Spread(130, 10)
			Dervs(D_DAM) = Spread(90, 10)
			Dervs(D_DR) = Spread(110, 10)
			Terrain = T_HIL
			AttP(0) = 20
			Atts(0) = "Illusion"
			AttP(1) = 30
			Atts(1) = "Mana Storm"
			AttP(2) = 50
			Atts(2) = "Dive"
		ElseIf s = "Integer Walker" Then 
			Name = s
			Depth = 18
			Dervs(D_SAT) = Spread(120, 10)
			Dervs(D_DEF) = Spread(110, 10)
			Dervs(D_HTP) = Spread(90, 10)
			Dervs(D_SPD) = Spread(85, 10)
			Dervs(D_DAM) = Spread(110, 10)
			Dervs(D_DR) = Spread(90, 10)
			Terrain = T_HIL
			AttP(0) = 70
			Atts(0) = "Stun Attack"
			AttP(1) = 15
			Atts(1) = "Three-Quarters"
			AttP(2) = 10
			Atts(2) = "Half"
			AttP(3) = 5
			Atts(3) = "Quarter"
		ElseIf s = "Copper Dragon" Then 
			Name = s
			Depth = 19
			Dervs(D_SAT) = Spread(115, 10)
			Dervs(D_DEF) = Spread(90, 10)
			Dervs(D_HTP) = Spread(110, 10)
			Dervs(D_SPD) = Spread(110, 10)
			Dervs(D_DAM) = Spread(110, 10)
			Dervs(D_DR) = Spread(100, 10)
			Terrain = T_HIL
			AttP(0) = 40
			Atts(0) = "Dragon Claw"
			AttP(1) = 35
			Atts(1) = "Dragon Bite"
			AttP(2) = 15
			Atts(2) = "Copper Dragon Breath"
			AttP(3) = 10
			Atts(3) = "Heal"
			Res(R_FIRE) = 100
			Res(R_MAGI) = 100
		ElseIf s = "Gargantuan" Then 
			Name = s
			Depth = 20
			Dervs(D_SAT) = Spread(120, 10)
			Dervs(D_DEF) = Spread(70, 10)
			Dervs(D_HTP) = Spread(200, 10)
			Dervs(D_SPD) = Spread(60, 10)
			Dervs(D_DAM) = Spread(150, 10)
			Dervs(D_DR) = Spread(120, 10)
			Terrain = T_HIL
			Flags = Flags Or F_REGN
			AttP(0) = 30
			Atts(0) = "Swallow"
			AttP(1) = 30
			Atts(1) = "Earthquake"
			AttP(2) = 30
			Atts(2) = "Stun Attack"
			AttP(3) = 10
			Atts(3) = "Heal"
			
		ElseIf s = "Nail Blossom" Then 
			Name = s
			Depth = 0
			Dervs(D_SAT) = Spread(130, 10)
			Dervs(D_DEF) = Spread(90, 10)
			Dervs(D_HTP) = Spread(90, 10)
			Dervs(D_SPD) = Spread(100, 10)
			Dervs(D_DAM) = Spread(100, 10)
			Dervs(D_DR) = Spread(90, 10)
			Terrain = T_JUN
			AttP(0) = 20
			Atts(0) = "Nail"
			AttP(1) = 20
			Atts(1) = "Entangle"
			Res(R_FIRE) = -25
		ElseIf s = "Tree Python" Then 
			Name = s
			Depth = 1
			Dervs(D_SAT) = Spread(130, 10)
			Dervs(D_DEF) = Spread(110, 10)
			Dervs(D_HTP) = Spread(110, 10)
			Dervs(D_SPD) = Spread(90, 10)
			Dervs(D_DAM) = Spread(100, 10)
			Dervs(D_DR) = Spread(100, 10)
			Terrain = T_JUN
			AttP(0) = 60
			Atts(0) = "Bite"
			AttP(1) = 20
			Atts(1) = "Constrict"
			AttP(1) = 20
			Atts(1) = "Swallow"
		ElseIf s = "Black Jaguar" Then 
			Name = s
			Depth = 2
			Dervs(D_SAT) = Spread(130, 10)
			Dervs(D_DEF) = Spread(120, 10)
			Dervs(D_HTP) = Spread(90, 10)
			Dervs(D_SPD) = Spread(120, 10)
			Dervs(D_DAM) = Spread(100, 10)
			Dervs(D_DR) = Spread(90, 10)
			Terrain = T_JUN
			AttP(0) = 20
			Atts(0) = "Bite"
			AttP(1) = 30
			Atts(1) = "Claw"
			AttP(2) = 30
			Atts(2) = "Leap"
			AttP(3) = 20
			Atts(4) = "Increase Attack"
		ElseIf s = "Tiny Pygmy" Then 
			Name = s
			Depth = 3
			Dervs(D_SAT) = Spread(90, 10)
			Dervs(D_DEF) = Spread(100, 10)
			Dervs(D_HTP) = Spread(120, 10)
			Dervs(D_SPD) = Spread(100, 10)
			Dervs(D_DAM) = Spread(120, 10)
			Dervs(D_DR) = Spread(110, 10)
			Terrain = T_JUN
			AttP(0) = 30
			Atts(0) = "Scream"
			AttP(1) = 40
			Atts(1) = "Bow"
			AttP(2) = 30
			Atts(2) = "Blowgun"
			Res(R_MAGI) = -25
		ElseIf s = "War Elephant" Then 
			Name = s
			Depth = 4
			Dervs(D_SAT) = Spread(80, 10)
			Dervs(D_DEF) = Spread(110, 10)
			Dervs(D_HTP) = Spread(150, 10)
			Dervs(D_SPD) = Spread(80, 10)
			Dervs(D_DAM) = Spread(120, 10)
			Dervs(D_DR) = Spread(120, 10)
			Terrain = T_JUN
			AttP(0) = 60
			Atts(0) = "Charge"
			AttP(1) = 40
			Atts(1) = "Stun Attack"
		ElseIf s = "Witch Doctor" Then 
			Name = s
			Depth = 5
			Dervs(D_SAT) = Spread(100, 10)
			Dervs(D_DEF) = Spread(100, 10)
			Dervs(D_HTP) = Spread(100, 10)
			Dervs(D_SPD) = Spread(100, 10)
			Dervs(D_DAM) = Spread(100, 10)
			Dervs(D_DR) = Spread(100, 10)
			Terrain = T_JUN
			AttP(0) = 20
			Atts(0) = "Illusion"
			AttP(1) = 20
			Atts(1) = "Stone Gaze"
			AttP(2) = 10
			Atts(2) = "Heal"
			AttP(3) = 20
			Atts(4) = "Half"
			AttP(4) = 30
			Atts(4) = "Blowgun"
			Res(R_MAGI) = 50
			Res(R_FIRE) = 50
			Res(R_ELEC) = 50
		ElseIf s = "Panthaur" Then 
			Name = s
			Depth = 6
			Dervs(D_SAT) = Spread(120, 10)
			Dervs(D_DEF) = Spread(80, 10)
			Dervs(D_HTP) = Spread(80, 10)
			Dervs(D_SPD) = Spread(120, 10)
			Dervs(D_DAM) = Spread(110, 10)
			Dervs(D_DR) = Spread(80, 10)
			Terrain = T_JUN
			AttP(0) = 20
			Atts(0) = "Bow"
			AttP(1) = 20
			Atts(1) = "Spear"
			AttP(1) = 10
			Atts(1) = "Charge"
			
		ElseIf s = "Thief" Then 
			'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Depth = World_Renamed.World(Loc_Renamed).Depth
			Name = s
			If Depth < 5 Then
				Name = "Footpad"
			ElseIf Depth < 10 Then 
				Name = "Robber"
			ElseIf Depth < 15 Then 
				Name = "Highwayman"
			Else
				Name = "Master Thief"
			End If
			
			Dervs(D_SAT) = Spread(100, 10)
			Dervs(D_DEF) = Spread(80, 10)
			Dervs(D_HTP) = Spread(80, 10)
			Dervs(D_SPD) = Spread(110, 10)
			Dervs(D_DAM) = Spread(100, 10)
			Dervs(D_DR) = Spread(100, 10)
			Terrain = T_ALL
			AttP(0) = 100
			Atts(0) = "Steal"
			Treasure = 2
		ElseIf s = "Ghost" Then 
			'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Depth = World_Renamed.World(Loc_Renamed).LCity.Conts
			Name = s
			If Depth < 2 Then
				Name = "Skeleton"
			ElseIf Depth < 4 Then 
				Name = "Zombie"
			ElseIf Depth < 6 Then 
				Name = "Ghoul"
			ElseIf Depth < 8 Then 
				Name = "Shadow"
			ElseIf Depth < 10 Then 
				Name = "Wight"
			ElseIf Depth < 12 Then 
				Name = "Ghast"
			ElseIf Depth < 14 Then 
				Name = "Wraith"
			ElseIf Depth < 16 Then 
				Name = "Spectre"
			ElseIf Depth < 18 Then 
				Name = "Vampire"
			ElseIf Depth < 20 Then 
				Name = "Ghost"
			Else
				Name = "Lich"
			End If
			
			Dervs(D_SAT) = Spread(100, 10)
			Dervs(D_DEF) = Spread(120, 10)
			Dervs(D_HTP) = Spread(80, 10)
			Dervs(D_SPD) = Spread(110, 10)
			Dervs(D_DAM) = Spread(100, 10)
			Dervs(D_DR) = Spread(100, 10)
			Terrain = T_GHOST
			Flags = Flags Or F_VAMP
			AttP(0) = 100
			Atts(0) = "Drain"
			Res(R_ELEC) = 100
			Res(R_COLD) = 100
			Res(R_FIRE) = -50
			Points = -1
			Treasure = 2
			
		ElseIf s = "Goblin" Then 
			Name = "Goblin"
			'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Depth = World_Renamed.World(Loc_Renamed).Depth
			Dervs(D_SAT) = Spread(110, 10)
			Dervs(D_DEF) = Spread(100, 10)
			Dervs(D_HTP) = Spread(90, 10)
			Dervs(D_SPD) = Spread(90, 10)
			Dervs(D_DAM) = Spread(133, 10)
			Dervs(D_DR) = Spread(100, 10)
			Terrain = T_GOBLIN
			AttP(0) = 80
			AttP(1) = 20
			Atts(0) = "Normal"
			Atts(1) = "FireBomb"
			Points = -1
			Treasure = -1
		Else
			Name = "Error!"
			Dervs(D_SAT) = 0
			Dervs(D_DAT) = 0
			Dervs(D_DEF) = 0
			Dervs(D_HTP) = 0
			Dervs(D_SPD) = 0
			Dervs(D_DAM) = 0
			Dervs(D_DR) = 0
			Dervs(D_CHP) = Dervs(D_HTP)
			Treasure = 0
			Depth = 0
			Terrain = 0
			Points = 0
			AttP(0) = 100
			Atts(0) = "None"
		End If
		
		Dervs(D_SAT) = Int(((Dervs(D_SAT) * (Depth + 1) * E_SAT) / 100) * (1 + (Depth * 0.02)))
		Dervs(D_DAT) = Int(((Dervs(D_DAT) * (Depth + 1) * E_DAT) / 100) * (1 + (Depth * 0.02)))
		Dervs(D_DEF) = Int(((Dervs(D_DEF) * (Depth + 1) * E_DEF) / 100) * (1 + (Depth * 0.02)))
		Dervs(D_HTP) = Int(((Dervs(D_HTP) * (Depth + 1) * E_HTP) / 100) * (1 + (Depth * 0.02)))
		Dervs(D_SPD) = Int(((Dervs(D_SPD) * (Depth + 1) * E_SPD) / 100) * (1 + (Depth * 0.02)))
		Dervs(D_DAM) = Int(((Dervs(D_DAM) * (Depth + 1) * E_DAM) / 100) * (1 + (Depth * 0.02)))
		Dervs(D_DR) = Int(((Dervs(D_DR) * (Depth + 1) * E_DR) / 100) * (1 + (Depth * 0.02)))
		
		If Points <> -1 Then
			Points = Points + (Depth + 1) * E_POINTS
		Else
			Points = 0
		End If
		
		Dervs(D_CHP) = Dervs(D_HTP)
		If Treasure = 0 Then Treasure = 1
		
	End Sub
	
	Public Function DoAttack(ByRef s As String, ByRef T As Character) As String
		Dim d As Short
		Dim attstr As String
		Dim longrange As Short
		Dim i As Short
		longrange = 0
		
		'  If (Me.Counts(N_CONF) > 0) And Int(Rnd * 2) = 0 Then 'Int(Rnd * (Depth + 1)) - Me.Counts(N_CONF) \ 10 < 0 Then
		'    DoAttack = "The " & Me.Name & " flails around in confusion."
		'    Exit Function
		'  End If
		
		If s = "Normal" Then
			d = Damage(Dervs(D_SAT), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), 0, Me, T)
			If d > 0 Then attstr = " hits you for " & d & " damage."
			If d <= 0 Then attstr = " swings and misses."
			
		ElseIf s = "FireBomb" Then 
			d = Damage(Dervs(D_SAT), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), F_FIRE, Me, T)
			If d > 0 Then attstr = " throws a Fire Bomb at you for " & d & " fire damage."
			If d <= 0 Then attstr = " misses you with a Fire Bomb."
			longrange = 1
			
		ElseIf s = "Throw Sand" Then 
			frmCombat.AddEvent(("The " & Me.Name & " throws sand in your eyes!"))
			d = Damage(-1, 3, 0, 0, F_BLND, (frmCombat.Enemy), (frmCombat.Player))
			Exit Function
			longrange = 1
			
		ElseIf s = "Leap" Then 
			d = Damage(Dervs(D_SAT), Dervs(D_DAM) * 1.1, T.Dervs(D_DEF), T.Dervs(D_DR), 0, Me, T)
			If d <= 0 Then attstr = " leaps at you, but misses."
			If d > 0 Then attstr = " leaps at your throat, biting for " & d & " damage."
			frmCombat.ETime = frmCombat.ETime - 100
			
		ElseIf s = "Bite" Then 
			d = Damage(Dervs(D_SAT), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), 0, Me, T)
			If d <= 0 Then attstr = " tries to bite you, but misses."
			If d > 0 Then attstr = " lunges and bites you for " & d & " damage."
			
		ElseIf s = "Claw" Then 
			d = Damage(Dervs(D_SAT), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), 0, Me, T)
			If d <= 0 Then attstr = " tries to claw you, but misses."
			If d > 0 Then attstr = " claws you for " & d & " damage."
			frmCombat.ETime = frmCombat.ETime + 100
			
		ElseIf s = "Spear" Then 
			d = Damage(Dervs(D_SAT), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), F_PIRC, Me, T)
			If d <= 0 Then attstr = " thrusts its spear at you, but misses."
			If d > 0 Then attstr = " stabs you with its spear for " & d & " damage."
			
		ElseIf s = "Pincer" Then 
			d = Damage(Dervs(D_SAT), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), F_PIRC, Me, T)
			If d > 0 Then attstr = " pinches for " & d & " damage."
			If d <= 0 Then attstr = " tries to pinch you, but misses."
			
		ElseIf s = "Poison Sting" Then 
			d = Damage(Dervs(D_SAT), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), F_POIS, Me, T)
			If d <= 0 Then attstr = " barely scratches you with its deadly stinger."
			If d > 0 Then attstr = " stings you viciously for " & d & " damage."
			
		ElseIf s = "Spit Poison" Then 
			frmCombat.AddEvent(("The " & Me.Name & " spits poison at your eyes."))
			d = Damage(-1, Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), F_POIS, Me, T)
			longrange = 1
			
		ElseIf s = "Stone Gaze" Then 
			frmCombat.AddEvent(("The " & Me.Name & " gazes deep into your eyes."))
			d = Damage(-1, 3, 0, 0, F_SLOW, Me, T)
			longrange = 1
			Exit Function
			
		ElseIf s = "Flame Thrower" Then 
			d = Damage(Dervs(D_SAT), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), F_FIRE, Me, T)
			If d <= 0 Then attstr = " blasts streams of flame at you, but misses."
			If d > 0 Then attstr = " blasts you with streams of flame for " & d & " damage."
			longrange = 1
			
		ElseIf s = "Ice Blast" Then 
			d = Damage(Dervs(D_SAT), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), F_COLD, Me, T)
			If d <= 0 Then attstr = " fires shards of ice at you, but misses."
			If d > 0 Then attstr = " slashes you with shards of ice for " & d & " damage."
			longrange = 1
			
		ElseIf s = "Mana Storm" Then 
			d = Damage(Dervs(D_SAT), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), F_MAGI, Me, T)
			If d <= 0 Then attstr = " fires streams of pure mana at you, but misses."
			If d > 0 Then attstr = " hurls streams of pure mana at you for " & d & " damage."
			longrange = 1
			
		ElseIf s = "Sand Blaster" Then 
			d = Damage(Dervs(D_SAT) + 10, Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), F_CONF, Me, T)
			If d <= 0 Then attstr = " narrowly misses you with gouts of sand."
			If d > 0 Then attstr = " hits you with a stream of sand for " & d & " damage."
			longrange = 1
			
		ElseIf s = "Illusion" Then 
			frmCombat.AddEvent(("The " & Me.Name & " tries to confuse you with an illusion."))
			d = Damage(-1, Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), F_CONF, Me, T)
			longrange = 1
			
		ElseIf s = "Scream" Then 
			frmCombat.AddEvent(("The " & Me.Name & " screams at you wildly."))
			d = Damage(-1, Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), F_CONF, Me, T)
			longrange = 1
			
		ElseIf s = "Heal" Then 
			d = (Int(Rnd() * (Me.Depth + 1)) + (Me.Depth + 1) \ 2) * (Int(Rnd() * 3) + 2)
			'UPGRADE_WARNING: Couldn't resolve default property of object Min(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Me.Dervs(D_CHP) = Min(Me.Dervs(D_HTP), Me.Dervs(D_CHP) + d)
			frmCombat.AddEvent(("The " & Me.Name & " heals " & d & " damage."))
			Exit Function
			
		ElseIf s = "Three-Quarters" Then 
			'UPGRADE_WARNING: Couldn't resolve default property of object Max(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			d = Max(1, CDbl(T.Dervs(D_CHP)) * 0.75)
			T.Dervs(D_CHP) = d
			attstr = " blasts your hit points down to three-quarters."
			
		ElseIf s = "Half" Then 
			'UPGRADE_WARNING: Couldn't resolve default property of object Max(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			d = Max(1, CDbl(T.Dervs(D_CHP)) * 0.5)
			T.Dervs(D_CHP) = d
			attstr = " blasts your hit points in half."
			
		ElseIf s = "Quarter" Then 
			'UPGRADE_WARNING: Couldn't resolve default property of object Max(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			d = Max(1, CDbl(T.Dervs(D_CHP)) * 0.25)
			T.Dervs(D_CHP) = d
			attstr = " quarters your hit-points."
			
		ElseIf s = "Increase Speed" Then 
			d = Int(Rnd() * 10) + 1
			Dervs(D_SPD) = Dervs(D_SPD) * (1 + (d / 100))
			attstr = " begins to move faster!"
			d = 0
			
		ElseIf s = "Increase Attack" Then 
			d = Int(Rnd() * 10) + 1
			Dervs(D_SAT) = Dervs(D_SAT) * (1 + (d / 100))
			attstr = " begins to attack more fiercely!"
			d = 0
			
		ElseIf s = "Blade Tornado" Then 
			frmCombat.AddEvent(("The " & Me.Name & " attacks you with Blade Tornado!"))
			For i = 0 To Dervs(D_DAM)
				d = Damage(Dervs(D_SAT), 1, T.Dervs(D_DEF), 0, 0, Me, T)
				If d <= 0 Then frmCombat.AddEvent(("The Blade Tornado misses!"))
				If d > 0 Then frmCombat.AddEvent(("The Blade Tornado hits you for " & d & " damage."))
			Next i
			Exit Function
			
		ElseIf s = "NinjaStr" Then 
			d = Damage(Dervs(D_SAT), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), 0, Me, T)
			If Int(Rnd() * 5) = 0 And d > 0 Then
				d = d + Damage(Dervs(D_SAT), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), 0, Me, T)
				frmCombat.AddEvent(("Critical Hit!"))
			End If
			If d > 0 Then attstr = " slashes you for " & d & " damage."
			If d <= 0 Then attstr = " slashes at you, but misses."
			
		ElseIf s = "Shatter" Then 
			d = Damage(Dervs(D_SAT) * 2, Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), 0, Me, T)
			Dervs(D_CHP) = 0
			attstr = " shatters, showering you with shards for " & d & " damage."
			
		ElseIf s = "Solar Flare" Then 
			d = Damage(Dervs(D_SAT) + 10, Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), F_FIRE, Me, T)
			If d > 0 Then attstr = " scorches you with a Solar Flare for " & d & " damage."
			longrange = 1
			
		ElseIf s = "Solar Eclipse" Then 
			d = Damage(-1, 3, T.Dervs(D_DEF), T.Dervs(D_DR), F_BLND, Me, T)
			attstr = " casts Solar Eclipse!"
			longrange = 1
			
		ElseIf s = "Steal" Then 
			d = TG(Me.Depth - 1) 'Int(1.2 ^ Me.Depth) * Int(Rnd * 10 + (60 - 3 * CDbl(Me.Depth)))
			'UPGRADE_WARNING: Couldn't resolve default property of object Max(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			d = Max(d, Int(Rnd() * 10 + Rnd() * 10))
			'UPGRADE_WARNING: Couldn't resolve default property of object Max(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			char_Renamed.Player.Gold = Max(char_Renamed.Player.Gold - d, 0)
			If char_Renamed.Player.Gold = 0 Then
				attstr = " steals all your gold!"
			Else
				attstr = " steals " & d & " gold from you, leaving you with " & char_Renamed.Player.Gold & "!"
			End If
			
		ElseIf s = "Sleep" Then 
			frmCombat.AddEvent(("The " & Me.Name & " emits a cloud of sleeping gas."))
			d = Damage(-1, Dervs(D_DAM) \ 2, T.Dervs(D_DEF), T.Dervs(D_DR), F_SLEP, Me, T)
			longrange = 1
			Exit Function
			
		ElseIf s = "Three Wishes" Then 
			d = Damage(Dervs(D_SAT), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR) \ 2, F_FIRE Or F_ELEC Or F_MAGI, Me, T)
			attstr = " makes Three Wishes against you for " & d & " damage."
			longrange = 1
			
		ElseIf s = "Stun Attack" Then 
			d = Damage(Dervs(D_SAT), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), F_STUN, Me, T)
			If d <= 0 Then attstr = " almost caves your head in!"
			If d > 0 Then attstr = " smashes you in the head for " & d & " damage."
			
		ElseIf s = "Dragon Bite" Then 
			d = Damage(Dervs(D_SAT), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), F_PIRC, Me, T)
			If d > 0 Then attstr = " bites you for " & d & " damage."
			If d <= 0 Then attstr = " snaps at you, but misses."
			
		ElseIf s = "Dragon Claw" Then 
			d = Damage(Dervs(D_SAT), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), 0, Me, T)
			If d > 0 Then attstr = " slashes you with its claws for " & d & " damage."
			If d <= 0 Then attstr = " swipes at you, but misses."
			
		ElseIf s = "Blue Dragon Breath" Then 
			d = Damage(32000, Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), F_ELEC, Me, T)
			If d > 0 Then attstr = " breathes lightning at you for " & d & " damage."
			If d <= 0 Then attstr = " breathes lightning at you, but misses."
			longrange = 1
			
		ElseIf s = "Green Dragon Breath" Then 
			d = Damage(32000, Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), F_POIS, Me, T)
			If d > 0 Then attstr = " breathes poison gas at you for " & d & " damage."
			If d <= 0 Then attstr = " breathes poison gas at you, but misses."
			longrange = 1
			
		ElseIf s = "Brass Dragon Breath" Then 
			d = Damage(32000, Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), F_SLEP, Me, T)
			If d > 0 Then attstr = " breathes sleep gas at you for " & d & " damage."
			If d <= 0 Then attstr = " breathes sleep gas at you, but misses."
			longrange = 1
			
		ElseIf s = "Copper Dragon Breath" Then 
			d = Damage(32000, Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), F_SLOW, Me, T)
			If d > 0 Then attstr = " breathes sleep gas at you for " & d & " damage."
			If d <= 0 Then attstr = " breathes sleep gas at you, but misses."
			longrange = 1
			
		ElseIf s = "Hell Fury" Then 
			d = Damage(Dervs(D_SAT), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), F_FIRE Or F_MAGI, Me, T)
			If d <= 0 Then attstr = " releases Hell's Fury at you, but misses."
			If d > 0 Then attstr = " releases Hell's Fury at you for " & d & " damage."
			longrange = 1
			
		ElseIf s = "Death" Then 
			T.Counts(N_DETH) = 10
			attstr = " calls the Reaper for your soul."
			
		ElseIf s = "Drain" Then 
			d = Damage(Dervs(D_SAT), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), F_COLD, Me, T)
			Dervs(D_CHP) = Dervs(D_CHP) + d
			If d > 0 Then attstr = " drains " & d & " hit points from you with a freezing touch."
			If d <= 0 Then attstr = " reaches out to touch you."
			
		ElseIf s = "Charge" Then 
			d = Damage(Dervs(D_SAT), Dervs(D_DAM) * 2, T.Dervs(D_DEF), T.Dervs(D_DR), 0, Me, T)
			If d > 0 Then attstr = " charges and hits you for " & d & " damage."
			If d <= 0 Then attstr = " charges at you, but misses."
			frmCombat.ETime = frmCombat.ETime - 1000
			
		ElseIf s = "Dive" Then 
			d = Damage(Dervs(D_SAT), Dervs(D_DAM) * 2, T.Dervs(D_DEF), T.Dervs(D_DR), 0, Me, T)
			If d > 0 Then attstr = " dives at you for " & d & " damage."
			If d <= 0 Then attstr = " dives at you, but misses."
			frmCombat.ETime = frmCombat.ETime - 1000
			
		ElseIf s = "Magic Dust" Then 
			d = Damage(-1, 0, T.Dervs(D_DEF), T.Dervs(D_DR), F_BLND, Me, T)
			attstr = " throws magic dust in your eyes!"
			longrange = 1
			
		ElseIf s = "Blinding Flash" Then 
			d = Damage(Dervs(D_SAT), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), F_BLND, Me, T)
			If d > 0 Then attstr = " pierces your skull with blinding light for " & d & " damage."
			If d <= 0 Then attstr = " blasts you with blinding light, but misses."
			longrange = 1
			
		ElseIf s = "Entangle" Then 
			frmCombat.AddEvent(("The " & Me.Name & " commands the plants to Entangle you!"))
			d = Damage(-1, 3, 0, 0, F_SLOW, Me, T)
			Exit Function
			
		ElseIf s = "Constrict" Then 
			frmCombat.AddEvent(("The " & Me.Name & " constricts your breathing!"))
			d = Damage(-1, 3, 0, 0, F_SLOW, Me, T)
			Exit Function
			
		ElseIf s = "Invisible" Then 
			frmCombat.AddEvent(("The " & Me.Name & " fades from visibility."))
			'UPGRADE_WARNING: Couldn't resolve default property of object Max(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Me.Counts(N_INVS) = Max(Me.Counts(N_INVS), Int(Rnd() * 5) + 1)
			longrange = 1
			Exit Function
			
		ElseIf s = "Electric Shock" Then 
			d = Damage(Dervs(D_SAT), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), F_ELEC, Me, T)
			If d > 0 Then attstr = " electrocutes you for " & d & " damage."
			If d <= 0 Then attstr = " shoots bolts of electricity at you, but misses."
			longrange = 1
			
		ElseIf s = "Cattle Prod" Then 
			d = Damage(Dervs(D_SAT), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), F_ELEC, Me, T)
			If d > 0 Then attstr = " hits you with a cattle prod you for " & d & " damage."
			If d <= 0 Then attstr = " swings at you with a cattle prod, but misses."
			
		ElseIf s = "Splinters" Then 
			d = Damage(Dervs(D_SAT), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), F_PIRC, Me, T)
			If d > 0 Then attstr = " riddles you with Splinters for " & d & " damage."
			If d <= 0 Then attstr = " fires Splinters at you, but misses."
			longrange = 1
			
		ElseIf s = "Swallow" Then 
			d = Damage(Dervs(D_SAT), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), 0, Me, T)
			If d > 0 Then attstr = " swallows you whole for " & d & " damage."
			If d <= 0 Then attstr = " tries to swallow you whole, but you escape."
			
		ElseIf s = "Bow" Then 
			d = Damage(Dervs(D_SAT), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), 0, Me, T)
			If d > 0 Then attstr = " hits you with an arrow for " & d & " damage."
			If d <= 0 Then attstr = " fires an arrow at you, but misses."
			frmCombat.ETime = frmCombat.ETime + 500
			longrange = 1
			
		ElseIf s = "Nail" Then 
			d = Damage(Dervs(D_SAT), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), 0, Me, T)
			If d > 0 Then attstr = " launches a nail at you for " & d & " damage."
			If d <= 0 Then attstr = " launches a nail at you, but misses."
			frmCombat.ETime = frmCombat.ETime + 250
			longrange = 1
			
		ElseIf s = "Throw Rock" Then 
			d = Damage(Dervs(D_SAT), Dervs(D_DAM), T.Dervs(D_DEF), CShort(T.Dervs(D_DR) * 1.5), 0, Me, T)
			If d > 0 Then attstr = " hits you with a rock for " & d & " damage."
			If d <= 0 Then attstr = " throws a rock at you, but misses."
			frmCombat.ETime = frmCombat.ETime + 500
			longrange = 1
			
		ElseIf s = "Lasso" Then 
			d = Damage(Dervs(D_SAT), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), F_STUN, Me, T)
			If d <= 0 Then attstr = " tries to lasso you, but misses!"
			If d > 0 Then attstr = " lassos you and drags you to the ground for " & d & " damage."
			
		ElseIf s = "Blowgun" Then 
			frmCombat.AddEvent(("The " & Me.Name & " shoots you with a blowgun."))
			d = Damage(-1, Dervs(D_DAM) \ 2, T.Dervs(D_DEF), T.Dervs(D_DR), F_SLEP, Me, T)
			longrange = 1
			Exit Function
			
		ElseIf s = "Swarm" Then 
			frmCombat.AddEvent(("The " & Me.Name & " surrounds you!"))
			For i = 0 To Dervs(D_DAM)
				d = Damage(Dervs(D_SAT), 1, T.Dervs(D_DEF), 0, 0, Me, T)
				If d <= 0 Then frmCombat.AddEvent(("The " & Me.Name & " misses!"))
				If d > 0 Then frmCombat.AddEvent(("The " & Me.Name & " hits you for " & d & " damage."))
			Next i
			longrange = 1
			Exit Function
			
		ElseIf s = "Earthquake" Then 
			d = Damage(Dervs(D_SAT), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), F_STUN, Me, T)
			If d <= 0 Then attstr = " shakes the ground beneath you!"
			If d > 0 Then attstr = " quakes you to the ground for " & d & " damage."
			longrange = 1
			
		ElseIf s = "Hurl Corpse" Then 
			d = Damage(32000, Dervs(D_DAM) \ 2, T.Dervs(D_DEF), T.Dervs(D_DR), F_POIS, Me, T)
			If d <= 0 Then attstr = " hurls a corpse at you, but misses."
			If d > 0 Then attstr = " hurls a corpse at you for " & d & " damage."
			longrange = 1
			
		ElseIf s = "Suck Blood" Then 
			d = Damage(Dervs(D_SAT), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), 0, Me, T)
			'UPGRADE_WARNING: Couldn't resolve default property of object Min(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Dervs(D_CHP) = Min(Dervs(D_CHP) + d, Dervs(D_HTP))
			If d <= 0 Then attstr = " tries to suck your blood, but misses!"
			If d > 0 Then attstr = " drains your blood for " & d & " damage."
			
		ElseIf s = "Moo" Then 
			d = Damage(-1, 0, T.Dervs(D_DEF), T.Dervs(D_DR), F_SLEP, Me, T)
			attstr = " moos you to sleep!"
			longrange = 1
			
		Else
			attstr = " does nothing. {" & s & "}"
		End If
		
		If attstr <> "" Then
			DoAttack = "The " & Me.Name & attstr
			If d <> 0 And longrange = 0 And T.Dervs(D_DMS) <> 0 And (Not Flags And F_LONG) Then
				DoAttack = DoAttack & " " & Damage(100, T.Dervs(D_DMS), 0, 0, 0, T, Me) & " point counter."
			End If
		Else
			DoAttack = ""
		End If
	End Function
	
	
	Public Property Counts(ByVal i As Short) As Short
		Get
			Counts = Counters(i)
		End Get
		Set(ByVal Value As Short)
			Counters(i) = Value
		End Set
	End Property
	
	'Public Property Let Flags(i As long, v As long)
	'  FlagsEffects(i) = v
	'End Property
	
	'Public Property Get Flags(i As long) As long
	'  Flags = FlagsEffects(i)
	'End Property
	
	
	
	Public Property Dervs(ByVal i As Short) As Short
		Get
			Dervs = Derived(i)
		End Get
		Set(ByVal Value As Short)
			Derived(i) = Value
		End Set
	End Property
	
	
	Public Property AttP(ByVal i As Short) As Short
		Get
			AttP = AttPers(i)
		End Get
		Set(ByVal Value As Short)
			AttPers(i) = Value
		End Set
	End Property
	
	
	Public Property Atts(ByVal i As Short) As String
		Get
			Atts = Attacks(i)
		End Get
		Set(ByVal Value As String)
			Attacks(i) = Value
		End Set
	End Property
	
	
	
	Public Property Res(ByVal i As Short) As Short
		Get
			Res = Resistances(i)
		End Get
		Set(ByVal Value As Short)
			Resistances(i) = Value
		End Set
	End Property
End Class