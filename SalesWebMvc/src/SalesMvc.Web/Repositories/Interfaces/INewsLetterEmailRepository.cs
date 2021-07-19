using System.Collections.Generic;
using System.Threading.Tasks;
using SalesMvc.Web.Models;

namespace SalesMvc.Web.Repositories.Interfaces
{
    public interface INewsLetterEmailRepository
    {
        Task RegisterEmail(NewsLetterEmail newsLetter);
        Task<IEnumerable<NewsLetterEmail>> GetAllAsync();
    }
}
