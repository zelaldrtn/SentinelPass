using System;
using System.Text;
using System.Security.Cryptography;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;

namespace SentinelApp.CLI
{
    public class SifrelemeMotoru
    {
        private static readonly byte[] SabitSalt = Encoding.UTF8.GetBytes("SentinelPassSalt123!");

        public static byte[] AnahtarTuret(string anaSifre)
        {
            byte[] anaSifreByte = Encoding.UTF8.GetBytes(anaSifre);

            // Yeni kütüphanede Argon2id doğrudan bu parametrelerle ayağa kalkar
            var kaynakParametreleri = new Argon2Parameters.Builder(Argon2Parameters.Argon2id)
                .WithMemoryAsKB(32768)
                .WithIterations(2)
                .WithParallelism(1)
                .WithSalt(SabitSalt)
                .Build();

            var generator = new Argon2BytesGenerator();
            generator.Init(kaynakParametreleri);

            // Yeni versiyonda çıktı boyutu GenerateBytes fonksiyonunun içine yazılmaz,
            // Önce bir byte dizisi açılır ve fonksiyon o diziyi doldurur.
            byte[] türetilenAnahtar = new byte[32]; // AES-256 için 32 byte
            generator.GenerateBytes(anaSifreByte, türetilenAnahtar, 0, türetilenAnahtar.Length);

            return türetilenAnahtar;
        }

        public static (string SifreliMetin, string Nonce) Sifrele(string temizMetin, byte[] anahtar)
        {
            byte[] temizByte = Encoding.UTF8.GetBytes(temizMetin);
            byte[] nonce = new byte[AesGcm.NonceByteSizes.MaxSize];
            RandomNumberGenerator.Fill(nonce);

            byte[] sifreliByte = new byte[temizByte.Length];
            byte[] tag = new byte[AesGcm.TagByteSizes.MaxSize];

            using (var aesGcm = new AesGcm(anahtar, tag.Length))
            {
                aesGcm.Encrypt(nonce, temizByte, sifreliByte, tag);
            }

            string tamamlanmisSifre = Convert.ToBase64String(sifreliByte) + ":" + Convert.ToBase64String(tag);
            return (tamamlanmisSifre, Convert.ToBase64String(nonce));
        }

        public static string SifreCoz(string sifreliParola, string nonceStr, byte[] anahtar)
        {
            try
            {
                string[] parcalar = sifreliParola.Split(':');
                byte[] sifreliByte = Convert.FromBase64String(parcalar[0]);
                byte[] tag = Convert.FromBase64String(parcalar[1]);
                byte[] nonce = Convert.FromBase64String(nonceStr);

                byte[] cozulenByte = new byte[sifreliByte.Length];

                using (var aesGcm = new AesGcm(anahtar, tag.Length))
                {
                    aesGcm.Decrypt(nonce, sifreliByte, tag, cozulenByte);
                }

                return Encoding.UTF8.GetString(cozulenByte);
            }
            catch
            {
                return "ERR:Şifre Çözülemedi!";
            }
        }
    }
}