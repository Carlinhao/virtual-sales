using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public async Task<IActionResult> Index(int? page)
        {
            return View(await _repository.GetAllCategory(page));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var result = await _repository.GetAllCategories();
            ViewBag.Categories = result.ToList().Select(a => new SelectListItem(a.Name,
                                                                                a.Id.ToString()));

            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Category category)
        {
            if (ModelState.IsValid)
            {
                await _repository.CreateAsync(category);

                TempData["MSG_S"] = "Register save succsess";

                return RedirectToAction(nameof(Index));
            }
            var result = await _repository.GetAllCategories();
            ViewBag.Categories = result.ToList().Select(a => new SelectListItem(a.Name,
                                                                                a.Id.ToString()));
            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
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