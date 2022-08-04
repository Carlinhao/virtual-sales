using System.Threading.Tasks;
using SalesMvc.Web.Models;
using SalesMvc.Web.Repositories.Interfaces;

namespace SalesMvc.Web.Repositories
{
    public class ImageRepository : IImageRepository
    {
        public Task CreateAsync(Image image)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteImageProductAsync(int productId)
        {
            throw new System.NotImplementedException();
        }
    }
}
