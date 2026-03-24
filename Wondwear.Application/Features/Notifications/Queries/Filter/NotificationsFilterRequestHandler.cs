
using Wondwear.Application.Features.DTOs.Notifications;

namespace Wondwear.Application.Features.Notifications.Queries.Filter;

public class NotificationsFilterRequestHandler(AppDbContext context) : IRequestHandler<NotificationsFilterRequest, Result>
{
    private readonly AppDbContext _context = context;

    public async Task<Result> Handle(NotificationsFilterRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var notifications = await _context.Notifications
            .OrderByDescending(n=>n.CreatedAt)
            .Select(n => new NotificationFilterDTO
            (
                n.Id,
                n.Title,
                n.Body,
                n.CreatedAt
            ))
            .PaginateAsync(request.page,request.size);
            return new Result(notifications, Error.None);
        }
        catch (Exception ex)
        {
            return new Result(null, new Error("500", ex.Message));
        }
    }
}
