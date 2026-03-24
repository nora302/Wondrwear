
using Wondwear.Application.Features.Notifications.Queries.Filter;

namespace Wondwear.Api.Controllers.Public;

[Route("api/public/[controller]")]
[ApiController]
[AllowAnonymous]
[EnableRateLimiting("auth")]
public class NotificationsController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;


    [HttpPost("Filter")]
    public async Task<IActionResult> Filter([FromQuery] NotificationsFilterRequest request)
    {
        var result = await _mediator.Send(request);
        if (result.data is null)
            return BadRequest(result);
        return Ok(result);
    }


}
