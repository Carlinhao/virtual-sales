using Microsoft.AspNetCore.Mvc;
using SalesMvc.Web.Libraries.Email;
using SalesMvc.Web.Models;

namespace SalesMvc.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult ActionContact()
        {
            Contact contact = new Contact();
            contact.Name = HttpContext.Request.Form["name"];
            contact.Email = HttpContext.Request.Form["email"];
            contact.Text = HttpContext.Request.Form["text"];

            ContactEmail.SendContactEmail(contact);

            return View("Contact");
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult RegisterCostumer()
        {
            return View();
        }

        public IActionResult ShoppingCart()
        {
            return View();
        }
    }
}
