using Microsoft.AspNetCore.Mvc;
using SalesMvc.Web.Models;

namespace SalesMvc.Web.Areas.Employee.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create([FromForm] Category category)
        {
            return View();
        }
    }
}