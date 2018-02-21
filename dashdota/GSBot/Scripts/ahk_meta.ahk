; These meta-level hotkeys provide functionality independent of any hero.
; Hotkeys and functions to test certain parts of the main application can
; also be found here.

Esc::ExitApp

;1::ShowMousePos()

ShowMousePos()
{
	MouseGetPos, xpos, ypos
	MsgBox, The cursor is at X%xpos% Y%ypos%.
}