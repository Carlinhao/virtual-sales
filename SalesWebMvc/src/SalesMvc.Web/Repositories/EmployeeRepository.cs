﻿using Microsoft.EntityFrameworkCore;
using SalesMvc.Web.DataBase;
using SalesMvc.Web.Models;
using SalesMvc.Web.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesMvc.Web.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Employee> _dBset;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _dbContext = context;
            _dBset = _dbContext.Set<Employee>();
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
            return await _dBset.ToListAsync();
        }

        public async Task<Employee> GetEmployerByIdAsync(int id)
        {
            var employer = await _dBset.FirstOrDefaultAsync(x => x.Id == id);
            return employer;
        }

        public async Task UpdateAsync(Employee employer)
        {
            _dBset.Update(employer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Employee> Login(string email, string password)
        {
            var result = await _dBset.Where(x => x.Email == email && x.Password == password).FirstOrDefaultAsync();
            return result;
        }
    }
}