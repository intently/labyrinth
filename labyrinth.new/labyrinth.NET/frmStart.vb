Option Strict Off
Option Explicit On
Friend Class frmStart
	Inherits System.Windows.Forms.Form
	Private Sub cmdQuit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdQuit.Click
		Me.Close()
		'  Unload frmGame
	End Sub
	
	Private Sub cmdStart_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdStart.Click
		frmGame = New frmGame
		
		Call Generate()
		
		Me.Visible = False
		frmGame.Visible = True
		Loc_Renamed = 0
		Call RefreshGame()
		Me.Close()
	End Sub
	
	Private Sub frmStart_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Randomize()
	End Sub
End Class