using Microsoft.EntityFrameworkCore;
using MyCommunitySite.Models;

namespace MyCommunitySite.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Message> Messages { get; set; } = null!;
        public DbSet<AppUser> AppUsers { get; set; } = null!;
        public DbSet<Hike> Hikes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {  
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
                {
                    AppUserId = 1,
                    Name = "Ellen Ripley",
                    SignupDate = DateTime.Now
                },
                new AppUser
                {
                    AppUserId = 2,
                    Name = "Laurie Strode",
                    SignupDate = DateTime.Now
                },
                new AppUser
                {
                    AppUserId = 3,
                    Name = "Pamela Vorhees",
                    SignupDate = DateTime.Now
                });

            modelBuilder.Entity<Message>().HasData(
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
