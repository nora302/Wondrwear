
namespace Wondwear.Application.Features.Pflegers.Queries.Filter;

public class PflegerFilterRequestFilterRequestHandler(AppDbContext context) : IRequestHandler<PflegerFilterRequest, Result>
{
    private readonly AppDbContext _context = context;

    public async Task<Result> Handle(PflegerFilterRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var Pflegers = await _context.Pflegers.Where(c => (request.userName == null || c.UserName.Contains(request.userName))
                                                          )
                                               .AsNoTracking()
                                               .Select(c => new PflegerFilterDTO(
                                                              c.Id,
                                                              c.UserName,
                                                              c.Email,
                                                              c.PhoneNumber,
                                                              c.Geburtsdatum,
                                                              c.Name,
                                                              c.NachName
                                               ))
                                               .PaginateAsync(request.page, request.size);

            return new Result(Pflegers, Error.None);
        }
        catch (Exception ex)
        {
            return new Result(null, new Error("500", ex.Message));
        }
    }
}

