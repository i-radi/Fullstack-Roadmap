using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using Factory.Entities.Joins;

namespace Factory.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public double TotalPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public string OrderDetial { get; set; }
        public string Type { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public ICollection<RawMaterial> RawMaterials { get; set; }
        public ICollection<MaterialOrderJoin> MaterialOrderJoins { get; set; }
    }
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            //Table Level
            builder.ToTable("Orders", "Factory");

            // Relationship level
            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.CustomerId);

          
            builder.HasOne(x => x.Car)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.CarId);

        }
    }
}
