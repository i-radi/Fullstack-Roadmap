using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Factory.Entities
{
    public class Sensor
    {
        public int Id { get; set; }

        public string Type { get; set; }
        public int SensorId { get; set; }
        public double CostPerHour { get; set; }


        public int CarId { get; set; }
        public Car Car { get; set; }

        public ICollection<SensorDataLog> SensorDataLogs { get; set; }
        public ICollection<RawMaterial> RawMaterials { get; set; }

    }

    public class SensorConfig : IEntityTypeConfiguration<Sensor>
    {
        public void Configure(EntityTypeBuilder<Sensor> builder)
        {
            //Table Level
            builder.ToTable("Sensors", "Factory");

            // Relationship level
            builder.HasOne(x => x.Car)
                .WithMany(x => x.Sensors)
                .HasForeignKey(x => x.CarId);
        }
    }
}