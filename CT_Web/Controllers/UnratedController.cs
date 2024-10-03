using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CT_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnratedController : ControllerBase
    {
        // GET: api/<UnratedController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UnratedController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UnratedController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UnratedController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UnratedController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
