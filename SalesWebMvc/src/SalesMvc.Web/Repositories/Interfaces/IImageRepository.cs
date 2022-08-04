using SalesMvc.Web.Models;
using System.Threading.Tasks;

namespace SalesMvc.Web.Repositories.Interfaces
{
    public interface IImageRepository
    {
        Task CreateAsync(Image image);
        Task DeleteAsync(int id);
        Task DeleteImageProductAsync(int productId);
    }
}
