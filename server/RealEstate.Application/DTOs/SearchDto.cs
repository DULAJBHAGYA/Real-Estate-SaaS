using RealEstate.Domain.Entities;

namespace RealEstate.Application.DTOs
{
    public class SearchDto
    {
        public string? Query { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public PropertyType? PropertyType { get; set; }
        public PropertyStatus? Status { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? MinBedrooms { get; set; }
        public int? MaxBedrooms { get; set; }
        public int? MinBathrooms { get; set; }
        public int? MaxBathrooms { get; set; }
        public decimal? MinSquareFootage { get; set; }
        public decimal? MaxSquareFootage { get; set; }
        public bool? IsPetFriendly { get; set; }
        public bool? HasGarage { get; set; }
        public bool? HasPool { get; set; }
        public bool? HasGarden { get; set; }
        public string? Tags { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int? Radius { get; set; } // in kilometers
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? SortBy { get; set; } = "CreatedAt";
        public string? SortDirection { get; set; } = "desc";
    }

    public class RecommendationDto
    {
        public string UserId { get; set; } = string.Empty;
        public string? City { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? MinBedrooms { get; set; }
        public int? MinBathrooms { get; set; }
        public PropertyType? PropertyType { get; set; }
        public int Count { get; set; } = 10;
    }

    public class PricePredictionDto
    {
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public PropertyType PropertyType { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public decimal SquareFootage { get; set; }
        public int YearBuilt { get; set; }
        public bool HasGarage { get; set; }
        public bool HasPool { get; set; }
        public bool HasGarden { get; set; }
        public string? Amenities { get; set; }
    }

    public class PricePredictionResultDto
    {
        public decimal PredictedPrice { get; set; }
        public decimal Confidence { get; set; }
        public string PriceRange { get; set; } = string.Empty;
        public List<string> Factors { get; set; } = new List<string>();
    }
}
