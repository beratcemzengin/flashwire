@echo off
chcp 65001 >nul
set SCRIPT="%TEMP%\create_shortcut_%RANDOM%.vbs"
set TARGET="%~dp0release\FlashWire.exe"
if not exist %TARGET% set TARGET="%~dp0bin\Release\FlashWire.exe"
if not exist %TARGET% set TARGET="%~dp0FlashWire.exe"

set SHORTCUT="%USERPROFILE%\Desktop\FlashWire.lnk"

echo Set oWS = WScript.CreateObject("WScript.Shell") >> %SCRIPT%
echo sLinkFile = %SHORTCUT% >> %SCRIPT%
echo Set oLink = oWS.CreateShortcut(sLinkFile) >> %SCRIPT%
echo oLink.TargetPath = %TARGET% >> %SCRIPT%
echo oLink.WorkingDirectory = "%~dp0" >> %SCRIPT%
echo oLink.Description = "FlashWire v2.0 - High-Speed DPI & DNS Shield" >> %SCRIPT%
echo oLink.Save >> %SCRIPT%

cscript /nologo %SCRIPT%
del %SCRIPT%

echo ==============================================
echo  Masaüstüne "FlashWire" kısayolu oluşturuldu!
echo ==============================================
pause
