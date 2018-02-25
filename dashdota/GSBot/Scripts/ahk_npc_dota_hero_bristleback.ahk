#Include dota.ahk

Bristleback := new Hero("Bristleback")
return

;----------------------------------------- Universal Hotkeys ---------------------------------------

*MButton::	Bristleback.AttackCancel(0.05)
!PgUp::		Bristleback.SelectDire()
!PgDn::		Bristleback.SelectRadiant()
PgUp::		Bristleback.CycleAllyUp()
PgDn::		Bristleback.CycleAllyDown()
Capslock::	Bristleback.OpenShop()
F8:: 		Bristleback.DirectionalMove(1)
End::		Bristleback.DirectionalForce()
!End::		Bristleback.DirectionalForceTp()
o::			Bristleback.Shrine()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------

; Tread swap and quill spray

e::
Bristleback.TreadSwap(Ability.W, Item.UpperR, 10)
return


#Include ahk_meta.ahk