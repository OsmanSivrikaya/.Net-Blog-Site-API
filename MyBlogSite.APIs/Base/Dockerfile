# Base API Dockerfile'ı
FROM mcr.microsoft.com/dotnet/sdk:8.0 as base
WORKDIR /app
EXPOSE 5000

COPY . . 

WORKDIR /app/MyBlogSite.APIs/Base

RUN dotnet restore

RUN dotnet publish --no-restore -c Release -o /app/Base

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

FROM runtime AS final
WORKDIR /app
COPY --from=base /app/Base .

ENTRYPOINT ["dotnet", "Base.dll"]