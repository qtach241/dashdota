#Include dota.ahk

Nightstalker := new Hero("Night_Stalker")
return

;----------------------------------------- Universal Hotkeys ---------------------------------------

*MButton::	Nightstalker.AttackCancel(0.05)
!PgUp::		Nightstalker.SelectDire()
!PgDn::		Nightstalker.SelectRadiant()
PgUp::		Nightstalker.CycleAllyUp()
PgDn::		Nightstalker.CycleAllyDown()
Capslock::	Nightstalker.OpenShop()
F8:: 		Nightstalker.DirectionalMove(1)
End::		Nightstalker.DirectionalForce()
!End::		Nightstalker.DirectionalForceTp()
F9:: 		Nightstalker.Shrine()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------

; Armlet Toggle

t::
Nightstalker.UseItem(Item.LowerR)
Nightstalker.UseItem(Item.LowerR)
return


#Include ahk_meta.ahk