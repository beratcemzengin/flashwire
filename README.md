<div align="center">

# ⚡ FlashWire v4.0
### Windows & Android İçin Yüksek Hızlı DPI ve DNS Engeli Aşma Kalkanı

<p align="center">
  <img src="assets/preview.png" alt="FlashWire v4.0 Arayüzü" width="340" style="border-radius: 18px; box-shadow: 0 10px 30px rgba(0,0,0,0.5);" />
</p>

[![Platform](https://img.shields.io/badge/Platform-Windows%20%7C%20Android-blue.svg?style=for-the-badge&logo=windows)](https://github.com/beratcemzengin/flashwire)
[![Version](https://img.shields.io/badge/Versiyon-v4.0-FFB800.svg?style=for-the-badge&logo=speedtest)](https://github.com/beratcemzengin/flashwire/releases)
[![License](https://img.shields.io/badge/Lisans-MIT-green.svg?style=for-the-badge)](LICENSE)
[![Zero Ping Loss](https://img.shields.io/badge/Ping%20Kaybı-%C2%B10%20ms%20(VPN%20Değil)-success.svg?style=for-the-badge)](#-flashwire-nedir-ve-neler-yapabilir)

**FlashWire**, Türkiye'deki internet servis sağlayıcılarının (Superonline, Turkcell, Vodafone, Türk Telekom, TurkNet, Kablonet) uyguladığı DPI (Deep Packet Inspection) ve DNS filtrelerini yerel paket desenkronizasyonu tekniğiyle aşan, **sıfır ping ve hız kaybıyla** çalışan bağımsız bir güvenlik ve erişim aracıdır.

---

</div>

## 📦 İndir (GitHub Releases)

Güncel sürümler doğrudan GitHub Releases üzerinden yayınlanmaktadır. Hem ana sayfadaki tablodan hem de sağ taraftaki **Releases** menüsünden her zaman en son sürüme ulaşabilirsiniz:

| Platform | Dosya Adı | Açıklama | Boyut | Doğrudan İndirme (Latest Release) |
| :---: | :--- | :--- | :---: | :---: |
| 🪟 **Windows** | **`FlashWire-v4.0-Windows-x64.zip`** | **Önerilen PC Paketi** (FlashWire.exe + Hızlı Başlatıcı + Kılavuz) | ~2.0 MB | [⬇️ İndir (.ZIP)](https://github.com/beratcemzengin/flashwire/releases/latest/download/FlashWire-v4.0-Windows-x64.zip) |
| 🪟 **Windows** | **`FlashWire.exe`** | Tek Dosya Bağımsız Portable Uygulama | ~2.0 MB | [⬇️ İndir (.EXE)](https://github.com/beratcemzengin/flashwire/releases/latest/download/FlashWire.exe) |
| 🤖 **Android** | **`FlashWire-v4.0-Android.apk`** | **Android Mobil Uygulama** (Telefon & Tablet) | ~3.5 MB | [⬇️ İndir (.APK)](https://github.com/beratcemzengin/flashwire/releases/latest/download/FlashWire-v4.0-Android.apk) |

> [!TIP]  
> 🔗 **Tüm Sürümler ve Değişiklik Geçmişi (Changelog):**  
> Sağ sütundaki veya bu bağlantıdaki **[🚀 GitHub Releases Sayfası](https://github.com/beratcemzengin/flashwire/releases)** üzerinden yayınlanan tüm geçmiş ve güncel versiyonlara, sürüm notlarına ve indirme dosyalarına tek tıkla ulaşabilirsiniz.

---

## 💡 FlashWire Nedir ve Neler Yapabilir?

Geleneksel VPN'ler tüm internet trafiğinizi yurt dışındaki uzak ve yavaş sunuculara yönlendirir; bu durum ping değerlerinizi 100-200 ms artırır ve internet hızınızı düşürür.

**FlashWire ise bir VPN DEĞİLDİR:**
- **Sıfır Ping ve Hız Kaybı:** Trafiğinizi harici bir sunucuya göndermez. Kendi cihazınızda paket başlıklarını DPI sistemlerinin tanıyamayacağı şekilde anlık olarak desenkronize eder.
- **⚙️ 7/24 Windows Hizmeti (v4.0 YENİLİK):** Windows servislerine (`services.msc`) tek tıkla entegre olur. PC açıldığında oturum açılmasa bile arka planda otomatik çalışır!
- **Discord & Roblox Erişimi:** Discord masaüstü ve mobil uygulamasını, ses kanallarını, ekran paylaşımlarını ve Roblox'u gecikmesiz açar.
- **Tüm Engelli Servisler:** Wattpad, Ekşi Sözlük, Instagram ve sansürlenen diğer siteleri pürüzsüz açar.
- **AdGuard Güvenli DNS:** İSS tarafındaki DNS zehirleme (DNS hijacking) girişimlerini önler ve istenmeyen reklamları engeller.
- **Tamamen Taşınabilir (Portable):** Windows sürümünde kurulum zorunluluğu yoktur (ister portable ister servis olarak çalıştırın), Android sürümünde ise root gerekmez.

---

## ⚙️ v4.0 Windows Hizmeti (services.msc) Mimarisi

FlashWire v4.0 ile artık her bilgisayarı açtığınızda programı manuel olarak başlatmak zorunda değilsiniz:

1. **Ayarlar (⚙)** çarkına tıklayın.
2. Açılan panelde **"7/24 Windows Hizmeti Olarak Kur"** butonuna basın.
3. FlashWire, sistem motorunu `%ProgramData%\FlashWire\engine` klasörüne yerleştirir ve Windows Hizmet Yöneticisi'ne (`FlashWireService`) kaydeder.
4. **Sonuç:**
   - Bilgisayarınız her yeniden başladığında, siz oturum açmasanız dahi FlashWire arka planda 7/24 çalışır.
   - FlashWire arayüzünü (GUI) kapatsanız bile koruma asla kesilmez.
   - İstediğiniz zaman aynı menüden **"Hizmeti Kaldır"** butonuna basarak sistemi ilk haline getirebilirsiniz.

---

## 🎛️ Operatör & Profil Seçici

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
- **⚡ FlashWire Logosu & `v4.0` Rozeti:** Uygulamanın güncel sürüm durumunu simgeler.
- **🚀 Roket Butonu (Canlı Ağ & Site Teşhisi):**
  - Tıklandığında pencerenin alt kısmında **Canlı Teşhis Çekmecesi** açılır.
  - Tek tıkla **Discord, Roblox, Wattpad, Ekşi Sözlük, Instagram ve YouTube** sunucularına test istekleri gönderir.
  - Sitelerin açık olup olmadığını ve gerçek tepki sürelerini (örn: `✔ 42 ms` veya `✖ Engelli`) listeler.
- **⚙ Çark Butonu (Operatör & Servis Ayarları):** Operatör seçim kartını ve **7/24 Windows Servisi Kur/Kaldır** panelini gizleyip açmanızı sağlar.
- **— Çizgi Butonu (Küçült):** Pencereyi görev çubuğuna ve sistem tepsisine (Tray) gizler.
- **✕ Kapat Butonu:** Manuel moddaysanız DPI korumasını durdurup DNS'i sıfırlar; Servis modundaysanız pencereyi kapatır fakat hizmet arka planda 7/24 kesintisiz çalışmayı sürdürür.

### 2. Durum Rozeti & Halo Ekranı
- **`● ○ GÜVENLİK DEVRE DIŞI` / `● FLASHWIRE KORUMASI AKTİF` Rozeti:** Kalkanın anlık durumunu dinamik rozetle bildirir.
- **Merkez Halo Orb:** Cyberpunk Altın parıltı efektiyle kalkan durumunu görselleştirir.

### 3. Eylem Butonu (Ana Bağlantı Tuşu)
- **⚡ BAĞLAN (Altın Buton):** Tek bir tıklama ile WinDivert paket filtresini ve AdGuard DNS kalkanını devreye sokar.
- **✕ BAĞLANTIYI KES (Kırmızı Buton):** Tıklandığında anında korumayı durdurur ve DNS ayarlarınızı sıfırlar.

---

## 🤖 Android Mobil Sürümü (v4.0)

- **Root Gerekmez:** Android yerel VPN servisi üzerinden cihaz içinde yerel filtreleme yapar.
- **Mobil Veri (4.5G / 5G) & Wi-Fi:** Superonline, Turkcell, Vodafone ve Türk Telekom hatlarında tam uyumludur.
- **Tasarım:** PC sürümüyle birebir aynı Cyberpunk Altın ve Obsidian teması.
- **Kurulum:** [release/FlashWire-v4.0-Android.apk](release/FlashWire-v4.0-Android.apk) dosyasını indirip telefonunuza kurmanız yeterlidir.

---

## 🚀 Adım Adım Kullanım Kılavuzu

### 🪟 Windows:
1. **İndirin:** [release/FlashWire-v4.0-Windows-x64.zip](release/FlashWire-v4.0-Windows-x64.zip) arşivini indirin ve bir klasöre çıkartın.
2. **Çalıştırın:** `FlashWire.exe` dosyasına çift tıklayın veya `Baslat.bat` dosyasını çalıştırın.
3. **SmartScreen Uyarısı Çıkarsa:**
   > [!NOTE]  
   > **🛡️ Windows Defender SmartScreen ("Kişisel Bilgisayarınızı Korudu") Uyarısı Hakkında:**  
   > FlashWire tamamen açık kaynaklı, bağımsız ve güvenli bir yazılımdır. Windows, ticari ve ücretli kurumsal kod imzalama sertifikası satın almayan açık kaynaklı yeni geliştirici araçlarında bu standart itibar uyarısını gösterir.  
   > Bu ekran çıktığında çalıştırmak için:  
   > 1. Ekranda yer alan **"Ek bilgi"** *(More info)* bağlantısına tıklayın.  
   > 2. Altta beliren **"Yine de çalıştır"** *(Run anyway)* butonuna basın.
4. **Yönetici İznini Onaylayın:** WinDivert çekirdek sürücüsü için açılışta çıkan Windows Yönetici İzni (UAC) uyarısına **"Evet"** deyin.
5. **Bağlanın:** Sağlayıcınızı seçin (örn: `Superonline`) ve **`⚡ BAĞLAN`** butonuna basın veya Ayarlar (⚙) menüsünden **7/24 Servis Kur** butonuna tıklayın.

### 🤖 Android:
1. **İndirin:** [release/FlashWire-v4.0-Android.apk](release/FlashWire-v4.0-Android.apk) dosyasını indirin.
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

**S: Windows SmartScreen uyarısı neden çıkıyor? Dosya güvenli mi?**  
**C:** FlashWire tamamen açık kaynaklıdır; tüm kaynak kodları bu depoda halka açıktır ve hiçbir kullanıcı verisi toplamaz. Microsoft SmartScreen, yıllık yüksek ücretler ödenerek satın alınan ticari EV sertifikalarına sahip olmayan bağımsız açık kaynak yazılımlarda bu uyarıyı verir. Ayrıca yerel paket desenkronizasyonu için kullanılan açık kaynaklı `WinDivert` sürücüsü bazı antivirüslerce yanlış pozitif (false positive) olarak etiketlenebilir. "Ek bilgi" ➔ "Yine de çalıştır" diyerek güvenle kullanabilirsiniz.

**S: 7/24 Windows Hizmeti nasıl çalışır?**  
**C:** FlashWire Ayarlar menüsünden servisi kurduğunuzda, `goodbyedpi.exe` Windows'un resmi Hizmet Yöneticisi'ne (`FlashWireService`) kaydedilir. Bilgisayar açıldığı andan itibaren arka planda çalışarak internetinizi sürekli korur.

**S: FlashWire oyunlarda pingimi artırır mı?**  
**C:** Kesinlikle hayır. FlashWire bir VPN değildir. Trafiğiniz yurt dışı sunuculara yönlendirilmez; internet servis sağlayıcınızın sağladığı orijinal hız ve ping değerleri korunur.

**S: Discord'da ses kanallarına girebilir miyim?**  
**C:** Evet, Discord ses ve görüntü protokolleri (WebRTC/UDP) için gerekli kurallar profillerin içerisine entegre edilmiştir.

**S: Programı kapattığımda internet ayarlarım bozulur mu?**  
**C:** Hayır. Manuel modda FlashWire kapatıldığında DNS ayarlarınız varsayılana döner. Servis modunda ise 7/24 kesintisiz koruma devam eder.

---

## ⚖️ Lisans

Bu proje **MIT Lisansı** altında özgür bir açık kaynak yazılım olarak paylaşılmaktadır. Detaylar için [LICENSE](LICENSE) dosyasına göz atabilirsiniz.

---

<div align="center">
  <sub>Geliştirici: <b>beratcemzengin</b> • ⚡ FlashWire v4.0</sub>
</div>
