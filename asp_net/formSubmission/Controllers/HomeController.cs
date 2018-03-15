using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using formSubmission.Models;

namespace formSubmission.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            // ViewBag.Errors = new List<string>();
            return View();
        }
        [HttpPost]
        [Route("add")]

        public IActionResult Method(string firstName, string lastName, int age, string Email, string Password)
        {
            var NewUser = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                Email = Email,
                Password = Password
            };
            if (TryValidateModel(NewUser)==true)

           // if (ModelState.IsValid)
            {
                return View("success");
            }
            else
            {
                ViewBag.errors = ModelState.Values;
                return View("index");
            }
        }



        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
