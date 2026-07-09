using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueryData.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueryData.Data.Configuration
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        void IEntityTypeConfiguration<Review>.Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.HasOne(x => x.Course)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.CourseId)
                .IsRequired();

            builder.Property(x => x.CreatedAt).IsRequired();

            builder.ToTable("Reviews");
        }
    }
}
