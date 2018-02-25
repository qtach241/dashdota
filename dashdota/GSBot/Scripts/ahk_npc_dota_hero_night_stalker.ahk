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
o::			Nightstalker.Shrine()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------

; Armlet Toggle

t::
Nightstalker.UseItem(Item.LowerM)
Nightstalker.UseItem(Item.LowerM)
return


#Include ahk_meta.ahk