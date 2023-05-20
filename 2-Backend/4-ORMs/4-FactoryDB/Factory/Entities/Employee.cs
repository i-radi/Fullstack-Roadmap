using System.Collections.Generic;
using Factory.Entities.Joins;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Factory.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public double Salary { get; set; }
        public string Type { get; set; }
        public int IDNumber { get; set; }

        public int ShiftId { get; set; }
        public Shift Shift { get; set; }
        public ICollection<Line> Lines { get; set; }
        public ICollection<EmployeeLineJoin> EmployeeLineJoins { get; set; }
    }

    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            //Table Level
            builder.ToTable("Employees", "Factory");

            // Relationship level
            builder.HasOne(x => x.Shift)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.ShiftId);
            builder.HasMany(x => x.Lines)
                .WithMany(x => x.Employees)
                .UsingEntity<EmployeeLineJoin>(
                    b => b.HasOne(e => e.Line).WithMany(x => x.EmployeeLineJoins)
                        .HasForeignKey(e => e.LineId),
                    b => b.HasOne(e => e.Employee).WithMany(x => x.EmployeeLineJoins)
                        .HasForeignKey(e => e.EmployeeId));

        }
    }

}
