#Include dota.ahk

Kunkka := new Hero("Kunkka")
return

;----------------------------------------- Universal Hotkeys ---------------------------------------

*MButton::	Kunkka.AttackCancel(0.05)
!PgUp::		Kunkka.SelectDire()
!PgDn::		Kunkka.SelectRadiant()
PgUp::		Kunkka.CycleAllyUp()
PgDn::		Kunkka.CycleAllyDown()
Capslock::	Kunkka.OpenShop()
F8:: 		Kunkka.DirectionalMove(1)
End::		Kunkka.DirectionalForce()
!End::		Kunkka.DirectionalForceTp()
F9:: 		Kunkka.Shrine()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------

; Cast X Return

Numpad0::
Kunkka.CastSpell(Ability.E)
return


#Include ahk_meta.ahk