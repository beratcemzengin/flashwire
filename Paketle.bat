@echo off
chcp 65001 >nul
title FlashWire Release Paketleyici
echo ==============================================
echo  FlashWire v2.0 - Release Paketi Oluşturuluyor
echo ==============================================

echo [1/3] MSBuild ile x64 Release derleniyor...
"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe" "%~dp0FlashWire.csproj" /p:Configuration=Release /p:Platform=x64
if %ERRORLEVEL% NEQ 0 (
    echo [HATA] Derleme basarisiz oldu!
    pause
    exit /b %ERRORLEVEL%
)

echo.
echo [2/3] Release klasoru hazirlaniyor...
powershell -NoProfile -ExecutionPolicy Bypass -Command "& { `
    `$relDir = Join-Path '%~dp0' 'release'; `
    if (-not (Test-Path `$relDir)) { New-Item -ItemType Directory -Path `$relDir -Force }; `
    `$binExe = Join-Path '%~dp0' 'bin\Release\FlashWire.exe'; `
    `$relExe = Join-Path `$relDir 'FlashWire.exe'; `
    `$zipPath = Join-Path `$relDir 'FlashWire-v2.0-Windows-x64.zip'; `
    `$staging = Join-Path `$env:TEMP 'FlashWire_Staging'; `
    if (Test-Path `$staging) { Remove-Item `$staging -Recurse -Force }; `
    New-Item -ItemType Directory -Path `$staging -Force; `
    Copy-Item `$binExe (Join-Path `$staging 'FlashWire.exe') -Force; `
    Copy-Item (Join-Path '%~dp0' 'Baslat.bat') (Join-Path `$staging 'Baslat.bat') -Force; `
    `$readme = @' `
============================================================ `
⚡ FLASHWIRE v2.0 (Windows x64) - Hizli Baslangic Kilavuzu `
============================================================ `
FlashWire, Windows uzerinde DPI ve DNS engellerini asarak `
Discord, Roblox ve tum engelli sitelere tek tikla sifir `
ping ve hiz kaybiyla erismenizi saglar. `
`
KULLANIM: `
1. FlashWire.exe'ye cift tiklayin veya Baslat.bat'i calistirin. `
2. Yonetici iznine 'Evet' deyin. `
3. 'BAGLAN' butonuna basin. `
'@; `
    Set-Content -Path (Join-Path `$staging 'BENIOKU.txt') -Value `$readme -Encoding UTF8; `
    if (Test-Path `$zipPath) { Remove-Item `$zipPath -Force }; `
    Compress-Archive -Path (Join-Path `$staging '*') -DestinationPath `$zipPath -Force; `
    Copy-Item `$binExe `$relExe -Force; `
    `$hZip = (Get-FileHash `$zipPath -Algorithm SHA256).Hash; `
    `$hExe = (Get-FileHash `$relExe -Algorithm SHA256).Hash; `
    `$sha = \"`$hZip  FlashWire-v2.0-Windows-x64.zip`r`n`$hExe  FlashWire.exe\"; `
    Set-Content -Path (Join-Path `$relDir 'SHA256SUMS.txt') -Value `$sha -Encoding UTF8; `
    Remove-Item `$staging -Recurse -Force; `
    Write-Host '[OK] Release dosyalari olusturuldu:' -ForegroundColor Green; `
    Get-ChildItem `$relDir | Select-Object Name, Length; `
}"

echo.
echo ==============================================
echo  [BASARILI] Release zip ve exe hazir!
echo  Konum: release\FlashWire-v2.0-Windows-x64.zip
echo ==============================================
pause
