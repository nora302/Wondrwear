namespace Wondwear.Application.Features.BewohnerCases.Commands.Done;

public class BewohnerCaseDoneRequestHandler(AppDbContext context,
                                             IHubContext<AlertHub, IAlertHub> hub) : IRequestHandler<BewohnerCaseDoneRequest, Result>
{
    private readonly AppDbContext _context = context;
    private readonly IHubContext<AlertHub, IAlertHub> _hub = hub;

    public async Task<Result> Handle(BewohnerCaseDoneRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var BewohnerCase = await _context.Cases.FirstOrDefaultAsync(p => p.Id == request.caseId);
            if (BewohnerCase == null)
                return new Result(false, Error.NullValue);
            var Pfleger = await _context.Pflegers.FirstOrDefaultAsync(p => p.Id == request.PflegerId);
            if (Pfleger == null)
                return new Result(false, Error.NullValue);

            BewohnerCase.PflegerId = request.PflegerId;
            BewohnerCase.Done = true;
            BewohnerCase.Notes = request.notes;
            await _context.SaveChangesAsync(cancellationToken);
            await _hub.Clients.All.SendAlertDoneAsync(request.caseId,BewohnerCase.BewohnerId, Pfleger.UserName);
            return new Result(true, Error.None);
        }
        catch (Exception ex)
        {
            return new Result(false, new Error("500", ex.Message));
        }
    }
}
