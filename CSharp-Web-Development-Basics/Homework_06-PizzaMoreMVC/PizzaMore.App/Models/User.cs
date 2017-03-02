using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaMore.App.Models
{
    public class User
    {
        public User()
        {
            this.PizzaSuggestions = new HashSet<Pizza>();
        }

        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Email { get; set; }

        [Required, StringLength(30)]
        public string Password { get; set; }

        public virtual ICollection<Pizza> PizzaSuggestions { get; set; }
    }
}