using MyBlogSite.Core.Dtos;
using MyBlogSite.Core.Dtos.ProducerDtos;

namespace MyBlogSite.Core.Producers.Interface;

public interface IEmailProducer
{
    Task SendEmailAsync(EmailMessageDto message);
    Task SendEmailQueueAsync(EmailMessageDto message);
}