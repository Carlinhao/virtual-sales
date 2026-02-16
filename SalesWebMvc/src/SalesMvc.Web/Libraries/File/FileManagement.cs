using System.IO;
using Microsoft.AspNetCore.Http;

namespace SalesMvc.Web.Libraries
{
	public static class FileManagement
	{
		public static string SaveProductImage(IFormFile file)
		{
			var fileName = Path.GetFileName(file.FileName);
			var completePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/temp", fileName);

			using var stream = new FileStream(completePath, FileMode.Create);
			file.CopyTo(stream);

			return Path.Combine("/uploads/temp", fileName);
		}

		public static bool DeleteProductImage(string filePath)
		{
			var completePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filePath.TrimStart('/'));
			if (File.Exists(completePath)) 
			{
				File.Delete(completePath);
				return true;
			}

			return false;
		}
	}
}
