


namespace Wondwear.Application.Features.Admins.Commands.Update;

public class AdminUpdateRequestHandler(AppDbContext context) : IRequestHandler<AdminUpdateRequest, Result>
{
    private readonly AppDbContext _context = context;

    public async Task<Result> Handle(AdminUpdateRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var admin = await _context.Admins .FirstOrDefaultAsync(u => u.Id == request.adminId);
            if (admin is null)
                return new Result(null, Error.NullValue);
            if(_context.Users.Any(u => u.NormalizedUserName == request.userName.ToUpper()))
                return new Result(false, Error.UserNameExist);  
            admin.UserName = request.userName;
            await _context.SaveChangesAsync(cancellationToken);
            return new Result(true, Error.None);
        }
        catch (Exception ex)
        {
            return new Result(false, new Error("500", ex.Message));
        }
    }
}
