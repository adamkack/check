using System.ComponentModel.DataAnnotations;

namespace check.Models
{
    public class Tid
    {
        public int Id { get; set; }

        [Required]
        public string Rubrik { get; set; } = string.Empty;
        public string? Beskrivning { get; set; }
        
        [Range(0, 24)]
        public int Timmar { get; set; }
        
        [Range(0, 59)]
        public int Minuter { get; set; }

        public DateTime? Datum { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;
    }
    
}
