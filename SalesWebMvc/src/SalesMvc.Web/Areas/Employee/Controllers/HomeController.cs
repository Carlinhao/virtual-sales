using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesMvc.Web.Libraries.Filters;
using SalesMvc.Web.Libraries.Login;
using SalesMvc.Web.Repositories.Interfaces;

namespace SalesMvc.Web.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _repository;
        private readonly LoginEmployee _loginEmployee;

        public HomeController(IEmployeeRepository repository, LoginEmployee loginEmployee)
        {
            _repository = repository;
            _loginEmployee = loginEmployee;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [EmployerAuthorization]
        public IActionResult Logout()
        {
            _loginEmployee.Logout();

            return RedirectToAction("Login", "Home");
        }

        [EmployerAuthorization]
        public IActionResult Painel()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] Models.Employee employee)
        {
            var employeeRepo = await _repository.Login(employee.Email, employee.Password);

            if (employeeRepo != null)
            {
                _loginEmployee.PostEmplyee(employeeRepo);

                return new RedirectResult(Url.Action(nameof(Painel)));
            }
            else
            {
                ViewData["MSG_E"] = "User or Password invalid.";
                return View();
            }
        }

        [HttpPost]
        public IActionResult RecoverPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateNewPassword()
        {
            return View();
        }
    }
}
