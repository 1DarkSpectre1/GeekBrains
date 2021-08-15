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

        public DbSet<Client> Client { get; set; }
        public DbSet<Contract> Contract { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Status_contract> Status_contract { get; set; }
        public DbSet<Status_Task> Status_Task { get; set; }


    }
}