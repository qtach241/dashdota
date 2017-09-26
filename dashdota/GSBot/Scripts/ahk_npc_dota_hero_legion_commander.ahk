#Include _common.ahk

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; T: Armlet Toggle
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

t::
SendInput dd
return

r::
SendInput {XButton2}
SendInput {XButton2}
SendInput {WheelUp}
SendInput {WheelUp}
SendInput ddr
return