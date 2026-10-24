@echo off
chcp 65001 >nul
title FlashWire Release Paketleyici
echo ==============================================
echo  FlashWire v4.0 - Release Paketi Oluşturuluyor
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
    `$rootExe = Join-Path '%~dp0' 'FlashWire.exe'; `
    `$relExe = Join-Path `$relDir 'FlashWire.exe'; `
    `$zipPath = Join-Path `$relDir 'FlashWire-v4.0-Windows-x64.zip'; `
    `$staging = Join-Path `$env:TEMP 'FlashWire_Staging'; `
    if (Test-Path `$staging) { Remove-Item `$staging -Recurse -Force }; `
    New-Item -ItemType Directory -Path `$staging -Force; `
    Copy-Item `$binExe (Join-Path `$staging 'FlashWire.exe') -Force; `
    Copy-Item `$binExe `$rootExe -Force; `
    Copy-Item `$binExe `$relExe -Force; `
    Copy-Item (Join-Path '%~dp0' 'Baslat.bat') (Join-Path `$staging 'Baslat.bat') -Force; `
    `$readme = @' `
============================================================ `
⚡ FLASHWIRE v4.0 (Windows x64) - Hizli Baslangic Kilavuzu `
============================================================ `
FlashWire, Windows uzerinde DPI ve DNS engellerini asarak `
Discord, Roblox ve tum engelli sitelere tek tikla sifir `
ping ve hiz kaybiyla erismenizi saglar. `
`
YENILIKLER (v4.0): `
- ⚙️ Windows Hizmeti (services.msc) Entegrasyonu: `
  Ayarlar menüsünden '7/24 Windows Hizmeti Kur' butonuna `
  tıklayarak FlashWire'ı arka plan servisi yapabilirsiniz. `
  Program açık olmasa ve PC yeniden başlasa bile `
  bağlantınız 7/24 kesintisiz açık kalır! `
- 🇹🇷 Superonline, Türk Telekom, Turkcell ve Vodafone desteği. `
- 🛡️ AdGuard DNS & WinDivert 1.4 entegrasyonu. `
`
KULLANIM: `
1. FlashWire.exe'ye cift tiklayin veya Baslat.bat'i calistirin. `
2. Yonetici iznine 'Evet' deyin. `
3. 'BAGLAN' butonuna basin ya da Ayarlar'dan Hizmet olarak kurun. `
'@; `
    Set-Content -Path (Join-Path `$staging 'BENIOKU.txt') -Value `$readme -Encoding UTF8; `
    if (Test-Path `$zipPath) { Remove-Item `$zipPath -Force }; `
    Compress-Archive -Path (Join-Path `$staging '*') -DestinationPath `$zipPath -Force; `
    `$apkSrc = Join-Path '%~dp0' 'FlashWire-4.0.apk'; `
    if (Test-Path `$apkSrc) { Copy-Item `$apkSrc (Join-Path `$relDir 'FlashWire-v4.0-Android.apk') -Force }; `
    `$hZip = (Get-FileHash `$zipPath -Algorithm SHA256).Hash; `
    `$hExe = (Get-FileHash `$relExe -Algorithm SHA256).Hash; `
    `$apkPath = Join-Path `$relDir 'FlashWire-v4.0-Android.apk'; `
    `$hApk = if (Test-Path `$apkPath) { (Get-FileHash `$apkPath -Algorithm SHA256).Hash } else { '' }; `
    `$sha = \"`$hZip  FlashWire-v4.0-Windows-x64.zip`r`n`$hExe  FlashWire.exe`r`n`$hApk  FlashWire-v4.0-Android.apk\"; `
    Set-Content -Path (Join-Path `$relDir 'SHA256SUMS.txt') -Value `$sha -Encoding UTF8; `
    Remove-Item `$staging -Recurse -Force; `
    Write-Host '[OK] Release dosyalari olusturuldu:' -ForegroundColor Green; `
    Get-ChildItem `$relDir | Select-Object Name, Length; `
}"

echo.
echo ==============================================
echo  [BASARILI] Release paketleri hazir!
echo  Konum: release\
echo ==============================================
