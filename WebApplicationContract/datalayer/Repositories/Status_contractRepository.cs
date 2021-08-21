using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationContract_GB_.Entitys;

namespace datalayer.Repositories
{
        public class Status_contractRepository
        {
            private ApplicationDataContext _context;

            public Status_contractRepository(ApplicationDataContext context)
            {
                _context = context;
            }
        
            public async Task<IEnumerable<Status_contract>> GetStatus_contractAsync()
            {
                return await _context.Status_contracts.Where(p => p.Id > 0).ToArrayAsync();
            }
            public async Task<IEnumerable<Status_contract>> GetStatus_contractById(int id)
            {
                return await _context.Status_contracts.Where(p => p.Id == id).ToArrayAsync();
            }
            public async Task<int> PostStatus_contract(Status_contract Status_contract)
            {
                Status_contract UpdStatus_contract = _context.Status_contracts.Where(p => p.Id == Status_contract.Id).FirstOrDefault();
                UpdStatus_contract = Status_contract;
                return await _context.SaveChangesAsync();
            }
            public async Task<int> PutStatus_contract(Status_contract Status_contract)
            {
                _context.Status_contracts.Remove(Status_contract);
                return await _context.SaveChangesAsync();
            }
            public async Task<int> DeleteStatus_contract(int id)
            {
                Status_contract DeleteStatus_contract = _context.Status_contracts.Where(p => p.Id == id).FirstOrDefault();
                _context.Status_contracts.Remove(DeleteStatus_contract);
                return await _context.SaveChangesAsync();
            }
        }
}
