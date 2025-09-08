using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Domain.Entities
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime ScheduledDate { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        [MaxLength(500)]
        public string? Notes { get; set; }

        [Required]
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Pending;

        [MaxLength(200)]
        public string? ContactPhone { get; set; }

        [MaxLength(200)]
        public string? ContactEmail { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Foreign Keys
        [Required]
        public int PropertyId { get; set; }

        [Required]
        public string ClientId { get; set; } = string.Empty;

        [Required]
        public string AgentId { get; set; } = string.Empty;

        // Navigation properties
        [ForeignKey("PropertyId")]
        public virtual Property Property { get; set; } = null!;

        [ForeignKey("ClientId")]
        public virtual ApplicationUser Client { get; set; } = null!;

        [ForeignKey("AgentId")]
        public virtual ApplicationUser Agent { get; set; } = null!;
    }

    public enum AppointmentStatus
    {
        Pending,
        Confirmed,
        Completed,
        Cancelled,
        Rescheduled
    }
}
