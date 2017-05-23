;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; Name: SelectTeamDire()
;; Args: none
;; Description: Sets the Team global to 1 (dire).
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

SelectTeamDire()
{
	global Team
	Team = 1
	SoundPlay, *64
	return
}

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; Name: SelectTeamRadiant()
;; Args: none
;; Description: Sets the Team global to 0 (radiant).
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

SelectTeamRadiant()
{
	global Team
	Team = 0
	SoundPlay, *48
	return
}

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; Name: CapslockShop()
;; Args: none
;; Description: Opens shop on capslock down, close shop on release.
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

CapslockShop() 
{
	SetCapsLockState, on
	keywait, CapsLock
	SetCapsLockState, off
	return
}

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; Name: CancelOnRelease(key, castpoint)
;; Args: [key]       Hotkey to pass in.
;;       [castpoint] Cast point in milliseconds.
;; Description: When [key] is released, sends the cancel command if the total
;; time spent held down is less than [castpoint].
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

CancelOnRelease(key, castpoint)
{
	Keywait, %key%
	if (A_TimeSinceThisHotkey < castpoint)
	{
		SendInput s
	}
	return
}

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; Name: SpamCancelOnRelease(key, castpoint)
;; Args: [key]       Hotkey to pass in.
;;       [castpoint] Cast point in milliseconds.
;; Description: Will continually spam [key] until released. When released, will
;; cancel cast if time spent held down is less then [castpoint]. Less precise
;; than CancelOnRelease(), but allows spamming out of disable.
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

SpamCancelOnRelease(key, castpoint)
{
	While GetKeyState(key, "P")
	{
		SendInput %key%
		Sleep, 20
	}
    if (A_TimeSinceThisHotkey < castpoint && A_TimeSinceThisHotkey > 0)
	{
		SendInput s
	}
	return
}

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; Name: SpamClickOn(key, hold, delay)
;; Args: [key]   The keybind to hold down.
;;       [hold]  Initial time to hold down to trigger spam click.
;;       [delay] Time between clicks.
;; Description: If [key] is held down for more than [hold] milliseconds, will
;; begin to auto spam left click with [delay] interval between clicks.
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

SpamClickOn(key, hold, delay)
{
	Sleep, %hold%
	SetMouseDelay, %delay%
	Loop
	{
		if (GetKeyState(key, "P") = 0)
		{
			break
		}
		SendInput %key%
		Click
	}
	return
}

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; Name: AttackCancel()
;; Args: none
;; Description: Right clicks at the start to initiate auto attack. Then
;; Sleeps for 200 ms. If KeyState of MButton is still down, will start to
;; spam attack cancel until MButton is released.
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

AttackCancel()
{
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
}

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; Name: QueueBottleCrow()
;; Args: none
;; Description: Helper function to shift que courier movement.
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

QueueBottleCrow()
{
	SendInput {Shift Down}
	SendInput rqtg
	SendInput {Shift Up}
	return
}

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; Name: BottleCrow()
;; Args: none
;; Description: Selects courier and sends it to fountain and back.
;; Assumes player has already moved bottle onto courier before firing
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

BottleCrow()
{
	SendInput z
	QueueBottleCrow()
	return
}

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; Name: BottleCrowGround()
;; Args: none
;; Description: Selects courier and commands it to pick up bottle from ground.
;; Then sends it to fountain and back. Assumes player is mousing over bottle
;; before firing.
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

BottleCrowGround()
{
	SendInput z
	Click right
	QueueBottleCrow()
	return
}

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; Name: DirectionalMove(n)
;; Args: [n] Number of times to spam directional move.
;; Description: Spams the hotkey to move hero in absolute direction.
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

DirectionalMove(n)
{
	SendInput {n Down}
	Loop, %n%
	{
		Click Right
	}
	SendInput {n Up}
	return
}

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; Name: DirectionalForce()
;; Args: none
;; Description: Spams Directional Move hotkey 10 times (to account for hero
;; turn rate), then force staff self.
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

DirectionalForce()
{
	DirectionalMove(10)
	SendInput {XButton1}
	SendInput {XButton1}
	return
}

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; Name: DirectionalForceTp()
;; Args: none
;; Description: Directional force staff and automatically tp.
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

DirectionalForceTp()
{
	DirectionalForce()
	SendInput ff
	return
}

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; Name: SaveMousePos(xPos, yPos)
;; Args: [xPos] Variable to hold the cursors current x position.
;;       [yPos] Variable to hold the cursors current y position.
;; Description: Gets current mouse position (x, y) and stores it in the
;; variables passed in by ref.
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

SaveMousePos(ByRef xPos, ByRef yPos)
{
	MouseGetPos, xPos, yPos
	SoundPlay, *48
	return
}

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; Name: SaveMouseCameraPos(xPos, yPos)
;; Args: [xPos] Variable to hold the cursors current x position.
;;       [yPos] Variable to hold the cursors current y position.
;; Description: Saves the current mouse position (x, y) as well as current
;; camera position.
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

SaveMouseCameraPos(ByRef xPos, ByRef yPos)
{
	MouseGetPos, xPos, yPos
	SendInput {LControl down}
	SendInput {F1}
	SendInput {LControl up}
	SendInput {Space down}
	Click
	SendInput {Space up}
	return
}

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; Name: MoveClickMouse(xPos, yPos, clickCount)
;; Args: [xPos] Variable that holds the x position to move cursor to.
;;       [yPos] Variable that holds the y position to move cursor to.
;;       [clickCount] Number of times to click.
;; Description: Clicks a number of times on the position specified by the
;; arguments. Then moves mouse back to previous position.
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

MoveClickMouse(ByRef xPos, ByRef yPos, clickCount)
{
	MouseGetPos, xCurPos, yCurPos
	MouseMove, xPos, yPos, 0
	Click %clickCount%
	MouseMove, xCurPos, yCurPos, 0
	return
}