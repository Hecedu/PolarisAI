using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Diagnostics;

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
            var timer = new Stopwatch();
            timer.Start();
            Log.Logger.Information($"POST: GetQuery called, query is: {query}");
            var result = PolarisAICore.PolarisAICore.CognizeDebug(query);
            timer.Stop();
            Log.Logger.Information($"POST: GetQuery executed in {timer.ElapsedMilliseconds}ms");
            return result;
        }
    }
}
