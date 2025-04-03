using Microsoft.AspNetCore.Mvc;
using TestApp.Application.Features.TestEntities;

namespace TestApp.API.Controllers
{
    [Route("[controller]")]
    public class TestEntityController : ApplicationController
    {
        [HttpGet("Entity")]

        public async Task<IActionResult> EntityList([FromServices] TestEntityHandler handler,
                                                    [FromQuery] TestRequest request,
                                                     CancellationToken ct)
        {

            var result = await handler.Handle(request, ct);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return Ok(result.Value);
        }
    }
}
