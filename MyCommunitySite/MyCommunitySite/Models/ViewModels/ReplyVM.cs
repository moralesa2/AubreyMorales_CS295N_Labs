namespace MyCommunitySite.Models.ViewModels
{
    public class ReplyVM
    {
        // message being replied to
        public int MessageId { get; set; }
        public string? ReplyText { get; set; }
    }
}
