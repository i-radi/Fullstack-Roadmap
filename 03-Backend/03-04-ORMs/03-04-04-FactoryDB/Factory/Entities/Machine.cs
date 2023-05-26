using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Factory.Entities
{
    public class Machine
    {
        public int Id { get; set; }

        public double AverageCostPerHour { get; set; }
        public string Description { get; set; }

        public int LineId { get; set; }
        public Line Line { get; set; }

        public ICollection<MachinePart> MachineParts { get; set; }
    }


    public class MachineConfig : IEntityTypeConfiguration<Machine>
    {
        public void Configure(EntityTypeBuilder<Machine> builder)
        {
            //Table Level
            builder.ToTable("Machines", "Factory");

            // Relationship level
            builder.HasOne(x => x.Line)
                .WithMany(x => x.Machines)
                .HasForeignKey(x => x.LineId);
        }

    }
}
