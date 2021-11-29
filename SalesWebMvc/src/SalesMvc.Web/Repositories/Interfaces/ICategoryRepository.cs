using System.Threading.Tasks;
using SalesMvc.Web.Models;
using System.Collections.Generic;
using X.PagedList;

namespace SalesMvc.Web.Repositories.Interfaces
{
    public interface ICategoryRepository 
    {
        Task CreateAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(int id);
        Task<Category> GetByIdAsync(int id);
        Task<IPagedList<Category>> GetAllCategory(int? page);
    }
}