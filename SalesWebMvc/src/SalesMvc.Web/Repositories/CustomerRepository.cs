using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IPagedList<Customer>> GetAllCustomer(int? page, string search = null)
        {
            var costumers = _dBset.AsQueryable();
            if (string.IsNullOrEmpty(search))
                costumers = costumers.Where(x => x.Name.Contains(search.Trim()) || x.Email.Contains(search.Trim()));

            return await costumers.ToPagedListAsync(page ?? 1, _config.GetValue<int>("NumberOfPage"));
        }

        public async Task<Customer> GetCustomerByIdAsync(int id) =>
            await _dBset.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Customer> Login(string email, string password) =>
            await _dBset.Where(x => x.Email == email && x.Password == password).FirstOrDefaultAsync();

        public async Task UpdateAsync(Customer customer)
        {
            _dBset.Update(customer);
            await _dbContext.SaveChangesAsync();
        }
    }
}
