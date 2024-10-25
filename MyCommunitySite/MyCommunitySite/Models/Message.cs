namespace MyCommunitySite.Models
{
    public class Message
    {
        public AppUser? Sender { get; set; }
        public AppUser? Recipient { get; set; }
        public string? Subject { get; set; }
        public int Priority { get; set; }
        public string? Content { get; set; }
        public DateTime TimeSent { get; set; }
    }
}
