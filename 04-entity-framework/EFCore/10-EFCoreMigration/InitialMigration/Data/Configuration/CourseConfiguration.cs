using InitialMigration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InitialMigration.Data.Configuration
{
    class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            //Id
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            //Course Name
            builder.Property(x => x.CourseName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255).IsRequired();

            //price
            builder.Property(x => x.Price)
                .HasPrecision(15, 2);

            builder.ToTable("Courses");

            builder.HasData(LoadCourses());

        }

        private List<Course> LoadCourses()
        {
            return new List<Course>
            {
                new Course { Id =1,CourseName="Mathmatics" ,Price=100m},
                new Course { Id =2,CourseName="Physics" ,Price=200m},
                new Course { Id =3,CourseName="Chemistry" ,Price=150m},
            };
        }
    }
}
