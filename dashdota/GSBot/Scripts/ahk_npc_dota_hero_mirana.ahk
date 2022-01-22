#Include dota.ahk

Mirana := new Hero("Mirana")
return

;----------------------------------------- Universal Hotkeys ---------------------------------------

*MButton::	Mirana.AttackCancel(0.05)
!PgUp::		Mirana.SelectDire()
!PgDn::		Mirana.SelectRadiant()
PgUp::		Mirana.CycleAllyUp()
PgDn::		Mirana.CycleAllyDown()
Capslock::	Mirana.OpenShop()
F8:: 		Mirana.DirectionalMove(1)
End::		Mirana.DirectionalForce()
!End::		Mirana.DirectionalForceTp()
F9:: 		Mirana.Shrine()
F11::		Mirana.DisplayHelp()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------

; Directional Leap

$e::
Mirana.DirectionalMove(1)
Sleep, 300
Mirana.CastSpell(Ability.E)
return


#Include ahk_meta.ahk