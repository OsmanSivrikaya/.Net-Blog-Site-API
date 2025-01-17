using MyBlogSite.Core.Dtos;

namespace MyBlogSite.Core.Producers.Interface;

public interface IEmailProducer
{
    Task SendEmailAsync(EmailMessageDto message);
    Task SendEmailQueueAsync(EmailMessageDto message);
}