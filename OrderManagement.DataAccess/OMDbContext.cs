using Microsoft.EntityFrameworkCore;
using OrderManagement.DataAccess.Entities;

namespace DataAccess
{
    public class OMDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Window> Windows { get; set; }
        public DbSet<SubElement> SubElements { get; set; }

        public OMDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}