#Include dota.ahk

Huskar := new Hero("Huskar")
return

;----------------------------------------- Universal Hotkeys ---------------------------------------

*MButton::	Huskar.AttackCancel(0.05)
!PgUp::		Huskar.SelectDire()
!PgDn::		Huskar.SelectRadiant()
PgUp::		Huskar.CycleAllyUp()
PgDn::		Huskar.CycleAllyDown()
Capslock::	Huskar.OpenShop()
F8:: 		Huskar.DirectionalMove(1)
End::		Huskar.DirectionalForce()
!End::		Huskar.DirectionalForceTp()
o::			Huskar.Shrine()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------

; Armlet Toggle

t::
Huskar.UseItem(Item.LowerM)
Huskar.UseItem(Item.LowerM)
return


#Include ahk_meta.ahk