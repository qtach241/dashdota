#Include dota.ahk

Slardar := new Hero("Slardar")
return

;----------------------------------------- Universal Hotkeys ---------------------------------------

*MButton::	Slardar.AttackCancel(0.05)
!PgUp::		Slardar.SelectDire()
!PgDn::		Slardar.SelectRadiant()
PgUp::		Slardar.CycleAllyUp()
PgDn::		Slardar.CycleAllyDown()
Capslock::	Slardar.OpenShop()
F8:: 		Slardar.DirectionalMove(1)
End::		Slardar.DirectionalForce()
!End::		Slardar.DirectionalForceTp()
o::			Slardar.Shrine()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------

; Long jump (force blink crush)

e::
Slardar.DirectionalMove(1)
Sleep, (Slardar.BaseTurnTime + 100)
Slardar.UseItem(Item.UpperR)
Slardar.UseItem(Item.UpperR)
Sleep, 500
Slardar.UseItem(Item.UpperL)
Click
Slardar.CastSpell(Ability.W)
return

; Armlet Toggle

t::
Slardar.UseItem(Item.LowerM)
Slardar.UseItem(Item.LowerM)
return


#Include ahk_meta.ahk