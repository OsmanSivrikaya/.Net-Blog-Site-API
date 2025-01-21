using MassTransit;
using MyBlogSite.Core.Dtos;
using MyBlogSite.Core.Producers.Interface;

namespace MailConsumer;

public class MailConsumer(IEmailProducer emailProducer) : IConsumer<EmailMessageDto>
{
    public async Task Consume(ConsumeContext<EmailMessageDto> context)
    {
       await emailProducer.SendEmailAsync(context.Message);
    }
}