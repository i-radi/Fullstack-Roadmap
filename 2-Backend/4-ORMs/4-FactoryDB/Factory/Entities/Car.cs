using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Factory.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public double CostPerHour { get; set; }
        public int CarNumber { get; set; }
        public string CarType { get; set; }
        public int EndYear { get; set; }

        public ICollection<Order> Orders { get; set; }
        public int GarageId { get; set; }
        public Garage Garage { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public ICollection<Sensor> Sensors { get; set; }
        public ICollection<MachinePart> MachineParts { get; set; }
    }
    public class CarConfig : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            //Table Level
            builder.ToTable("Cars", "Factory");

            // Relationship level
            builder.HasOne(x => x.Garage)
                .WithMany(x => x.Cars)
                .HasForeignKey(x => x.GarageId);

            builder.HasOne(x => x.Supplier)
                .WithMany(x => x.Cars)
                .HasForeignKey(x => x.SupplierId);
        }
    }
}