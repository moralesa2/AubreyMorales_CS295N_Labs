using System.ComponentModel.DataAnnotations;

namespace MyCommunitySite.Models
{
    public class Message
    {
        [Required(ErrorMessage = "This field cannot be left blank.")]
        public AppUser? Sender { get; set; }

        [Required(ErrorMessage = "This field cannot be left blank.")]
        public AppUser? Recipient { get; set; }

        public string? Subject { get; set; }

        [Range(1, 99, ErrorMessage ="Priority must be from 1 to 99.")]
        public int Priority { get; set; }

        [Required(ErrorMessage = "You can't send a blank message.")]
        public string? Content { get; set; }

        public DateTime TimeSent { get; set; }
    }
}
