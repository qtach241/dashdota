#Include dota.ahk

Pugna := new Hero("Pugna")
return

;----------------------------------------- Universal Hotkeys ---------------------------------------

*MButton::	Pugna.AttackCancel(0.05)
!PgUp::		Pugna.SelectDire()
!PgDn::		Pugna.SelectRadiant()
PgUp::		Pugna.CycleAllyUp()
PgDn::		Pugna.CycleAllyDown()
Capslock::	Pugna.OpenShop()
F8:: 		Pugna.DirectionalMove(1)
End::		Pugna.DirectionalForce()
!End::		Pugna.DirectionalForceTp()
F9:: 		Pugna.Shrine()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------

; Decrepify dagon

; Bkb lifedrain


#Include ahk_meta.ahk