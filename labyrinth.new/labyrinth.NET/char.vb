Option Strict Off
Option Explicit On
'UPGRADE_NOTE: char was upgraded to char_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
Module char_Renamed
	Public Player As New Character
	Public Locked(6) As Integer
	Public LockedPoints As Integer
	
	Public Function IsEquipped(ByRef T As Item) As Short
		Dim i As Short
		For i = 0 To 7
			If Player.Eq(i) Is T Then
				IsEquipped = i
				Exit Function
			End If
		Next i
		IsEquipped = -1
	End Function
End Module