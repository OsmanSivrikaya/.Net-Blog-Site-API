using Base.Configurations;
using MassTransit;
using Microsoft.AspNetCore.SignalR;
using MyBlogSite.Core.Dtos.Settings;
using NotificationConsumer;
using NotificationConsumer.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder
            .SetIsOriginAllowed(_ => true) 
            .AllowAnyMethod() // GET, POST, PUT, DELETE gibi tüm HTTP metodlarına izin ver
            .AllowAnyHeader() // Tüm header'lara izin ver
            .AllowCredentials() // Eğer SignalR ile Auth token gönderiyorsan ekleyebilirsin
    );
});

// derlendiği environment'i çekiyoruz
var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

// derlendiği environment'a göre configuration oluşturuyoruz
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

builder.Services.AddOpenApi();

// Authentication'u ekliyoruz
builder.Services.AddAuthenticationJWT(configuration);
// SignalR servisini ekliyoruz
builder.Services.AddSignalR(options =>
{
    options.EnableDetailedErrors = true; // Hata mesajlarını detaylı göster
});

builder.Services.AddSingleton<IUserIdProvider, CustomUserIdProvider>();

var rabbitMqSettings = configuration.GetSection("RabbitMQ").Get<RabbitMqSettingDto>();
if (rabbitMqSettings != null) builder.Services.AddMassTransitConsumers(rabbitMqSettings);

#region App

var app = builder.Build();

// RabbitMQ Consumer'ı elle başlat
var busControl = app.Services.GetRequiredService<IBusControl>();
await busControl.StartAsync();

//app.UseHttpsRedirection();

app.UseRouting();
app.UseCors("AllowAll"); // Burada CORS tanımlandı!
app.UseAuthenticationJWT();
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<NotificationHub>("/notificationHub");
});

app.Run();

#endregion