

namespace Wondwear.Application.Features.Auth.Commands.ResetPassword;

public class ResetPasswordRequestHandler(AppDbContext context,UserManager<User> manager) : IRequestHandler<ResetPasswordRequest, Result>
{
    private readonly AppDbContext _context = context;
    private readonly UserManager<User> _manager = manager;

    public async Task<Result> Handle(ResetPasswordRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id==request.userId);
            if (user is null)
                return new Result(false, Error.UserNotFound);

            var result = await _manager.ChangePasswordAsync(user, request.currentPassword, request.newPassword);
            if (result.Succeeded == false)
                return new Result(false, Error.WrongPassword);
            await _context.SaveChangesAsync(cancellationToken);
            return new Result(true, Error.None);

        }
        catch (Exception ex)
        {
            return new Result(false, new Error("500", ex.Message));
        }
    }
}


