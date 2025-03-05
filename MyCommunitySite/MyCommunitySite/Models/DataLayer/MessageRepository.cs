using Microsoft.EntityFrameworkCore;
using MyCommunitySite.Models.DomainModels;
using System.Net.NetworkInformation;

namespace MyCommunitySite.Models
{
    public class MessageRepository : IMessageRepository
    {
        private ApplicationDbContext context;

        public MessageRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Message> Messages
        {
            get
            {
                return context.Messages
                    .Include(message => message.Sender)
                    .Include(message => message.Recipient)
                    .OrderBy(message => message.TimeSent);
            }
        }

        public async Task AddMessageAsync(Message message)
        {
            try
            {
                context.Messages.Add(message);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving message");
                throw;
            }
        }

        public async Task UpdateMessageAsync(Message message)
        {
            context.Messages.Update(message);
            await context.SaveChangesAsync();
        }

        public async Task<List<Message>> GetMessagesAsync()
        {
            List<Message> messages = await context.Messages
                .Include(m => m.Sender)
                .Include(m => m.Recipient)
                .Include(m => m.Replies)
                .ThenInclude(reply => reply.Sender)
                .ToListAsync();
            return messages;
        }

        public async Task<Message> GetMessageByIdAsync(int messageId)
        {
            return await context.Messages
                .Include(message => message.Sender)
                .Include(message => message.Replies)
                .ThenInclude(message => message.Sender)
                .Where(message => message.MessageId == messageId)
                .SingleOrDefaultAsync();
        }

        public int DeleteMessage(int messageId)
        {
            var deleteMessage = context.Messages.Find(messageId);
            context.Messages.Remove(deleteMessage);
            return context.SaveChanges();
        }

        public int DeleteReply(int messageId, int replyId)
        {
            Message message = GetMessageByIdAsync(messageId).Result;
            Reply reply = message.Replies.Where(r => r.ReplyId == replyId).SingleOrDefault();
            message.Replies.Remove(reply);
            return context.SaveChanges();
        }
    }
}
