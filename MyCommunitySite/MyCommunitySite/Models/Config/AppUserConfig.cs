using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyCommunitySite.Models
{
    internal class AppUserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> entity)
        {
            entity.HasData(
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
        }
    }
}
