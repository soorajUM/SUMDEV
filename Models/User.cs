using System.ComponentModel.DataAnnotations;

namespace SUM.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!; 
    }
}
