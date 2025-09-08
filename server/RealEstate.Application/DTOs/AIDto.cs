using RealEstate.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Application.DTOs
{
    public class ImageTaggingDto
    {
        public string ImageUrl { get; set; } = string.Empty;
        public List<ImageTag> Tags { get; set; } = new List<ImageTag>();
        public decimal Confidence { get; set; }
    }

    public class ImageTag
    {
        public string Name { get; set; } = string.Empty;
        public decimal Confidence { get; set; }
        public string Category { get; set; } = string.Empty;
    }

    public class ChatbotDto
    {
        public string Message { get; set; } = string.Empty;
        public string Response { get; set; } = string.Empty;
        public string SessionId { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
        public List<ChatbotSuggestion> Suggestions { get; set; } = new List<ChatbotSuggestion>();
    }

    public class ChatbotSuggestion
    {
        public string Text { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public string? Url { get; set; }
    }

    public class ChatbotRequestDto
    {
        [Required]
        public string Message { get; set; } = string.Empty;
        
        public string? SessionId { get; set; }
        public string? UserId { get; set; }
        public string? Context { get; set; }
    }

    public class AIResponseDto
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public object? Data { get; set; }
        public decimal Confidence { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }
}
