using InitialMigration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InitialMigration.Data.Configuration
{
    class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            //id
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            //name
            builder.Property(x => x.Name)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255).IsRequired();

            //relationship 1:1
            builder.HasOne(x => x.Office)
                .WithOne(x => x.Instructor)
                .HasForeignKey<Instructor>(x => x.OfficeId)
                .IsRequired(false);

            builder.ToTable("Instructors");

            builder.HasData(SeedData.LoadInstructors());
        }

        
    
    }
}
