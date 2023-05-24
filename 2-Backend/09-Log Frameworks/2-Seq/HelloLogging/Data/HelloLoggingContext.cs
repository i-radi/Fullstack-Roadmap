using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HelloLogging.Models;

namespace HelloLogging.Data
{
    public class HelloLoggingContext : DbContext
    {
        public HelloLoggingContext (DbContextOptions<HelloLoggingContext> options)
            : base(options)
        {
        }

        public DbSet<HelloLogging.Models.Employee> Employee { get; set; }
    }
}
