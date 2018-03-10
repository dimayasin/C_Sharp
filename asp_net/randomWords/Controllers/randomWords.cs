using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;


namespace randomWords.Controllers
{
    public class randomWordsController : Controller
    {

        public string RandomString()
        {
            string charSet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            // List<string> passwrd = new List<string>();
            string passwrd="";
            Random random = new Random();
            char temp;
            for (int i = 0; i < 16; i++)
            {
                temp = charSet[random.Next(0, 16)];
                passwrd +="" + temp;

            }



            return passwrd;

        }




        int count =1;

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            // HttpContext.Session.Clear();
            // HttpContext.Session.SetInt32("Count",1);
            HttpContext.Session.SetString("RandomPassword", RandomString());
            ViewBag.PassCode = HttpContext.Session.GetString("RandomPassword");
            ViewBag.Count += count;


            return View();
        }

        [HttpGet]
        [Route("method")]
        public IActionResult Method()
        {
         
            return RedirectToAction("Index");
        }




    }
}