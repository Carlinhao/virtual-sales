using Microsoft.AspNetCore.Mvc;

namespace SalesMvc.Web.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class HomeController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult RecoverPassword()
        {
            return View();
        }

        public IActionResult CreateNewPassword()
        {
            return View();
        }
    }
}
