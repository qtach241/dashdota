#Include dota.ahk

Magnus := new Hero("Magnataur")
return

;----------------------------------------- Universal Hotkeys ---------------------------------------

*MButton::	Magnus.AttackCancel(0.05)
!PgUp::		Magnus.SelectDire()
!PgDn::		Magnus.SelectRadiant()
PgUp::		Magnus.CycleAllyUp()
PgDn::		Magnus.CycleAllyDown()
Capslock::	Magnus.OpenShop()
F8:: 		Magnus.DirectionalMove(1)
End::		Magnus.DirectionalForce()
!End::		Magnus.DirectionalForceTp()
o::			Magnus.Shrine()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------


#Include ahk_meta.ahk