
namespace Wondwear.Application.Features.Customers.Queries.Filter;

public class AdminFilterRequestHandler(AppDbContext context) : IRequestHandler<AdminFilterRequest, Result>
{
    private readonly AppDbContext _context = context;

    public async Task<Result> Handle(AdminFilterRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var admins = await _context.Admins.Where(c => (request.userName == null || c.UserName.Contains(request.userName))
                                                          )
                                               .AsNoTracking()
                                               .Select(c => new AdminFilterDTO(
                                                              c.Id,
                                                              c.UserName
                                               ))
                                               .PaginateAsync(request.page, request.size);

            return new Result(admins, Error.None);
        }
        catch (Exception ex)
        {
            return new Result(null, new Error("500", ex.Message));
        }
    }
}

