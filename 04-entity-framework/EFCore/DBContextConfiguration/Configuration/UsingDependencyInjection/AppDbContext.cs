using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContextConfiguration.Configuration.UsingDependencyInjection
{
    public class AppDbContext : DbContext
    {
        public DbSet<Wallet> wallets { set; get; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    }
}
