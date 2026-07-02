using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContextConfiguration.Configuration
{
    public class InternalConfiguration:DbContext
    {
        public DbSet<Wallet> wallets { set; get; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var connectionString = configuration.GetSection("DefaultConnection").Value;

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
