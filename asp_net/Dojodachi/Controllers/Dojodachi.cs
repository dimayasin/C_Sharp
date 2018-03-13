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
            HttpContext.Session.SetInt32("happiness", 20);
            HttpContext.Session.SetInt32("fullness", 20);
            HttpContext.Session.SetInt32("meals", 3);
            HttpContext.Session.SetInt32("energy", 50);

            ViewBag.Happiness = HttpContext.Session.GetInt32("happiness");
            ViewBag.Fullness = HttpContext.Session.GetInt32("fullness");
            ViewBag.Energy = HttpContext.Session.GetInt32("energy");
            ViewBag.Meals = HttpContext.Session.GetInt32("meals");
            ViewBag.msg = "";

            return View();
        }


        [HttpGet]

        [Route("dojoachi")]
        public IActionResult dojoachi()
        {
            int happiness = (int)HttpContext.Session.GetInt32("happiness");
            int fullness = (int)HttpContext.Session.GetInt32("fullness");
            int energy = (int)HttpContext.Session.GetInt32("energy");
            int meals = (int)HttpContext.Session.GetInt32("meals");


            ViewBag.Happiness = HttpContext.Session.GetInt32("Happiness");
            ViewBag.Fullness = HttpContext.Session.GetInt32("Fullness");
            ViewBag.Energy = HttpContext.Session.GetInt32("Energy");
            ViewBag.Meals = HttpContext.Session.GetInt32("Meals");

            ViewBag.msg = "";

            if (energy > 100 && fullness > 100 && happiness > 100)
            {
                return RedirectToAction("win");

            }
            if (fullness <= 0 || happiness <= 0)
            {
                return RedirectToAction("lose");


            }
            else

                return View("dojoachi");
        }

        [HttpGet]

        [Route("Dojogachi/Feed")]
        public IActionResult Feed()
        {
            int happiness = (int)HttpContext.Session.GetInt32("happiness");

            int fullness = (int)HttpContext.Session.GetInt32("fullness");
            int meals = (int)HttpContext.Session.GetInt32("meals");
            int energy = (int)HttpContext.Session.GetInt32("energy");


            if (meals <= 0)
            {
                ViewBag.msg = "You don't have enough food to feed your Dojogachi!\n";
                return RedirectToAction("dojoachi");
            }


            meals -= 1;
            Random rand = new Random();
            if (rand.Next(0, 101) < 25)
            {
                ViewBag.msg = " Your Dojodachi didn't like the meal and gained no benefits";
            }
            else
            {
                int newfull = rand.Next(5, 10);
                fullness += newfull;
                ViewBag.msg = "Your Dojodachi enjoyed the meal. Meals -1 pts" + ". Fullness + " + newfull.ToString() + " pts.";
            }

            HttpContext.Session.SetInt32("meals", meals);
            HttpContext.Session.SetInt32("happiness", happiness);
            HttpContext.Session.SetInt32("energy", energy);
            HttpContext.Session.SetInt32("fullness", fullness);

            ViewBag.Happiness = happiness;
            ViewBag.Fullness = fullness;
            ViewBag.Energy = energy;
            ViewBag.Meals = meals;

            return RedirectToAction("dojoachi");
        }

        [HttpGet]

        [Route("Dojogachi/Play")]
        public IActionResult Play()
        {
            int happiness = (int)HttpContext.Session.GetInt32("happiness");

            int fullness = (int)HttpContext.Session.GetInt32("fullness");
            int meals = (int)HttpContext.Session.GetInt32("meals");
            int energy = (int)HttpContext.Session.GetInt32("energy");

            if (energy <= 0)
            {
                ViewBag.msg = "Your dojodachi is exhausted and needs some rest\n";
                return RedirectToAction("dojoachi");
            }

            energy -= 5;
            Random rand = new Random();
            if (rand.Next(0, 101) < 25)
            {
                ViewBag.msg = " Your Dojodachi didn't like playing and gained no benefits";
            }
            else
            {
                int newhappy = rand.Next(5, 10);
                happiness += newhappy;
                ViewBag.msg = "Your Dojodachi enjoyed the play. Energy - 5 pts " + " Happiness + " + newhappy.ToString() + " pts.";
            }

            HttpContext.Session.SetInt32("meals", meals);
            HttpContext.Session.SetInt32("happiness", happiness);
            HttpContext.Session.SetInt32("energy", energy);
            HttpContext.Session.SetInt32("fullness", fullness);


            ViewBag.Happiness = happiness;
            ViewBag.Fullness = fullness;
            ViewBag.Energy = energy;
            ViewBag.Meals = meals;
            return RedirectToAction("dojoachi");
        }


        [HttpGet]
        [Route("Dojogachi/Work")]
        public IActionResult Work()
        {
            int happiness = (int)HttpContext.Session.GetInt32("happiness");

            int fullness = (int)HttpContext.Session.GetInt32("fullness");
            int meals = (int)HttpContext.Session.GetInt32("meals");
            int energy = (int)HttpContext.Session.GetInt32("energy");
            if (energy <= 0)
            {
                ViewBag.msg = "Your dojodachi is exhausted and needs some rest\n";
                return RedirectToAction("dojoachi");
            }

            Random rand = new Random();
            energy -= 5;

            int newmeals = rand.Next(1, 3);
            meals += newmeals;
            ViewBag.msg = "Your dojogachi worked hard.  Energy - 5 pts" + ". Meals + " + newmeals.ToString() + " pts.";


            HttpContext.Session.SetInt32("meals", meals);
            HttpContext.Session.SetInt32("happiness", happiness);
            HttpContext.Session.SetInt32("energy", energy);
            HttpContext.Session.SetInt32("fullness", fullness);


            ViewBag.Happiness = happiness;
            ViewBag.Fullness = fullness;
            ViewBag.Energy = energy;
            ViewBag.Meals = meals;
            return RedirectToAction("dojoachi");
        }
        [HttpGet]
        [Route("Dojogachi/Sleep")]
        public IActionResult Sleep()
        {
            int happiness = (int)HttpContext.Session.GetInt32("happiness");

            int fullness = (int)HttpContext.Session.GetInt32("fullness");
            int meals = (int)HttpContext.Session.GetInt32("meals");
            int energy = (int)HttpContext.Session.GetInt32("energy");

            energy += 15;
            happiness -= 5;
            fullness -= 5;
            ViewBag.msg = "Your dojogachi had a good nap.  Energy + 15 pts. Happiness -5 pts. Fullness -5 pts.";

            HttpContext.Session.SetInt32("meals", meals);
            HttpContext.Session.SetInt32("happiness", happiness);
            HttpContext.Session.SetInt32("energy", energy);
            HttpContext.Session.SetInt32("fullness", fullness);


            ViewBag.Happiness = happiness;
            ViewBag.Fullness = fullness;
            ViewBag.Energy = energy;
            ViewBag.Meals = meals;
            return RedirectToAction("dojoachi");
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