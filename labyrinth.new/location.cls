VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "Location"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Option Explicit
Public Name As String
Private LinkTo(0 To 4) As Integer
Public Terrain As Integer
Public Region As Integer
Public RegionName As String
Public Owner As Integer
Public Explored As Integer
Public Known As Integer
Public LCity As City
Public Road As Integer
Public RoadFrom As Integer
Public Depth As Integer
Public level As Integer
Public Loc As Integer
Public xx As Single
Public yy As Single
Public aa As Single
Public rr As Double

'Public Done As long

Public Sub GenerateCity(Optional Size As Integer = -1)
  Set LCity = New City
  Call LCity.MakeCity(Me.Loc, Size)
End Sub

Public Property Let Link(i As Integer, v As Integer)
  LinkTo(i) = v
End Property

Public Property Get Link(i As Integer) As Integer
  Link = LinkTo(i)
End Property

Private Sub Class_Initialize()
  Dim i As Integer
  Terrain = Int(Rnd * 8)
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
