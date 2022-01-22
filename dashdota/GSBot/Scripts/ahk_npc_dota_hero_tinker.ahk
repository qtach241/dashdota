#Include dota.ahk

Tinker := new Hero("Tinker")
return

;----------------------------------------- Universal Hotkeys ---------------------------------------

*MButton::	Tinker.AttackCancel(0.05)
;!PgUp::		Tinker.SelectDire()
;!PgDn::		Tinker.SelectRadiant()
;PgUp::		Tinker.CycleAllyUp()
;PgDn::		Tinker.CycleAllyDown()
Capslock::	Tinker.OpenShop()
F8:: 		Tinker.DirectionalMove(1)
End::		Tinker.DirectionalForce()
!End::		Tinker.DirectionalForceTp()
F9:: 		Tinker.Shrine()
F11::		Tinker.DisplayHelp()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------

; Quick cast blink
~Home::
Click
return

; Eblade/sheepstick dagon
XButton1::
Tinker.UseItem(Item.UpperR)
Click
Tinker.UseItem(Item.LowerL)
return

; Fighting AoE

r::
Tinker.UseItem(Item.UpperM)					; Soul Ring
Tinker.UseItem(Item.UpperR)					; Ghost Scepter
Tinker.CastSpell(Ability.W)
Tinker.CastSpell(Ability.W)
Tinker.UseItem(Item.LowerR)					; Bottle
Tinker.CastSpell(Ability.Ultimate)
return

; Fighting single target

d::
Tinker.UseItem(Item.UpperM)					; Soul Ring
Tinker.UseItem(Item.UpperR)					; Ghost Scepter / Sheepstick
Click
Tinker.UseItem(Item.LowerL)					; Dagon
Click
Tinker.CastSpell(Ability.Ultimate)
return

; Farming

t::
Tinker.UseItem(Item.UpperM) 					; Soul Ring
Tinker.UseItem(Item.UpperR) 					; Ghost Scepter
Tinker.DirectionalMove(1)
BlockInput, MouseMove
MouseGetPos, xCurPos, yCurPos
MouseMove, 900, 1300, 3
Tinker.CastSpell(Ability.E)
Tinker.CastSpell(Ability.E)
MouseMove, xCurPos, yCurPos
BlockInput, MouseMoveOff
Tinker.UseItem(Item.LowerR)					; Bottle
Tinker.CastSpell(Ability.Ultimate)
return

; Backpack items to recover faster in fountain

PgDn::
Tinker.UseItem(Item.UpperM)					; Soul Ring
BlockInput, MouseMove
MouseGetPos, xCurPos, yCurPos
Tinker.MoveItem(Item.LowerL, Item.BackpackL)		; Move LowerL item to backpack
Tinker.MoveItem(Item.UpperM, Item.BackpackM)		; Move UpperM item to backpack
Tinker.MoveItem(Item.UpperR, Item.BackpackR)		; Move UpperR item to backpack
MouseMove, xCurPos, yCurPos
BlockInput, MouseMoveOff
Tinker.UseItem(Item.UpperR)					; Bottle
Tinker.UseItem(Item.LowerR)
Tinker.CastSpell(Ability.Ultimate)				; Rearm
SetTimer, Bottle, -50
return

; Move items back to inventory

PgUp::
SetTimer, Bottle, Off						; Deactivate auto bottle
BlockInput, MouseMove
MouseGetPos, xCurPos, yCurPos
Tinker.MoveItem(Item.BackpackL, Item.LowerL)		; Move LowerL item back to inventory
Tinker.MoveItem(Item.BackpackM, Item.UpperM)		; Move UpperM item back to inventory
Tinker.MoveItem(Item.BackpackR, Item.UpperR)		; Move UpperR item back to inventory
MouseMove, xCurPos, yCurPos
BlockInput, MouseMoveOff
return

; Bottle self (bottle should be in one of two slots)

Bottle:
Tinker.UseItem(Item.UpperR)
Tinker.UseItem(Item.LowerR)
SetTimer, Bottle, 1000
return


#Include ahk_meta.ahk