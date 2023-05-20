using System;
using System.Collections.Generic;
using Factory.Entities.Joins;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Factory.Entities
{
    public class Line
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }
        public double TotalCost { get; set; }
        public string ProductType { get; set; }
        public int SerialNumber { get; set; }

        public ICollection<Product> Products { get; set; }
        public ICollection<Machine> Machines { get; set; }
        public ICollection<Shift> Shifts { get; set; }
        public ICollection<ShiftLineJoin> ShiftLineJoins { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<EmployeeLineJoin> EmployeeLineJoins { get; set; }

    }
    public class LineConfig : IEntityTypeConfiguration<Line>
    {
        public void Configure(EntityTypeBuilder<Line> builder)
        {
            //Table Level
            builder.ToTable("Lines", "Factory");
        }
    }
}