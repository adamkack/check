using System.ComponentModel.DataAnnotations;

namespace check.Models
{
    public class Employe
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Range(18, 100)]
        public int Age { get; set; }
        public DateTime? Birthday { get; set; }
    }
}
