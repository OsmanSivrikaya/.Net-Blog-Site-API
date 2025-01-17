using MassTransit;
using MyBlogSite.Core.Dtos;
using MyBlogSite.Core.Producers.Interface;

namespace MailConsumer;

public class MailConsumer(IEmailProducer emailProducer) : IConsumer<EmailMessageDto>
{
    private readonly IEmailProducer _emailProducer = emailProducer;

    public async Task Consume(ConsumeContext<EmailMessageDto> context)
    {
       await _emailProducer.SendEmailAsync(context.Message);
    }
}