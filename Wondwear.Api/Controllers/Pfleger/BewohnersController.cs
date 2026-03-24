

namespace Wondwear.Api.Controllers.Pfleger;

[Route("api/Pfleger/[controller]")]
[ApiController]
[Authorize(Roles=nameof(Roles.Pfleger))]
public class BewohnersController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet("Filter")]
    public async Task<IActionResult> Filter([FromQuery] BewohnerFilterRequest request)
    {
        var result = await _mediator.Send(request);
        if (result.data is null)
            return BadRequest(result);
        return Ok(result);
    }
    [HttpGet("Get")]
    public async Task<IActionResult> Get( [FromQuery] BewohnerGetRequest request)
    {
        var result = await _mediator.Send(request);
        if (result.data is null)
            return BadRequest(result);
        return Ok(result);
    }
}
