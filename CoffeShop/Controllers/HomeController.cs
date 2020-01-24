using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoffeShop.Models;

namespace CoffeShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Welcome(Customer cus,string passwordtwo,string firstname, string lastname, string phonenumber,string email, string password)
        {
            ViewBag.Name = firstname;
            ViewBag.Last = lastname;
            ViewBag.Phone = phonenumber;
            ViewBag.Email = email;

            if (password == passwordtwo)
            {
                return View();
            }
            else
            {
                return IncorrectPassword();
            }
            
        }
        public IActionResult IncorrectPassword()
        {
            return View("IncorrectPassword");
        }
        public IActionResult Registration()
        {
            return View();
        }
        //need one action to load our RegistrationPage, also need a view
        //need one action to take those user inputs, and display the user name in a new view
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
