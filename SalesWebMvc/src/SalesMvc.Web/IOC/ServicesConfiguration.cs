using Microsoft.Extensions.DependencyInjection;
using SalesMvc.Web.Libraries.Login;
using SalesMvc.Web.Libraries.Sessions;
using SalesMvc.Web.Repositories.Interfaces;
using SalesMvc.Web.Repositories;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;
using SalesMvc.Web.Libraries.Email;

namespace SalesMvc.Web.IOC
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection GetServicesConfig(this IServiceCollection services, IConfiguration configuration)
        {
            // Repositories
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<INewsLetterEmailRepository, NewsLetterEmailRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();

            // Session
            services.AddMemoryCache();
            services.AddSession(opt =>
            {
            });
            services.AddScoped<Session>();
            services.AddScoped<LoginCostumer>();
            services.AddScoped<LoginEmployee>();

            // SMTP
            services.AddScoped(options =>
            {
                SmtpClient smtpClient = new SmtpClient()
                {
                    Host = configuration.GetValue<string>("ServerSMTP"),
                    Port = configuration.GetValue<int>("ServerPort"),
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(configuration.GetValue<string>("UserName"),
                                                        configuration.GetValue<string>("Password")),
                    EnableSsl = true
                };

                return smtpClient;
            });
            services.AddScoped<ContactEmail>();

            return services;
        }
    }
}
