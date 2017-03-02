using System.ComponentModel.DataAnnotations;

namespace PizzaMore.App.Models
{
    public class Pizza
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Title { get; set; }

        [Required]
        public string Recipe { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public int UpVotes { get; set; }

        public int DownVotes { get; set; }

        public virtual User Owner { get; set; }
    }
}
