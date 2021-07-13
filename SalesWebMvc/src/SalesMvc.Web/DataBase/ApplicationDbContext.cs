﻿using Microsoft.EntityFrameworkCore;
using SalesMvc.Web.Models;

namespace SalesMvc.Web.DataBase
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }
    }
}
