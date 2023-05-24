using Commander.Models;

namespace Commander.Data.DbContext
{
    public class CommanderContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> opt) : base(opt)
        {
            
        }

        public DbSet<Command> Commands { get; set; }

    }
}