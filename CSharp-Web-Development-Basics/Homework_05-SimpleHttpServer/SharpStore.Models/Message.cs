using System.ComponentModel.DataAnnotations;

namespace SharpStore.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public virtual User Sender { get; set; }

        [Required]
        public virtual User Subject { get; set; }

        [Required]
        public string MessageContent { get; set; }
    }
}
