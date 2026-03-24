namespace Wondwear.Application.Features.Bewohners.Queries.Get;

public record BewohnerGetRequest(int bewohnerId) :IRequest<Result>;
