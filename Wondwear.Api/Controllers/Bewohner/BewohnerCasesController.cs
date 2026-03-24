

namespace Wondwear.Api.Controllers.Bewohner;

[Route("api/Bewohner/[controller]")]
[ApiController]
[Authorize(Roles = nameof(Roles.Bewohner))]
public class BewohnerCasesController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] BewohnerCaseCreateRequest request)
    {
        var result = await _mediator.Send(request);
        if (result.data is null)
            return BadRequest(result);
        return Ok(result);
    }
}
