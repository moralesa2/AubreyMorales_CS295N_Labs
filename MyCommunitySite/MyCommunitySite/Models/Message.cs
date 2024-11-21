using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace MyCommunitySite.Models
{
    public class Message
    {
        public int MessageId { get; set; }

        [Required(ErrorMessage = "This field cannot be left blank.")]
        public int SenderId { get; set; }
        [ValidateNever]
        public AppUser Sender { get; set; } = null!;

        [Required(ErrorMessage = "This field cannot be left blank.")]
        public int RecipientId { get; set; }
        [ValidateNever]
        public AppUser Recipient { get; set; } = null!;

        public string? Subject { get; set; }

        [Range(1, 5, ErrorMessage ="Priority must be from 1 to 5.")]
        public int Priority { get; set; }

        [Required(ErrorMessage = "You can't send a blank message.")]
        public string? Content { get; set; }

        public DateTime TimeSent { get; set; } = DateTime.Now.ToLocalTime();
    }
}
