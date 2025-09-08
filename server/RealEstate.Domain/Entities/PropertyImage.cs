using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Domain.Entities
{
    public class PropertyImage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string ImageUrl { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? AltText { get; set; }

        [MaxLength(50)]
        public string? ImageType { get; set; } // "main", "gallery", "virtual_tour", etc.

        public int DisplayOrder { get; set; } = 0;
        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Foreign Key
        [Required]
        public int PropertyId { get; set; }

        // Navigation property
        [ForeignKey("PropertyId")]
        public virtual Property Property { get; set; } = null!;
    }
}
