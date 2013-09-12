Option Strict Off
Option Explicit On
Friend Class Character
	Public XP As Short
	Public Gold As Double
	Public LockPoints As Short
	Public Points As Integer
	Public Name As String
	Public LastTown As Short
	
	Private r(6) As Short
	Private Statistics(6) As Short
	Private Derived(10) As Short
	Private Inventory(C_INVMAX - 1) As Item
	Private Equipped(7) As Item
	Public Flags As Short
	Private Counters(C_COUNTERS - 1) As Short
	Public Dropping As Short
	Public CombatUsing As Short
	Private Resistances(C_RESISTS - 1) As Short
	Public Spells As New Collection
	
	Private KillHistory(T_MAX, 20) As Short
	Private KillLearned(T_MAX, 20) As Short
	Private RecentKills(9) As String
	Public Kills As Integer
	
	Public HandHits As Integer
	Public HandSkill As Double
	
	Public Cargo As Short
	
	Public Sub Cast(ByRef sp As String)
		Dim tocast As Spell
		Dim ic As Short
		Dim s As String
		Dim cap As String
		Dim d As Short
		
		If frmCombat Is Nothing Then
			ic = 0
		Else
			ic = frmCombat.InCombat
		End If
		tocast = Spells.Item(sp)
		cap = "Cast " & tocast.Key
		
		If tocast.Points < tocast.cost Then
			MsgBox("You don't have that spell memorized.",  , "Casting " & sp)
			Exit Sub
		End If
		
		If Rnd() * (tocast.Depth * 10 + Reals(S_INT) + tocast.Skill) <= tocast.Depth * 10 Then
			If Rnd() * (tocast.Depth * 10 + Reals(S_WIS)) > tocast.Depth * 10 Then
				tocast.Skill = tocast.Skill + 1
			End If
			
			If ic = 1 Then
				Call frmCombat.AddEvent("The spell fizzles!", 0)
			Else
				Call MsgBox("The spell fizzles!")
			End If
			tocast.Points = tocast.Points - tocast.cost
			'UPGRADE_WARNING: Couldn't resolve default property of object tocast.Used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			tocast.Used = Str(Now.ToOADate())
			Exit Sub
		End If
		
		If sp = "Magic Missile" And ic = 1 Then
			Call frmCombat.AddEvent("You cast Magic Missile.", 0)
			d = Damage(Reals(S_INT) * 2, Reals(S_INT) / 3, 0, frmCombat.Enemy.Dervs(D_DR), F_MAGI, Me, (frmCombat.Enemy))
			If d <> 0 Then Call frmCombat.AddEvent("The " & frmCombat.Enemy.Name & " is blasted for " & d & " damage.", 0)
			If d = 0 Then Call frmCombat.AddEvent("Your Magic Missiles are harmlessly absorbed.", 0)
		ElseIf sp = "Sparkler" And ic = 1 Then 
			Call frmCombat.AddEvent("You cast Sparkler.", 0)
			d = Damage(Reals(S_INT), Reals(S_INT) / 4, 0, frmCombat.Enemy.Dervs(D_DR), 0, Me, (frmCombat.Enemy))
			If d <> 0 Then Call frmCombat.AddEvent("Your Sparkler engulfs the " & frmCombat.Enemy.Name & " for " & d & " damage.", 0)
			If d = 0 Then Call frmCombat.AddEvent("Your Sparkler has no effect.", 0)
			
		ElseIf sp = "Escape" And ic = 1 Then 
			Call frmCombat.AddEvent("You cast Escape.", 0)
			Call frmCombat.FleeAttempt(1)
			
		ElseIf sp = "Protection" And ic = 1 Then 
			Call frmCombat.AddEvent("You cast Protection. Def+" & Reals(S_INT) \ 10 & " DR+" & Reals(S_INT) \ 25, 0)
			Counts(N_PROT) = Reals(S_INT) \ 5
			
		ElseIf sp = "Fireball" And ic = 1 Then 
			Call frmCombat.AddEvent("You cast Fireball.", 0)
			d = Damage(Reals(S_INT) * 2, Reals(S_INT) / 2, frmCombat.Enemy.Dervs(D_DEF), frmCombat.Enemy.Dervs(D_DR), F_FIRE, Me, (frmCombat.Enemy))
			If d <> 0 Then Call frmCombat.AddEvent("The " & frmCombat.Enemy.Name & " is fried for " & d & " damage.", 0)
			If d = 0 Then Call frmCombat.AddEvent("Your Fireball misses.", 0)
		ElseIf sp = "Ice Storm" And ic = 1 Then 
			Call frmCombat.AddEvent("You cast Ice Storm.", 0)
			d = Damage(Reals(S_INT) * 2, Reals(S_INT) / 2, frmCombat.Enemy.Dervs(D_DEF), frmCombat.Enemy.Dervs(D_DR), F_COLD, Me, (frmCombat.Enemy))
			If d <> 0 Then Call frmCombat.AddEvent("The " & frmCombat.Enemy.Name & " is frozen for " & d & " damage.", 0)
			If d = 0 Then Call frmCombat.AddEvent("Your Ice Storm dissipates harmlessly.", 0)
		ElseIf sp = "Lightning Bolt" And ic = 1 Then 
			Call frmCombat.AddEvent("You cast Lightning bolt.", 0)
			d = Damage(Reals(S_INT) * 2, Reals(S_INT) / 2, frmCombat.Enemy.Dervs(D_DEF), frmCombat.Enemy.Dervs(D_DR), F_ELEC, Me, (frmCombat.Enemy))
			If d <> 0 Then Call frmCombat.AddEvent("The " & frmCombat.Enemy.Name & " is electrocuted for " & d & " damage.", 0)
			If d = 0 Then Call frmCombat.AddEvent("Your Lightning Bolt strikes wide.", 0)
			
		ElseIf sp = "Heal" Then 
			d = Int(Rnd() * ((Reals(S_INT) + Reals(S_WIS)) \ 2)) + 1 + ((Reals(S_INT) + Reals(S_WIS)) \ 4)
			If ic = 0 Then
				s = "You heal " & d & " points of damage."
				move.RefreshGame()
			ElseIf ic = 1 Then 
				Call frmCombat.AddEvent("You cast Heal, and recover " & d & " hit points.", 0)
			End If
			'UPGRADE_WARNING: Couldn't resolve default property of object Min(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Dervs(D_CHP) = Min(Dervs(D_CHP) + d, Dervs(D_HTP))
		ElseIf sp = "Teleport" And ic = 0 Then 
			d = Int(Rnd() * C_LOCS)
			s = "You teleport to " & d & "."
			MoveTo((d))
		ElseIf sp = "Haste" And ic = 1 Then 
			Counts(N_FAST) = Reals(S_INT) \ 10
			Call frmCombat.AddEvent("You feel yourself speed up.", 0)
		ElseIf sp = "Slow" And ic = 1 Then 
			If MagicSave(frmCombat.Enemy.Res(R_MAGI)) = 0 Then
				frmCombat.Enemy.Counts(N_SLOW) = Reals(S_INT) \ 10
				Call frmCombat.AddEvent("The " & frmCombat.Enemy.Name & " is slowed!", 0)
			Else
				Call frmCombat.AddEvent("The " & frmCombat.Enemy.Name & " is not affected!", 0)
			End If
		ElseIf sp = "Stun" And ic = 1 Then 
			If MagicSave(frmCombat.Enemy.Res(R_MAGI)) = 0 Then
				frmCombat.ETime = frmCombat.ETime - Reals(S_INT) * 50
				Call frmCombat.AddEvent("The " & frmCombat.Enemy.Name & " is stunned!", 0)
			Else
				Call frmCombat.AddEvent("The " & frmCombat.Enemy.Name & " is not affected!", 0)
			End If
		ElseIf sp = "Bless" And ic = 1 Then 
			Call frmCombat.AddEvent("You feel yourself surrounded with holy power.", 0)
			Counts(N_BLES) = Reals(S_INT) \ 10
		ElseIf sp = "Town Portal" And ic = 0 Then 
			'UPGRADE_WARNING: Couldn't resolve default property of object World.Cities. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			d = World.Cities(Int(Rnd() * UBound(World.Cities)))
			'    d = LastTown
			'UPGRADE_WARNING: Couldn't resolve default property of object World.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			While World.World(d).LCity.T <> "City" Or World.World(d).Explored = 0
				'UPGRADE_WARNING: Couldn't resolve default property of object World.Cities. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				d = World.Cities(Int(Rnd() * UBound(World.Cities)))
			End While
			'UPGRADE_WARNING: Couldn't resolve default property of object World.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			s = "You teleport to " & World.World(d).LCity.Name & "."
			Call MoveTo(d)
		Else
			s = "That spell cannot be cast now."
		End If
		
		If s <> "That spell cannot be cast now." Then
			If Rnd() * (tocast.Depth * 10 + Reals(S_WIS)) > tocast.Depth * 10 Then
				tocast.Skill = tocast.Skill + 1
			End If
			
			tocast.Points = tocast.Points - tocast.cost
			'UPGRADE_WARNING: Couldn't resolve default property of object tocast.Used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			tocast.Used = Str(Now.ToOADate())
		End If
		
		If s <> "" Then
			MsgBox(s,  , cap)
		End If
		
		If ic = 0 Then move.RefreshGame()
		
	End Sub
	
	Public Function GetTreasure(ByRef T As Short, ByRef Special As Short) As String
		Dim s As String
		Dim g As Short
		Dim it As Item
		Dim r As Short
		If Special > 0 And T >= 0 Then
			g = TG(T)
			'    g = Int(Rnd * (C_VALUEPERLEVEL / 20) + (C_VALUEPERLEVEL / 40))
			s = "You collect " & g & " gold!"
			r = Int(Rnd() * 100)
			If Special = 2 Then r = 0
			Select Case r
				Case 0 To 15
					it = New Item
					'UPGRADE_WARNING: Couldn't resolve default property of object Max(0, Int(Rnd * 6) - 4). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Call it.Create(Int(Rnd() * 4), T + Max(0, (Int(Rnd() * 6)) - 4), T - 5 + Max(0, (Int(Rnd() * 6)) - 4))
				Case 16 To 30
					it = New Item
					Call it.MakeItem(1, 1, "Body Part", (frmCombat.Enemy.Terrain), (frmCombat.Enemy.Depth),  ,  ,  ,  , True)
				Case 31 To 36
					If Rnd() * 20 <= T Then
						it = New Item
						Call it.CreateWand()
					End If
				Case 37 To 97
				Case 98 To 99
					it = New Item
					'UPGRADE_WARNING: Couldn't resolve default property of object Max(T - 1 + Int(Rnd * 3), 0). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Call it.CreateArtifact(Int(Rnd() * 6), Max(T - 1 + Int(Rnd() * 3), 0))
			End Select
		ElseIf Special = -1 Then 
			g = 0
			s = "You find nothing!"
		Else
			g = 0
			s = "Blank treasure."
		End If
		
		Me.Gold = Me.Gold + g
		If Not it Is Nothing Then
			s = s & " You find a " & JustText(ItemText(it)) & "."
			Call Me.AddInven(it)
		End If
		
		GetTreasure = s
	End Function
	
	Public Function DoAttack(ByRef s As String, ByRef T As Monster) As String
		Dim d As Short
		Dim ff As Short
		Dim longrange As Short
		Dim t1 As Double
		
		longrange = 0
		
		If (Counts(N_CONF) > 0) And Int(Rnd() * 2) = 0 Then
			DoAttack = "You flail around in confusion."
			Exit Function
		End If
		
		'  If Me.Eq(E_WEP) Is Nothing Then
		'    s = "Punch"
		'  End If
		
		If Not Eq(E_WEP) Is Nothing Then
			ff = ff Or Eq(E_WEP).Flags
		End If
		
		If Not Eq(E_GNT) Is Nothing Then
			ff = ff Or Eq(E_GNT).Flags
		End If
		
		If s = "Punch" Then
			If Int(Rnd() * 3) = 0 Then
				If Rnd() * (Dervs(D_SAT) + Dervs(D_DAT)) < Dervs(D_SAT) Then
					t1 = 1.1
				Else
					frmCombat.PTime = frmCombat.PTime + 100
					t1 = 1
				End If
				
				If Not Eq(E_BTS) Is Nothing Then
					ff = Eq(E_BTS).Flags
				End If
				
				'UPGRADE_WARNING: Couldn't resolve default property of object Max(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				d = Damage(Max(Dervs(D_SAT), Dervs(D_DAT)) + HandSkill, (Dervs(D_DAM) + HandSkill / 3) * t1, T.Dervs(D_DEF), T.Dervs(D_DR), ff, Me, T)
				If d > 0 Then
					DoAttack = "You kick the " & T.Name & " for " & d & " damage."
					Call IncWeap()
				End If
				If d <= 0 Then DoAttack = "Your kick goes wide."
			Else
				If Rnd() * (Dervs(D_SAT) + Dervs(D_DAT)) < Dervs(D_SAT) Then
					t1 = 1.1
				Else
					frmCombat.PTime = frmCombat.PTime + 100
					t1 = 1
				End If
				
				frmCombat.PTime = frmCombat.PTime + 250
				
				If Not Eq(E_GNT) Is Nothing Then
					ff = Eq(E_GNT).Flags
				End If
				
				'UPGRADE_WARNING: Couldn't resolve default property of object Max(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				d = Damage(Max(Dervs(D_SAT), Dervs(D_DAT)) + HandSkill, (Dervs(D_DAM) + HandSkill / 3) * t1, T.Dervs(D_DEF), T.Dervs(D_DR), ff, Me, T)
				If d > 0 Then
					DoAttack = "You punch the " & T.Name & " for " & d & " damage."
					Call IncWeap()
				End If
				If d <= 0 Then DoAttack = "Your punch goes wide."
			End If
			'    Exit Function
		ElseIf s = "Highest" Or s = "MageStr" Then 
			'UPGRADE_WARNING: Couldn't resolve default property of object Max(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			d = Damage(Max(Dervs(D_SAT), Dervs(D_DAT)), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), ff, Me, T)
			If d > 0 Then
				DoAttack = "You hit the " & T.Name & " for " & d & " damage."
				Call IncWeap()
			End If
			If d <= 0 Then DoAttack = "You swing and miss."
		ElseIf s = "NormalStr" Then 
			d = Damage(Dervs(D_SAT), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), ff, Me, T)
			If d > 0 Then
				DoAttack = "You hit the " & T.Name & " for " & d & " damage."
				Call IncWeap()
			End If
			If d <= 0 Then DoAttack = "You swing and miss."
			'    Exit Function
		ElseIf s = "NormalDex" Then 
			d = Damage(Dervs(D_DAT), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), ff, Me, T)
			If d > 0 Then
				DoAttack = "You hit the " & T.Name & " for " & d & " damage."
				Call IncWeap()
			End If
			If d <= 0 Then DoAttack = "You swing and miss."
			'    Exit Function
		ElseIf s = "Bow" Then 
			d = Damage(Dervs(D_DAT), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), ff, Me, T)
			If d > 0 Then
				DoAttack = "You shoot the " & T.Name & " for " & d & " damage."
				Call IncWeap()
			End If
			If d <= 0 Then DoAttack = "You fire and miss."
			'    frmCombat.PTime = frmCombat.PTime + 250
			longrange = 1
			'    Exit Function
		ElseIf s = "NinjaDex" Then 
			d = Damage(Dervs(D_DAT), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), ff, Me, T)
			If Int(Rnd() * 5) = 0 And d > 0 Then
				d = d + Damage(Dervs(D_DAT), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), Eq(0).Flags, Me, T)
				Call frmCombat.AddEvent("Critical Hit!", 0)
			End If
			If d > 0 Then
				DoAttack = "You hit the " & T.Name & " for " & d & " damage."
				Call IncWeap()
			End If
			If d <= 0 Then DoAttack = "You swing and miss."
			'    Exit Function
		ElseIf s = "NinjaStr" Then 
			d = Damage(Dervs(D_SAT), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), ff, Me, T)
			If Int(Rnd() * 6) = 0 And d > 0 Then
				d = d + Damage(Dervs(D_DAT), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), ff, Me, T)
				Call frmCombat.AddEvent("Critical Hit!", 0)
			End If
			If d > 0 Then
				DoAttack = "You hit the " & T.Name & " for " & d & " damage."
				Call IncWeap()
			End If
			If d <= 0 Then DoAttack = "You swing and miss."
			'    Exit Function
		ElseIf s = "Sword of Giants" Then 
			d = Damage(Dervs(D_SAT), Dervs(D_DAM), T.Dervs(D_DEF), T.Dervs(D_DR), F_ELEC, Me, T)
			If d > 0 Then
				DoAttack = "You slash the " & T.Name & " with the Sowrd of Giants for " & d & " electrical damage."
				Call IncWeap()
			End If
			If d <= 0 Then DoAttack = "You miss with the Fire Bomb."
			'    Exit Function
		ElseIf s = "FireBomb" Then 
			d = Damage(10, 2, T.Dervs(D_DEF), T.Dervs(D_DR), F_FIRE, Me, T)
			If d > 0 Then DoAttack = "You throw a Fire Bomb at the " & T.Name & " for " & d & " fire damage."
			If d <= 0 Then DoAttack = "You miss with the Fire Bomb."
			longrange = 1
			'    Exit Function
		Else
			DoAttack = "You do nothing."
			Exit Function
		End If
		
		If longrange = 0 And d <> 0 And T.Dervs(D_DMS) <> 0 And (Not Flags And F_LONG) Then
			DoAttack = DoAttack & " " & Damage(100, T.Dervs(D_DMS), 0, 0, 0, T, Me) & " point counter."
		End If
	End Function
	
	Public Sub IncWeap()
		If Rnd() > frmCombat.Enemy.Depth * 10 / (char_Renamed.Player.Reals(S_REP) + 1) Then
			Exit Sub
		End If
		
		If Eq(E_WEP) Is Nothing Then
			HandHits = HandHits + 1
			If HandHits >= HandSkill + 1 Then
				HandHits = 0
				HandSkill = HandSkill + 1
				Call frmCombat.AddEvent("You improve your martial arts skill!", 0)
			End If
			Exit Sub
		End If
		
		Eq(E_WEP).Hits = Eq(E_WEP).Hits + 1
		If Eq(E_WEP).Hits >= ((Eq(E_WEP).SkillBonus + 0.1) / 0.1) * 10 Then
			Eq(E_WEP).Hits = 0
			Eq(E_WEP).SkillBonus = Eq(E_WEP).SkillBonus + 0.1
			
			Eq(E_WEP).Att = (Eq(E_WEP).Att / (Eq(E_WEP).SkillBonus + 0.9)) * (Eq(E_WEP).SkillBonus + 1) ' + 1
			Eq(E_WEP).Dam = (Eq(E_WEP).Dam / (Eq(E_WEP).SkillBonus + 0.9)) * (Eq(E_WEP).SkillBonus + 1) ' + 0.5
			Eq(E_WEP).Def = (Eq(E_WEP).Def / (Eq(E_WEP).SkillBonus + 0.9)) * (Eq(E_WEP).SkillBonus + 1) ' + 1
			Eq(E_WEP).DR = (Eq(E_WEP).DR / (Eq(E_WEP).SkillBonus + 0.9)) * (Eq(E_WEP).SkillBonus + 1) ' + 0.5
			Eq(E_WEP).DMS = (Eq(E_WEP).DMS / (Eq(E_WEP).SkillBonus + 0.9)) * (Eq(E_WEP).SkillBonus + 1) ' + 0.5
			
			Call frmCombat.AddEvent("You feel more skilled with your weapon!", 0)
			Eq(E_WEP).SetText()
		End If
		
	End Sub
	
	Public Function HandsText() As Object
		If HandSkill <= 7# Then
			'UPGRADE_WARNING: Couldn't resolve default property of object HandsText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			HandsText = HandsText & "[Grasshopper] "
		ElseIf HandSkill <= 14 Then 
			'UPGRADE_WARNING: Couldn't resolve default property of object HandsText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			HandsText = HandsText & "[Novice] "
		ElseIf HandSkill <= 21 Then 
			'UPGRADE_WARNING: Couldn't resolve default property of object HandsText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			HandsText = HandsText & "[Initiate] "
		ElseIf HandSkill <= 28 Then 
			'UPGRADE_WARNING: Couldn't resolve default property of object HandsText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			HandsText = HandsText & "[Acolyte] "
		ElseIf HandSkill <= 35 Then 
			'UPGRADE_WARNING: Couldn't resolve default property of object HandsText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			HandsText = HandsText & "[Adept] "
		ElseIf HandSkill <= 42 Then 
			'UPGRADE_WARNING: Couldn't resolve default property of object HandsText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			HandsText = HandsText & "[Master of Grass] "
		ElseIf HandSkill <= 49 Then 
			'UPGRADE_WARNING: Couldn't resolve default property of object HandsText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			HandsText = HandsText & "[Master of Leaves] "
		ElseIf HandSkill <= 56 Then 
			'UPGRADE_WARNING: Couldn't resolve default property of object HandsText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			HandsText = HandsText & "[Master of Breezes] "
		ElseIf HandSkill <= 63 Then 
			'UPGRADE_WARNING: Couldn't resolve default property of object HandsText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			HandsText = HandsText & "[Master of Winds] "
		ElseIf HandSkill <= 70 Then 
			'UPGRADE_WARNING: Couldn't resolve default property of object HandsText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			HandsText = HandsText & "[Master of Streams] "
		ElseIf HandSkill <= 77 Then 
			'UPGRADE_WARNING: Couldn't resolve default property of object HandsText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			HandsText = HandsText & "[Master of Rivers] "
		ElseIf HandSkill <= 84 Then 
			'UPGRADE_WARNING: Couldn't resolve default property of object HandsText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			HandsText = HandsText & "[Master of Sparks] "
		ElseIf HandSkill <= 91 Then 
			'UPGRADE_WARNING: Couldn't resolve default property of object HandsText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			HandsText = HandsText & "[Master of Flames] "
		ElseIf HandSkill <= 98 Then 
			'UPGRADE_WARNING: Couldn't resolve default property of object HandsText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			HandsText = HandsText & "[Master of Elements] "
		Else
			'UPGRADE_WARNING: Couldn't resolve default property of object HandsText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			HandsText = HandsText & "[Grand Master] "
		End If
		
		Call CalcDervs()
		
		'UPGRADE_WARNING: Couldn't resolve default property of object HandsText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		HandsText = HandsText & "Hands and Feet"
		'UPGRADE_WARNING: Couldn't resolve default property of object Max(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object HandsText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		HandsText = HandsText & " Att:" & Int(Max(Dervs(D_SAT), Dervs(D_DAT)) + HandSkill)
		'UPGRADE_WARNING: Couldn't resolve default property of object HandsText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		HandsText = HandsText & " Dm:" & Int(Dervs(D_DAM) + HandSkill / 3)
		
	End Function
	
	'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Public Sub Class_Initialize_Renamed()
		Dim i As Short
		Points = 600
		LockPoints = 0
		Name = "Player"
		XP = 0
		Stats(S_STR) = 10
		Stats(S_DEX) = 10
		Stats(S_CON) = 10
		Stats(S_INT) = 10
		Stats(S_WIS) = 10
		Stats(S_CHA) = 10
		Stats(S_REP) = 0
		
		HandHits = 0
		HandSkill = 0
		
		Cargo = 1
		
		Call CalcDervs()
		Dervs(D_CHP) = Dervs(D_HTP)
		Gold = 2000
		Flags = 0
		'  For i = 0 To C_SPELLS - 1
		'    Spells(i) = -1
		'  Next i
		
		Dim Knife As New Item
		Dim Dagger As New Item
		Dim Ring1 As New Item
		Dim Ring2 As New Item
		Dim Armor As New Item
		Dim Potion As New Item
		'  Dim Map As New Item
		'  Dim MM As New Spell
		'  Dim Heal As New Spell
		'  Dim TeleS As New Item
		'  Dim HealS As New Item
		'  Dim doll As New Item
		Dim Spark As New Spell
		
		Call Knife.MakeItem(1, 1, "Knife",  ,  ,  , 0, 0, 0, False)
		'  Call Dagger.Me.MakeItem(1,1, "Leather Gloves", , , , 100, 100, 10)
		Call Ring1.MakeItem(1, 1, "Healing Potion", 0)
		Call Ring2.MakeItem(1, 1, "Healing Potion", 0)
		Call Armor.MakeItem(1, 1, "Clothing",  ,  ,  ,  ,  ,  , False)
		Call Potion.MakeItem(1, 1, "Healing Potion", 0)
		'  Call Map.Me.MakeItem(1,1, "Map", 999)
		'  Call MM.MakeSpell(M_MMIS)
		Call Spark.MakeSpell(M_SPRK)
		'  Call Heal.MakeSpell(M_HEAL)
		'  Call TeleS.Me.MakeItem(1,1, "Scroll", M_TELE)
		'  Call HealS.Me.MakeItem(1,1, "Scroll", M_HEAL)
		'  Call doll.Me.MakeItem(1,1, "Wand of Terrain")
		'  Call Tele.MakeSpell("Teleport")
		
		
		'  Call Me.AddInven(Knife)
		Call Me.AddInven(Potion)
		Call Me.AddInven(Ring1)
		Call Me.AddInven(Ring2)
		'  Call Me.AddInven(Armor)
		'  Call Me.AddInven(Map)
		'  Call Me.Spells.Add(MM, MM.Key)
		Call Me.Spells.Add(Spark, Spark.Key)
		'  Call Me.Spells.Add(Heal, Heal.Key)
		'  Call Me.AddInven(TeleS)
		'  Call Me.AddInven(HealS)
		'  Call Me.AddInven(doll)
		'  Call Me.Spells.Add(Tele, Tele.Key)
		
	End Sub
	Public Sub New()
		MyBase.New()
		Class_Initialize_Renamed()
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
		If T.Use = E_TRD Then
			If Cargo = 0 Then
				Call MsgBox("You can't carry any cargo yet!  Increase your reputation.",  , "Cargo Full")
				AddInven = -1
				Exit Function
			End If
			If TGCount() < Cargo Then
				For i = 0 To C_INVMAX - 1
					If Me.Inven(i) Is Nothing Then
						'UPGRADE_WARNING: Couldn't resolve default property of object Me.Inven(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Me.Inven(i) = T
						AddInven = i
						'      Set T = Nothing
						Exit Function
					End If
				Next i
			Else
				Call MsgBox("Your cargo is full." & vbCrLf & "Discard something from your caravan to load up:" & vbCrLf & Right(T.Text, Len(T.Text) - 3),  , "Cargo Full")
				
				frmInven.Visible = True
				frmInven.PickUp = T
				frmInven.RefreshInven()
				
				AddInven = -1
				Exit Function
			End If
		Else
			For i = 0 To C_INVMAX - 1
				If Me.Inven(i) Is Nothing Then
					'UPGRADE_WARNING: Couldn't resolve default property of object Me.Inven(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Me.Inven(i) = T
					AddInven = i
					'      Set T = Nothing
					Exit Function
				End If
			Next i
		End If
		
		Call MsgBox("Your inventory is full." & vbCrLf & "Drop something if you want to pick up" & vbCrLf & Right(T.Text, Len(T.Text) - 3),  , "Inventory Full")
		
		frmInven.Visible = True
		frmInven.PickUp = T
		frmInven.RefreshInven()
		
		AddInven = -1
	End Function
	
	Public Function RemInven(ByRef T As Item, Optional ByRef n As Short = -1) As Short
		Dim i As Short
		
		For i = 0 To C_INVMAX - 1
			If Me.Inven(i) Is T Then
				If IsEquipped(T) <> -1 Then
					'UPGRADE_NOTE: Object Me.Eq() may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
					'UPGRADE_WARNING: Couldn't resolve default property of object Me.Eq(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Me.Eq(IsEquipped(T)) = Nothing
				End If
				
				'      If n = -1 Then
				'UPGRADE_NOTE: Object Me.Inven() may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				'UPGRADE_WARNING: Couldn't resolve default property of object Me.Inven(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Me.Inven(i) = Nothing
				'      Else
				'        Me.Inven(i).num = Me.Inven(i).num - n
				'        If Me.Inven(i).num <= 0 Then Call RemInven(T)
				'      End If
				RemInven = i
				Exit Function
				
			End If
		Next i
		
	End Function
	
	Public Sub CalcDervs()
		Dim i As Short
		Dim j As Short
		
		For i = 0 To 6
			Reals(i) = Stats(i)
		Next i
		For i = 0 To C_RESISTS - 1
			Res(i) = 0
		Next i
		
		For i = 0 To 6
			For j = 0 To 7
				If Not Eq(j) Is Nothing Then
					'UPGRADE_WARNING: Couldn't resolve default property of object Max(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Reals(i) = Max(Reals(i) + Eq(j).Stats(i), 1)
				End If
			Next j
		Next i
		
		Dervs(D_SAT) = Int((Reals(S_STR) * 2 + Reals(S_DEX) * 1) / 3)
		Dervs(D_DAT) = Int((Reals(S_STR) * 1 + Reals(S_DEX) * 3) / 4)
		Dervs(D_DEF) = Int((Reals(S_DEX) + Reals(S_CON) * 2 + Reals(S_INT) + Reals(S_WIS) * 2) / 6)
		Dervs(D_HTP) = Int((Reals(S_STR) + Reals(S_CON) * 3) / 4) + 5
		Dervs(D_SPD) = Int((Reals(S_DEX) * 2 + Reals(S_INT) * 2) / 4)
		Dervs(D_PER) = Int((Reals(S_INT) + Reals(S_WIS) * 3) / 4)
		Dervs(D_LUK) = Int((Reals(S_STR) + Reals(S_DEX) + Reals(S_CON) + Reals(S_INT) + 2 * Reals(S_WIS) + 2 * Reals(S_CHA) + Reals(S_REP)) / 9)
		Dervs(D_DAM) = Int((Reals(S_STR) * 2 + Reals(S_DEX)) / 15)
		Dervs(D_DR) = Int(Reals(S_CON) / 15)
		Dervs(D_DMS) = 0
		
		Cargo = Int(Reals(S_REP) / 10)
		
		For j = 0 To 7
			If Not Eq(j) Is Nothing Then
				If Eq(j).Stat = S_STR Then
					Dervs(D_SAT) = Dervs(D_SAT) + Eq(j).Att
				ElseIf Eq(j).Stat = S_DEX Then 
					Dervs(D_DAT) = Dervs(D_DAT) + Eq(j).Att
				Else
					Dervs(D_SAT) = Dervs(D_SAT) + Eq(j).Att
					Dervs(D_DAT) = Dervs(D_DAT) + Eq(j).Att
				End If
				
				Dervs(D_DEF) = Dervs(D_DEF) + Eq(j).Def
				Dervs(D_DAM) = Dervs(D_DAM) + Eq(j).Dam
				Dervs(D_DR) = Dervs(D_DR) + Eq(j).DR
				Dervs(D_SPD) = Dervs(D_SPD) + Eq(j).Speed
				Dervs(D_DMS) = Dervs(D_DMS) + Eq(j).DMS
				
				For i = 0 To C_RESISTS - 1
					Res(i) = Res(i) + Eq(j).Res(i)
				Next i
				
				If j <> E_WEP Then
					Flags = Flags Or Eq(j).Flags
				End If
			End If
		Next j
		
		
	End Sub
	
	Public Function InInventory(ByRef Target As String) As Short
		Dim i As Short
		
		For i = 0 To UBound(Inventory)
			If Not Inventory(i) Is Nothing Then
				If InStr(1, Inventory(i).Text, Target) Then
					InInventory = i
					Exit Function
				End If
			End If
		Next i
		InInventory = -1
	End Function
	
	Public Function TGCount() As Short
		Dim i As Object
		
		TGCount = 0
		
		For i = 0 To UBound(Inventory)
			'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If Not Inventory(i) Is Nothing Then
				'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Inventory(i).Use = E_TRD Then
					TGCount = TGCount + 1
				End If
			End If
		Next i
	End Function
	
	
	Public Property Counts(ByVal i As Short) As Short
		Get
			Counts = Counters(i)
		End Get
		Set(ByVal Value As Short)
			Counters(i) = Value
		End Set
	End Property
	
	
	Public Property KH(ByVal i As Short, ByVal j As Short) As Short
		Get
			KH = KillHistory(i, j)
		End Get
		Set(ByVal Value As Short)
			KillHistory(i, j) = Value
		End Set
	End Property
	
	Public Property KL(ByVal i As Short, ByVal j As Short) As Short
		Get
			KL = KillLearned(i, j)
		End Get
		Set(ByVal Value As Short)
			KillLearned(i, j) = Value
		End Set
	End Property
	
	
	Public Property RK(ByVal i As Short) As String
		Get
			RK = RecentKills(i)
		End Get
		Set(ByVal Value As String)
			RecentKills(i) = Value
		End Set
	End Property
	
	'Public Property Let Flags(i As long, v As long)
	'  FlagsEffects(i) = v
	'End Property
	
	'Public Property Get Flags(i As long) As long
	'  Flags = FlagsEffects(i)
	'End Property
	
	
	Public Property Reals(ByVal i As Short) As Short
		Get
			Reals = r(i)
		End Get
		Set(ByVal Value As Short)
			r(i) = Value
		End Set
	End Property
	
	
	Public Property Dervs(ByVal i As Short) As Short
		Get
			Dervs = Derived(i)
		End Get
		Set(ByVal Value As Short)
			Derived(i) = Value
		End Set
	End Property
	
	
	Public Property Stats(ByVal i As Short) As Short
		Get
			Stats = Statistics(i)
		End Get
		Set(ByVal Value As Short)
			Statistics(i) = Value
		End Set
	End Property
	
	Public Property Res(ByVal i As Short) As Short
		Get
			Res = Resistances(i)
		End Get
		Set(ByVal Value As Short)
			Resistances(i) = Value
		End Set
	End Property
	
	
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
	
	Public Property Eq(ByVal i As Short) As Item
		Get
			Eq = Equipped(i)
		End Get
		Set(ByVal Value As Item)
			Equipped(i) = Value
		End Set
	End Property
	
	'Public Property Let Spells(i As long, v As long)
	'  Set MagicSpells(i) = v
	'End Property
	
	'Public Property Get Spells(i As long) As long
	'  Set Spells = MagicSpells(i)
	'End Property
End Class