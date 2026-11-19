# ⚡ FlashWire v4.1 - Critical SSL & DNS Fix (Windows & Android Release)

> **Yüksek Hızlı DPI (Derin Paket İnceleme) ve DNS Engeli Aşma Kalkanı**  
> Discord, Roblox, Wattpad ve tüm kısıtlı servislere sıfır ping ve hız kaybıyla tek tıkla bağlanın.

---

### 📦 İndirme Seçenekleri (Downloads)

| Platform | Dosya | Açıklama | Boyut | İndirme Bağlantısı |
| :---: | :--- | :--- | :---: | :--- |
| 🪟 **Windows** | **`FlashWire-v4.1-Windows-x64.zip`** | **Önerilen PC Paketi** (FlashWire.exe + Hızlı Başlatıcı + Kılavuz) | ~2.0 MB | [⬇️ İndir (ZIP)](https://github.com/beratcemzengin/flashwire/releases/download/v4.1/FlashWire-v4.1-Windows-x64.zip) |
| 🪟 **Windows** | **`FlashWire.exe`** | Bağımsız Tek Dosya Taşınabilir Program (Portable) | ~2.0 MB | [⬇️ İndir (EXE)](https://github.com/beratcemzengin/flashwire/releases/download/v4.1/FlashWire.exe) |
| 🤖 **Android** | **`FlashWire-v4.1-Android.apk`** | **Android Mobil Sürüm** (Tüm Telefon & Tabletler) | ~3.5 MB | [⬇️ İndir (APK)](https://github.com/beratcemzengin/flashwire/releases/download/v4.1/FlashWire-v4.1-Android.apk) |

---

### 🚀 v4.1 Kritik Sürüm İyileştirmeleri (Hotfix)

- 🔒 **Kritik SSL Hatası Çözüldü (`ERR_SSL_PROTOCOL_ERROR` Fix):**
  - v4.0'da kullanılan `-5` modu paketleri tersten gönderdiği (`--reverse-frag`) için Cloudflare, Google, mTLS ve TLS 1.3 kullanan web sitelerinde SSL el sıkışması çöküyordu.
  - v4.1 ile motor, resmi ve en kararlı mod olan **`-1` (`-p -r -s -f 2 -k 2 -n -e 2`)** mimarisine geçirildi. Paketler sıralı ve nizami bölünerek DPI sansürü aşılırken, hiçbir sitenin SSL/HTTPS sertifikası bozulmaz.
- ⚡ **Cloudflare DNS (`1.1.1.1` & `1.0.0.1`) Geçişi:**
  - AdGuard DNS'in filtrelemeleri ve sorgu tıkanıklıkları kaldırılarak, dünyanın en hızlı ve tamamen tarafsız/nötr DNS'i olan **Cloudflare DNS** birincil ve ikincil DNS olarak atandı.
- 🚨 **Ağı ve DNS'i Sıfırla (Acil Kurtarma Butonu):**
  - Ayarlar menüsüne tek tıkla sistemi fabrika ayarlarına döndüren **"🚨 Ağı ve DNS'i Sıfırla"** butonu eklendi. Arka planda kalabilecek hizmetleri ve süreçleri anında temizler, DNS'i otomatik (DHCP) yapar.
- ⚙️ **Windows Hizmeti (`services.msc`) Kararlılığı:**
  - Hizmet parametreleri `-1` ve Cloudflare DNS ile güncellendi; 7/24 kesintisiz koruma SSL hatası vermeden güvenle çalışır hale getirildi.

---

### 🔒 Güvenlik & Dosya Doğrulama (SHA-256)

```text
FlashWire-v4.1-Windows-x64.zip : FFDA8061D735A661E2DEA6B374EFA42789D53D5492774CF479F7606B9A456C40
FlashWire.exe                  : 06662C09EA997CC2F09D49A65A6DE8BCE01E079C2866CB5AEBC4FBFD6E54071B
FlashWire-v4.1-Android.apk     : A56850066EF3A9EF6E74024BB8063A919D4819E5CCB8628362F754537C27F7B0
```

#### Windows:
1. `FlashWire.exe` dosyasını çalıştırın (SmartScreen uyarısında *Ek bilgi* -> *Yine de çalıştır* deyin).
2. Windows UAC Yönetici iznine **Evet** deyin.
3. **Manuel Mod:** Operatörünüzü seçip **⚡ BAĞLAN** butonuna tıklayın.
4. **7/24 Otomatik Servis Modu (İsteğe Bağlı):** Sağ üstteki **⚙ Ayarlar** çarkına tıklayın ve **"7/24 Windows Hizmeti Kur"** butonuna basın.

#### Android:
1. `FlashWire-v4.1-Android.apk` dosyasını telefonunuza indirin ve kurun.
2. Açıp profilinizi seçin ve **⚡ BAĞLAN** butonuna dokunun (VPN iznini onaylayın).
