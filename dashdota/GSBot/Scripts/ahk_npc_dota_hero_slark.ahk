#Include dota.ahk

Slark := new Hero("Slark")
return

;----------------------------------------- Universal Hotkeys ---------------------------------------

*MButton::	Slark.AttackCancel(0.05)
!PgUp::		Slark.SelectDire()
!PgDn::		Slark.SelectRadiant()
PgUp::		Slark.CycleAllyUp()
PgDn::		Slark.CycleAllyDown()
Capslock::	Slark.OpenShop()
F8:: 		Slark.DirectionalMove(1)
End::		Slark.DirectionalForce()
!End::		Slark.DirectionalForceTp()
F9:: 		Slark.Shrine()
F11::		Slark.DisplayHelp()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------

; Directional pounce

w::
Slark.DirectionalMove(10)
Slark.CastSpell(Ability.W)
return

; Dark pact + directional pounce

e::
Slark.CastSpell(Ability.Q)
Slark.DirectionalMove(10)
Slark.CastSpell(Ability.W)
return


#Include ahk_meta.ahk