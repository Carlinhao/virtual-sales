using Microsoft.EntityFrameworkCore;
using SalesMvc.Web.Models;

namespace SalesMvc.Web.DataBase
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<NewsLetterEmail> NewsLetterEmails { get; set; }
        public DbSet<Employees> Employees { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }
    }
}
