using System;
using Microsoft.Data.Sqlite;

namespace SentinelApp.CLI
{
    public class Veritabani
    {
        private const string BaglantiStringi = "Data Source=kasa.db;";

        public static void IlkKurulum()
        {
            using (var baglanti = new SqliteConnection(BaglantiStringi))
            {
                baglanti.Open();

                // Hesaplar Tablosu (AES-GCM için Nonce alanı şarttır)
                string hesaplarTablosu = @"
                    CREATE TABLE IF NOT EXISTS Hesaplar (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Platform TEXT NOT NULL,
                        KullaniciAdi TEXT NOT NULL,
                        SifreliParola TEXT NOT NULL,
                        Nonce TEXT NOT NULL
                    );";

    // Güvenlik Günlükleri (Audit Logs) Tablosu
    string loglarTablosu = @"
                    CREATE TABLE IF NOT EXISTS Loglar (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Zaman TEXT NOT NULL,
                        OlayTipi TEXT NOT NULL,
                        Aciklama TEXT NOT NULL
                    );";

                using (var komut = new SqliteCommand(hesaplarTablosu, baglanti)) { komut.ExecuteNonQuery(); }
using (var komut = new SqliteCommand(loglarTablosu, baglanti)) { komut.ExecuteNonQuery(); }
            }
        }

        public static SqliteConnection BaglantiAl()
{
    var baglanti = new SqliteConnection(BaglantiStringi);
    baglanti.Open();
    return baglanti;
}
    }
}