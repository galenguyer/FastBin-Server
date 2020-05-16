using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace FastBin_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RawController : ControllerBase
    {
        // GET: api/text/id
        [HttpGet("{id}", Name = "GetRaw")]
        public IActionResult Get(string id)
        {
            var snippet = Program.dbClient.RetrieveText(id, "raw");
            if (snippet == null)
                return new NotFoundObjectResult($"Could not locate raw text with id {id}");
            else return new OkObjectResult(snippet.Text);
        }

        // POST: api/text/id
        [HttpPost("{id}", Name = "PostRaw")]
        public ActionResult Post(string id)
        {
            string data = new StreamReader(Request.Body).ReadToEndAsync().Result;
            var finalId = Program.dbClient.InsertText(new Database.TextSnippet(id, data), "raw");
            return new OkObjectResult(finalId);
        }
    }
}
