using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using loginRegistration.Models;
using DbConnection;

namespace loginRegistration.Controllers
{
    public class UserLoginController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            // ViewBag.Errors = new List<string>();
            return View();
        }

 
        [HttpGet]
        [Route("/log")]
        public IActionResult log()
        {
            return View("login");

        }


 
        [HttpPost]
        [Route("login")]

        public IActionResult login(Login myUser)
        {
            string query = "SELECT * FROM users where Email = myUser.Email";
            var info = DbConnector.Query(query);
            if (info.Count == 1)

                return View("Success");
            else
                return View("login");
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
