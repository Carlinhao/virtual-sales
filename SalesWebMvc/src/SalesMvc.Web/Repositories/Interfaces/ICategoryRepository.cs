using SalesMvc.Web.Models;
using X.PagedList;

namespace SalesMvc.Web.Repositories.Interfaces
{
    public interface ICategoryRepository 
    {
        Task CreateAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(int id);
        Task<Category> GetByIdAsync(int id);
        Task<IEnumerable<Category>> GetAllCategories();
        Task<IPagedList<Category>> GetAllCategory(int? page);
    }
}