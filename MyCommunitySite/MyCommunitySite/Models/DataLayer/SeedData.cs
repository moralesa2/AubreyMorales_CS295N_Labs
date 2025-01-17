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
                var userManager = provider.GetRequiredService<UserManager<AppUser>>();
                const string SECRET_PASSWORD = "?Password1";

                AppUser naru = new AppUser { UserName = "Naru" };
                var result1 = userManager.CreateAsync(naru, SECRET_PASSWORD);
              
                AppUser lilaCrane = new AppUser { UserName = "Lila Crane" };
                var result2 = userManager.CreateAsync(lilaCrane, SECRET_PASSWORD);

                AppUser marionCrane = new AppUser { UserName = "Marion Crane" };
                var result3 = userManager.CreateAsync(marionCrane, SECRET_PASSWORD);

                Hike hike1 = new Hike {Location = "Mount Doom", Date = "11/17/2003"};
                Hike hike2 = new Hike { Location = "The Shire", Date = "11/19/2001" };

                context.Hikes.Add(hike1);
                context.Hikes.Add(hike2);

                Message message1 = new Message
                {
                    Sender = naru,
                    SenderId = naru.Id,
                    Recipient = lilaCrane,
                    RecipientId = lilaCrane.Id,
                    Subject = "identity test 1",
                    Content = "message 1 for lab01 identity"
                };
                context.Messages.Add(message1);

                Message message2 = new Message
                {
                    Sender = lilaCrane,
                    SenderId = lilaCrane.Id,
                    Recipient = marionCrane,
                    RecipientId = marionCrane.Id,
                    Subject = "identity test 2",
                    Content = "message 2 for lab01 identity"
                };
                context.Messages.Add(message2);

                Message message3 = new Message
                {
                    Sender = marionCrane,
                    SenderId = marionCrane.Id,
                    Recipient = naru,
                    RecipientId = marionCrane.Id,
                    Subject = "identity test 3",
                    Content = "message 3 for lab01 identity"
                };
                context.Messages.Add(message3);

                context.SaveChanges();
            }
        }
    }
}