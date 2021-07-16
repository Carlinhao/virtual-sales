using System;
using Microsoft.AspNetCore.Mvc;
using SalesMvc.Web.Libraries.Email;
using SalesMvc.Web.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text;
using SalesMvc.Web.DataBase;

namespace SalesMvc.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([FromBody] NewsLetterEmail newsLetterEmail)
        {
            if(ModelState.IsValid)
            {
                _context.NewsLetterEmails.Add(newsLetterEmail);
                _context.SaveChanges();

                TempData["MSG_S"] = "Send email with success!";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult ActionContact()
        {
            try
            {
                Contact contact = new Contact
                {
                    Name = HttpContext.Request.Form["name"],
                    Email = HttpContext.Request.Form["email"],
                    Text = HttpContext.Request.Form["text"]
                };               

                var errorList = new List<ValidationResult>();
                var context = new ValidationContext(contact);
                bool isValid = Validator.TryValidateObject(contact, context, errorList, true);

                if (isValid)
                {
                    ContactEmail.SendContactEmail(contact);
                    ViewData["MSG_S"] = "Send message success!";
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in errorList)
                    {
                        sb.Append(item.ErrorMessage + "<br />");
                    }

                    ViewData["MSG_E"] = sb.ToString();
                    ViewData["CONTACT"] = contact;
                }

            }
            catch (Exception)
            {
                ViewData["MSG_E"] = "Ops.. something is wrong!";
                
                // TODO - Write log
            }

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
