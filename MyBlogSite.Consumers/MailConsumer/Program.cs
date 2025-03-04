using MailConsumer;
using MailConsumer.Configurations;
using MassTransit;
using MyBlogSite.Core.Dtos.Settings;
using MyBlogSite.Core.Producers;
using MyBlogSite.Core.Producers.Interface;

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
builder.Services.AddScoped<IEmailProducer, EmailProducer>();

var mailSettings = configuration.GetSection("MAIL_CONNECTION");
builder.Services.Configure<MailSettings>(mailSettings);

var rabbitMqSettings = configuration.GetSection("RabbitMQ").Get<RabbitMqSettingDto>();
if (rabbitMqSettings != null) builder.Services.AddMassTransitConsumers(rabbitMqSettings);

#region App

var app = builder.Build();
// RabbitMQ Consumer'ı elle başlat
var busControl = app.Services.GetRequiredService<IBusControl>();
await busControl.StartAsync();

//app.UseHttpsRedirection();

app.Run();

#endregion