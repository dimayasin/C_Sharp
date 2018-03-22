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

    public class WeddingController : Controller
    {
        private WeddingPlanContext _context;

        public WeddingController(WeddingPlanContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("newWed")]
        public IActionResult newWed()
        {
            return View("NewWedding");
        }

        [HttpGet]
        [Route("Delete/{WeddingId}")]
        public IActionResult Delete(int WeddingId)
        {
            Wedding deleteTarget = _context.Weddings.SingleOrDefault(
              w => w.UserId == (int)HttpContext.Session.GetInt32("UserId") &&
              w.WeddingID == WeddingId);
            if (deleteTarget != null)
            {
                _context.Weddings.Remove(deleteTarget);
                _context.SaveChanges();
            }
            return RedirectToAction("Show","Login");
        }

        [HttpGet]
        [Route("UnRSVP/{WeddingId}")]
        public IActionResult UnRSVP(int WeddingId)
        {
            Guest NoRSVP = _context.Guests.SingleOrDefault(
              r => r.UserId == (int)HttpContext.Session.GetInt32("UserId") &&
              r.WeddingID == WeddingId);
            if (NoRSVP != null)
            {
                _context.Guests.Remove(NoRSVP);
                _context.SaveChanges();
            }
            return RedirectToAction("Show","Login");
        }

        [HttpGet]
        [Route("RSVPok/{WeddingId}")]
        public IActionResult RSVPok(int WeddingId)
        {
            Guest newRSVP = new Guest
            {
                UserId = (int)HttpContext.Session.GetInt32("UserId"),
                WeddingID = WeddingId
            };
            Guest existingRSVP = _context.Guests.SingleOrDefault(
              r => r.UserId == (int)HttpContext.Session.GetInt32("UserId") &&
              r.WeddingID == WeddingId);
            if (existingRSVP == null)
            {
                _context.Guests.Add(newRSVP);
                _context.SaveChanges();
            }
            return RedirectToAction("Show","Login");
        }

        [HttpPost]
        [Route("addWed")]
        public IActionResult addWed(Wedding Wed)
        {
            int? x=HttpContext.Session.GetInt32("UserId");
            User TEMP = _context.RSVPS.SingleOrDefault(u=>u.UserId == x);
            if (ModelState.IsValid)
            {
                Wedding newWedding = new Wedding(){
                    WedderOne = Wed.WedderOne,
                    WedderTwo = Wed.WedderTwo,
                    WeddingDate = Wed.WeddingDate,
                    Address = Wed.Address,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    UserId =(int)HttpContext.Session.GetInt32("UserId")
                };
                System.Console.WriteLine("===================");
                System.Console.WriteLine(x);
                System.Console.WriteLine("=====================");
                _context.Weddings.Add(newWedding);
                _context.SaveChanges();
                ViewBag.ThisWedding = newWedding;
                return View("WeddingInfo");//"WInfo/{newWedding.WeddingID}");
            }
            else
            {
                return View("NewWedding");
            }

        }

        [HttpGet]
        [Route("WInfo/{WeddingId}")]
        public IActionResult WInfo(int WeddingId)
        {
            Wedding thisWedding = _context.Weddings.Include(w => w.Guests)
                                .ThenInclude(r => r.User)
                                .SingleOrDefault(w => w.WeddingID == WeddingId);
            ViewBag.ThisWedding = thisWedding;

            return View("WeddingInfo");
        }

    }
}