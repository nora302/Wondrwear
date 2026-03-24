

namespace Wondwear.Application.Features.BewohnerCases.Queries.Report;
public class CasesReportRequestHandler(AppDbContext context) : IRequestHandler<CasesReportRequest, Result>
{
    private readonly AppDbContext _context = context;

    public async Task<Result> Handle(CasesReportRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var cases = await _context.Cases.AsNoTracking()
                                               .Where(c => (request.Date != null && c.CreatedAt.Date==request.Date.Value.Date) || c.CreatedAt.Date==DateTime.UtcNow.Date )
                                               .Select(c => new
                                               {
                                                   c.Id,
                                                   Bewohner = c.Bewohner.UserName,
                                                   Pfleger = (c.Pfleger != null) ? c.Pfleger.UserName : null,
                                                   c.Done,
                                                   c.CreatedAt,
                                                   c.Notes
                                               })
                                               .ToListAsync();
            return new Result(cases, Error.None);
        }
        catch (Exception ex)
        {
            return new Result(null, new Error("500", ex.Message));
        }
    }
}

