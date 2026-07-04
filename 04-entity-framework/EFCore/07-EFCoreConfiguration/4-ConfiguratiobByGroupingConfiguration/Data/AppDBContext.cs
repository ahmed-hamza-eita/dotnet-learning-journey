using _4_ConfiguratiobByGroupingConfiguration.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace _4_ConfiguratiobByGroupingConfiguration
{
      class AppDBContext:DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Tweet> Tweets { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
                Assembly.GetExecutingAssembly()
                );
        }
        
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
