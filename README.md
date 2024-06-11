# 🚀 Blog Sitesi API - .NET 8
Dikkat!! Proje daha geliştirme aşamasındadır.
🥇 Bu proje, .NET 8 kullanılarak geliştirilen, blog gönderilerini yönetmenizi sağlayan bir API'dir. Proje geliştirme aşamasında olup, yeni özellikler eklenmekte ve mevcut özellikler iyileştirilmektedir.

## İçindekiler
- [Teknoloji](#teknoloji)
- [Mimari](#mimari)
- [Özellikler](#özellikler)
- [Kurulum](#kurulum)

## Teknoloji
- ASP.NET Core 8
- Entity Framework Core 8
- JWT Authentication
- JWT'yi Şifreleme (JWE) ile Güvence Altına Alma
- Exception Handling Kullanarak İstisna Yönetimi
- Autofac Kullanarak Bağımlılık Enjeksiyonu (IoC Container)
- Async/Await Best Practices
- Versioning Management
- Using Swagger (Swashbuckle)
- Auto Document Generator for Swagger
- Integrate Swagger and Versioning
- Integrate Swagger and JWT/OAuth Authentication
- AutoMapper
- FluentValidator
- Swagger UI
- SQL Server

## Mimari
- SOLID Principles
- Clean Code
- Unit of Work
- Domain Validations
- Event Sourcing
- Repository Pattern
- Resut Pattern

## Özellikler
- Şuanda Api geliştirme aşamasında

## Kurulum

### Adımlar
1. Bu projeyi klonlayın:
    ```bash
    git clone https://github.com/OsmanSivrikaya/AspNetCore-Blog-Site-Backend.git
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
    dotnet run --launch-profile "Development" --BASE_URL="http://localhost" --PORT="7071" --SQL_CONNECTION="YOUR_CONNECTION_STRING"
    ```

API artık `http://localhost:7071` adresinde çalışıyor olmalı.
