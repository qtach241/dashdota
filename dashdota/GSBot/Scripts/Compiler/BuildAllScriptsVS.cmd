echo Building Ahk Scripts
echo Ahk Compiler Location: %~f1
echo Ahk Source Location: %~f2
echo Ahk Output Location: %~f3

if not exist %~f3 mkdir %~f3

%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in "%~f2ahk_default.ahk" /out %~f3ahk_default.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_axe.ahk /out %~f3ahk_npc_dota_hero_axe.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_bristleback.ahk /out %~f3ahk_npc_dota_hero_bristleback.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_centaur.ahk /out %~f3ahk_npc_dota_hero_centaur.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_magnataur.ahk /out %~f3ahk_npc_dota_hero_magnataur.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_nevermore.ahk /out %~f3ahk_npc_dota_hero_nevermore.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_omniknight.ahk /out %~f3ahk_npc_dota_hero_omniknight.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_skywrath_mage.ahk /out %~f3ahk_npc_dota_hero_skywrath_mage.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_slardar.ahk /out %~f3ahk_npc_dota_hero_slardar.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_slark.ahk /out %~f3ahk_npc_dota_hero_slark.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_treant.ahk /out %~f3ahk_npc_dota_hero_treant.exe