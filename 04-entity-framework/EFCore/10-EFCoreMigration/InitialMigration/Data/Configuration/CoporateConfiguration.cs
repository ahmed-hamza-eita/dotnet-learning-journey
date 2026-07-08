using InitialMigration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
 

namespace InitialMigration.Data.Configuration
{
    class CoporateConfiguration : IEntityTypeConfiguration<Coporate>
    {
        public void Configure(EntityTypeBuilder<Coporate> builder)
        {

            builder.ToTable("Coporates");

            builder.HasData(SeedData.LoadCorporates());
        }

    }
}
