using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesMvc.Web.Libraries.Email;
using SalesMvc.Web.Libraries.Filters;
using SalesMvc.Web.Libraries.Lang;
using SalesMvc.Web.Libraries.Text;
using SalesMvc.Web.Models.Constats;
using SalesMvc.Web.Repositories.Interfaces;

namespace SalesMvc.Web.Areas.Employee.Controllers
{
    [Area("Employee")]
    [EmployerAuthorization(TypeEmployeeConstant.Manager)]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IContactEmail _contactEmail;

        public EmployeeController(IEmployeeRepository employeeRepository,
                                  IContactEmail contactEmail)
        {
            _employeeRepository = employeeRepository;
            _contactEmail = contactEmail;
        }

        public async Task<IActionResult> Index(int? page)
        {
            return View(await _employeeRepository.GetAllEmployer(page));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Models.Employee employee)
        {
            ModelState.Remove("Password");

            if (ModelState.IsValid)
            {
                employee.Password = KeyGenerator.GetUniqueKey(8);
                await _employeeRepository.CreateAsync(employee);

                _contactEmail.SendEmailToEmployee(employee);
                
                TempData["MSG_S"] = Message.MSG_S001;
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        [ValidateHttpReferer]
        public async Task<IActionResult> GeneratePassword(int id)
        {
            var employee = await _employeeRepository.GetEmployerByIdAsync(id);

            employee.Password = KeyGenerator.GetUniqueKey(8);
            await _employeeRepository.UpdatePasswordAsync(employee);
            _contactEmail.SendEmailToEmployee(employee);

            TempData["MSG_S"] = Message.MSG_S003;

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var result = await _employeeRepository.GetEmployerByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromForm] Models.Employee employee, int id)
        {
            if (ModelState.IsValid)
            {
                await _employeeRepository.UpdateAsync(employee);
                TempData["MSG_S"] = Message.MSG_S001;

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        [ValidateHttpReferer]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeRepository.DeleteAsync(id);
            TempData["MSG_S"] = Message.MSG_S002;

            return RedirectToAction(nameof(Index));
        }
    }
}
