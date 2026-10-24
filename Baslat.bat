@echo off
title FlashWire v2.0 Başlatılıyor...
if exist "%~dp0FlashWire.exe" (
    start "" "%~dp0FlashWire.exe"
    exit
)
if exist "%~dp0release\FlashWire.exe" (
    start "" "%~dp0release\FlashWire.exe"
    exit
)
if exist "%~dp0bin\Release\FlashWire.exe" (
    start "" "%~dp0bin\Release\FlashWire.exe"
    exit
)
echo [UYARI] FlashWire.exe bulunamadı!
echo Lütfen önce 'Derle.bat' ile projeyi derleyin.
pause
