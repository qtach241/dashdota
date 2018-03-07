echo Building Ahk Scripts
echo Ahk Compiler Location: %~f1
echo Ahk Source Location: %~f2
echo Ahk Output Location: %~f3

if not exist %~f3 mkdir %~f3

copy %~f2settings.ini %~f3

%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in "%~f2ahk_default.ahk" /out %~f3ahk_default.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_alchemist.ahk /out %~f3ahk_npc_dota_hero_alchemist.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_arc_warden.ahk /out %~f3ahk_npc_dota_hero_arc_warden.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_axe.ahk /out %~f3ahk_npc_dota_hero_axe.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_beastmaster.ahk /out %~f3ahk_npc_dota_hero_beastmaster.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_bristleback.ahk /out %~f3ahk_npc_dota_hero_bristleback.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_centaur.ahk /out %~f3ahk_npc_dota_hero_centaur.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_chaos_knight.ahk /out %~f3ahk_npc_dota_hero_chaos_knight.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_chen.ahk /out %~f3ahk_npc_dota_hero_chen.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_crystal_maiden.ahk /out %~f3ahk_npc_dota_hero_crystal_maiden.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_dark_seer.ahk /out %~f3ahk_npc_dota_hero_dark_seer.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_disruptor.ahk /out %~f3ahk_npc_dota_hero_disruptor.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_dragon_knight.ahk /out %~f3ahk_npc_dota_hero_dragon_knight.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_enigma.ahk /out %~f3ahk_npc_dota_hero_enigma.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_huskar.ahk /out %~f3ahk_npc_dota_hero_huskar.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_invoker.ahk /out %~f3ahk_npc_dota_hero_invoker.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_kunkka.ahk /out %~f3ahk_npc_dota_hero_kunkka.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_legion_commander.ahk /out %~f3ahk_npc_dota_hero_legion_commander.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_life_stealer.ahk /out %~f3ahk_npc_dota_hero_life_stealer.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_magnataur.ahk /out %~f3ahk_npc_dota_hero_magnataur.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_morphling.ahk /out %~f3ahk_npc_dota_hero_morphling.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_naga_siren.ahk /out %~f3ahk_npc_dota_hero_naga_siren.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_nevermore.ahk /out %~f3ahk_npc_dota_hero_nevermore.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_omniknight.ahk /out %~f3ahk_npc_dota_hero_omniknight.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_puck.ahk /out %~f3ahk_npc_dota_hero_puck.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_pugna.ahk /out %~f3ahk_npc_dota_hero_pugna.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_skeleton_king.ahk /out %~f3ahk_npc_dota_hero_skeleton_king.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_skywrath_mage.ahk /out %~f3ahk_npc_dota_hero_skywrath_mage.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_slardar.ahk /out %~f3ahk_npc_dota_hero_slardar.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_slark.ahk /out %~f3ahk_npc_dota_hero_slark.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_sven.ahk /out %~f3ahk_npc_dota_hero_sven.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_tinker.ahk /out %~f3ahk_npc_dota_hero_tinker.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_tiny.ahk /out %~f3ahk_npc_dota_hero_tiny.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_treant.ahk /out %~f3ahk_npc_dota_hero_treant.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_warlock.ahk /out %~f3ahk_npc_dota_hero_warlock.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_wisp.ahk /out %~f3ahk_npc_dota_hero_wisp.exe