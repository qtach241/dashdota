#Include dota.ahk

Treant := new Hero("Treant")
return

;----------------------------------------- Universal Hotkeys ---------------------------------------

*MButton::	Treant.AttackCancel(0.05)
!PgUp::		Treant.SelectDire()
!PgDn::		Treant.SelectRadiant()
PgUp::		Treant.CycleAllyUp()
PgDn::		Treant.CycleAllyDown()
Capslock::	Treant.OpenShop()
F8:: 		Treant.DirectionalMove(1)
End::		Treant.DirectionalForce()
!End::		Treant.DirectionalForceTp()
F9:: 		Treant.Shrine()
F11::		Treant.DisplayHelp()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------


#Include ahk_meta.ahk