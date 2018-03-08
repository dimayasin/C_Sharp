using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace MyFirstAsp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("DisplayInt")]
        public JsonResult DisplayInt()
        {
            return Json(15);
        }
    }
}
