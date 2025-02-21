using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyCommunitySite.Models;
using Microsoft.AspNetCore.Authorization;
using MyCommunitySite.Models.DomainModels;
using MyCommunitySite.Models.ViewModels;

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
            List<Message> messages = await messageRepo.Messages.Include(m => m.Replies).ToListAsync<Message>();
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
            ModelState.AddModelError("Error", "validation error");
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
                var searchDate = DateTime.Parse(date);
                await Task.Run(() =>
                    messages =
                        (from m in messageRepo.Messages
                         where m.TimeSent.Date == searchDate
                         select m).ToList());
            }
            return View("Index", messages);
        }

        public IActionResult DeleteMessage(int messageId)
        {
            messageRepo.DeleteMessage(messageId);
            var messages = messageRepo.Messages.ToList();
            return View("Index", messages);
        }

        [Authorize]
        public IActionResult Reply(int messageId)
        {
            var replyVM = new ReplyVM { MessageId = messageId };
            return View(replyVM);
        }

        [HttpPost]
        public async Task<RedirectToActionResult> Reply(ReplyVM replyVM)
        {
            // get message that the reply is for
            var message = (from m in messageRepo.Messages.Include(m => m.Replies)
                           where m.MessageId == replyVM.MessageId
                           select m).First<Message>();

            // Reply is the domain model
            var reply = new Reply { ReplyText = replyVM.ReplyText };
            reply.Sender = userManager?.GetUserAsync(User).Result;
            reply.Recipient = message.Sender;

            // store reply message w/reply in db
            message.Replies.Add(reply);
            await messageRepo.UpdateMessageAsync(message);

            var messages = messageRepo.Messages.ToList();
            return RedirectToAction("Index", messages);
        }
    }
}
