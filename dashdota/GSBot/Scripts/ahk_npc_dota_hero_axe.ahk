#Include dota.ahk

Axe := new Hero("Axe")
return

;----------------------------------------- Universal Hotkeys ---------------------------------------

*MButton::	Axe.AttackCancel(0.05)
!PgUp::		Axe.SelectDire()
!PgDn::		Axe.SelectRadiant()
PgUp::		Axe.CycleAllyUp()
PgDn::		Axe.CycleAllyDown()
Capslock::	Axe.OpenShop()
F8:: 		Axe.DirectionalMove(1)
End::		Axe.DirectionalForce()
!End::		Axe.DirectionalForceTp()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------

q::
Axe.UseItem(1)
Axe.UseItem(2)
Axe.UseItem(4)
Axe.UseItem(4)
Axe.CastSpell(0)
return


#Include ahk_meta.ahk