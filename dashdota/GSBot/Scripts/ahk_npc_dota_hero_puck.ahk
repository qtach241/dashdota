#Include dota.ahk

Puck := new Hero("Puck")
return

;----------------------------------------- Universal Hotkeys ---------------------------------------

*MButton::	Puck.AttackCancel(0.05)
Capslock::	Puck.OpenShop()
F8:: 		Puck.DirectionalMove(1)
End::		Puck.DirectionalForce()
!End::		Puck.DirectionalForceTp()
F9:: 		Puck.Shrine()
F11::		Puck.DisplayHelp()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------

; Orb and Jaunt uses same key

q::
Puck.Stop()
Puck.CastSpell(Ability.Sub1)
Puck.CastSpell(Ability.Q)
return


#Include ahk_meta.ahk