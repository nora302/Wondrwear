
namespace Wondwear.Application.Features.Admins.Commands.Delete;

public record AdminDeleteRequest(int adminId) : IRequest<Result>;
