using RealEstate.Domain.Entities;

namespace RealEstate.Application.DTOs
{
    public class AdminUserDto
    {
        public string Id { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastLoginAt { get; set; }
        public bool IsActive { get; set; }
        public List<string> Roles { get; set; } = new List<string>();
        public int PropertiesCount { get; set; }
        public int BookingsCount { get; set; }
    }

    public class PendingPropertyDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public PropertyType PropertyType { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public DateTime CreatedAt { get; set; }
        public string AgentId { get; set; } = string.Empty;
        public string AgentName { get; set; } = string.Empty;
        public string AgentEmail { get; set; } = string.Empty;
    }

    public class PropertyApprovalDto
    {
        public int PropertyId { get; set; }
        public bool IsApproved { get; set; }
        public string? RejectionReason { get; set; }
        public string? AdminNotes { get; set; }
    }

    public class AnalyticsDto
    {
        public int TotalUsers { get; set; }
        public int ActiveUsers { get; set; }
        public int TotalProperties { get; set; }
        public int ActiveProperties { get; set; }
        public int PendingProperties { get; set; }
        public int TotalBookings { get; set; }
        public int CompletedBookings { get; set; }
        public int PendingBookings { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal MonthlyRevenue { get; set; }
        public List<PropertyTypeStats> PropertyTypeStats { get; set; } = new List<PropertyTypeStats>();
        public List<MonthlyStats> MonthlyStats { get; set; } = new List<MonthlyStats>();
    }

    public class PropertyTypeStats
    {
        public PropertyType PropertyType { get; set; }
        public int Count { get; set; }
        public decimal AveragePrice { get; set; }
        public decimal TotalValue { get; set; }
    }

    public class MonthlyStats
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int NewUsers { get; set; }
        public int NewProperties { get; set; }
        public int NewBookings { get; set; }
        public decimal Revenue { get; set; }
    }

    public class UserSearchDto
    {
        public string? SearchTerm { get; set; }
        public string? Role { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedFrom { get; set; }
        public DateTime? CreatedTo { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
