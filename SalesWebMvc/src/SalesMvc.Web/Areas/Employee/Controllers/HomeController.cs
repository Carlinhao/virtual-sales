using Microsoft.AspNetCore.Mvc;

namespace SalesMvc.Web.Areas.Employee.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
