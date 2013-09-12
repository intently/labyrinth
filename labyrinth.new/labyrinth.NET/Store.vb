Option Strict Off
Option Explicit On
Friend Class Store
	Public T As Short
	Public Depth As Short
	'UPGRADE_NOTE: Loc was upgraded to Loc_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Public Loc_Renamed As Short
	Private Inventory(C_INVMAX - 1) As Item
	Private TradeGoodsPrices(G_MAX - 1) As Double
	
	Public Sub Stock()
		Dim it As Item
		Dim i As Short
		Dim j As Short
		
		If Me.T < C_STORES Then
			For i = 0 To (C_INVMAX \ 2) - 1
				j = Int(Rnd() * C_INVMAX) \ 2
				If Me.Inven(j) Is Nothing Then
					it = New Item
					If Me.T = S_MRK Then
						Call it.Create(Me.T, Me.Depth,  , Loc_Renamed)
					Else
						Call it.Create(Me.T, Me.Depth) ', Me.Depth - 3)
					End If
					it.ID = True
					'      If It.Value > (Me.Depth + 1) * C_VALUEPERLEVEL Then
					'        i = i - 1
					'      Else
					'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If World_Renamed.World(Loc_Renamed).LCity.T <> "City" And it.Use = E_SER Then it.Value = it.Value * 2
					
					Call AddInven(it)
					'      End If
				ElseIf (Not Me.Inven(j) Is Nothing) Then 
					'UPGRADE_NOTE: Object Me.Inven() may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
					'UPGRADE_WARNING: Couldn't resolve default property of object Me.Inven(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Me.Inven(j) = Nothing
				End If
			Next i
			TGP(G_WEPS) = TGP(G_WEPS) * (0.8 + Rnd() * 0.4)
		Else
			If Me.T = S_TRAN Then
				For i = 0 To (C_INVMAX \ 4) - 1
					j = Int(Rnd() * C_INVMAX) \ 2
					If Me.Inven(j) Is Nothing Then
						it = New Item
						Call it.Create(Me.T, 20, 0, 100) ', Me.Depth - 3)
						it.ID = False
						it.Value = it.Value \ 2
						Call AddInven(it)
					ElseIf (Not Me.Inven(j) Is Nothing) Then 
						'UPGRADE_NOTE: Object Me.Inven() may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
						'UPGRADE_WARNING: Couldn't resolve default property of object Me.Inven(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Me.Inven(j) = Nothing
					End If
				Next i
			ElseIf Me.T = S_ACAD Then 
				For i = 0 To (C_INVMAX \ 4) - 1
					j = Int(Rnd() * C_INVMAX) \ 2
					If Me.Inven(j) Is Nothing Then
						it = New Item
						Call it.Create(Me.T, 20, 0, 100) ', Me.Depth - 3)
						it.ID = True
						Call AddInven(it)
					ElseIf (Not Me.Inven(j) Is Nothing) Then 
						'UPGRADE_NOTE: Object Me.Inven() may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
						'UPGRADE_WARNING: Couldn't resolve default property of object Me.Inven(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Me.Inven(j) = Nothing
					End If
				Next i
			ElseIf Me.T = S_TEMP Then 
				For i = 0 To (C_INVMAX \ 4) - 1
					j = Int(Rnd() * C_INVMAX) \ 2
					If Me.Inven(j) Is Nothing Then
						it = New Item
						Call it.Create(Me.T, 0, 0, 0)
						it.Value = 0
						it.ID = True
						Call AddInven(it)
					ElseIf (Not Me.Inven(j) Is Nothing) Then 
						'UPGRADE_NOTE: Object Me.Inven() may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
						'UPGRADE_WARNING: Couldn't resolve default property of object Me.Inven(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Me.Inven(j) = Nothing
					End If
				Next i
			ElseIf Me.T = S_CARN Then 
				For i = 0 To (C_INVMAX \ 4) - 1
					j = Int(Rnd() * C_INVMAX) \ 2
					If Me.Inven(j) Is Nothing Then
						it = New Item
						Call it.Create(Me.T, 0, 0, 0)
						it.Value = 0
						it.ID = True
						Call AddInven(it)
					ElseIf (Not Me.Inven(j) Is Nothing) Then 
						'UPGRADE_NOTE: Object Me.Inven() may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
						'UPGRADE_WARNING: Couldn't resolve default property of object Me.Inven(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Me.Inven(j) = Nothing
					End If
				Next i
			ElseIf Me.T = S_CAST Then 
				For i = 0 To (C_INVMAX \ 4) - 1
					j = Int(Rnd() * C_INVMAX) \ 2
					If Me.Inven(j) Is Nothing Then
						it = New Item
						Call it.Create(Me.T, Me.Depth) ', Me.Depth - 3)
						it.ID = True
						it.Value = Int(it.Value / I_MANT)
						Call AddInven(it)
					ElseIf (Not Me.Inven(j) Is Nothing) Then 
						'UPGRADE_NOTE: Object Me.Inven() may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
						'UPGRADE_WARNING: Couldn't resolve default property of object Me.Inven(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Me.Inven(j) = Nothing
					End If
				Next i
			End If
		End If
	End Sub
	
	Public Function AddInven(ByRef T As Item, Optional ByRef n As Short = -1) As Short
		Dim i As Short
		Dim ans As MsgBoxResult
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
				'UPGRADE_WARNING: Couldn't resolve default property of object Me.Inven(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Me.Inven(i) = T
				AddInven = i
				'      T.ID = True
				'      Set T = Nothing
				Exit Function
			End If
		Next i
		AddInven = -1
	End Function
	
	Public Function RemInven(ByRef T As Item, Optional ByRef n As Short = -1) As Short
		Dim i As Short
		
		For i = 0 To C_INVMAX - 1
			If Me.Inven(i) Is T Then
				'UPGRADE_NOTE: Object Me.Inven() may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				'UPGRADE_WARNING: Couldn't resolve default property of object Me.Inven(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Me.Inven(i) = Nothing
				RemInven = i
				Exit Function
			End If
		Next i
		
	End Function
	
	Public Sub TGPSet()
		'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If World_Renamed.World(Me.Loc_Renamed).Terrain = T_FOR Then
			TGP(G_WOOD) = 0.5
			TGP(G_FOOD) = 0.75
			TGP(G_ORES) = 1
			TGP(G_GEMS) = 1.5
			TGP(G_ARTS) = 1.25
			TGP(G_WEPS) = 1
			TGP(G_MEDS) = 0.9
			'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ElseIf World_Renamed.World(Me.Loc_Renamed).Terrain = T_DES Then 
			TGP(G_WOOD) = 1.5
			TGP(G_FOOD) = 1.5
			TGP(G_ORES) = 1.25
			TGP(G_GEMS) = 0.9
			TGP(G_ARTS) = 1
			TGP(G_WEPS) = 1
			TGP(G_MEDS) = 1.25
			'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ElseIf World_Renamed.World(Me.Loc_Renamed).Terrain = T_PLN Then 
			TGP(G_WOOD) = 1
			TGP(G_FOOD) = 0.5
			TGP(G_ORES) = 1.1
			TGP(G_GEMS) = 1.1
			TGP(G_ARTS) = 1.3
			TGP(G_WEPS) = 1
			TGP(G_MEDS) = 1
			'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ElseIf World_Renamed.World(Me.Loc_Renamed).Terrain = T_HIL Then 
			TGP(G_WOOD) = 1.1
			TGP(G_FOOD) = 0.75
			TGP(G_ORES) = 0.75
			TGP(G_GEMS) = 0.8
			TGP(G_ARTS) = 1
			TGP(G_WEPS) = 1
			TGP(G_MEDS) = 0.9
			'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ElseIf World_Renamed.World(Me.Loc_Renamed).Terrain = T_JUN Then 
			TGP(G_WOOD) = 0.65
			TGP(G_FOOD) = 0.8
			TGP(G_ORES) = 1.2
			TGP(G_GEMS) = 1.5
			TGP(G_ARTS) = 0.75
			TGP(G_WEPS) = 1
			TGP(G_MEDS) = 0.5
			'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ElseIf World_Renamed.World(Me.Loc_Renamed).Terrain = T_MTN Then 
			TGP(G_WOOD) = 1
			TGP(G_FOOD) = 1.5
			TGP(G_ORES) = 0.5
			TGP(G_GEMS) = 0.6
			TGP(G_ARTS) = 0.9
			TGP(G_WEPS) = 1
			TGP(G_MEDS) = 1.5
			'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ElseIf World_Renamed.World(Me.Loc_Renamed).Terrain = T_SWP Then 
			TGP(G_WOOD) = 0.9
			TGP(G_FOOD) = 1.2
			TGP(G_ORES) = 1.5
			TGP(G_GEMS) = 1.1
			TGP(G_ARTS) = 0.6
			TGP(G_WEPS) = 1
			TGP(G_MEDS) = 0.65
			'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ElseIf World_Renamed.World(Me.Loc_Renamed).Terrain = T_TUN Then 
			TGP(G_WOOD) = 0.8
			TGP(G_FOOD) = 1.3
			TGP(G_ORES) = 1.25
			TGP(G_GEMS) = 0.75
			TGP(G_ARTS) = 1
			TGP(G_WEPS) = 1
			TGP(G_MEDS) = 1.25
		End If
	End Sub
	
	
	Public Property Inven(ByVal i As Short) As Item
		Get
			'  If Inventory(i) = 0 Then
			'    Set Inven = Nothing
			'   Else
			Inven = Inventory(i)
			'  End If
		End Get
		Set(ByVal Value As Item)
			Inventory(i) = Value
		End Set
	End Property
	
	Public Property TGP(ByVal i As Short) As Double
		Get
			'  If Inventory(i) = 0 Then
			'    Set Inven = Nothing
			'   Else
			TGP = TradeGoodsPrices(i)
			'  End If
		End Get
		Set(ByVal Value As Double)
			TradeGoodsPrices(i) = Value
		End Set
	End Property
End Class