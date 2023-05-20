using EFCore.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Configuration;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        //builder
        //    .HasMany(t => t.Posts)
        //    .WithMany(p => p.Tags)
        //    .UsingEntity(j => j.ToTable("Tags_Posts"));

        builder
            .HasMany(t => t.Posts)
            .WithMany(p => p.Tags)
            .UsingEntity<TagPost>(
                j => j
                    .HasOne(pt => pt.Post)
                    .WithMany(t => t.TagPosts)
                    .HasForeignKey(pt => pt.PostId),
                j => j
                    .HasOne(pt => pt.Tag)
                    .WithMany(t => t.TagPosts)
                    .HasForeignKey(pt => pt.TagId),
                j =>
                {
                    j.HasKey(t => new { t.PostId, t.TagId });
                }
            );

    }
}