using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Factory.Entities
{
    public class Warehouse
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Location { get; set; }
        public int InventoryId { get; set; }

        public ICollection<Product> products { get; set; }
        public ICollection<SensorDataLog> SensorDataLogs { get; set; }
        public ICollection<ProductDetail> ProductDetails { get; set; }

    }
    public class StorageConfig : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            //Table Level
            builder.ToTable("Warehouses", "Factory");
        }
    }
}