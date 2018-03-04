;---------------------------------------------------------------------------------------------------
; Name: HeroSelectHero
; Parameters:
;	hero - global hero object.
; Description: Sends the key to select the current hero.
;---------------------------------------------------------------------------------------------------
HeroSelectHero(hero)
{
	SendInput, % hero.SelectHeroKey
}

;---------------------------------------------------------------------------------------------------
; Name: HeroSelectAllUnits
; Parameters:
;	hero - global hero object.
; Description: Sends the key to select all units under the hero's control.
;---------------------------------------------------------------------------------------------------
HeroSelectAllUnits(hero)
{
	SendInput, % hero.SelectAllUnitsKey
}

;---------------------------------------------------------------------------------------------------
; Name: HeroSelectAllOtherUnits
; Parameters:
;	hero - global hero object.
; Description: Sends the key to select all other units except the current hero.
;---------------------------------------------------------------------------------------------------
HeroSelectAllOtherUnits(hero)
{
	SendInput, % hero.SelectAllOtherUnitsKey
}

;---------------------------------------------------------------------------------------------------
; Name: HeroSelectNextUnit
; Parameters:
;	hero - global hero object.
; Description: Sends the key to select the next unit under hero control.
;---------------------------------------------------------------------------------------------------
HeroSelectNextUnit(hero)
{
	SendInput, % hero.SelectNextUnitKey
}

;---------------------------------------------------------------------------------------------------
; Name: HeroSelectControlGroup
; Parameters:
;	hero - global hero object.
;	index - index of the control group array
; Description: Send the key to select a specific control group from the control group array.
;---------------------------------------------------------------------------------------------------
HeroSelectControlGroup(hero, index)
{
	SendInput, % hero.ControlGroups[index]
}

;---------------------------------------------------------------------------------------------------
; Name: HeroSelectRadiant
; Parameters:
;	hero - global hero object.
; Description: Set Team field in global hero object to radiant.
;---------------------------------------------------------------------------------------------------
HeroSelectRadiant(hero)
{
	hero.Team := Team.Radiant
	SoundPlay, *48
}

;---------------------------------------------------------------------------------------------------
; Name: HeroSelectDire
; Parameters:
;	hero - global hero object.
; Description: Set Team field in global hero object to dire.
;---------------------------------------------------------------------------------------------------
HeroSelectDire(hero)
{
	hero.Team := Team.Dire
	SoundPlay, *64
}

;---------------------------------------------------------------------------------------------------
; Name: HeroMove
; Parameters:
;	hero - global hero object.
; Description: Issue a move command at the current mouse location.
;---------------------------------------------------------------------------------------------------
HeroMove(hero)
{
	SendInput, % hero.MoveKey
	Click
}

;---------------------------------------------------------------------------------------------------
; Name: HeroAttackMove
; Parameters:
;	hero - global hero object.
; Description: Issue an attack move command at the current mouse location.
;---------------------------------------------------------------------------------------------------
HeroAttackMove(hero)
{
	SendInput, % hero.AttackMoveKey
	Click
}

;---------------------------------------------------------------------------------------------------
; Name: HeroShiftAttackMove
; Parameters:
;	hero - global hero object.
; Description: Queue an attack move command at the current mouse location.
;---------------------------------------------------------------------------------------------------
HeroShiftAttackMove(hero)
{
	SendInput, {Shift Down}
	hero.AttackMove()
	SendInput, {Shift Up}
}

;---------------------------------------------------------------------------------------------------
; Name: HeroPatrol
; Parameters:
;	hero - global hero object.
; Description: Issue a patrol command at the current mouse location.
;---------------------------------------------------------------------------------------------------
HeroPatrol(hero)
{
	SendInput, % hero.PatrolKey
	Click
}

;---------------------------------------------------------------------------------------------------
; Name: HeroCancel
; Parameters:
;	hero - global hero object.
; Description: Sends the key cancel current action (stop).
;---------------------------------------------------------------------------------------------------
HeroCancel(hero)
{
	SendInput, % hero.CancelKey
}

;---------------------------------------------------------------------------------------------------
; Name: HeroHold
; Parameters:
;	hero - global hero object.
; Description: Sends the key to hold position.
;---------------------------------------------------------------------------------------------------
HeroHold(hero)
{
	SendInput, % hero.HoldKey
}

;---------------------------------------------------------------------------------------------------
; Name: HeroCastSpell
; Parameters:
;	hero - global hero object.
;	index - index of the abilities array.
; Description: Sends the key to cast a spell.
;---------------------------------------------------------------------------------------------------
HeroCastSpell(hero, index)
{
	SendInput, % hero.Abilities[index]
}

;---------------------------------------------------------------------------------------------------
; Name: HeroUseItem
; Parameters:
;	hero - global hero object.
;	index - index of the items array.
; Description: Sends the key to use an item.
;---------------------------------------------------------------------------------------------------
HeroUseItem(hero, index)
{
	SendInput, % hero.Items[index]
}

;---------------------------------------------------------------------------------------------------
; Name: HeroAttackCancel
; Parameters:
;	hero - global hero object.
;	tsec - Time in seconds to wait before cancelling a previously ordered attack.
; Description: Will issue an attack command and then indefinitely cancel all attacks until the
;	attack cancel key is released.
;---------------------------------------------------------------------------------------------------
HeroAttackCancel(hero, tsec)
{
	Click, Right
	Sleep, (tsec*1000)
	Loop
	{
		KeyWait, % hero.AttackCancelKey, T%tsec%
		if (ErrorLevel = 0)
			break
		hero.Stop()
		Click, Right
	}
}

;---------------------------------------------------------------------------------------------------
; Name: HeroSpamClick
; Parameters:
;	hero - global hero object.
;	spell - index of ability array.
;	hold - initial wait time in seconds before spam click begins.
;	interval - time in seconds between spam clicks.
; Description: Repeatedly attempt to cast a spell at the current mouse position. Only intended
;	to be used with Q/W/E ability.
;---------------------------------------------------------------------------------------------------
HeroSpamClick(hero, spell, hold, interval)
{
	if (spell > 2)
		return
	
	Sleep, (hold*1000)
	Loop
	{
		KeyWait, % hero.Abilities[spell], T%interval%
		if (ErrorLevel = 0)
			break
		hero.CastSpell(spell)
		Click
	}
}

;---------------------------------------------------------------------------------------------------
; Name: HeroDirectionalMove
; Parameters:
;	hero - global hero object.
;	count - number of times to right click before releasing directional move key.
; Description: Send a specific number of directional move commands at the current mouse location.
;---------------------------------------------------------------------------------------------------
HeroDirectionalMove(hero, count)
{
	key := % hero.DirectionalMoveKey
	SendInput, {%key% Down}
	Loop, %count%
	{
		Click, Right
	}
	SendInput, {%key% Up}
}

;---------------------------------------------------------------------------------------------------
; Name: HeroDirectionalForce
; Parameters:
;	hero - global hero object.
; Description: Face in the direction of the current mouse position and self cast force staff.
;---------------------------------------------------------------------------------------------------
HeroDirectionalForce(hero)
{
	hero.DirectionalMove(10)
	hero.UseItem(Item.UpperR)
	hero.UseItem(Item.UpperR)
}

;---------------------------------------------------------------------------------------------------
; Name: HeroDirectionalForceTp
; Parameters:
;	hero - global hero object.
; Description: Follow up directional force with tp to base.
;---------------------------------------------------------------------------------------------------
HeroDirectionalForceTp(hero)
{
	HeroDirectionalForce(hero)
	hero.UseItem(Item.LowerR)
	hero.UseItem(Item.LowerR)
}

;---------------------------------------------------------------------------------------------------
; Name: HeroShopsCapslock
; Parameters: none
; Description: Opens the shop as long as capslock is held down. Immediately closes the shop when
;	when capslock is released.
;---------------------------------------------------------------------------------------------------
HeroShopCapslock()
{
	SetCapsLockState, On
	Keywait, CapsLock
	SetCapsLockState, Off
}

;---------------------------------------------------------------------------------------------------
; Name: HeroAllyFocusUp
; Parameters:
;	hero - global hero object.
; Description: Helper function to increment the ally focus target field in global hero object.
;	Reset to 0 if greater than 4.
;---------------------------------------------------------------------------------------------------
HeroAllyFocusUp(hero)
{
	if (++hero.AllyFocus > 4)
		hero.AllyFocus := 0
}

;---------------------------------------------------------------------------------------------------
; Name: HeroAllyFocusDown
; Parameters:
;	hero - global hero object.
; Description: Helper function to decrement the ally focus target field in global hero object.
;	Reset to 4 if less than 0.
;---------------------------------------------------------------------------------------------------
HeroAllyFocusDown(hero)
{
	if (--hero.AllyFocus < 0)
		hero.AllyFocus := 4
}

;---------------------------------------------------------------------------------------------------
; Name: HeroAllyFocus
; Parameters:
;	hero - global hero object.
; Description: Helper function to double click on a hero's top-bar portrait.
;---------------------------------------------------------------------------------------------------
HeroAllyFocus(hero)
{
	MouseGetPos, xCurPos, yCurPos
	MouseMove, % Hud.AllyIcons[hero.Team][hero.AllyFocus].x, % Hud.AllyIcons[hero.Team][hero.AllyFocus].y, 0
	Click, 2
	MouseMove, xCurPos, yCurPos, 0
}

;---------------------------------------------------------------------------------------------------
; Name: HeroCycleAllyUp
; Parameters:
;	hero - global hero object.
; Description: Double click on the next allied hero portrait.
;---------------------------------------------------------------------------------------------------
HeroCycleAllyUp(hero)
{
	hero.AllyFocusUp()
	HeroAllyFocus(hero)
}

;---------------------------------------------------------------------------------------------------
; Name: HeroCycleAllyDown
; Parameters:
;	hero - global hero object.
; Description: Double click on the previous allied hero portrait.
;---------------------------------------------------------------------------------------------------
HeroCycleAllyDown(hero)
{
	hero.AllyFocusDown()
	HeroAllyFocus(hero)
}

;---------------------------------------------------------------------------------------------------
; Name: HeroTreadSwapStrength
; Parameters:
;	hero - global hero object.
;	spell - index in the abilities array.
;	item - index in the items array.
;	delay - time in ms to delay before and after spell cast.
; Description: Activates treads to switch to int, casts a spell, then activates treads to switch
;	back to strength.
;---------------------------------------------------------------------------------------------------
HeroTreadSwapStrength(hero, spell, item, delay)
{
	hero.UseItem(item)
	Sleep, %delay%
	hero.CastSpell(spell)
	Sleep, %delay%
	hero.UseItem(item)
	hero.UseItem(item)
}

;---------------------------------------------------------------------------------------------------
; Name: HeroTreadSwapAgility
; Parameters:
;	hero - global hero object.
;	spell - index in the abilities array.
;	item - index in the items array.
;	delay - time in ms to delay before and after spell cast.
; Description: Activates treads to switch to int, casts a spell, then activates treads to switch
;	back to agility.
;---------------------------------------------------------------------------------------------------
HeroTreadSwapAgility(hero, spell, item, delay)
{
	hero.UseItem(item)
	hero.UseItem(item)
	Sleep, %delay%
	hero.CastSpell(spell)
	Sleep, %delay%
	hero.UseItem(item)
}

;---------------------------------------------------------------------------------------------------
; Name: HeroMoveItem
; Parameters:
;	hero - global hero object.
;	src - index specifying the slot in inventory to move item from.
;	dst - index specifying the slot in inventory to move item to.
; Description: Helper function to move an item from one inventory slot to another.
;---------------------------------------------------------------------------------------------------
HeroMoveItem(hero, src, dst)
{
	MouseMove, % Hud.InventoryIcons[hero.SpellCount][src].x, % Hud.InventoryIcons[hero.SpellCount][src].y, 0
	Click, Down
	MouseMove, % Hud.InventoryIcons[hero.SpellCount][dst].x, % Hud.InventoryIcons[hero.SpellCount][dst].y, 2
	Click, Up
}

;---------------------------------------------------------------------------------------------------
; Name: HeroTranquilSwap
; Parameters:
;	hero - global hero object.
;	src - index specifying the slot in inventory of tranquil boots.
;	dst - index specifying the slot in backpack to move tranquil boots to.
; Description: Moves tranquils from inventory to backpack and then back to inventory. Mouse move
;	is disabled during the process.
;---------------------------------------------------------------------------------------------------
HeroTranquilSwap(hero, src, dst)
{
	BlockInput, MouseMove
	MouseGetPos, xCurPos, yCurPos
	MouseMove, % Hud.InventoryIcons[hero.SpellCount][src].x, % Hud.InventoryIcons[hero.SpellCount][src].y, 0
	Click, Down
	MouseMove, % Hud.InventoryIcons[hero.SpellCount][dst].x, % Hud.InventoryIcons[hero.SpellCount][dst].y, 2
	Click, Up
	Sleep, 200
	Click, Down
	MouseMove, % Hud.InventoryIcons[hero.SpellCount][src].x, % Hud.InventoryIcons[hero.SpellCount][src].y, 2
	Click, Up
	MouseMove, xCurPos, yCurPos
	BlockInput, MouseMoveOff
}

;---------------------------------------------------------------------------------------------------
; Name: HeroShrine
; Parameters:
;	hero - global hero object.
; Description: Cycles all 6 inventory items into backpack and back to put them on the backpack
;	cooldown which temporarily disables their stats. Useful when shrining.
;---------------------------------------------------------------------------------------------------
HeroShrine(hero)
{
	BlockInput, MouseMove
	MouseGetPos, xCurPos, yCurPos
	hero.MoveItem(Item.UpperL, Item.BackpackL)
	hero.MoveItem(Item.UpperM, Item.BackpackM)
	hero.MoveItem(Item.UpperR, Item.BackpackR)
	hero.MoveItem(Item.LowerL, Item.BackpackL)
	hero.MoveItem(Item.LowerM, Item.BackpackM)
	hero.MoveItem(Item.LowerR, Item.BackpackR)
	hero.MoveItem(Item.UpperL, Item.BackpackL)
	hero.MoveItem(Item.UpperM, Item.BackpackM)
	hero.MoveItem(Item.UpperR, Item.BackpackR)
	hero.MoveItem(Item.LowerL, Item.UpperL)
	hero.MoveItem(Item.LowerM, Item.UpperM)
	hero.MoveItem(Item.LowerR, Item.UpperR)
	MouseMove, xCurPos, yCurPos
	BlockInput, MouseMoveOff
}

;---------------------------------------------------------------------------------------------------
; Name: HeroSetCameraPosition
; Parameters:
;	hero - global hero object.
;	index - index of the camera position array
; Description: Save the current camera position coordinates into the slot in the camera positions
; 	specified by index.
;---------------------------------------------------------------------------------------------------
HeroSetCameraPosition(hero, index)
{
	SendInput {Control Down}
	SendInput, % hero.CameraPositions[index]
	SendInput {Control Up}
}

;---------------------------------------------------------------------------------------------------
; Name: HeroGotoCameraPosition
; Parameters:
;	hero - global hero object.
;	index - index of the camera position array
; Description: Move the camera to the location in the camera positions array specified by index.
;---------------------------------------------------------------------------------------------------
HeroGotoCameraPosition(hero, index)
{
	SendInput, % hero.CameraPositions[index]
}