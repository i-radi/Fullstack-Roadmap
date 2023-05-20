using EFCore.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Configuration;

public class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        //relations
        builder
            .HasMany(b => b.Posts)
            .WithOne(p => p.Blog)
            .HasForeignKey(p => p.BlogId)
            .HasPrincipalKey(b => b.BlogId);
            //.HasConstraintName("FK_Posts_Test");

        builder.Ignore(b => b.AddedOn);
        builder
            .HasKey(b => b.BlogId);
        //.HasName("PK_Blog");

        builder
            .HasIndex(b => new { b.Url, b.AddedOn })
            .HasDatabaseName("IX_Composite")
            .HasFilter("[Url] IS NOT NULL");
            //.IsUnique()
            //.HasFilter(null);

        //properties
        builder
            .Property(b => b.Url)
            .HasColumnName("BlogUrl")
            .HasColumnType("varchar(200)")
            .HasComment("The Url of the blog")
            .IsRequired();
        builder
            .Property(b => b.Rating)
            .HasDefaultValue(5);
        builder
            .Property(b => b.CreatedOn)
            .HasDefaultValueSql("GETDATE()");

        //Seed Data
        builder.HasData(new Blog { BlogId = 1, Url = "google.com" });
    }
}