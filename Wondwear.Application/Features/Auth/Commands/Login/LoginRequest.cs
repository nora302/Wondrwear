namespace Wondwear.Application.Features.Auth.Commands.Login;

public record LoginRequest(string userName, string password, string? fcmToken) : IRequest<Result>;
