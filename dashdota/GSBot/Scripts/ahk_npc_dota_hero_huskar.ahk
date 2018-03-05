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
F9:: 		Huskar.Shrine()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------

; Armlet Toggle

t::
Huskar.UseItem(Item.LowerR)
Huskar.UseItem(Item.LowerR)
return


#Include ahk_meta.ahk