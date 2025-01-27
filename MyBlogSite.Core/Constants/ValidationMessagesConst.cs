namespace MyBlogSite.Core.Constants
{
    public class ValidationMessagesConst
    {
        public const string RequiredMessage = "{PropertyName} zorunlu alandır.";
        public const string LengthMessage = "{PropertyName} {MinLength} ile {MaxLength} karakter arasında olmalı.";
        public const string PasswordApprove = "Şifre en az 8 karakter olmalı, bir büyük harf, bir küçük harf, bir rakam ve bir özel karakter içermelidir.";
    }
}
