using _1_ConfigurationByConvention.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace _1_ConfigurationByConvention.Data
{
    class AppDBContext : DbContext
    {
        public DbSet<User> tblUsers { get; set; } = null!;
        public DbSet<Tweet> tblTweets { get; set; } = null!;
        public DbSet<Comment> tblComments { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();
            var connectionString = configuration.GetRequiredSection("DefaultConnection").Value;

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
