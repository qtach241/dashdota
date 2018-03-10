#Include dota.ahk

gHero := new Hero("Generic")
return

;----------------------------------------- Universal Hotkeys ---------------------------------------

*MButton::	gHero.AttackCancel(0.05)
!PgUp::		gHero.SelectDire()
!PgDn::		gHero.SelectRadiant()
PgUp::		gHero.CycleAllyUp()
PgDn::		gHero.CycleAllyDown()
Capslock::	gHero.OpenShop()
F8:: 		gHero.DirectionalMove(1)
End::		gHero.DirectionalForce()
!End::		gHero.DirectionalForceTp()
F9:: 		gHero.Shrine()
F11::		gHero.DisplayHelp()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------


#Include ahk_meta.ahk