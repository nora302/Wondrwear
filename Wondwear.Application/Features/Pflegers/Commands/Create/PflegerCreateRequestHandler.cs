

namespace Wondwear.Application.Features.Pflegers.Commands.Create;

public class PflegerCreateRequestHandler(IUserRepository<User> repo,AppDbContext context) : IRequestHandler<PflegerCreateRequest, Result>
{
    private readonly IUserRepository<User> _repo = repo;
    private readonly AppDbContext _context = context;

    public async Task<Result> Handle(PflegerCreateRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var Pfleger = new Pfleger
            (
                userName: request.userName,
                email:request.email,
                telefonnummber:request.telefonnummber,
                geburtsdatum:request.geburtsdatum,
                name:request.name,
                nachName:request.nachName
            );
            var result = await _repo.AddWithRole(Pfleger, Roles.Pfleger.ToString(), request.password);
            if (!result.Succeeded)
                return new Result(false, new Error("400", result.Errors.First().Description));

            await _context.SaveChangesAsync(cancellationToken);
            return new Result(true, Error.None);
        }
        catch (Exception ex)
        {
            return new Result(false, new Error("500", ex.Message));
        }
    }
}
