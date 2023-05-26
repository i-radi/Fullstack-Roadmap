﻿using EF006.DbContextAndConcurrency.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF006.DbContextAndConcurrency.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Wallet> Wallets { get; set; } = null!;

        public AppDbContext(DbContextOptions options)
            : base(options)
        {

        }
    }
}
