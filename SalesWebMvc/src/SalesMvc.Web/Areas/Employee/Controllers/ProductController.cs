using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SalesMvc.Web.Repositories.Interfaces;

namespace SalesMvc.Web.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

		public ProductController(IProductRepository productRepository, 
                                 ICategoryRepository categoryRepository)
		{
			_productRepository = productRepository;
			_categoryRepository = categoryRepository;
		}

		[HttpGet]
        public async Task<IActionResult> Index(int? page, string search)
        {
            var result = await _productRepository.GetAllProduct(page, search);
            return View(result);
        }

		[HttpGet]
		public async Task<IActionResult> Create()
        {
            var result = await _categoryRepository.GetAllCategories();
			ViewBag.Categories = result.AsEnumerable().Select(a => new SelectListItem(a.Name,
																				a.Id.ToString()));

			return View();
        }
    }
}
