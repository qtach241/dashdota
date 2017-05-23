#Include _common.ahk

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; T: Directional Move to Saved Location + RP Skewer Combo
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

t::
SendInput {F1}
MouseMove, xMagnus, yMagnus, 0
DirectionalMove(1)
SendInput rrrrrrr
Loop, 10
{
	SendInput e
	Sleep, 20
	Click
}
return

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; G: Save Current Mouse and Camera Position
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

g::
SaveMouseCameraPos(xMagnus, yMagnus)
return