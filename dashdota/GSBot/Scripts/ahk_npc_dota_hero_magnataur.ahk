#NoEnv
#If WinActive("Dota 2")

#Include _common.ahk

t::
SendInput r
Sleep 120
SendInput s
return

g::
Click right
SendInput r
SendInput e
Click
return