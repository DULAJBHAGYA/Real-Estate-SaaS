using RealEstate.Domain.Entities;

namespace RealEstate.Application.DTOs
{
    public class PropertyDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public PropertyType PropertyType { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public decimal SquareFootage { get; set; }
        public decimal LotSize { get; set; }
        public int YearBuilt { get; set; }
        public PropertyStatus Status { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsPetFriendly { get; set; }
        public bool HasGarage { get; set; }
        public bool HasPool { get; set; }
        public bool HasGarden { get; set; }
        public string? Amenities { get; set; }
        public string? Tags { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string AgentId { get; set; } = string.Empty;
        public string AgentName { get; set; } = string.Empty;
        public List<PropertyImageDto> Images { get; set; } = new List<PropertyImageDto>();
    }

    public class CreatePropertyDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public PropertyType PropertyType { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public decimal SquareFootage { get; set; }
        public decimal LotSize { get; set; }
        public int YearBuilt { get; set; }
        public PropertyStatus Status { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsPetFriendly { get; set; }
        public bool HasGarage { get; set; }
        public bool HasPool { get; set; }
        public bool HasGarden { get; set; }
        public string? Amenities { get; set; }
        public string? Tags { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }

    public class UpdatePropertyDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public PropertyType PropertyType { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public decimal SquareFootage { get; set; }
        public decimal LotSize { get; set; }
        public int YearBuilt { get; set; }
        public PropertyStatus Status { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsPetFriendly { get; set; }
        public bool HasGarage { get; set; }
        public bool HasPool { get; set; }
        public bool HasGarden { get; set; }
        public string? Amenities { get; set; }
        public string? Tags { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }

    public class PropertyImageDto
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string? AltText { get; set; }
        public string? ImageType { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class PropertySearchDto
    {
        public string? SearchTerm { get; set; }
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
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? SortBy { get; set; } = "CreatedAt";
        public string? SortDirection { get; set; } = "desc";
    }
}
