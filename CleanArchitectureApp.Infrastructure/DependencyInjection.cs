using CleanArchitectureApp.Domain.Interfaces;
using CleanArchitectureApp.Domain.Model;
using CleanArchitectureApp.Infrastructure.Data;
using CleanArchitectureApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace CleanArchitectureApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer("Server=DESKTOP-8CV7N11;Database=CleanArchitectureApp;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True;");
            });
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}
