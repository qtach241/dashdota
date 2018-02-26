#Include dota.ahk

Legion := new Hero("Legion_Commander")
return

;----------------------------------------- Universal Hotkeys ---------------------------------------

*MButton::	Legion.AttackCancel(0.05)
!PgUp::		Legion.SelectDire()
!PgDn::		Legion.SelectRadiant()
PgUp::		Legion.CycleAllyUp()
PgDn::		Legion.CycleAllyDown()
Capslock::	Legion.OpenShop()
F8:: 		Legion.DirectionalMove(1)
End::		Legion.DirectionalForce()
!End::		Legion.DirectionalForceTp()
o::			Legion.Shrine()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------

; Armlet Toggle

t::
Legion.UseItem(Item.LowerR)
Legion.UseItem(Item.LowerR)
return

;; Self-cast W

e::
Legion.CastSpell(Ability.W)
Legion.CastSpell(Ability.W)
return

; Pop items and duel

r::
Legion.UseItem(Item.UpperM)
Legion.UseItem(Item.UpperR)
Legion.UseItem(Item.LowerL)
Legion.UseItem(Item.LowerL)
Legion.UseItem(Item.LowerR)
Legion.CastSpell(Ability.Ultimate)
return


#Include ahk_meta.ahk