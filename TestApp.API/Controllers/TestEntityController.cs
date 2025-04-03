using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
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

        [HttpPost("Entity")]
        public async Task<IActionResult> Add([FromServices] TestEntityHandler handler,
                                             TestRequest request,
                                             CancellationToken ct)
        {

            //var list = JsonConvert.DeserializeObject<IEnumerable<KeyValuePair<string, string>>>(jsonContent);
            //var dictionary = list.ToDictionary(x => x.Key, x => x.Value);


            var result = await handler.Handle(request, ct);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return Ok(result.Value);
        }


        [HttpPost]
        public async Task<IActionResult> Post(object[] objects)
        {
            //var requestContent = Request.Body.;
            //var jsonContent = await requestContent.ReadAsStringAsync();

            //var list = JsonConvert.DeserializeObject<IEnumerable<KeyValuePair<string, string>>>(content);

            List<Ett> ettList = new List<Ett>();

            foreach (var obj in objects)
            {
                string s = obj.ToString();

                s = s.Replace("\"", "").Replace("{", "").Replace("}", "");

                string[] sArr = s.Split(':');

                ettList.Add(new Ett() { Code = int.Parse(sArr[0]), Value = sArr[1].Trim() });
            }

            //ettList.Sort();

            //Ett[] aEtt = ettList.ToArray();

            //return Ok(aEtt);



            return Ok(ettList);
        }
    }


    public class Ett
    {
        public int Code { get; set; }
        public string Value { get; set; }
    }
}
