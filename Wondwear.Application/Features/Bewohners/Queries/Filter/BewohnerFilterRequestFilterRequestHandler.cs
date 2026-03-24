


namespace Wondwear.Application.Features.Bewohners.Queries.Filter;

public class BewohnerFilterRequestFilterRequestHandler(AppDbContext context) : IRequestHandler<BewohnerFilterRequest, Result>
{
    private readonly AppDbContext _context = context;

    public async Task<Result> Handle(BewohnerFilterRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var bewhoners = await _context.Bewohners.AsNoTracking()
                                                    .Where(c => (request.userName == null || c.UserName.Contains(request.userName))
                                                          )
                                               .Select(c => new BewohnerFilterDTO(
                                                              c.Id,
                                                              c.UserName,
                                                              c.ZimmerNummer,
                                                              c.Cases.Any(cs => !cs.Done)
                                               ))
                                                .ToListAsync();
            return new Result(bewhoners, Error.None);
        }
        catch (Exception ex)
        {
            return new Result(null, new Error("500", ex.Message));
        }
    }
}

