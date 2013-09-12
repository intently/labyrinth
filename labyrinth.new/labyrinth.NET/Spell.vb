Option Strict Off
Option Explicit On
Friend Class Spell
	Public cost As Short
	'Public Name As String
	Public Points As Short
	Public Key As String
	Public Used As Object
	Public Depth As Short
	Public Desc As String
	Public Skill As Double
	'UPGRADE_WARNING: Lower bound of array SDM was changed from M_SPRK_D to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
	Private SDM(M_TOWN_D) As Short
	
	Public Sub MakeSpell(ByRef K As Short)
		If K = M_SPRK Then
			cost = M_SPRK_C
			Points = 0
			Key = "Sparkler"
			Depth = M_SPRK_D
			Desc = "Blast of sparks causes minor damage."
		ElseIf K = M_PROT Then 
			cost = M_PROT_C
			Points = 0
			Key = "Protection"
			Depth = M_PROT_D
			Desc = "Creates a defensive shield."
		ElseIf K = M_MMIS Then 
			cost = M_MMIS_C
			Points = 0
			Key = "Magic Missile"
			Depth = M_MMIS_D
			Desc = "Launches piercing magic bolts."
		ElseIf K = M_FLEE Then 
			cost = M_FLEE_C
			Points = 0
			Key = "Escape"
			Depth = M_FLEE_D
			Desc = "Aids in attempt to flee combat."
		ElseIf K = M_HEAL Then 
			cost = M_HEAL_C
			Points = 0
			Key = "Heal"
			Depth = M_HEAL_D
			Desc = "Recovers lost hit points."
		ElseIf K = M_TELE Then 
			cost = M_TELE_C
			Points = 0
			Key = "Teleport"
			Depth = M_TELE_D
			Desc = "Transports to another sector."
		ElseIf K = M_STUN Then 
			cost = M_STUN_C
			Points = 0
			Key = "Stun"
			Depth = M_STUN_D
			Desc = "Attempts to stun enemy."
		ElseIf K = M_TOWN Then 
			cost = M_TOWN_C
			Points = 0
			Key = "Town Portal"
			Depth = M_TOWN_D
			Desc = "Teleport to an explored town."
		ElseIf K = M_FAST Then 
			cost = M_FAST_C
			Points = 0
			Key = "Haste"
			Depth = M_FAST_D
			Desc = "Speeds actions in combat."
		ElseIf K = M_SLOW Then 
			cost = M_SLOW_C
			Points = 0
			Key = "Slow"
			Depth = M_SLOW_D
			Desc = "Slows enemy actions in combat."
		ElseIf K = M_BLES Then 
			cost = M_BLES_C
			Points = 0
			Key = "Bless"
			Depth = M_BLES_D
			Desc = "Holy power enhances attack and defense."
		ElseIf K = M_FIRE Then 
			cost = M_FIRE_C
			Points = 0
			Key = "Fireball"
			Depth = M_FIRE_D
			Desc = "Fireball engulfs enemy."
		ElseIf K = M_COLD Then 
			cost = M_COLD_C
			Points = 0
			Key = "Ice Storm"
			Depth = M_COLD_D
			Desc = "Freezes enemy with ice."
		ElseIf K = M_ELEC Then 
			cost = M_ELEC_C
			Points = 0
			Key = "Lightning Bolt"
			Depth = M_ELEC_D
			Desc = "Bolt of electricity shocks enemy."
			
		Else
			cost = 1000000
			Points = 0
			Key = "Doodad Spell"
			Depth = 0
		End If
		'UPGRADE_WARNING: Couldn't resolve default property of object Used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Used = Str(Now.ToOADate())
		Skill = 0
	End Sub
	
	Public Sub InitSpell(ByRef K As Short)
		SDM(M_SPRK_D) = 0
		SDM(M_PROT_D) = 0
		SDM(M_MMIS_D) = 0
		SDM(M_FLEE_D) = Int((1 - 0 + 1) * Rnd() + 0)
		SDM(M_HEAL_D) = Int((1 - 0 + 1) * Rnd() + 0)
		SDM(M_FIRE_D) =
		'UPGRADE_ISSUE: The preceding line couldn't be parsed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="82EBB1AE-1FCB-4FEF-9E6C-8736A316F8A7"'
		SDM(M_COLD_D) = 0
		SDM(M_ELEC_D) = 0
		SDM(M_TELE_D) = 0
		SDM(M_BLES_D) = 0
		SDM(M_STUN_D) = 0
		SDM(M_FAST_D) = 0
		SDM(M_SLOW_D) = 0
		SDM(M_TOWN_D) = 0
		' anti-magic shell
		' drain
		' steal, effect and spell
		' drain hp, effect and spell
		' drain mp, effect and spell
	End Sub
End Class