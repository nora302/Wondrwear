namespace Wondwear.Domain.Common;

public record NotificationRequest(List<string> fcmTokens, string Title, string Body);
