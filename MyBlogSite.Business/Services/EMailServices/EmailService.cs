using System.Text;
using System.Text.Json;
using MyBlogSite.Core.Dtos.RabbitMQ;
using Microsoft.Extensions.Options;
using MyBlogSite.Core.Dtos;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;

namespace MyBlogSite.Business.Services.EmailServices;

public class EmailService : IEmailService
{
    private IConnection? _connection;
    private IChannel? _channel;
    private readonly string _queueName = "email-queue";
    private readonly RabbitMqSettingDto _rabbitMqSetting;

    public EmailService(IOptions<RabbitMqSettingDto> rabbitMqSetting)
    {
        _rabbitMqSetting = rabbitMqSetting.Value;
    }

    public async Task SendEmailAsync(string email, string subject, string message)
    {
        ConnectionFactory factory = new()
        {
            Uri = new Uri(_rabbitMqSetting.Url)
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

        await channel.BasicConsumeAsync(queue: "email-queue", autoAck: false, consumer);
    }

    public async Task SendEmailQueueAsync(string email, string subject, string message)
    {
        // RabbitMQ bağlantısı ve kanalının doğruluğunu kontrol et
        await EnsureConnectionAsync();

        var emailMessage = new EmailMessageDto
        {
            To = email,
            Subject = subject,
            Body = message
        };

        string jsonMessage = JsonSerializer.Serialize(emailMessage);
        byte[] messageBody = Encoding.UTF8.GetBytes(jsonMessage);

        try
        {
            await _channel.BasicPublishAsync(exchange: "", routingKey: _queueName, body: messageBody);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Bir hata oluştu: {ex.Message}");
            // TODO: loglama eklenecek
        }
    }
    
    /// <summary>
    /// RabbitMqConnection olur
    /// </summary>
    private async Task EnsureConnectionAsync()
    {
        if (_connection == null || !_connection.IsOpen)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri(_rabbitMqSetting.Url)
            };

            _connection = await factory.CreateConnectionAsync();
            _channel = await _connection.CreateChannelAsync();

            // Kuyruğu bir kez oluşturun
            await _channel.QueueDeclareAsync(queue: _queueName, durable: true, exclusive: false, autoDelete: false);
        }
    }
    // Uygulama sonlandığında bağlantıyı kapatabilirsiniz (isteğe bağlı)
    public async Task Dispose()
    {
        await _channel?.CloseAsync()!;
        await _connection?.CloseAsync()!;
    }
}