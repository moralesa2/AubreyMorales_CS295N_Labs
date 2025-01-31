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
        public async Task <IActionResult> Message()
        {
            // pass in AppUsers for selecting Recipient
            ViewBag.AppUsers = await userManager?.Users.ToListAsync();
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Message(Message message)
        {
            // set sender & recipient
            if (ModelState.IsValid)
            {
                message.Sender = userManager?.GetUserAsync(User).Result;
                message.Recipient = userManager?.FindByIdAsync(message.RecipientId).Result;
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
            // TODO: fix filter, dates aren't converting
            if (!string.IsNullOrEmpty(date))
            {
                var searchDate = DateTime.Parse(date);
                await Task.Run(() =>
                    messages =
                        (from m in messageRepo.Messages
                         where m.TimeSent.Date == searchDate
                         select m).ToList());
            }
            return View("Index", messages);
        }
    }
}
