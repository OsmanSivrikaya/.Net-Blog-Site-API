using System.Net;
using System.Net.Mail;
using MassTransit;
using Microsoft.Extensions.Options;
using MyBlogSite.Core.Dtos;
using MyBlogSite.Core.Dtos.Settings;
using MyBlogSite.Core.Producers.Interface;

namespace MyBlogSite.Core.Producers;

public class EmailProducer(ISendEndpointProvider sendEndpointProvider, IOptions<RabbitMqSettingDto> rabbitMqSettings)
    : IEmailProducer
{
    private readonly RabbitMqSettingDto _rabbitMqSettings = rabbitMqSettings.Value;
    public async Task SendEmailAsync(EmailMessageDto message)
    {
        var fromEmail = "deneme@gmail.com"; // Gönderen e-posta adresi
        var fromPassword = "password"; // App Password

        var smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(fromEmail, fromPassword),
            EnableSsl = true,
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress(fromEmail),
            Subject = message.Subject,
            Body = message.Body,
            IsBodyHtml = true,
        };

        // Alıcı e-posta adreslerini ekliyoruz
        foreach (var toEmail in message.ToEmails)
        {
            mailMessage.To.Add(toEmail);
        }

        try
        {
            await Task.Run(() => smtpClient.Send(mailMessage)); 
        }
        catch (Exception ex)
        {
            Console.WriteLine($"E-posta gönderme hatası: {ex.Message}");
        }
    }
    
    public async Task SendEmailQueueAsync(EmailMessageDto message)
    {
        try
        {
            var sendPoint = await sendEndpointProvider.GetSendEndpoint(new Uri($"queue:{_rabbitMqSettings.MailQueueKey}"));
            await sendPoint.Send(message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}