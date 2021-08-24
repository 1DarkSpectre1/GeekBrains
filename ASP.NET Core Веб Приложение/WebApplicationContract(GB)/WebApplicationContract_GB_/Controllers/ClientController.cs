using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationContract_GB_.Entitys;
using WebApplicationContract_GB_.Response;

namespace WebApplicationContract_GB_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly ILogger<ClientController> _logger;

        public ClientController(ILogger<ClientController> logger)
        {
            _logger = logger;
        }
        [HttpGet()]
        public ResponseClient Get()
        {

            return new ResponseClient() { Id = 12, FirstName = "asd" };
        }

        [HttpGet("clients")]
        public IActionResult GetPersonById([FromRoute] int id)
        {
            //var result = await _personsService.GetPersonById(id);
            //return result.Select(r => new ResponseClient() { Id = r.Id, FirstName = r.FirstName }).ToArray();
            return Ok();
        }

        [HttpGet("client/search")]
        public IActionResult GetPersonByName([FromRoute] string name)
        {
            //var result = await _personsService.GetPersonByName(name);
            //return result.Select(r => new ResponseClient() { Id = r.Id, FirstName = r.FirstName }).ToArray(); ;
            return Ok();
        }
        [HttpPost("client")]
        public IActionResult PostPerson([FromBody] Client person)
        {
           // _personsService.PostPerson(person);
            return Ok();
        }
        [HttpPut("client")]
        public IActionResult PutPerson([FromBody] Client person)
        {
            //_personsService.PutPerson(person);
            return Ok();
        }
        [HttpDelete("client")]
        public IActionResult DeletePerson([FromRoute] int id)
        {
            //_personsService.DeletePerson(id);
            return Ok();
        }

    }
}
