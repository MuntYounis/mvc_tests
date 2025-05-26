using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Category
    {

        public int Id { get; set; }
        [Required]
        [MinLength(4)]
        [MaxLength(100)]
        public string Name { get; set; }
        [MinLength(10)]
        public string Description { get; set; } 
    }
}
