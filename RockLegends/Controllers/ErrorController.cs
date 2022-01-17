using Microsoft.AspNetCore.Mvc;

namespace RockLegends.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            

            return View();
        }

        public IActionResult Specific(int id)
        {
            ViewBag.Code = id;

            return View();
        }


    }
}
