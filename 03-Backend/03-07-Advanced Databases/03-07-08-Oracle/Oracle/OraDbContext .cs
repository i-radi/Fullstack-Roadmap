using Microsoft.EntityFrameworkCore;
using Oracle;

namespace Core_APIOracle.Models;

public class OraDbContext : DbContext
{
    public DbSet<SP_GetProductById_Response> SP_GetProductByIdResponse { get; set; }
    public DbSet<View_Product> PRODUCTVIEW { get; set; }
    public DbSet<ProductsInfo> Products { get; set; }
    public OraDbContext(DbContextOptions<OraDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}