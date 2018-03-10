#Include dota.ahk

WraithKing := new Hero("Skeleton_King")
return

;----------------------------------------- Universal Hotkeys ---------------------------------------

*MButton::	WraithKing.AttackCancel(0.05)
!PgUp::		WraithKing.SelectDire()
!PgDn::		WraithKing.SelectRadiant()
PgUp::		WraithKing.CycleAllyUp()
PgDn::		WraithKing.CycleAllyDown()
Capslock::	WraithKing.OpenShop()
F8:: 		WraithKing.DirectionalMove(1)
End::		WraithKing.DirectionalForce()
!End::		WraithKing.DirectionalForceTp()
F9:: 		WraithKing.Shrine()
F11::		WraithKing.DisplayHelp()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------

; Armlet Toggle

t::
WraithKing.UseItem(Item.LowerR)
WraithKing.UseItem(Item.LowerR)
return


#Include ahk_meta.ahk