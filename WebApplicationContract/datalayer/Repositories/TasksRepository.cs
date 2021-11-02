using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationContract_GB_.Entitys;

namespace datalayer.Repositories
{
        public class TasksRepository
        {
            private ApplicationDataContext _context;

            public TasksRepository(ApplicationDataContext context)
            {
                _context = context;
            }
        
            public async Task<IEnumerable<Tasks>> GetTasksAsync()
            {
                return await _context.Tasks.Where(p => p.Id > 0).ToArrayAsync();
            }
            public async Task<IEnumerable<Tasks>> GetTasksById(int id)
            {
                return await _context.Tasks.Where(p => p.Id == id).ToArrayAsync();
            }
            public async Task<IEnumerable<Tasks>> GetTasksByid_contract(int id)
            {
                return await _context.Tasks.Where(p => p.id_contract == id).ToArrayAsync();
            }
            public async Task<int> PostTasks(Tasks Tasks)
            {
                Tasks UpdTasks = _context.Tasks.Where(p => p.Id == Tasks.Id).FirstOrDefault();
                UpdTasks = Tasks;
                return await _context.SaveChangesAsync();
            }
            public async Task<int> PutTasks(Tasks Tasks)
            {
                _context.Tasks.Remove(Tasks);
                return await _context.SaveChangesAsync();
            }
            public async Task<int> DeleteTasks(int id)
            {
                Tasks DeleteTasks = _context.Tasks.Where(p => p.Id == id).FirstOrDefault();
                _context.Tasks.Remove(DeleteTasks);
                return await _context.SaveChangesAsync();
            }
        }
}
