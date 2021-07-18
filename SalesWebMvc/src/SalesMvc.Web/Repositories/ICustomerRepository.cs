using System.Collections.Generic;
using System.Threading.Tasks;
using SalesMvc.Web.Models;

namespace SalesMvc.Web.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> Login(string email, string password);
        Task CreateAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(int id);
        Task<Customer> GetCustomerAsync(int id);
        Task<List<Customer>> GetAllCustomerById();
    }
}
