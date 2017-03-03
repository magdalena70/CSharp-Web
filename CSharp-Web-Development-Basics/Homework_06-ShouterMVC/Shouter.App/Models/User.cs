using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shouter.App.Models
{
    public class User
    {
        public User()
        {
            this.Followers = new HashSet<User>();
            this.Shouts = new HashSet<Shout>();
        }

        [Key]
        public int Id { get; set; }

        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public DateTime? BirthDate { get; set; }

        public virtual ICollection<Shout> Shouts { get; set; }

        public virtual ICollection<User> Followers { get; set; }
    }
}
