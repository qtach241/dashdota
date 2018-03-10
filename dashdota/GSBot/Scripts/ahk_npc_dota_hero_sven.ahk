#Include dota.ahk

Sven := new Hero("Sven")
return

;----------------------------------------- Universal Hotkeys ---------------------------------------

*MButton::	Sven.AttackCancel(0.05)
!PgUp::		Sven.SelectDire()
!PgDn::		Sven.SelectRadiant()
PgUp::		Sven.CycleAllyUp()
PgDn::		Sven.CycleAllyDown()
Capslock::	Sven.OpenShop()
F8:: 		Sven.DirectionalMove(1)
End::		Sven.DirectionalForce()
!End::		Sven.DirectionalForceTp()
F9:: 		Sven.Shrine()
F11::		Sven.DisplayHelp()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------

; Pop ultimate before MoM

r::
Sven.CastSpell(Ability.Ultimate)
Sven.CastSpell(Ability.Ultimate)
Sven.UseItem(Item.LowerR)
return


#Include ahk_meta.ahk