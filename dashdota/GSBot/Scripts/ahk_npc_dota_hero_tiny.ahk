#Include dota.ahk

Tiny := new Hero("Tiny")
return

;----------------------------------------- Universal Hotkeys ---------------------------------------

*MButton::	Tiny.AttackCancel(0.05)
!PgUp::		Tiny.SelectDire()
!PgDn::		Tiny.SelectRadiant()
PgUp::		Tiny.CycleAllyUp()
PgDn::		Tiny.CycleAllyDown()
Capslock::	Tiny.OpenShop()
F8:: 		Tiny.DirectionalMove(1)
End::		Tiny.DirectionalForce()
!End::		Tiny.DirectionalForceTp()
F9:: 		Tiny.Shrine()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------

; Toss avalanche combo


#Include ahk_meta.ahk