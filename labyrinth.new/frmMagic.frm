VERSION 5.00
Object = "{DC4027A0-633A-11D1-943D-444553540000}#1.0#0"; "ctlist32.ocx"
Begin VB.Form frmMagic 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Known Spells"
   ClientHeight    =   5670
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   5715
   KeyPreview      =   -1  'True
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   ScaleHeight     =   5670
   ScaleWidth      =   5715
   StartUpPosition =   2  'CenterScreen
   Begin CTLISTLibCtl.ctList lstSpells 
      Height          =   5655
      Left            =   0
      TabIndex        =   0
      TabStop         =   0   'False
      Top             =   0
      Width           =   5685
      _Version        =   65536
      _ExtentX        =   10028
      _ExtentY        =   9975
      _StockProps     =   77
      BackColor       =   16777215
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BeginProperty TitleFont {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BeginProperty HeaderFont {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      TitleBackImage  =   "frmMagic.frx":0000
      HeaderPicture   =   "frmMagic.frx":001C
      Picture         =   "frmMagic.frx":0038
      CheckPicDown    =   "frmMagic.frx":0054
      CheckPicUp      =   "frmMagic.frx":0070
      BreakChar       =   "|"
      HeaderAlign     =   0
      SortDirection   =   1
      SortColumn      =   2
      ShowHeader      =   -1  'True
      AlternateColor  =   -1  'True
      HorzGridLines   =   -1  'True
      VertGridLines   =   -1  'True
      SortArrows      =   0   'False
      HeaderData      =   "frmMagic.frx":008C
   End
End
Attribute VB_Name = "frmMagic"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Private Sub Form_Unload(cancel As Integer)
  If frmCombat.InCombat = 1 Then
    frmCombat.Visible = True
  End If
End Sub
Private Sub Form_Load()
  RefreshSpells
End Sub

Public Sub RefreshSpells()
  Dim s As String
  Dim avail As Integer
  Dim pts As Integer
  Dim x As Spell
  Dim nIndex As Integer
  
  Call lstSpells.ClearList

  For Each x In char.Player.Spells
    avail = x.Points \ x.cost
    pts = x.Points Mod x.cost
    
'    s = "(" & avail & "/" & Player.Reals(S_WIS) * 10 \ x.cost & ")|" & Int((char.Player.Reals(S_INT) + x.Skill) / (x.Depth * 10 + char.Player.Reals(S_INT) + x.Skill) * 100) & "|" & x.Key & "|" & x.Desc & "|" & (x.Used) '& " [" & pts & "/" & x.cost & "]"
    s = "(" & avail & "/" & Player.Reals(S_WIS) * 10 \ x.cost & ")|" & Int((char.Player.Reals(S_INT) + x.Skill) / (x.Depth * 10 + char.Player.Reals(S_INT) + x.Skill) * 100) & "|" & x.Key & "|" & x.Desc & "|" & (x.Depth) '& " [" & pts & "/" & x.cost & "]"
    
    nIndex = lstSpells.AddItem(s)
'    lstSpells.ListCargo(nIndex) = x.Used
'    lstSpells.List(lstSpells.NewIndex) = x.Used & "|" & "(" & avail & "/" & Player.Reals(S_WIS) * 10 \ x.cost & ") " & lstSpells.List(lstSpells.NewIndex) & " [" & pts & "/" & x.cost & "]"
    
  Next x
  lstSpells.SortColumn = 5
'  lstSpells.SortDirection = SortAscend
  Call ctListSort(lstSpells, 5)
'  lstSpells.SortList
End Sub
Private Sub lstSpells_DblClick()
  Dim sp As String
  Dim l As String
  Dim r As String
  
'  l = Left(lstSpells.ListText(Val(lstSpells.Tag)), InStr(1, lstSpells.ListText(Val(lstSpells.Tag)), "[", vbTextCompare) - 2)
'  r = Right(l, Len(l) - InStr(1, l, ")", vbTextCompare) - 1)
  
  sp = lstSpells.ListColumnText(Val(lstSpells.Tag), 3)
    
  'lstSpells.ListCargo(lstSpells.Tag) = Str(CDbl(Now()))
  char.Player.Spells(sp).Used = Str(CDbl(Now()))
    
  Call char.Player.Cast(sp)
  
  frmMagic.Visible = False
  If frmCombat.InCombat = 1 Then
    frmCombat.Visible = True
    Call frmCombat.RefreshCombat
    Call frmCombat.EnemyAttack
  End If
'  frmGame.SetFocus
End Sub
Private Sub Form_KeyPress(keyascii As Integer)
  If keyascii = 27 Then
    Unload Me
  End If
End Sub

Private Sub lstSpells_Change(ByVal nIndex As Integer)
  lstSpells.Tag = nIndex
End Sub

