using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyCommunitySite.Models
{
    internal class HikeConfig : IEntityTypeConfiguration<Hike>
    {
       public void Configure(EntityTypeBuilder<Hike> entity)
        {
            entity.HasData(
               new Hike
               {
                   HikeId = 1,
                   Location = "Spencer Butte",
                   Date = "11/08/2024"
               },
               new Hike
               {
                   HikeId = 2,
                   Location = "Ridgeline Trail - Fox Hollow to Mt. Baldy",
                   Date = "10/13/2024"
               });
        }
    }
}
