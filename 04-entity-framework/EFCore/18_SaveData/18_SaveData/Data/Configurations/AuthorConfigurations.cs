using _18_SaveData.Entities;
using _18_SaveData.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace _18_SaveData.Data.Configurations
{
    public class AuthorConfigurations : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.FName)
                 .HasColumnType("VARCHAR")
                .HasMaxLength(50).IsRequired();

            builder.Property(x => x.LName)
                 .HasColumnType("VARCHAR")
                .HasMaxLength(50).IsRequired();

            //Interceptor
            builder.HasQueryFilter(del => !del.IsDeleted);

            // Encryption -> Automatically encodes at save time, automatically decodes at read time
            builder.Property(x => x.NationalId)
                .HasConversion(
                    plain => EncryptionHelper.Encrypt(plain),
                    encrypted => EncryptionHelper.Decrypt(encrypted));

            builder.ToTable("Authors");
        }
    }
}
