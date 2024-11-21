using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCommunitySite.Data;
using MyCommunitySite.Models;

namespace MyCommunitySite.Controllers
{
    public class MessagesController : Controller
    {
        private ApplicationDbContext context {  get; set; }

        public MessagesController(ApplicationDbContext ctx) => context = ctx;

        public IActionResult Index()
        {
            var messages = context.Messages
                .Include(m => m.Sender)
                .Include(m => m.Recipient)
                .OrderBy(m => m.TimeSent)
                .ToList();
            return View(messages);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.AppUsers = context.AppUsers
                .OrderBy(a => a.Name)
                .ToList();
            return View("Edit", new Message());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.AppUsers = context.AppUsers
                .OrderBy(a => a.Name)
                .ToList();
            var message = context.Messages.Find(id);
            return View(message);
        }

        [HttpPost]
        public IActionResult Edit(Message message)
        {
            if (ModelState.IsValid)
            {
                if (message.MessageId == 0 )
                    context.Messages.Add(message);
                else
                    context.Messages.Update(message);
                context.SaveChanges();
                return RedirectToAction("Index", "Messages");
            }
            else
            {
                ViewBag.Action = (message.MessageId == 0 ? "Add" : "Edit");
                ViewBag.AppUsers = context.AppUsers
                    .OrderBy(a => a.Name)
                    .ToList();
                return View(message);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var message = context.Messages.Find(id);
            return View(message);
        }

        [HttpPost]
        public IActionResult Delete(Message message)
        {
            context.Messages.Remove(message);
            context.SaveChanges();
            return RedirectToAction("Index", "Messages");
        }
    }
}
