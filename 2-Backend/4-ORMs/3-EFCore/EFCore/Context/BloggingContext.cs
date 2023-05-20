using System.Transactions;
using EFCore.Configuration;
using EFCore.Model;

namespace EFCore.Context;

public class BloggingContext : DbContext
{
    public virtual DbSet<Blog> Blogs { get; set; }
    public virtual DbSet<Post> Posts { get; set; }
    public virtual DbSet<Book> Books { get; set; }
    public virtual DbSet<Author> Authors { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Tag> Tags { get; set; }
    public virtual DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.HasSequence<int>("OrderNumber", schema: "shared")
            .StartsAt(100)
            .IncrementsBy(2);
        modelBuilder.Entity<Order>()
            .Property(o => o.OrderNo)
            .HasDefaultValueSql("NEXT VALUE FOR shared.OrderNumber");

        modelBuilder.Entity<Order>(o
            =>
        { o.HasNoKey().ToView(null); });

        //modelBuilder.Entity<Post>().HasQueryFilter(o => !o.IsDeleted);
        modelBuilder.Entity<Blog>().HasQueryFilter(b => b.Posts.Count > 0);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuthorConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TagConfiguration).Assembly);
        modelBuilder.HasDefaultSchema("Blogging");


        //Indirect Many to Many
       modelBuilder.Entity<TagPost>()
           .HasKey(t => new { t.PostId, t.TagId });

        modelBuilder.Entity<TagPost>()
            .HasOne(pt => pt.Post)
            .WithMany(p => p.TagPosts)
            .HasForeignKey(pt => pt.PostId);

        modelBuilder.Entity<TagPost>()
            .HasOne(pt => pt.Tag)
            .WithMany(p => p.TagPosts)
            .HasForeignKey(pt => pt.TagId);

        modelBuilder.Entity<Blog>();
        modelBuilder.Ignore<Blog>();
        //new UserConfiguration().Configure(modelBuilder.Entity<Blog>());
        modelBuilder.Entity<Blog>().ToTable("Blogs", b => b.ExcludeFromMigrations());

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer(
            @"Server=.;Database=BloggingDB;Trusted_Connection=True");

        optionsBuilder.UseSqlServer(
            @"Server=.;Database=BloggingDB;Trusted_Connection=True");

        optionsBuilder.UseSqlServer(
            @"Server=.;Database=BloggingDB;Trusted_Connection=True",
            o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
    }
}

public class Order
{
    public int Id { get; set; }
    public long OrderNo { get; set; }
    public double Amount { get; set; }
}