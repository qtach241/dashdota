#Include dota.ahk

Lifestealer := new Hero("Lifestealer")
return

;----------------------------------------- Universal Hotkeys ---------------------------------------

*MButton::	Lifestealer.AttackCancel(0.05)
!PgUp::		Lifestealer.SelectDire()
!PgDn::		Lifestealer.SelectRadiant()
PgUp::		Lifestealer.CycleAllyUp()
PgDn::		Lifestealer.CycleAllyDown()
Capslock::	Lifestealer.OpenShop()
F8:: 		Lifestealer.DirectionalMove(1)
End::		Lifestealer.DirectionalForce()
!End::		Lifestealer.DirectionalForceTp()
F9:: 		Lifestealer.Shrine()
F11::		Lifestealer.DisplayHelp()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------

; Armlet Toggle

t::
Lifestealer.UseItem(Item.LowerR)
Lifestealer.UseItem(Item.LowerR)
return


#Include ahk_meta.ahk