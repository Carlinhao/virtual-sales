using Microsoft.AspNetCore.Mvc;

namespace SalesMvc.Web.Areas.Employee.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}

