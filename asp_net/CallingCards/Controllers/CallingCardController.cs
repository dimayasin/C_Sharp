using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace CallingCards.Controllers
{
    public class CallingCardController : Controller
    {
        [HttpGet]
        [Route("")]
        public JsonResult Name()
        {
            return Json("Mickey Mouse");
        }

        [HttpGet]
        [Route("age")]
        public JsonResult Age()
        {
            return Json(90);
        }

        [HttpGet]
        [Route("{firstName}/{lastName}/{age}/{faveColor}")]
        public JsonResult JsonInfo(string firstName, string lastName, int age, string faveColor)
        {
          var callCard = new {
            FirstName = firstName,
            LastName = lastName,
            Age = age,
            FaveColor = faveColor
          };
          return Json(callCard);
        }

        [HttpGet]
        [Route("bonus")]
        public IActionResult Index()
        {
            return View();
        }
    }
}