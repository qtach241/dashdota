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

;--------------------------------------- Hero Specific Hotkeys -------------------------------------

t::
Alchemist.UseItem(4)
Alchemist.UseItem(4)
return


#Include ahk_meta.ahk