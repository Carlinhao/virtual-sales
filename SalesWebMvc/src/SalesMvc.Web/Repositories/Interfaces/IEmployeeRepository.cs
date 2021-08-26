using System.Collections.Generic;
using System.Threading.Tasks;
using SalesMvc.Web.Models;

namespace SalesMvc.Web.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task CreateAsync(Employee employer);
        Task UpdateAsync(Employee employer);
        Task DeleteAsync(int id);

        Task<Employee> GetEmployerByIdAsync(int id);
        Task<IEnumerable<Employee>> GetAllEmployer();
        Task<Employee> Login(string email, string password);
    }
}
