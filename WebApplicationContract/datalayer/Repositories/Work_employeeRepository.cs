using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationContract_GB_.Entitys;

namespace datalayer.Repositories
{
        public class Work_employeeRepository
        {
            private ApplicationDataContext _context;

            public Work_employeeRepository(ApplicationDataContext context)
            {
                _context = context;
            }
        
            public async Task<IEnumerable<Work_employee>> GetWork_employeeAsync()
            {
                return await _context.Work_employee.Where(p => p.Id > 0).ToArrayAsync();
            }
            public async Task<IEnumerable<Work_employee>> GetWork_employeeById(int id)
            {
                return await _context.Work_employee.Where(p => p.Id == id).ToArrayAsync();
            }
            public async Task<IEnumerable<Work_employee>> GetWork_employeeByid_employee(int id)
            {
                return await _context.Work_employee.Where(p => p.id_employee == id).ToArrayAsync();
            }
            public async Task<IEnumerable<Work_employee>> GetWork_employeeByid_task(int id)
            {
                return await _context.Work_employee.Where(p => p.id_task == id).ToArrayAsync();
            }
            public async Task<int> PostWork_employee(Work_employee Work_employee)
            {
                Work_employee UpdWork_employee = _context.Work_employee.Where(p => p.Id == Work_employee.Id).FirstOrDefault();
                UpdWork_employee = Work_employee;
                return await _context.SaveChangesAsync();
            }
            public async Task<int> PutWork_employee(Work_employee Work_employee)
            {
                _context.Work_employee.Remove(Work_employee);
                return await _context.SaveChangesAsync();
            }
            public async Task<int> DeleteWork_employee(int id)
            {
                Work_employee DeleteWork_employee = _context.Work_employee.Where(p => p.Id == id).FirstOrDefault();
                _context.Work_employee.Remove(DeleteWork_employee);
                return await _context.SaveChangesAsync();
            }
        }
}
