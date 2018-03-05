#Include dota.ahk

Shadowfiend := new Hero("Nevermore")
return

;----------------------------------------- Universal Hotkeys ---------------------------------------

*MButton::	Shadowfiend.AttackCancel(0.05)
!PgUp::		Shadowfiend.SelectDire()
!PgDn::		Shadowfiend.SelectRadiant()
PgUp::		Shadowfiend.CycleAllyUp()
PgDn::		Shadowfiend.CycleAllyDown()
Capslock::	Shadowfiend.OpenShop()
F8:: 		Shadowfiend.DirectionalMove(1)
End::		Shadowfiend.DirectionalForce()
!End::		Shadowfiend.DirectionalForceTp()
F9:: 		Shadowfiend.Shrine()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------

; Directional Raze

$q::
Shadowfiend.DirectionalMove(1)
Shadowfiend.CastSpell(Ability.Q)
return

; Directional Raze

$w::
Shadowfiend.DirectionalMove(1)
Shadowfiend.CastSpell(Ability.W)
return

; Directional Raze

$e::
Shadowfiend.DirectionalMove(1)
Shadowfiend.CastSpell(Ability.E)
return


#Include ahk_meta.ahk