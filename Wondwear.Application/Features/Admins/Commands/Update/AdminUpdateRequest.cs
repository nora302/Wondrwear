


namespace Wondwear.Application.Features.Admins.Commands.Update;

public record AdminUpdateRequest(int adminId,
                                    string userName) : IRequest<Result>;
