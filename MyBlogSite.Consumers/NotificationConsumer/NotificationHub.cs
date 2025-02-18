using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace NotificationConsumer;

/// <summary>
/// Kullanıcılara bildirim gönderen SignalR Hub.
/// </summary>
[Authorize]
public class NotificationHub : Hub
{
    /// <summary>
    /// Kullanıcıya özel bildirim gönderme metodu.
    /// </summary>
    public async Task SendNotificationToUser(string userId, string message)
    {
        await Clients.User(userId).SendAsync("ReceiveNotification", message);
    }
}