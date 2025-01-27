using System.Text.RegularExpressions;

namespace MyBlogSite.Core.Constants;

public static class RegexConst
{
    public static readonly Regex PasswordRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");
}