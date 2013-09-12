Option Strict Off
Option Explicit On
Friend Class Person
	Public Name As String
	Public T As String
	'UPGRADE_NOTE: Loc was upgraded to Loc_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Public Loc_Renamed As Short
	Public RoadChance As Short
	Public NoRoadChance As Short
	Public PrefTer As Short
	Public TerChance As Short
	Public NoTerChance As Short
	Private K(C_LOCS - 1) As Short
	Public Desc As String
	Public Greed As Short
	Public Quality As Short
	Public LastExplored As Date
	Public it As Item
	
	'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Public Sub Class_Initialize_Renamed()
		Name = "None"
		T = "None"
		Loc_Renamed = -1
		RoadChance = 0
		NoRoadChance = 0
	End Sub
	Public Sub New()
		MyBase.New()
		Class_Initialize_Renamed()
	End Sub
	
	Public Sub MakeMerchant(ByRef l As Short, ByRef n As String)
		Name = n & " the Merchant" & Int(Rnd() * 10000)
		T = "Merchant"
		Loc_Renamed = l
		RoadChance = 90
		NoRoadChance = 20
		PrefTer = T_ALL
		Desc = Name & "'s business seems to be going well this season.  His wagons are fully loaded and his people look well fed.  He looks like he is resting his caravan only momentarily before moving on."
		Greed = 75
		Quality = 1
	End Sub
	
	Public Sub MakeGypsy(ByRef l As Short, ByRef n As String)
		Name = n & " the Gypsy" & Int(Rnd() * 10000)
		T = "Gypsy"
		Loc_Renamed = l
		RoadChance = 20
		NoRoadChance = 90
		PrefTer = T_ALL
		Desc = Name & "'s gypsy band is here.  Several wagons are scattered about in a loose circle, and gypsies are roaming about, performing their daily business, whatever that is."
		Greed = 50
		Quality = -1
	End Sub
	
	Public Sub MakeTaxidermist(ByRef l As Short, ByRef n As String)
		Name = n & " the Taxidermist" & Int(Rnd() * 10000)
		T = "Taxidermist"
		Loc_Renamed = l
		RoadChance = 90
		NoRoadChance = 90
		PrefTer = T_ALL
		Desc = Name & " is camped here.  Racks of skins and body parts lie scattered about in a macabre sort of zoo."
		Greed = 100
		Quality = 0
	End Sub
	
	Public Sub MakeGuards(ByRef l As Short, ByRef n As String)
		Name = n & " City Guards"
		T = "Guards"
		Loc_Renamed = l
		RoadChance = 100
		NoRoadChance = 0
		PrefTer = T_ALL
		Desc = "The " & Name & " are here, patrolling the road.  They are well-equipped and well-armed, and look determined to keep the peace."
		Greed = 125
		Quality = 2
	End Sub
	
	
	Public Property Known(ByVal i As Short) As Short
		Get
			Known = K(i)
		End Get
		Set(ByVal Value As Short)
			K(i) = Value
		End Set
	End Property
End Class