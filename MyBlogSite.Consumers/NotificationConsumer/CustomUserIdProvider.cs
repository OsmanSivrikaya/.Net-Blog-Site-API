using System.Security.Claims;
using Microsoft.AspNetCore.SignalR;

namespace NotificationConsumer;

/// <summary>
/// SignalR kullanıcı kimliğini belirlemek için özel bir `IUserIdProvider` implementasyonu.
/// Bu sınıf, kullanıcının JWT token'ında bulunan **NameIdentifier (UserId)** bilgisini alır ve kullanıcının kimliğini belirler.
/// </summary>
public class CustomUserIdProvider : IUserIdProvider
{
    /// <summary>
    /// Kullanıcının kimliğini almak için `Claims` verilerini okur.
    /// SignalR bağlantısı açıldığında, bu metod çağrılır ve kullanıcıya ait bir ID döndürülür.
    /// </summary>
    /// <param name="connection">SignalR bağlantı bağlamı</param>
    /// <returns>Kullanıcının ID'si (string olarak) veya null</returns>
    public string? GetUserId(HubConnectionContext connection)
    {
        // Kullanıcı bilgilerini içeren JWT token'ındaki "NameIdentifier" (UserId) claim'ini bul
        return connection.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        /*
         * ClaimTypes.NameIdentifier:
         * Kullanıcının kimlik bilgisini içeren claim (genellikle UserId olur).
         * Örneğin, JWT token içinde şu şekilde olabilir:
         * { "sub": "b7f9c2c4-d75e-4cd3-9d6c-df34e7e232b1" }
         *
         * Eğer kullanıcı giriş yapmamışsa veya token geçerli değilse `null` dönecektir.
         */
    }
}