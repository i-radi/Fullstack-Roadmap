using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Factory.Entities
{
    public class MachinePart
    {
        public int Id { get; set; }

        public int PartNumber { get; set; }
        public string Name { get; set; }
        public double CostPerHour { get; set; }

        public int MachineId { get; set; }
        public Machine Machine { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }

    }
    public class MachinePartConfig : IEntityTypeConfiguration<MachinePart>
    {
        public void Configure(EntityTypeBuilder<MachinePart> builder)
        {
            //Table Level
            builder.ToTable("MachineParts", "Factory");

            // Relationship level
            builder.HasOne(x => x.Machine)
                .WithMany(x => x.MachineParts)
                .HasForeignKey(x => x.MachineId);
            builder.HasOne(x => x.Car)
                .WithMany(x => x.MachineParts)
                .HasForeignKey(x => x.CarId);

        }
    }

}
