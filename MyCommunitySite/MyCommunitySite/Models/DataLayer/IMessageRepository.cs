using Newtonsoft.Json.Bson;

namespace MyCommunitySite.Models
{
    public interface IMessageRepository
    {
        IQueryable<Message> Messages { get; }
        Task AddMessageAsync(Message message);
    }
}
