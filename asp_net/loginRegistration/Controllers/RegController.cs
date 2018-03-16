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
    public class RegController : Controller
    {
        // [HttpGet]
        // [Route("")]
        // public IActionResult Index()
        // {
        //     // ViewBag.Errors = new List<string>();
        //     return View();
        // }

        [HttpGet]
        [Route("register")]
        public IActionResult register()
        {
            return View("registration");

        }




        [HttpPost]
        [Route("add")]

        public IActionResult add(Registration NewUser)
        {

            if (ModelState.IsValid)
            {

                string query = $"INSERT INTO users (FirstName, LastName,Email,Password) VALUES('{NewUser.FirstName}', '{NewUser.LastName}','{NewUser.Email}', '{NewUser.Password}')";
                DbConnector.Execute(query);
                return View("success");
            }
            else
            {
                return View("registration");
            }
        }
        //    public IActionResult Error()
        //     {
        //         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //     }
    }
}
