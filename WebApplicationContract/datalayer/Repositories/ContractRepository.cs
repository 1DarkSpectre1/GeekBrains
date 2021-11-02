using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationContract_GB_.Entitys;

namespace datalayer.Repositories
{
        public class ContractRepository
        {
            private ApplicationDataContext _context;

            public ContractRepository(ApplicationDataContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Contract>> GetContractAsync()
            {
                return await _context.Contracts.Where(p => p.Id > 0).ToArrayAsync();
            }
            public async Task<IEnumerable<Contract>> GetContractById(int id)
            {
                return await _context.Contracts.Where(p => p.Id == id).ToArrayAsync();
            }
            public async Task<IEnumerable<Contract>> GetContractsByid_client(int id)
            {
                return await _context.Contracts.Where(p => p.id_client == id).ToArrayAsync();
            }
        
            public async Task<int> PostContract(Contract Contract)
            {
                Contract UpdContract = _context.Contracts.Where(p => p.Id == Contract.Id).FirstOrDefault();
                UpdContract = Contract;
                return await _context.SaveChangesAsync();
            }
            public async Task<int> PutContract(Contract Contract)
            {
                _context.Contracts.Remove(Contract);
                return await _context.SaveChangesAsync();
            }
            public async Task<int> DeleteContract(int id)
            {
                Contract DeleteContract = _context.Contracts.Where(p => p.Id == id).FirstOrDefault();
                _context.Contracts.Remove(DeleteContract);
                return await _context.SaveChangesAsync();
            }
        }
}
