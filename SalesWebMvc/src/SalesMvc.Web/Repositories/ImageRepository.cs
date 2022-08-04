using SalesMvc.Web.Repositories.Interfaces;
using SalesMvc.Web.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesMvc.Web.DataBase;
using System.Linq;

namespace SalesMvc.Web.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Image> _dBset;

        public ImageRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dBset = _dbContext.Set<Image>();
        }

        public async Task CreateAsync(Image image)
        {
            await _dBset.AddAsync(image);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var image = await _dBset.FindAsync(id);
            if (image is null)
                return;

            _dBset.Remove(image);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteImageProductAsync(int productId)
        {
            var images = await _dBset.Where(x => x.ProductId == productId).ToListAsync();
            if (images is null)
                return;

            _dBset.RemoveRange(images);
            await _dbContext.SaveChangesAsync();
        }
    }
}
