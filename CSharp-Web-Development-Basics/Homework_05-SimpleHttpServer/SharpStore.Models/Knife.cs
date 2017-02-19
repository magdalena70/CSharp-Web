using System.ComponentModel.DataAnnotations;

namespace SharpStore.Models
{
    public class Knife
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string ImageURL { get; set; }
    }
}
