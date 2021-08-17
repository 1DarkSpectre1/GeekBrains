using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationContract_GB_.Entitys;

namespace datalayer.Repositories
{
        public class ClientRepository
        {
            private ApplicationDataContext _context;

            public ClientRepository(ApplicationDataContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Client>> GetClientAsync()
            {
                return await _context.Clients.Where(p => p.Id > 0).ToArrayAsync();
            }
            public async Task<IEnumerable<Client>> GetClientById(int id)
            {
                return await _context.Clients.Where(p => p.Id == id).ToArrayAsync();
            }
            public async Task<IEnumerable<Client>> GetClientByName(string name)
            {
                return await _context.Clients.Where(p => p.FirstName.Contains(name)).ToArrayAsync();
            }
            public async Task<int> PostClient(Client Client)
            {
                Client UpdClient = _context.Clients.Where(p => p.Id == Client.Id).FirstOrDefault();
                UpdClient = Client;
                return await _context.SaveChangesAsync();
            }
            public async Task<int> PutClient(Client Client)
            {
                _context.Clients.Remove(Client);
                return await _context.SaveChangesAsync();
            }
            public async Task<int> DeleteClient(int id)
            {
                Client DeleteClient = _context.Clients.Where(p => p.Id == id).FirstOrDefault();
                _context.Clients.Remove(DeleteClient);
                return await _context.SaveChangesAsync();
            }
        }
}
