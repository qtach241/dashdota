#NoEnv
#IfWinActive Dota

#Include Libraries/game.ahk

class Team
{
	static Radiant := 0
	static Dire := 1
}

class Ability
{
	static Q := 0
	static W := 1
	static E := 2
	static Sub1 := 3
	static Sub2 := 4
	static Ultimate := 5
}

class Item
{
	static UpperL := 0
	static UpperM := 1
	static UpperR := 2
	static LowerL := 3
	static LowerM := 4
	static LowerR := 5
	static BackpackL := 6
	static BackpackM := 7
	static BackpackR := 8
}

class ControlGroup
{
	static Group1 := 0
	static Group2 := 1
	static Group3 := 2
	static Group4 := 3
	static Group5 := 4
	static Group6 := 5
}

class Camera
{
	static Position1 := 0
	static Position2 := 1
	static Position3 := 2
	static Position4 := 3
	static Position5 := 4
	static Position6 := 5
}

class Hud
{
	; XY coordinates of the 5 allied hero icons at the top of the hud.
	static AllyIcons := {(Team.Radiant): {0: {x: 760, y: 20}, 1: {x: 840, y: 20}, 2: {x: 930, y: 20}, 3: {x: 1010, y: 20}, 4: {x: 1090, y: 20}}
	, (Team.Dire): {0: {x: 1450, y: 20}, 1: {x: 1540, y: 20}, 2: {x: 1620, y: 20}, 3: {x: 1710, y: 20}, 4: {x: 1790, y: 20}}}
	
	; XY coordinates of the 6 inventory slots + 3 backpack slots for three hero types (4/5/6 spells).
	static InventoryIcons := {4: {0: {x: 1520, y: 1290}, 1: {x: 1605, y: 1290}, 2: {x: 1695, y: 1290}, 3: {x: 1520, y: 1350}, 4: {x: 1605, y: 1350}, 5: {x: 1695, y: 1350}, 6: {x: 1520, y: 1400}, 7: {x: 1605, y: 1400}, 8: {x: 1695, y: 1400}}
	, 5: {0: {x: 1540, y: 1290}, 1: {x: 1625, y: 1290}, 2: {x: 1715, y: 1290}, 3: {x: 1540, y: 1350}, 4: {x: 1625, y: 1350}, 5: {x: 1715, y: 1350}, 6: {x: 1540, y: 1400}, 7: {x: 1625, y: 1400}, 8: {x: 1715, y: 1400}}
	, 6: {0: {x: 1580, y: 1290}, 1: {x: 1670, y: 1290}, 2: {x: 1755, y: 1290}, 3: {x: 1580, y: 1350}, 4: {x: 1670, y: 1350}, 5: {x: 1755, y: 1350}, 6: {x: 1580, y: 1400}, 7: {x: 1670, y: 1400}, 8: {x: 1755, y: 1400}}}
}

class Treads
{
	static Strength := Func("HeroTreadSwapStrength")
	static Agility := Func("HeroTreadSwapAgility")
	static Intelligence := Func("HeroTreadSwapStrength")
}

class Hero
{
	__Init()
	{
		
	}
	
	__New(hero)
	{
		this.Name := hero
		
		; Hero Attributes
		IniRead, OutputVarDefault, settings.ini, Hero_Default, PRIMARY_ATTRIBUTE
		IniRead, OutputVar, settings.ini, Hero_%hero%, PRIMARY_ATTRIBUTE, %OutputVarDefault%
		this.PrimaryAttribute := OutputVar
		
		IniRead, OutputVarDefault, settings.ini, Hero_Default, ABILITY_COUNT
		IniRead, OutputVar, settings.ini, Hero_%hero%, ABILITY_COUNT, %OutputVarDefault%
		this.SpellCount := OutputVar
		
		IniRead, OutputVarDefault, settings.ini, Hero_Default, ATTACK_POINT_MS
		IniRead, OutputVar, settings.ini, Hero_%hero%, ATTACK_POINT_MS, %OutputVarDefault%
		this.BaseAttackPoint := OutputVar
		
		IniRead, OutputVarDefault, settings.ini, Hero_Default, TURN_TIME_MS
		IniRead, OutputVar, settings.ini, Hero_%hero%, TURN_TIME_MS, %OutputVarDefault%
		this.BaseTurnTime := OutputVar
		
		; In-game keybind arrays
		i := 0
		while (i < 6)
		{
			IniRead, OutputVarDefault, settings.ini, Keybinds, ABILITY_CAST_%i%
			IniRead, OutputVar, settings.ini, Keybinds_%hero%, ABILITY_CAST_%i%, %OutputVarDefault%
			this.Abilities[i] := OutputVar
			
			IniRead, OutputVarDefault, settings.ini, Keybinds, ITEM_CAST_%i%
			IniRead, OutputVar, settings.ini, Keybinds_%hero%, ITEM_CAST_%i%, %OutputVarDefault%
			this.Items[i] := OutputVar
			
			IniRead, OutputVarDefault, settings.ini, Keybinds, CONTROL_GROUP_%i%
			IniRead, OutputVar, settings.ini, Keybinds_%hero%, CONTROL_GROUP_%i%, %OutputVarDefault%
			this.ControlGroups[i] := OutputVar
			
			IniRead, OutputVarDefault, settings.ini, Keybinds, CAMERA_POSITION_%i%
			IniRead, OutputVar, settings.ini, Keybinds_%hero%, CAMERA_POSITION_%i%, %OutputVarDefault%
			this.CameraPositions[i] := OutputVar
			
			i++
		}
		
		; In-game keybinds
		IniRead, OutputVar, settings.ini, Keybinds, SELECT_HERO
		this.SelectHeroKey := OutputVar
		
		IniRead, OutputVar, settings.ini, Keybinds, SELECT_ALL_UNITS
		this.SelectAllUnitsKey := OutputVar
		
		IniRead, OutputVar, settings.ini, Keybinds, SELECT_ALL_OTHER_UNITS
		this.SelectAllOtherUnitsKey := OutputVar
		
		IniRead, OutputVar, settings.ini, Keybinds, SELECT_NEXT_UNIT
		this.SelectNextUnitKey := OutputVar
		
		IniRead, OutputVar, settings.ini, Keybinds, MOVE
		this.MoveKey := OutputVar
		
		IniRead, OutputVar, settings.ini, Keybinds, ATTACK_MOVE
		this.AttackMoveKey := OutputVar
		
		IniRead, OutputVar, settings.ini, Keybinds, DIRECTIONAL_MOVE
		this.DirectionalMoveKey := OutputVar
		
		IniRead, OutputVar, settings.ini, Keybinds, PATROL
		this.PatrolKey := OutputVar
		
		IniRead, OutputVar, settings.ini, Keybinds, CANCEL_ACTION
		this.CancelKey := OutputVar
		
		IniRead, OutputVar, settings.ini, Keybinds, HOLD
		this.HoldKey := OutputVar
		
		IniRead, OutputVar, settings.ini, Keybinds, SELECT_COURIER
		this.SelectCrowKey := OutputVar
		
		; External Hotkeys
		IniRead, OutputVar, settings.ini, Hotkeys, ATTACK_CANCEL
		this.AttackCancelKey := OutputVar
		
		IniRead, OutputVar, settings.ini, Hotkeys, TOGGLE_SHOP_PANEL
		this.ShopKey := OutputVar
		
		IniRead, OutputVar, settings.ini, Hotkeys, DIRECTIONAL_FORCE
		this.DirectionalForceKey := OutputVar
		
		IniRead, OutputVar, settings.ini, Hotkeys, SCORE_BOARD
		this.ScoreboardKey := OutputVar
		
		; Hero specific methods
		this.TreadSwap := Treads[this.PrimaryAttribute]
	}
	
	; Display name of the current hero.
	static Name := ""
	
	; Primary attribute of the current hero.
	static PrimaryAttribute := ""
	
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
	
	; Array of current hero's ability keybinds.
	static Abilities := []
	
	; Array of current hero's item keybinds.
	static Items := []
	
	; Array of current hero's control group keybinds.
	static ControlGroups := []
	
	; Array of current hero's camera position keybinds.
	static CameraPositions := []
	
	; Keybind to select hero / center camera on hero.
	static SelectHeroKey := ""
	
	; Keybind to select all controlled units.
	static SelectAllUnitsKey := ""
	
	; Keybind to select all controlled units except hero.
	static SelectAllOtherUnitsKey := ""
	
	; Keybind to select next control group. 
	static SelectNextUnitKey := ""
	
	; Keybind to move.
	static MoveKey := ""
	
	; Keybind to attack move.
	static AttackMoveKey := ""
	
	; Keybind to move directionally without pathing.
	static DirectionalMoveKey := ""
	
	; Keybind to patrol.
	static PatrolKey := ""
	
	; Keybind to cancel current action.
	static CancelKey := ""
	
	; Keybind to hold.
	static HoldKey := ""
	
	; Keybind to select courier.
	static SelectCrowKey := ""
	
	; Hotkey to cancel attack during csing.
	static AttackCancelKey := ""
	
	; Hotkey to toggle the shop panel.
	static ShopKey := ""
	
	; Hotkey to trigger directional forcestaff.
	static DirectionalForceKey := ""
	
	; Hotkey to open scoreboard.
	static ScoreboardKey := ""
	
	; Selection methods
	SelectHero := Func("HeroSelectHero")
	SelectAllUnits := Func("HeroSelectAllUnits")
	SelectAllOtherUnits := Func("HeroSelectAllOtherUnits")
	SelectNextUnit := Func("HeroSelectNextUnit")
	SelectControlGroup := Func("HeroSelectControlGroup")
	SelectRadiant := Func("HeroSelectRadiant")
	SelectDire := Func("HeroSelectDire")
	
	; Basic hero movement
	MoveClick := Func("HeroMove")
	AttackMove := Func("HeroAttackMove")
	ShiftAttackMove := Func("HeroShiftAttackMove")
	Patrol := Func("HeroPatrol")
	Stop := Func("HeroCancel")
	Hold := Func("HeroHold")
	
	; Combat
	CastSpell := Func("HeroCastSpell")
	UseItem := Func("HeroUseItem")
	AttackCancel := Func("HeroAttackCancel")
	SpamClick := Func("HeroSpamClick")
	DirectionalMove := Func("HeroDirectionalMove")
	DirectionalForce := Func("HeroDirectionalForce")
	DirectionalForceTp := Func("HeroDirectionalForceTp")
	
	; Interface and camera
	OpenShop := Func("HeroShopCapslock")
	CycleAllyUp := Func("HeroCycleAllyUp")
	CycleAllyDown := Func("HeroCycleAllyDown")
	MoveItem := Func("HeroMoveItem")
	TranquilSwap := Func("HeroTranquilSwap")
	Shrine := Func("HeroShrine")
	SetCameraPosition := Func("HeroSetCameraPosition")
	GotoCameraPosition := Func("HeroGotoCameraPosition")
}