using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Serilog;
using System.Diagnostics;

namespace PolarisAIWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QueryController : ControllerBase
    {

        // GET query
        [HttpGet]
        public ActionResult<string> Get()
        {
            Log.Logger.Information($"POST: Get called, query was null.");
            return "Query is null";
        }

        // GET query/do that
        [HttpGet("{query}")]
        public ActionResult<JObject> GetQuery(string query)
        {
            var timer = new Stopwatch();
            timer.Start();
            Log.Logger.Information($"POST: GetQuery called, query is: {query}");
            var result = PolarisAICore.PolarisAICore.Cognize(query);
            timer.Stop();
            Log.Logger.Information($"POST: GetQuery executed in {timer.ElapsedMilliseconds}ms");
            return result;
        }
    }
}
