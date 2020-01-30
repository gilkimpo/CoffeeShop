using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoffeShop.Models;
using Microsoft.AspNetCore.Http;

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
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(string passwordtwo,
            string firstname,
            string lastname,
            string phonenumber, string email, string password)
        {
            if (password == passwordtwo)
            {
                return View();
            }
            else
            {
                return IncorrectPassword();
            }
            
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            using (var db = new ShopDBContext())
            {
                var user = db.Users.FirstOrDefault(u => u.UserName == username);
                if (user != null)
                {
                    //check password if user is not null
                    if (password == user.PassWord)
                    {
                        HttpContext.Session.SetString("session_username", user.UserName);
                        //TODO: CHANGE TO APPROPRIATE VIEW TO GO TO
                        return View("RegisterSuccess");  //RegisterSuccess returned here originally
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Password is incorrect";
                        return View();
                    }
                }
                else // user was Null, not found in database
                {
                    ViewBag.ErrorMessage = "User not Found";
                    return View();
                }
            }
        }
                               
       
        public IActionResult Shop()
        {
            return View();
        }
        public IActionResult IncorrectPassword()
        {
            return View("IncorrectPassword");
        }
        [HttpPost]
        public IActionResult MakeNewUser (Users U)
        {
            
                using (var db = new ShopDBContext())
                {
                    var newUser = new Users
                    {
                        Email = U.Email,
                        FirstName = U.FirstName,
                        LastName = U.LastName,
                        UserName = U.UserName,
                        PassWord = U.PassWord,
                        Funds = 100
                    };
                    db.Users.Add(newUser);
                    if (db.SaveChanges() > 0)
                    {
                        //Do the work to create new user;
                        //if successful return view Register Success; if not (go back to register page or another view)
                        return View("RegisterSuccess");
                    }
                    else
                    {
                        // Was not able to save user to database for whatever reason.
                        ViewBag.ErrorMessage("Was not successful.");
                        return View("Register");
                    }
                }            
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
