using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Query;
using SalesMvc.Web.DataBase;
using SalesMvc.Web.Models;
using SalesMvc.Web.Repositories.Interfaces;
using X.PagedList;

namespace SalesMvc.Web.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Category> _dbset;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbset = _context.Set<Category>();
        }

        public async Task CreateAsync(Category category)
        {
            await _dbset.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _dbset.FindAsync(id);
            if (category == null)
                return;
            _dbset.Remove(category);
            await _context.SaveChangesAsync(); 
        }

        public async Task<IPagedList<Category>> GetAllCategory(int? page)
        {
            var result = await _dbset.Include(a => a.CategoryFather).ToPagedListAsync(page ?? 1, 10);
            return result;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var customer = await _dbset.FirstOrDefaultAsync(x => x.Id == id);
            return customer;
        }

        public async Task UpdateAsync(Category category)
        {
            _dbset.Update(category);
            await _context.SaveChangesAsync();
        }
    }
}