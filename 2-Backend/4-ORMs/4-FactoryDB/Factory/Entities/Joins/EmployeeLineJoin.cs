using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Factory.Entities.Joins
{
    public class EmployeeLineJoin
    {
        public int Id { get; set; }

        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }

        public Line Line { get; set; }
        public int LineId { get; set; }
    }
    public class EmployeeLineJoinConfig : IEntityTypeConfiguration<EmployeeLineJoin>
    {
        public void Configure(EntityTypeBuilder<EmployeeLineJoin> builder)
        {
            //Table Level
            builder.ToTable("EmployeeLineJoin", "Factory");

        }
    }
}