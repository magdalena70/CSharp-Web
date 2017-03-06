using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftUniStore.App.Models
{
    public class User
    {
        public User()
        {
            this.Games = new HashSet<Game>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required, MinLength(6)]
        [RegularExpression(@"^[0-9A-Z-a-z]+$")]
        public string Password { get; set; }

        [Required]
        public string FullName { get; set; }

        public bool IsAdmin { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
