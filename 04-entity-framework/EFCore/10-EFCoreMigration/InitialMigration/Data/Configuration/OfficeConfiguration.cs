using InitialMigration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace InitialMigration.Data.Configuration
{
    class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            //Id
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            //office Name
            builder.Property(x => x.OfficeName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50).IsRequired();

            //office location
            builder.Property(x => x.OfficeLocation)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50).IsRequired();

            builder.ToTable("Offices");

            builder.HasData(SeedData.LoadOffices());

        }

        
    }
}