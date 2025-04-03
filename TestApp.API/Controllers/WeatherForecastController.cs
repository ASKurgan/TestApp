using Microsoft.AspNetCore.Mvc;
using TestApp.Application.Features.TestEntities;

namespace TestApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }




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
            //var pcResult = await handler.Handle(request, ct);

            //if (pcResult.IsFailure)
            //{
            //    return BadRequest(pcResult.Error);
            //}

            //var pcResponse = pcResult.Value;

            return Ok(result.Value);
        }

        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}
