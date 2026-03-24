

namespace Wondwear.Application.Features.Pflegers.Commands.Update;

public class PflegerUpdateRequestHandler(AppDbContext context) : IRequestHandler<PflegerUpdateRequest, Result>
{
    private readonly AppDbContext _context = context;

    public async Task<Result> Handle(PflegerUpdateRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var Pfleger = await _context.Pflegers.FirstOrDefaultAsync(u => u.Id == request.PflegerId);
            if (Pfleger is null)
                return new Result(null, Error.NullValue);
            if (_context.Users.Any(u => u.NormalizedUserName == request.userName.ToUpper()))
                return new Result(false, Error.UserNameExist);
            Pfleger.UserName = request.userName;
            Pfleger.Email = request.email;
            Pfleger.PhoneNumber = request.telefonnummber;
            Pfleger.Geburtsdatum = request.geburtsdatum;
            Pfleger.NachName = request.nachName;
            Pfleger.Name = request.name;

            await _context.SaveChangesAsync(cancellationToken);
            return new Result(true, Error.None);
        }
        catch (Exception ex)
        {
            return new Result(false, new Error("500", ex.Message));
        }
    }
}
