#Include dota.ahk

Darkseer := new Hero("Dark_Seer")
return

;----------------------------------------- Universal Hotkeys ---------------------------------------

*MButton::	Darkseer.AttackCancel(0.05)
!PgUp::		Darkseer.SelectDire()
!PgDn::		Darkseer.SelectRadiant()
PgUp::		Darkseer.CycleAllyUp()
PgDn::		Darkseer.CycleAllyDown()
Capslock::	Darkseer.OpenShop()
F8:: 		Darkseer.DirectionalMove(1)
End::		Darkseer.DirectionalForce()
!End::		Darkseer.DirectionalForceTp()
F9:: 		Darkseer.Shrine()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------

; Vacuum wall combo

r::
Darkseer.CastSpell(Ability.Q)
Click
Darkseer.CastSpell(Ability.Ultimate)
Click
return


#Include ahk_meta.ahk