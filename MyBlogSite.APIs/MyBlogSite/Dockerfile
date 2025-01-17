# .NET 8 SDK'sını içeren bir temel imaj kullan
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Proje dosyalarını kopyala
COPY . ./

# Bağımlılıkları yükle ve projeyi yayınla
RUN dotnet publish -c Release -o out

# .NET 8 ASP.NET Core runtime'ını içeren bir temel imaj kullan
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# Uygulamanı çalıştır
ENTRYPOINT ["dotnet", "MyBlogSite.dll"]