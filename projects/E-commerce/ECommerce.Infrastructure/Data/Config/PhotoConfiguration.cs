using ECommerce.Core.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Data.Config
{
    public class PhotoConfiguration : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.Property(n => n.Name).IsRequired();

            builder.HasData(new Photo { Id = 1, Name = "test-photo-1.jpg", ProductId = 1 });
        }
    }
}
