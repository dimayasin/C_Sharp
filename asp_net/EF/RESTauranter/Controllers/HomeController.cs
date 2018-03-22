using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using RESTauranter.Models;

namespace RESTauranter.Controllers
{
    public class HomeController : Controller
    {
        private RestaurantContext _context;
        public HomeController(RestaurantContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {


            return View();
        }

        [HttpPost]
        [Route("addRev")]
        public IActionResult addRev(Restaurant newRev)
        {
            _context.Add(newRev);
            _context.SaveChanges();


            return RedirectToAction("Show");

        }

        [HttpGet]
        [Route("show")]
        public IActionResult Show()
        {
            List<Restaurant> Reviewers = _context.restaurants.ToList();
            ViewBag.Reviews = Reviewers;
            return View("Show");
        }
    }
}
