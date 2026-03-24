

namespace Wondwear.Api.Controllers.Pfleger;

[Route("api/Pfleger/[controller]")]
[ApiController]
[Authorize(Roles = nameof(Roles.Pfleger))]
public class PflegersController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet("Get")]
    public async Task<IActionResult> Get([FromQuery] PflegerGetRequest request)
    {
        var result = await _mediator.Send(request);
        if (result.data is null)
            return BadRequest(result);
        return Ok(result);
    }
   
    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] PflegerUpdateRequest request)
    {
        var result = await _mediator.Send(request);
        if (result.data is null)
            return BadRequest(result);
        return Ok(result);
    }
    
}
