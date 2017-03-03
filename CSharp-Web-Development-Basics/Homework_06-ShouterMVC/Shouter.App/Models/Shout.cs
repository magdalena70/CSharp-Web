using System;
using System.ComponentModel.DataAnnotations;

namespace Shouter.App.Models
{
    public class Shout
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime? PostedOn { get; set; }

        public TimeSpan? Duration { get; set; }

        public virtual User Author { get; set; }
    }
}
