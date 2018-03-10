#Include dota.ahk

Skywrath := new Hero("Skywrath_Mage")
return

;----------------------------------------- Universal Hotkeys ---------------------------------------

*MButton::	Skywrath.AttackCancel(0.05)
!PgUp::		Skywrath.SelectDire()
!PgDn::		Skywrath.SelectRadiant()
PgUp::		Skywrath.CycleAllyUp()
PgDn::		Skywrath.CycleAllyDown()
Capslock::	Skywrath.OpenShop()
F8:: 		Skywrath.DirectionalMove(1)
End::		Skywrath.DirectionalForce()
!End::		Skywrath.DirectionalForceTp()
F9:: 		Skywrath.Shrine()
F11::		Skywrath.DisplayHelp()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------

; Spam click Q

~q::
Skywrath.SpamClick(Ability.Q, 0.4, 0.02)
return

; Spam click E

~e::
Skywrath.SpamClick(Ability.E, 0.4, 0.02)
return


; Ult also fires W

r::
Skywrath.CastSpell(Ability.W)
Skywrath.CastSpell(Ability.Ultimate)
return


#Include ahk_meta.ahk