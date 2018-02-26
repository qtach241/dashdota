#Include dota.ahk

Invoker := new Hero("Invoker")
return

;----------------------------------------- Universal Hotkeys ---------------------------------------

*MButton::	Invoker.AttackCancel(0.05)
;!PgUp::		Invoker.SelectDire()
;!PgDn::		Invoker.SelectRadiant()
;PgUp::		Invoker.CycleAllyUp()
;PgDn::		Invoker.CycleAllyDown()
Capslock::	Invoker.OpenShop()
F8:: 		Invoker.DirectionalMove(1)
End::		Invoker.DirectionalForce()
!End::		Invoker.DirectionalForceTp()
o::			Invoker.Shrine()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------

;NumpadDiv::PgUp
;NumpadMult::PgDn
;XButton2::4
;WheelUp::5

Numpad1::InvokeColdSnap(Invoker)
Numpad2::InvokeGhostWalk(Invoker)
Numpad3::InvokeIcewall(Invoker)
Numpad4::InvokeTornado(Invoker)
Numpad5::InvokeEmp(Invoker)
Numpad6::InvokeAlacrity(Invoker)
Numpad7::InvokeForgeSpirit(Invoker)
Numpad8::InvokeMeteor(Invoker)
Numpad9::InvokeSunstrike(Invoker)
Numpad0::InvokeDeafeningBlast(Invoker)

6::
TryCombo(Invoker)
return

; Helpers

InvokeColdSnap(hero)
{
	hero.CastSpell(Ability.Q)
	hero.CastSpell(Ability.Q)
	hero.CastSpell(Ability.Q)
	hero.CastSpell(Ability.Ultimate)
}

InvokeGhostWalk(hero)
{
	hero.CastSpell(Ability.Q)
	hero.CastSpell(Ability.Q)
	hero.CastSpell(Ability.W)
	hero.CastSpell(Ability.Ultimate)
}

InvokeIcewall(hero)
{
	hero.CastSpell(Ability.Q)
	hero.CastSpell(Ability.Q)
	hero.CastSpell(Ability.E)
	hero.CastSpell(Ability.Ultimate)
}

InvokeTornado(hero)
{
	hero.CastSpell(Ability.W)
	hero.CastSpell(Ability.W)
	hero.CastSpell(Ability.Q)
	hero.CastSpell(Ability.Ultimate)
}

InvokeEmp(hero)
{
	hero.CastSpell(Ability.W)
	hero.CastSpell(Ability.W)
	hero.CastSpell(Ability.W)
	hero.CastSpell(Ability.Ultimate)
}

InvokeAlacrity(hero)
{
	hero.CastSpell(Ability.W)
	hero.CastSpell(Ability.W)
	hero.CastSpell(Ability.E)
	hero.CastSpell(Ability.Ultimate)
}

InvokeForgeSpirit(hero)
{
	hero.CastSpell(Ability.E)
	hero.CastSpell(Ability.E)
	hero.CastSpell(Ability.Q)
	hero.CastSpell(Ability.Ultimate)
}

InvokeMeteor(hero)
{
	hero.CastSpell(Ability.E)
	hero.CastSpell(Ability.E)
	hero.CastSpell(Ability.W)
	hero.CastSpell(Ability.Ultimate)
}

InvokeSunstrike(hero)
{
	hero.CastSpell(Ability.E)
	hero.CastSpell(Ability.E)
	hero.CastSpell(Ability.E)
	hero.CastSpell(Ability.Ultimate)
}

InvokeDeafeningBlast(hero)
{
	hero.CastSpell(Ability.Q)
	hero.CastSpell(Ability.W)
	hero.CastSpell(Ability.E)
	hero.CastSpell(Ability.Ultimate)
}

TryCombo(hero)
{
	hero.CastSpell(Ability.Sub1)
	Click
	Sleep, 500
	hero.CastSpell(Ability.Sub2)
	Click
	Sleep, 500
	InvokeSunstrike(hero)
	Sleep, 500
	hero.CastSpell(Ability.Sub1)
	Click
	Sleep, 500
	hero.UseItem(Item.LowerR)
	Sleep, 500
	hero.CastSpell(Ability.Sub1)
	Click
	Sleep, 500
	hero.CastSpell(Ability.Sub2)
	Click
	Sleep, 500
	InvokeDeafeningBlast(hero)
	Sleep, 500
	hero.CastSpell(Ability.Sub1)
	Click
}

TryCombo2(hero)
{
	hero.CastSpell(Ability.Sub1)
	Click
	hero.CastSpell(Ability.Sub2)
	Click
	Sleep, 500
	InvokeMeteor(hero)
	Sleep, 500
	hero.CastSpell(Ability.Sub1)
	Click
	Sleep, 1000
	hero.UseItem(Item.LowerR)
	Sleep, 500
	hero.CastSpell(Ability.Sub1)
	Click
	hero.CastSpell(Ability.Sub2)
	Click
	Sleep, 1000
	InvokeDeafeningBlast(hero)
	Sleep, 1000
	hero.CastSpell(Ability.Sub1)
	Click
	return
}


#Include ahk_meta.ahk