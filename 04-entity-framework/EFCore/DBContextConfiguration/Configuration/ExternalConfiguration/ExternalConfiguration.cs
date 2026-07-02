using Microsoft.EntityFrameworkCore;
using Shared.DBConfiguration;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContextConfiguration.Configuration.ExternalConfiguration
{
    public class ExternalConfiguration : DbContext
    {
        public DbSet<Wallet> wallets { set; get; } = null!;

        public ExternalConfiguration(DbContextOptions options) : base(options)
        {


        }

    }
}
