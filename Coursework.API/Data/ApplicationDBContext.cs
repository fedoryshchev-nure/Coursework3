using Core.Models.Origin;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Wall> Walls { get; set; }
        public DbSet<Sensor> Sensors { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
    }
}
