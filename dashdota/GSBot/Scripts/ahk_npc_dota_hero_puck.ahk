#Include dota.ahk

Puck := new Hero("Puck")
return

;----------------------------------------- Universal Hotkeys ---------------------------------------

*MButton::	Puck.AttackCancel(0.05)
;!PgUp::		Puck.SelectDire()
;!PgDn::		Puck.SelectRadiant()
;PgUp::		Puck.CycleAllyUp()
;PgDn::		Puck.CycleAllyDown()
Capslock::	Puck.OpenShop()
F8:: 		Puck.DirectionalMove(1)
End::		Puck.DirectionalForce()
!End::		Puck.DirectionalForceTp()
F9:: 		Puck.Shrine()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------

; Orb and Jaunt uses same key

q::
Puck.Stop()
Puck.CastSpell(Ability.Sub1)
Puck.CastSpell(Ability.Q)
return


#Include ahk_meta.ahk