# SentinelPass - Güvenli Kimlik ve Erişim Yönetimi Projesi

SentinelPass, modern siber güvenlik standartları ve kriptografik algoritmalar kullanılarak geliştirilmiş, askeri düzeyde şifreleme sunan masaüstü tabanlı bir parola yönetim ve güvenlik uygulamasıdır. Proje .NET 8.0 mimarisi üzerine inşa edilmiştir.

## Öne Çıkan Siber Güvenlik Özellikleri

* **Argon2id Anahtar Türetme:** Kullanıcının belirlediği Ana Şifre (Master Password), OWASP tavsiyelerine uygun olarak Argon2id algoritmasıyla işlenir ve AES-256 anahtarı türetilir.
* **AES-GCM ile Kimlik Doğrulamalı Şifreleme:** Kaydedilen tüm hassas veriler, veri bütünlüğünü garanti altına alan ve "Bit-Flipping" saldırılarını engelleyen **AES-GCM (Galois/Counter Mode)** yöntemi ile şifrelenir. Her kayıt için benzersiz bir `Nonce` üretilir.
* **SIEM Mantığında Audit Logging:** Sistemde gerçekleşen her başarılı veya başarısız giriş denemesi ile şifre ekleme olayları yerel SQLite veritabanına zaman damgasıyla (Timestamp) loglanır.
* **Kaba Kuvvet (Brute-Force) Koruması:** Son 5 dakika içerisinde 3 defa hatalı giriş denemesi algılandığında, güvenlik servisi otomatik olarak sistemi kilitleyerek Brute-Force saldırılarını engeller.
* **Gerçek Zamanlı Şifre Sağlığı Skoru:** Kullanıcı şifre üretirken; büyük harf, rakam, sembol ve uzunluk parametrelerini entropi formülüyle ölçen dinamik bir görsel bar içerir.

## Kullanılan Teknolojiler

* **C# / .NET 8.0** (Modern ve LTS Sürüm)
* **Windows Forms** (Koyu Tema & Minimalist Arayüz)
* **BouncyCastle.Cryptography** (Resmi Güvenli Kriptografi Kütüphanesi)
* **Microsoft.Data.Sqlite** (Parametrik & SQL Injection Korumalı Veritabanı)
