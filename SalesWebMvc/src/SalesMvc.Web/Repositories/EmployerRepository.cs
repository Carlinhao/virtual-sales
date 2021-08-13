using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesMvc.Web.DataBase;
using SalesMvc.Web.Models;
using SalesMvc.Web.Repositories.Interfaces;

namespace SalesMvc.Web.Repositories
{
    public class EmployerRepository : IEmployerRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Employer> _dBset;

        public EmployerRepository(ApplicationDbContext context)
        {
            _context = context;
            _dBset = _context.Set<Employer>();
        }

        public Task CreateAsync(Employer employer)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
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
            await _context.SaveChangesAsync();
        }
    }
}
