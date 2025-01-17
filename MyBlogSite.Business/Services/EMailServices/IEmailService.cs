namespace MyBlogSite.Business.Services.EmailServices;

public interface IEmailService
{
    Task SendEmailAsync(string email, string subject, string message);
    /// <summary>
    /// Gönderilen mail'ı kuyruğa ekler.
    /// </summary>
    /// <param name="email"></param>
    /// <param name="subject"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    Task SendEmailQueueAsync(string email, string subject, string message);
}