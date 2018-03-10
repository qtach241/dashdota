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
F9:: 		Axe.Shrine()
F11::		Axe.DisplayHelp()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------

; Pop items and call

q::
Axe.UseItem(Item.UpperM)
Axe.UseItem(Item.UpperR)
Axe.UseItem(Item.LowerL)
Axe.UseItem(Item.LowerL)
Axe.CastSpell(Ability.Q)
return

t::
Axe.TranquilSwap(Item.LowerR, Item.BackpackR)
return


#Include ahk_meta.ahk