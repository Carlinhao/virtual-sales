using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SalesMvc.Web.DataBase;
using SalesMvc.Web.Models;
using SalesMvc.Web.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace SalesMvc.Web.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Employee> _dBset;
        private readonly IConfiguration _configuration;

        public EmployeeRepository(ApplicationDbContext context,
                                  IConfiguration configuration)
        {
            _dbContext = context;
            _dBset = _dbContext.Set<Employee>();
            _configuration = configuration;
        }

        public async Task CreateAsync(Employee employer)
        {
            await _dBset.AddAsync(employer);
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

        public async Task<IEnumerable<Employee>> GetAllEmployer()
        {
            return await _dBset.Where(e => e.Type != "G").ToListAsync();
        }

        public async Task<Employee> GetEmployerByIdAsync(int id)
        {
            var employer = await _dBset.FirstOrDefaultAsync(x => x.Id == id);
            return employer;
        }

        public async Task UpdateAsync(Employee employer)
        {
            _dBset.Update(employer);
            _dbContext.Entry(employer).Property(x => x.Password).IsModified = false;

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdatePasswordAsync(Employee employee)
        {
            _dBset.Update(employee);
            _dbContext.Entry(employee).Property(x => x.Name).IsModified = false;
            _dbContext.Entry(employee).Property(x => x.Email).IsModified = false;
            _dbContext.Entry(employee).Property(x => x.Type).IsModified = false;

            await _dbContext.SaveChangesAsync();
        }

        public async Task<Employee> Login(string email, string password)
        {
            var result = await _dBset.Where(x => x.Email == email && x.Password == password).FirstOrDefaultAsync();
            return result;
        }

        public async Task<IPagedList<Employee>> GetAllEmployer(int? page)
        {
            var result = await _dBset.Where(e => e.Type != "G").ToPagedListAsync(page ?? 1, _configuration.GetValue<int>("NumberOfPage"));

            return result;
        }

        public async Task<IEnumerable<Employee>> GetEmployerEmail(string email)
        {
            return await _dBset.Where(e => e.Email == email).ToListAsync();
        }
    }
}
