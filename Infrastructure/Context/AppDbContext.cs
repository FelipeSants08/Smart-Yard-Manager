using Microsoft.EntityFrameworkCore;
using Smart_Yard_Manager.Domain.Entity;
using Smart_Yard_Manager.Infrastructure.Mappings;

namespace Smart_Yard_Manager.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Sensor> Sensors { get; set; }

        public DbSet<Moviment> Moviments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SensorMapping());
            modelBuilder.ApplyConfiguration(new MovimentMapping());
        }
    }
}
