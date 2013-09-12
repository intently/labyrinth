VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "Person"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Option Explicit
Public Name As String
Public T As String
Public Loc As Integer
Public RoadChance As Integer
Public NoRoadChance As Integer
Public PrefTer As Integer
Public TerChance As Integer
Public NoTerChance As Integer
Private K(0 To C_LOCS - 1) As Integer
Public Desc As String
Public Greed As Integer
Public Quality As Integer
Public LastExplored As Date
Public it As Item

Public Sub Class_Initialize()
  Name = "None"
  T = "None"
  Loc = -1
  RoadChance = 0
  NoRoadChance = 0
End Sub

Public Sub MakeMerchant(l As Integer, n As String)
  Name = n & " the Merchant" & Int(Rnd * 10000)
  T = "Merchant"
  Loc = l
  RoadChance = 90
  NoRoadChance = 20
  PrefTer = T_ALL
  Desc = Name & "'s business seems to be going well this season.  His wagons are fully loaded and his people look well fed.  He looks like he is resting his caravan only momentarily before moving on."
  Greed = 75
  Quality = 1
End Sub

Public Sub MakeGypsy(l As Integer, n As String)
  Name = n & " the Gypsy" & Int(Rnd * 10000)
  T = "Gypsy"
  Loc = l
  RoadChance = 20
  NoRoadChance = 90
  PrefTer = T_ALL
  Desc = Name & "'s gypsy band is here.  Several wagons are scattered about in a loose circle, and gypsies are roaming about, performing their daily business, whatever that is."
  Greed = 50
  Quality = -1
End Sub

Public Sub MakeTaxidermist(l As Integer, n As String)
  Name = n & " the Taxidermist" & Int(Rnd * 10000)
  T = "Taxidermist"
  Loc = l
  RoadChance = 90
  NoRoadChance = 90
  PrefTer = T_ALL
  Desc = Name & " is camped here.  Racks of skins and body parts lie scattered about in a macabre sort of zoo."
  Greed = 100
  Quality = 0
End Sub

Public Sub MakeGuards(l As Integer, n As String)
  Name = n & " City Guards"
  T = "Guards"
  Loc = l
  RoadChance = 100
  NoRoadChance = 0
  PrefTer = T_ALL
  Desc = "The " & Name & " are here, patrolling the road.  They are well-equipped and well-armed, and look determined to keep the peace."
  Greed = 125
  Quality = 2
End Sub

Public Property Let Known(i As Integer, v As Integer)
  K(i) = v
End Property

Public Property Get Known(i As Integer) As Integer
  Known = K(i)
End Property

