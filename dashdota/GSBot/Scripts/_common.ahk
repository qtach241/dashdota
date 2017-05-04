#NoEnv
#If WinActive("Dota 2")

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; Globals/Helpers (Must be the first section in all scripts)
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

#Include Include/_globals.ahk
#Include Include/_helpers.ahk
#Include Include/_helpers_backpack.ahk
#Include Include/_helpers_camera.ahk

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; Common binds
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

!PgUp::
SelectTeamDire()
return

!PgDn::
SelectTeamRadiant()
return

Capslock::
CapslockShop()
return

*Mbutton::
AttackCancel()
return

F1::
BottleCrowGround()
return

F2::
BottleCrow()
return

F8::
DirectionalMove(1)
return

F10::
CycleFocusUp()
return

End::
DirectionalForce()
return

!End::
DirectionalForceTp()
return

!1::
SaveMousePos(xPos_1, yPos_1)
return

1::
MoveClickMouse(xPos_1, yPos_1, 2)
return

!2::
SaveMousePos(xPos_2, yPos_2)
return

2::
MoveClickMouse(xPos_2, yPos_2, 2)
return

!3::
SaveMousePos(xPos_3, yPos_3)
return

3::
MoveClickMouse(xPos_3, yPos_3, 2)
return

4::
SwapTranquils()
return