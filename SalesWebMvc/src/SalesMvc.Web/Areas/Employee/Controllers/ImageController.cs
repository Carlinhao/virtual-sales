using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesMvc.Web.Libraries;

namespace SalesMvc.Web.Areas.Employee.Controllers
{
	[Area("Employee")]
	public class ImageController : Controller
	{
		[HttpPost]
		public IActionResult Import(IFormFile file)
		{
			if (file is null)
				return BadRequest();

			var pathFile = FileManagement.SaveProductImage(file);
			if (pathFile.Length > 0)
				return Ok(new { caminho = pathFile });

			return new StatusCodeResult(500);
		}

		public IActionResult Delete(string pathFile)
		{
			if (FileManagement.DeleteProductImage(pathFile))
				return Ok();

			return BadRequest();
		}
	}
}
