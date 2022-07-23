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
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Product> _dBset;
        private readonly IConfiguration _configuration;

        public ProductRepository(ApplicationDbContext dbContext,
                                 DbSet<Product> dBset,
                                 IConfiguration configuration)
        {
            _dbContext = dbContext;
            _dBset = dBset;
            _configuration = configuration;
        }

        public async Task CreateAsync(Product product)
        {
            await _dBset.AddAsync(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id) =>
            await _dBset.FirstOrDefaultAsync(x => x.Id == id);

        public Task<IPagedList<Product>> GetAllProduct(int? page, string search)
            => _dBset.Include(i => i.Imagens)
                     .Where(a => a.Name.Contains(search.Trim()))
                     .ToPagedListAsync(page ?? 1, _configuration.GetValue<int>("NumberOfPage"));

        public async Task<Product> GetProductByIdAsync(int id) =>
            await _dBset.Include(i => i.Imagens).Where(x => x.Id == id).FirstOrDefaultAsync();

        public async Task UpdateAsync(Product product)
        {
            _dBset.Update(product);
            await _dbContext.SaveChangesAsync();
        }
    }
}
