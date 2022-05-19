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

        public Task CreateAsync(Product product)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IPagedList<Product>> GetAllProduct(int? page, string search)
        {
            throw new System.NotImplementedException();
        }

        public Task<Product> GetEmployerByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(Product product)
        {
            throw new System.NotImplementedException();
        }
    }
}
