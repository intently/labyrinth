Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmStore
	Inherits System.Windows.Forms.Form
	Public s As Store
	
	Public Sub LoadStore(ByRef l As Short, ByRef i As Short)
		'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		s = World_Renamed.World(l).LCity.Stores(i)
		
		RefreshStore()
	End Sub
	
	Public Sub RefreshStore()
		Dim i As Short
		Dim T As String
		
		lstInven.Items.Clear()
		lstStore.Items.Clear()
		
		txGold.Text = CStr(char_Renamed.Player.Gold)
		frStore.Text = ""
		
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
		For i = 0 To C_INVMAX - 1
			If Not s.Inven(i) Is Nothing Then
				
				T = ItemText(s.Inven(i))
				'      T = "[" & Price(S.Inven(i), 1) & "]  " & JustText(T)
				'      If S.Inven(i).Use = E_NON Then
				'        T = T & " (" & S.Inven(i).num & ")"
				'      End If
				
				Call lstStore.Items.Add(T)
				'UPGRADE_ISSUE: ListBox property lstStore.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
				VB6.SetItemData(lstStore, lstStore.NewIndex, i)
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
		
		lstStore.Items.Add((E_WEP & "-------- Weapons -----"))
		lstStore.Items.Add((E_ARM & "-------- Armor -------"))
		lstStore.Items.Add((E_SLD & "-------- Shields -----"))
		lstStore.Items.Add((E_HLM & "-------- Helms -------"))
		lstStore.Items.Add((E_GNT & "-------- Gauntlets ---"))
		lstStore.Items.Add((E_BTS & "-------- Boots -------"))
		lstStore.Items.Add((E_RG1 & "-------- Rings -------"))
		lstStore.Items.Add((E_NON & "-------- Misc. -------"))
		lstStore.Items.Add((Hex(E_TRD) & "-------- Trade Goods -"))
		
		For i = 0 To lstInven.Items.Count - 1
			If VB.Left(JustText(VB6.GetItemString(lstInven, i)), 1) <> "-" Then
				If char_Renamed.Player.Inven(VB6.GetItemData(lstInven, i)).Use = E_TRD Then
					VB6.SetItemString(lstInven, i, "[" & PadSpaces(CStr(TGPrice(char_Renamed.Player.Inven(VB6.GetItemData(lstInven, i)), s, 0)), 10) & "]  " & JustText(VB6.GetItemString(lstInven, i)))
				Else
					VB6.SetItemString(lstInven, i, "[" & PadSpaces(CStr(Price((char_Renamed.Player.Inven(VB6.GetItemData(lstInven, i)).Value), 0)), 10) & "]  " & JustText(VB6.GetItemString(lstInven, i)))
				End If
			Else
				VB6.SetItemString(lstInven, i, JustText(VB6.GetItemString(lstInven, i)))
			End If
		Next i
		Dim it As Item
		For i = 0 To lstStore.Items.Count - 1
			If VB.Left(JustText(VB6.GetItemString(lstStore, i)), 1) <> "-" Then
				it = s.Inven(VB6.GetItemData(lstStore, i))
				
				If it.Use = E_SER Then
					If InStr(1, it.BaseName, "Blessing") Then
						If Not char_Renamed.Player.Eq((it.Notes)) Is Nothing Then
							it.Value = Price((char_Renamed.Player.Eq((it.Notes)).Value), 1) * (I_MANT ^ (it.Depth)) - Price((char_Renamed.Player.Eq((it.Notes)).Value), 0)
						Else
							it.Value = 0
						End If
					ElseIf InStr(1, it.BaseName, "Carnival Game") Then 
						it.Value = AtrCost(char_Renamed.Player.Stats((it.Notes)) + 1) * 4 * (I_MANT ^ (char_Renamed.Player.Stats((it.Notes)) / 10))
					End If
				End If
				
				If it.Use = E_TRD Then
					VB6.SetItemString(lstStore, i, "[" & PadSpaces(CStr(TGPrice(s.Inven(VB6.GetItemData(lstStore, i)), s, 1)), 10) & "]  " & JustText(VB6.GetItemString(lstStore, i)))
				Else
					VB6.SetItemString(lstStore, i, "[" & PadSpaces(CStr(Price((s.Inven(VB6.GetItemData(lstStore, i)).Value), 1)), 10) & "]  " & JustText(VB6.GetItemString(lstStore, i)))
				End If
				
			Else
				VB6.SetItemString(lstStore, i, JustText(VB6.GetItemString(lstStore, i)))
			End If
		Next i
		
		For i = 0 To lstStore.Items.Count - 2
			If VB.Left(VB6.GetItemString(lstStore, i), 1) = "-" And VB.Left(VB6.GetItemString(lstStore, i + 1), 1) = "-" Then
				Call lstStore.Items.RemoveAt(i)
				i = i - 1
			End If
		Next i
		
		If VB.Left(VB6.GetItemString(lstStore, lstStore.Items.Count - 1), 1) = "-" Then
			Call lstStore.Items.RemoveAt(lstStore.Items.Count - 1)
		End If
		
		If lstInven.SelectedIndex <> -1 Then
			txCur.Text = VB6.GetItemString(lstInven, lstInven.SelectedIndex)
		ElseIf lstStore.SelectedIndex <> -1 Then 
			txCur.Text = VB6.GetItemString(lstStore, lstStore.SelectedIndex)
		Else
			txCur.Text = ""
		End If
		
		
	End Sub
	
	Private Sub cmdDone_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDone.Click
		Me.Visible = False
		Me.Close()
	End Sub
	
	Private Sub cmdID_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdID.Click
		Dim Res As MsgBoxResult
		Dim d As String
		Dim it As Item
		Dim index As Short
		Dim cost As Double
		
		If lstInven.SelectedIndex = -1 Or VB.Left(VB6.GetItemString(lstInven, lstInven.SelectedIndex), 1) = "-" Then Exit Sub
		
		index = VB6.GetItemData(lstInven, lstInven.SelectedIndex)
		it = char_Renamed.Player.Inven(index)
		
		d = JustText(ItemText(it))
		cost = Price(it.Value \ 10, 1)
		
		Res = MsgBox("Do you wish to identify:" & vbCrLf & d & vbCrLf & "For " & cost & " gold coins?", MsgBoxStyle.YesNo, "Buy Item")
		
		If Res = MsgBoxResult.Yes And char_Renamed.Player.Gold >= cost Then
			char_Renamed.Player.Gold = char_Renamed.Player.Gold - cost
			it.ID = True
		ElseIf Res = MsgBoxResult.Yes Then 
			MsgBox("You don't have enough gold!",  , "Identify")
		End If
		
		RefreshStore()
		
	End Sub
	
	Private Sub frmStore_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim keyascii As Short = Asc(eventArgs.KeyChar)
		If keyascii = 27 Then
			Call cmdDone_Click(cmdDone, New System.EventArgs())
		ElseIf keyascii = Asc("i") Or keyascii = Asc("I") Then 
			Call cmdID_Click(cmdID, New System.EventArgs())
		End If
		eventArgs.KeyChar = Chr(keyascii)
		If keyascii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub lstInven_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstInven.DoubleClick
		Dim Res As MsgBoxResult
		Dim d As String
		Dim it As Item
		Dim index As Short
		Dim cost As Integer
		
		If VB.Left(VB6.GetItemString(lstInven, lstInven.SelectedIndex), 1) = "-" Then Exit Sub
		
		index = VB6.GetItemData(lstInven, lstInven.SelectedIndex)
		it = char_Renamed.Player.Inven(index)
		
		d = JustText(ItemText(it))
		
		If it.Use = E_TRD Then
			cost = TGPrice(it, s, 0)
		Else
			cost = Price((it.Value), 0)
		End If
		
		Res = MsgBox("Do you wish to sell:" & vbCrLf & d & vbCrLf & "For " & cost & " gold coins?", MsgBoxStyle.YesNo, "Sell Item")
		
		If Res = MsgBoxResult.Yes Then
			it.ID = True
			Call s.AddInven(it, 1)
			Call char_Renamed.Player.RemInven(it, 1)
			char_Renamed.Player.Gold = char_Renamed.Player.Gold + cost
			Call char_Renamed.Player.CalcDervs()
		End If
		RefreshStore()
	End Sub
	
	Private Sub lstStore_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstStore.DoubleClick
		Dim Res As MsgBoxResult
		Dim d As String
		Dim it As Item
		Dim index As Short
		Dim cost As Double
		
		index = VB6.GetItemData(lstStore, lstStore.SelectedIndex)
		it = s.Inven(index)
		
		d = JustText(ItemText(it))
		
		If s.Inven(index).Use = E_TRD Then
			cost = TGPrice(s.Inven(index), s, 1)
		Else
			cost = Price((s.Inven(index).Value), 1)
		End If
		
		Res = MsgBox("Do you wish to buy:" & vbCrLf & d & vbCrLf & "For " & cost & " gold coins?", MsgBoxStyle.YesNo, "Buy Item")
		
		If Res = MsgBoxResult.Yes And char_Renamed.Player.Gold >= cost And it.Use = E_SER Then
			char_Renamed.Player.Gold = char_Renamed.Player.Gold - cost
			Call it.UseF(-1)
		ElseIf Res = MsgBoxResult.Yes And char_Renamed.Player.Gold >= cost Then 
			it.ID = True
			Call char_Renamed.Player.AddInven(it, 1)
			Call s.RemInven(it, 1)
			char_Renamed.Player.Gold = char_Renamed.Player.Gold - cost
		ElseIf Res = MsgBoxResult.Yes Then 
			MsgBox("You don't have enough gold!",  , "Buy Item")
		End If
		
		RefreshStore()
	End Sub
	'UPGRADE_WARNING: Event lstInven.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub lstInven_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstInven.SelectedIndexChanged
		If lstInven.SelectedIndex <> -1 And VB.Left(VB6.GetItemString(lstInven, lstInven.SelectedIndex), 1) <> "-" Then
			txCur.Text = VB6.GetItemString(lstInven, lstInven.SelectedIndex)
		Else
			txCur.Text = ""
		End If
		
	End Sub
	'UPGRADE_WARNING: Event lstStore.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub lstStore_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstStore.SelectedIndexChanged
		If lstStore.SelectedIndex <> -1 And VB.Left(VB6.GetItemString(lstStore, lstStore.SelectedIndex), 1) <> "-" Then
			txCur.Text = VB6.GetItemString(lstStore, lstStore.SelectedIndex)
		Else
			txCur.Text = ""
		End If
		
	End Sub
End Class