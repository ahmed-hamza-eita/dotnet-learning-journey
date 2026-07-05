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

            builder.ToTable("Instructors");

            builder.HasData(LoadInstructors());
        }

        private List<Instructor> LoadInstructors()
        {
            return new List<Instructor> {

            new Instructor{Id=1,Name="Ahmed Abdullah" },
            new Instructor{Id=2,Name="Yasmeen Mohammed" },
            new Instructor{Id=3,Name="Khalid Hassan" },

            };
        }
    }
}
