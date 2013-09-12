Option Strict Off
Option Explicit On
Friend Class frmMap
	Inherits System.Windows.Forms.Form
	Private Sub frmMap_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Click
		DrawMap()
	End Sub
	
	Private Sub frmMap_GotFocus(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.GotFocus
		DrawMap()
	End Sub
	
	Private Sub frmMap_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'  DrawMap
	End Sub
	
	Public Sub DrawMap()
		Dim i As Short
		Dim j As Short
		Dim xx As Short
		Dim yy As Short
		Dim source As Location
		Dim dest As Location
		Dim lastlevel As Short
		Dim lastdepth As Short
		Dim lloc As Short
		Dim Color As Short
		Dim Wide As Short
		Dim baselevel As Short
		Dim dep, dep2 As Object
		Dim depdif As Short
		
		xx = 0
		yy = 0
		lastlevel = 0
		lloc = Loc_Renamed
		Wide = 10
		
		For i = 0 To C_LOCS - 1
			'    If Abs(World.World(i).Depth - World.World(lloc).Depth) <= 2 Then
			'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			baselevel = World_Renamed.World(i).level - World_Renamed.World(lloc).level
			'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If World_Renamed.World(i).level = lastlevel Then
				yy = yy + 300
			Else
				yy = 300
				'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				lastdepth = World_Renamed.World(i).level
			End If
			xx = ((baselevel) * CInt(500)) + 5400 '+ ((i Mod 50) * 10)
			'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			lastlevel = World_Renamed.World(i).level
			'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			World_Renamed.World(i).xx = xx
			'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			World_Renamed.World(i).yy = yy
			'    End If
		Next i
		
		For i = 0 To C_LOCS - 1
			'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If System.Math.Abs(World_Renamed.World(i).level - World_Renamed.World(lloc).level) <= Wide Then
				
				For j = 0 To 4
					'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If World_Renamed.World(i).Link(j) <> -1 Then
						'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						If i < World_Renamed.World(i).Link(j) And System.Math.Abs(World_Renamed.World(i).level - World_Renamed.World(lloc).level) <= Wide Then 'And Abs(World.World(i).Level - World.World(lloc).Level) <> 0 Then
							'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							source = World_Renamed.World(i)
							'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							dest = World_Renamed.World(World_Renamed.World(i).Link(j))
							'            If i = lloc Then
							'              Line (source.xx, source.yy)-(dest.xx, dest.yy), RGB(200, 120, 0)
							'            Else
							'UPGRADE_ISSUE: Form method frmMap.Line was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
							Me.Line (source.xx, source.yy) - (dest.xx, dest.yy), RGB(120, 120, 0)
							'            End If
						End If
					End If
				Next j
			End If
		Next i
		
		For j = 0 To 4
			'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If World_Renamed.World(lloc).Link(j) <> -1 Then
				'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				source = World_Renamed.World(lloc)
				'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				dest = World_Renamed.World(World_Renamed.World(lloc).Link(j))
				'UPGRADE_ISSUE: Form method frmMap.Line was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				Me.Line (source.xx, source.yy) - (dest.xx, dest.yy), RGB(255, 120, 0)
				'UPGRADE_ISSUE: Form method frmMap.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				Me.Circle (dest.xx, dest.yy), 100, RGB(255, 120, 0)
			End If
		Next j
		
		For i = 0 To C_LOCS - 1
			'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If System.Math.Abs(World_Renamed.World(i).level - World_Renamed.World(lloc).level) <= Wide Then
				
				'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object dep. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				dep = World_Renamed.World(lloc).Depth
				'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object dep2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				dep2 = World_Renamed.World(i).Depth
				'UPGRADE_WARNING: Couldn't resolve default property of object dep. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object dep2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				depdif = dep2 - dep
				'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				xx = World_Renamed.World(i).xx
				'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				yy = World_Renamed.World(i).yy
				
				'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If World_Renamed.World(i).Terrain = T_DES Then
					Color = RGB(255, 255, 30)
					'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf World_Renamed.World(i).Terrain = T_FOR Then 
					Color = RGB(0, 180, 0)
					'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf World_Renamed.World(i).Terrain = T_HIL Then 
					Color = RGB(160, 160, 0)
					'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf World_Renamed.World(i).Terrain = T_JUN Then 
					Color = RGB(180, 80, 180)
					'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf World_Renamed.World(i).Terrain = T_MTN Then 
					Color = RGB(180, 50, 0)
					'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf World_Renamed.World(i).Terrain = T_PLN Then 
					Color = RGB(0, 230, 0)
					'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf World_Renamed.World(i).Terrain = T_SWP Then 
					Color = RGB(0, 120, 120)
					'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf World_Renamed.World(i).Terrain = T_TUN Then 
					Color = RGB(200, 200, 200)
				Else
					Color = RGB(255, 0, 0)
				End If
				
				'      Red = depdif * 50 + 125
				'      Blue = -depdif * 50 + 125
				'      Green = (2 - Abs(depdif)) * 100 + 25
				'UPGRADE_ISSUE: Form method frmMap.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				Me.Circle (xx, yy), 40, Color
				If i = lloc Then
					'UPGRADE_ISSUE: Form method frmMap.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					Me.Circle (xx, yy), 100, RGB(255, 255, 255)
				End If
				'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If World_Renamed.World(i).LCity.T = "City" Then
					'UPGRADE_ISSUE: Form method frmMap.Line was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					Me.Line (xx - 10, yy - 10) - (xx + 10, yy + 10), RGB(255, 255, 255), BF
				End If
			End If
		Next i
		
	End Sub
End Class