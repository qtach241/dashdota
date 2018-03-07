#Include dota.ahk

Chen := new Hero("Chen")
return

;----------------------------------------- Universal Hotkeys ---------------------------------------

*MButton::	Chen.AttackCancel(0.05)
;!PgUp::		Chen.SelectDire()
;!PgDn::		Chen.SelectRadiant()
;PgUp::		Chen.CycleAllyUp()
;PgDn::		Chen.CycleAllyDown()
Capslock::	Chen.OpenShop()
F8:: 		Chen.DirectionalMove(1)
End::		Chen.DirectionalForce()
!End::		Chen.DirectionalForceTp()
F9:: 		Chen.Shrine()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------

;; Cast spells from melee control group

PgUp::
Chen.SelectControlGroup(ControlGroup.Group1)
Loop, 4
{
	Chen.CastSpell(Ability.Q)
	Click
	Chen.SelectNextUnit()
}
Chen.SelectAllUnits()
return

;; Cast spells from ranged control group

PgDn::
Chen.SelectHero()
Chen.CastSpell(Ability.Q)
Click
Chen.SelectControlGroup(ControlGroup.Group2)
Loop, 4
{
	Chen.CastSpell(Ability.Q)
	Click
	Chen.SelectNextUnit()
}
Chen.SelectAllUnits()
return


#Include ahk_meta.ahk