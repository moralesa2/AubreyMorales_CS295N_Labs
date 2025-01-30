using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyCommunitySite.Models;
using Microsoft.AspNetCore.Authorization;

namespace MyCommunitySite.Controllers
{
    public class MessagesController : Controller
    {
        readonly IMessageRepository messageRepo;
        readonly UserManager<AppUser> userManager;

        public MessagesController(IMessageRepository mRepo, UserManager<AppUser> uManager)
        {
            this.messageRepo = mRepo;
            this.userManager = uManager;
        }

        public async Task<IActionResult> Index()
        {
            // get message list
            List<Message> messages = await messageRepo.Messages.ToListAsync<Message>();
            return View(messages);
        }

        [Authorize]
        public IActionResult Message()
        {
            // pass in AppUsers for selecting Recipient
            ViewBag.AppUsers = userManager?.Users.ToList();
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Message(Message message)
        {
            // set sender & recipient
            message.Sender = userManager?.GetUserAsync(User).Result;
            message.Recipient = await userManager.FindByIdAsync(message.RecipientId);

            if (ModelState.IsValid)
            {
                await messageRepo.AddMessageAsync(message);
            }
            return RedirectToAction("Index", message);
        }

        public async Task<IActionResult> Filter(string sender, string date)
        {
            List<Message> messages = null;

            if (!string.IsNullOrEmpty(sender))
            {
                await Task.Run(() =>
                    messages =
                        (from m in messageRepo.Messages
                         where m.Sender.UserName == sender
                         select m).ToList());
            }
            if (!string.IsNullOrEmpty(date))
            {
                var searchDate = DateTime.Parse(date).ToShortDateString();
                await Task.Run(() =>
                    messages =
                        (from m in messageRepo.Messages
                         where m.TimeSent.ToShortDateString() == searchDate
                         select m).ToList());
            }
            return View("Index", messages);
        }
    }
}
