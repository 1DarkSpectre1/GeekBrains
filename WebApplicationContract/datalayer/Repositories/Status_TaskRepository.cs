using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationContract_GB_.Entitys;

namespace datalayer.Repositories
{
        public class Status_TaskRepository
        {
            private ApplicationDataContext _context;

            public Status_TaskRepository(ApplicationDataContext context)
            {
                _context = context;
            }
        
            public async Task<IEnumerable<Status_Task>> GetStatus_TaskAsync()
            {
                return await _context.Status_Tasks.Where(p => p.Id > 0).ToArrayAsync();
            }
            public async Task<IEnumerable<Status_Task>> GetStatus_TaskById(int id)
            {
                return await _context.Status_Tasks.Where(p => p.Id == id).ToArrayAsync();
            }
            public async Task<int> PostStatus_Task(Status_Task Status_Task)
            {
                Status_Task UpdStatus_Task = _context.Status_Tasks.Where(p => p.Id == Status_Task.Id).FirstOrDefault();
                UpdStatus_Task = Status_Task;
                return await _context.SaveChangesAsync();
            }
            public async Task<int> PutStatus_Task(Status_Task Status_Task)
            {
                _context.Status_Tasks.Remove(Status_Task);
                return await _context.SaveChangesAsync();
            }
            public async Task<int> DeleteStatus_Task(int id)
            {
                Status_Task DeleteStatus_Task = _context.Status_Tasks.Where(p => p.Id == id).FirstOrDefault();
                _context.Status_Tasks.Remove(DeleteStatus_Task);
                return await _context.SaveChangesAsync();
            }
        }
}
