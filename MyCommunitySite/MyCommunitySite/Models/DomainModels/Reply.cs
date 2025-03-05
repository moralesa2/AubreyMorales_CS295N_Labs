using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace MyCommunitySite.Models.DomainModels
{
    public class Reply
    {
        public int ReplyId { get; set; }
        [ValidateNever]
        public AppUser Sender { get; set; } = null!;
        [ValidateNever]
        public AppUser Recipient { get; set; } = null!;

        [Required(ErrorMessage = "You can't send a blank message.")]
        public string? ReplyText { get; set; }

        public DateTime TimeSent { get; set; } = DateTime.Now.ToLocalTime();

        // FK for cascade delete
        public int MessageId { get; set; }
    }
}
