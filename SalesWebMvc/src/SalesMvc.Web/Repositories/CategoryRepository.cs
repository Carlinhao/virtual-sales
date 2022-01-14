using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;

        public CategoryRepository(ApplicationDbContext context,
                                  IConfiguration configuration)
        {
            _context = context;
            _dbset = _context.Set<Category>();
            _configuration = configuration;
        }

        public async Task CreateAsync(Category category)
        {
            await _dbset.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _dbset.FirstOrDefaultAsync(a => a.Id == id);
            if (category == null)
                return;

            _dbset.Remove(category);
            await _context.SaveChangesAsync(); 
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _dbset.ToListAsync();
        }

        public async Task<IPagedList<Category>> GetAllCategory(int? page)
        {
            var result = await _dbset.Include(a => a.CategoryFather).ToPagedListAsync(page ?? 1, _configuration.GetValue<int>("NumberOfPage"));
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