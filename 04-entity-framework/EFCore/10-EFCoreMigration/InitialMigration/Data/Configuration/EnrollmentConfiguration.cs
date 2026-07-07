using InitialMigration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace InitialMigration.Data.Configuration
{
    public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            //id (composite key)
            builder.HasKey(x => new { x.SectionId, x.ParticipantId });

            builder.ToTable("Enrollments");



        }

    }
}
 