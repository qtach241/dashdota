#Include dota.ahk

DragonKnight := new Hero("Dragon_Knight")
return

;----------------------------------------- Universal Hotkeys ---------------------------------------

*MButton::	DragonKnight.AttackCancel(0.05)
!PgUp::		DragonKnight.SelectDire()
!PgDn::		DragonKnight.SelectRadiant()
PgUp::		DragonKnight.CycleAllyUp()
PgDn::		DragonKnight.CycleAllyDown()
Capslock::	DragonKnight.OpenShop()
F8:: 		DragonKnight.DirectionalMove(1)
End::		DragonKnight.DirectionalForce()
!End::		DragonKnight.DirectionalForceTp()
F9:: 		DragonKnight.Shrine()
F11::		DragonKnight.DisplayHelp()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------

; Armlet Toggle

t::
DragonKnight.UseItem(Item.LowerR)
DragonKnight.UseItem(Item.LowerR)
return


#Include ahk_meta.ahk