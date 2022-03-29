using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesMvc.Web.DataBase;
using SalesMvc.Web.Models;
using SalesMvc.Web.Repositories.Interfaces;

namespace SalesMvc.Web.Repositories
{
    public class NewsLetterEmailRepository : INewsLetterEmailRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<NewsLetterEmail> _dBset;
        public NewsLetterEmailRepository(ApplicationDbContext context)
        {
            _context = context;
            _dBset = _context.Set<NewsLetterEmail>();
        }

        public async Task<IEnumerable<NewsLetterEmail>> GetAllAsync() =>
            await _dBset.ToListAsync();

        public async Task RegisterEmail(NewsLetterEmail newsLetter)
        {
            await _dBset.AddAsync(newsLetter);
            await _context.SaveChangesAsync();
        }
    }
}
