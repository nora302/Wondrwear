
namespace Wondwear.Infrastructure.Services.Push;

public interface IPushService
{
    Task<bool> PushNotification(NotificationRequest notification);
}
