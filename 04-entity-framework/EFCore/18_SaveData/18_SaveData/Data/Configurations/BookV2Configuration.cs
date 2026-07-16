

using _18_SaveData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _18_SaveData.Data.Configurations
{
    public class BookV2Configuration : IEntityTypeConfiguration<BookV2>
    {
        public void Configure(EntityTypeBuilder<BookV2> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Title)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255).IsRequired();

            builder.HasOne(x => x.AuthorV2)
                .WithMany(x => x.BooksV2)
                .HasForeignKey(x => x.AuthorV2Id)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            builder.ToTable("BooksV2");
        }
    }
}

 