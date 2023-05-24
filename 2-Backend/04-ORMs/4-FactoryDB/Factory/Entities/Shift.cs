using System;
using System.Collections.Generic;
using Factory.Entities.Joins;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Factory.Entities
{
    public class Shift
    {
        public int Id { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Name { get; set; }


        public ICollection<Employee> Employees { get; set; }
        public ICollection<Line> Lines { get; set; }
        public ICollection<ShiftLineJoin> ShiftLineJoins { get; set; }

    }
    public class ShiftConfig : IEntityTypeConfiguration<Shift>
    {
        public void Configure(EntityTypeBuilder<Shift> builder)
        {
            //Table Level
            builder.ToTable("Shifts", "Factory");

            // Relationship level
            builder.HasMany(x => x.Lines)
                .WithMany(x => x.Shifts)
                .UsingEntity<ShiftLineJoin>(
                    b => b.HasOne(e => e.Line).WithMany(x => x.ShiftLineJoins)
                        .HasForeignKey(e => e.LineId),
                    b => b.HasOne(e => e.Shift).WithMany(x => x.ShiftLineJoins)
                        .HasForeignKey(e => e.ShiftId));
        }
    }
}
