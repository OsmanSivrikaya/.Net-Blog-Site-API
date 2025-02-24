using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using MyBlogSite.Core.Enums;


namespace MyBlogSite.Core.Helpers;

public static class ClaimHelper
{
    private static IHttpContextAccessor _httpContextAccessor;

    /// <summary>
    /// Dependency Injection ile IHttpContextAccessor'ü set eder.
    /// </summary>
    public static void Configure(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    /// <summary>
    /// Kullanıcının UserId değerini GUID olarak alır.
    /// </summary>
    public static Guid GetUserId()
    {
        var userIdString = GetClaimValue("userId") 
                           ?? GetClaimValue(ClaimTypes.NameIdentifier) 
                           ?? GetClaimValue("sub");

        return Guid.TryParse(userIdString, out var userId) ? userId : Guid.Empty;
    }

    /// <summary>
    /// Kullanıcının rolünü `RoleEnum` olarak alır.
    /// </summary>
    public static RoleEnum GetUserRole()
    {
        var roleString = GetClaimValue(ClaimTypes.Role) ?? GetClaimValue("role");

        return Enum.TryParse(roleString, out RoleEnum role) ? role : RoleEnum.Moderator;
    }

    /// <summary>
    /// Genel claim okuma fonksiyonu.
    /// </summary>
    private static string GetClaimValue(string claimType)
    {
        var httpContext = _httpContextAccessor?.HttpContext;
        return httpContext?.User?.FindFirst(claimType)?.Value;
    }
}
