using CleanArchitectureApp.Application;
using CleanArchitectureApp.Domain;
using CleanArchitectureApp.Infrastructure;

namespace CleanArchitectureApp
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMainAppDI(this IServiceCollection services)
        {
            services.AddApplicationDI();
           // services.AddDomainDI();
            services.AddInfrastructureDI();
            return services;
        }
    }
}
