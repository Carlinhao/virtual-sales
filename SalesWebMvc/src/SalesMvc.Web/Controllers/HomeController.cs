﻿using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult RegisterCostumer()
        {
            return View();
        }
    }
}
