# Temel imaj olarak .NET SDK kullan
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Çalışma dizinini ayarla
WORKDIR /app

# Proje dosyasını kopyala ve bağımlılıkları yükle
COPY *.csproj ./
RUN dotnet restore

# Uygulamayı derle
COPY . ./
RUN dotnet publish -c Release -o /out

# Çalıştırma için temel imaj olarak .NET Runtime kullans
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# Çalışma dizinini ayarlan
WORKDIR /app

# Yayınlanan dosyaları kopyalad
COPY --from=build /out .

# Uygulamayı çalıştırs
ENTRYPOINT ["dotnet", "Admin.dll"]