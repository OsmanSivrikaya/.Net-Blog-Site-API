namespace MyBlogSite.Core.Dtos.ProducerDtos;

public class EmailMessageDto
{
    public List<string> ToEmails  { get; set; } = new List<string>();
    public string Subject { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
}