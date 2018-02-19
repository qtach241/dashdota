SelectTeamDire(hero)
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
	hero.UseItem(2)
	hero.UseItem(2)
}

HeroDirectionalForceTp(hero)
{
	HeroDirectionalForce(hero)
	hero.UseItem(5)
	hero.UseItem(5)
}

HeroTreadSwitchStrength(hero, spell, item, delay)
{
	hero.UseItem(item)
	Sleep, %delay%
	hero.CastSpell(spell)
	Sleep, %delay%
	hero.UseItem(item)
	hero.UseItem(item)
}

HeroTreadSwitchAgility(hero, spell, item, delay)
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