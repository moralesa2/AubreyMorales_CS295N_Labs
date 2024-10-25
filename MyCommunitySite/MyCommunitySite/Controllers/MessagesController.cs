using Microsoft.AspNetCore.Mvc;
using MyCommunitySite.Models;

namespace MyCommunitySite.Controllers
{
    public class MessagesController : Controller
    {
        public IActionResult Index()
        {
            Message model = new Message();
            model.Sender = new AppUser();
            model.Recipient = new AppUser();
            return View(model);
        }

        public IActionResult Message()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Message(Message model)
        {
            model.TimeSent = DateTime.Now;
            return View("Index", model);
        }
    }
}
