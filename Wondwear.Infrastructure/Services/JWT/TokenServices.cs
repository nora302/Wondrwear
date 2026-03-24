

namespace Wondwear.Infrastructure.Services.JWT;

public class TokenServices(
    IJwtProvider jwtProvider
)
{
    private readonly IJwtProvider _jwtProvider = jwtProvider;

    public async Task<TokenResponse> GenerateToken(
        User user,
        List<string> roles,
        CancellationToken cancellationToken
    )
    {
        var Token = _jwtProvider.Generate(user, roles);


        return new TokenResponse(
            new JwtSecurityTokenHandler().WriteToken(Token)
        );
    }
}