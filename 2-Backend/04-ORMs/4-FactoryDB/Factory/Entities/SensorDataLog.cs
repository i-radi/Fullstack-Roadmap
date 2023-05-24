using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Factory.Entities
{
    public class SensorDataLog
    {
        public int Id { get; set; }

        public string Location { get; set; }
        public DateTime DateTimeRead { get; set; }

        public int SensorId { get; set; }
        public Sensor Sensor { get; set; }
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
    }

    public class SensorDataLogConfig : IEntityTypeConfiguration<SensorDataLog>
    {
        public void Configure(EntityTypeBuilder<SensorDataLog> builder)
        {
            //Table Level
            builder.ToTable("SensorDataLogs", "Factory");

            // Relationship level
            builder.HasOne(x => x.Sensor)
                .WithMany(x => x.SensorDataLogs)
                .HasForeignKey(x => x.SensorId);

            builder.HasOne(x => x.Warehouse)
                .WithMany(x => x.SensorDataLogs)
                .HasForeignKey(x => x.WarehouseId);
        }
    }
}