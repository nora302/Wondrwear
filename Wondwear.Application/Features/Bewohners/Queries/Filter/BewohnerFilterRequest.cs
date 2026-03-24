


namespace Wondwear.Application.Features.Bewohners.Queries.Filter;

public record BewohnerFilterRequest(string? userName,
                                    int page,
                                    int size) : IRequest<Result>;
