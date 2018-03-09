using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DojoServey.Controllers
{
    public class DojoServeyController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("method")]
        public IActionResult Method(string name, string location, string language, string comment)
        {

            ViewBag.Name = name;
            ViewBag.Location=location;
            ViewBag.Language = language;
            ViewBag.Comment = comment;

            return View("results.cshtml");
        }


    }
}