using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesMvc.Web.DataBase;
using SalesMvc.Web.Models;
using SalesMvc.Web.Repositories.Interfaces;

namespace SalesMvc.Web.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Customer> _dBset;
        public CustomerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dBset = dbContext.Set<Customer>();
        }

        public async Task CreateAsync(Customer customer)
        {
            await _dBset.AddAsync(customer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var customer = await _dBset.FirstOrDefaultAsync( x => x.Id == id);
            if (customer is null)
                return;

            _dBset.Remove(customer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Customer>> GetAllCustomer()
        {
            return await _dBset.ToListAsync();
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
