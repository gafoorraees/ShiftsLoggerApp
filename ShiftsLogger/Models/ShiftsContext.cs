using Microsoft.EntityFrameworkCore;
using ShiftsLogger.Models;

namespace ShiftsLogger.Models
{
    public class ShiftsContext : DbContext
    {
        public ShiftsContext(DbContextOptions<ShiftsContext> options)
            : base(options)
        {

        }

        public DbSet<Shift> Shifts { get; set; }

        public DbSet<Employee> Employees { get; set; }
    }
}
