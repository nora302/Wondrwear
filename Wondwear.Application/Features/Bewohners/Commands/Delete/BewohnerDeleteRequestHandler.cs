



namespace Wondwear.Application.Features.Pflegers.Commands.Delete;

public class BewohnerDeleteRequestHandler(AppDbContext context) : IRequestHandler<BewohnerDeleteRequest, Result>
{
    private readonly AppDbContext _context = context;

    public async Task<Result> Handle(BewohnerDeleteRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var Bewohner = await _context.Bewohners.FirstOrDefaultAsync(a => a.Id == request.BewohnerId);
            if (Bewohner is null)
                return new Result(false, Error.UserNotFound);
            _context.Bewohners.Remove(Bewohner);
            await _context.SaveChangesAsync(cancellationToken);
            return new Result(true, Error.None);
        }
        catch (Exception ex)
        {
            return new Result(true, new Error("500", ex.Message));
        }
    }
}
