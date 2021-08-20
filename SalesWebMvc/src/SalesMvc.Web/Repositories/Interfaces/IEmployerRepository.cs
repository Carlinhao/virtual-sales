using System.Collections.Generic;
using System.Threading.Tasks;
using SalesMvc.Web.Models;

namespace SalesMvc.Web.Repositories.Interfaces
{
    public interface IEmployerRepository
    {
        Task CreateAsync(Employees employer);
        Task UpdateAsync(Employees employer);
        Task DeleteAsync(int id);

        Task<Employees> GetEmployerByIdAsync(int id);
        Task<IEnumerable<Employees>> GetAllEmployer();
        Task<Employees> Login(string email, string password);
    }
}
