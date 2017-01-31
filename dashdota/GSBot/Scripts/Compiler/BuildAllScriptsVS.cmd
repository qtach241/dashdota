echo Building Ahk Scripts
echo Ahk Compiler Location: %~f1
echo Ahk Source Location: %~f2
echo Ahk Output Location: %~f3

if not exist %~f3 mkdir %~f3

%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in "%~f2ahk_default.ahk" /out %~f3ahk_default.exe
%~f1Ahk2Exe.exe /bin %~f1AutoHotkeySC.bin /in %~f2ahk_npc_dota_hero_magnataur.ahk /out %~f3ahk_npc_dota_hero_magnataur.exe