#Include dota.ahk

Tinker := new Hero("Tinker")
return

;----------------------------------------- Universal Hotkeys ---------------------------------------

*MButton::	Tinker.AttackCancel(0.05)
!PgUp::		Tinker.SelectDire()
!PgDn::		Tinker.SelectRadiant()
PgUp::		Tinker.CycleAllyUp()
PgDn::		Tinker.CycleAllyDown()
Capslock::	Tinker.OpenShop()
F8:: 		Tinker.DirectionalMove(1)
End::		Tinker.DirectionalForce()
!End::		Tinker.DirectionalForceTp()
F9:: 		Tinker.Shrine()
F11::		Tinker.DisplayHelp()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------

;Home::
;Spam blink
;return

; Quick cast blink
~Home::
Click
return

; Eblade/sheepstick dagon
d::
Tinker.UseItem(Item.UpperR)
Click
Tinker.UseItem(Item.LowerL)
return

; Fighting AoE

r::
Tinker.UseItem(Item.UpperM)
Tinker.UseItem(Item.UpperR)
Tinker.CastSpell(Ability.W)
Tinker.CastSpell(Ability.W)
Tinker.CastSpell(Ability.Ultimate)
return

; Fighting single target

; Farming

t::
Tinker.UseItem(Item.UpperM)
Tinker.UseItem(Item.UpperR)
Tinker.CastSpell(Ability.E)
Tinker.CastSpell(Ability.E)
Tinker.CastSpell(Ability.Ultimate)
return

; Recover in fountain
1::
Tinker.UseItem(Item.UpperM)
Tinker.UseItem(Item.LowerR)
Tinker.CastSpell(Ability.Ultimate)
return

#Include ahk_meta.ahk