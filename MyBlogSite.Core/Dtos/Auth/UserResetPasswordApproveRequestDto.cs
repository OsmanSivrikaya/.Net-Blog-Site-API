namespace MyBlogSite.Core.Dtos.Auth;

public class UserResetPasswordApproveRequestDto
{
    public string Email { get; set; } = string.Empty;
    public string Pass1 { get; set; } = string.Empty;
    public string Pass2 { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
}