using App.Application.Interfaces;
using App.Application.Services;
using App.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Application
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
                //.UseLazyLoadingProxies()
            });

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddTransient<ProductService>();
            services.AddTransient<CategoryService>();
            services.AddTransient<UserService>();

            services.AddTransient<IEmailService, SmtpEmailService>();

            return services;
        }
    }
}
