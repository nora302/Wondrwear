
namespace Wondwear.Application.Features.Auth.Commands.Login;

public class LoginRequestHandler(UserManager<User> manager,
                                 TokenServices tokenServices,
                                 AppDbContext context) : IRequestHandler<LoginRequest, Result>
{
    private readonly UserManager<User> _manager = manager;
    private readonly TokenServices _tokenService = tokenServices;
    private readonly AppDbContext _contxt = context;

    public async Task<Result> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        try
        {

            var user = await _contxt.Users.FirstOrDefaultAsync(u => u.NormalizedUserName.Equals(request.userName.ToUpper()));

            if (user is null)
                return new Result(null, Error.UserNotFound);

            var isPasswordMatch = await _manager.CheckPasswordAsync(user, request.password);

            if (!isPasswordMatch)
                return new Result(null, Error.WrongPassword);

            var roles = await _manager.GetRolesAsync(user);
            var response = await _tokenService.GenerateToken(user, roles.ToList(), cancellationToken);
            user.FcmToken = request.fcmToken;
            await _contxt.SaveChangesAsync(cancellationToken);
            return new Result(response, Error.None);

        }
        catch (Exception ex)
        {
            return new Result(null, new Error("500", ex.Message));
        }
    }
}