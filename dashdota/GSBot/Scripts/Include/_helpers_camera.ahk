;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; Name: FocusCamera(x, y)
;; Args: [x] X-coordinate of focus point 
;;       [y] Y-coordinate of focus point
;; Description: Double click mouse at an arbitrary position, then moves
;; mouse back to previous position.
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

FocusCamera(x, y)
{
	MouseGetPos, xCurPos, yCurPos
	MouseMove, %x%, %y%, 0
	Click 2
	MouseMove, xCurPos, yCurPos, 0
	return
}

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; Name: CycleFocusUp()
;; Args: none
;; Description: Focus camera on the "next" focus position specified by the
;; global variable FocusPos.
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

CycleFocusUp()
{
	global Team
	
	if (Team = 0)
	{
		global FocusPos
		if (FocusPos = 0)
		{
			FocusPos = 1
			FocusCamera(840, 20)
		}
		else if (FocusPos = 1)
		{
			FocusPos = 2
			FocusCamera(930, 20)
		}
		else if (FocusPos = 2)
		{
			FocusPos = 3
			FocusCamera(1010, 20)
		}
		else if (FocusPos = 3)
		{
			FocusPos = 4
			FocusCamera(1090, 20)
		}
		else if (FocusPos = 4)
		{
			FocusPos = 0
			FocusCamera(760, 20)
		}
	}
	else
	{
		global FocusPos
		if (FocusPos = 0)
		{
			FocusPos = 1
			FocusCamera(1540, 20)
		}
		else if (FocusPos = 1)
		{
			FocusPos = 2
			FocusCamera(1620, 20)
		}
		else if (FocusPos = 2)
		{
			FocusPos = 3
			FocusCamera(1710, 20)
		}
		else if (FocusPos = 3)
		{
			FocusPos = 4
			FocusCamera(1790, 20)
		}
		else if (FocusPos = 4)
		{
			FocusPos = 0
			FocusCamera(1450, 20)
		}
	}
	return
}

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; Name: CycleFocusDown()
;; Args: none
;; Description: Focus camera on the "previous" focus position specified by the
;; global variable FocusPos.
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

CycleFocusDown()
{
	global Team
	
	if (Team = 0)
	{
		global FocusPos
		if (FocusPos = 0)
		{
			FocusPos = 4
			FocusCamera(1090, 20)
		}
		else if (FocusPos = 1)
		{
			FocusPos = 0
			FocusCamera(760, 20)
		}
		else if (FocusPos = 2)
		{
			FocusPos = 1
			FocusCamera(840, 20)
		}
		else if (FocusPos = 3)
		{
			FocusPos = 2
			FocusCamera(930, 20)
		}
		else if (FocusPos = 4)
		{
			FocusPos = 3
			FocusCamera(1010, 20)
		}
	}
	else
	{
		global FocusPos
		if (FocusPos = 0)
		{
			FocusPos = 4
			FocusCamera(1790, 20)
		}
		else if (FocusPos = 1)
		{
			FocusPos = 0
			FocusCamera(1450, 20)
		}
		else if (FocusPos = 2)
		{
			FocusPos = 1
			FocusCamera(1540, 20)
		}
		else if (FocusPos = 3)
		{
			FocusPos = 2
			FocusCamera(1620, 20)
		}
		else if (FocusPos = 4)
		{
			FocusPos = 3
			FocusCamera(1710, 20)
		}
	}
	return
}