using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using TestApp.Application.Features.TestEntities;
using TestApp.Infrastructure.Queries.TestEntities.GetTestEntity.GetAll;

namespace TestApp.API.Controllers
{
    [Route("[controller]")]
    public class TestEntityController : ApplicationController
    {
        

        [HttpPost("Entity")]
        public async Task<IActionResult> Add([FromServices] TestEntityHandler handler,
                                             object[] objects,
                                             CancellationToken ct)
        {

            
            var result = await handler.Handle(objects, ct);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return Ok(result.Value);
        }


        [HttpGet("Entities")]
        public async Task<IActionResult> GetAll([FromServices] GetEntitiesQuery query,
                                                 CancellationToken ct)
        {
            var result = await query.Handle(ct);
            //var list = JsonConvert.DeserializeObject<IEnumerable<KeyValuePair<string, string>>>(jsonContent);
            //var dictionary = list.ToDictionary(x => x.Key, x => x.Value);

         if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return Ok(result.Value);
        }

    }


    
}
