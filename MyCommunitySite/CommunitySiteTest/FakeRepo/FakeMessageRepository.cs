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

        public async Task AddMessageAsync(Message message)
        {
            message.MessageId = messages.Count();
            messages.Add(message);
        }
    }
}
