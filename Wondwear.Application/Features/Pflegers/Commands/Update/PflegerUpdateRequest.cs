

namespace Wondwear.Application.Features.Pflegers.Commands.Update;

public record PflegerUpdateRequest(int PflegerId,string userName, string email, string telefonnummber, DateTime geburtsdatum, string name, string nachName) :IRequest<Result>;
