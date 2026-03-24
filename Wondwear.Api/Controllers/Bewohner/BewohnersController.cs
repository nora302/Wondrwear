

namespace Wondwear.Api.Controllers.Bewohner;

[Route("api/Bewohner/[controller]")]
[ApiController]
[Authorize(Roles=nameof(Roles.Bewohner))]
public class BewohnersController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;


    [HttpGet("Get")]
    public async Task<IActionResult> Get( [FromQuery] BewohnerGetRequest request)
    {
        var result = await _mediator.Send(request);
        if (result.data is null)
            return BadRequest(result);
        return Ok(result);
    }
    
}
