using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesMvc.Web.DataBase;
using SalesMvc.Web.Models;
using SalesMvc.Web.Repositories.Interfaces;

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

        public Task CreateAsync(Category category)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetAllCategory()
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(Category category)
        {
            throw new System.NotImplementedException();
        }
    }
}