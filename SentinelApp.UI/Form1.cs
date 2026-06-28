using System;
using System.IO;
using System.Windows.Forms;
// Bizim siber güvenlik motorumuzu buraya dahil ediyoruz:
using SentinelApp.CLI;


namespace SentinelApp.UI
{
    public partial class Form1 : Form
    {
        // Şifreyi kod içine gömmek yerine yerel bir dosyada veya DB'de hash olarak tutacağız.
        // Şimdilik projenin ilk açılışta şifre oluşturmasını sağlıyoruz.
        private const string SifreDosyaYolu = "master.key";
        public Form1()
        {
            InitializeComponent();
            Veritabani.IlkKurulum();
            txtAnaSifre.PasswordChar = '●'; // Şifrenin ekranda görünmesini engeller (Maskeleme)
            // Eğer daha önce şifre oluşturulmadıysa butonun yazısını değiştiriyoruz
            if (!File.Exists(SifreDosyaYolu))
            {
                btnGiris.Text = "İlk Şifreyi Oluştur";
            }
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAnaSifre.Text))
            {
                MessageBox.Show("Lütfen bir şifre girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. Brute-Force Kontrolü
            if (GuvenlikServisi.BruteForceBlokajVarMi())
            {
                MessageBox.Show("Çok fazla hatalı deneme! Sistem kilitlendi.", "SIEM BLOKAJI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. İlk Kurulum Modu (Şifre henüz belirlenmemişse)
            if (!File.Exists(SifreDosyaYolu))
            {
                // Girilen şifreyi basitçe dosyaya yazıyoruz (Normalde hashlenir, MVP için bu çok pratiktir)
                File.WriteAllText(SifreDosyaYolu, txtAnaSifre.Text);
                MessageBox.Show("Ana şifreniz başarıyla oluşturuldu! Şimdi bu şifreyle giriş yapabilirsiniz.", "SentinelPass", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnGiris.Text = "Giriş Yap";
                txtAnaSifre.Clear();
                return;
            }

            // 3. Giriş Kontrol Modu
            string kayitliSifre = File.ReadAllText(SifreDosyaYolu);

            if (txtAnaSifre.Text == kayitliSifre)
            {
                GuvenlikServisi.LogEkle("GIRIS_BASARILI", "Kullanıcı kasaya erişti.");
                byte[] guvenliAnahtar = SifrelemeMotoru.AnahtarTuret(txtAnaSifre.Text);

                AnaKasaForm anaKasa = new AnaKasaForm(guvenliAnahtar);
                this.Hide();
                anaKasa.ShowDialog();
                this.Close();
            }
            else
            {
                GuvenlikServisi.LogEkle("GIRIS_BASARISIZ", "Yetkisiz giriş denemesi!");
                MessageBox.Show("Ana Şifre Hatalı!", "GÜVENLİK UYARISI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
