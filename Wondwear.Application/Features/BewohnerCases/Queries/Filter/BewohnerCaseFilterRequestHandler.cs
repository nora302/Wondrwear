

namespace Wondwear.Application.Features.BewohnerCases.Queries.Filter;

public class BewohnerCaseFilterRequestHandler(AppDbContext context) : IRequestHandler<BewohnerCaseFilterRequest, Result>
{
    private readonly AppDbContext _context = context;

    public async Task<Result> Handle(BewohnerCaseFilterRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var cases = await _context.Cases .AsNoTracking()
                                               .OrderByDescending(c=>c.Id)
                                               .Select(c => new
                                               {
                                                   c.Id,
                                                   Bewohner=c.Bewohner.UserName,
                                                   Pfleger=(c.Pfleger!=null)?c.Pfleger.UserName:null,
                                                   c.Done,
                                                   c.CreatedAt
                                               })
                                               .PaginateAsync(request.page, request.size);
            return new Result(cases, Error.None);
        }
        catch (Exception ex)
        {
            return new Result(null, new Error("500", ex.Message));
        }
    }
}
