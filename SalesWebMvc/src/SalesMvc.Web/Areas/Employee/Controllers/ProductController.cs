using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SalesMvc.Web.Libraries.Filters;
using SalesMvc.Web.Libraries.Lang;
using SalesMvc.Web.Models;
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

		[HttpPost]
		public async Task<IActionResult> Create(Product product)
		{
			if (ModelState.IsValid) {
				await _productRepository.CreateAsync(product);
				TempData["MSG_S"] = Message.MSG_S001;

				return RedirectToAction(nameof(Index));
			}

			var result = await _categoryRepository.GetAllCategories();

			ViewBag.Categories = result.AsEnumerable().Select(a => new SelectListItem(a.Name,
																				a.Id.ToString()));

			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Update(int id)
		{
			var result = await _categoryRepository.GetAllCategories();

			ViewBag.Categories = result.AsEnumerable().Select(a => new SelectListItem(a.Name,
																				a.Id.ToString()));
			var product = await _productRepository.GetProductByIdAsync(id);
			return View(product);
		}

		[HttpPost]
		public async Task<IActionResult> Update(Product product, int id)
		{
			if (ModelState.IsValid) 
			{
				await _productRepository.UpdateAsync(product);

				TempData["MSG_S"] = Message.MSG_S001;

				return RedirectToAction(nameof(Index));
			}
			var result = await _categoryRepository.GetAllCategories();

			ViewBag.Categories = result.AsEnumerable().Select(a => new SelectListItem(a.Name,
																				a.Id.ToString()));
			return View(product);
		}
	}
}
																							   