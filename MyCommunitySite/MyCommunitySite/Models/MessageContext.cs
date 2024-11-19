using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace MyCommunitySite.Models
{
    public class MessageContext : DbContext
    {
        public MessageContext(DbContextOptions<MessageContext> options) : base(options) { }

        public DbSet<Message> Messages { get; set; } = null!;
    }
}
