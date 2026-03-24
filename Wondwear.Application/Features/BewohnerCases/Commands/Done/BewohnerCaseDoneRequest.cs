

namespace Wondwear.Application.Features.BewohnerCases.Commands.Done;

public record BewohnerCaseDoneRequest(int caseId,int PflegerId,string? notes) : IRequest<Result>;
