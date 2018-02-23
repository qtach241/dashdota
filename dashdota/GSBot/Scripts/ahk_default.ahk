#Include dota.ahk

Generic := new Hero("Generic")
return

;----------------------------------------- Universal Hotkeys ---------------------------------------

*MButton::	Generic.AttackCancel(0.05)
!PgUp::		Generic.SelectDire()
!PgDn::		Generic.SelectRadiant()
PgUp::		Generic.CycleAllyUp()
PgDn::		Generic.CycleAllyDown()
Capslock::	Generic.OpenShop()
F8:: 		Generic.DirectionalMove(1)
End::		Generic.DirectionalForce()
!End::		Generic.DirectionalForceTp()
o::			Generic.Shrine()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------


#Include ahk_meta.ahk