namespace MyCommunitySite.Models
{
    public class Hike
    {
        public int HikeId { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;

        /*public int Attending { get; set; } Implement this later*/
    }
}
