

namespace Wondwear.Application.Features.Bewohners.Commands.Update;

public class BewohnerUpdateRequestHandler(AppDbContext context) : IRequestHandler<BewohnerUpdateRequest, Result>
{
    private readonly AppDbContext _context = context;

    public async Task<Result> Handle(BewohnerUpdateRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var Bewohner = await _context.Bewohners.FirstOrDefaultAsync(u => u.Id == request.BewohnerId);
            if (Bewohner is null)
                return new Result(null, Error.NullValue);
            if(request.userName is not null )
            {
                if (_context.Users.Any(u => u.NormalizedUserName == request.userName.ToUpper()))
                    return new Result(false, Error.UserNameExist);
                Bewohner.UserName = request.userName;
            }
            Bewohner.ZimmerNummer= request.ZimmerNummer;
            Bewohner.PhoneNumber= request.telefonnummer;
            Bewohner.Geburtsdatum= request.geburtsdatum;
            Bewohner.Einzugsdatum= request.einzugsdatum;
            Bewohner.Name= request.name;
            Bewohner.NachName = request.nachName;
            await _context.SaveChangesAsync(cancellationToken);
            return new Result(true, Error.None);
        }
        catch (Exception ex)
        {
            return new Result(false, new Error("500", ex.Message));
        }
    }
}
