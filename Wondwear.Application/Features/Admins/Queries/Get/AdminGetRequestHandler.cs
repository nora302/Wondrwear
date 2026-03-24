


namespace Wondwear.Application.Features.Customers.Queries.Get;

public class AdminGetRequestHandler(AppDbContext context) : IRequestHandler<AdminGetRequest, Result>
{
    private readonly AppDbContext _context = context;

    public async Task<Result> Handle(AdminGetRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var admin = await _context.Admins.Select(c => new AdminGetDTO(
                                                            c.Id,
                                                            c.UserName
                                                        ))
                .FirstOrDefaultAsync(c => c.Id == request.adminId);
                                                        
            if (admin is null)
                return new Result(null, Error.NullValue);

            return new Result(admin, Error.None);
        }
        catch (Exception ex)
        {
            return new Result(null, new Error("500", ex.Message));
        }
    }
}

