using System.Collections.Generic;
using System.Threading.Tasks;
using SalesMvc.Web.Models;
using X.PagedList;

namespace SalesMvc.Web.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> Login(string email, string password);
        Task CreateAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(int id);
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<IPagedList<Customer>> GetAllCustomer(int? page, string search = null);
    }
}
