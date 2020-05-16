using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FastBin_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextController : ControllerBase
    {
        // GET: api/text/id
        [HttpGet("{id}", Name = "GetText")]
        public IActionResult Get(string id)
        {
            var snippet = Program.dbClient.RetrieveText(id, "text");
            if (snippet == null)
                return new NotFoundObjectResult($"Could not locate text with id {id}");
            else return new OkObjectResult(snippet.Text);
        }

        // POST: api/text/id
        [HttpPost("{id}", Name = "PostText")]
        public ActionResult Post(string id)
        {
            string data = new StreamReader(Request.Body).ReadToEndAsync().Result;
            var finalId = Program.dbClient.InsertText(new Database.TextSnippet(id, data), "text");
            return new OkObjectResult(finalId);
        }
    }
}
