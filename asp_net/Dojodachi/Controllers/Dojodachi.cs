using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;


namespace Dojodachi.Controllers
{
    public class DojodachiController : Controller
    {


        [HttpGet]
        [Route("")]
        public IActionResult Index()

        {
            HttpContext.Session.SetInt32("Happiness", 20);
            HttpContext.Session.SetInt32("Fullness", 20);
            HttpContext.Session.SetInt32("Energy", 50);
            HttpContext.Session.SetInt32("Meals", 3);


            return View();
        }
        

        [HttpGet]

        [Route("dojoachi")]
        public IActionResult dojoachi()
        {
            int? happiness = HttpContext.Session.GetInt32("happiness");
            string msgs = HttpContext.Session.GetString("msg");
            int? fullness = HttpContext.Session.GetInt32("fullness");
            int? meals = HttpContext.Session.GetInt32("meals");
            int? energy = HttpContext.Session.GetInt32("energy");

            ViewBag.Happiness = HttpContext.Session.GetInt32("Happiness");
            ViewBag.Fullness = HttpContext.Session.GetInt32("Fullness");
            ViewBag.Energy = HttpContext.Session.GetInt32("Energy");
            ViewBag.Meals = HttpContext.Session.GetInt32("Meals");
            ViewBag.msg = HttpContext.Session.GetString("msg");

            if (ViewBag.Energy > 100 && ViewBag.Fullness > 100 && ViewBag.Happiness > 100)
            {
                return RedirectToAction("win");

            }
            if (ViewBag.Fullness >= 0 || ViewBag.Happiness >= 0)
            {
                return RedirectToAction("lose");


            }





            return View("dojoachi"); ;
        }

        [HttpGet]

        [Route("Dojogachi/Feed")]
        public IActionResult Feed()
        {
            int? happiness = HttpContext.Session.GetInt32("happiness");
            string msg = HttpContext.Session.GetString("msg");
            int? fullness = HttpContext.Session.GetInt32("fullness");
            int? meals = HttpContext.Session.GetInt32("meals");
            int? energy = HttpContext.Session.GetInt32("energy");


            // ViewBag.Happiness = HttpContext.Session.GetInt32("Happiness");
            // ViewBag.Fullness = HttpContext.Session.GetInt32("Fullness");
            // ViewBag.Energy = HttpContext.Session.GetInt32("Energy");
            // ViewBag.Meals = HttpContext.Session.GetInt32("Meals");
            // ViewBag.msg = HttpContext.Session.GetString("msg");

            if (meals <= 0)
            {
                msg = "You don't have enough food to feed your Dojogachi!\n";
                return RedirectToAction("Dojogachi");
            }


            meals -= 1;
            Random rand = new Random();
            if (rand.Next(0, 101) < 25)
            {
                msg = " Your Dojodachi didn't like the meal and gained no benefits";
            }
            else
            {
                int newfull = rand.Next(5, 10);
                fullness += newfull;
                msg = "Your Dojodachi enjoyed the meal. Meals -1 pts" + ". Fullness + " + newfull.ToString() + " pts.";
            }
            // int happiness = ViewBag.Happiness;
            // string msg = ViewBag.msg;
            // int fullness = ViewBag.Fullness;
            // int meals = ViewBag.Meals;
            // int energy = ViewBag.Energy;

            HttpContext.Session.SetInt32("meals", (int)meals);
            HttpContext.Session.SetInt32("happiness", (int)happiness);
            HttpContext.Session.SetInt32("energy", (int)energy);
            HttpContext.Session.SetInt32("fullness", (int)fullness);
            HttpContext.Session.SetString("msg", msg);
            return RedirectToAction("Dojogachi");
        }

        [HttpGet]

        [Route("Dojogachi/Play")]
        public IActionResult Play()
        {
            int? happiness = HttpContext.Session.GetInt32("happiness");
            string msg = HttpContext.Session.GetString("msg");
            int? fullness = HttpContext.Session.GetInt32("fullness");
            int? meals = HttpContext.Session.GetInt32("meals");
            int? energy = HttpContext.Session.GetInt32("energy");

            if (energy <= 0)
            {
                msg = "Your dojodachi is exhausted and needs some rest\n";
                return RedirectToAction("Dojogachi");
            }

            energy -= 5;
            Random rand = new Random();
            if (rand.Next(0, 101) < 25)
            {
                msg = " Your Dojodachi didn't like playing and gained no benefits";
            }
            else
            {
                int newhappy = rand.Next(5, 10);
                happiness += newhappy;
                msg = "Your Dojodachi enjoyed the play. Energy - 5 pts " + " Happiness + " + newhappy.ToString() + " pts.";
            }

           HttpContext.Session.SetInt32("meals", (int)meals);
            HttpContext.Session.SetInt32("happiness", (int)happiness);
            HttpContext.Session.SetInt32("energy", (int)energy);
            HttpContext.Session.SetInt32("fullness", (int)fullness);
            HttpContext.Session.SetString("msg", msg);
            return RedirectToAction("Dojogachi");
        }


        [HttpGet]
        [Route("Dojogachi/Work")]
        public IActionResult Work()
        {
            int? happiness = HttpContext.Session.GetInt32("happiness");
            string msg = HttpContext.Session.GetString("msg");
            int? fullness = HttpContext.Session.GetInt32("fullness");
            int? meals = HttpContext.Session.GetInt32("meals");
            int? energy = HttpContext.Session.GetInt32("energy");

            if (energy <= 0)
            {
                msg = "Your dojodachi is exhausted and needs some rest\n";
                return RedirectToAction("Dojogachi");
            }

            Random rand = new Random();
            energy -= 5;
            // happiness = happiness - 5;
            int newmeals = rand.Next(1, 3);
            meals += newmeals;
            msg = "Your dojogachi worked hard.  Energy - 5 pts" + ". Meals + " + newmeals.ToString() + " pts.";

            HttpContext.Session.SetInt32("meals", (int)meals);
            HttpContext.Session.SetInt32("happiness", (int)happiness);
            HttpContext.Session.SetInt32("energy", (int)energy);
            HttpContext.Session.SetInt32("fullness", (int)fullness);
            HttpContext.Session.SetString("msg", msg);
            return RedirectToAction("Dojogachi");
        }
        [HttpGet]
        [Route("Dojogachi/Sleep")]
        public IActionResult Sleep()
        {
            int? happiness = HttpContext.Session.GetInt32("happiness");
            string msg = HttpContext.Session.GetString("msg");
            int? fullness = HttpContext.Session.GetInt32("fullness");
            int? meals = HttpContext.Session.GetInt32("meals");
            int? energy = HttpContext.Session.GetInt32("energy");

            energy += 15;
            happiness -= 5;
            fullness -= 5;
            msg = "Your dojogachi had a good nap.  Energy + 15 pts. Happiness -5 pts. Fullness -5 pts.";

            HttpContext.Session.SetInt32("meals", (int)meals);
            HttpContext.Session.SetInt32("happiness", (int)happiness);
            HttpContext.Session.SetInt32("energy", (int)energy);
            HttpContext.Session.SetInt32("fullness", (int)fullness);
            HttpContext.Session.SetString("msg", msg);
            return RedirectToAction("Dojogachi");
        }

        [HttpGet]
        [Route("win")]
        public IActionResult win()
        {
            return View("win");
        }

        [HttpGet]
        [Route("lose")]
        public IActionResult lose()
        {
            return View("loss");
        }


    }
}