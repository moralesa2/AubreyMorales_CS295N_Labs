using Microsoft.AspNetCore.Mvc;
using MyCommunitySite.Models;

namespace MyCommunitySite.Controllers
{
    public class PlannedHikesController : Controller
    {
        private Hikes hikesList = new Hikes();
        public IActionResult Index()
        {
            return View(hikesList);
        }

        public IActionResult JoinHike()
        {
            return View();
        }

        public IActionResult PlanHike()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PlanHike(Hike newHike)
        {
            hikesList.Add(newHike);
            return View("Index", hikesList);
        }
    }
}
