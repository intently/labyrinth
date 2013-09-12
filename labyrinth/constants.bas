Attribute VB_Name = "constants"
Option Explicit
'Base 0

Public Const C_HARDDEATH As Integer = 0
Public Const C_MAXCONNECTS As Integer = 5
Public Const C_LOCS As Integer = 1000
Public Const C_INVMAX As Integer = 100
Public Const C_WAGONMAX As Integer = 20
Public Const C_RMAX As Integer = 100
Public Const C_SAMETERRAINCHANCE As Integer = 100
Public Const C_DIFTERRAINCHANCE As Integer = 20
Public Const C_MAXATTACKS As Integer = 5
Public Const C_STOREINVENTARGET As Integer = 30
Public Const C_VALUEPERLEVEL As Single = 600
Public Const C_ARM_COST As Single = 0.5
Public Const C_WEP_COST As Single = 0.5
Public Const C_PEOPLE As Integer = 100
Public Const C_TMANT As Double = 1.5
Public Const C_KILLSECTOR As Integer = 0

Public Const C_STATS As Integer = 7
Public Const S_STR As Integer = 0 ' strength
Public Const S_DEX As Integer = 1 ' dexterity
Public Const S_CON As Integer = 2 ' constitution
Public Const S_INT As Integer = 3 ' intelligence
Public Const S_WIS As Integer = 4 ' wisdom
Public Const S_CHA As Integer = 5 ' charisma
Public Const S_REP As Integer = 6 ' reputation

Public Const D_SAT As Integer = 0
Public Const D_DAT As Integer = 1
Public Const D_DEF As Integer = 2
Public Const D_HTP As Integer = 3
Public Const D_SPD As Integer = 4
Public Const D_PER As Integer = 5
Public Const D_LUK As Integer = 6
Public Const D_DAM As Integer = 7
Public Const D_DR As Integer = 8
Public Const D_CHP As Integer = 9
Public Const D_DMS As Integer = 10

Public Const E_WEP As Integer = 0
Public Const E_ARM As Integer = 1
Public Const E_SLD As Integer = 2
Public Const E_HLM As Integer = 3
Public Const E_GNT As Integer = 4
Public Const E_BTS As Integer = 5
Public Const E_RG1 As Integer = 6
Public Const E_RG2 As Integer = 7
Public Const E_NON As Integer = 8
Public Const E_SER As Integer = 9
Public Const E_TRD As Integer = 10

Public Const T_FOR As Integer = 0 ' forest, wood
Public Const T_DES As Integer = 1 ' desert, oil
Public Const T_PLN As Integer = 2 ' plains, food
Public Const T_HIL As Integer = 3 ' hills,  ore
Public Const T_JUN As Integer = 4 ' jungle, artifacts, wood
Public Const T_MTN As Integer = 5 ' mountains, ore, gems
Public Const T_SWP As Integer = 6 ' swamp,  artifacts
Public Const T_TUN As Integer = 7 ' tundra, oil
Public Const T_ALL As Integer = 8
Public Const T_GHOST As Integer = 9
Public Const T_GOBLIN As Integer = 10
Public Const T_MAX As Integer = 10
Public Const T_MAXUSED As Integer = 3

Public Const G_WOOD As Integer = 0
Public Const G_FOOD As Integer = 1
Public Const G_ORES As Integer = 2
Public Const G_GEMS As Integer = 3
Public Const G_ARTS As Integer = 4
Public Const G_WEPS As Integer = 5
Public Const G_MEDS As Integer = 6
Public Const G_MAX As Integer = 7

Public Const C_FLAGS As Long = 17 ' attack flags
Public Const F_FIRE As Long = 1
Public Const F_COLD As Long = 2
Public Const F_ELEC As Long = 4
Public Const F_CONF As Long = 8
Public Const F_PIRC As Long = 16
Public Const F_SLOW As Long = 32
Public Const F_POIS As Long = 64
Public Const F_MAGI As Long = 128
Public Const F_FAST As Long = 256
Public Const F_BLND As Long = 512
Public Const F_SLEP As Long = 1024
Public Const F_STUN As Long = 2048
Public Const F_REGN As Long = 4096
Public Const F_LIFE As Long = 8192
Public Const F_HYPR As Long = 16384
Public Const F_VAMP As Long = 32768
Public Const F_TRUE As Long = 65536
Public Const F_LONG As Long = 131072

Public Const C_RESISTS As Integer = 4
Public Const R_FIRE As Integer = 0
Public Const R_COLD As Integer = 1
Public Const R_ELEC As Integer = 2
Public Const R_MAGI As Integer = 3

Public Const C_COUNTERS As Integer = 15
Public Const N_POIS As Integer = 0
Public Const N_FIRE As Integer = 1
Public Const N_COLD As Integer = 2
Public Const N_FAST As Integer = 3
Public Const N_SLOW As Integer = 4
Public Const N_INVS As Integer = 5
Public Const N_IVLN As Integer = 6
Public Const N_REGN As Integer = 7
Public Const N_DETH As Integer = 8
Public Const N_CONF As Integer = 9
Public Const N_BLND As Integer = 10
Public Const N_SLEP As Integer = 11
Public Const N_STUN As Integer = 12
Public Const N_BLES As Integer = 13
Public Const N_PROT As Integer = 14

Public Const C_STORES As Integer = 6
Public Const S_WEP As Integer = 0
Public Const S_ARM As Integer = 1
Public Const S_GEN As Integer = 2
Public Const S_MAG As Integer = 3
Public Const S_INN As Integer = 4
Public Const S_MRK As Integer = 5

Public Const S_TRAN As Integer = 6
Public Const S_ACAD As Integer = 7
Public Const S_CARN As Integer = 8
Public Const S_TEMP As Integer = 9
Public Const S_CAST As Integer = 10

Public Const C_SPELLS As Integer = 14
Public Const M_MMIS As Integer = 0
Public Const M_HEAL As Integer = 1
Public Const M_TELE As Integer = 2
Public Const M_STUN As Integer = 3
Public Const M_TOWN As Integer = 4
Public Const M_FAST As Integer = 5
Public Const M_SLOW As Integer = 6
Public Const M_BLES As Integer = 7
Public Const M_FIRE As Integer = 8
Public Const M_COLD As Integer = 9
Public Const M_ELEC As Integer = 10
Public Const M_SPRK As Integer = 11
Public Const M_FLEE As Integer = 12
Public Const M_PROT As Integer = 13

Public Const M_SPRK_C As Integer = 50
Public Const M_SPRK_D As Integer = 0
Public Const M_PROT_C As Integer = 100
Public Const M_PROT_D As Integer = 1
Public Const M_MMIS_C As Integer = 100
Public Const M_MMIS_D As Integer = 2
Public Const M_FLEE_C As Integer = 150
Public Const M_FLEE_D As Integer = 3
Public Const M_HEAL_C As Integer = 200
Public Const M_HEAL_D As Integer = 4
Public Const M_FIRE_C As Integer = 500
Public Const M_FIRE_D As Integer = 5
Public Const M_COLD_C As Integer = 500
Public Const M_COLD_D As Integer = 5
Public Const M_ELEC_C As Integer = 500
Public Const M_ELEC_D As Integer = 5
Public Const M_TELE_C As Integer = 300
Public Const M_TELE_D As Integer = 6
Public Const M_BLES_C As Integer = 1000
Public Const M_BLES_D As Integer = 7
Public Const M_STUN_C As Integer = 600
Public Const M_STUN_D As Integer = 8
Public Const M_FAST_C As Integer = 300
Public Const M_FAST_D As Integer = 9
Public Const M_SLOW_C As Integer = 300
Public Const M_SLOW_D As Integer = 9
Public Const M_TOWN_C As Integer = 500
Public Const M_TOWN_D As Integer = 10

Public Const E_SAT As Integer = 12
Public Const E_DAT As Integer = 11
Public Const E_DEF As Integer = 10
Public Const E_HTP As Integer = 10
Public Const E_SPD As Integer = 10
Public Const E_DAM As Integer = 3
Public Const E_DR As Integer = 2
Public Const E_POINTS As Integer = 40

Public Const I_ATT As Integer = 11
Public Const I_DAM As Integer = 16
Public Const I_DEF As Integer = 16
Public Const I_DR As Integer = 30
Public Const I_STAT As Integer = 30
Public Const I_RES As Integer = 15
Public Const I_BASE As Integer = 100
Public Const I_FLAG As Integer = 750
Public Const I_MANT As Double = 1.5

Public Const B_CAST As Integer = 6
Public Const B_WALL As Integer = 0
Public Const B_FARM As Integer = 1
Public Const B_MARK As Integer = 2
Public Const B_TRAN As Integer = 3
Public Const B_BANK As Integer = 4
Public Const B_SPEC As Integer = 5


Public Function Min(A As Variant, b As Variant) As Variant
  If A < b Then
    Min = A
  Else
    Min = b
  End If
End Function

Public Function Max(A As Variant, b As Variant) As Variant
  If A > b Then
    Max = A
  Else
    Max = b
  End If
End Function

Public Function TG(T As Integer) As Long
  TG = CLng(C_TMANT ^ T) * CLng(Rnd * 20 + (60 - 3 * T))
  TG = TG * Min(Max(0.5, ((char.Player.Dervs(D_LUK) + char.Player.Dervs(D_PER)) / (2 * char.Player.Stats(S_REP) + 10))), 2)
  TG = CLng(TG)
End Function

Public Function Dice(num As Integer, sides As Integer) As Integer
  Dim i As Integer
  
  For i = 0 To num - 1
    Dice = Dice + Int(Rnd * sides) + 1
  Next i
End Function

Public Function PM(ByVal n As Variant, ByVal A As Integer) As Long
  PM = CLng((CDbl(n) * (1# - (CDbl(A) / 100#))) + (Rnd * 2# * (CDbl(A) / 100#) * CDbl(n)))
End Function

Public Function Price(it As Long, h As Integer) As Long
  Dim m As Integer
  m = Min(600, char.Player.Dervs(D_PER) + char.Player.Reals(S_CHA) + char.Player.Reals(S_REP))
  
  ' 1 = player buy price, 0 = player sell price
  If h = 1 Then
    Price = it * ((1200 - m) / 600)
  ElseIf h = 0 Then
    Price = it * ((600 + m) / 1200)
  End If
End Function

Public Function TGPrice(it As Item, st As Store, h As Integer) As Long
  Dim m As Integer
  
  m = Min(1000, (char.Player.Dervs(D_PER) + char.Player.Reals(S_CHA) + char.Player.Reals(S_REP) + char.Player.Dervs(S_INT) * 2) / 4 + 750)
  
  ' 1 = buy price, 0 = sell price
  If h = 1 Then
    TGPrice = it.Value * ((2000 - m) / 1000) * st.TGP(it.Att)
  ElseIf h = 0 Then
    TGPrice = it.Value * ((1000 + m) / 2000) * st.TGP(it.Att)
  End If
End Function

Public Sub DispMonster(Mo As Monster, off As Integer)
  Dim tx As String
  Dim i As Integer
  
  tx = ""
  tx = tx & "Name:" & vbTab & Mo.Name & vbCrLf
  tx = tx & "Terrain:" & vbTab & TerName(Mo.Terrain) & vbCrLf
  tx = tx & "Depth:" & vbTab & PM(Mo.Depth, off) & vbCrLf
  tx = tx & "Killed:" & vbTab & Player.KH(Mo.Terrain, Mo.Depth) & vbCrLf
  tx = tx & "Studied:" & vbTab & CBool(Player.KL(Mo.Terrain, Mo.Depth)) & vbCrLf & vbCrLf
  
  tx = tx & "Attack:" & vbTab & PM(Mo.Dervs(D_SAT), off) & vbCrLf
  tx = tx & "Damage:" & vbTab & PM(Mo.Dervs(D_DAM), off) & vbCrLf
  tx = tx & "Speed:" & vbTab & PM(Mo.Dervs(D_SPD), off) & vbCrLf
  tx = tx & "Defense:" & vbTab & PM(Mo.Dervs(D_DEF), off) & vbCrLf
  tx = tx & "DR:" & vbTab & PM(Mo.Dervs(D_DR), off) & vbCrLf
  tx = tx & "Cur HP:" & vbTab & PM(Mo.Dervs(D_CHP), off) & vbCrLf
  tx = tx & "Max HP:" & vbTab & PM(Mo.Dervs(D_HTP), off) & vbCrLf & vbCrLf
  
  tx = tx & "Attacks:" & vbCrLf
  
  For i = 0 To C_MAXATTACKS - 1
    If Mo.Atts(i) <> "" And char.Player.KH(Mo.Terrain, Mo.Depth) + char.Player.KL(Mo.Terrain, Mo.Depth) > 50 - Mo.AttP(i) Then
      tx = tx & vbTab & Mo.Atts(i) & vbCrLf
    End If
  Next i
  
  tx = tx & vbCrLf
  
  If Mo.Res(R_MAGI) < 0 And char.Player.KH(Mo.Terrain, Mo.Depth) + char.Player.KL(Mo.Terrain, Mo.Depth) > 50 + Mo.Res(R_MAGI) Then
    tx = tx & "Weak against Magic" & vbCrLf
  ElseIf Mo.Res(R_MAGI) > 0 And char.Player.KH(Mo.Terrain, Mo.Depth) + char.Player.KL(Mo.Terrain, Mo.Depth) > 50 - Mo.Res(R_MAGI) Then
    tx = tx & "Resistant to Magic" & vbCrLf
  End If
  If Mo.Res(R_FIRE) < 0 And char.Player.KH(Mo.Terrain, Mo.Depth) + char.Player.KL(Mo.Terrain, Mo.Depth) > 50 + Mo.Res(R_FIRE) Then
    tx = tx & "Weak against Fire" & vbCrLf
  ElseIf Mo.Res(R_FIRE) > 0 And char.Player.KH(Mo.Terrain, Mo.Depth) + char.Player.KL(Mo.Terrain, Mo.Depth) > 50 - Mo.Res(R_FIRE) Then
    tx = tx & "Resistant to Fire" & vbCrLf
  End If
  If Mo.Res(R_COLD) < 0 And char.Player.KH(Mo.Terrain, Mo.Depth) + char.Player.KL(Mo.Terrain, Mo.Depth) > 50 + Mo.Res(R_COLD) Then
    tx = tx & "Weak against Cold" & vbCrLf
  ElseIf Mo.Res(R_COLD) > 0 And char.Player.KH(Mo.Terrain, Mo.Depth) + char.Player.KL(Mo.Terrain, Mo.Depth) > 50 - Mo.Res(R_COLD) Then
    tx = tx & "Resistant to Cold" & vbCrLf
  End If
  If Mo.Res(R_ELEC) < 0 And char.Player.KH(Mo.Terrain, Mo.Depth) + char.Player.KL(Mo.Terrain, Mo.Depth) > 50 + Mo.Res(R_ELEC) Then
    tx = tx & "Weak against Electricity" & vbCrLf
  ElseIf Mo.Res(R_ELEC) > 0 And char.Player.KH(Mo.Terrain, Mo.Depth) + char.Player.KL(Mo.Terrain, Mo.Depth) > 50 - Mo.Res(R_ELEC) Then
    tx = tx & "Resistant to Electricity" & vbCrLf
  End If
  
  MsgBox tx, , Mo.Name & " Statistics"
End Sub

Public Function ItemText(it As Item) As String
  If it.ID = True Then
    ItemText = it.Text
  Else
    ItemText = it.UnIDText
  End If
End Function

Public Function Spread(c As Integer, s As Integer) As Integer
  Spread = Int(c - s * c / 100 + Rnd * 2 * s * c / 100)
End Function

Public Function IR(base As Integer, radius As Integer) As Integer
  IR = Int(base - radius + Rnd * 2 * radius)
End Function

Public Function AtrCost(i As Integer, Optional adjuster As Integer = 0) As Integer
  Dim j As Integer
  Dim c As Double
  
  c = 0
  For j = 0 To 6
    c = c + char.Player.Stats(j)
  Next j
  c = c - i - 50 + 1 - adjuster
  c = c \ 10
  
  AtrCost = Int(((CDbl(i + 23#) / 7.5) ^ 2.1)) + c
End Function

Public Function ctListSort(ctl As ctList, col As Integer) As Integer
  Dim i As Integer
  
'  Call ctListMergeSort(ctl, col, 0, ctl.ListCount - 1)
  Call ctListBubbleSort(ctl, col)
End Function

Public Function ctListBubbleSort(ctl As ctList, col As Integer) As Integer
  Dim i, j As Integer
  Dim s As String
  
  For i = 0 To ctl.ListCount - 1
    For j = 0 To ctl.ListCount - 1
      If (0.5 - ctl.SortDirection) * CDbl(ctl.ListColumnText(i, col)) < (0.5 - ctl.SortDirection) * CDbl(ctl.ListColumnText(j, col)) Then
        s = ctl.ListText(i)
        Call ctl.RemoveItem(i)
        Call ctl.InsertItem(s, j)
      End If
    Next j
  Next i
  
End Function

Public Function ctListMergeSort(ctl As ctList, col As Integer, A As Integer, b As Integer) As Integer
' doesn't work... piece of crap
  Dim i, j, K, p As Integer
  Dim s, T(0 To C_SPELLS - 1) As String
  
  p = (A + b) \ 2
  
  If A = b Then
    Exit Function
  ElseIf b - A = 1 Then
    If CDbl(ctl.ListColumnText(A, col)) < CDbl(ctl.ListColumnText(b, col)) Then
      s = ctl.ListText(A)
      Call ctl.RemoveItem(A)
      Call ctl.InsertItem(s, b)
    End If
    Exit Function
  Else
    Call ctListMergeSort(ctl, col, A, p)
    Call ctListMergeSort(ctl, col, p + 1, b)
    
    i = A
    j = p + 1
    K = 0
    
    For K = A To b
      If (CDbl(ctl.ListColumnText(i, col)) < CDbl(ctl.ListColumnText(Min(b, j), col)) And i <= p) Or j > b Then
        T(K) = ctl.ListText(i)
        i = i + 1
      Else
        T(K) = ctl.ListText(j)
        j = j + 1
      End If
    Next K
    
    For K = A To b
      Call ctl.RemoveItem(A)
    Next K
  
    For K = A To b
      Call ctl.InsertItem(T(K), K)
    Next K
  
  End If
End Function
