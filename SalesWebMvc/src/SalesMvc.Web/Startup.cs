using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SalesMvc.Web.DataBase;
using SalesMvc.Web.Libraries.Login;
using SalesMvc.Web.Libraries.Sessions;
using SalesMvc.Web.Repositories;
using SalesMvc.Web.Repositories.Interfaces;

namespace SalesMvc.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<ICustomerRepository, CustomerRepository>(); 
            services.AddScoped<INewsLetterEmailRepository, NewsLetterEmailRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddControllersWithViews();
            services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlServer(Configuration.GetConnectionString("SQL_SERVER")));
            services.AddMemoryCache();
            services.AddSession(opt =>
            {
            });
            services.AddScoped<Session>();
            services.AddScoped<LoginCostumer>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
