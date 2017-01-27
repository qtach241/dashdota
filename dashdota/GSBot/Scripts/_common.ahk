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
F5::
SendInput z
Click Right
QueueBottleCrow()
;;SendInput {Home}
return

;; Go Mein Chicken
F6::
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
;; Auto Directional Self Force Staff
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
F1::
SendInput {n Down}
Click Right
SendInput {n Up}
Sleep, 250
SendInput {XButton1}
SendInput {XButton1}
return