using Microsoft.AspNetCore.Mvc;

namespace SalesMvc.Web.Areas.Employee.Controllers
{
    public class EmployeeController : Controller
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
        public IActionResult Create([FromForm] Models.Employee employee)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update([FromForm] Models.Employee employee, int id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View();
        }
    }
}
