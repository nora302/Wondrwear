


namespace Wondwear.Application.Features.Admins.Commands.Create;

public record AdminCreateRequest(string userName,
                                    string password) : IRequest<Result>;
