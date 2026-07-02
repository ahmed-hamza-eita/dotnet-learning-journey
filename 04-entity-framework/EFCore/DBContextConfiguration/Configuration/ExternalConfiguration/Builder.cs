using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DBContextConfiguration.Configuration.ExternalConfiguration
{
    public static class Builder
    {
        public static DbContextOptions Build()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var connectionString = configuration.GetSection("DefaultConnection").Value;

            var optionBuilder = new DbContextOptionsBuilder();
            optionBuilder.UseSqlServer(connectionString);
            var options = optionBuilder.Options;

            return options;

        }
    }
}
