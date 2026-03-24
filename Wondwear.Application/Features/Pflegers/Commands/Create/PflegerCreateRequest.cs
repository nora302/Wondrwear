

namespace Wondwear.Application.Features.Pflegers.Commands.Create;

public record PflegerCreateRequest(string userName,string password, string email, string telefonnummber, DateTime geburtsdatum, string name, string nachName) :IRequest<Result>;
