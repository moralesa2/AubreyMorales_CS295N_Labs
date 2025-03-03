using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using MyCommunitySite.Models.DomainModels;
using System.ComponentModel.DataAnnotations;

namespace MyCommunitySite.Models
{
    public class Message
    {
        public int MessageId { get; set; }

        [Required]
        public string SenderId { get; set; } = null!;
        [ValidateNever]
        public AppUser Sender { get; set; } = null!;
        [Required]
        public string RecipientId { get; set; } = null!;
        [ValidateNever]
        public AppUser Recipient { get; set; } = null!;

        [Required(ErrorMessage = "Subject cannot be blank.")]
        [StringLength(60, ErrorMessage = "Subject cannot exceed 60 characters. ")]
        public string? Subject { get; set; }

        [Range(1, 5, ErrorMessage = "Priority must be from 1 to 5.")]
        public int Priority { get; set; }

        [Required(ErrorMessage = "You can't send a blank message.")]
        public string? Content { get; set; }

        public DateTime TimeSent { get; set; } = DateTime.Now.ToLocalTime();

        public ICollection<Reply> Replies { get; set; } = new List<Reply>();
    }
}
