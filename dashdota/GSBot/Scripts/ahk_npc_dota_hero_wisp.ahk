#Include dota.ahk

Io := new Hero("Wisp")
return

;----------------------------------------- Universal Hotkeys ---------------------------------------

*MButton::	Io.AttackCancel(0.05)
!PgUp::		Io.SelectDire()
!PgDn::		Io.SelectRadiant()
PgUp::		Io.CycleAllyUp()
PgDn::		Io.CycleAllyDown()
Capslock::	Io.OpenShop()
F8:: 		Io.DirectionalMove(1)
End::		Io.DirectionalForce()
!End::		Io.DirectionalForceTp()
F9:: 		Io.Shrine()
F11::		Io.DisplayHelp()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------

; Relocate to base

; Tether + overcharge + pop regen


#Include ahk_meta.ahk