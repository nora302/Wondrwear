namespace Wondwear.Application.Features.Bewohners.Queries.Get;

public class BewohnerGetRequestHandler(AppDbContext context) : IRequestHandler<BewohnerGetRequest, Result>
{
    private readonly AppDbContext _context = context;

    public async Task<Result> Handle(BewohnerGetRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var Bewohner = await _context.Bewohners.AsNoTracking()
                                                    .Where(b=>b.Id == request.bewohnerId)
                                                    .Select(c => new BewohnerGetDTO(
                                                                                    c.Id,
                                                                                    c.UserName,
                                                                                    c.ZimmerNummer,
                                                                                    c.Name,
                                                                                    c.NachName,
                                                                                    c.Geburtsdatum,
                                                                                    c.Einzugsdatum,
                                                                                    c.PhoneNumber
                                                                                            ))
                                                    .FirstOrDefaultAsync();

            if (Bewohner is null)
                return new Result(null, Error.NullValue);

            return new Result(Bewohner, Error.None);
        }
        catch (Exception ex)
        {
            return new Result(null, new Error("500", ex.Message));
        }
    }
}
