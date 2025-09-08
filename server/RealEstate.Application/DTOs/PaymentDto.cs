using System.ComponentModel.DataAnnotations;

namespace RealEstate.Application.DTOs
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public string PaymentId { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Currency { get; set; } = string.Empty;
        public PaymentStatus Status { get; set; }
        public PaymentMethod Method { get; set; }
        public string? Description { get; set; }
        public string? Reference { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public string? FailureReason { get; set; }
    }

    public class CreatePaymentDto
    {
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 3)]
        public string Currency { get; set; } = "USD";

        [Required]
        public PaymentMethod Method { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [MaxLength(100)]
        public string? Reference { get; set; }
    }

    public class PaymentCheckoutDto
    {
        public string CheckoutUrl { get; set; } = string.Empty;
        public string SessionId { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
    }

    public class PaymentWebhookDto
    {
        public string EventType { get; set; } = string.Empty;
        public string PaymentId { get; set; } = string.Empty;
        public string SessionId { get; set; } = string.Empty;
        public PaymentStatus Status { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
    }

    public class PaymentHistoryDto
    {
        public List<PaymentDto> Payments { get; set; } = new List<PaymentDto>();
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
    }

    public enum PaymentStatus
    {
        Pending,
        Processing,
        Completed,
        Failed,
        Cancelled,
        Refunded
    }

    public enum PaymentMethod
    {
        CreditCard,
        DebitCard,
        PayPal,
        Stripe,
        BankTransfer,
        Cash
    }
}
