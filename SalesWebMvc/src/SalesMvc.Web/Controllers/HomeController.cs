using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesMvc.Web.Libraries.Email;
using SalesMvc.Web.Models;
using SalesMvc.Web.Repositories.Interfaces;

namespace SalesMvc.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerRepository _repository;
        private readonly INewsLetterEmailRepository _newsLetterEmailRepository;

        public HomeController(ICustomerRepository repository,
                              INewsLetterEmailRepository newsLetterEmailRepository)
        {
            _repository = repository;
            _newsLetterEmailRepository = newsLetterEmailRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromForm] NewsLetterEmail newsLetterEmail)
        {
            if(ModelState.IsValid)
            {
                await _newsLetterEmailRepository.RegisterEmail(newsLetterEmail);

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

        [HttpGet]
        public IActionResult RegisterCostumer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCostumer([FromForm] Customer customer)
        {
            if (ModelState.IsValid)
            {
               await _repository.CreateAsync(customer);

                TempData["MSG_S"] = "Register with success!";

                // TODO - Implement Diferent redirection
                return RedirectToAction(nameof(RegisterCostumer));
            }
            return View();
        }

        public IActionResult ShoppingCart()
        {
            return View();
        }
    }
}
