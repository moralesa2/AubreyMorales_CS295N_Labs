using Microsoft.AspNetCore.Identity;
using MyCommunitySite.Models;
using System.Threading.Tasks;

namespace MyCommunitySite.Models.DataLayer
{
    public class SeedData
    {
        public static async Task Seed(ApplicationDbContext context, IServiceProvider provider)
        {
            var userManager = provider.GetRequiredService<UserManager<AppUser>>();

            // check for any users, should exist if data already seeded
            if (!userManager.Users.Any())
            {
                // add items that use identity to database
                #region Identity items
                // get userManager
                const string SECRET_PASSWORD = "?Password1";

                // create user
                AppUser naru = new AppUser { UserName = "Naru" };
                // put user w/new password in database
                await userManager.CreateAsync(naru, SECRET_PASSWORD);

                AppUser lilaCrane = new AppUser { UserName = "LilaCrane" };
                await userManager.CreateAsync(lilaCrane, SECRET_PASSWORD);

                AppUser marionCrane = new AppUser { UserName = "MarionCrane" };
                await userManager.CreateAsync(marionCrane, SECRET_PASSWORD);
                #endregion

                // add items that do not use identity to database
                #region Non-Identity items
                // check for any messages and add seed data accordingly
                if (!context.Messages.Any())
                {
                    Hike hike1 = new Hike { Location = "Mount Doom", Date = "11/17/2003" };
                    Hike hike2 = new Hike { Location = "The Shire", Date = "11/19/2001" };

                    context.Hikes.Add(hike1);
                    context.Hikes.Add(hike2);

                    Message message1 = new Message
                    {
                        Sender = naru,
                        SenderId = naru.Id,
                        Recipient = lilaCrane,
                        RecipientId = lilaCrane.Id,
                        Priority = 1,
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
                        Priority = 1,
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
                        Priority = 1,
                        Subject = "identity test 3",
                        Content = "message 3 for lab01 identity"
                    };
                    context.Messages.Add(message3);

                    await context.SaveChangesAsync();
                }
                #endregion
            }
        }
    }
}