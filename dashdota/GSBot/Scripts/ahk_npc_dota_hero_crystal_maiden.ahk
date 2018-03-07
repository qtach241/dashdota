#Include dota.ahk

CrystalMaiden := new Hero("Crystal_Maiden")
return

;----------------------------------------- Universal Hotkeys ---------------------------------------

*MButton::	CrystalMaiden.AttackCancel(0.05)
!PgUp::		CrystalMaiden.SelectDire()
!PgDn::		CrystalMaiden.SelectRadiant()
PgUp::		CrystalMaiden.CycleAllyUp()
PgDn::		CrystalMaiden.CycleAllyDown()
Capslock::	CrystalMaiden.OpenShop()
F8:: 		CrystalMaiden.DirectionalMove(1)
End::		CrystalMaiden.DirectionalForce()
!End::		CrystalMaiden.DirectionalForceTp()
F9:: 		CrystalMaiden.Shrine()

;--------------------------------------- Hero Specific Hotkeys -------------------------------------

; Bkb/glimmer + channel ultimate

r::
CrystalMaiden.UseItem(Item.LowerR)
CrystalMaiden.UseItem(Item.LowerR)
CrystalMaiden.CastSpell(Ability.Ultimate)
return


#Include ahk_meta.ahk