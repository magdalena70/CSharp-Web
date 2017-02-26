using System.ComponentModel.DataAnnotations;

namespace SimpleMVC.App.Models
{
    public class Login
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public string SessionId { get; set; }
    }
}
