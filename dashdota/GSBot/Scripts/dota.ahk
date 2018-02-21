#NoEnv
#IfWinActive Dota

#Include Libraries/game.ahk

class Team
{
	static Radiant := 0
	static Dire := 1
}

class Hud
{
	; XY coordinates of the 5 allied hero icons at the top of the hud.
	static AllyIcons := {(Team.Radiant): {0: {x: 760, y: 20}, 1: {x: 840, y: 20}, 2: {x: 930, y: 20}, 3: {x: 1010, y: 20}, 4: {x: 1090, y: 20}}
	, (Team.Dire): {0: {x: 1450, y: 20}, 1: {x: 1540, y: 20}, 2: {x: 1620, y: 20}, 3: {x: 1710, y: 20}, 4: {x: 1790, y: 20}}}
	
	; XY coordinates of the 6 inventory slots + 3 backpack slots for three hero types (4/5/6 spells).
	static InventoryIcons := {4: [{x: 1520, y: 1290}, {x: 1605, y: 1290}, {x: 1695, y: 1290}, {x: 1520, y: 1350}, {x: 1605, y: 1350}, {x: 1695, y: 1350}, {x: 1520, y: 1400}, {x: 1605, y: 1400}, {x: 1695, y: 1400}]
	, 5: [{x: 1540, y: 1290}, {x: 1625, y: 1290}, {x: 1715, y: 1290}, {x: 1540, y: 1350}, {x: 1625, y: 1350}, {x: 1715, y: 1350}, {x: 1540, y: 1400}, {x: 1625, y: 1400}, {x: 1715, y: 1400}]
	, 6: [{x: 1580, y: 1290}, {x: 1670, y: 1290}, {x: 1755, y: 1290}, {x: 1580, y: 1350}, {x: 1670, y: 1350}, {x: 1755, y: 1350}, {x: 1580, y: 1400}, {x: 1670, y: 1400}, {x: 1755, y: 1400}]}
}

class Hero
{
	__Init()
	{
		
	}
	
	__New(hero)
	{
		this.Name := hero
		
		i := 0
		while (i < 6)
		{
			IniRead, OutputVar, settings.ini, Keybinds, ABILITY_CAST_%i%
			this.Abilities[i] := OutputVar
			IniRead, OutputVar, settings.ini, Keybinds, ITEM_CAST_%i%
			this.Items[i] := OutputVar
			i++
		}
		
		IniRead, OutputVar, settings.ini, Keybinds, SELECT_HERO
		this.SelectHeroKey := OutputVar
		
		IniRead, OutputVar, settings.ini, Keybinds, SELECT_COURIER
		this.SelectCrowKey := OutputVar
		
		IniRead, OutputVar, settings.ini, Keybinds, DIRECTIONAL_MOVE
		this.DirectionalMoveKey := OutputVar
		
		IniRead, OutputVar, settings.ini, Hotkeys, ATTACK_CANCEL
		this.AttackCancelKey := OutputVar
		
		IniRead, OutputVar, settings.ini, Hotkeys, TOGGLE_SHOP_PANEL
		this.ShopKey := OutputVar
		
		IniRead, OutputVar, settings.ini, Hotkeys, DIRECTIONAL_FORCE
		this.DirectionalForceKey := OutputVar
		
		IniRead, OutputVarDefault, settings.ini, Hero_Default, ABILITY_COUNT
		IniRead, OutputVar, settings.ini, Hero_%hero%, ABILITY_COUNT, %OutputVarDefault%
		this.SpellCount := OutputVar
		
		IniRead, OutputVarDefault, settings.ini, Hero_Default, ATTACK_POINT_MS
		IniRead, OutputVar, settings.ini, Hero_%hero%, ATTACK_POINT_MS, %OutputVarDefault%
		this.BaseAttackPoint := OutputVar
		
		IniRead, OutputVarDefault, settings.ini, Hero_Default, TURN_TIME_MS
		IniRead, OutputVar, settings.ini, Hero_%hero%, TURN_TIME_MS, %OutputVarDefault%
		this.BaseTurnTime := OutputVar
	}
	
	; Display name of the current hero.
	static Name := ""
	
	; Number of spell slots (4/5/6).
	static SpellCount := ""
	
	; Base time in milliseconds between attack animation start point and attack point.
	static BaseAttackPoint := ""
	
	; Base time in milliseconds to turn 180 degrees.
	static BaseTurnTime := ""
	
	; Current hero's team (radiant or dire).
	static Team := Team.Radiant
	
	; Value specifying which of the 5 hero icons to select next.
	static AllyFocus := 0
	
	; Keybind to select hero / center camera on hero.
	static SelectHeroKey := ""
	
	; Keybind to select courier.
	static SelectCrowKey := ""
	
	; Keybind to move directionally without pathing.
	static DirectionalMoveKey := ""
	
	; Hotkey to cancel attack during csing.
	static AttackCancelKey := ""
	
	; Hotkey to toggle the shop panel.
	static ShopKey := ""
	
	; Hotkey to trigger directional forcestaff.
	static DirectionalForceKey := ""
	
	; Array of current hero's ability keybinds.
	static Abilities := []
	
	; Array of current hero's item keybinds.
	static Items := []
	
	SelectRadiant := Func("SelectTeamRadiant")
	SelectDire := Func("SelectTeamDire")
	AllyFocusUp := Func("HeroAllyFocusUp")
	AllyFocusDown := Func("HeroAllyFocusDown")
	CastSpell := Func("HeroCastSpell")
	UseItem := Func("HeroUseItem")
	OpenShop := Func("HeroShopCapslock")
	AttackCancel := Func("HeroAttackCancel")
	DirectionalMove := Func("HeroDirectionalMove")
	DirectionalForce := Func("HeroDirectionalForce")
	DirectionalForceTp := Func("HeroDirectionalForceTp")
	CycleAllyUp := Func("HeroCycleAllyUp")
	CycleAllyDown := Func("HeroCycleAllyDown")
	MoveItem := Func("HeroMoveItem")
	TranquilSwap := Func("HeroTranquilSwap")
}