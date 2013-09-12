Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmCity
	Inherits System.Windows.Forms.Form
	Public LCity As City
	Public t_Build As Short
	
	Private Sub cmdExplore_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExplore.Click
		Dim monstername As String
		Dim i As Short
		Dim it As Item
		
		Dim offer As Short
		Dim cost As Integer
		Dim ans As MsgBoxResult
		Dim g As Short
		If LCity.T = "Haunted House" Then
			monstername = SelectMonster(T_GHOST, (LCity.Conts))
			Call frmCombat.StartCombat(monstername, (LCity.Conts), Me)
		ElseIf LCity.T = "Fairy Pond" Then 
			If VB.Day(GameDate) = LCity.Conts Then
				char_Renamed.Player.Dervs(D_CHP) = char_Renamed.Player.Dervs(D_HTP)
				MsgBox("You drink from the pure, clear water." & vbCrLf & "Your hit points are restored!",  , "Fairy Pond")
				
				ans = MsgBox("As you raise your head from the water," & vbCrLf & "you find yourself eye to eye" & vbCrLf & "with tiny winged woman." & vbCrLf & "In a musical voice, she offers to" & vbCrLf & "use her magic on your behalf for a" & vbCrLf & "token from your treasure." & vbCrLf & vbCrLf & "Do you accept?", MsgBoxStyle.YesNo, "Fairy Encounter")
				If ans = MsgBoxResult.Yes Then
					offer = Int(Rnd() * (C_STATS + 1))
					cost = Int(Rnd() * 100) * char_Renamed.Player.Reals(S_REP)
					If cost > char_Renamed.Player.Gold Then
						MsgBox("The fairy laughs at your pitiful treasure, and disappears!",  , "Fairy Encounter")
					Else
						char_Renamed.Player.Gold = char_Renamed.Player.Gold - cost
						If offer < C_STATS Then
							char_Renamed.Player.Stats(offer) = char_Renamed.Player.Stats(offer) + 1
						Else
							For i = 0 To C_STATS - 1
								char_Renamed.Player.Stats(i) = char_Renamed.Player.Stats(i) + 1
							Next i
						End If
						MsgBox("The fairy waves her tiny hand at you" & vbCrLf & "and you feel a tingle run through your body." & vbCrLf & "She then disappears, and your purse feels lighter.",  , "Fairy Encounter")
					End If
				Else
					MsgBox("The fairy sticks out her tiny tongue at you and disappears.",  , "Fairy Encounter")
				End If
				LCity.Conts = Int(Rnd() * 31) + 1
			Else
				char_Renamed.Player.Dervs(D_CHP) = char_Renamed.Player.Dervs(D_HTP)
				MsgBox("You drink from the pure, clear water." & vbCrLf & "Your hit points are restored!",  , "Fairy Pond")
			End If
		ElseIf LCity.T = "Goblin Mine" Then 
			If Int(Rnd() * 35) > LCity.Conts Then
				MsgBox("As you are scrounging around the mine, you are discovered!")
				monstername = SelectMonster(T_GOBLIN, (LCity.Conts))
				Call frmCombat.StartCombat(monstername, (LCity.Conts), Me)
				'UPGRADE_WARNING: Couldn't resolve default property of object Max(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LCity.Conts = Max(LCity.Conts - 5, 0)
			Else
				g = TG((LCity.Depth))
				MsgBox("You search the mine and find " & g & " gold coins!")
				Player.Gold = Player.Gold + g
				'UPGRADE_WARNING: Couldn't resolve default property of object Max(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LCity.Conts = Max(LCity.Conts - 2, 0)
			End If
		ElseIf LCity.T = "Mystic Sage" Then 
			frmStore.Visible = True
			Call frmStore.LoadStore(Loc_Renamed, 0)
		ElseIf LCity.T = "Temple" Then 
			frmStore.Visible = True
			Call frmStore.LoadStore(Loc_Renamed, 0)
		ElseIf LCity.T = "Academy" Then 
			frmStore.Visible = True
			Call frmStore.LoadStore(Loc_Renamed, 0)
		ElseIf LCity.T = "Carnival" Then 
			frmStore.Visible = True
			Call frmStore.LoadStore(Loc_Renamed, 0)
		ElseIf LCity.T = "Ancient Ruins" Then 
			If Int(Rnd() * 100) < LCity.Conts Then
				it = New Item
				'UPGRADE_WARNING: Couldn't resolve default property of object Min(LCity.Depth + 1 + Int(Rnd * 3), 21). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Call it.Create(Int(Rnd() * 4), Min(LCity.Depth + 1 + Int(Rnd() * 3), 21))
				it.Value = Int(it.Value / 2)
				it.ID = False
				
				Call MsgBox("You find a " & JustText(ItemText(it)) & " hidden amidst the ruins!",  , "You find an item!")
				
				Call char_Renamed.Player.AddInven(it)
				LCity.Conts = 0
			Else
				Call MsgBox("You wander around for a while, but you don't find anything.",  , "You find nothing!")
				LCity.Conts = 0
			End If
		ElseIf LCity.T = "Monster Graveyard" Then 
			If Int(Rnd() * 10) + 1 < LCity.Conts Then
				it = New Item
				'UPGRADE_WARNING: Couldn't resolve default property of object Max(0, Min(20, Int(LCity.Conts / 20) - 2 + LCity.Depth)). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Call it.MakeItem(1, 1, "Body Part", Int(Rnd() * T_MAXUSED), Max(0, Min(20, Int(LCity.Conts / 20) - 2 + LCity.Depth)),  ,  ,  ,  , True)
				
				it.Value = Int(it.Value / 2)
				it.ID = True
				
				Call MsgBox("You find " & JustText(ItemText(it)) & " in plain sight!",  , "You find an item!")
				
				Call char_Renamed.Player.AddInven(it)
				'UPGRADE_WARNING: Couldn't resolve default property of object Max(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LCity.Conts = Max(LCity.Conts - 10, 0)
			Else
				Call MsgBox("You wander around for a while, but you don't find anything.",  , "You find nothing!")
				'UPGRADE_WARNING: Couldn't resolve default property of object Max(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LCity.Conts = Max(LCity.Conts - 10, 0)
			End If
		End If
		RefreshCity()
	End Sub
	
	Private Sub cmdExplore_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExplore.Enter
		RefreshCity()
	End Sub
	
	Private Sub cmdLeave_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdLeave.Click
		LCity.LastExplored = GameDate
		
		frmGame.Visible = True
		RefreshGame()
		Me.Close()
		frmStore.Close()
	End Sub
	
	Private Sub cmdStores_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdStores.Click
		Dim index As Short = cmdStores.GetIndex(eventSender)
		Dim cost As Double
		Dim st As String
		Dim ans As MsgBoxResult
		
		Dim s As String
		If LCity.T = "City" Then
			frmStore.Visible = True
			Call frmStore.LoadStore(Loc_Renamed, index)
		ElseIf LCity.T = "Castle" Then 
			If cmdStores(index).Text = "Bank" Then
				If t_Build = 1 And LCity.Castle(B_BANK) < 3 Then
					cost = I_BASE * 2 * (I_MANT ^ (LCity.Depth + LCity.Castle(B_BANK)))
					If char_Renamed.Player.Gold >= I_BASE * 2 * (I_MANT ^ (LCity.Depth + LCity.Castle(B_BANK))) Then
						ans = MsgBox("Do you want to spend " & cost & " to upgrade your Bank?" & vbCrLf & "You have " & char_Renamed.Player.Gold & " gold.", MsgBoxStyle.YesNo, "Bank Upgrade")
						
						If ans = MsgBoxResult.Yes Then
							char_Renamed.Player.Gold = char_Renamed.Player.Gold - cost
							LCity.Castle(B_BANK) = LCity.Castle(B_BANK) + 1
						Else
							
						End If
					Else
						Call MsgBox("You don't have the " & cost & " gold in your inventory required to upgrade your Bank.")
					End If
				Else 'If LCity.Castle(B_BANK) > 0 Then
					st = InputBox("Deposit how much gold?" & vbCrLf & "(Use negative numbers to make withdrawls.)" & vbCrLf & vbCrLf & "Money on hand: " & char_Renamed.Player.Gold & vbCrLf & "Money in bank: " & LCity.Conts, "Bank Transaction", "0")
					If VB.Left(st, 1) <> "-" Then
						st = "0" & st
					End If
					'        If Len(st) > 0 Then
					cost = Int(CDbl(Val(st)))
					'        Else
					'          cost = 0
					'        End If
					'        cost = Int(cost)
					If cost < 0 Then
						cost = System.Math.Abs(cost)
						If cost > LCity.Conts Then
							cost = LCity.Conts
							Call MsgBox("You only have " & cost & " gold in the bank here.",  , "Not enough funds!")
						End If
						char_Renamed.Player.Gold = char_Renamed.Player.Gold + cost
						LCity.Conts = LCity.Conts - cost
						Call MsgBox("You withdraw " & cost & " gold from the bank.",  , "Withdrawl")
					Else
						If cost > char_Renamed.Player.Gold Then
							cost = char_Renamed.Player.Gold
							Call MsgBox("You only have " & cost & " gold with you.",  , "Not enough gold!")
						End If
						char_Renamed.Player.Gold = char_Renamed.Player.Gold - cost
						LCity.Conts = LCity.Conts + cost
						Call MsgBox("You deposit " & cost & " gold into the bank.",  , "Deposit")
					End If
				End If
				t_Build = 0
			ElseIf cmdStores(index).Text = "Market" Then 
				If t_Build = 1 And LCity.Castle(B_MARK) < 3 Then
					cost = I_BASE * 2 * (I_MANT ^ (LCity.Depth + LCity.Castle(B_MARK)))
					If char_Renamed.Player.Gold >= I_BASE * 2 * (I_MANT ^ (LCity.Depth + LCity.Castle(B_MARK))) Then
						ans = MsgBox("Do you want to spend " & cost & " to upgrade your Market?" & vbCrLf & "You have " & char_Renamed.Player.Gold & " gold.", MsgBoxStyle.YesNo, "Market Upgrade")
						
						If ans = MsgBoxResult.Yes Then
							char_Renamed.Player.Gold = char_Renamed.Player.Gold - cost
							LCity.Castle(B_MARK) = LCity.Castle(B_MARK) + 1
							LCity.Stores(0).Depth = LCity.Stores(0).Depth + 1
						Else
							
						End If
					Else
						Call MsgBox("You don't have the " & cost & " gold in your inventory required to upgrade your Market.")
					End If
				Else
					frmStore.Visible = True
					Call frmStore.LoadStore(Loc_Renamed, 0)
				End If
				t_Build = 0
			ElseIf cmdStores(index).Text = "Trainer" Then 
				If t_Build = 1 And LCity.Castle(B_TRAN) < 3 Then
					cost = I_BASE * 2 * (I_MANT ^ (LCity.Depth + LCity.Castle(B_TRAN)))
					If char_Renamed.Player.Gold >= I_BASE * 2 * (I_MANT ^ (LCity.Depth + LCity.Castle(B_TRAN))) Then
						ans = MsgBox("Do you want to spend " & cost & " to upgrade your Trainer?" & vbCrLf & "You have " & char_Renamed.Player.Gold & " gold.", MsgBoxStyle.YesNo, "Trainer Upgrade")
						
						If ans = MsgBoxResult.Yes Then
							char_Renamed.Player.Gold = char_Renamed.Player.Gold - cost
							LCity.Castle(B_TRAN) = LCity.Castle(B_TRAN) + 1
						Else
							
						End If
					Else
						Call MsgBox("You don't have the " & cost & " gold in your inventory required to upgrade your Trainer.")
					End If
				Else
					If LCity.Pop > 0 Then
						Call MsgBox("You undergo rigorous training, and gain " & LCity.Pop & " experience points.",  , "Trainer")
						char_Renamed.Player.Points = char_Renamed.Player.Points + LCity.Pop
						LCity.Pop = 0
					Else
						Call MsgBox("There is nothing more you can learn here, now.",  , "Trainer")
					End If
				End If
				t_Build = 0
			ElseIf cmdStores(index).Text = "Defense" Then 
				If t_Build = 1 And LCity.Castle(B_WALL) < 3 Then
					cost = I_BASE * 2 * (I_MANT ^ (LCity.Depth + LCity.Castle(B_WALL)))
					If char_Renamed.Player.Gold >= I_BASE * 2 * (I_MANT ^ (LCity.Depth + LCity.Castle(B_WALL))) Then
						ans = MsgBox("Do you want to spend " & cost & " to upgrade your Defense?" & vbCrLf & "You have " & char_Renamed.Player.Gold & " gold.", MsgBoxStyle.YesNo, "Defense Upgrade")
						
						If ans = MsgBoxResult.Yes Then
							char_Renamed.Player.Gold = char_Renamed.Player.Gold - cost
							LCity.Castle(B_WALL) = LCity.Castle(B_WALL) + 1
						Else
							
						End If
					Else
						Call MsgBox("You don't have the " & cost & " gold in your inventory required to upgrade your Defense.")
					End If
				Else
					
					s = "Current defensive level: " & LCity.Castle(B_WALL) & "." & vbCrLf & vbCrLf
					If LCity.Castle(B_BANK) > 0 Then
						s = s & "Current monthly interest rate: " & System.Math.Round(1 + (LCity.Castle(B_BANK) * (0.05) + (LCity.Depth / 100)), 2) & "%" & vbCrLf
					End If
					If LCity.Castle(B_MARK) > 0 Then
						s = s & "Current monthly store income: " & System.Math.Round(I_BASE * I_MANT ^ (LCity.Castle(B_MARK) + (LCity.Depth - 1)), 0)
					End If
					Call MsgBox(s,  , "Defense Report")
				End If
				t_Build = 0
			ElseIf cmdStores(index).Text = "Special" Then 
				t_Build = 0
			ElseIf cmdStores(index).Text = "Build" Then 
				If t_Build = 0 Then
					t_Build = 1
					Call MsgBox("Click the button for the structure you want to build or upgrade.",  , "Building Activated")
				Else
					t_Build = 0
					Call MsgBox("Build cancelled.",  , "Building cancelled")
				End If
			End If
			RefreshCity()
		End If
	End Sub
	
	Public Sub RefreshCity()
		Dim i As Short
		
		frmGame.Visible = False
		
		'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		LCity = World_Renamed.World(Loc_Renamed).LCity
		frInfo.Text = LCity.Name
		Me.Text = LCity.T
		txInfo.Text = ""
		
		If LCity.T = "City" Then
			For i = 0 To C_STORES - 1
				If LCity.Stores(i).T <> -1 Then
					cmdStores(i).Enabled = True
				Else
					cmdStores(i).Enabled = False
				End If
			Next i
			
			cmdStores(0).Text = "Weapons"
			cmdStores(1).Text = "Armor"
			cmdStores(2).Text = "General Store"
			cmdStores(3).Text = "Magic Shop"
			cmdStores(4).Text = "Inn"
			cmdStores(5).Text = "Market"
			
			cmdExplore.Visible = False
			txInfo.Text = txInfo.Text & "The City of " & LCity.Name & "." & vbCrLf
			txInfo.Text = txInfo.Text & LCity.Desc & vbCrLf
		ElseIf LCity.T = "Castle" Then 
			
			If LCity.Castle(B_BANK) > 0 Or t_Build = 1 Then
				cmdStores(0).Enabled = True
			Else
				cmdStores(0).Enabled = False
			End If
			
			If LCity.Castle(B_MARK) > 0 Or t_Build = 1 Then
				cmdStores(1).Enabled = True
			Else
				cmdStores(1).Enabled = False
			End If
			
			If LCity.Castle(B_TRAN) > 0 Or t_Build = 1 Then
				cmdStores(2).Enabled = True
			Else
				cmdStores(2).Enabled = False
			End If
			
			If LCity.Castle(B_WALL) > 0 Or t_Build = 1 Then
				cmdStores(3).Enabled = True
			Else
				cmdStores(3).Enabled = False
			End If
			
			If LCity.Castle(B_SPEC) > 0 Or t_Build = 1 Then
				cmdStores(4).Enabled = True
			Else
				cmdStores(4).Enabled = False
			End If
			
			cmdStores(0).Text = "Bank"
			cmdStores(1).Text = "Market"
			cmdStores(2).Text = "Trainer"
			cmdStores(3).Text = "Defense"
			cmdStores(4).Text = "Special"
			cmdStores(5).Text = "Build"
			
			cmdExplore.Visible = False
			
			i = LCity.Castle(B_BANK) + LCity.Castle(B_MARK) + LCity.Castle(B_SPEC) + LCity.Castle(B_TRAN) + LCity.Castle(B_WALL)
			
			If i = 0 Then
				LCity.Desc = "You have built a castle here.  It is currently little more than a foundation."
			ElseIf i < 5 Then 
				LCity.Desc = "You have built a castle here.  It isn't very developed yet, but construction is coming along nicely."
			ElseIf i < 10 Then 
				LCity.Desc = "You have built a castle here.  You have built several buildings, and the castle is quite imposing."
			ElseIf i < 15 Then 
				LCity.Desc = "You have built a castle here.  Few other castles can match its excellence."
			ElseIf i = 15 Then 
				LCity.Desc = "You have built a castle here.  Construction is complete, and your castle reigns supreme over the surrounding countryside."
			End If
			
			LCity.Desc = LCity.Desc & vbCrLf
			LCity.Desc = LCity.Desc & LCity.Castle(B_BANK) & ": Bank level" & vbCrLf
			LCity.Desc = LCity.Desc & LCity.Castle(B_MARK) & ": Market level" & vbCrLf
			LCity.Desc = LCity.Desc & LCity.Castle(B_TRAN) & ": Trainer level" & vbCrLf
			LCity.Desc = LCity.Desc & LCity.Castle(B_WALL) & ": Defense level" & vbCrLf
			LCity.Desc = LCity.Desc & LCity.Castle(B_SPEC) & ": Special level" & vbCrLf
			
			txInfo.Text = txInfo.Text & LCity.Name & vbCrLf
			txInfo.Text = txInfo.Text & LCity.Desc & vbCrLf
		Else
			For i = 0 To C_STORES - 1
				cmdStores(i).Enabled = False
				cmdStores(i).Visible = False
			Next i
			cmdExplore.Visible = True
			frInfo.Text = LCity.T
			txInfo.Text = LCity.Desc
			
			If LCity.T = "Haunted House" Then
				If LCity.Conts = 0 Then
					txInfo.Text = txInfo.Text & vbCrLf & vbCrLf & "You have not yet explored this Haunted House." & vbCrLf & vbCrLf & "Click the 'Explore' button to enter."
				ElseIf LCity.Conts < 21 Then 
					txInfo.Text = txInfo.Text & vbCrLf & vbCrLf & "Click the 'Explore' button to enter."
				ElseIf LCity.Conts >= 21 Then 
					txInfo.Text = txInfo.Text & vbCrLf & vbCrLf & "You have already vanquished the spirits from this once-Haunted House."
					cmdExplore.Enabled = False
				End If
			ElseIf LCity.T = "Fairy Pond" Then 
			ElseIf LCity.T = "Crossroad" Then 
				cmdExplore.Visible = False
				cmdStores(S_INN).Enabled = True
				cmdStores(S_INN).Visible = True
			ElseIf LCity.T = "Goblin Mine" Then 
				'UPGRADE_WARNING: Couldn't resolve default property of object Min(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LCity.Conts = Min(30, System.Date.FromOADate(LCity.Conts + GameDate.ToOADate - LCity.LastExplored.ToOADate))
				If LCity.Conts = 30 Then
					txInfo.Text = txInfo.Text & vbCrLf & vbCrLf & "There does not appear to be much activity." & vbCrLf & vbCrLf & "Click the 'Explore' button to enter."
				ElseIf LCity.Conts >= 20 And LCity.Conts < 30 Then 
					txInfo.Text = txInfo.Text & vbCrLf & vbCrLf & "You hear goblin patrols moving beneath you." & vbCrLf & vbCrLf & "Click the 'Explore' button to enter."
				ElseIf LCity.Conts >= 10 And LCity.Conts < 20 Then 
					txInfo.Text = txInfo.Text & vbCrLf & vbCrLf & "You hear the sounds of shouting and running coming from the mine." & vbCrLf & vbCrLf & "Click the 'Explore' button to enter."
				ElseIf LCity.Conts > 0 And LCity.Conts < 10 Then 
					txInfo.Text = txInfo.Text & vbCrLf & vbCrLf & "You see goblins searching about for an intruder." & vbCrLf & vbCrLf & "Click the 'Explore' button to enter."
				ElseIf LCity.Conts = 0 Then 
					txInfo.Text = txInfo.Text & vbCrLf & vbCrLf & "Goblin guards are actively patrolling the mine enterance." & vbCrLf & vbCrLf & "Click the 'Explore' button to enter."
				End If
			ElseIf LCity.T = "Mystic Sage" Then 
				
			ElseIf LCity.T = "Ancient Ruins" Then 
				'UPGRADE_WARNING: Couldn't resolve default property of object Min(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LCity.Conts = Min(100, System.Date.FromOADate(LCity.Conts + GameDate.ToOADate - LCity.LastExplored.ToOADate))
				
				If LCity.Conts = 100 Then
					txInfo.Text = txInfo.Text & vbCrLf & vbCrLf & "Your treasure-sense is tingling."
				ElseIf LCity.Conts >= 75 Then 
					txInfo.Text = txInfo.Text & vbCrLf & vbCrLf & "There's treasure in there somewhere, you can feel it."
				ElseIf LCity.Conts >= 50 Then 
					txInfo.Text = txInfo.Text & vbCrLf & vbCrLf & "You've got a good feeling about this place."
				ElseIf LCity.Conts >= 25 Then 
					txInfo.Text = txInfo.Text & vbCrLf & vbCrLf & "You don't feel like searching this place again."
				Else
					txInfo.Text = txInfo.Text & vbCrLf & vbCrLf & "You've been up and down every corridor, you doubt there's anything left."
				End If
			ElseIf LCity.T = "Monster Graveyard" Then 
				'UPGRADE_WARNING: Couldn't resolve default property of object Min(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LCity.Conts = Min(100, System.Date.FromOADate(LCity.Conts + GameDate.ToOADate - LCity.LastExplored.ToOADate))
				
				If LCity.Conts = 100 Then
					txInfo.Text = txInfo.Text & vbCrLf & vbCrLf & "There are amazing pieces all around you!"
				ElseIf LCity.Conts >= 75 Then 
					txInfo.Text = txInfo.Text & vbCrLf & vbCrLf & "A few well-preserved monster parts are scattered around."
				ElseIf LCity.Conts >= 50 Then 
					txInfo.Text = txInfo.Text & vbCrLf & vbCrLf & "There are some good parts, but you'll have to dig."
				ElseIf LCity.Conts >= 25 Then 
					txInfo.Text = txInfo.Text & vbCrLf & vbCrLf & "The place is nearly picked clean."
				Else
					txInfo.Text = txInfo.Text & vbCrLf & vbCrLf & "All that's left is garbage."
				End If
				
			End If
		End If
		
		LCity.LastExplored = GameDate
		
	End Sub
	
	
	Private Sub frmCity_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		t_Build = 0
		RefreshCity()
	End Sub
	Private Sub frmCity_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim keyascii As Short = Asc(eventArgs.KeyChar)
		If keyascii = 27 Then
			Call cmdLeave_Click(cmdLeave, New System.EventArgs())
		End If
		eventArgs.KeyChar = Chr(keyascii)
		If keyascii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
End Class