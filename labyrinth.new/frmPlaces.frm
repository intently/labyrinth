VERSION 5.00
Begin VB.Form frmPlaces 
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Locations of Interest"
   ClientHeight    =   5535
   ClientLeft      =   45
   ClientTop       =   285
   ClientWidth     =   4350
   KeyPreview      =   -1  'True
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   5535
   ScaleWidth      =   4350
   ShowInTaskbar   =   0   'False
   StartUpPosition =   2  'CenterScreen
   Begin VB.ListBox lstPlaces 
      Height          =   5520
      Left            =   0
      Sorted          =   -1  'True
      TabIndex        =   0
      Top             =   0
      Width           =   4335
   End
End
Attribute VB_Name = "frmPlaces"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Private Sub Form_Load()
  RefreshPlaces
End Sub

Public Sub RefreshPlaces()
  Dim i As Integer
  Dim lc As City
  Dim s As String
  
  Call lstPlaces.Clear
   
  For i = 0 To C_LOCS - 1
    If (World.World(i).Explored = 1 Or World.World(i).Known = 1 Or frmGame.ckCombat = 1) And Not World.World(i).LCity Is Nothing Then
      Set lc = World.World(i).LCity
      s = lc.T
      If lc.Size <> -1 Then s = s & " (" & lc.Size & ")"
      If lc.Name <> "None" Then s = s & " " & lc.Name
      
      s = s & " [" & i & "]"
      
      If World.World(i).Explored = 0 Then
        s = s & "*"
      End If
      
      lstPlaces.AddItem (s)
    End If
  Next i
End Sub

Private Sub lstPlaces_DblClick()
  Dim i As Integer
  Dim l As String
  Dim r As String
  
  l = Left(lstPlaces.Text, InStr(1, lstPlaces.Text, "]", vbTextCompare) - 1)
  r = Right(l, Len(l) - InStr(1, l, "[", vbTextCompare))
  
  
  i = Val(r)
  frmGame.txRoute.Text = i
  frmPlaces.Visible = False

  frmGame.SetFocus
  If frmGame.cmdRoute.Enabled = True Then
    frmGame.cmdRoute.SetFocus
  End If
End Sub
Private Sub Form_KeyPress(keyascii As Integer)
  If keyascii = 27 Then
    Unload Me
  End If
End Sub

