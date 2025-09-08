using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Domain.Entities
{
    public class PropertyView
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime ViewedAt { get; set; } = DateTime.UtcNow;

        [MaxLength(45)]
        public string? IpAddress { get; set; }

        [MaxLength(500)]
        public string? UserAgent { get; set; }

        [MaxLength(100)]
        public string? Referrer { get; set; }

        // Foreign Keys
        [Required]
        public int PropertyId { get; set; }

        public string? UserId { get; set; } // Nullable for anonymous views

        // Navigation properties
        [ForeignKey("PropertyId")]
        public virtual Property Property { get; set; } = null!;

        [ForeignKey("UserId")]
        public virtual ApplicationUser? User { get; set; }
    }
}
