using Microsoft.AspNetCore.SignalR;
using MyBlogSite.Core.Dtos.Settings;
using NotificationConsumer;
using NotificationConsumer.Configurations;

var builder = WebApplication.CreateBuilder(args);

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
builder.Services.AddSingleton<IUserIdProvider, CustomUserIdProvider>();

var rabbitMqSettings = configuration.GetSection("RabbitMQ").Get<RabbitMqSettingDto>();
if (rabbitMqSettings != null) builder.Services.AddMassTransitConsumers(rabbitMqSettings);

#region App

var app = builder.Build();

app.UseHttpsRedirection();

app.Run();

#endregion