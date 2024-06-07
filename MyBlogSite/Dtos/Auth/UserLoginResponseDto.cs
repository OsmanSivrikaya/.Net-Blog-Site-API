namespace MyBlogSite.Dtos.Auth
{
    public class UserLoginResponseDto
    {
        public bool AuthenticateResult { get; set; }
        public string AuthToken { get; set; }
        public DateTime AccessTokenExpireDate { get; set; }
    }
}