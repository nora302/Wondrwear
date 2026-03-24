

namespace Wondwear.Api.Controllers.Admin;

[Route("api/admin/[controller]")]
[ApiController]
[Authorize(Roles = nameof(Roles.Admin))]
public class BewohnerCasesController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet("Filter")]
    public async Task<IActionResult> Filter([FromQuery] BewohnerCaseFilterRequest request)
    {
        var result = await _mediator.Send(request);
        if (result.data is null)
            return BadRequest(result);
        return Ok(result);
    }

    [HttpGet("report")]
    public async Task<IActionResult> Report([FromQuery] CasesReportRequest request)
    {
        var result = await _mediator.Send(request);
        if (result.data is null)
            return BadRequest(result);
        return Ok(result);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] BewohnerCaseCreateRequest request)
    {
        var result = await _mediator.Send(request);
        if (result.data is null)
            return BadRequest(result);
        return Ok(result);
    }
    [HttpPut("Done")]
    public async Task<IActionResult> Done([FromBody] BewohnerCaseDoneRequest request)
    {
        var result = await _mediator.Send(request);
        if (result.data is null)
            return BadRequest(result);
        return Ok(result);
    }
   
}
