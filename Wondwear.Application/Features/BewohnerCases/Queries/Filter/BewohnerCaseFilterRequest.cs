

namespace Wondwear.Application.Features.BewohnerCases.Queries.Filter;

public record BewohnerCaseFilterRequest(int page=1,int size=10):IRequest<Result>;
