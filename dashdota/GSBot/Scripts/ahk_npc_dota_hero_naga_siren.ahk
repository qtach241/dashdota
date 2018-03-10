#Include dota.ahk

Naga := new Hero("Naga_Siren")
return

;----------------------------------------- Universal Hotkeys ---------------------------------------

*MButton::	Naga.AttackCancel(0.05)
!PgUp::		Naga.SelectDire()
!PgDn::		Naga.SelectRadiant()
PgUp::		Naga.CycleAllyUp()
PgDn::		Naga.CycleAllyDown()
Capslock::	Naga.OpenShop()
F8:: 		Naga.DirectionalMove(1)
End::		Naga.DirectionalForce()
!End::		Naga.DirectionalForceTp()
F9:: 		Naga.Shrine()
F11::		Naga.DisplayHelp()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------


#Include ahk_meta.ahk