using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesMvc.Web.Libraries.Filters;
using SalesMvc.Web.Libraries.Lang;
using SalesMvc.Web.Models;
using SalesMvc.Web.Repositories.Interfaces;
using X.PagedList;

namespace SalesMvc.Web.Areas.Employee.Controllers
{
    [Area("Employee")]
    [EmployerAuthorization]
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

        [ValidateHttpReferer]
        public async Task<IActionResult> Activate(int id)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(id);

            customer.Situation = customer.Situation == "A" ? customer.Situation = "D" : customer.Situation = "A";            
            await _customerRepository.UpdateAsync(customer);

            TempData["MSG_S"] = Message.MSG_S001;

            return RedirectToAction(nameof(Index));
        }
    }
}
