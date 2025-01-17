using System.Text;
using Microsoft.Extensions.Options;
using MyBlogSite.Core.Dtos.RabbitMQ;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

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

builder.Services.Configure<RabbitMqSettingDto>(configuration.GetSection("RabbitMQ"));

#region App

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/email-consumer", async (IOptions<RabbitMqSettingDto> rabbitMqOptions) =>
    {
        var rabbitMqSettings = rabbitMqOptions.Value;
        ConnectionFactory factory = new()
        {
            Uri = new Uri(rabbitMqSettings.Url)
        };

        await using IConnection connection = await factory.CreateConnectionAsync();
        await using IChannel channel = await connection.CreateChannelAsync();

        // Kuyruğu tanımlayın (varsa)
        await channel.QueueDeclareAsync(queue: "email-queue", durable: true, exclusive: false, autoDelete: false);

        AsyncEventingBasicConsumer consumer = new(channel);

        consumer.ReceivedAsync += async (sender, e) =>
        {
            try
            {
                var message = Encoding.UTF8.GetString(e.Body.Span);
                Console.WriteLine($"Received message: {message}");

                // Mesaj işlendi olarak işaretle
                await channel.BasicAckAsync(e.DeliveryTag, multiple: false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing message: {ex.Message}");
                // Gerekirse mesajı tekrar kuyruğa ekleyebilirsiniz
                await channel.BasicNackAsync(e.DeliveryTag, multiple: false, requeue: true);
            }
        };

        await channel.BasicConsumeAsync(queue: "example-1-queue", autoAck: false, consumer);
    });

app.Run();

#endregion