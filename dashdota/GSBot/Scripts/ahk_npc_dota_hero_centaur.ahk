﻿#Include dota.ahk

Centaur := new Hero("Centaur")
return

;----------------------------------------- Universal Hotkeys ---------------------------------------

*MButton::	Centaur.AttackCancel(0.05)
!PgUp::		Centaur.SelectDire()
!PgDn::		Centaur.SelectRadiant()
PgUp::		Centaur.CycleAllyUp()
PgDn::		Centaur.CycleAllyDown()
Capslock::	Centaur.OpenShop()
F8:: 		Centaur.DirectionalMove(1)
End::		Centaur.DirectionalForce()
!End::		Centaur.DirectionalForceTp()
F9:: 		Centaur.Shrine()
F11::		Centaur.DisplayHelp()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------

; Tranquil swap

t::
Centaur.TranquilSwap(Item.LowerR, Item.BackpackR)
return


#Include ahk_meta.ahk