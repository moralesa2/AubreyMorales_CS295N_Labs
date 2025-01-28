using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCommunitySite.Models
{
    public class AppUser : IdentityUser
    {
        [NotMapped]
        public IList<string>? UserRoles { get; set; }

        public DateTime SignupDate { get; set; } = DateTime.Now.ToLocalTime();
    }
}