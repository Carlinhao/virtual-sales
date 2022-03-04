using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesMvc.Web.Models;
using SalesMvc.Web.Repositories.Interfaces;
using X.PagedList;

namespace SalesMvc.Web.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IActionResult> Index(int? page)
        {
            IPagedList<Customer> customers = await _customerRepository.GetAllCustomer(page);

            return View(customers);
        }

        public IActionResult Activate()
        {
            return View();
        }
    }
}
