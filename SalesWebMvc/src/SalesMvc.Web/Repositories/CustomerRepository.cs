using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesMvc.Web.DataBase;
using SalesMvc.Web.Models;

namespace SalesMvc.Web.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private DbSet<Customer> _dBset;
        public CustomerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dBset = dbContext.Set<Customer>();
        }

        public Task CreateAsync(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetAllCustomerById()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
