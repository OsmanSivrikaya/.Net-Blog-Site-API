namespace MyBlogSite.Core.Dtos.Auth;

public class ResetPasswordTokenDto
{
    public string Email { get; set; }
    public DateTime Date { get; set; }
}