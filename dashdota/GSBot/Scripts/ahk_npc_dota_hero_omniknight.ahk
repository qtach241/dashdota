#Include dota.ahk

Omniknight := new Hero("Omniknight")
return

;----------------------------------------- Universal Hotkeys ---------------------------------------

*MButton::	Omniknight.AttackCancel(0.05)
!PgUp::		Omniknight.SelectDire()
!PgDn::		Omniknight.SelectRadiant()
PgUp::		Omniknight.CycleAllyUp()
PgDn::		Omniknight.CycleAllyDown()
Capslock::	Omniknight.OpenShop()
F8:: 		Omniknight.DirectionalMove(1)
End::		Omniknight.DirectionalForce()
!End::		Omniknight.DirectionalForceTp()
F9:: 		Omniknight.Shrine()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------

; Self heal and repel

e::
Omniknight.CastSpell(Ability.Q)
Omniknight.CastSpell(Ability.Q)
Omniknight.CastSpell(Ability.W)
Omniknight.CastSpell(Ability.W)
return


#Include ahk_meta.ahk