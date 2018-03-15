using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuotingDojo.Models;
using DBConnection;
using System.Globalization;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
        private DBConnector cnx;
        public HomeController()
        {
            cnx = new DBConnector();
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        [Route("add")]
        public IActionResult add(string username, string quote)
        {
            string myquery;
 
            
            if (ModelState.IsValid)
            {

                myquery = $"INSERT INTO quotes (UserName,Quote,createdAt) Values ('{username}','{quote}',NOW())"; 

                DBConnector.Execute(myquery);
                return RedirectToAction("show");
            }
            // return RedirectToAction("DisplayData");
            else
            {
                ViewBag.errors = ModelState.Values;
                ViewBag.status = "fail";

                return View("home");
            }

        }
        [HttpGet]
        [Route("show")]
        public IActionResult show()
        {
            List<Dictionary<string, object>> allQuotes = DBConnector.Query("Select * From quotes;");

            // Console.WriteLine("==============================");
            // Console.WriteLine(allQuotes.Count);

            // Console.WriteLine("==============================");

            ViewBag.allQuotes = allQuotes;
            return View("home");

        }

    }
}
