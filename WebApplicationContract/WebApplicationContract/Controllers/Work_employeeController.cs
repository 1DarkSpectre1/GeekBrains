using datalayer.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationContract_GB_.Entitys;

namespace WebApplicationContract.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Work_employeeController : ControllerBase
    {
        private readonly ILogger<Work_employeeController> _logger;
        private readonly Work_employeeRepository _Work_employeeRepository;
        public Work_employeeController(ILogger<Work_employeeController> logger, Work_employeeRepository Work_employeeRepository)
        {
            _logger = logger;
            _Work_employeeRepository = Work_employeeRepository;
        }
        [HttpGet("Work_employees")]
        public async Task<IEnumerable<Work_employee>> GetWork_employeeById([FromRoute] int id)
        {
            return await _Work_employeeRepository.GetWork_employeeById(id);
        }
        [HttpGet("Work_employees/by/employee")]
        public async Task<IEnumerable<Work_employee>> GetWork_employeeByid_employee([FromRoute] int id)
        {
            return await _Work_employeeRepository.GetWork_employeeByid_employee(id);
        }
        [HttpGet("Work_employees/by/task")]
        public async Task<IEnumerable<Work_employee>> GetWork_employeeByid_task([FromRoute] int id)
        {
            return await _Work_employeeRepository.GetWork_employeeByid_task(id);
        }
        [HttpPost("Work_employee")]
        public async Task<int> PostWork_employee([FromBody] Work_employee Work_employee)
        {
            return await _Work_employeeRepository.PostWork_employee(Work_employee);
        }
        [HttpPut("Work_employee")]
        public async Task<int> PutWork_employee([FromBody] Work_employee Work_employee)
        {
            return await _Work_employeeRepository.PutWork_employee(Work_employee);
        }
        [HttpDelete("Work_employee")]
        public async Task<int> DeleteWork_employee([FromRoute] int id)
        {
            return await _Work_employeeRepository.DeleteWork_employee(id);
        }
    }
}
