using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueryData.Entities;

namespace QueryData.Data.Configuration
{
    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            //Id
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            //Section Name
            builder.Property(x => x.SectionName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255).IsRequired();

            //Relation 1:M 
            builder.HasOne(x => x.Course)
                  .WithMany(x => x.Sections)
                  .HasForeignKey(x => x.CourseId)
                  .IsRequired();

            builder.HasOne(x => x.Instructor)
                  .WithMany(x => x.Sections)
                  .HasForeignKey(x => x.InstructorId)
                  .IsRequired(false);

            /*
            //relation m:m
            builder.HasMany(x => x.Schedules)
                .WithMany(x => x.Sections)
                .UsingEntity<SectionSchedule>();
             */
            builder.HasMany(x => x.Participants)
                .WithMany(x => x.Sections)
                .UsingEntity<Enrollment>();

            builder.HasOne(c => c.Schedule)
                .WithMany(x => x.Sections)
                .HasForeignKey(x => x.ScheduleId)
                .IsRequired();


            builder.OwnsOne(x => x.TimeSlot, ts =>
            {
                ts.Property(p => p.StartTime).HasColumnType("time(0)").HasColumnName("StartTime").IsRequired();
                ts.Property(p => p.EndTime).HasColumnType("time(0)").HasColumnName("EndTime").IsRequired();
            });

            builder.OwnsOne(x => x.DateRange, ts =>
            {
                ts.Property(p => p.StartDate).HasColumnType("date").HasColumnName("StartDate").IsRequired();
                ts.Property(p => p.EndDate).HasColumnType("date").HasColumnName("EndDate").IsRequired();
            });

            //Has query filter
            var twoYearsAgo = DateOnly.FromDateTime(DateTime.Now.AddYears(-4));
            builder.HasQueryFilter(x => x.DateRange.StartDate >= twoYearsAgo);


            builder.ToTable("Sections");

        }
    }
}

