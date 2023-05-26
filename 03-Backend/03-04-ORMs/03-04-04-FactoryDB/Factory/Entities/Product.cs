using System;
using System.Collections;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Factory.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public int SerialNumber { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
        public int LineId { get; set; }
        public Line Line { get; set; }
        public ICollection<ProductDetail> ProductDetails { get; set; }
    }
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //Table Level
            builder.ToTable("Products", "Factory");

            // Relationship level
            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);

            builder.HasOne(x => x.Warehouse)
                .WithMany(x => x.products)
                .HasForeignKey(x => x.WarehouseId);

            builder.HasOne(x => x.Line)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.LineId);
        }
    }
}
