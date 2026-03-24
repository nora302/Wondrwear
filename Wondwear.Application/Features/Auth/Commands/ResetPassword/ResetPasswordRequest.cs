

namespace Wondwear.Application.Features.Auth.Commands.ResetPassword;

public record ResetPasswordRequest(int userId,string currentPassword,string newPassword):IRequest<Result>;


