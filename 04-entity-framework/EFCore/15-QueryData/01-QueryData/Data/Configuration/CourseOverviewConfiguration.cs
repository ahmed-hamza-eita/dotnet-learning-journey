
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueryData.Entities;

namespace QueryData.Data.Configuration
{
    public class CourseOverviewConfiguration : IEntityTypeConfiguration<CourseOverview>
    {
        public void Configure(EntityTypeBuilder<CourseOverview> builder)
        {
            builder.HasNoKey();
            builder.ToView("CourseOverview");
        }
    }
}
