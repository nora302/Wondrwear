namespace Wondwear.Application.Features.Pflegers.Queries.Get;

public class PflegerGetRequestHandler(AppDbContext context) : IRequestHandler<PflegerGetRequest, Result>
{
    private readonly AppDbContext _context = context;

    public async Task<Result> Handle(PflegerGetRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var pfleger = await _context.Pflegers.Select(c => new PflegerGetDTO(
                                                            c.Id,
                                                            c.UserName,
                                                            c.Email,
                                                            c.PhoneNumber,
                                                            c.Geburtsdatum,
                                                            c.Name,
                                                            c.NachName
                                                        ))
                .FirstOrDefaultAsync(c => c.Id == request.PflegerId);

            if (pfleger is null)
                return new Result(null, Error.NullValue);

            return new Result(pfleger, Error.None);
        }
        catch (Exception ex)
        {
            return new Result(null, new Error("500", ex.Message));
        }
    }
}
