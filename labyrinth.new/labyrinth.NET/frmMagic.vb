Option Strict Off
Option Explicit On
Friend Class frmMagic
	Inherits System.Windows.Forms.Form
	Private Sub frmMagic_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		If frmCombat.InCombat = 1 Then
			frmCombat.Visible = True
		End If
	End Sub
	Private Sub frmMagic_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		RefreshSpells()
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
	Private Sub lstSpells_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstSpells.DblClick
		Dim sp As String
		Dim l As String
		Dim r As String
		
		'  l = Left(lstSpells.ListText(Val(lstSpells.Tag)), InStr(1, lstSpells.ListText(Val(lstSpells.Tag)), "[", vbTextCompare) - 2)
		'  r = Right(l, Len(l) - InStr(1, l, ")", vbTextCompare) - 1)
		
		sp = lstSpells.get_ListColumnText(Val(lstSpells.Tag), 3)
		
		'lstSpells.ListCargo(lstSpells.Tag) = Str(CDbl(Now()))
		'UPGRADE_WARNING: Couldn't resolve default property of object char_Renamed.Player.Spells(sp).Used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		char_Renamed.Player.Spells.Item(sp).Used = Str(Now.ToOADate())
		
		Call char_Renamed.Player.Cast(sp)
		
		Me.Visible = False
		If frmCombat.InCombat = 1 Then
			frmCombat.Visible = True
			Call frmCombat.RefreshCombat()
			Call frmCombat.EnemyAttack()
		End If
		'  frmGame.SetFocus
	End Sub
	Private Sub frmMagic_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim keyascii As Short = Asc(eventArgs.KeyChar)
		If keyascii = 27 Then
			Me.Close()
		End If
		eventArgs.KeyChar = Chr(keyascii)
		If keyascii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub lstSpells_Change(ByVal eventSender As System.Object, ByVal eventArgs As AxCTLISTLib._DctListEvents_ChangeEvent) Handles lstSpells.Change
		lstSpells.Tag = eventArgs.nIndex
	End Sub
End Class