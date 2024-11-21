namespace MyCommunitySite.Models
{
    public class AppUser
    {
        public int AppUserId { get; set; }
        public string? Name { get; set; }
        public DateTime SignupDate { get; set; } = DateTime.Now.ToLocalTime();
    }
}