@echo off
chcp 65001 >nul
title FlashWire Derleniyor...
echo ==============================================
echo  [FlashWire v2.0] MSBuild ile Derleniyor...
echo ==============================================
"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe" "%~dp0FlashWire.csproj" /p:Configuration=Release /p:Platform=x64
if %ERRORLEVEL% EQU 0 (
    echo.
    echo ==============================================
    echo  BAŞARILI! FlashWire.exe derlendi.
    echo  Konum: bin\Release\FlashWire.exe
    echo ==============================================
) else (
    echo.
    echo [HATA] Derleme işlemi başarısız oldu!
)
pause
