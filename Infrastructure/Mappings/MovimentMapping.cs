using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_Yard_Manager.Domain.Entity;

namespace Smart_Yard_Manager.Infrastructure.Mappings
{
    public class MovimentMapping : IEntityTypeConfiguration<Moviment>
    {
        public void Configure(EntityTypeBuilder<Moviment> builder)
        {
            builder.ToTable("MOVIMENTS");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                   .HasColumnName("ID")
                   .IsRequired();

            builder.Property(m => m.PlacaMoto)
                   .HasColumnName("PLACA_MOTO")
                   .HasMaxLength(20)
                   .IsRequired();

            builder.Property(m => m.DataHora)
                   .HasColumnName("DATA_HORA")
                   .IsRequired();

            builder.Property(m => m.SensorId)
                   .HasColumnName("SENSOR_ID")
                   .IsRequired();

            builder.HasOne(m => m.Sensor)
                   .WithMany(s => s.Moviments)
                   .HasForeignKey(m => m.SensorId)
                   .OnDelete(DeleteBehavior.Restrict);
        } 
    }
}

