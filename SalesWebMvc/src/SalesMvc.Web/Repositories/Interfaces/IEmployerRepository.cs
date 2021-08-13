using System.Collections.Generic;
using System.Threading.Tasks;
using SalesMvc.Web.Models;

namespace SalesMvc.Web.Repositories.Interfaces
{
    public interface IEmployerRepository
    {
        Task CreateAsync(Employer employer);
        Task UpdateAsync(Employer employer);
        Task DeleteAsync(int id);

        Task<Employer> GetEmployerByIdAsync(int id);
        Task<IEnumerable<Employer>> GetAllEmployer();
        Task<Employer> Login(string email, string password);
    }
}
