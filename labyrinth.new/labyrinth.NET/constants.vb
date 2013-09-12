Option Strict Off
Option Explicit On
'UPGRADE_NOTE: constants was upgraded to constants_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
Module constants_Renamed
	'Base 0
	
	Public Const C_HARDDEATH As Short = 0
	Public Const C_MAXCONNECTS As Short = 5
	Public Const C_LOCS As Short = 1000
	Public Const C_INVMAX As Short = 100
	Public Const C_WAGONMAX As Short = 20
	Public Const C_RMAX As Short = 100
	Public Const C_SAMETERRAINCHANCE As Short = 100
	Public Const C_DIFTERRAINCHANCE As Short = 20
	Public Const C_MAXATTACKS As Short = 5
	Public Const C_STOREINVENTARGET As Short = 30
	Public Const C_VALUEPERLEVEL As Single = 600
	Public Const C_ARM_COST As Single = 0.5
	Public Const C_WEP_COST As Single = 0.5
	Public Const C_PEOPLE As Short = 100
	Public Const C_TMANT As Double = 1.5
	Public Const C_KILLSECTOR As Short = 0
	
	Public Const C_STATS As Short = 7
	Public Const S_STR As Short = 0 ' strength
	Public Const S_DEX As Short = 1 ' dexterity
	Public Const S_CON As Short = 2 ' constitution
	Public Const S_INT As Short = 3 ' intelligence
	Public Const S_WIS As Short = 4 ' wisdom
	Public Const S_CHA As Short = 5 ' charisma
	Public Const S_REP As Short = 6 ' reputation
	
	Public Const D_SAT As Short = 0
	Public Const D_DAT As Short = 1
	Public Const D_DEF As Short = 2
	Public Const D_HTP As Short = 3
	Public Const D_SPD As Short = 4
	Public Const D_PER As Short = 5
	Public Const D_LUK As Short = 6
	Public Const D_DAM As Short = 7
	Public Const D_DR As Short = 8
	Public Const D_CHP As Short = 9
	Public Const D_DMS As Short = 10
	
	Public Const E_WEP As Short = 0
	Public Const E_ARM As Short = 1
	Public Const E_SLD As Short = 2
	Public Const E_HLM As Short = 3
	Public Const E_GNT As Short = 4
	Public Const E_BTS As Short = 5
	Public Const E_RG1 As Short = 6
	Public Const E_RG2 As Short = 7
	Public Const E_NON As Short = 8
	Public Const E_SER As Short = 9
	Public Const E_TRD As Short = 10
	
	Public Const T_FOR As Short = 0 ' forest, wood
	Public Const T_DES As Short = 1 ' desert, oil
	Public Const T_PLN As Short = 2 ' plains, food
	Public Const T_HIL As Short = 3 ' hills,  ore
	Public Const T_JUN As Short = 4 ' jungle, artifacts, wood
	Public Const T_MTN As Short = 5 ' mountains, ore, gems
	Public Const T_SWP As Short = 6 ' swamp,  artifacts
	Public Const T_TUN As Short = 7 ' tundra, oil
	Public Const T_ALL As Short = 8
	Public Const T_GHOST As Short = 9
	Public Const T_GOBLIN As Short = 10
	Public Const T_MAX As Short = 10
	Public Const T_MAXUSED As Short = 3
	
	Public Const G_WOOD As Short = 0
	Public Const G_FOOD As Short = 1
	Public Const G_ORES As Short = 2
	Public Const G_GEMS As Short = 3
	Public Const G_ARTS As Short = 4
	Public Const G_WEPS As Short = 5
	Public Const G_MEDS As Short = 6
	Public Const G_MAX As Short = 7
	
	Public Const C_FLAGS As Integer = 17 ' attack flags
	Public Const F_FIRE As Integer = 1
	Public Const F_COLD As Integer = 2
	Public Const F_ELEC As Integer = 4
	Public Const F_CONF As Integer = 8
	Public Const F_PIRC As Integer = 16
	Public Const F_SLOW As Integer = 32
	Public Const F_POIS As Integer = 64
	Public Const F_MAGI As Integer = 128
	Public Const F_FAST As Integer = 256
	Public Const F_BLND As Integer = 512
	Public Const F_SLEP As Integer = 1024
	Public Const F_STUN As Integer = 2048
	Public Const F_REGN As Integer = 4096
	Public Const F_LIFE As Integer = 8192
	Public Const F_HYPR As Integer = 16384
	Public Const F_VAMP As Integer = 32768
	Public Const F_TRUE As Integer = 65536
	Public Const F_LONG As Integer = 131072
	
	Public Const C_RESISTS As Short = 4
	Public Const R_FIRE As Short = 0
	Public Const R_COLD As Short = 1
	Public Const R_ELEC As Short = 2
	Public Const R_MAGI As Short = 3
	
	Public Const C_COUNTERS As Short = 15
	Public Const N_POIS As Short = 0
	Public Const N_FIRE As Short = 1
	Public Const N_COLD As Short = 2
	Public Const N_FAST As Short = 3
	Public Const N_SLOW As Short = 4
	Public Const N_INVS As Short = 5
	Public Const N_IVLN As Short = 6
	Public Const N_REGN As Short = 7
	Public Const N_DETH As Short = 8
	Public Const N_CONF As Short = 9
	Public Const N_BLND As Short = 10
	Public Const N_SLEP As Short = 11
	Public Const N_STUN As Short = 12
	Public Const N_BLES As Short = 13
	Public Const N_PROT As Short = 14
	
	Public Const C_STORES As Short = 6
	Public Const S_WEP As Short = 0
	Public Const S_ARM As Short = 1
	Public Const S_GEN As Short = 2
	Public Const S_MAG As Short = 3
	Public Const S_INN As Short = 4
	Public Const S_MRK As Short = 5
	
	Public Const S_TRAN As Short = 6
	Public Const S_ACAD As Short = 7
	Public Const S_CARN As Short = 8
	Public Const S_TEMP As Short = 9
	Public Const S_CAST As Short = 10
	
	Public Const C_SPELLS As Short = 14
	Public Const M_MMIS As Short = 0
	Public Const M_HEAL As Short = 1
	Public Const M_TELE As Short = 2
	Public Const M_STUN As Short = 3
	Public Const M_TOWN As Short = 4
	Public Const M_FAST As Short = 5
	Public Const M_SLOW As Short = 6
	Public Const M_BLES As Short = 7
	Public Const M_FIRE As Short = 8
	Public Const M_COLD As Short = 9
	Public Const M_ELEC As Short = 10
	Public Const M_SPRK As Short = 11
	Public Const M_FLEE As Short = 12
	Public Const M_PROT As Short = 13
	
	Public Const M_SPRK_C As Short = 50
	Public Const M_SPRK_D As Short = 0
	Public Const M_PROT_C As Short = 100
	Public Const M_PROT_D As Short = 1
	Public Const M_MMIS_C As Short = 100
	Public Const M_MMIS_D As Short = 2
	Public Const M_FLEE_C As Short = 150
	Public Const M_FLEE_D As Short = 3
	Public Const M_HEAL_C As Short = 200
	Public Const M_HEAL_D As Short = 4
	Public Const M_FIRE_C As Short = 500
	Public Const M_FIRE_D As Short = 5
	Public Const M_COLD_C As Short = 500
	Public Const M_COLD_D As Short = 5
	Public Const M_ELEC_C As Short = 500
	Public Const M_ELEC_D As Short = 5
	Public Const M_TELE_C As Short = 300
	Public Const M_TELE_D As Short = 6
	Public Const M_BLES_C As Short = 1000
	Public Const M_BLES_D As Short = 7
	Public Const M_STUN_C As Short = 600
	Public Const M_STUN_D As Short = 8
	Public Const M_FAST_C As Short = 300
	Public Const M_FAST_D As Short = 9
	Public Const M_SLOW_C As Short = 300
	Public Const M_SLOW_D As Short = 9
	Public Const M_TOWN_C As Short = 500
	Public Const M_TOWN_D As Short = 10
	
	Public Const E_SAT As Short = 12
	Public Const E_DAT As Short = 11
	Public Const E_DEF As Short = 10
	Public Const E_HTP As Short = 10
	Public Const E_SPD As Short = 10
	Public Const E_DAM As Short = 3
	Public Const E_DR As Short = 2
	Public Const E_POINTS As Short = 40
	
	Public Const I_ATT As Short = 11
	Public Const I_DAM As Short = 16
	Public Const I_DEF As Short = 16
	Public Const I_DR As Short = 30
	Public Const I_STAT As Short = 30
	Public Const I_RES As Short = 15
	Public Const I_BASE As Short = 100
	Public Const I_FLAG As Short = 750
	Public Const I_MANT As Double = 1.5
	
	Public Const B_CAST As Short = 6
	Public Const B_WALL As Short = 0
	Public Const B_FARM As Short = 1
	Public Const B_MARK As Short = 2
	Public Const B_TRAN As Short = 3
	Public Const B_BANK As Short = 4
	Public Const B_SPEC As Short = 5
	
	
	Public Function Min(ByRef A As Object, ByRef b As Object) As Object
		'UPGRADE_WARNING: Couldn't resolve default property of object b. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object A. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If A < b Then
			'UPGRADE_WARNING: Couldn't resolve default property of object A. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object Min. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Min = A
		Else
			'UPGRADE_WARNING: Couldn't resolve default property of object b. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object Min. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Min = b
		End If
	End Function
	
	Public Function Max(ByRef A As Object, ByRef b As Object) As Object
		'UPGRADE_WARNING: Couldn't resolve default property of object b. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object A. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If A > b Then
			'UPGRADE_WARNING: Couldn't resolve default property of object A. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object Max. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Max = A
		Else
			'UPGRADE_WARNING: Couldn't resolve default property of object b. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object Max. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Max = b
		End If
	End Function
	
	Public Function TG(ByRef T As Short) As Integer
		TG = CInt(C_TMANT ^ T) * CInt(Rnd() * 20 + (60 - 3 * T))
		'UPGRADE_WARNING: Couldn't resolve default property of object Min(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		TG = TG * Min(Max(0.5, (char_Renamed.Player.Dervs(D_LUK) + char_Renamed.Player.Dervs(D_PER)) / (2 * char_Renamed.Player.Stats(S_REP) + 10)), 2)
		TG = CInt(TG)
	End Function
	
	Public Function Dice(ByRef num As Short, ByRef sides As Short) As Short
		Dim i As Short
		
		For i = 0 To num - 1
			Dice = Dice + Int(Rnd() * sides) + 1
		Next i
	End Function
	
	Public Function PM(ByVal n As Object, ByVal A As Short) As Integer
		'UPGRADE_WARNING: Couldn't resolve default property of object n. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		PM = CInt((CDbl(n) * (1# - (CDbl(A) / 100#))) + (Rnd() * 2# * (CDbl(A) / 100#) * CDbl(n)))
	End Function
	
	Public Function Price(ByRef it As Integer, ByRef h As Short) As Integer
		Dim m As Short
		'UPGRADE_WARNING: Couldn't resolve default property of object Min(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		m = Min(600, char_Renamed.Player.Dervs(D_PER) + char_Renamed.Player.Reals(S_CHA) + char_Renamed.Player.Reals(S_REP))
		
		' 1 = player buy price, 0 = player sell price
		If h = 1 Then
			Price = it * ((1200 - m) / 600)
		ElseIf h = 0 Then 
			Price = it * ((600 + m) / 1200)
		End If
	End Function
	
	Public Function TGPrice(ByRef it As Item, ByRef st As Store, ByRef h As Short) As Integer
		Dim m As Short
		
		'UPGRADE_WARNING: Couldn't resolve default property of object Min(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		m = Min(1000, (char_Renamed.Player.Dervs(D_PER) + char_Renamed.Player.Reals(S_CHA) + char_Renamed.Player.Reals(S_REP) + char_Renamed.Player.Dervs(S_INT) * 2) / 4 + 750)
		
		' 1 = buy price, 0 = sell price
		If h = 1 Then
			TGPrice = it.Value * ((2000 - m) / 1000) * st.TGP((it.Att))
		ElseIf h = 0 Then 
			TGPrice = it.Value * ((1000 + m) / 2000) * st.TGP((it.Att))
		End If
	End Function
	
	Public Sub DispMonster(ByRef Mo As Monster, ByRef off As Short)
		Dim tx As String
		Dim i As Short
		
		tx = ""
		tx = tx & "Name:" & vbTab & Mo.Name & vbCrLf
		tx = tx & "Terrain:" & vbTab & TerName((Mo.Terrain)) & vbCrLf
		tx = tx & "Depth:" & vbTab & PM(Mo.Depth, off) & vbCrLf
		tx = tx & "Killed:" & vbTab & Player.KH((Mo.Terrain), (Mo.Depth)) & vbCrLf
		tx = tx & "Studied:" & vbTab & CBool(Player.KL((Mo.Terrain), (Mo.Depth))) & vbCrLf & vbCrLf
		
		tx = tx & "Attack:" & vbTab & PM(Mo.Dervs(D_SAT), off) & vbCrLf
		tx = tx & "Damage:" & vbTab & PM(Mo.Dervs(D_DAM), off) & vbCrLf
		tx = tx & "Speed:" & vbTab & PM(Mo.Dervs(D_SPD), off) & vbCrLf
		tx = tx & "Defense:" & vbTab & PM(Mo.Dervs(D_DEF), off) & vbCrLf
		tx = tx & "DR:" & vbTab & PM(Mo.Dervs(D_DR), off) & vbCrLf
		tx = tx & "Cur HP:" & vbTab & PM(Mo.Dervs(D_CHP), off) & vbCrLf
		tx = tx & "Max HP:" & vbTab & PM(Mo.Dervs(D_HTP), off) & vbCrLf & vbCrLf
		
		tx = tx & "Attacks:" & vbCrLf
		
		For i = 0 To C_MAXATTACKS - 1
			If Mo.Atts(i) <> "" And char_Renamed.Player.KH((Mo.Terrain), (Mo.Depth)) + char_Renamed.Player.KL((Mo.Terrain), (Mo.Depth)) > 50 - Mo.AttP(i) Then
				tx = tx & vbTab & Mo.Atts(i) & vbCrLf
			End If
		Next i
		
		tx = tx & vbCrLf
		
		If Mo.Res(R_MAGI) < 0 And char_Renamed.Player.KH((Mo.Terrain), (Mo.Depth)) + char_Renamed.Player.KL((Mo.Terrain), (Mo.Depth)) > 50 + Mo.Res(R_MAGI) Then
			tx = tx & "Weak against Magic" & vbCrLf
		ElseIf Mo.Res(R_MAGI) > 0 And char_Renamed.Player.KH((Mo.Terrain), (Mo.Depth)) + char_Renamed.Player.KL((Mo.Terrain), (Mo.Depth)) > 50 - Mo.Res(R_MAGI) Then 
			tx = tx & "Resistant to Magic" & vbCrLf
		End If
		If Mo.Res(R_FIRE) < 0 And char_Renamed.Player.KH((Mo.Terrain), (Mo.Depth)) + char_Renamed.Player.KL((Mo.Terrain), (Mo.Depth)) > 50 + Mo.Res(R_FIRE) Then
			tx = tx & "Weak against Fire" & vbCrLf
		ElseIf Mo.Res(R_FIRE) > 0 And char_Renamed.Player.KH((Mo.Terrain), (Mo.Depth)) + char_Renamed.Player.KL((Mo.Terrain), (Mo.Depth)) > 50 - Mo.Res(R_FIRE) Then 
			tx = tx & "Resistant to Fire" & vbCrLf
		End If
		If Mo.Res(R_COLD) < 0 And char_Renamed.Player.KH((Mo.Terrain), (Mo.Depth)) + char_Renamed.Player.KL((Mo.Terrain), (Mo.Depth)) > 50 + Mo.Res(R_COLD) Then
			tx = tx & "Weak against Cold" & vbCrLf
		ElseIf Mo.Res(R_COLD) > 0 And char_Renamed.Player.KH((Mo.Terrain), (Mo.Depth)) + char_Renamed.Player.KL((Mo.Terrain), (Mo.Depth)) > 50 - Mo.Res(R_COLD) Then 
			tx = tx & "Resistant to Cold" & vbCrLf
		End If
		If Mo.Res(R_ELEC) < 0 And char_Renamed.Player.KH((Mo.Terrain), (Mo.Depth)) + char_Renamed.Player.KL((Mo.Terrain), (Mo.Depth)) > 50 + Mo.Res(R_ELEC) Then
			tx = tx & "Weak against Electricity" & vbCrLf
		ElseIf Mo.Res(R_ELEC) > 0 And char_Renamed.Player.KH((Mo.Terrain), (Mo.Depth)) + char_Renamed.Player.KL((Mo.Terrain), (Mo.Depth)) > 50 - Mo.Res(R_ELEC) Then 
			tx = tx & "Resistant to Electricity" & vbCrLf
		End If
		
		MsgBox(tx,  , Mo.Name & " Statistics")
	End Sub
	
	Public Function ItemText(ByRef it As Item) As String
		If it.ID = True Then
			ItemText = it.Text
		Else
			ItemText = it.UnIDText
		End If
	End Function
	
	Public Function Spread(ByRef c As Short, ByRef s As Short) As Short
		Spread = Int(c - s * c / 100 + Rnd() * 2 * s * c / 100)
	End Function
	
	Public Function IR(ByRef base As Short, ByRef radius As Short) As Short
		IR = Int(base - radius + Rnd() * 2 * radius)
	End Function
	
	Public Function AtrCost(ByRef i As Short, Optional ByRef adjuster As Short = 0) As Short
		Dim j As Short
		Dim c As Double
		
		c = 0
		For j = 0 To 6
			c = c + char_Renamed.Player.Stats(j)
		Next j
		c = c - i - 50 + 1 - adjuster
		c = c \ 10
		
		AtrCost = Int((CDbl(i + 23#) / 7.5) ^ 2.1) + c
	End Function
	
	Public Function ctListSort(ByRef ctl As AxCTLISTLib.AxctList, ByRef col As Short) As Short
		Dim i As Short
		
		'  Call ctListMergeSort(ctl, col, 0, ctl.ListCount - 1)
		Call ctListBubbleSort(ctl, col)
	End Function
	
	Public Function ctListBubbleSort(ByRef ctl As AxCTLISTLib.AxctList, ByRef col As Short) As Short
		Dim i As Object
		Dim j As Short
		Dim s As String
		
		For i = 0 To ctl.ListCount - 1
			For j = 0 To ctl.ListCount - 1
				'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If (0.5 - ctl.SortDirection) * CDbl(ctl.get_ListColumnText(i, col)) < (0.5 - ctl.SortDirection) * CDbl(ctl.get_ListColumnText(j, col)) Then
					'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					s = ctl.get_ListText(i)
					'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Call ctl.RemoveItem(i)
					Call ctl.InsertItem(s, j)
				End If
			Next j
		Next i
		
	End Function
	
	Public Function ctListMergeSort(ByRef ctl As AxCTLISTLib.AxctList, ByRef col As Short, ByRef A As Short, ByRef b As Short) As Short
		' doesn't work... piece of crap
		Dim j, i, K As Object
		Dim p As Short
		Dim s As Object
		Dim T(C_SPELLS - 1) As String
		
		p = (A + b) \ 2
		
		If A = b Then
			Exit Function
		ElseIf b - A = 1 Then 
			If CDbl(ctl.get_ListColumnText(A, col)) < CDbl(ctl.get_ListColumnText(b, col)) Then
				'UPGRADE_WARNING: Couldn't resolve default property of object s. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				s = ctl.get_ListText(A)
				Call ctl.RemoveItem(A)
				'UPGRADE_WARNING: Couldn't resolve default property of object s. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Call ctl.InsertItem(s, b)
			End If
			Exit Function
		Else
			Call ctListMergeSort(ctl, col, A, p)
			Call ctListMergeSort(ctl, col, p + 1, b)
			
			'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			i = A
			'UPGRADE_WARNING: Couldn't resolve default property of object j. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			j = p + 1
			'UPGRADE_WARNING: Couldn't resolve default property of object K. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			K = 0
			
			For K = A To b
				'UPGRADE_WARNING: Couldn't resolve default property of object j. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object Min(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If (CDbl(ctl.get_ListColumnText(i, col)) < CDbl(ctl.get_ListColumnText(Min(b, j), col)) And i <= p) Or j > b Then
					'UPGRADE_WARNING: Couldn't resolve default property of object K. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					T(K) = ctl.get_ListText(i)
					'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					i = i + 1
				Else
					'UPGRADE_WARNING: Couldn't resolve default property of object K. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object j. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					T(K) = ctl.get_ListText(j)
					'UPGRADE_WARNING: Couldn't resolve default property of object j. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					j = j + 1
				End If
			Next K
			
			For K = A To b
				Call ctl.RemoveItem(A)
			Next K
			
			For K = A To b
				'UPGRADE_WARNING: Couldn't resolve default property of object K. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Call ctl.InsertItem(T(K), K)
			Next K
			
		End If
	End Function
End Module