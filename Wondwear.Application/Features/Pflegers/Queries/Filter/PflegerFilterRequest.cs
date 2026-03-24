


namespace Wondwear.Application.Features.Pflegers.Queries.Filter;

public record PflegerFilterRequest(string? userName,
                                    int page,
                                    int size) : IRequest<Result>;
