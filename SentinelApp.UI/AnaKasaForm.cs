using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
using SentinelApp.CLI;

namespace SentinelApp.UI
{
    public partial class AnaKasaForm : Form
    {
        private byte[] _anahtar; // Girişte Argon2id ile türetilen güvenli anahtar
        public AnaKasaForm(byte[] anahtar)
        {
            InitializeComponent();
            _anahtar = anahtar;
            Listele();
        }
        // 1. Veritabanındaki Şifreli Verileri AES-GCM ile Çözerek Listeleme
        private void Listele()
        {
            dgvHesaplar.Rows.Clear();
            if (dgvHesaplar.Columns.Count == 0)
            {
                dgvHesaplar.Columns.Add("Id", "ID");
                dgvHesaplar.Columns.Add("Platform", "Platform / Site");
                dgvHesaplar.Columns.Add("User", "Kullanıcı Adı");
                dgvHesaplar.Columns.Add("Pass", "Şifre (Çözülmüş)");
            }

            using (var baglanti = Veritabani.BaglantiAl())
            {
                string sorgu = "SELECT * FROM Hesaplar";
                using (var komut = new SqliteCommand(sorgu, baglanti))
                using (var oku = komut.ExecuteReader())
                {
                    while (oku.Read())
                    {
                        // AES-GCM ile şifreyi çözüyoruz
                        string cozulmusSifre = SifrelemeMotoru.SifreCoz(
                            oku["SifreliParola"].ToString(),
                            oku["Nonce"].ToString(),
                            _anahtar
                        );

                        dgvHesaplar.Rows.Add(oku["Id"], oku["Platform"], oku["KullaniciAdi"], cozulmusSifre);
                    }
                }
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPlatform.Text) || string.IsNullOrEmpty(txtParola.Text))
            {
                MessageBox.Show("Lütfen Platform ve Parola alanlarını boş bırakmayın!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // AES-GCM kilit motorunu çağırıyoruz
            var (sifreliMetin, nonce) = SifrelemeMotoru.Sifrele(txtParola.Text, _anahtar);

            using (var baglanti = Veritabani.BaglantiAl())
            {
                string sorgu = "INSERT INTO Hesaplar (Platform, KullaniciAdi, SifreliParola, Nonce) VALUES (@p, @k, @s, @n)";
                using (var komut = new SqliteCommand(sorgu, baglanti))
                {
                    komut.Parameters.AddWithValue("@p", txtPlatform.Text);
                    komut.Parameters.AddWithValue("@k", txtKullaniciAdi.Text);
                    komut.Parameters.AddWithValue("@s", sifreliMetin);
                    komut.Parameters.AddWithValue("@n", nonce);
                    komut.ExecuteNonQuery();
                }
            }

            GuvenlikServisi.LogEkle("SIFRE_EKLEME", $"{txtPlatform.Text} platformu için yeni bir veri şifrelenerek kaydedildi.");

            // Metin kutularını temizle ve listeyi yenile
            txtPlatform.Clear();
            txtKullaniciAdi.Clear();
            txtParola.Clear();
            pbSifreGucu.Value = 0;

            Listele();
            MessageBox.Show("Veri askeri düzeyde AES-GCM ile şifrelenerek kaydedildi!", "SentinelPass", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtParola_TextChanged(object sender, EventArgs e)
        {
            string sifre = txtParola.Text;
            int skor = 0;

            if (sifre.Length >= 8) skor += 25; // Uzunluk denetimi
            if (System.Text.RegularExpressions.Regex.IsMatch(sifre, @"[A-Z]")) skor += 25; // Büyük harf denetimi
            if (System.Text.RegularExpressions.Regex.IsMatch(sifre, @"[0-9]")) skor += 25; // Rakam denetimi
            if (System.Text.RegularExpressions.Regex.IsMatch(sifre, @"[\W_]")) skor += 25; // Özel karakter/Sembol denetimi

            pbSifreGucu.Value = skor; // ProgressBar'ı doldur

            // Şifre gücüne göre ProgressBar rengini dinamik değiştirme (CV puanı artırır)
            if (skor < 50) pbSifreGucu.ForeColor = System.Drawing.Color.Red;
            else if (skor < 100) pbSifreGucu.ForeColor = System.Drawing.Color.Orange;
            else pbSifreGucu.ForeColor = System.Drawing.Color.Green;
        }
    }
}
