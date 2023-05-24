using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Factory.Entities.Joins
{
    public class MaterialOrderJoin
    {
        public int Id { get; set; }

        public int RawMaterialId { get; set; }
        public RawMaterial RawMaterial { get; set; }

        public Order Order { get; set; }
        public int OrderId { get; set; }
    }
    public class MaterialOrderJoinConfig : IEntityTypeConfiguration<MaterialOrderJoin>
    {
        public void Configure(EntityTypeBuilder<MaterialOrderJoin> builder)
        {
            //Table Level
            builder.ToTable("MaterialOrderJoin", "Factory");
        }
    }
}