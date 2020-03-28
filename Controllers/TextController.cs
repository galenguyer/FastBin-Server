using System;
using System.Collections.Generic;
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
        [HttpGet("{id}", Name = "Get")]
        public string Get(string id)
        {
            return "value: " + id;
        }

        // POST: api/text
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
