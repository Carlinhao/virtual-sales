using System.Threading.Tasks;
using SalesMvc.Web.Models;
using X.PagedList;

namespace SalesMvc.Web.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task CreateAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);

        Task<Product> GetProductByIdAsync(int id);
        Task<IPagedList<Product>> GetAllProduct(int? page, string search);
    }
}
