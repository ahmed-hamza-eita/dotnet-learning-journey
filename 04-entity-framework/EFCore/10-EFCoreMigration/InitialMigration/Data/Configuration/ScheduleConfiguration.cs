using InitialMigration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace InitialMigration.Data.Configuration
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            //Id
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            //title
            builder.Property(x => x.Title)
               .HasColumnType("VARCHAR")
               .HasMaxLength(50).IsRequired();



            builder.ToTable("Schedules");

            builder.HasData(SeedData.LoadSchedules());

        }

       
        }
    }
 
