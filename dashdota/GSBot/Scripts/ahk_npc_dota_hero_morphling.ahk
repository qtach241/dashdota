#Include dota.ahk

Morphling := new Hero("Morphling")
return

;----------------------------------------- Universal Hotkeys ---------------------------------------

*MButton::	Morphling.AttackCancel(0.05)
!PgUp::		Morphling.SelectDire()
!PgDn::		Morphling.SelectRadiant()
PgUp::		Morphling.CycleAllyUp()
PgDn::		Morphling.CycleAllyDown()
Capslock::	Morphling.OpenShop()
F8:: 		Morphling.DirectionalMove(1)
End::		Morphling.DirectionalForce()
!End::		Morphling.DirectionalForceTp()
F9:: 		Morphling.Shrine()
F11::		Morphling.DisplayHelp()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------

; Pop spells and de-morph

; E-blade combo


#Include ahk_meta.ahk