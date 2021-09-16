using System.Threading.Tasks;
using SalesMvc.Web.Models;

namespace SalesMvc.Web.Repositories.Interfaces
{
    public interface ICategoryRepository 
    {
        Task CreateAsync(Category category);
    }
}