using Commander.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Commander.Data.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}