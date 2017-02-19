using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SharpStore.Models
{
    public class User
    {
        public User()
        {
            this.ReceivedMessages = new HashSet<Message>();
            this.SendedMessages = new HashSet<Message>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public virtual ICollection<Message> ReceivedMessages { get; set; }

        public virtual ICollection<Message> SendedMessages { get; set; }
    }
}
