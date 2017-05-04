;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; Name: MoveToBackpack(invslot, bpslot)
;; Args: [invslot] Inventory slot number (1-6)
;;       [bpslot]  Backpack slot number (1-3)
;; Description: Moves items from inventory to backpack slot.
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

MoveToBackpack(invslot, bpslot)
{
	MouseGetPos, xCurPos, yCurPos

	if (invslot = 1)
	{
		MouseGetPos, xCurPos, yCurPos
		MouseMove, 1520, 1280, 0
		SendInput {LButton Down}
		MouseMove, 1520, 1400, 2
		SendInput {LButton Up}
		MouseMove, xCurPos, yCurPos, 0
	}
	else if (invslot = 2)
	{
	}
	else if (invslot = 3)
	{
	}

	return
}

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; Name: MoveToInventory(bpslot, invslot)
;; Args: [bpslot]  Backpack slot number (1-3)
;;       [invslot] Inventory slot number (1-6)
;; Description: Moves items from backpack to inventory slot.
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

MoveToInventory(bpslot, invslot)
{
	MouseGetPos, xCurPos, yCurPos

	if (bpslot = 1)
	{
		MouseMove, 1520, 1400, 0
		SendInput {LButton Down}
		MouseMove, 1520, 1280, 2
		SendInput {LButton Up}
		MouseMove, xCurPos, yCurPos, 0
	}

	return
}

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; Name: SwapTranquils()
;; Args: none
;; Description: Moves item (presumably tranquil boots) from inventory slot 1
;; to back pack slot 1, then immediately back. Keeps track of the item
;; disable timer.
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

SwapTranquils()
{
	MoveToBackpack(1, 1)
	Sleep, 50
	MoveToInventory(1, 1)
	return
}
