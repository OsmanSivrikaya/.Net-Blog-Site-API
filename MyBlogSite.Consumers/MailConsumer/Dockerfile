# 📌 Build aşaması için .NET SDK 9 kullan
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# 📌 Proje dosyasını ve bağımlılıkları kopyala
COPY MyBlogSite.Consumers/MailConsumer/*.csproj MyBlogSite.Consumers/MailConsumer/
RUN dotnet restore MyBlogSite.Consumers/MailConsumer/MailConsumer.csproj

# 📌 Kodları kopyala ve publish et
COPY . .
WORKDIR /src/MyBlogSite.Consumers/MailConsumer
RUN dotnet publish -c Release -o /app

# 📌 Runtime için .NET 9 kullan
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app . 

# 📌 Çalıştırma komutu
ENTRYPOINT ["dotnet", "MailConsumer.dll"]
