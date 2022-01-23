using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesMvc.Web.Libraries.Lang;
using SalesMvc.Web.Repositories.Interfaces;

namespace SalesMvc.Web.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
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
            if (ModelState.IsValid)
            {
                // TODO Generate password.
                await _employeeRepository.CreateAsync(employee);

                TempData["MSG_S"] = Message.MSG_S001;
                //  send e-mail
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GeneratePassword()
        {
            // TODO Generate password, salve new password, sen
            return View();
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
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeRepository.DeleteAsync(id);
            TempData["MSG_S"] = Message.MSG_S002;

            return RedirectToAction(nameof(Index));
        }
    }
}
