using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesMvc.Web.Libraries.Filters;
using SalesMvc.Web.Models;
using SalesMvc.Web.Repositories.Interfaces;

namespace SalesMvc.Web.Areas.Employee.Controllers
{
    [Area("Employee")]
    //[CostumerAutorization]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetAllCategory());
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

        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }
        
        [HttpPut]
        public IActionResult Update([FromForm] Category category)
        {
            return View();
        }
        
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return View();
        }
    }
}