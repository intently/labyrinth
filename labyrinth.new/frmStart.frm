VERSION 5.00
Begin VB.Form frmStart 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Labyrinth"
   ClientHeight    =   4485
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   1830
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   4485
   ScaleWidth      =   1830
   StartUpPosition =   2  'CenterScreen
   Begin VB.Frame frStatus 
      Caption         =   "Status"
      Height          =   3015
      Left            =   0
      TabIndex        =   2
      Top             =   1440
      Width           =   1815
      Begin VB.CheckBox ckStatus 
         Caption         =   "(6) Specials"
         Enabled         =   0   'False
         Height          =   495
         Index           =   6
         Left            =   120
         TabIndex        =   9
         Top             =   2400
         Width           =   1575
      End
      Begin VB.CheckBox ckStatus 
         Caption         =   "(5) Regions"
         Enabled         =   0   'False
         Height          =   495
         Index           =   5
         Left            =   120
         TabIndex        =   8
         Top             =   2040
         Width           =   1575
      End
      Begin VB.CheckBox ckStatus 
         Caption         =   "(4) Depth"
         Enabled         =   0   'False
         Height          =   495
         Index           =   4
         Left            =   120
         TabIndex        =   7
         Top             =   1680
         Width           =   1575
      End
      Begin VB.CheckBox ckStatus 
         Caption         =   "(3) Sort"
         Enabled         =   0   'False
         Height          =   495
         Index           =   3
         Left            =   120
         TabIndex        =   6
         Top             =   1320
         Width           =   1575
      End
      Begin VB.CheckBox ckStatus 
         Caption         =   "(2) Renumber"
         Enabled         =   0   'False
         Height          =   495
         Index           =   2
         Left            =   120
         TabIndex        =   5
         Top             =   960
         Width           =   1575
      End
      Begin VB.CheckBox ckStatus 
         Caption         =   "(1) Connect"
         Enabled         =   0   'False
         Height          =   495
         Index           =   1
         Left            =   120
         TabIndex        =   4
         Top             =   600
         Width           =   1575
      End
      Begin VB.CheckBox ckStatus 
         Caption         =   "(0) Create Nodes"
         Enabled         =   0   'False
         Height          =   495
         Index           =   0
         Left            =   120
         TabIndex        =   3
         Top             =   240
         Width           =   1575
      End
   End
   Begin VB.CommandButton cmdQuit 
      Caption         =   "Quit"
      Height          =   615
      Left            =   0
      TabIndex        =   1
      Top             =   720
      Width           =   1815
   End
   Begin VB.CommandButton cmdStart 
      Caption         =   "Start New Game"
      Height          =   615
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   1815
   End
End
Attribute VB_Name = "frmStart"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Private Sub cmdQuit_Click()
  Unload frmStart
'  Unload frmGame
End Sub

Private Sub cmdStart_Click()
  Set frmGame = New frmGame
    
  Call Generate
  
  frmStart.Visible = False
  frmGame.Visible = True
  Loc = 0
  Call RefreshGame
  Unload frmStart
End Sub

Private Sub Form_Load()
  Randomize
End Sub
