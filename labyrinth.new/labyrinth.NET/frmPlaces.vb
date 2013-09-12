Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmPlaces
	Inherits System.Windows.Forms.Form
	Private Sub frmPlaces_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		RefreshPlaces()
	End Sub
	
	Public Sub RefreshPlaces()
		Dim i As Short
		Dim lc As City
		Dim s As String
		
		Call lstPlaces.Items.Clear()
		
		For i = 0 To C_LOCS - 1
			'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If (World_Renamed.World(i).Explored = 1 Or World_Renamed.World(i).Known = 1 Or frmGame.ckCombat.CheckState = 1) And Not World_Renamed.World(i).LCity Is Nothing Then
				'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				lc = World_Renamed.World(i).LCity
				s = lc.T
				If lc.Size <> -1 Then s = s & " (" & lc.Size & ")"
				If lc.Name <> "None" Then s = s & " " & lc.Name
				
				s = s & " [" & i & "]"
				
				'UPGRADE_WARNING: Couldn't resolve default property of object World_Renamed.World. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If World_Renamed.World(i).Explored = 0 Then
					s = s & "*"
				End If
				
				lstPlaces.Items.Add((s))
			End If
		Next i
	End Sub
	
	Private Sub lstPlaces_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstPlaces.DoubleClick
		Dim i As Short
		Dim l As String
		Dim r As String
		
		l = VB.Left(lstPlaces.Text, InStr(1, lstPlaces.Text, "]", CompareMethod.Text) - 1)
		r = VB.Right(l, Len(l) - InStr(1, l, "[", CompareMethod.Text))
		
		
		i = Val(r)
		frmGame.txRoute.Text = CStr(i)
		Me.Visible = False
		
		frmGame.Activate()
		If frmGame.cmdRoute.Enabled = True Then
			frmGame.cmdRoute.Focus()
		End If
	End Sub
	Private Sub frmPlaces_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim keyascii As Short = Asc(eventArgs.KeyChar)
		If keyascii = 27 Then
			Me.Close()
		End If
		eventArgs.KeyChar = Chr(keyascii)
		If keyascii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
End Class