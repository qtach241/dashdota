#Include dota.ahk

Warlock := new Hero("Warlock")
return

;----------------------------------------- Universal Hotkeys ---------------------------------------

*MButton::	Warlock.AttackCancel(0.05)
!PgUp::		Warlock.SelectDire()
!PgDn::		Warlock.SelectRadiant()
PgUp::		Warlock.CycleAllyUp()
PgDn::		Warlock.CycleAllyDown()
Capslock::	Warlock.OpenShop()
F8:: 		Warlock.DirectionalMove(1)
End::		Warlock.DirectionalForce()
!End::		Warlock.DirectionalForceTp()
F9:: 		Warlock.Shrine()
F11::		Warlock.DisplayHelp()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------

; Fatal bonds + Ultimate + Upheaval + Glimmer

r::
Warlock.CastSpell(Ability.Q)
Click
Warlock.CastSpell(Ability.Ultimate)
Click
Warlock.CastSpell(Ability.E)
Click
Sleep, 1000
Warlock.UseItem(Item.LowerL)
Warlock.UseItem(Item.LowerL)
return


#Include ahk_meta.ahk