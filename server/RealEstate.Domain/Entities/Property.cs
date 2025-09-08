using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Domain.Entities
{
    public class Property
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(2000)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Address { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string City { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string State { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string ZipCode { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Country { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        public PropertyType PropertyType { get; set; }

        [Required]
        public int Bedrooms { get; set; }

        [Required]
        public int Bathrooms { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal SquareFootage { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal LotSize { get; set; }

        [Required]
        public int YearBuilt { get; set; }

        [Required]
        public PropertyStatus Status { get; set; }

        public bool IsFeatured { get; set; } = false;
        public bool IsPetFriendly { get; set; } = false;
        public bool HasGarage { get; set; } = false;
        public bool HasPool { get; set; } = false;
        public bool HasGarden { get; set; } = false;

        [MaxLength(1000)]
        public string? Amenities { get; set; }

        [MaxLength(1000)]
        public string? Tags { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Foreign Keys
        [Required]
        public string AgentId { get; set; } = string.Empty;

        // Navigation properties
        [ForeignKey("AgentId")]
        public virtual ApplicationUser Agent { get; set; } = null!;
        public virtual ICollection<PropertyImage> Images { get; set; } = new List<PropertyImage>();
        public virtual ICollection<PropertyView> Views { get; set; } = new List<PropertyView>();
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }

    public enum PropertyType
    {
        House,
        Apartment,
        Condo,
        Townhouse,
        Villa,
        Studio,
        Penthouse,
        Duplex,
        Other
    }

    public enum PropertyStatus
    {
        ForSale,
        ForRent,
        Sold,
        Rented,
        Pending,
        OffMarket
    }
}
