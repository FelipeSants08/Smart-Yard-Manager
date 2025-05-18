using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_Yard_Manager.Domain.Entity;

namespace Smart_Yard_Manager.Infrastructure.Mappings
{
    public class SensorMapping : IEntityTypeConfiguration<Sensor>
    {
        public void Configure(EntityTypeBuilder<Sensor> builder)
        {
            builder.ToTable("SENSORS");

            builder.HasKey(s => s.Id);

            builder.Property(sensors => sensors.Id)
                   .HasColumnName("ID")
                   .IsRequired();

            builder.Property(s => s.Name)
                   .HasColumnName("NAME")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(s => s.Section)
                   .HasColumnName("SECTION")
                   .HasConversion<int>()
                   .IsRequired();

            builder.Property(s => s.Active)
                   .HasConversion<int>()
                   .HasColumnName("ACTIVE")
                   .IsRequired();
            
            builder.HasMany(s => s.Moviments) 
                .WithOne(m => m.Sensor)
                .HasForeignKey(m => m.SensorId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
