using Microsoft.Extensions.DependencyInjection;
using SalesMvc.Web.Libraries.Login;
using SalesMvc.Web.Libraries.Sessions;
using SalesMvc.Web.Repositories.Interfaces;
using SalesMvc.Web.Repositories;

namespace SalesMvc.Web.IOC
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection GetServicesConfig(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<INewsLetterEmailRepository, NewsLetterEmailRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            // Session
            services.AddMemoryCache();
            services.AddSession(opt =>
            {
            });
            services.AddScoped<Session>();
            services.AddScoped<LoginCostumer>();
            services.AddScoped<LoginEmployee>();

            return services;
        }
    }
}
