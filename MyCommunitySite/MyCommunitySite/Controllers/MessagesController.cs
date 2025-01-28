using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyCommunitySite.Models;
using Microsoft.AspNetCore.Authorization;

namespace MyCommunitySite.Controllers
{
    public class MessagesController : Controller
    {
        readonly IRepository<Message> messageRepo;
        readonly UserManager<AppUser> userManager;

        private readonly QueryOptions<Message> mOptions = new QueryOptions<Message>();

        public MessagesController(IRepository<Message> mRepo, UserManager<AppUser> uManager)
        {
            this.messageRepo = mRepo;
            this.userManager = uManager;
        }

        public IActionResult Index()
        {
            mOptions.Includes = "Sender, Recipient";
            mOptions.OrderBy = message => message.TimeSent;
            ViewBag.AppUsers = userManager.Users.ToList();

            var messages = messageRepo.List(mOptions);

            return View(messages);
        }
        
        [Authorize]
        [HttpGet]
        public IActionResult Add()
        {
            mOptions.Includes = "Sender, Recipient";
            ViewBag.Action = "Add";
            ViewBag.AppUsers = userManager.Users.ToList();
            return View("Edit", new Message());
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            mOptions.Includes = "Sender, Recipient";
            ViewBag.Action = "Edit";
            ViewBag.AppUsers = userManager.Users.ToList();
            var message = messageRepo.Get(id);
            return View(message);
        }

        [HttpPost]
        public IActionResult Edit(Message message)
        {
            // set sender to current user
            message.Sender = userManager.GetUserAsync(User).Result;
            message.SenderId = message.Sender.Id;

            if (ModelState.IsValid)
            {
                if (message.MessageId == 0)
                {
                    messageRepo.Insert(message);
                }
                else
                    messageRepo.Update(message);
                messageRepo.Save();
                return RedirectToAction("Index", "Messages");
            }
            else
            {
                mOptions.Includes = "Sender, Recipient";
                ViewBag.Action = (message.MessageId == 0 ? "Add" : "Edit");
                ViewBag.AppUsers = userManager.Users.ToList();
                return View(message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var message = messageRepo.Get(id);
            return View(message);
        }

        [HttpPost]
        public IActionResult Delete(Message message)
        {
            messageRepo.Delete(message);
            messageRepo.Save();
            return RedirectToAction("Index", "Messages");
        }

        public IActionResult Filter(string sender, string date)
        {
            mOptions.Includes = "Sender, Recipient";
            var messages = messageRepo.List(mOptions)
                .Where(m => sender == null || m.Sender.UserName == sender)
                .Where(m => date == null || m.TimeSent.ToString("MM/dd/yyyy") == date)
                .ToList();

            return View("Index", messages);
        }
    }
}
