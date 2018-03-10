#Include dota.ahk

Alchemist := new Hero("Alchemist")
return

;----------------------------------------- Universal Hotkeys ---------------------------------------

*MButton::	Alchemist.AttackCancel(0.05)
!PgUp::		Alchemist.SelectDire()
!PgDn::		Alchemist.SelectRadiant()
PgUp::		Alchemist.CycleAllyUp()
PgDn::		Alchemist.CycleAllyDown()
Capslock::	Alchemist.OpenShop()
F8:: 		Alchemist.DirectionalMove(1)
End::		Alchemist.DirectionalForce()
!End::		Alchemist.DirectionalForceTp()
F9:: 		Alchemist.Shrine()
F11::		Alchemist.DisplayHelp()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------

; Armlet Toggle

t::
Alchemist.UseItem(Item.LowerR)
Alchemist.UseItem(Item.LowerR)
return


#Include ahk_meta.ahk