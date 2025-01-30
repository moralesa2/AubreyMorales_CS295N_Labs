using MyCommunitySite.Models;

namespace CommunitySiteTest.FakeRepo
{
    public class FakeMessageRepository : IMessageRepository
    {

        private List<Message> messages = new List<Message>();

        public IQueryable<Message> Messages
        {
            get
            {
                return messages.AsQueryable<Message>();
            }
        }
        public Message? Get(int id)
        {
            Message message = messages.Find(m => m.MessageId == id);
            return message;
        }

#pragma warning disable CS1998
        public async Task AddMessageAsync(Message message)
#pragma warning restore CS1998
        {
            message.MessageId = messages.Count();
            messages.Add(message);
        }
    }
}
