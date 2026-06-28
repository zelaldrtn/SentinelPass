using System;
using Microsoft.Data.Sqlite;

namespace SentinelApp.CLI
{
    public class GuvenlikServisi
    {
        public static void LogEkle(string olayTipi, string aciklama)
        {
            using (var baglanti = Veritabani.BaglantiAl())
            {
                string sorgu = "INSERT INTO Loglar (Zaman, OlayTipi, Aciklama) VALUES (@zaman, @olay, @aciklama)";
                using (var komut = new SqliteCommand(sorgu, baglanti))
                {
                    komut.Parameters.AddWithValue("@zaman", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    komut.Parameters.AddWithValue("@olay", olayTipi);
                    komut.Parameters.AddWithValue("@aciklama", aciklama);
                    komut.ExecuteNonQuery();
                }
            }
        }

        public static bool BruteForceBlokajVarMi()
        {
            using (var baglanti = Veritabani.BaglantiAl())
            {
                string sorgu = "SELECT COUNT(*) FROM Loglar WHERE OlayTipi = 'GIRIS_BASARISIZ' AND Zaman > datetime('now', '-5 minutes', 'localtime')";
                using (var komut = new SqliteCommand(sorgu, baglanti))
                {
                    long hataliSayisi = Convert.ToInt64(komut.ExecuteScalar());
                    return hataliSayisi >= 3;
                }
            }
        }
    }
}