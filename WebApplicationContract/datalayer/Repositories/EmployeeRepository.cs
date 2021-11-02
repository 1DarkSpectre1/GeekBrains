using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationContract_GB_.Entitys;

namespace datalayer.Repositories
{
        public class EmployeeRepository
    {
            private ApplicationDataContext _context;

            public EmployeeRepository(ApplicationDataContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Employee>> GetEmployeeAsync()
            {
                return await _context.Employees.Where(p => p.Id > 0).ToArrayAsync();
            }
            public async Task<IEnumerable<Employee>> GetEmployeeById(int id)
            {
                return await _context.Employees.Where(p => p.Id == id).ToArrayAsync();
            }
            public async Task<IEnumerable<Employee>> GetEmployeeByName(string name)
            {
                return await _context.Employees.Where(p => p.FirstName.Contains(name)).ToArrayAsync();
            }
            public async Task<int> PostEmployee(Employee Employee)
            {
                Employee UpdEmployee = _context.Employees.Where(p => p.Id == Employee.Id).FirstOrDefault();
                UpdEmployee = Employee;
                return await _context.SaveChangesAsync();
            }
            public async Task<int> PutEmployee(Employee Employee)
            {
                _context.Employees.Remove(Employee);
                return await _context.SaveChangesAsync();
            }
            public async Task<int> DeleteEmployee(int id)
            {
                Employee DeleteEmployee = _context.Employees.Where(p => p.Id == id).FirstOrDefault();
                _context.Employees.Remove(DeleteEmployee);
                return await _context.SaveChangesAsync();
            }
        }
}
