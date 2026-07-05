using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sahred.Entities;

namespace Sahred.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<OrderWithDetailsView> OrderWithDetailsViews { get; set; }

    public virtual DbSet<Product> Products { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

         var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

         var connectionStr = configuration.GetConnectionString("DefaultConnection");

        optionsBuilder.UseSqlServer(connectionStr);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3214EC07C52F09CD");

            entity.ToTable("Orders", "Sales");

            entity.HasIndex(e => e.CustomerEmail, "UC_CustomerEmail").IsUnique();

            entity.Property(e => e.CustomerEmail).HasMaxLength(100);
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderDet__3214EC0753EA2BA3");

            entity.ToTable("OrderDetails", "Sales");

            entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__Order__5070F446");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__Produ__5165187F");
        });

        modelBuilder.Entity<OrderWithDetailsView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("OrderWithDetailsView");

            entity.Property(e => e.CustomerEmail).HasMaxLength(100);
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.ProductName).HasMaxLength(50);
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC07E8786D3A");

            entity.ToTable("Products", "Inventory");

            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
