

namespace Wondwear.Application.Hubs;

[Authorize]
public class AlertHub() : Hub<IAlertHub>
{
    public override async Task OnConnectedAsync()
    {
        if (string.IsNullOrEmpty(Context.UserIdentifier))
        {
            throw new HubException("User not authenticated");
        }
        var userId = int.Parse(Context.UserIdentifier);

        // Add user to their personal group
        await Groups.AddToGroupAsync(Context.ConnectionId, $"user-{userId}");

        await base.OnConnectedAsync();
    }

}