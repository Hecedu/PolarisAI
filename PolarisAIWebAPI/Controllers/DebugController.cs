using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace PolarisAIWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DebugController : ControllerBase
    {

        // GET query
        [HttpGet]
        public ActionResult<string> Get()
        {
            Log.Logger.Debug("Debug: API called, query was null.");
            return "Query is null";
        }

        // GET debug/do that
        [HttpGet("{query}")]
        public ActionResult<string> GetDebug(string query)
        {
            Log.Logger.Debug($"Debug: API called, query is: {query}");
            return PolarisAICore.PolarisAICore.CognizeDebug(query);
        }
    }
}
