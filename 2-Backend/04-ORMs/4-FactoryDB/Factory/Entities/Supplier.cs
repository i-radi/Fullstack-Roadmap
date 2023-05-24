using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Factory.Entities
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Location { get; set; }

        public ICollection<RawMaterial> RawMaterials { get; set; }
        public ICollection<Car> Cars { get; set; }


    }
    public class SupplierConfig : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            //Table Level
            builder.ToTable("Suppliers", "Factory");
        }
    }
}
