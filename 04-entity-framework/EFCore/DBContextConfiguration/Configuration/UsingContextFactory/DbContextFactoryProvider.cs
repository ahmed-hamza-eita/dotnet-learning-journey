using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContextConfiguration.Configuration.UsingContextFactory
{
    class DbContextFactoryProvider
    {

        public static IDbContextFactory<T> CreateFactory<T>() where T : DbContext
        {

            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var connectionString = configuration.GetSection("DefaultConnection").Value;

            var services = new ServiceCollection();

            services.AddDbContextFactory<T>(option => option.UseSqlServer(connectionString));

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            var contextFactory = serviceProvider.GetRequiredService<IDbContextFactory<T>>();

            return contextFactory;

        }

    }

}
