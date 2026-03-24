


namespace Wondwear.Application.Features.Customers.Queries.Filter;

public record AdminFilterRequest(string? userName,
                                    int page,
                                    int size) : IRequest<Result>;
