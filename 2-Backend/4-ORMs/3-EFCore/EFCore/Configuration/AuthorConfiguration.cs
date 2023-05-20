using EFCore.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Configuration;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder
            .HasOne(a => a.Book)
            .WithOne(b => b.Author)
            .HasForeignKey<Book>(b => b.AuthorId); 

        builder
            .Property(a => a.DisplayName)
            .HasComputedColumnSql("[FirstName]+' '+[LastName]");
    }
}