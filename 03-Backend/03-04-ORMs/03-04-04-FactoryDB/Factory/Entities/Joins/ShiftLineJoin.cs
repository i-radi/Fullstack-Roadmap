using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Factory.Entities.Joins
{
    public class ShiftLineJoin
    {
        public int Id { get; set; }

        public Shift Shift { get; set; }
        public int ShiftId { get; set; }

        public Line Line { get; set; }
        public int LineId { get; set; }
    }
    public class ShiftLineJoinConfig : IEntityTypeConfiguration<ShiftLineJoin>
    {
        public void Configure(EntityTypeBuilder<ShiftLineJoin> builder)
        {
            //Table Level
            builder.ToTable("ShiftLineJoin", "Factory");

        }
    }
}