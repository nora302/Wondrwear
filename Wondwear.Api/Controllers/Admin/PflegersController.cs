

namespace Wondwear.Api.Controllers.Admin;

[Route("api/admin/[controller]")]
[ApiController]
[Authorize(Roles = nameof(Roles.Admin))]
public class PflegersController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet("Filter")]
    public async Task<IActionResult> Filter([FromQuery] PflegerFilterRequest request)
    {
        var result = await _mediator.Send(request);
        if (result.data is null)
            return BadRequest(result);
        return Ok(result);
    }
    [HttpGet("Get")]
    public async Task<IActionResult> Get([FromQuery] PflegerGetRequest request)
    {
        var result = await _mediator.Send(request);
        if (result.data is null)
            return BadRequest(result);
        return Ok(result);
    }
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] PflegerCreateRequest request)
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
    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete([FromQuery] PflegerDeleteRequest request)
    {
        var result = await _mediator.Send(request);
        if (result.data is null)
            return BadRequest(result);
        return Ok(result);
    }
}
