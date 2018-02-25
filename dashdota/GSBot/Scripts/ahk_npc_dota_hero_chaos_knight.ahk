#Include dota.ahk

ChaosKnight := new Hero("Chaos_Knight")
return

;----------------------------------------- Universal Hotkeys ---------------------------------------

*MButton::	ChaosKnight.AttackCancel(0.05)
!PgUp::		ChaosKnight.SelectDire()
!PgDn::		ChaosKnight.SelectRadiant()
PgUp::		ChaosKnight.CycleAllyUp()
PgDn::		ChaosKnight.CycleAllyDown()
Capslock::	ChaosKnight.OpenShop()
F8:: 		ChaosKnight.DirectionalMove(1)
End::		ChaosKnight.DirectionalForce()
!End::		ChaosKnight.DirectionalForceTp()
o::			ChaosKnight.Shrine()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------

; Armlet Toggle

t::
ChaosKnight.UseItem(Item.LowerM)
ChaosKnight.UseItem(Item.LowerM)
return


#Include ahk_meta.ahk