using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesMvc.Web.DataBase;
using SalesMvc.Web.Models;
using SalesMvc.Web.Repositories.Interfaces;

namespace SalesMvc.Web.Repositories
{
    public class EmployerRepository : IEmployerRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Employer> _dBset;

        public EmployerRepository(ApplicationDbContext context)
        {
            _dbContext = context;
            _dBset = _dbContext.Set<Employer>();
        }

        public async Task CreateAsync(Employer employer)
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

        public async Task<IEnumerable<Employer>> GetAllEmployer()
        {
            return await _dBset.ToListAsync();
        }

        public async Task<Employer> GetEmployerByIdAsync(int id)
        {
            var employer = await _dBset.FirstOrDefaultAsync(x => x.Id == id);
            return employer;
        }

        public async Task UpdateAsync(Employer employer)
        {
            _dBset.Update(employer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Employer> Login(string email, string password)
        {
            var result = await _dBset.Where(x => x.Email == email && x.Password == password).FirstOrDefaultAsync();
            return result;
        }
    }
}
