using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApplicationContract_GB_.Entitys;

namespace datalayer
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Status_contract> Status_contracts { get; set; }
        public DbSet<Status_Task> Status_Tasks { get; set; }


    }
}