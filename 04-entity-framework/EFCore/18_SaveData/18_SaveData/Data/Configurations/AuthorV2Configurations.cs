using _18_SaveData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace _18_SaveData.Data.Configurations
{
    public class AuthorV2Configurations : IEntityTypeConfiguration<AuthorV2>
    {
        public void Configure(EntityTypeBuilder<AuthorV2> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.FName)
                 .HasColumnType("VARCHAR")
                .HasMaxLength(50).IsRequired();

            builder.Property(x => x.LName)
                 .HasColumnType("VARCHAR")
                .HasMaxLength(50).IsRequired();

            builder.ToTable("AuthorsV2");
        }
    }
}
