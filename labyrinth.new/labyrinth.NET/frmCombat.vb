Option Strict Off
Option Explicit On
Friend Class frmCombat
	Inherits System.Windows.Forms.Form
	Public Turn As Short
	Public Enemy As Monster
	Public Player As Character
	Public PTime As Short
	Public ETime As Short
	Public InCombat As Short
	Public lastForm As System.Windows.Forms.Form
	
	Public Sub AddEvent(ByRef s As String, Optional ByRef W As Short = -1)
		Static lastturn As Short
		Dim pre As String
		
		If W = 1 Then
			pre = " + "
		ElseIf W = 0 Then 
			pre = " * "
		ElseIf W = -1 Then 
			pre = "   "
		End If
		
		If s = "" Then Exit Sub
		If lastturn <> Turn Then
			Call lstEvents.Items.Insert(lstEvents.Items.Count, Turn & " ------------------------------------------------")
			lastturn = Turn
		End If
		
		Call lstEvents.Items.Insert(lstEvents.Items.Count, pre & s)
		While lstEvents.Items.Count > 200
			lstEvents.Items.RemoveAt((0))
		End While
		lstEvents.SelectedIndex = lstEvents.Items.Count - 1
	End Sub
	
	Public Sub EndCombat()
		Dim s As String
		Dim d As Short
		Dim i As Short
		Dim m As Double
		If Player.Dervs(D_CHP) <= 0 Then
			AddEvent(("You are defeated."))
			frmGame.AddEvent(("Defeated in combat by " & Enemy.Name & "."))
			d = 10 + (Player.Stats(S_REP) \ 20)
			'UPGRADE_WARNING: Couldn't resolve default property of object Max(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Player.Stats(S_REP) = Max(Player.Stats(S_REP) - d, 0)
			Player.CalcDervs()
			AddEvent(("You have been defeated in combat."))
			If C_HARDDEATH = 1 Then
				AddEvent(("Game over!"))
			Else
				Player.Dervs(D_CHP) = Player.Dervs(D_HTP)
				AddEvent(("Your reputation decreases by " & d & "."))
				d = CInt(Player.Gold / 2)
				'UPGRADE_WARNING: Couldn't resolve default property of object Max(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Player.Gold = Max(Player.Gold - d, 0)
				AddEvent(("You lose " & d & " gold coins."))
				AddEvent(("You have been returned to Centris."))
				'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.Loc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				World_Renamed.Loc = 0
				frmGame.cmdRoute.Text = "Calc. Route"
			End If
		ElseIf Enemy.Dervs(D_CHP) <= 0 Then 
			m = 1
			For i = 0 To 9
				If Player.RK(i) = Enemy.Name Then m = m * 0.85
			Next i
			
			'UPGRADE_WARNING: Couldn't resolve default property of object Max(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			m = m * (0.8 ^ Max((Player.Reals(S_REP) \ 10) - (Enemy.Depth), 0))
			
			AddEvent(("You win!"))
			AddEvent(("Gain " & CShort(Enemy.Points * m) & " experience points."))
			Player.Points = Player.Points + CShort(Enemy.Points * m)
			
			Player.RK(Player.Kills Mod 10) = Enemy.Name
			Player.Kills = Player.Kills + 1
			Player.KH((Enemy.Terrain), (Enemy.Depth)) = Player.KH((Enemy.Terrain), (Enemy.Depth)) + 1
			
			AddEvent((Player.GetTreasure((Enemy.Depth), (Enemy.Treasure))))
			If Int(Rnd() * 10) + (Enemy.Depth) * 10 + 1 > Player.Stats(S_REP) Then
				Player.Stats(S_REP) = Player.Stats(S_REP) + 1
				Player.CalcDervs()
				AddEvent(("Your reputation increases!"))
			End If
			If Enemy.Terrain = T_GHOST Then
				'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				World_Renamed.World(Loc_Renamed).LCity.Conts = World_Renamed.World(Loc_Renamed).LCity.Conts + 1
			End If
			frmGame.AddEvent(("Killed " & Enemy.Name & " in combat."))
		Else
			AddEvent(("You escape!"))
			frmGame.AddEvent(("Escaped from " & Enemy.Name & "."))
			ETime = 0
		End If
		
		cmdRun.Enabled = False
		cmdInven.Enabled = False
		'  cmdSpell.Enabled = False
		cmdWait.Enabled = False
		cmdAttack.Text = "Exit"
		
		RefreshGame()
	End Sub
	
	Public Sub Regen(ByRef A As Object)
		Dim x As Spell
		
		'UPGRADE_WARNING: Couldn't resolve default property of object A.Flags. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If A Is Enemy And A.Flags And F_REGN Then
			'UPGRADE_WARNING: Couldn't resolve default property of object A.Dervs. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object Min(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			A.Dervs(D_CHP) = Min(A.Dervs(D_CHP) + 1, A.Dervs(D_HTP))
		ElseIf A Is Player Then 
			'UPGRADE_WARNING: Couldn't resolve default property of object A.Eq. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If Not A.Eq(E_WEP) Is Nothing Then
				'UPGRADE_WARNING: Couldn't resolve default property of object A.Eq. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If (A.Eq(E_WEP).Flags And F_LIFE) Then
					'UPGRADE_WARNING: Couldn't resolve default property of object A.Dervs. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object A.Reals. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object Min(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					A.Dervs(D_CHP) = Min(A.Dervs(D_CHP) + Int(Rnd() * A.Reals(S_CON)) \ 10, A.Dervs(D_HTP))
					'UPGRADE_WARNING: Couldn't resolve default property of object A.Eq. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf (A.Eq(E_WEP).Flags And F_REGN) And Int(Rnd() * 2) = 0 Then 
					'UPGRADE_WARNING: Couldn't resolve default property of object A.Dervs. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object A.Reals. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object Min(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					A.Dervs(D_CHP) = Min(A.Dervs(D_CHP) + Int(Rnd() * A.Reals(S_CON)) \ 10, A.Dervs(D_HTP))
				End If
			End If
			
			'    For Each x In char.Player.Spells
			'      x.Points = Min(x.Points + char.Player.Reals(S_INT) \ 10, (char.Player.Reals(S_WIS) * 10)) '\ 20) * x.cost)
			'    Next x
			
		End If
	End Sub
	
	
	Public Function NextTurn() As Short ' returns 0 for player, 1 for enemy
		Dim i As Short
		Dim Padd As Short
		Dim Eadd As Short
		Dim d As Short
		Dim conf As Boolean
		
		Turn = Turn + 1
		
		If Player.Dervs(D_CHP) <= 0 Or Enemy.Dervs(D_CHP) <= 0 Then
			EndCombat()
			NextTurn = 0
			Exit Function
		End If
		
		While InCombat = 1
			Padd = Spread(Player.Dervs(D_SPD), 20) 'Int(Rnd * Player.Dervs(D_SPD)) + 1 + Player.Dervs(D_SPD) \ 2
			Eadd = Spread(Enemy.Dervs(D_SPD), 20) ' Int(Rnd * Enemy.Dervs(D_SPD)) + 1 + Enemy.Dervs(D_SPD) \ 2
			If Player.Counts(N_SLOW) > 0 Then
				Padd = Padd \ 2
			End If
			If Player.Counts(N_FAST) > 0 Then
				Padd = Padd * 2
			End If
			If Player.Counts(N_SLEP) > 0 Then
				Padd = 0
				'      Player.Counts(N_SLEP) = Player.Counts(N_SLEP) - 1
			End If
			If Enemy.Counts(N_SLOW) > 0 Then
				Eadd = Eadd \ 2
			End If
			If Enemy.Counts(N_FAST) > 0 Then
				Eadd = Eadd * 2
			End If
			If Enemy.Counts(N_SLEP) > 0 Then
				Eadd = 0
				'      Enemy.Counts(N_SLEP) = Enemy.Counts(N_SLEP) - 1
			End If
			
			PTime = PTime + Padd
			ETime = ETime + Eadd
			
			If (PTime >= 1000 And ETime < 1000) Or (ETime >= 1000 And PTime >= 1000 And PTime >= ETime) Then
				PTime = PTime - 1000
				NextTurn = 0
				If Player.Counts(N_DETH) > 1 Then AddEvent((Player.Counts(N_DETH) - 1 & " turns left to live!"))
				If Player.Counts(N_DETH) = 1 Then
					Player.Dervs(D_CHP) = 0
					EndCombat()
					NextTurn = 0
					Exit Function
				End If
				If Player.Counts(N_POIS) >= 1 Then
					d = Damage(1, Enemy.Depth, 0, 0, 0, Enemy, Player)
					AddEvent(("You take " & d & " poison damage!"))
					RefreshCombat()
				End If
				Call Regen(Player)
				
				Call DecCounters(Player)
				
				If Player.Counts(N_CONF) > 0 Then
					If SavingThrow(F_CONF, F_CONF, Player.Flags, Enemy.Depth, Player.Reals(S_REP) \ 10) = False Then
						Call AddEvent("You are confused!", 0)
						conf = True
					Else
						Call AddEvent("You have a moment of clarity!", 0)
						conf = False
					End If
				End If
				If Player.Counts(N_SLOW) > 0 Then
					Call AddEvent("You're moving slowly!", 0)
				End If
				If Player.Counts(N_FAST) > 0 Then
					Call AddEvent("You're moving quickly!", 0)
				End If
				If Player.Counts(N_SLEP) > 0 Then
					Call AddEvent("You're asleep!", 0)
					conf = True
					'      Player.Counts(N_SLEP) = Player.Counts(N_SLEP) - 1
				End If
				
				If conf = True Then
					PTime = PTime
				Else
					Exit Function
				End If
			ElseIf (ETime >= 1000 And PTime < 1000) Or (ETime >= 1000 And PTime >= 1000 And ETime > PTime) Then 
				ETime = ETime - 1000
				NextTurn = 1
				If Enemy.Counts(N_DETH) > 1 Then AddEvent((Enemy.Counts(N_DETH) - 1 & " turns left for your enemy to live!"))
				If Enemy.Counts(N_DETH) = 1 Then
					Enemy.Dervs(D_CHP) = 0
					EndCombat()
					NextTurn = 0
					Exit Function
				End If
				If Enemy.Counts(N_POIS) >= 1 Then
					If Not Player.Eq(E_WEP) Is Nothing Then
						d = Damage(1, Player.Eq(E_WEP).Depth, 0, 0, 0, Player, Enemy)
					Else
						d = Damage(1, 1, 0, 0, 0, Player, Enemy)
					End If
					AddEvent(("The " & Enemy.Name & " takes " & d & " poison damage!"))
				End If
				Call Regen(Enemy)
				
				Call DecCounters(Enemy)
				Exit Function
				'    ElseIf ETime >= 1000 And PTime >= 1000 Then
				'      If ETime > PTime Then
				'        ETime = ETime - 1000
				'        NextTurn = 1
				'        Call DecCounters(Enemy)
				'        Exit Function
				'      Else
				'        PTime = PTime - 1000
				'        NextTurn = 0
				'        Call DecCounters(Player)
				'        Exit Function
				'      End If
			End If
		End While
	End Function
	
	Public Sub DecCounters(ByRef e As Object)
		Dim i As Short
		For i = 0 To C_COUNTERS - 1
			'UPGRADE_WARNING: Couldn't resolve default property of object e.Counts. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object Max(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			e.Counts(i) = Max(e.Counts(i) - 1, 0)
		Next i
	End Sub
	
	Public Sub EnemyAttack()
		Dim conf As Boolean
		
		If NextTurn() = 0 Then Exit Sub
		
		Dim A As Short
		Dim i As Short
		A = Int(Rnd() * 100) + 1
		
		For i = 0 To C_MAXATTACKS - 1
			A = A - Enemy.AttP(i)
			If A <= 0 Then Exit For
		Next i
		
		If Enemy.Counts(N_CONF) > 0 Then
			If SavingThrow(F_CONF, F_CONF, Enemy.Flags, Player.Reals(S_REP) \ 10, Enemy.Depth) = False Then
				Call AddEvent("The " & Enemy.Name & " flails around in confusion.", 1)
				conf = True
			Else
				Call AddEvent("The " & Enemy.Name & " has a moment of clarity.", 1)
				conf = False
			End If
		End If
		If Enemy.Counts(N_SLOW) > 0 Then
			Call AddEvent("The " & Enemy.Name & " is moving slowly.", 1)
		End If
		If Enemy.Counts(N_FAST) > 0 Then
			Call AddEvent("The " & Enemy.Name & " is moving quickly.", 1)
		End If
		If Enemy.Counts(N_SLEP) > 0 Then
			Call AddEvent("The " & Enemy.Name & " is asleep.", 1)
			conf = True
			'      Enemy.Counts(N_SLEP) = Enemy.Counts(N_SLEP) - 1
		End If
		
		If conf = False Then
			Call AddEvent(Enemy.DoAttack(Enemy.Atts(i), Player), 1)
		End If
		Call RefreshCombat()
		If Player.Dervs(D_CHP) <= 0 Then
			EndCombat()
		Else
			Call EnemyAttack()
		End If
		Exit Sub
		
	End Sub
	
	Public Sub RefreshCombat()
		txHP.Text = Player.Dervs(D_CHP) & "/" & Player.Dervs(D_HTP)
		RefreshSpells()
	End Sub
	
	Private Sub cmdAttack_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAttack.Click
		Dim s As String
		Dim conf As Boolean
		
		If cmdAttack.Text = "Exit" Then
			Me.Visible = False
			
			cmdRun.Enabled = True
			cmdInven.Enabled = True
			cmdWait.Enabled = True
			cmdAttack.Text = "Attack"
			
			InCombat = 0
			If C_HARDDEATH = 1 And Player.Dervs(D_CHP) <= 0 Then
				End
			Else
				lastForm.Visible = True
				Exit Sub
			End If
		End If
		
		If Player.Eq(E_WEP) Is Nothing Then
			s = "Punch"
			If (Player.Flags And F_HYPR) Then
				PTime = PTime + 500
			ElseIf (Player.Flags And F_FAST) Then 
				PTime = PTime + 250
			End If
		Else
			s = Player.Eq(E_WEP).Attack
			If (Player.Eq(E_WEP).Flags And F_HYPR) Or (Player.Flags And F_HYPR) Then
				PTime = PTime + 500
			ElseIf (Player.Eq(E_WEP).Flags And F_FAST) Or (Player.Flags And F_FAST) Then 
				PTime = PTime + 250
			End If
		End If
		
		'  If Player.Counts(N_CONF) > 0 Then
		'    If SavingThrow(F_CONF, F_CONF, Player.Flags, Enemy.Depth, Player.Reals(S_REP) \ 10) = False Then
		'      Call AddEvent("You are confused!", 0)
		'      conf = True
		'    Else
		'      Call AddEvent("You have a moment of clarity!", 0)
		'      conf = False
		'    End If
		'  End If
		
		If conf = False Then
			Call AddEvent(Player.DoAttack(s, Enemy), 0)
		End If
		'  Call AddEvent(Player.DoAttack(S, Enemy), 0)
		Call RefreshCombat()
		Call EnemyAttack()
	End Sub
	
	Public Sub StartCombat(ByRef s As String, ByRef ambush As Short, ByRef lf As System.Windows.Forms.Form)
		Dim i As Short
		Me.Refresh()
		
		Enemy = New Monster
		Call Enemy.MakeMonster(s)
		Player = char_Renamed.Player
		lastForm = lf
		
		For i = 0 To C_COUNTERS - 1
			Enemy.Counts(i) = 0
			Player.Counts(i) = 0
		Next i
		
		InCombat = 1
		PTime = 0
		ETime = 0
		Turn = 1
		
		If ambush = 1 Then
			PTime = PTime + 1000
		ElseIf ambush = 2 Then 
			ETime = ETime + 1000
		End If
		
		txEnemyName.Text = Enemy.Name
		lstEvents.Items.Clear()
		
		AddEvent(("Entering combat with " & Enemy.Name))
		
		lastForm.Visible = False
		frmInven.Visible = False
		Me.Visible = True
		cmdRun.Focus()
		Call RefreshCombat()
		
		Call EnemyAttack()
		
	End Sub
	
	Private Sub cmdInven_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdInven.Click
		frmInven.Visible = True
		Me.Visible = False
		frmInven.RefreshInven()
	End Sub
	
	Private Sub cmdLook_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdLook.Click
		Dim off As Short
		
		'  off = (400 - Player.Dervs(D_PER) - Player.Reals(S_REP)) \ 4
		'UPGRADE_WARNING: Couldn't resolve default property of object Min(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		off = Min(Max(100 - (((Player.Dervs(D_PER) - Enemy.Depth * 10) * 100) / ((Enemy.Depth + 1) * 10)) / 4 - (((Player.Reals(S_REP) - Enemy.Depth * 10) * 100) / ((Enemy.Depth + 1) * 10)) / 4 - Player.KH((Enemy.Terrain), (Enemy.Depth)) - Player.KL((Enemy.Terrain), (Enemy.Depth)), 0), 100)
		If Player.Flags And F_TRUE Then
			off = off \ 2
		End If
		
		Call DispMonster(Enemy, off)
	End Sub
	
	Private Sub cmdRun_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRun.Click
		Call FleeAttempt(0)
	End Sub
	
	Public Sub FleeAttempt(Optional ByRef EscapeSpell As Short = 0)
		Dim m As Short
		
		If EscapeSpell = 1 Then
			m = 2
		Else
			m = 1
		End If
		
		If Int(Rnd() * 200) < Player.Dervs(D_LUK) * m Then
			Call EndCombat()
			Exit Sub
		ElseIf Int(Rnd() * (Player.Dervs(D_SPD) * m + Enemy.Dervs(D_SPD))) <= Player.Dervs(D_SPD) * m Then 
			Call EndCombat()
			Exit Sub
		Else
			Call AddEvent("You try to escape, but you don't get away!")
		End If
		
		Call RefreshCombat()
		Call EnemyAttack()
		
	End Sub
	
	Private Sub cmdSpell_Click()
		Call frmMagic.RefreshSpells()
		frmMagic.Visible = True
		Me.Visible = False
		frmMagic.Activate()
	End Sub
	
	Private Sub cmdWait_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdWait.Click
		Dim s As String
		
		Call AddEvent("You wait.")
		Call RefreshCombat()
		Call EnemyAttack()
	End Sub
	
	Private Sub frmCombat_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'  Call StartCombat
	End Sub
	
	Private Sub frmCombat_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		If InCombat = 1 Then
			'UPGRADE_ISSUE: Event parameter Cancel was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FB723E3C-1C06-4D2B-B083-E6CD0D334DA8"'
			cancel = 1
		End If
	End Sub
	
	Public Sub RefreshSpells()
		Dim s As String
		Dim avail As Short
		Dim pts As Short
		Dim x As Spell
		Dim nIndex As Short
		
		Call lstSpells.ClearList()
		
		For	Each x In char_Renamed.Player.Spells
			avail = x.Points \ x.cost
			pts = x.Points Mod x.cost
			
			'    s = "(" & avail & "/" & Player.Reals(S_WIS) * 10 \ x.cost & ")|" & Int((char.Player.Reals(S_INT) + x.Skill) / (x.Depth * 10 + char.Player.Reals(S_INT) + x.Skill) * 100) & "|" & x.Key & "|" & x.Desc & "|" & (x.Used) '& " [" & pts & "/" & x.cost & "]"
			s = "(" & avail & "/" & Player.Reals(S_WIS) * 10 \ x.cost & ")|" & Int((char_Renamed.Player.Reals(S_INT) + x.Skill) / (x.Depth * 10 + char_Renamed.Player.Reals(S_INT) + x.Skill) * 100) & "|" & x.Key & "|" & x.Desc & "|" & (x.Depth) '& " [" & pts & "/" & x.cost & "]"
			
			nIndex = lstSpells.AddItem(s)
			'    lstSpells.ListCargo(nIndex) = x.Used
			'    lstSpells.List(lstSpells.NewIndex) = x.Used & "|" & "(" & avail & "/" & Player.Reals(S_WIS) * 10 \ x.cost & ") " & lstSpells.List(lstSpells.NewIndex) & " [" & pts & "/" & x.cost & "]"
			
		Next x
		lstSpells.SortColumn = 5
		'  lstSpells.SortDirection = SortAscend
		Call ctListSort(lstSpells, 5)
		'  lstSpells.SortList
	End Sub
	
	Private Sub lstSpells_Change(ByVal eventSender As System.Object, ByVal eventArgs As AxCTLISTLib._DctListEvents_ChangeEvent) Handles lstSpells.Change
		lstSpells.Tag = eventArgs.nIndex
	End Sub
	
	Private Sub lstSpells_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstSpells.DblClick
		Dim sp As String
		Dim l As String
		Dim r As String
		
		If cmdAttack.Text = "Exit" Then Exit Sub
		
		'  l = Left(lstSpells.ListText(Val(lstSpells.Tag)), InStr(1, lstSpells.ListText(Val(lstSpells.Tag)), "[", vbTextCompare) - 2)
		'  r = Right(l, Len(l) - InStr(1, l, ")", vbTextCompare) - 1)
		
		sp = lstSpells.get_ListColumnText(Val(lstSpells.Tag), 3)
		
		'lstSpells.ListCargo(lstSpells.Tag) = Str(CDbl(Now()))
		'UPGRADE_WARNING: Couldn't resolve default property of object char_Renamed.Player.Spells(sp).Used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		char_Renamed.Player.Spells.Item(sp).Used = Str(Now.ToOADate())
		
		Call char_Renamed.Player.Cast(sp)
		
		'  frmMagic.Visible = False
		If Me.InCombat = 1 Then
			Me.Visible = True
			Call Me.RefreshCombat()
			Call Me.EnemyAttack()
		End If
		'  frmGame.SetFocus
	End Sub
End Class