


namespace Wondwear.Application.Features.Admins.Commands.Create;

public class AdminCreateRequestHandler(IUserRepository<User> users,
                                        AppDbContext context
                                         ) : IRequestHandler<AdminCreateRequest, Result>
{
    private readonly IUserRepository<User> _users = users;
    private readonly AppDbContext _context = context;

    public async Task<Result> Handle(AdminCreateRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var admin = new Admin
            (
                userName : request.userName
            );
            var result = await _users.AddWithRole(admin, Roles.Admin.ToString(), request.password);
            if (!result.Succeeded)
                return new Result(false, new Error("400", result.Errors.First().Description));

            return new Result(true, Error.None);
        }
        catch (Exception ex)
        {
            return new Result(false, new Error("500", ex.Message));
        }
    }
  
}