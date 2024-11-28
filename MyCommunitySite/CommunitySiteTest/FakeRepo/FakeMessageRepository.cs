using MyCommunitySite.Models;

namespace CommunitySiteTest.FakeRepo
{
    public class FakeMessageRepository : IRepository<Message>
    {

        private List<Message> messages = new List<Message>();

        public Message? Get(int id)
        {
            Message message = messages.Find(m => m.MessageId == id);
            return message;
        }

        public int StoreMessage(Message model)
        {
            int status = 0;
            if (model != null && model.Sender != null && model.Recipient != null)
            {
                model.MessageId = messages.Count + 1;
                messages.Add(model);
                status = 1;
            }
            return status;
        }

        public void Insert(Message entity) => messages.Add(entity);

        public IEnumerable<Message> List(QueryOptions<Message> options) => messages;

        public Message? Get(QueryOptions<Message> options)
        {
            throw new NotImplementedException();
        }

        public void Delete(Message entity) { }
        public void Update(Message entity) { }
        public void Delete(int id) { }
        public void Save() { }
    }
}
