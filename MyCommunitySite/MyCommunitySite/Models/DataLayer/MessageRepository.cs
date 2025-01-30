using Microsoft.EntityFrameworkCore;

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

        public async Task<int> DeleteMessageAsync(Message message)
        {
            var deleteMessage = await context.Messages.FindAsync(message.MessageId);
            context.Messages.Remove(deleteMessage);
            return await context.SaveChangesAsync();
        }
    }
}
