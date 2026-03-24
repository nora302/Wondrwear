namespace Wondwear.Infrastructure.Services.Push;

public class PushService : IPushService
{
    public async Task<bool> PushNotification(NotificationRequest notification)
    {
        var not = new FirebaseAdmin.Messaging.Notification
        {
            Title = notification.Title,
            Body = notification.Body,
        };
        var msgData = new Dictionary<string, string?>
        {
            { "title", notification.Title },
            { "body", notification.Body }
        };
        var message = new MulticastMessage
        {
            Android = new AndroidConfig
            {
                TimeToLive = TimeSpan.FromDays(7),
                Priority = Priority.High,
                Notification = new AndroidNotification { Sound = "default" },
            },
            Tokens = notification.fcmTokens,
            Notification = not,
            Data = msgData,
        };
        BatchResponse response;
        try
        {
            response = await FirebaseMessaging.DefaultInstance.SendEachForMulticastAsync(message);
        }

        catch
        {
            return false;
        }
        if (response.FailureCount > 0)
        {
            return false;
        }

        return true;
    }



}
