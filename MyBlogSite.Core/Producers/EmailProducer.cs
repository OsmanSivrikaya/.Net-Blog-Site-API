using System.Net;
using System.Net.Mail;
using MassTransit;
using Microsoft.Extensions.Options;
using MyBlogSite.Core.Dtos;
using MyBlogSite.Core.Dtos.Settings;
using MyBlogSite.Core.Producers.Interface;

namespace MyBlogSite.Core.Producers;

public class EmailProducer(ISendEndpointProvider sendEndpointProvider, 
                           IOptions<RabbitMqSettingDto> rabbitMqSettings,
                           IOptions<MailSettings> mailSettings)
    : IEmailProducer
{
    private readonly RabbitMqSettingDto _rabbitMqSettings = rabbitMqSettings.Value;
    private readonly MailSettings _mailSettings = mailSettings.Value;
    public async Task SendEmailAsync(EmailMessageDto message)
    {
        var smtpClient = new SmtpClient
        {
            Host = _mailSettings.Host,
            Port = _mailSettings.Port,
            Credentials = new NetworkCredential(_mailSettings.Mail, _mailSettings.AppPass),
            EnableSsl = _mailSettings.IsSsl,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false 
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress(_mailSettings.Mail, "Blog Sitesi"),
            Subject = message.Subject,
            Body = message.Body,
            IsBodyHtml = true,
        };
        
        message.ToEmails.ForEach(x=> mailMessage.To.Add(x));
        
        try
        {
            await smtpClient.SendMailAsync(mailMessage, CancellationToken.None); 
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