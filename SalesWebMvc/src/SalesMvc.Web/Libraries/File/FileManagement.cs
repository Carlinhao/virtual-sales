using System.IO;
using Microsoft.AspNetCore.Http;

namespace SalesMvc.Web.Libraries
{
	public class FileManagement
	{
		public static string SaveProductImage(IFormFile file)
		{
			var fileName = Path.GetFileName(file.FileName);
			var completePaht = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/temp", fileName);

			using var stream = new FileStream(completePaht, FileMode.Create);
			file.CopyTo(stream);

			return Path.Combine("/uploads/temp", fileName);
		}

		public static bool DeleteProductImage(string filePath)
		{
			var completePaht = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filePath.TrimStart('/'));
			if (File.Exists(completePaht)) 
			{
				File.Delete(completePaht);
				return true;
			}

			return false;
		}
	}
}
