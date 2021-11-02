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
    public class ContractController : ControllerBase
    {
        private readonly ILogger<ContractController> _logger;
        private readonly ContractRepository _ContractRepository;
        public ContractController(ILogger<ContractController> logger, ContractRepository ContractsRepository)
        {
            _logger = logger;
            _ContractRepository = ContractsRepository;
        }
        [HttpGet("Contracts")]
        public async Task<IEnumerable<Contract>> GetContractById([FromRoute] int id)
        {
            return await _ContractRepository.GetContractById(id);
        }

        [HttpGet("Contract/search")]
        public async Task<IEnumerable<Contract>> GetContractsByid_client([FromRoute] int id)
        {
            return await _ContractRepository.GetContractsByid_client(id);
        }
        [HttpPost("Contract")]
        public async Task<int> PostContract([FromBody] Contract Contract)
        {
            return await _ContractRepository.PostContract(Contract);
        }
        [HttpPut("Contract")]
        public async Task<int> PutContract([FromBody] Contract Contract)
        {
            return await _ContractRepository.PutContract(Contract);
        }
        [HttpDelete("Contract")]
        public async Task<int> DeleteContract([FromRoute] int id)
        {
            return await _ContractRepository.DeleteContract(id);
        }
    }
}
