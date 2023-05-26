using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Factory.Entities
{
    public class Garage
    {
        public int Id { get; set; }

        public int GarageNumber { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
    public class GarageConfig : IEntityTypeConfiguration<Garage>
    {
        public void Configure(EntityTypeBuilder<Garage> builder)
        {
            //Table Level
            builder.ToTable("Garages", "Factory");
        }
    }
}