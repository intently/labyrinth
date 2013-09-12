Option Strict Off
Option Explicit On
Friend Class frmRad
	Inherits System.Windows.Forms.Form
	Private Const MaxWide As Short = 20
	Private Wide As Short
	Private Spread As Double
	Private ALL As Double
	Private VisAreas As Short
	Private links As Short
	
	Private Sub cmdZoomIn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdZoomIn.Click
		If Wide > 2 Then
			Wide = Wide - 1
		End If
		Spread = 9000 / (2 * Wide - 1)
		DrawMap()
	End Sub
	
	Private Sub cmdZoomOut_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdZoomOut.Click
		If Wide < MaxWide Then
			Wide = Wide + 1
		End If
		Spread = 9000 / (2 * Wide - 1)
		DrawMap()
	End Sub
	
	Private Sub frmRad_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Click
		DrawMap()
	End Sub
	
	Private Sub frmRad_GotFocus(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.GotFocus
		DrawMap()
	End Sub
	
	Private Sub frmRad_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'  DrawMap
		Wide = frmGame.Wide
		Spread = 9000 / (2 * Wide - 1)
	End Sub
	
	Public Sub DrawMap()
		Dim i As Short
		Dim j As Short
		Dim xx As Double
		Dim yy As Double
		Dim rr As Double
		Dim aa As Double
		Dim source As Location
		Dim dest As Location
		Dim lastlevel As Short
		Dim lastdepth As Short
		Dim lloc As Short
		Dim Color As Integer
		Dim onroute(C_LOCS - 1) As Short
		Dim Count(MaxWide - 1) As Short
		Dim Used(C_LOCS - 1) As Short 'MaxWide - 1) As long
		Dim kids(C_LOCS - 1) As Short
		Dim dep, dep2 As Object
		Dim depdif As Short
		
		Dim Pi As Double
		
		Pi = 3.14159265358979
		links = 0
		ALL = 0
		VisAreas = 0
		Me.Width = VB6.TwipsToPixelsX(9200) '(2 * Wide - 1) * Spread + 200
		Me.Height = VB6.TwipsToPixelsY(9200) '(2 * Wide - 1) * Spread + 200
		lbZoom.Text = "Zoom Factor: " & Wide
		'UPGRADE_ISSUE: Form method frmRad.Cls was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		frmRad.Cls()
		
		xx = 0
		yy = 0
		lastlevel = 0
		lloc = Loc_Renamed
		
		Call CalcRoute(Str(lloc), 1, Wide - 1) ' Str(lloc)
		
		For i = 0 To C_LOCS - 1
			If old(i) < Wide Then
				Count(old(i)) = Count(old(i)) + 1
			End If
			If path(i) <> -1 Then
				kids(path(i)) = kids(path(i)) + 1
			End If
			
			'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			World_Renamed.World(i).xx = 0
			'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			World_Renamed.World(i).yy = 0
			'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			World_Renamed.World(i).aa = 0
			'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			World_Renamed.World(i).rr = 0
			
			If i < C_RMAX Then
				If curroute(i) <> -1 Then
					onroute(curroute(i)) = 1
				End If
			End If
		Next i
		
		' calculate radial positions
		Dim avail As Double
		For i = 0 To C_LOCS - 1
			If old(i) <> C_LOCS Then
				
				If path(i) <> -1 Then
					'        avail = 2 * Pi * kids(path(i)) / (Count(old(i)) + Count(old(i) - 1))
					avail = 2 * Pi / (Count(old(i) - 1))
					If old(i) > 1 Then
						'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						aa = ((avail / (kids(path(i)) + 1)) * (Used(path(i)) + 1)) + World_Renamed.World(path(i)).aa - (avail / 2)
					Else
						'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						aa = ((avail / (kids(path(i)))) * Used(path(i))) + World_Renamed.World(path(i)).aa
					End If
					Used(path(i)) = Used(path(i)) + 1
				Else
					avail = 2 * Pi
					aa = 0
				End If
				rr = old(i) * Spread
				xx = ((VB6.PixelsToTwipsX(Me.Width) / 2)) + rr * System.Math.Cos(aa)
				yy = ((VB6.PixelsToTwipsY(Me.Height) / 2) - 150) + rr * System.Math.Sin(aa)
				'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				World_Renamed.World(i).xx = xx
				'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				World_Renamed.World(i).yy = yy
				'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				World_Renamed.World(i).aa = aa
				'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				World_Renamed.World(i).rr = rr
				
				'      aa = (2# * CDbl(Used(old(i))) * Pi) / CDbl(Count(old(i))) - (Pi / CDbl(2)) '- (CDbl(old(i) - 1) * Pi / CDbl(Wide))
				'      rr = old(i) * Spread
				'      xx = ((frmRad.Width / 2)) + rr * Cos(aa)
				'      yy = ((frmRad.Height / 2) - 150) + rr * Sin(aa)
				'      World.World(i).xx = xx
				'      World.World(i).yy = yy
				'      World.World(i).aa = aa
				'      World.World(i).rr = rr
				'      Used(old(i)) = Used(old(i)) + 1
			End If
		Next i
		
		For i = 0 To C_LOCS - 1
			If old(i) <> C_LOCS Then
				For j = 0 To 4
					'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If World_Renamed.World(i).Link(j) <> -1 Then
						' "<>" below was "<", check if paths to lesser unexplored sectors are drawn
						'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						If i <> World_Renamed.World(i).Link(j) And old(World_Renamed.World(i).Link(j)) <> C_LOCS Then 'And Abs(World.World(i).Level - World.World(lloc).Level) <> 0 Then
							'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							source = World_Renamed.World(i)
							'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							dest = World_Renamed.World(World_Renamed.World(i).Link(j))
							If source.Explored = 1 Or frmGame.ckCombat.CheckState = 1 Then
								If dest.Explored = 1 Then
									'UPGRADE_ISSUE: Form property frmRad.DrawStyle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
									frmRad.DrawStyle = 0
								Else
									'UPGRADE_ISSUE: Form property frmRad.DrawStyle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
									frmRad.DrawStyle = 2
								End If
								ALL = ALL + System.Math.Sqrt((source.xx - dest.xx) ^ 2 + (source.yy - dest.yy) ^ 2)
								links = links + 1
								'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								If onroute(i) = 1 And onroute(World_Renamed.World(i).Link(j)) = 1 Then
									'UPGRADE_ISSUE: Form method frmRad.Line was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
									Me.Line (source.xx, source.yy) - (dest.xx, dest.yy), RGB(255, 255, 255)
								ElseIf source.Road = 1 And dest.Road = 1 Then 
									'UPGRADE_ISSUE: Form method frmRad.Line was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
									Me.Line (source.xx, source.yy) - (dest.xx, dest.yy), RGB(140, 140, 140)
								Else
									'UPGRADE_ISSUE: Form method frmRad.Line was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
									Me.Line (source.xx, source.yy) - (dest.xx, dest.yy), RGB(140, 110, 0)
								End If
							End If
							
						End If
					End If
				Next j
			End If
		Next i
		
		'UPGRADE_ISSUE: Form property frmRad.DrawStyle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		frmRad.DrawStyle = 0
		
		VisAreas = 0
		
		For j = 0 To 4
			'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If World_Renamed.World(lloc).Link(j) <> -1 Then
				'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If old(World_Renamed.World(lloc).Link(j)) <> C_LOCS Then
					'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					source = World_Renamed.World(lloc)
					'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					dest = World_Renamed.World(World_Renamed.World(lloc).Link(j))
					'UPGRADE_ISSUE: Form method frmRad.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					Me.Circle (dest.xx, dest.yy), 100, RGB(255, 120, 0)
					ForeColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
					'UPGRADE_ISSUE: Form property frmRad.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					CurrentX = dest.xx - 150
					'UPGRADE_ISSUE: Form property frmRad.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					CurrentY = dest.yy - 300
					'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_ISSUE: Form method frmRad.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					Print(World_Renamed.World(lloc).Link(j))
				End If
			End If
		Next j
		
		For i = 0 To C_LOCS - 1
			If old(i) <> C_LOCS Then
				
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
				
				'      If World.World(i).Explored = 0 And World.World(i).Known = 0 Then
				'        Color = RGB(80, 80, 80)
				'      Else
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
				'UPGRADE_ISSUE: Form method frmRad.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				Me.Circle (xx, yy), 40, Color
				'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If World_Renamed.World(i).Explored = 1 Or frmGame.ckCombat.CheckState = 1 Then
					ForeColor = System.Drawing.ColorTranslator.FromOle(Color)
					'UPGRADE_ISSUE: Form property frmRad.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					CurrentX = xx - 150
					'UPGRADE_ISSUE: Form property frmRad.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					CurrentY = yy - 300
					'UPGRADE_ISSUE: Form method frmRad.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					Print(CStr(i))
				End If
				
				'      If World.World(i).Explored = 0 Then
				'        Circle (xx, yy), 30, RGB(140, 140, 140)
				'      End If
				If i = lloc Then
					'UPGRADE_ISSUE: Form method frmRad.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					Me.Circle (xx, yy), 100, RGB(255, 255, 255)
				End If
				'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Not World_Renamed.World(i).LCity Is Nothing Then
					'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If World_Renamed.World(i).LCity.T = "City" Then
						'UPGRADE_ISSUE: Form method frmRad.Line was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
						Me.Line (xx - 10, yy - 10) - (xx + 10, yy + 10), RGB(255, 255, 255), BF
					End If
				End If
				VisAreas = VisAreas + 1
			End If
		Next i
		lbZones.Text = "Visible Areas: " & VisAreas
		'UPGRADE_WARNING: Couldn't resolve default property of object Max(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		lbALL.Text = "ALL: " & System.Math.Round(ALL / Max(links, 1), 0)
	End Sub
	
	Private Sub frmRad_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		frmGame.Wide = Wide
	End Sub
	
	Private Sub frmRad_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim keyascii As Short = Asc(eventArgs.KeyChar)
		If keyascii = 27 Then
			Me.Close()
		ElseIf keyascii = Asc("o") Or keyascii = Asc("O") Then 
			Call cmdZoomOut_Click(cmdZoomOut, New System.EventArgs())
		ElseIf keyascii = Asc("i") Or keyascii = Asc("I") Then 
			Call cmdZoomIn_Click(cmdZoomIn, New System.EventArgs())
		End If
		eventArgs.KeyChar = Chr(keyascii)
		If keyascii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
End Class