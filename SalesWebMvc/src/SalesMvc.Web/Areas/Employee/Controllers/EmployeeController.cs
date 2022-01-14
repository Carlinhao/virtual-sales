using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesMvc.Web.Models;
using SalesMvc.Web.Repositories.Interfaces;

namespace SalesMvc.Web.Areas.Employee.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IActionResult> Index(int? page)
        {
            return View( await _employeeRepository.GetAllEmployer(page));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var result = await _employeeRepository.GetAllEmployer();
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Models.Employee employee)
        {
            if(ModelState.IsValid)
{
                await _employeeRepository.CreateAsync(employee);

                TempData["MSG_S"] = "Register save succsess.";

                return RedirectToAction(nameof(Index));
            }

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
                TempData["MSG_S"] = "Register save succsess.";

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeRepository.DeleteAsync(id);
            return View();
        }
    }
}
