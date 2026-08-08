using ECommerce.Core.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Price).HasColumnType("decimal(18,2)").IsRequired();
        }
    }
}
