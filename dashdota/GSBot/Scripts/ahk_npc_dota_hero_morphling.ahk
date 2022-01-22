#Include dota.ahk

Morphling := new Hero("Morphling")
return

;----------------------------------------- Universal Hotkeys ---------------------------------------

*MButton::	Morphling.AttackCancel(0.05)
Capslock::	Morphling.OpenShop()
F8:: 		Morphling.DirectionalMove(1)
End::		Morphling.DirectionalForce()
!End::		Morphling.DirectionalForceTp()
F9:: 		Morphling.Shrine()
F11::		Morphling.DisplayHelp()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------

; Pop spells and de-morph

t::
Morphling.CastSpell(Ability.Ultimate)
Click
Morphling.CastSpell(Ability.Q)
Morphling.CastSpell(Ability.Q)
Click
Morphling.CastSpell(Ability.W)
Morphling.CastSpell(Ability.W)
Click
Morphling.CastSpell(Ability.E)
Morphling.CastSpell(Ability.E)
Click
Morphling.CastSpell(Ability.Ultimate)
return

; E-blade combo
w::
Morphling.UseItem(Item.UpperR)
Click
Morphling.CastSpell(Ability.Sub1)
Morphling.CastSpell(Ability.W)
return

e::
Morphling.CastSpell(Ability.Sub2)
Morphling.CastSpell(Ability.E)
return


Numpad1::Morphling.CastSpell(Ability.Sub1)		; Agility
Numpad0::Morphling.CastSpell(Ability.Sub2)		; Strength


#Include ahk_meta.ahk