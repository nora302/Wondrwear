
namespace Wondwear.Application.Features.Admins.Commands.Delete;

public class AdminDeleteRequestHandler(AppDbContext context) : IRequestHandler<AdminDeleteRequest, Result>

{
    private readonly AppDbContext _context = context;

    public async Task<Result> Handle(AdminDeleteRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var customer = await _context.Admins.FirstOrDefaultAsync(a => a.Id == request.adminId);
            if (customer is null)
                return new Result(false, Error.UserNotFound);
            _context.Admins.Remove(customer);
            await _context.SaveChangesAsync(cancellationToken);
            return new Result(true, Error.None);
        }
        catch (Exception ex)
        {
            return new Result(true, new Error("500", ex.Message));
        }
    }
}