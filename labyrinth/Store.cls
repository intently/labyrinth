VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "Store"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Option Explicit
Public T As Integer
Public Depth As Integer
Public Loc As Integer
Private Inventory(0 To C_INVMAX - 1) As Item
Private TradeGoodsPrices(0 To G_MAX - 1) As Double

Public Sub Stock()
  Dim it As Item
  Dim i As Integer
  Dim j As Integer
   
  If Me.T < C_STORES Then
    For i = 0 To (C_INVMAX \ 2) - 1
      j = Int(Rnd * C_INVMAX) \ 2
      If Me.Inven(j) Is Nothing Then
        Set it = New Item
        If Me.T = S_MRK Then
          Call it.Create(Me.T, Me.Depth, , Loc)
        Else
          Call it.Create(Me.T, Me.Depth) ', Me.Depth - 3)
        End If
        it.ID = True
  '      If It.Value > (Me.Depth + 1) * C_VALUEPERLEVEL Then
  '        i = i - 1
  '      Else
          If World.World(Loc).LCity.T <> "City" And it.Use = E_SER Then it.Value = it.Value * 2

          Call AddInven(it)
  '      End If
      ElseIf (Not Me.Inven(j) Is Nothing) Then
        Me.Inven(j) = Nothing
      End If
    Next i
    TGP(G_WEPS) = TGP(G_WEPS) * (0.8 + Rnd * 0.4)
  Else
    If Me.T = S_TRAN Then
      For i = 0 To (C_INVMAX \ 4) - 1
        j = Int(Rnd * C_INVMAX) \ 2
        If Me.Inven(j) Is Nothing Then
          Set it = New Item
          Call it.Create(Me.T, 20, 0, 100) ', Me.Depth - 3)
          it.ID = False
          it.Value = it.Value \ 2
          Call AddInven(it)
        ElseIf (Not Me.Inven(j) Is Nothing) Then
          Me.Inven(j) = Nothing
        End If
      Next i
    ElseIf Me.T = S_ACAD Then
      For i = 0 To (C_INVMAX \ 4) - 1
        j = Int(Rnd * C_INVMAX) \ 2
        If Me.Inven(j) Is Nothing Then
          Set it = New Item
          Call it.Create(Me.T, 20, 0, 100) ', Me.Depth - 3)
          it.ID = True
          Call AddInven(it)
        ElseIf (Not Me.Inven(j) Is Nothing) Then
          Me.Inven(j) = Nothing
        End If
      Next i
    ElseIf Me.T = S_TEMP Then
      For i = 0 To (C_INVMAX \ 4) - 1
        j = Int(Rnd * C_INVMAX) \ 2
        If Me.Inven(j) Is Nothing Then
          Set it = New Item
          Call it.Create(Me.T, 0, 0, 0)
          it.Value = 0
          it.ID = True
          Call AddInven(it)
        ElseIf (Not Me.Inven(j) Is Nothing) Then
          Me.Inven(j) = Nothing
        End If
      Next i
    ElseIf Me.T = S_CARN Then
      For i = 0 To (C_INVMAX \ 4) - 1
        j = Int(Rnd * C_INVMAX) \ 2
        If Me.Inven(j) Is Nothing Then
          Set it = New Item
          Call it.Create(Me.T, 0, 0, 0)
          it.Value = 0
          it.ID = True
          Call AddInven(it)
        ElseIf (Not Me.Inven(j) Is Nothing) Then
          Me.Inven(j) = Nothing
        End If
      Next i
    ElseIf Me.T = S_CAST Then
      For i = 0 To (C_INVMAX \ 4) - 1
        j = Int(Rnd * C_INVMAX) \ 2
        If Me.Inven(j) Is Nothing Then
          Set it = New Item
          Call it.Create(Me.T, Me.Depth) ', Me.Depth - 3)
          it.ID = True
          it.Value = Int(it.Value / I_MANT)
          Call AddInven(it)
        ElseIf (Not Me.Inven(j) Is Nothing) Then
          Me.Inven(j) = Nothing
        End If
      Next i
    End If
  End If
End Sub

Public Function AddInven(T As Item, Optional n As Integer = -1) As Integer
  Dim i As Integer
  Dim ans As VbMsgBoxResult
tryagain:
'  For i = 0 To C_INVMAX - 1
'    If Not Me.Inven(i) Is Nothing Then
'      If Me.Inven(i).Text = T.Text And Me.Inven(i).Use = E_NON And T.Use = E_NON Then
'        If n = -1 Then
'          Me.Inven(i).num = Me.Inven(i).num + T.num
'          AddInven = i
'          Set T = Nothing
'        Else
'          Me.Inven(i).num = Me.Inven(i).num + n
'          AddInven = i
'        End If
'        Exit Function
'      End If
'    End If
'  Next i
  For i = 0 To C_INVMAX - 1
    If Me.Inven(i) Is Nothing Then
      Me.Inven(i) = T
      AddInven = i
'      T.ID = True
'      Set T = Nothing
      Exit Function
    End If
  Next i
  AddInven = -1
End Function

Public Function RemInven(T As Item, Optional n As Integer = -1) As Integer
  Dim i As Integer
  
  For i = 0 To C_INVMAX - 1
    If Me.Inven(i) Is T Then
      Me.Inven(i) = Nothing
      RemInven = i
      Exit Function
    End If
  Next i

End Function

Public Sub TGPSet()
  If World.World(Me.Loc).Terrain = T_FOR Then
    TGP(G_WOOD) = 0.5
    TGP(G_FOOD) = 0.75
    TGP(G_ORES) = 1
    TGP(G_GEMS) = 1.5
    TGP(G_ARTS) = 1.25
    TGP(G_WEPS) = 1
    TGP(G_MEDS) = 0.9
  ElseIf World.World(Me.Loc).Terrain = T_DES Then
    TGP(G_WOOD) = 1.5
    TGP(G_FOOD) = 1.5
    TGP(G_ORES) = 1.25
    TGP(G_GEMS) = 0.9
    TGP(G_ARTS) = 1
    TGP(G_WEPS) = 1
    TGP(G_MEDS) = 1.25
  ElseIf World.World(Me.Loc).Terrain = T_PLN Then
    TGP(G_WOOD) = 1
    TGP(G_FOOD) = 0.5
    TGP(G_ORES) = 1.1
    TGP(G_GEMS) = 1.1
    TGP(G_ARTS) = 1.3
    TGP(G_WEPS) = 1
    TGP(G_MEDS) = 1
  ElseIf World.World(Me.Loc).Terrain = T_HIL Then
    TGP(G_WOOD) = 1.1
    TGP(G_FOOD) = 0.75
    TGP(G_ORES) = 0.75
    TGP(G_GEMS) = 0.8
    TGP(G_ARTS) = 1
    TGP(G_WEPS) = 1
    TGP(G_MEDS) = 0.9
  ElseIf World.World(Me.Loc).Terrain = T_JUN Then
    TGP(G_WOOD) = 0.65
    TGP(G_FOOD) = 0.8
    TGP(G_ORES) = 1.2
    TGP(G_GEMS) = 1.5
    TGP(G_ARTS) = 0.75
    TGP(G_WEPS) = 1
    TGP(G_MEDS) = 0.5
  ElseIf World.World(Me.Loc).Terrain = T_MTN Then
    TGP(G_WOOD) = 1
    TGP(G_FOOD) = 1.5
    TGP(G_ORES) = 0.5
    TGP(G_GEMS) = 0.6
    TGP(G_ARTS) = 0.9
    TGP(G_WEPS) = 1
    TGP(G_MEDS) = 1.5
  ElseIf World.World(Me.Loc).Terrain = T_SWP Then
    TGP(G_WOOD) = 0.9
    TGP(G_FOOD) = 1.2
    TGP(G_ORES) = 1.5
    TGP(G_GEMS) = 1.1
    TGP(G_ARTS) = 0.6
    TGP(G_WEPS) = 1
    TGP(G_MEDS) = 0.65
  ElseIf World.World(Me.Loc).Terrain = T_TUN Then
    TGP(G_WOOD) = 0.8
    TGP(G_FOOD) = 1.3
    TGP(G_ORES) = 1.25
    TGP(G_GEMS) = 0.75
    TGP(G_ARTS) = 1
    TGP(G_WEPS) = 1
    TGP(G_MEDS) = 1.25
  End If
End Sub

Public Property Let Inven(i As Integer, v As Item)
  Set Inventory(i) = v
End Property

Public Property Get Inven(i As Integer) As Item
'  If Inventory(i) = 0 Then
'    Set Inven = Nothing
'   Else
    Set Inven = Inventory(i)
'  End If
End Property
Public Property Let TGP(i As Integer, v As Double)
  TradeGoodsPrices(i) = v
End Property

Public Property Get TGP(i As Integer) As Double
'  If Inventory(i) = 0 Then
'    Set Inven = Nothing
'   Else
    TGP = TradeGoodsPrices(i)
'  End If
End Property

