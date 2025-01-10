using Microsoft.AspNetCore.Identity;
using MyCommunitySite.Models;

namespace MyCommunitySite.Models.DataLayer
{
    public class SeedData
    {
        public static void Seed(ApplicationDbContext context, IServiceProvider provider)
        {
            if (!context.Messages.Any())
            {
                /*AppUser user1 = new AppUser {Name = "Naru"};
                AppUser user2 = new AppUser {Name = "Marion Crane"};
                AppUser user3 = new AppUser {Name = "Lila Crane"};

                context.AppUsers.Add(user1);
                context.AppUsers.Add(user2);
                context.AppUsers.Add(user3);*/

                var userManager = provider.GetRequiredService<UserManager<AppUser>>();

                Hike hike1 = new Hike {Location = "Mount Doom", Date = "11/17/2003"};
                Hike hike2 = new Hike { Location = "The Shire", Date = "11/19/2001" };

                context.Hikes.Add(hike1);
                context.Hikes.Add(hike2);

                Message message1 = new Message
                {
                    SenderId = 1,
                    RecipientId = 2,
                    Subject = "identity test 1",
                    Content = "message 1 for lab01 identity"
                };
                context.Messages.Add(message1);

                Message message2 = new Message
                {
                    SenderId = 2,
                    RecipientId = 3,
                    Subject = "identity test 2",
                    Content = "message 2 for lab01 identity"
                };
                context.Messages.Add(message2);

                Message message3 = new Message
                {
                    SenderId = 3,
                    RecipientId = 1,
                    Subject = "identity test 3",
                    Content = "message 3 for lab01 identity"
                };
                context.Messages.Add(message3);

                context.SaveChanges();
            }
        }
    }
}