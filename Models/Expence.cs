using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SUM.Models
{
    [Table("expences")]
    public class Expence
    {
        [Key]
        public Guid id { get; set; }

        [Required]
        public string name { get; set; } = null!;
        public string description { get; set; } = null!;
        [Required]
        [Range(0.01, double.MaxValue,ErrorMessage ="enter an amount greater than 0")]
        public double amount { get; set; }


    }
}
