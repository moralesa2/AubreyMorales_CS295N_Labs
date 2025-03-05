using Newtonsoft.Json.Bson;

namespace MyCommunitySite.Models
{
    public interface IMessageRepository
    {
        IQueryable<Message> Messages { get; }
        public Task AddMessageAsync(Message message);
        public Task UpdateMessageAsync(Message message);
        public Task<List<Message>> GetMessagesAsync();
        public Task<Message> GetMessageByIdAsync(int messageId);
        public int DeleteMessage(int messageId);
        public int DeleteReply(int messageId, int replyId);
    }
}
