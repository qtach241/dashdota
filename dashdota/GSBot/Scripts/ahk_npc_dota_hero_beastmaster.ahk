#Include dota.ahk

Beastmaster := new Hero("Beastmaster")
return

;----------------------------------------- Universal Hotkeys ---------------------------------------

*MButton::	Beastmaster.AttackCancel(0.05)
!PgUp::		Beastmaster.SelectDire()
!PgDn::		Beastmaster.SelectRadiant()
PgUp::		Beastmaster.CycleAllyUp()
PgDn::		Beastmaster.CycleAllyDown()
Capslock::	Beastmaster.OpenShop()
F8:: 		Beastmaster.DirectionalMove(1)
End::		Beastmaster.DirectionalForce()
!End::		Beastmaster.DirectionalForceTp()
F9:: 		Beastmaster.Shrine()
F11::		Beastmaster.DisplayHelp()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------


#Include ahk_meta.ahk