using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3_ConfigurationUsingFluentAPI.Data
{
      class AppDBContext:DbContext
    {
        public DbSet<User> Users { set; get; } = null!;
        public DbSet<Tweet> Tweets { set; get; } = null!;
        public DbSet<Comment> Comments { set; get; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("tblUsers"); //for table name
            modelBuilder.Entity<User>().Property(p => p.Id).HasColumnName("UserID"); //for column name
            modelBuilder.Entity<Tweet>().ToTable("tblTweets");
            modelBuilder.Entity<Comment>().ToTable("tblComments");
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
