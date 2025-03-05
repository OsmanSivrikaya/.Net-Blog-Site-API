# 📌 Build aşaması için .NET SDK 8 kullan
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 📌 Proje dosyasını ve bağımlılıkları kopyala
COPY MyBlogSite.APIs/MyBlogSite/*.csproj MyBlogSite.APIs/MyBlogSite/
RUN dotnet restore MyBlogSite.APIs/MyBlogSite/MyBlogSite.csproj

# 📌 Kodları kopyala ve publish et
COPY . .
WORKDIR /src/MyBlogSite.APIs/MyBlogSite
RUN dotnet publish -c Release -o /app

# 📌 Runtime için .NET 8 kullan
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app . 

# 📌 Çalıştırma komutu
ENTRYPOINT ["dotnet", "MyBlogSite.dll"]
