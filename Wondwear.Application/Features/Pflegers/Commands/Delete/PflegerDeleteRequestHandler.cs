



namespace Wondwear.Application.Features.Pflegers.Commands.Delete;

public class PflegerDeleteRequestHandler(AppDbContext context) : IRequestHandler<PflegerDeleteRequest, Result>
{
    private readonly AppDbContext _context = context;

    public async Task<Result> Handle(PflegerDeleteRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var Pfleger = await _context.Pflegers.FirstOrDefaultAsync(a => a.Id == request.PflegerId);
            if (Pfleger is null)
                return new Result(false, Error.UserNotFound);
            _context.Pflegers.Remove(Pfleger);
            await _context.SaveChangesAsync(cancellationToken);
            return new Result(true, Error.None);
        }
        catch (Exception ex)
        {
            return new Result(true, new Error("500", ex.Message));
        }
    }
}
