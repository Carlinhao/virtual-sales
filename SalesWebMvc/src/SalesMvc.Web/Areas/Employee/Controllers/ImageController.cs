using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesMvc.Web.Libraries;

namespace SalesMvc.Web.Areas.Employee.Controllers
{
	[Area("Employee")]
	[Controller]
	public class ImageController : Controller
	{
		public IActionResult Import(IFormFile image)
		{
			var pathFile = FileManagement.SaveProductImage(image);
			if (pathFile.Length > 0)
				return Ok(new { caminho = pathFile });

			return new StatusCodeResult(500);
		}

		public async Task<IActionResult> Delete(string pathFile)
		{
			if (FileManagement.DeleteProductImage(pathFile))
				return Ok();

			return BadRequest();
		}
	}
}
