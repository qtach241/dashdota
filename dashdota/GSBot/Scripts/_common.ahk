;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; Auto close shop when Capslock released
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

Capslock::
SetCapsLockState, on
keywait, CapsLock
SetCapsLockState, off
return

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; Auto right-click + stop while holding Mbutton
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

*Mbutton::
Click right
Sleep 200
SetKeyDelay 50
Loop 
{
	if (GetKeyState("Mbutton","P") = 0)
	{
		break
	}
	Send s
	Click right
}
return

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; Auto Courier
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

QueueBottleCrow()
{
	SendInput {Shift Down}
	;;SendInput {LAlt Down}
	SendInput rqtg
	;;SendInput {LAlt Up}
	SendInput {Shift Up}
}

;; Come Mein Chicken
F1::
SendInput z
Click Right
QueueBottleCrow()
;;SendInput {Home}
return

;; Go Mein Chicken
F2::
SendInput z
QueueBottleCrow()
;;SendInput {Home}
return

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; Directional Move
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

F8::
SendInput {n Down}
Click Right
SendInput {n Up}
return

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; Center Camera Allies
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

!WheelUp::
MouseGetPos, xPos_1, yPos_1
return

!F6::
MouseGetPos, xPos_2, yPos_2
return

!F7::
MouseGetPos, xPos_3, yPos_3
return

WheelUp::
MouseGetPos, xCurPos, yCurPos
MouseMove, xPos_1, yPos_1, 0
Click
Click
MouseMove, xCurPos, yCurPos, 0
return

F6::
MouseGetPos, xCurPos, yCurPos
MouseMove, xPos_2, yPos_2, 0
Click
Click
MouseMove, xCurPos, yCurPos, 0
return

F7::
MouseGetPos, xCurPos, yCurPos
MouseMove, xPos_3, yPos_3, 0
Click
Click
MouseMove, xCurPos, yCurPos, 0
return