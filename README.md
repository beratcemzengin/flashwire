<div align="center">

# ⚡ FlashWire v3.0
### Windows & Android İçin Yüksek Hızlı DPI ve DNS Engeli Aşma Kalkanı

<p align="center">
  <img src="assets/preview.png" alt="FlashWire v3.0 Arayüzü" width="340" style="border-radius: 18px; box-shadow: 0 10px 30px rgba(0,0,0,0.5);" />
</p>

[![Platform](https://img.shields.io/badge/Platform-Windows%20%7C%20Android-blue.svg?style=for-the-badge&logo=windows)](https://github.com/beratcemzengin/flashwire)
[![Version](https://img.shields.io/badge/Versiyon-v3.0-FFB800.svg?style=for-the-badge&logo=speedtest)](https://github.com/beratcemzengin/flashwire/releases)
[![License](https://img.shields.io/badge/Lisans-MIT-green.svg?style=for-the-badge)](LICENSE)
[![Zero Ping Loss](https://img.shields.io/badge/Ping%20Kaybı-%C2%B10%20ms%20(VPN%20Değil)-success.svg?style=for-the-badge)](#-flashwire-nedir-ve-neler-yapabilir)

**FlashWire**, Türkiye'deki internet servis sağlayıcılarının (Superonline, Turkcell, Vodafone, Türk Telekom, TurkNet, Kablonet) uyguladığı DPI (Deep Packet Inspection) ve DNS filtrelerini yerel paket desenkronizasyonu tekniğiyle aşan, **sıfır ping ve hız kaybıyla** çalışan bağımsız bir güvenlik ve erişim aracıdır.

---

</div>

## 📦 İndir (GitHub Releases)

Güncel sürümler doğrudan GitHub Releases üzerinden yayınlanmaktadır. Hem ana sayfadaki tablodan hem de sağ taraftaki **Releases** menüsünden her zaman en son sürüme ulaşabilirsiniz:

| Platform | Dosya Adı | Açıklama | Boyut | Doğrudan İndirme (Latest Release) |
| :---: | :--- | :--- | :---: | :---: |
| 🪟 **Windows** | **`FlashWire-v3.0-Windows-x64.zip`** | **Önerilen PC Paketi** (FlashWire.exe + Hızlı Başlatıcı + Kılavuz) | ~2.0 MB | [⬇️ İndir (.ZIP)](https://github.com/beratcemzengin/flashwire/releases/latest/download/FlashWire-v3.0-Windows-x64.zip) |
| 🪟 **Windows** | **`FlashWire.exe`** | Tek Dosya Bağımsız Portable Uygulama | ~2.0 MB | [⬇️ İndir (.EXE)](https://github.com/beratcemzengin/flashwire/releases/latest/download/FlashWire.exe) |
| 🤖 **Android** | **`FlashWire-v3.0-Android.apk`** | **Android Mobil Uygulama** (Telefon & Tablet) | ~3.5 MB | [⬇️ İndir (.APK)](https://github.com/beratcemzengin/flashwire/releases/latest/download/FlashWire-v3.0-Android.apk) |

> [!TIP]  
> 🔗 **Tüm Sürümler ve Değişiklik Geçmişi (Changelog):**  
> Sağ sütundaki veya bu bağlantıdaki **[🚀 GitHub Releases Sayfası](https://github.com/beratcemzengin/flashwire/releases)** üzerinden yayınlanan tüm geçmiş ve güncel versiyonlara, sürüm notlarına ve indirme dosyalarına tek tıkla ulaşabilirsiniz.

---

## 💡 FlashWire Nedir ve Neler Yapabilir?

Geleneksel VPN'ler tüm internet trafiğinizi yurt dışındaki uzak ve yavaş sunuculara yönlendirir; bu durum ping değerlerinizi 100-200 ms artırır ve internet hızınızı düşürür.

**FlashWire ise bir VPN DEĞİLDİR:**
- **Sıfır Ping ve Hız Kaybı:** Trafiğinizi harici bir sunucuya göndermez. Kendi cihazınızda paket başlıklarını DPI sistemlerinin tanıyamayacağı şekilde anlık olarak desenkronize eder.
- **Discord & Roblox Erişimi:** Discord masaüstü ve mobil uygulamasını, ses kanallarını, ekran paylaşımlarını ve Roblox'u gecikmesiz açar.
- **Tüm Engelli Servisler:** Wattpad, Ekşi Sözlük, Instagram ve sansürlenen diğer siteleri pürüzsüz açar.
- **AdGuard Güvenli DNS:** İSS tarafındaki DNS zehirleme (DNS hijacking) girişimlerini önler ve istenmeyen reklamları engeller.
- **Tamamen Taşınabilir (Portable):** Windows sürümünde kurulum gerekmez, Android sürümünde ise root gerekmez.

---

## 🎛️ Operatör & Profil Seçici (v3.0 İle Superonline Eklendi!)

Kullandığınız internet sağlayıcısının uyguladığı sansür yöntemine en uygun bypass profilini seçebilirsiniz:

| Profil | Desteklenen Sağlayıcı | Açıklama |
| :--- | :--- | :--- |
| **⚡ Otomatik** | *Tüm Ağlar & Genel* | Discord ve tüm siteler için en kararlı genel koruma modudur *(Varsayılan)*. |
| **🔴 Turkcell** | Turkcell Mobil | Turkcell 4.5G/5G mobil hatlarındaki sansürleri aşmak için özel profil. |
| **🟠 Superonline** *(YENİ)* | Superonline Fiber & VDSL | Superonline omurgasındaki agresif SNI/DPI filtrelerini aşmak için ayrılmış bağımsız profil. |
| **🟣 Vodafone** | Vodafone Fiber & Redbox / Mobil | Vodafone şebekesindeki TCP TTL ve paket bölme (multisplit) kurallarını uygular. |
| **🔵 Türk Telekom** | TTNet & Mobil | Türk Telekom omurgasındaki SNI engellemelerini desync teknikleriyle aşar. |
| **🟡 TurkNet** | GigaFiber & VDSL | TurkNet hatları için minimum gecikmeli hızlı bypass modudur. |
| **🟢 Türksat Kablonet**| Uydunet / Kablonet | Kablonet filtrelerine özel paket sırası değiştirme modudur. |
| **🌐 Evrensel Mod** | Tüm Şebekeler | Standart GoodbyeDPI -5 moduyla genel koruma sağlar. |

---

## 🎛️ Windows Arayüz ve Buton Rehberi

<div align="center">
  <img src="assets/preview.png" alt="FlashWire Arayüzü Detaylı Şema" width="320" />
</div>

### 1. Üst Başlık Çubuğu (Header Bar)
- **⚡ FlashWire Logosu & `v3.0` Rozeti:** Uygulamanın güncel sürüm durumunu simgeler.
- **🚀 Roket Butonu (Canlı Ağ & Site Teşhisi):**
  - Tıklandığında pencerenin alt kısmında **Canlı Teşhis Çekmecesi** açılır.
  - Tek tıkla **Discord, Roblox, Wattpad, Ekşi Sözlük, Instagram ve YouTube** sunucularına test istekleri gönderir.
  - Sitelerin açık olup olmadığını ve gerçek tepki sürelerini (örn: `✔ 42 ms` veya `✖ Engelli`) listeler.
- **⚙ Çark Butonu (Operatör Ayarları):** Operatör seçim kartını gizleyip açmanızı sağlar.
- **— Çizgi Butonu (Küçült):** Pencereyi görev çubuğuna ve sistem tepsisine (Tray) gizler.
- **✕ Kapat Butonu:** DPI korumasını güvenli şekilde durdurur, DNS ayarlarınızı otomatik eski haline döndürür ve kapatır.

### 2. Durum Rozeti & Halo Ekranı
- **`● ○ GÜVENLİK DEVRE DIŞI` / `● FLASHWIRE KORUMASI AKTİF` Rozeti:** Kalkanın anlık durumunu dinamik rozetle bildirir.
- **Merkez Halo Orb:** Cyberpunk Altın parıltı efektiyle kalkan durumunu görselleştirir.

### 3. Eylem Butonu (Ana Bağlantı Tuşu)
- **⚡ BAĞLAN (Altın Buton):** Tek bir tıklama ile WinDivert paket filtresini ve AdGuard DNS kalkanını devreye sokar.
- **✕ BAĞLANTIYI KES (Kırmızı Buton):** Tıklandığında anında korumayı durdurur ve DNS ayarlarınızı sıfırlar.

---

## 🤖 Android Mobil Sürümü (v3.0)

- **Root Gerekmez:** Android yerel VPN servisi üzerinden cihaz içinde yerel filtreleme yapar.
- **Mobil Veri (4.5G / 5G) & Wi-Fi:** Superonline, Turkcell, Vodafone ve Türk Telekom hatlarında tam uyumludur.
- **Tasarım:** PC sürümüyle birebir aynı Cyberpunk Altın ve Obsidian teması.
- **Kurulum:** [release/FlashWire-v3.0-Android.apk](release/FlashWire-v3.0-Android.apk) dosyasını indirip telefonunuza kurmanız yeterlidir.

---

## 🚀 Adım Adım Kullanım Kılavuzu

### 🪟 Windows:
1. **İndirin:** [release/FlashWire-v3.0-Windows-x64.zip](release/FlashWire-v3.0-Windows-x64.zip) arşivini indirin ve bir klasöre çıkartın.
2. **Çalıştırın:** `FlashWire.exe` dosyasına çift tıklayın veya `Baslat.bat` dosyasını çalıştırın.
3. **Yönetici İznini Onaylayın:** WinDivert çekirdek sürücüsü için açılışta çıkan Windows Yönetici İzni (UAC) uyarısına **"Evet"** deyin.
4. **Bağlanın:** Sağlayıcınızı seçin (örn: `Superonline`) ve **`⚡ BAĞLAN`** butonuna basın.

### 🤖 Android:
1. **İndirin:** [release/FlashWire-v3.0-Android.apk](release/FlashWire-v3.0-Android.apk) dosyasını indirin.
2. **Kurun & Açın:** APK dosyasını açıp kurulumu tamamlayın.
3. **Bağlanın:** Profilinizi seçip ortadaki **`⚡ BAĞLAN`** butonuna dokunun.

---

## 🛠️ Kaynak Koddan Derleme (Windows PC)

```cmd
Derle.bat
```

Tüm zip ve exe paketlerini sıfırdan hazırlamak için:
```cmd
Paketle.bat
```

---

## ❓ Sıkça Sorulan Sorular (SSS)

**S: FlashWire oyunlarda pingimi artırır mı?**  
**C:** Kesinlikle hayır. FlashWire bir VPN değildir. Trafiğiniz yurt dışı sunuculara yönlendirilmez; internet servis sağlayıcınızın sağladığı orijinal hız ve ping değerleri korunur.

**S: Discord'da ses kanallarına girebilir miyim?**  
**C:** Evet, Discord ses ve görüntü protokolleri (WebRTC/UDP) için gerekli kurallar profillerin içerisine entegre edilmiştir.

**S: Programı kapattığımda internet ayarlarım bozulur mu?**  
**C:** Hayır. FlashWire kapatıldığında uyguladığı geçici AdGuard DNS adreslerini otomatik temizler ve ağ adaptörünüzü varsayılan ayarlarına geri döndürür.

---

## ⚖️ Lisans

Bu proje **MIT Lisansı** altında özgür bir açık kaynak yazılım olarak paylaşılmaktadır. Detaylar için [LICENSE](LICENSE) dosyasına göz atabilirsiniz.

---

<div align="center">
  <sub>Geliştirici: <b>beratcemzengin</b> • ⚡ FlashWire v3.0</sub>
</div>
