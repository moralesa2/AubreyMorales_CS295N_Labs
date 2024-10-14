using Microsoft.AspNetCore.Mvc;

namespace MyCommunitySite.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Links()
        {
            return View();
        }

        public IActionResult FAQ()
        {
            return View();
        }
    }
}
