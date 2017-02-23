using System.ComponentModel.DataAnnotations;

namespace SimpleMVC.App.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public virtual User Owner { get; set; }
    }
}
