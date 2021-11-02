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
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly EmployeeRepository _EmployeeRepository;
        public EmployeeController(ILogger<EmployeeController> logger, EmployeeRepository EmployeesRepository)
        {
            _logger = logger;
            _EmployeeRepository = EmployeesRepository;
        }
        [HttpGet("Employees")]
        public async Task<IEnumerable<Employee>> GetEmployeeById([FromRoute] int id)
        {
            return await _EmployeeRepository.GetEmployeeById(id);
        }

        [HttpGet("Employee/search")]
        public async Task<IEnumerable<Employee>> GetEmployeeByName([FromRoute] string name)
        {
            return await _EmployeeRepository.GetEmployeeByName(name);
        }
        [HttpPost("Employee")]
        public async Task<int> PostEmployee([FromBody] Employee Employee)
        {
            return await _EmployeeRepository.PostEmployee(Employee);
        }
        [HttpPut("Employee")]
        public async Task<int> PutEmployee([FromBody] Employee Employee)
        {
            return await _EmployeeRepository.PutEmployee(Employee);
        }
        [HttpDelete("Employee")]
        public async Task<int> DeleteEmployee([FromRoute] int id)
        {
            return await _EmployeeRepository.DeleteEmployee(id);
        }
    }
}
