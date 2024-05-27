# Blog Sitesi API - .NET 8

Bu proje, .NET 8 kullanılarak geliştirilen, blog gönderilerini yönetmenizi sağlayan bir API'dir. Proje geliştirme aşamasında olup, yeni özellikler eklenmekte ve mevcut özellikler iyileştirilmektedir.

## İçindekiler
- [Özellikler](#özellikler)
- [Kurulum](#kurulum)
- [Kullanım](#kullanım)
- [Geliştirme Notları](#geliştirme-notları)
- [API Dökümantasyonu](#api-dökümantasyonu)
- [Katkıda Bulunma](#katkıda-bulunma)
- [Lisans](#lisans)

## Özellikler
- Blog gönderisi oluşturma
- Blog gönderisi okuma
- Blog gönderisi güncelleme
- Blog gönderisi silme
- Kullanıcı kimlik doğrulama (JWT)
- Yorum ekleme ve yönetme (geliştirme aşamasında)
- Kategori ekleme ve yönetme (geliştirme aşamasında)

## Kurulum
### Gereksinimler
- .NET 8 SDK
- SQL Server veya başka bir veritabanı yönetim sistemi
- Postman veya benzeri bir API test aracı

### Adımlar
1. Bu projeyi klonlayın:
    ```bash
    git clone https://github.com/kullanici_adi/blog-api.git
    cd blog-api
    ```

2. Gerekli bağımlılıkları yükleyin:
    ```bash
    dotnet restore
    ```

3. Veritabanını güncelleyin:
    ```bash
    dotnet ef database update
    ```

4. API'yi çalıştırın:
    ```bash
    dotnet run
    ```

API artık `https://localhost:5001` adresinde çalışıyor olmalı.
