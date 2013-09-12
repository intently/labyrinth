Option Strict Off
Option Explicit On
Friend Class Location
	Public Name As String
	Private LinkTo(4) As Short
	Public Terrain As Short
	Public Region As Short
	Public RegionName As String
	Public Owner As Short
	Public Explored As Short
	Public Known As Short
	Public LCity As City
	Public Road As Short
	Public RoadFrom As Short
	Public Depth As Short
	Public level As Short
	'UPGRADE_NOTE: Loc was upgraded to Loc_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Public Loc_Renamed As Short
	Public xx As Single
	Public yy As Single
	Public aa As Single
	Public rr As Double
	
	'Public Done As long
	
	Public Sub GenerateCity(Optional ByRef Size As Short = -1)
		LCity = New City
		Call LCity.MakeCity(Me.Loc_Renamed, Size)
	End Sub
	
	
	Public Property Link(ByVal i As Short) As Short
		Get
			Link = LinkTo(i)
		End Get
		Set(ByVal Value As Short)
			LinkTo(i) = Value
		End Set
	End Property
	
	'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub Class_Initialize_Renamed()
		Dim i As Short
		Terrain = Int(Rnd() * 8)
		Owner = -1
		For i = 0 To 4
			LinkTo(i) = -1
		Next i
		Region = -1
		Explored = 0
		Road = 0
		RoadFrom = -1
		Depth = -1
		'  Done = 0
		
		'  Set LCity = New City
	End Sub
	Public Sub New()
		MyBase.New()
		Class_Initialize_Renamed()
	End Sub
End Class