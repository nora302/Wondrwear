



namespace Wondwear.Application.Features.BewohnerCases.Commands.Create;

public class BewohnerCaseCreateRequestHandler(AppDbContext context, 
                                             IHubContext<AlertHub, IAlertHub> hub,
                                             IPushService pushService) : IRequestHandler<BewohnerCaseCreateRequest, Result>
{
    private readonly AppDbContext _context = context;
    private readonly IHubContext<AlertHub, IAlertHub> _hub = hub;
    private readonly IPushService _pushService = pushService;

    public async Task<Result> Handle(BewohnerCaseCreateRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var Bewohner = await _context.Bewohners.FirstOrDefaultAsync(p => p.Id == request.BewohnerId);
            if(Bewohner == null) 
                return new Result(false,Error.NullValue);

            var BewohnerCase = new BewohnerCase
            (
                bewohnerId: request.BewohnerId
            );
            await _context.Cases.AddAsync(BewohnerCase);


            var users = await _context.Users.Select(n => new
            {
                n.Id,
                n.FcmToken
            }).ToListAsync();
            var notifications = new List<Notification>();
            foreach (var user in users)
            {
                notifications.Add(new Notification("Der Bewohner braucht Hilfe", $"Bewohner {Bewohner.UserName} im ZimmerNummer {Bewohner.ZimmerNummer} benötigt Hilfe",user.Id));
            }
            _context.Notifications.AddRange(notifications);


            await _context.SaveChangesAsync(cancellationToken);
            await _pushService.PushNotification(new NotificationRequest(users.Where(u=>u.FcmToken != null).Select(u=>u.FcmToken).ToList(), "Der Bewohner braucht Hilfe", $"Bewohner {Bewohner.UserName} im ZimmerNummer {Bewohner.ZimmerNummer} benötigt Hilfe" ));
            await _hub.Clients.All.SendAlertAsync(BewohnerCase.Id,Bewohner.Id,Bewohner.UserName,Bewohner.ZimmerNummer);
            return new Result(true, Error.None);
        }
        catch (Exception ex)
        {
            return new Result(false, new Error("500", ex.Message));
        }
    }
}
