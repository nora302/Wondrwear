

namespace Wondwear.Api.Controllers.Admin;

[Route("api/admin/[controller]")]
[ApiController]
[Authorize(Roles=nameof(Roles.Admin))]
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
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] BewohnerCreateRequest request)
    {
        var result = await _mediator.Send(request);
        if (result.data is null)
            return BadRequest(result);
        return Ok(result);
    }
    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] BewohnerUpdateRequest request)
    {
        var result = await _mediator.Send(request);
        if (result.data is null)
            return BadRequest(result);
        return Ok(result);
    }
    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete([FromQuery] BewohnerDeleteRequest request)
    {
        var result = await _mediator.Send(request);
        if (result.data is null)
            return BadRequest(result);
        return Ok(result);
    }
}
