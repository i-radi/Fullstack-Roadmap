using Microsoft.EntityFrameworkCore;
using Redis_Cache_using_.NET_Core_API.Model;

namespace Redis_Cache_using_.NET_Core_API.Data;

public class DbContextClass : DbContext
{
    public DbContextClass(DbContextOptions<DbContextClass> options) : base(options) { }
    public DbSet<Product> Products
    {
        get;
        set;
    }
}
