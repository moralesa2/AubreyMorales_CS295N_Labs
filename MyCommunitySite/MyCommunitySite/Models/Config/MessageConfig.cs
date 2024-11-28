using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyCommunitySite.Models
{
    internal class MessageConfig : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> entity)
        {
            entity.HasData(
                new Message
                {
                    MessageId = 1,
                    SenderId = 1,
                    RecipientId = 2,
                    Subject = "Test1",
                    Content = "This is a test message"
                },
                new Message
                {
                    MessageId = 2,
                    SenderId = 2,
                    RecipientId = 3,
                    Subject = "Test2",
                    Content = "This is a 2nd test message"
                });
        }
    }
}
