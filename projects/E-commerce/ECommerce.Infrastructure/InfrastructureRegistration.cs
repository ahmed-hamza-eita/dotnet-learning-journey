using ECommerce.Core.Interfaces;
using ECommerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Infrastructure
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection InfrastructureConfiguration(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return services;
        }
    }
}