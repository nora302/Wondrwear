namespace Wondwear.Application.Features.Pflegers.Queries.Get;

public record PflegerGetRequest(int PflegerId):IRequest<Result>;
