using System.ComponentModel.DataAnnotations;

namespace MyCommunitySite.Models.ViewModels
{
    public class ReplyVM
    {
        // message being replied to
        public int MessageId { get; set; }

        [Required(ErrorMessage = "You cannot send an empty reply message.")]
        public string? ReplyText { get; set; }
    }
}
