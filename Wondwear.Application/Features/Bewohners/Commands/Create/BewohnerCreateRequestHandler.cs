

namespace Wondwear.Application.Features.Bewohners.Commands.Create;

public class BewohnerCreateRequestHandler(IUserRepository<User> repo) : IRequestHandler<BewohnerCreateRequest, Result>
{
    private readonly IUserRepository<User> _repo = repo;

    public async Task<Result> Handle(BewohnerCreateRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var random = new Random();
            var Bewohner = new Bewohner
            (
                userName: request.userName,
                zimmernummer: request.zimmerNummer,
                telefonnummer: request.telefonnummer,
                geburtsdatum: request.geburtsdatum,
                einzugsdatum: request.einzugsdatum,
                name: request.name,
                nachName: request.nachName
            );
            var result = await _repo.AddWithRole(Bewohner, Roles.Bewohner.ToString(), request.password);

            if (!result.Succeeded)
                return new Result(false, new Error("400", result.Errors.First().Description));

            return new Result(true, Error.None);
        }
        catch (Exception ex)
        {
            return new Result(false, new Error("500", ex.Message));
        }
    }
}
