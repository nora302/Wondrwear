


namespace Wondwear.Api.Controllers.Pfleger;

[Route("api/Pfleger/[controller]")]
[ApiController]
[Authorize(Roles = nameof(Roles.Pfleger))]
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
    [HttpPut("Done")]
    public async Task<IActionResult> Done([FromBody] BewohnerCaseDoneRequest request)
    {
        var result = await _mediator.Send(request);
        if (result.data is null)
            return BadRequest(result);
        return Ok(result);
    }
   
}
