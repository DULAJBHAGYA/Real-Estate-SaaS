using RealEstate.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Application.DTOs
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public DateTime ScheduledDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string? Notes { get; set; }
        public AppointmentStatus Status { get; set; }
        public string? ContactPhone { get; set; }
        public string? ContactEmail { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int PropertyId { get; set; }
        public string PropertyTitle { get; set; } = string.Empty;
        public string PropertyAddress { get; set; } = string.Empty;
        public string ClientId { get; set; } = string.Empty;
        public string ClientName { get; set; } = string.Empty;
        public string AgentId { get; set; } = string.Empty;
        public string AgentName { get; set; } = string.Empty;
    }

    public class CreateAppointmentDto
    {
        [Required]
        public DateTime ScheduledDate { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        [MaxLength(500)]
        public string? Notes { get; set; }

        [MaxLength(200)]
        public string? ContactPhone { get; set; }

        [MaxLength(200)]
        public string? ContactEmail { get; set; }

        [Required]
        public int PropertyId { get; set; }
    }

    public class UpdateAppointmentDto
    {
        public DateTime? ScheduledDate { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string? Notes { get; set; }
        public AppointmentStatus? Status { get; set; }
        public string? ContactPhone { get; set; }
        public string? ContactEmail { get; set; }
    }

    public class AppointmentSearchDto
    {
        public int? PropertyId { get; set; }
        public string? ClientId { get; set; }
        public string? AgentId { get; set; }
        public AppointmentStatus? Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
