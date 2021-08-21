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
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private readonly ClientRepository _ClientRepository;
        public ClientController(ILogger<ClientController> logger, ClientRepository ClientsRepository)
        {
            _logger = logger;
            _ClientRepository = ClientsRepository;
        }
        [HttpGet("clients")]
        public async Task<IEnumerable<Client>> GetClientById([FromRoute] int id)
        {
            return await _ClientRepository.GetClientById(id);
        }

        [HttpGet("client/search")]
        public async Task<IEnumerable<Client>> GetClientByName([FromRoute] string name)
        {
            return await _ClientRepository.GetClientByName(name);
        }
        [HttpPost("client")]
        public async Task<int> PostClient([FromBody] Client Client)
        {
            return await _ClientRepository.PostClient(Client);
        }
        [HttpPut("client")]
        public async Task<int> PutClient([FromBody] Client Client)
        {
            return await _ClientRepository.PutClient(Client);
        }
        [HttpDelete("client")]
        public async Task<int> DeleteClient([FromRoute] int id)
        {
            return await _ClientRepository.DeleteClient(id);
        }
    }
}
