Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmInven
	Inherits System.Windows.Forms.Form
	Public PickUp As Item
	Public Used As String
	
	Private Sub cmdDone_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDone.Click
		If frmCombat.InCombat = 1 Then
			frmCombat.Visible = True
			frmCombat.Refresh()
			
			If Used <> "" Then
				Call frmCombat.AddEvent("You use a " & Used)
			Else
				Call frmCombat.AddEvent("You fiddle with your equipment.")
			End If
			Used = ""
			Call frmCombat.RefreshCombat()
			Call frmCombat.EnemyAttack()
		Else
			RefreshGame()
		End If
		
		Me.Close()
	End Sub
	
	Private Sub cmdDrop_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDrop.Click
		Dim i As Short
		Dim j As Short
		Dim ans As MsgBoxResult
		If lstInven.SelectedIndex = -1 Or VB.Left(lstInven.Text, 1) = "-" Then Exit Sub
		
		For i = 0 To C_INVMAX - 1
			If Not char_Renamed.Player.Inven(i) Is Nothing Then
				If (i = VB6.GetItemData(lstInven, lstInven.SelectedIndex)) Then
					For j = 0 To 7
						If char_Renamed.Player.Inven(i) Is char_Renamed.Player.Eq(j) Then
							MsgBox("Cannot discard an equipped item.")
							Exit Sub
						End If
					Next j
					'Right(char.Player.Inven(i).Text, Len(char.Player.Inven(i).Text) - 3)
					ans = MsgBox(lstInven.Text & vbCrLf & "Discard Permanently?", MsgBoxStyle.YesNo, "Discard?")
					If ans = MsgBoxResult.Yes Then
						Call char_Renamed.Player.RemInven(char_Renamed.Player.Inven(i))
					End If
					RefreshInven()
					'        RefreshChar
					Exit For
				End If
			End If
		Next i
		
	End Sub
	
	Private Sub cmdID_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdID.Click
		Dim i As Short
		Dim j As Short
		Dim it As Item
		Dim exp As Short
		Dim c As Double
		Dim s As String
		
		If lstInven.SelectedIndex = -1 Or VB.Left(lstInven.Text, 1) = "-" Then Exit Sub
		i = VB6.GetItemData(lstInven, lstInven.SelectedIndex)
		
		If Not char_Renamed.Player.Inven(i) Is Nothing Then
			it = char_Renamed.Player.Inven(i)
			c = ((char_Renamed.Player.Dervs(D_PER) + char_Renamed.Player.Reals(S_INT) + char_Renamed.Player.Reals(S_REP)) / 30)
			c = c / (c + it.Depth)
			If char_Renamed.Player.Flags And F_TRUE Then
				c = c * 2
			End If
			If (it.ID = False) And it.LastID > System.Date.FromOADate(GameDate.ToOADate - CDate(Max(30 - (char_Renamed.Player.Reals(S_INT) \ 10), 1)).ToOADate) Then
				MsgBox("You still have no idea what this item is.",  , "Identify")
			ElseIf (it.ID = True) Or (Rnd() < c) Or frmGame.ckCombat.CheckState = 1 Then 
				If it.ID = False Then
					exp = (it.Depth + 0) * E_POINTS
					char_Renamed.Player.Points = char_Renamed.Player.Points + exp
				Else
					exp = 0
				End If
				it.ID = True
				
				s = "You identify the item!" & vbCrLf
				s = s & JustText((it.Text)) & vbCrLf & vbCrLf
				
				If it.Flags And F_BLND Then
					s = s & "Radiant" & vbCrLf
				End If
				If it.Flags And F_COLD Then
					s = s & "Frosty" & vbCrLf
				End If
				If it.Flags And F_CONF Then
					s = s & "Prismatic" & vbCrLf
				End If
				If it.Flags And F_ELEC Then
					s = s & "Electric" & vbCrLf
				End If
				If it.Flags And F_FAST Then
					s = s & "Hasted" & vbCrLf
				End If
				If it.Flags And F_FIRE Then
					s = s & "Flaming" & vbCrLf
				End If
				If it.Flags And F_HYPR Then
					s = s & "Hyper" & vbCrLf
				End If
				If it.Flags And F_LIFE Then
					s = s & "Fast Regeneration" & vbCrLf
				End If
				If it.Flags And F_LONG Then
					s = s & "Integer Range" & vbCrLf
				End If
				If it.Flags And F_MAGI Then
					s = s & "Enchanted" & vbCrLf
				End If
				If it.Flags And F_PIRC Then
					s = s & "Vorpal" & vbCrLf
				End If
				If it.Flags And F_POIS Then
					s = s & "Venomous" & vbCrLf
				End If
				If it.Flags And F_REGN Then
					s = s & "Regeneration" & vbCrLf
				End If
				If it.Flags And F_SLEP Then
					s = s & "Sleep" & vbCrLf
				End If
				If it.Flags And F_SLOW Then
					s = s & "Ensnaring" & vbCrLf
				End If
				If it.Flags And F_STUN Then
					s = s & "Stunning" & vbCrLf
				End If
				If it.Flags And F_TRUE Then
					s = s & "Insightful" & vbCrLf
				End If
				If it.Flags And F_VAMP Then
					s = s & "Vampiric" & vbCrLf
				End If
				
				s = s & vbCrLf & "You gain " & exp & " experience points."
				
				MsgBox(s,  , "Identify")
			Else
				'      MsgBox "You don't know what this item is. (" & Round(((char.Player.Dervs(D_PER) + char.Player.Reals(S_INT) + char.Player.Reals(S_REP)) / 30) / (((char.Player.Dervs(D_PER) + char.Player.Reals(S_INT) + char.Player.Reals(S_REP)) / 30) + it.Depth), 2) * 100 & "%)", , "Identify"
				MsgBox("You don't know what this item is. (" & System.Math.Round(c, 2) * 100 & "%)",  , "Identify")
				it.LastID = GameDate
			End If
			RefreshInven()
		End If
	End Sub
	
	Private Sub cmdPickUp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPickUp.Click
		Call char_Renamed.Player.AddInven(PickUp)
		'UPGRADE_NOTE: Object PickUp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		PickUp = Nothing
		RefreshInven()
	End Sub
	
	Private Sub cmdUneq_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUneq.Click
		Dim index As Short = cmdUneq.GetIndex(eventSender)
		'UPGRADE_NOTE: Object char_Renamed.Player.Eq() may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		'UPGRADE_WARNING: Couldn't resolve default property of object char_Renamed.Player.Eq(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		char_Renamed.Player.Eq(index) = Nothing
		' Call RefreshChar
		Call RefreshInven()
	End Sub
	
	Private Sub frmInven_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim keyascii As Short = Asc(eventArgs.KeyChar)
		If keyascii = 27 Then
			Call cmdDone_Click(cmdDone, New System.EventArgs())
		ElseIf keyascii = Asc("i") Or keyascii = Asc("I") Then 
			Call cmdID_Click(cmdID, New System.EventArgs())
		End If
		
		keyascii = 0
		eventArgs.KeyChar = Chr(keyascii)
		If keyascii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub frmInven_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'  lstInven.Sorted = True
		'  Call RefreshChar
		Call RefreshInven()
	End Sub
	
	Public Sub RefreshInven()
		Dim i As Short
		Dim T As String
		Dim cur As Short
		
		cur = lstInven.SelectedIndex
		
		lstInven.Items.Clear()
		
		txGold.Text = CStr(char_Renamed.Player.Gold)
		
		For i = 0 To C_INVMAX - 1
			If Not char_Renamed.Player.Inven(i) Is Nothing Then
				T = ItemText(char_Renamed.Player.Inven(i))
				'      If char.Player.Inven(i).Use = E_NON Then
				'        T = T & " (" & char.Player.Inven(i).num & ")"
				'      End If
				
				If IsEquipped(char_Renamed.Player.Inven(i)) <> -1 Then
					T = VB.Left(T, 3) & Chr(128) & " " & JustText(T) ' 128, 164
				End If
				
				lstInven.Items.Add(New VB6.ListBoxItem((T), i))
			End If
		Next i
		
		lstInven.Items.Add((E_WEP & "-------- Weapons -----"))
		lstInven.Items.Add((E_ARM & "-------- Armor -------"))
		lstInven.Items.Add((E_SLD & "-------- Shields -----"))
		lstInven.Items.Add((E_HLM & "-------- Helms -------"))
		lstInven.Items.Add((E_GNT & "-------- Gauntlets ---"))
		lstInven.Items.Add((E_BTS & "-------- Boots -------"))
		lstInven.Items.Add((E_RG1 & "-------- Rings -------"))
		lstInven.Items.Add((E_NON & "-------- Misc. -------"))
		lstInven.Items.Add((Hex(E_TRD) & "-------- Trade Goods, Max:" & char_Renamed.Player.Cargo & ""))
		
		For i = 0 To lstInven.Items.Count - 1
			VB6.SetItemString(lstInven, i, JustText(VB6.GetItemString(lstInven, i)))
		Next i
		
		For i = 0 To 7
			If Not char_Renamed.Player.Eq(i) Is Nothing Then
				txEq(i).Text = JustText(ItemText(char_Renamed.Player.Eq(i)))
			ElseIf i = 0 Then 
				'UPGRADE_WARNING: Couldn't resolve default property of object char_Renamed.Player.HandsText(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				txEq(i).Text = char_Renamed.Player.HandsText()
			Else
				txEq(i).Text = ""
			End If
		Next i
		
		If lstInven.SelectedIndex <> -1 Then
			txCur.Text = VB6.GetItemString(lstInven, lstInven.SelectedIndex)
			txValue.Text = CStr(Int(char_Renamed.Player.Inven(VB6.GetItemData(lstInven, lstInven.SelectedIndex)).Value))
		Else
			txCur.Text = ""
			txValue.Text = ""
		End If
		
		'  For i = 0 To C_RESISTS - 1
		'    txRes(i).Text = char.Player.Res(i)
		'  Next i
		
		If Not PickUp Is Nothing Then
			cmdPickUp.Enabled = True
			txPickUp.Text = VB.Right(ItemText(PickUp), Len(ItemText(PickUp)) - 3)
		Else
			cmdPickUp.Enabled = False
			txPickUp.Text = ""
		End If
		
		If cur <> -1 Then
			lstInven.SetSelected(cur, True)
		End If
		RefreshChar()
		
	End Sub
	
	
	Private Sub frmInven_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		If frmCombat.InCombat = 1 Then
			frmCombat.Visible = True
		End If
	End Sub
	
	'UPGRADE_WARNING: Event lstInven.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub lstInven_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstInven.SelectedIndexChanged
		If lstInven.SelectedIndex <> -1 And VB.Left(VB6.GetItemString(lstInven, lstInven.SelectedIndex), 1) <> "-" Then
			txCur.Text = VB6.GetItemString(lstInven, lstInven.SelectedIndex)
			txValue.Text = CStr(Int(char_Renamed.Player.Inven(VB6.GetItemData(lstInven, lstInven.SelectedIndex)).Value))
		Else
			txCur.Text = ""
			txValue.Text = ""
		End If
		
	End Sub
	
	Private Sub lstInven_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstInven.DoubleClick
		Dim T As String
		Dim i As Short
		Dim u As Short
		Dim nnn As String
		
		If VB.Left(lstInven.Text, 1) = "-" Then
			Exit Sub
		End If
		
		i = VB6.GetItemData(lstInven, lstInven.SelectedIndex)
		
		'  For i = 0 To C_INVMAX - 1
		If Not char_Renamed.Player.Inven(i) Is Nothing Then
			If char_Renamed.Player.Inven(i).Use <> E_NON Then
				u = char_Renamed.Player.Inven(i).Use
				
				If u = E_RG1 Then
					If char_Renamed.Player.Eq(E_RG1) Is Nothing Then
						'UPGRADE_WARNING: Couldn't resolve default property of object char_Renamed.Player.Eq(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						char_Renamed.Player.Eq(E_RG1) = char_Renamed.Player.Inven(i)
						If char_Renamed.Player.Eq(E_RG1) Is char_Renamed.Player.Eq(E_RG2) Then
							'UPGRADE_NOTE: Object char_Renamed.Player.Eq() may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
							'UPGRADE_WARNING: Couldn't resolve default property of object char_Renamed.Player.Eq(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							char_Renamed.Player.Eq(E_RG2) = Nothing
						End If
					Else
						'UPGRADE_WARNING: Couldn't resolve default property of object char_Renamed.Player.Eq(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						char_Renamed.Player.Eq(E_RG2) = char_Renamed.Player.Eq(E_RG1)
						'UPGRADE_WARNING: Couldn't resolve default property of object char_Renamed.Player.Eq(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						char_Renamed.Player.Eq(E_RG1) = char_Renamed.Player.Inven(i)
						If char_Renamed.Player.Eq(E_RG1) Is char_Renamed.Player.Eq(E_RG2) Then
							'UPGRADE_NOTE: Object char_Renamed.Player.Eq() may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
							'UPGRADE_WARNING: Couldn't resolve default property of object char_Renamed.Player.Eq(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							char_Renamed.Player.Eq(E_RG2) = Nothing
						End If
					End If
				Else
					'UPGRADE_WARNING: Couldn't resolve default property of object char_Renamed.Player.Eq(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					char_Renamed.Player.Eq(u) = char_Renamed.Player.Inven(i)
				End If
				'        Exit For
			ElseIf char_Renamed.Player.Inven(i).Use = E_NON Then 
				nnn = char_Renamed.Player.Inven(i).Name
				Call char_Renamed.Player.Inven(i).UseF(i)
				If char_Renamed.Player.Inven(i) Is Nothing Then
					lstInven.SelectedIndex = -1
				End If
				If frmCombat.InCombat = 1 Then
					Used = nnn
					Call cmdDone_Click(cmdDone, New System.EventArgs())
				End If
			End If
		End If
		'  Next i
		
		'  Call RefreshChar
		Call RefreshInven()
	End Sub
	
	'Private Sub txEq_DblClick(Index As long)
	' char.Player.Eq(Index) = Nothing
	' Call RefreshInven
	' call refreshchar
	'End Sub
	
	Public Sub RefreshChar()
		Dim i As Short
		
		Call char_Renamed.Player.CalcDervs()
		For i = 0 To 6
			txStats(i).Text = CStr(Player.Reals(i))
			txDervs(i).Text = CStr(Player.Dervs(i))
		Next i
		txDam.Text = CStr(Player.Dervs(D_DAM))
		txDR.Text = CStr(Player.Dervs(D_DR))
		txGold.Text = CStr(Player.Gold)
		
		For i = 0 To C_RESISTS - 1
			txRes(i).Text = CStr(char_Renamed.Player.Res(i))
		Next i
		
		
	End Sub
End Class