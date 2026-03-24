namespace Wondwear.Api.Controllers.Public;

[Route("api/public/[controller]")]
[ApiController]
[AllowAnonymous]
[EnableRateLimiting("auth")]
public class AuthController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;


    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var result = await _mediator.Send(request);
        if (result.data is null)
            return BadRequest(result);
        return Ok(result);
    }
    

    [HttpPut("ResetPassword")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
    {
        var result = await _mediator.Send(request);
        if (result.data is false)
            return BadRequest(result);
        return Ok(result);
    }
   
    
}
