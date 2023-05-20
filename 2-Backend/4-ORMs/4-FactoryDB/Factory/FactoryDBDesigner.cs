using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Factory
{
    public class FactoryDbDesigner : IDesignTimeDbContextFactory<FactoryDbContext>
    {
        public static DbContextOptionsBuilder<TContext> SetConfiguration<TContext>(DbContextOptionsBuilder<TContext> builder, string connectionString)
            where TContext : DbContext
        {
            builder.UseSqlServer(connectionString, options =>
            {
                options.EnableRetryOnFailure(3);
                options.CommandTimeout(45);
            });
#if DEBUG
            builder.EnableSensitiveDataLogging()
                .EnableDetailedErrors();
#endif
            return builder;
        }


        public FactoryDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = SetConfiguration(new DbContextOptionsBuilder<FactoryDbContext>(),
                "Server=.;Database=FactoryDB;Trusted_Connection=True ;MultipleActiveResultSets=true");

            return new FactoryDbContext(optionsBuilder.Options);
        }
    }
}