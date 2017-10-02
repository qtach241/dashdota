#Include _common.ahk

NumpadDiv::t
NumpadMult::g
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

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; Spell Invoke Helpers
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

InvokeColdSnap()
{
	SendInput qqqr
	return
}

InvokeGhostWalk()
{
	SendInput qqwr
	return
}

InvokeIcewall()
{
	SendInput qqer
	return
}

InvokeTornado()
{
	SendInput wwqr
	return
}

InvokeEmp()
{
	SendInput wwwr
	return
}

InvokeAlacrity()
{
	SendInput wwer
	return
}

InvokeForgeSpirit()
{
	SendInput eeqr
	return
}

InvokeMeteor()
{
	SendInput eewr
	return
}

InvokeSunstrike()
{
	SendInput eeer
	return
}

InvokeDeafeningBlast()
{
	SendInput qwer
	return
}