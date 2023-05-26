using EFCore.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Configuration;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Posts", "Blogging");
        builder.ToView("SelectPosts", "Blogging");


        builder.Property(b => b.Content)
            .HasMaxLength(500)
            .IsRequired();
    }
}