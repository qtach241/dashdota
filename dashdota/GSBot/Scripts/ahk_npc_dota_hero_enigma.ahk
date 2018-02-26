#Include dota.ahk

Enigma := new Hero("Enigma")
return

;----------------------------------------- Universal Hotkeys ---------------------------------------

*MButton::	Enigma.AttackCancel(0.05)
!PgUp::		Enigma.SelectDire()
!PgDn::		Enigma.SelectRadiant()
PgUp::		Enigma.CycleAllyUp()
PgDn::		Enigma.CycleAllyDown()
Capslock::	Enigma.OpenShop()
F8:: 		Enigma.DirectionalMove(1)
End::		Enigma.DirectionalForce()
!End::		Enigma.DirectionalForceTp()
o::			Enigma.Shrine()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------

; Midnight pulse + bkb black hole
r::
Enigma.CastSpell(Ability.E)
Click
Enigma.UseItem(Item.LowerL)
Enigma.CastSpell(Ability.Ultimate)
return


#Include ahk_meta.ahk