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

NumpadDiv::PgUp
NumpadMult::PgDn
XButton2::4
WheelUp::5

Numpad1::
InvokeColdSnap()
return

Numpad2::
InvokeGhostWalk()
return

Numpad3::
InvokeIcewall()
return

Numpad4::
InvokeTornado()
return

Numpad5::
InvokeEmp()
return

Numpad6::
InvokeAlacrity()
return

Numpad7::
InvokeForgeSpirit()
return

Numpad8::
InvokeMeteor()
return

Numpad9::
InvokeSunstrike()
return

Numpad0::
InvokeDeafeningBlast()
return

6::
TryCombo()
return

; Helpers

InvokeColdSnap()
{
	SendInput qqqr
	Invoker.CastSpell(Ability.Q)
	Invoker.CastSpell(Ability.Q)
	Invoker.CastSpell(Ability.Q)
	Invoker.CastSpell(Ability.Ultimate)
}

InvokeGhostWalk()
{
	SendInput qqwr
	Invoker.CastSpell(Ability.Q)
	Invoker.CastSpell(Ability.Q)
	Invoker.CastSpell(Ability.W)
	Invoker.CastSpell(Ability.Ultimate)
}

InvokeIcewall()
{
	SendInput qqer
	Invoker.CastSpell(Ability.Q)
	Invoker.CastSpell(Ability.Q)
	Invoker.CastSpell(Ability.E)
	Invoker.CastSpell(Ability.Ultimate)
}

InvokeTornado()
{
	SendInput wwqr
	Invoker.CastSpell(Ability.W)
	Invoker.CastSpell(Ability.W)
	Invoker.CastSpell(Ability.Q)
	Invoker.CastSpell(Ability.Ultimate)
}

InvokeEmp()
{
	SendInput wwwr
	Invoker.CastSpell(Ability.W)
	Invoker.CastSpell(Ability.W)
	Invoker.CastSpell(Ability.W)
	Invoker.CastSpell(Ability.Ultimate)
}

InvokeAlacrity()
{
	SendInput wwer
	Invoker.CastSpell(Ability.W)
	Invoker.CastSpell(Ability.W)
	Invoker.CastSpell(Ability.E)
	Invoker.CastSpell(Ability.Ultimate)
}

InvokeForgeSpirit()
{
	SendInput eeqr
	Invoker.CastSpell(Ability.E)
	Invoker.CastSpell(Ability.E)
	Invoker.CastSpell(Ability.Q)
	Invoker.CastSpell(Ability.Ultimate)
}

InvokeMeteor()
{
	SendInput eewr
	Invoker.CastSpell(Ability.E)
	Invoker.CastSpell(Ability.E)
	Invoker.CastSpell(Ability.W)
	Invoker.CastSpell(Ability.Ultimate)
}

InvokeSunstrike()
{
	SendInput eeer
	Invoker.CastSpell(Ability.E)
	Invoker.CastSpell(Ability.E)
	Invoker.CastSpell(Ability.E)
	Invoker.CastSpell(Ability.Ultimate)
}

InvokeDeafeningBlast()
{
	SendInput qwer
	Invoker.CastSpell(Ability.Q)
	Invoker.CastSpell(Ability.W)
	Invoker.CastSpell(Ability.E)
	Invoker.CastSpell(Ability.Ultimate)
}

TryCombo()
{
	SendInput t
	Click
	Sleep, 500
	SendInput g
	Click
	Sleep, 500
	InvokeSunstrike()
	Sleep, 500
	SendInput t
	Click
	Sleep, 500
	SendInput d
	Sleep, 500
	SendInput t
	Click
	Sleep, 500
	SendInput g
	Click
	Sleep, 500
	InvokeDeafeningBlast()
	Sleep, 500
	SendInput t
	Click
	return
}

TryCombo2()
{
	SendInput t
	Click
	SendInput g
	Click
	Sleep, 500
	InvokeMeteor()
	Sleep, 500
	SendInput t
	Click
	Sleep, 1000
	SendInput d
	Sleep, 500
	SendInput t
	Click
	SendInput g
	Click
	Sleep, 1000
	InvokeDeafeningBlast()
	Sleep, 1000
	SendInput t
	Click
	return
}


#Include ahk_meta.ahk