using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContextConfiguration.Configuration.UsingDependencyInjection
{
    public static class Services
    {
        public static IServiceProvider BuildServiceProvider<T>() where T :DbContext
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var connectionString = configuration.GetSection("DefaultConnection").Value;

            //DI Container (Create a collection to hold all registered services)
            var services = new ServiceCollection();

            //Register the DbContext service
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));

            //Build the Service Provider to be able to resolve/get services
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            
            return serviceProvider;
        }
    }
}
