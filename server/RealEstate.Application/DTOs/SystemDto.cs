using System.ComponentModel.DataAnnotations;

namespace RealEstate.Application.DTOs
{
    public class HealthCheckDto
    {
        public string Status { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
        public string Version { get; set; } = string.Empty;
        public List<ServiceHealth> Services { get; set; } = new List<ServiceHealth>();
        public SystemInfo SystemInfo { get; set; } = new SystemInfo();
    }

    public class ServiceHealth
    {
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public TimeSpan ResponseTime { get; set; }
    }

    public class SystemInfo
    {
        public string Environment { get; set; } = string.Empty;
        public string Database { get; set; } = string.Empty;
        public long MemoryUsage { get; set; }
        public double CpuUsage { get; set; }
        public long DiskSpace { get; set; }
    }

    public class LogEntryDto
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string Level { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string? Exception { get; set; }
        public string? UserId { get; set; }
        public string? Action { get; set; }
        public string? IpAddress { get; set; }
        public string? UserAgent { get; set; }
    }

    public class LogSearchDto
    {
        public string? Level { get; set; }
        public string? UserId { get; set; }
        public string? Action { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? SearchTerm { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 50;
    }

    public class AuditTrailDto
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public string EntityType { get; set; } = string.Empty;
        public string EntityId { get; set; } = string.Empty;
        public string? OldValues { get; set; }
        public string? NewValues { get; set; }
        public string IpAddress { get; set; } = string.Empty;
        public string UserAgent { get; set; } = string.Empty;
        public string? Notes { get; set; }
    }

    public class AuditSearchDto
    {
        public string? UserId { get; set; }
        public string? Action { get; set; }
        public string? EntityType { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 50;
    }
}
