using System.Threading.Tasks;
using SalesMvc.Web.Models;
using System.Collections.Generic;

namespace SalesMvc.Web.Repositories.Interfaces
{
    public interface ICategoryRepository 
    {
        Task CreateAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(int id);
        Task<Category> GetByIdAsync(int id);
        Task<IEnumerable<Category>> GetAllCategory();
    }
}