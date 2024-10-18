using Microsoft.AspNetCore.Mvc;

namespace MyCommunitySite.Controllers
{
    public class OtherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult OldStuff()
        {
            return View();
        }

        public IActionResult Recipes()
        {
            return View();
        }
    }
}
