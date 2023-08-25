using Microsoft.EntityFrameworkCore;
using WS.Model.Entities;

namespace WS.DataAccess.Implementations.EF.Contexts
{
    public class AIRPORTContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder
            optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=.
              ;database=AIRPORT;trusted_connection=true;");
        }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<SeatNumber> SeatsNumbers { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<AdminPanelUser> AdminPanelUsers { get; set; }
    }
}
