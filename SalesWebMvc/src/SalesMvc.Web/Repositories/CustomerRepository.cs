﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SalesMvc.Web.DataBase;
using SalesMvc.Web.Models;
using SalesMvc.Web.Repositories.Interfaces;
using X.PagedList;

namespace SalesMvc.Web.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Customer> _dBset;
        private readonly IConfiguration _config;
        public CustomerRepository(ApplicationDbContext dbContext, IConfiguration config)
        {
            _dbContext = dbContext;
            _dBset = _dbContext.Set<Customer>();
            _config = config;
        }

        public async Task CreateAsync(Customer customer)
        {
            await _dBset.AddAsync(customer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var customer = await _dBset.FirstOrDefaultAsync(x => x.Id == id);
            if (customer is null)
                return;

            _dBset.Remove(customer);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<IPagedList<Customer>> GetAllCustomer(int? page)
        {
            var result = await _dBset.ToPagedListAsync(page ?? 1, _config.GetValue<int>("NumberOfPage"));
            return result;
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            var customer = await _dBset.FirstOrDefaultAsync(x => x.Id == id);
            return customer;
        }

        public async Task<Customer> Login(string email, string password)
        {
            var result = await _dBset.Where(x => x.Email == email && x.Password == password).FirstOrDefaultAsync();
            return result;
        }

        public async Task UpdateAsync(Customer customer)
        {
            _dBset.Update(customer);
            await _dbContext.SaveChangesAsync();
        }
    }
}
