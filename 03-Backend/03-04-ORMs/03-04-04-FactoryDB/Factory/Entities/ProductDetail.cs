using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Factory.Entities
{
    public class ProductDetail
    {
        public int Id { get; set; }
        public int ProductNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime ProductionDateT { get; set; }
        public int Quantity { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
    }
    public class ProductDetailConfig : IEntityTypeConfiguration<ProductDetail>
    {
        public void Configure(EntityTypeBuilder<ProductDetail> builder)
        {
            //Table Level
            builder.ToTable("ProductDetails", "Factory");

            // Relationship level
            builder.HasOne(x => x.Product)
                .WithMany(x => x.ProductDetails)
                .HasForeignKey(x => x.ProductId);

            builder.HasOne(x => x.Warehouse)
                .WithMany(x => x.ProductDetails)
                .HasForeignKey(x => x.WarehouseId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}