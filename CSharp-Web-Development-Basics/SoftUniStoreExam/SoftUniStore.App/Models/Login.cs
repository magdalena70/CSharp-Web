using System.ComponentModel.DataAnnotations;

namespace SoftUniStore.App.Models
{
    public class Login
    {
        [Key]
        public int Id { get; set; }

        public virtual User User { get; set; }

        public string SessionId { get; set; }

        public bool IsActive { get; set; }
    }
}
