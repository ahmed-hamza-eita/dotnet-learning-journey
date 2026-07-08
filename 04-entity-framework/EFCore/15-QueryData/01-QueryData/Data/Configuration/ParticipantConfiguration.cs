using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueryData.Entities;

namespace QueryData.Data.Configuration
{
    public class ParticipantConfiguration : IEntityTypeConfiguration<Participant>
    {
        public void Configure(EntityTypeBuilder<Participant> builder)
        {
            //id
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            //student name
            builder.Property(x => x.FName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50).IsRequired();

            builder.Property(x => x.LName)
            .HasColumnType("VARCHAR")
            .HasMaxLength(50).IsRequired();


            //TPH
            /*
            builder.HasDiscriminator<string>("ParticipantType")
                .HasValue<Individual>("INDV")
                .HasValue<Coporate>("COPR");
            builder.Property("ParticipantType").HasColumnType("VARCHAR").HasMaxLength(4);
            */

            //TPT way1
            //builder.UseTptMappingStrategy();


            builder.ToTable("Participants");



        }


    }
}
