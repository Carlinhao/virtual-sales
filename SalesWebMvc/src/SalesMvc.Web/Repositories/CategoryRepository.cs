using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
            return await _dbset.ToPagedListAsync(page, 10);            
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