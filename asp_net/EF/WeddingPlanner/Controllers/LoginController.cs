using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;




namespace WeddingPlanner.Controllers
{
    public class LoginController : Controller
    {
        private WeddingPlanContext _context;

        public LoginController(WeddingPlanContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            int? userid = HttpContext.Session.GetInt32("UserId");
            if (userid == null)
            HttpContext.Session.SetInt32("UserId", 0);

            return View();
        }
            
        [HttpGet]
        [Route("log")]
        public IActionResult log()
        {
            
                return View("login");
        }

        [HttpGet]
        [Route("registration")]
        public IActionResult registration()
        {
            
                return View("registration");
        }


 
        [HttpPost]
        [Route("addUser")]
        public IActionResult addUser(RegisterViewModel newUser)
        {
            if (ModelState.IsValid)
            {
                User ThisUser = _context.RSVPS.SingleOrDefault(user => user.Email == newUser.Email);

                if (ThisUser != null)
                {
                    ViewBag.Message = "A user with this email already exists. Try another.";
                    return View("login");
                }

                User userAdded = new User
                {
                    UserFirstName = newUser.FirstName,
                    UserLastName = newUser.LastName,
                    Email = newUser.Email,
                    Password = newUser.Password,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                _context.Add(userAdded);
                _context.SaveChanges();
                userAdded = _context.RSVPS.SingleOrDefault(user => user.Email == userAdded.Email);
                HttpContext.Session.SetInt32("UserId",userAdded.UserId);
                ViewBag.UserId= userAdded.UserId;
                return RedirectToAction("Show");


            }
            else
                return View("/");

        }

        [HttpGet]
        [Route("logout")]
        public IActionResult logout()
        {
            // HttpContext.Session.Clear();
            return View("index");

        }





        [HttpPost]
        [Route("login")]

        public IActionResult login(string Email, string Password)
        {
            User FoundUser = _context.RSVPS.SingleOrDefault(user => user.Email == Email && user.Password == Password);
            if (FoundUser == null)
            {
                ViewBag.Message = "Login failed.";
                return View("/");
            }
            else
            {
                HttpContext.Session.SetInt32("UserId",FoundUser.UserId);
                ViewBag.UserId=FoundUser.UserId;
                return RedirectToAction("Show");
            }
        }
        
        [HttpGet]
        [Route("Show")]
        public IActionResult Show()
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if (UserId != null)
            {
            List<Wedding> AllWeddings = _context.Weddings
                  .Include(wedding => wedding.Creator)
                  .Include(wedding => wedding.Guests)
                  .ThenInclude(gsts => gsts.User).ToList();
                List<Dictionary<string, object>> WeddingList = new List<Dictionary<string, object>>();
                foreach (Wedding wedding in AllWeddings)
                {
                  bool owned = false;
                  bool RSVPed = false;
                  int RSVPs = 0;
                  if (HttpContext.Session.GetInt32("UserId") == wedding.UserId)
                  {
                    owned = true;
                  }
                  foreach (var gsts in wedding.Guests)
                  {
                    if (gsts.UserId == HttpContext.Session.GetInt32("UserId"))
                    {
                      RSVPed = true;
                    }
                    ++RSVPs;
                  }
                  Dictionary<string, object> newWeddingThing = new Dictionary<string, object>();
                  newWeddingThing.Add("WeddingId", wedding.WeddingID);
                  newWeddingThing.Add("WedderOne", wedding.WedderOne);
                  newWeddingThing.Add("WedderTwo", wedding.WedderTwo);
                  newWeddingThing.Add("WeddingDate", wedding.WeddingDate);
                  newWeddingThing.Add("Owned", owned);
                  newWeddingThing.Add("RSVPs", RSVPs);
                  newWeddingThing.Add("RSVPed", RSVPed);
                  WeddingList.Add(newWeddingThing);
                }
                ViewBag.Weddings = WeddingList;
                return View("Dashboard");
            }

            else
            {
                return RedirectToAction("Index");
            }
        }

    }

    
}
