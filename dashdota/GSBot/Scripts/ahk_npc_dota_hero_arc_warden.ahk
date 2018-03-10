#Include dota.ahk

ArcWarden := new Hero("Arc_Warden")
return

;----------------------------------------- Universal Hotkeys ---------------------------------------

*MButton::	ArcWarden.AttackCancel(0.05)
!PgUp::		ArcWarden.SelectDire()
!PgDn::		ArcWarden.SelectRadiant()
PgUp::		ArcWarden.CycleAllyUp()
PgDn::		ArcWarden.CycleAllyDown()
Capslock::	ArcWarden.OpenShop()
F8:: 		ArcWarden.DirectionalMove(1)
End::		ArcWarden.DirectionalForce()
!End::		ArcWarden.DirectionalForceTp()
F9:: 		ArcWarden.Shrine()
F11::		ArcWarden.DisplayHelp()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------


#Include ahk_meta.ahk