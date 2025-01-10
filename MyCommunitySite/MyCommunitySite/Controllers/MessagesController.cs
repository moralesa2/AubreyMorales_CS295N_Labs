using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCommunitySite.Models;

namespace MyCommunitySite.Controllers
{
    public class MessagesController : Controller
    {
        readonly IRepository<Message> messageRepo;
        readonly IRepository<AppUser> userRepo;

        private readonly QueryOptions<Message> mOptions = new QueryOptions<Message>();
        private readonly QueryOptions<AppUser> uOptions = new QueryOptions<AppUser>();

        public MessagesController(IRepository<Message> mRepo, IRepository<AppUser> uRepo)
        {
            this.messageRepo = mRepo;
            this.userRepo = uRepo;
        }

        public IActionResult Index()
        {
            mOptions.Includes = "Sender, Recipient";
            mOptions.OrderBy = message => message.TimeSent;
            var messages = messageRepo.List(mOptions);

            return View(messages);
        }

        [HttpGet]
        public IActionResult Add()
        {
            mOptions.Includes = "Sender, Recipient";
            uOptions.OrderBy = appUser => appUser.Name;
            var appUsers = userRepo.List(uOptions);

            ViewBag.Action = "Add";
            ViewBag.AppUsers = appUsers;
            return View("Edit", new Message());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            mOptions.Includes = "Sender, Recipient";
            uOptions.OrderBy = appUser => appUser.Name;
            var appUsers = userRepo.List(uOptions);

            ViewBag.Action = "Edit";
            ViewBag.AppUsers = appUsers;
            var message = messageRepo.Get(id);
            return View(message);
        }

        [HttpPost]
        public IActionResult Edit(Message message)
        {
            if (ModelState.IsValid)
            {
                if (message.MessageId == 0)
                    messageRepo.Insert(message);
                else
                    messageRepo.Update(message);
                messageRepo.Save();
                return RedirectToAction("Index", "Messages");
            }
            else
            {
                mOptions.Includes = "Sender, Recipient";
                uOptions.OrderBy = appUser => appUser.Name;
                var appUsers = userRepo.List(uOptions);

                ViewBag.Action = (message.MessageId == 0 ? "Add" : "Edit");
                ViewBag.AppUsers = appUsers;

                return View(message);
            }
        }

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
                .Where(m => sender == null || m.Sender.Name == sender)
                .Where(m => date == null || m.TimeSent.ToString("MM/dd/yyyy") == date)
                .ToList();

            return View("Index", messages);
        }
    }
}
