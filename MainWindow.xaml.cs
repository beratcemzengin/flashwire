using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Forms;
using System.IO.Compression;
using System.Text;

namespace FlashWire
{
    public partial class MainWindow : Window
    {
        private Process _engineProcess;
        private bool _isConnected = false;
        private bool _isDnsChanged = false;
        private string _lastEngineError = "";
        private NotifyIcon _notifyIcon;

        // Cyberpunk Obsidian & Gold Theme Palette
        private readonly SolidColorBrush _goldBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFB800"));
        private readonly SolidColorBrush _greenBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#10B981"));
        private readonly SolidColorBrush _redBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EF4444"));
        private readonly SolidColorBrush _slateBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#94A3B8"));
        private readonly SolidColorBrush _darkTextBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0B0D12"));

        private readonly SolidColorBrush _badgeRedBg = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#231518"));
        private readonly SolidColorBrush _badgeGoldBg = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#292211"));
        private readonly SolidColorBrush _badgeGreenBg = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0F291E"));

        public MainWindow()
        {
            InitializeComponent();
            SetupTrayIcon();
            this.Closing += MainWindow_Closing;
            this.Loaded += (s, e) => Task.Run(() => GetEngineDirectory());
        }

        private void SetupTrayIcon()
        {
            try
            {
                _notifyIcon = new NotifyIcon();
                _notifyIcon.Text = "FlashWire v3.0 - DPI & DNS Kalkanı";
                try
                {
                    var iconUri = new Uri("pack://application:,,,/app.ico");
                    var iconInfo = System.Windows.Application.GetResourceStream(iconUri);
                    if (iconInfo != null)
                    {
                        using (var stream = iconInfo.Stream)
                        {
                            _notifyIcon.Icon = new System.Drawing.Icon(stream);
                        }
                    }
                    else
                    {
                        _notifyIcon.Icon = System.Drawing.SystemIcons.Shield;
                    }
                }
                catch
                {
                    _notifyIcon.Icon = System.Drawing.SystemIcons.Shield;
                }
                _notifyIcon.Visible = true;

                var menu = new ContextMenuStrip();
                var itemShow = menu.Items.Add("FlashWire'ı Aç");
                itemShow.Click += (s, e) => RestoreFromTray();

                var itemToggle = menu.Items.Add("Bağlan / Bağlantıyı Kes");
                itemToggle.Click += async (s, e) => await ToggleConnectionAsync();

                menu.Items.Add(new ToolStripSeparator());
                var itemExit = menu.Items.Add("Çıkış");
                itemExit.Click += (s, e) => {
                    CleanupEngine();
                    _notifyIcon.Visible = false;
                    _notifyIcon.Dispose();
                    System.Windows.Application.Current.Shutdown();
                };

                _notifyIcon.ContextMenuStrip = menu;
                _notifyIcon.DoubleClick += (s, e) => RestoreFromTray();
            }
            catch
            {
                // Tray icon fallback
            }
        }

        private void RestoreFromTray()
        {
            this.Show();
            this.WindowState = WindowState.Normal;
            this.Activate();
        }

        private void Header_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            CleanupEngine();
            if (_notifyIcon != null)
            {
                _notifyIcon.Visible = false;
                _notifyIcon.Dispose();
            }
            this.Close();
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CleanupEngine();
        }

        private void BtnSettings_Click(object sender, RoutedEventArgs e)
        {
            panelSettings.Visibility = panelSettings.Visibility == Visibility.Visible 
                ? Visibility.Collapsed 
                : Visibility.Visible;
        }

        private void BtnHeaderTest_Click(object sender, RoutedEventArgs e)
        {
            panelTest.Visibility = panelTest.Visibility == Visibility.Visible 
                ? Visibility.Collapsed 
                : Visibility.Visible;
        }

        private void BtnCloseTest_Click(object sender, RoutedEventArgs e)
        {
            panelTest.Visibility = Visibility.Collapsed;
        }

        private async void BtnStartTest_Click(object sender, RoutedEventArgs e)
        {
            btnStartTest.IsEnabled = false;
            btnStartTest.Content = "Testler Yapılıyor...";

            try
            {
                var t1 = CheckSiteAsync("https://discord.com", txtTestDiscord);
                var t2 = CheckSiteAsync("https://www.roblox.com", txtTestRoblox);
                var t3 = CheckSiteAsync("https://www.wattpad.com", txtTestWattpad);
                var t4 = CheckSiteAsync("https://eksisozluk.com", txtTestEksi);
                var t5 = CheckSiteAsync("https://www.instagram.com", txtTestInstagram);
                var t6 = CheckSiteAsync("https://www.youtube.com", txtTestYoutube);

                await Task.WhenAll(t1, t2, t3, t4, t5, t6);
            }
            catch { }
            finally
            {
                btnStartTest.Content = "Yeniden Test Et";
                btnStartTest.IsEnabled = true;
            }
        }

        private class SiteTestResult
        {
            public bool Success;
            public int ElapsedMs;
        }

        private async Task CheckSiteAsync(string url, TextBlock resultBlock)
        {
            resultBlock.Text = "⏳ Test...";
            resultBlock.Foreground = _goldBrush;

            SiteTestResult res = await Task.Run(() =>
            {
                Stopwatch sw = Stopwatch.StartNew();
                try
                {
                    System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
                    request.Timeout = 3500;
                    request.ReadWriteTimeout = 3500;
                    request.Method = "HEAD";
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) FlashWire/3.0";
                    request.AllowAutoRedirect = true;
                    using (System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse())
                    {
                        sw.Stop();
                        return new SiteTestResult { Success = true, ElapsedMs = (int)sw.ElapsedMilliseconds };
                    }
                }
                catch (System.Net.WebException webEx)
                {
                    sw.Stop();
                    // WebException with a response means DNS and TCP handshake succeeded
                    if (webEx.Response != null)
                    {
                        return new SiteTestResult { Success = true, ElapsedMs = (int)sw.ElapsedMilliseconds };
                    }
                    return new SiteTestResult { Success = false, ElapsedMs = 0 };
                }
                catch
                {
                    return new SiteTestResult { Success = false, ElapsedMs = 0 };
                }
            });

            if (res.Success)
            {
                resultBlock.Text = string.Format("✔ {0} ms", res.ElapsedMs);
                resultBlock.Foreground = _greenBrush;
            }
            else
            {
                resultBlock.Text = "✖ Engelli";
                resultBlock.Foreground = _redBrush;
            }
        }

        private void CmbProfiles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbProfiles == null || txtFooterEngine == null) return;
            ComboBoxItem item = cmbProfiles.SelectedItem as ComboBoxItem;
            if (item != null)
            {
                string text = item.Content.ToString();
                if (text.Contains("Superonline"))
                {
                    txtFooterEngine.Text = "Superonline Fiber • AdGuard DNS";
                }
                else if (text.Contains("Turkcell"))
                {
                    txtFooterEngine.Text = "Turkcell Mobil • AdGuard DNS";
                }
                else if (text.Contains("Vodafone"))
                {
                    txtFooterEngine.Text = "Vodafone Profili • AdGuard DNS";
                }
                else if (text.Contains("Türk Telekom"))
                {
                    txtFooterEngine.Text = "Türk Telekom Profili • AdGuard DNS";
                }
                else if (text.Contains("TurkNet"))
                {
                    txtFooterEngine.Text = "TurkNet Profili • AdGuard DNS";
                }
                else if (text.Contains("Kablonet"))
                {
                    txtFooterEngine.Text = "Kablonet Profili • AdGuard DNS";
                }
                else if (text.Contains("Evrensel"))
                {
                    txtFooterEngine.Text = "Evrensel GoodbyeDPI • 1.1.1.1 DNS";
                }
                else
                {
                    txtFooterEngine.Text = "AdGuard DNS • WinDivert x64";
                }
            }
        }

        private async void BtnConnectToggle_Click(object sender, RoutedEventArgs e)
        {
            await ToggleConnectionAsync();
        }

        private async Task ToggleConnectionAsync()
        {
            btnConnectToggle.IsEnabled = false;

            try
            {
                if (!_isConnected)
                {
                    // Start connecting
                    SetConnectingUI();
                    bool success = await StartBypassEngineAsync();
                    if (success)
                    {
                        _isConnected = true;
                        SetConnectedUI();
                    }
                    else
                    {
                        _isConnected = false;
                        SetDisconnectedUI("BAĞLANTI BAŞARISIZ");
                        string msg = "FlashWire DPI ve DNS kalkanı başlatılamadı.";
                        if (!string.IsNullOrEmpty(_lastEngineError))
                        {
                            msg += "\n\nHata Ayrıntısı:\n" + _lastEngineError;
                        }
                        else
                        {
                            msg += "\nLütfen programı 'Yönetici Olarak Çalıştır' seçeneğiyle açtığınızdan emin olun.";
                        }

                        System.Windows.MessageBox.Show(
                            msg,
                            "FlashWire - Uyarı",
                            MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                    }
                }
                else
                {
                    // Disconnecting
                    SetConnectingUI("KORUMA KAPATILIYOR...");
                    await Task.Run(() => CleanupEngine());
                    _isConnected = false;
                    SetDisconnectedUI();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                SetDisconnectedUI();
            }
            finally
            {
                btnConnectToggle.IsEnabled = true;
            }
        }

        private async Task<bool> StartBypassEngineAsync()
        {
            return await Task.Run(() =>
            {
                try
                {
                    _lastEngineError = "";
                    KillStaleProcesses();

                    string engineRoot = GetEngineDirectory();
                    int selectedProfile = 0;
                    Dispatcher.Invoke(() => { selectedProfile = cmbProfiles.SelectedIndex; });

                    string exePath = "";
                    string args = "";
                    string workingDir = "";

                    // Profile mapping
                    // 0: ⚡ Otomatik (Tüm Siteler & Discord - GoodbyeDPI + AdGuard DNS)
                    // 1: 🔴 Turkcell (Mobil Veri)
                    // 2: 🟠 Superonline (Fiber & VDSL)
                    // 3: 🟣 Vodafone (Fiber & Redbox)
                    // 4: 🔵 Türk Telekom (TTNet & Mobil)
                    // 5: 🟡 TurkNet (GigaFiber & VDSL)
                    // 6: 🟢 Türksat Kablonet
                    // 7: 🌐 Evrensel Mod (GoodbyeDPI)
                    if (selectedProfile == 0 || selectedProfile == 5 || selectedProfile == 7)
                    {
                        string gbdDir = Path.Combine(engineRoot, "goodbyedpi");
                        exePath = Path.Combine(gbdDir, "goodbyedpi.exe");
                        args = "-5 --dns-addr 94.140.14.14 --dns-port 53 --dnsv6-addr 2a10:50c0::ad1:ff --dnsv6-port 53";
                        workingDir = gbdDir;

                        // AdGuard DNS uygula
                        Task.Run(() => SetSystemDnsToAdGuard());
                        _isDnsChanged = true;
                    }
                    else
                    {
                        // Zapret2 engine for Turkcell, Superonline, Vodafone, TTNet, Kablonet
                        string zapDir = Path.Combine(engineRoot, "zapret");
                        exePath = Path.Combine(zapDir, "winws.exe");
                        workingDir = zapDir;

                        string technique = "--payload=tls_client_hello --lua-desync=multidisorder:pos=2:seqovl=1";
                        if (selectedProfile == 3) // Vodafone
                        {
                            technique = "--payload=tls_client_hello --lua-desync=multisplit:blob=fake_default_tls:ip_ttl=5:pos=2:nodrop:repeats=1";
                        }

                        string libPath = Path.Combine(zapDir, "lua", "zapret-lib.lua");
                        string antiPath = Path.Combine(zapDir, "lua", "zapret-antidpi.lua");

                        args = string.Format(
                            "--wf-l3=ipv4 --wf-tcp-out=0-65535 --wf-udp-out=0-65535 {0} \"--lua-init=@{1}\" \"--lua-init=@{2}\"",
                            technique,
                            libPath,
                            antiPath);

                        Task.Run(() => SetSystemDnsToAdGuard());
                        _isDnsChanged = true;
                    }

                    if (!File.Exists(exePath))
                    {
                        _lastEngineError = "Motor dosyası bulunamadı: " + exePath;
                        return false;
                    }

                    StringBuilder outputBuffer = new StringBuilder();

                    var psi = new ProcessStartInfo
                    {
                        FileName = exePath,
                        Arguments = args,
                        WorkingDirectory = workingDir,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardError = true,
                        RedirectStandardOutput = true,
                        WindowStyle = ProcessWindowStyle.Hidden
                    };

                    _engineProcess = new Process();
                    _engineProcess.StartInfo = psi;
                    _engineProcess.EnableRaisingEvents = true;
                    _engineProcess.OutputDataReceived += (s, e) => {
                        if (!string.IsNullOrEmpty(e.Data)) outputBuffer.AppendLine(e.Data);
                    };
                    _engineProcess.ErrorDataReceived += (s, e) => {
                        if (!string.IsNullOrEmpty(e.Data)) outputBuffer.AppendLine(e.Data);
                    };

                    bool started = _engineProcess.Start();
                    if (!started)
                    {
                        _lastEngineError = "Motor başlatılamadı: " + exePath;
                        return false;
                    }

                    _engineProcess.BeginOutputReadLine();
                    _engineProcess.BeginErrorReadLine();

                    // Motorun ayağa kalkması için bekleme
                    System.Threading.Thread.Sleep(800);

                    if (_engineProcess.HasExited)
                    {
                        string err = outputBuffer.ToString().Trim();
                        _lastEngineError = string.IsNullOrEmpty(err) ? "Çıkış kodu: " + _engineProcess.ExitCode : err;

                        // Akıllı Yedekleme (Fallback): Seçilen motor çöktüyse hemen GoodbyeDPI'ı dene
                        if (!exePath.Contains("goodbyedpi"))
                        {
                            string gbdDir = Path.Combine(engineRoot, "goodbyedpi");
                            string gbdExe = Path.Combine(gbdDir, "goodbyedpi.exe");
                            if (File.Exists(gbdExe))
                            {
                                var gbdPsi = new ProcessStartInfo
                                {
                                    FileName = gbdExe,
                                    Arguments = "-5 --dns-addr 94.140.14.14 --dns-port 53 --dnsv6-addr 2a10:50c0::ad1:ff --dnsv6-port 53",
                                    WorkingDirectory = gbdDir,
                                    UseShellExecute = false,
                                    CreateNoWindow = true,
                                    WindowStyle = ProcessWindowStyle.Hidden
                                };
                                _engineProcess = Process.Start(gbdPsi);
                                System.Threading.Thread.Sleep(700);
                                if (_engineProcess != null && !_engineProcess.HasExited)
                                {
                                    FlushDns();
                                    return true;
                                }
                            }
                        }

                        return false;
                    }

                    // Flush Windows DNS Cache so blocked sites are re-resolved through clean DNS
                    FlushDns();
                    return true;
                }
                catch (Exception ex)
                {
                    _lastEngineError = ex.Message;
                    return false;
                }
            });
        }

        private string GetEngineDirectory()
        {
            // 1. Önce exe'nin hemen yanındaki engine klasörüne bak
            string localEngine = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "engine");
            if (Directory.Exists(localEngine) && File.Exists(Path.Combine(localEngine, "goodbyedpi", "goodbyedpi.exe")))
            {
                return localEngine;
            }

            // 2. Exe tek başına taşındıysa %LOCALAPPDATA%\FlashWire\engine kullan
            string appDataEngine = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), 
                "FlashWire", 
                "engine");

            string testFile = Path.Combine(appDataEngine, "goodbyedpi", "goodbyedpi.exe");
            if (File.Exists(testFile))
            {
                return appDataEngine;
            }

            // 3. İçine gömülmüş (embedded) engine.zip arşivini otomatik çıkart
            try
            {
                if (!Directory.Exists(appDataEngine))
                {
                    Directory.CreateDirectory(appDataEngine);
                }

                var assembly = System.Reflection.Assembly.GetExecutingAssembly();
                Stream stream = assembly.GetManifestResourceStream("FlashWire.engine.zip");
                if (stream == null)
                {
                    stream = assembly.GetManifestResourceStream("SplitWireMini.engine.zip");
                }

                if (stream != null)
                {
                    using (stream)
                    using (var archive = new System.IO.Compression.ZipArchive(stream))
                    {
                        foreach (var entry in archive.Entries)
                        {
                            string completeFileName = Path.Combine(appDataEngine, entry.FullName);
                            string directory = Path.GetDirectoryName(completeFileName);
                            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                            {
                                Directory.CreateDirectory(directory);
                            }
                            if (!string.IsNullOrEmpty(entry.Name))
                            {
                                entry.ExtractToFile(completeFileName, true);
                            }
                        }
                    }
                }
            }
            catch { }

            return appDataEngine;
        }

        private void KillStaleProcesses()
        {
            try
            {
                RunHiddenCmd("taskkill /f /im goodbyedpi.exe /im winws.exe /im ciadpi.exe >nul 2>&1");
            }
            catch { }
        }

        private void CleanupEngine()
        {
            try
            {
                if (_engineProcess != null && !_engineProcess.HasExited)
                {
                    _engineProcess.Kill();
                    _engineProcess.Dispose();
                    _engineProcess = null;
                }
            }
            catch { }

            if (_isDnsChanged)
            {
                ResetSystemDns();
                _isDnsChanged = false;
            }

            KillStaleProcesses();
            FlushDns();
        }

        private void SetSystemDnsToAdGuard()
        {
            try
            {
                string cmd = "Get-NetAdapter | Where-Object { $_.Status -eq 'Up' -and $_.InterfaceDescription -notlike '*Virtual*' -and $_.InterfaceDescription -notlike '*Tailscale*' -and $_.InterfaceDescription -notlike '*Loopback*' -and $_.InterfaceDescription -notlike '*Hyper-V*' } | Set-DnsClientServerAddress -ServerAddresses ('94.140.14.14','1.1.1.1')";
                RunHiddenPowerShell(cmd);
            }
            catch { }
        }

        private void ResetSystemDns()
        {
            try
            {
                string cmd = "Get-NetAdapter | Where-Object { $_.Status -eq 'Up' -and $_.InterfaceDescription -notlike '*Virtual*' -and $_.InterfaceDescription -notlike '*Tailscale*' -and $_.InterfaceDescription -notlike '*Loopback*' -and $_.InterfaceDescription -notlike '*Hyper-V*' } | Set-DnsClientServerAddress -ResetServerAddresses";
                RunHiddenPowerShell(cmd);
            }
            catch { }
        }

        private void RunHiddenPowerShell(string command)
        {
            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = "-NoProfile -ExecutionPolicy Bypass -Command \"" + command + "\"",
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden
                };
                using (var p = Process.Start(psi))
                {
                    if (p != null)
                    {
                        p.WaitForExit(3000);
                    }
                }
            }
            catch { }
        }

        private void FlushDns()
        {
            try
            {
                RunHiddenCmd("ipconfig /flushdns >nul 2>&1");
            }
            catch { }
        }

        private void RunHiddenCmd(string command)
        {
            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/c " + command,
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden
                };
                using (var p = Process.Start(psi))
                {
                    if (p != null)
                    {
                        p.WaitForExit(2000);
                    }
                }
            }
            catch { }
        }

        // ==================== UI STATE UPDATERS ====================

        private void SetConnectingUI(string customText = "BAĞLANILIYOR...")
        {
            txtStatus.Text = customText;
            txtStatus.Foreground = _goldBrush;
            dotStatus.Fill = _goldBrush;
            badgeStatus.Background = _badgeGoldBg;
            badgeStatus.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#423512"));
            txtSubStatus.Text = "DPI kuralları ve DNS ayarlanıyor...";

            orbDropShadow.Color = (Color)ColorConverter.ConvertFromString("#FFB800");
            orbDropShadow.Opacity = 0.6;
            orbDropShadow.BlurRadius = 24;
            orbBorder.BorderBrush = _goldBrush;

            try
            {
                imgCenterLogo.Source = new BitmapImage(new Uri("pack://application:,,,/flashwire_gold.png"));
            }
            catch { }

            btnConnectText.Text = "LÜTFEN BEKLEYİN...";
        }

        private void SetConnectedUI()
        {
            txtStatus.Text = "● FLASHWIRE KORUMASI AKTİF";
            txtStatus.Foreground = _goldBrush;
            dotStatus.Fill = _goldBrush;
            badgeStatus.Background = _badgeGoldBg;
            badgeStatus.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#423512"));
            txtSubStatus.Text = "Discord, Roblox ve tüm servisler açık";

            // Glow and border in Cyberpunk Gold
            orbDropShadow.Color = (Color)ColorConverter.ConvertFromString("#FFB800");
            orbDropShadow.Opacity = 0.75;
            orbDropShadow.BlurRadius = 32;
            orbBorder.BorderBrush = _goldBrush;

            try
            {
                imgCenterLogo.Source = new BitmapImage(new Uri("pack://application:,,,/flashwire_gold.png"));
            }
            catch { }

            // Button switches to Crimson Red "BAĞLANTIYI KES"
            var redGradient = new LinearGradientBrush();
            redGradient.StartPoint = new Point(0, 0);
            redGradient.EndPoint = new Point(1, 0);
            redGradient.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#EF4444"), 0));
            redGradient.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#DC2626"), 1));

            btnConnectToggle.Background = redGradient;
            btnShadow.Color = (Color)ColorConverter.ConvertFromString("#EF4444");
            btnConnectText.Text = "BAĞLANTIYI KES";
            btnConnectText.Foreground = Brushes.White;
            btnIconPath.Fill = Brushes.White;
            btnIconPath.Data = Geometry.Parse("M19 6.41L17.59 5 12 10.59 6.41 5 5 6.41 10.59 12 5 17.59 6.41 19 12 13.41 17.59 19 19 17.59 13.41 12z");
        }

        private void SetDisconnectedUI(string statusMsg = "○ GÜVENLİK DEVRE DIŞI")
        {
            txtStatus.Text = statusMsg;
            txtStatus.Foreground = _redBrush;
            dotStatus.Fill = _redBrush;
            badgeStatus.Background = _badgeRedBg;
            badgeStatus.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3E1C22"));
            txtSubStatus.Text = "DPI ve DNS kalkanı şu anda devre dışı";

            // Reset glow and border to Subtle Red/Default
            orbDropShadow.Color = (Color)ColorConverter.ConvertFromString("#EF4444");
            orbDropShadow.Opacity = 0.35;
            orbDropShadow.BlurRadius = 24;
            orbBorder.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#242C3D"));

            try
            {
                imgCenterLogo.Source = new BitmapImage(new Uri("pack://application:,,,/flashwire_gold.png"));
            }
            catch { }

            // Button switches back to Gold "BAĞLAN"
            var goldGradient = new LinearGradientBrush();
            goldGradient.StartPoint = new Point(0, 0);
            goldGradient.EndPoint = new Point(1, 0);
            goldGradient.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FFB800"), 0));
            goldGradient.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#E0A200"), 1));

            btnConnectToggle.Background = goldGradient;
            btnShadow.Color = (Color)ColorConverter.ConvertFromString("#FFB800");
            btnConnectText.Text = "BAĞLAN";
            btnConnectText.Foreground = _darkTextBrush;
            btnIconPath.Fill = _darkTextBrush;
            btnIconPath.Data = Geometry.Parse("M13 2 L3 14 L12 14 L11 22 L21 10 L12 10 Z");
        }
    }
}
