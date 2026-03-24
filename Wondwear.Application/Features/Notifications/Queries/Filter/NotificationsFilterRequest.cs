

namespace Wondwear.Application.Features.Notifications.Queries.Filter;

public record NotificationsFilterRequest( int page = 1, int size = 10) : IRequest<Result>;
