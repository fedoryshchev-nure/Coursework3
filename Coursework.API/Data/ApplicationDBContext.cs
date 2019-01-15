using Core.Entities.CrossTable;
using Core.Entities.Origin;
using Core.Models.Origin;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ApplicationDBContext : IdentityDbContext<User>
    {
        public DbSet<Wall> Walls { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<Material> Materials { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            builder.Entity<Material>()
                .HasIndex(x => x.Name)
                .IsUnique();

            builder.Entity<WallMaterial>()
                .HasKey(x => new { x.MaterialId, x.WallId });

            base.OnModelCreating(builder);
        }
    }
}
