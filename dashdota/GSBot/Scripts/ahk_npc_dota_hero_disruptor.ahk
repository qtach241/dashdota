#Include dota.ahk

Disruptor := new Hero("Disruptor")
return

;----------------------------------------- Universal Hotkeys ---------------------------------------

*MButton::	Disruptor.AttackCancel(0.05)
!PgUp::		Disruptor.SelectDire()
!PgDn::		Disruptor.SelectRadiant()
PgUp::		Disruptor.CycleAllyUp()
PgDn::		Disruptor.CycleAllyDown()
Capslock::	Disruptor.OpenShop()
F8:: 		Disruptor.DirectionalMove(1)
End::		Disruptor.DirectionalForce()
!End::		Disruptor.DirectionalForceTp()
F9:: 		Disruptor.Shrine()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------

; Static storm kinetic field combo

r::
Disruptor.CastSpell(Ability.Ultimate)
Click
Disruptor.CastSpell(Ability.E)
Click
return


#Include ahk_meta.ahk