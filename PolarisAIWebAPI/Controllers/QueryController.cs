using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Serilog;

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
            Log.Logger.Information($"API called, query was null.");
            return "Query is null";
        }

        // GET query/do that
        [HttpGet("{query}")]
        public ActionResult<JObject> GetQuery(string query)
        {
            Log.Logger.Information($"API called, query is: {query}");
            return PolarisAICore.PolarisAICore.Cognize(query);
        }
    }
}
