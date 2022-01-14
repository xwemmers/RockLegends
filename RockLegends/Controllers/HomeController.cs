using Microsoft.AspNetCore.Mvc;

namespace RockLegends.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var names = new[] { "Harald", "Nina", "Koen", "Hans-Peter", "Reinier", "Klaas", "Stefan", "Johan", "Tom", "Hendrik-Jan" };

            // Extra dingen geef je mee via ViewBag
            ViewBag.TrainerName = "Xander";
            ViewBag.Age = 47;

            return View(names);
        }


    }
}
