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
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }
        [HttpGet()]
        public ResponseEmployee Get()
        {

            return new ResponseEmployee() { Id = 12, FirstName = "asd" };
        }

        [HttpGet("employees")]
        public IActionResult GetPersonById([FromRoute] int id)
        {
            //var result = await _personsService.GetPersonById(id);
            //return result.Select(r => new ResponseClient() { Id = r.Id, FirstName = r.FirstName }).ToArray();
            return Ok();
        }

        [HttpGet("employee/search")]
        public IActionResult GetPersonByName([FromRoute] string name)
        {
            //var result = await _personsService.GetPersonByName(name);
            //return result.Select(r => new ResponseClient() { Id = r.Id, FirstName = r.FirstName }).ToArray(); ;
            return Ok();
        }
        [HttpPost("employee")]
        public IActionResult PostPerson([FromBody] Employee person)
        {
            // _personsService.PostPerson(person);
            return Ok();
        }
        [HttpPut("employee")]
        public IActionResult PutPerson([FromBody] Employee person)
        {
            //_personsService.PutPerson(person);
            return Ok();
        }
        [HttpDelete("employee")]
        public IActionResult DeletePerson([FromRoute] int id)
        {
            //_personsService.DeletePerson(id);
            return Ok();
        }

    }
}

