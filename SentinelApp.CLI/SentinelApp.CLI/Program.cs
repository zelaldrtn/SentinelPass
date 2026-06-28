using System;
using System.Text;

namespace SentinelApp.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "SentinelPass - Kripto Test Sürüşü";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==================================================");
            Console.WriteLine("     SENTINELPASS CRYPTO ENGINE INITIALIZED       ");
            Console.WriteLine("==================================================\n");

            // 1. Adım: Veritabanını Ayağa Kaldır
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("[*] Veritabanı tabloları kontrol ediliyor...");
            Veritabani.IlkKurulum();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[+] Veritabanı ve tablolar başarıyla hazırlandı!\n");

            // 2. Adım: Argon2id ile Ana Şifreden Anahtar Türetme
            Console.ForegroundColor = ConsoleColor.White;
            string testAnaSifre = "Zelal123!";
            Console.WriteLine($"[*] Giriş yapılan Ana Şifre: {testAnaSifre}");
            Console.WriteLine("[*] Argon2id algoritması çalıştırılıyor (Lütfen bekleyin)...");

            byte[] türetilenAnahtar = SifrelemeMotoru.AnahtarTuret(testAnaSifre);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[+] Anahtar başarıyla türetildi! Boyut: {türetilenAnahtar.Length} byte (AES-256 uyumlu)\n");

            // 3. Adım: AES-GCM ile Hassas Veri Şifreleme
            Console.ForegroundColor = ConsoleColor.White;
            string hamSifre = "BenimCokGizliInstagramSifrem123";
            Console.WriteLine($"[*] Şifrelenecek Ham Veri: {hamSifre}");

            var (sifreliMetin, nonce) = SifrelemeMotoru.Sifrele(hamSifre, türetilenAnahtar);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[+] AES-GCM Şifreli Hali (Base64): {sifreliMetin}");
            Console.WriteLine($"[+] Üretilen Benzersiz Nonce: {nonce}\n");

            // 4. Adım: Veriyi Geri Çözme
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("[*] Şifreli veri geri çözülüyor...");

            string cozulunMetin = SifrelemeMotoru.SifreCoz(sifreliMetin, nonce, türetilenAnahtar);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[+] Başarıyla Çözülen Orijinal Veri: {cozulunMetin}\n");

            // 5. Adım: Güvenlik Logu Ekleme
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("[*] Sisteme test logu yazılıyor...");
            GuvenlikServisi.LogEkle("TEST_CALISMASI", "Sistem ilk kez siyah ekranda başarıyla test edildi.");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[+] Log veritabanına işlendi!\n");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==================================================");
            Console.WriteLine("   TEST BAŞARIYLA TAMAMLANDI! ÇIKMAK İÇİN BASIN   ");
            Console.WriteLine("==================================================");
            Console.ReadLine();
        }
    }
}