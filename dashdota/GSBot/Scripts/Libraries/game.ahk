﻿SelectTeamDire(hero)
{
	hero.Team := Team.Dire
	SoundPlay, *64
}

SelectTeamRadiant(hero)
{
	hero.Team := Team.Radiant
	SoundPlay, *48
}

HeroAllyFocusUp(hero)
{
	if (++hero.AllyFocus > 4)
		hero.AllyFocus := 0
}

HeroAllyFocusDown(hero)
{
	if (--hero.AllyFocus < 0)
		hero.AllyFocus := 4
}

HeroCastSpell(hero, index)
{
	SendInput, % hero.Abilities[index]
}

HeroUseItem(hero, index)
{
	SendInput, % hero.Items[index]
}

HeroShopCapslock()
{
	SetCapsLockState, On
	Keywait, CapsLock
	SetCapsLockState, Off
}

HeroAttackCancel(hero, tsec)
{
	Click, Right
	Sleep, (tsec*1000)
	Loop
	{
		KeyWait, % hero.AttackCancelKey, T%tsec%
		if (ErrorLevel = 0)
			break
		SendInput, s
		Click, Right
	}
}

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

HeroDirectionalForce(hero)
{
	hero.DirectionalMove(10)
	hero.UseItem(Item.UpperR)
	hero.UseItem(Item.UpperR)
}

HeroDirectionalForceTp(hero)
{
	HeroDirectionalForce(hero)
	hero.UseItem(Item.LowerR)
	hero.UseItem(Item.LowerR)
}

HeroTreadSwapStrength(hero, spell, item, delay)
{
	hero.UseItem(item)
	Sleep, %delay%
	hero.CastSpell(spell)
	Sleep, %delay%
	hero.UseItem(item)
	hero.UseItem(item)
}

HeroTreadSwapAgility(hero, spell, item, delay)
{
	hero.UseItem(item)
	hero.UseItem(item)
	Sleep, %delay%
	hero.CastSpell(spell)
	Sleep, %delay%
	hero.UseItem(item)
}

HeroAllyFocus(hero)
{
	MouseGetPos, xCurPos, yCurPos
	MouseMove, % Hud.AllyIcons[hero.Team][hero.AllyFocus].x, % Hud.AllyIcons[hero.Team][hero.AllyFocus].y, 0
	Click, 2
	MouseMove, xCurPos, yCurPos, 0
}

HeroCycleAllyUp(hero)
{
	hero.AllyFocusUp()
	HeroAllyFocus(hero)
}

HeroCycleAllyDown(hero)
{
	hero.AllyFocusDown()
	HeroAllyFocus(hero)
}

HeroMoveItem(hero, src, dst)
{
	MouseMove, % Hud.InventoryIcons[hero.SpellCount][src].x, % Hud.InventoryIcons[hero.SpellCount][src].y, 0
	Click, Down
	MouseMove, % Hud.InventoryIcons[hero.SpellCount][dst].x, % Hud.InventoryIcons[hero.SpellCount][dst].y, 2
	Click, Up
}

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