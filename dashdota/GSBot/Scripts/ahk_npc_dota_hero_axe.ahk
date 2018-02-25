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
o::			Axe.Shrine()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------

; Pop items and call

q::
Axe.UseItem(Item.UpperM)
Axe.UseItem(Item.UpperR)
Axe.UseItem(Item.LowerL)
Axe.UseItem(Item.LowerL)
Axe.CastSpell(Ability.Q)
return

g::
Axe.TranquilSwap(Item.LowerL, Item.BackpackL)
return


#Include ahk_meta.ahk