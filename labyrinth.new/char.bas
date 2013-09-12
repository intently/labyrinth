Attribute VB_Name = "char"
Option Explicit
Public Player As New Character
Public Locked(0 To 6) As Long
Public LockedPoints As Long

Public Function IsEquipped(T As Item) As Integer
  Dim i As Integer
  For i = 0 To 7
    If Player.Eq(i) Is T Then
      IsEquipped = i
      Exit Function
    End If
  Next i
  IsEquipped = -1
End Function
