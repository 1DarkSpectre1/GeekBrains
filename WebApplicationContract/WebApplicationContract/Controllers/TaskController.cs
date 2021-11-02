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
    public class TaskController : ControllerBase
    {
        private readonly ILogger<TaskController> _logger;
        private readonly TasksRepository _TasksRepository;
        public TaskController(ILogger<TaskController> logger, TasksRepository TasksRepository)
        {
            _logger = logger;
            _TasksRepository = TasksRepository;
        }
        [HttpGet("Tasks")]
        public async Task<IEnumerable<Tasks>> GetTasksById([FromRoute] int id)
        {
            return await _TasksRepository.GetTasksById(id);
        }

        [HttpGet("Tasks/search")]
        public async Task<IEnumerable<Tasks>> GetTasksByid_contract([FromRoute] int id)
        {
            return await _TasksRepository.GetTasksByid_contract(id);
        }
        [HttpPost("Tasks")]
        public async Task<int> PostTasks([FromBody] Tasks Tasks)
        {
            return await _TasksRepository.PostTasks(Tasks);
        }
        [HttpPut("Tasks")]
        public async Task<int> PutTasks([FromBody] Tasks Tasks)
        {
            return await _TasksRepository.PutTasks(Tasks);
        }
        [HttpDelete("Tasks")]
        public async Task<int> DeleteTask([FromRoute] int id)
        {
            return await _TasksRepository.DeleteTasks(id);
        }
    }
}
