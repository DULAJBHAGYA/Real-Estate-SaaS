using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.DTOs;
using RealEstate.Application.Queries.Properties;
using MediatR;

namespace RealEstateAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<SearchController> _logger;

        public SearchController(IMediator mediator, ILogger<SearchController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> SearchProperties([FromQuery] SearchDto searchCriteria)
        {
            try
            {
                var query = new GetPropertiesQuery 
                { 
                    SearchCriteria = new PropertySearchDto
                    {
                        SearchTerm = searchCriteria.Query,
                        City = searchCriteria.City,
                        State = searchCriteria.State,
                        PropertyType = searchCriteria.PropertyType,
                        Status = searchCriteria.Status,
                        MinPrice = searchCriteria.MinPrice,
                        MaxPrice = searchCriteria.MaxPrice,
                        MinBedrooms = searchCriteria.MinBedrooms,
                        MaxBedrooms = searchCriteria.MaxBedrooms,
                        MinBathrooms = searchCriteria.MinBathrooms,
                        MaxBathrooms = searchCriteria.MaxBathrooms,
                        MinSquareFootage = searchCriteria.MinSquareFootage,
                        MaxSquareFootage = searchCriteria.MaxSquareFootage,
                        IsPetFriendly = searchCriteria.IsPetFriendly,
                        HasGarage = searchCriteria.HasGarage,
                        HasPool = searchCriteria.HasPool,
                        HasGarden = searchCriteria.HasGarden,
                        Tags = searchCriteria.Tags,
                        Page = searchCriteria.Page,
                        PageSize = searchCriteria.PageSize,
                        SortBy = searchCriteria.SortBy,
                        SortDirection = searchCriteria.SortDirection
                    }
                };

                var result = await _mediator.Send(query);

                if (result.IsSuccess)
                {
                    return Ok(result.Data);
                }

                return BadRequest(result.Error);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error searching properties");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("recommendations")]
        public async Task<IActionResult> GetRecommendations([FromBody] RecommendationDto recommendation)
        {
            try
            {
                // TODO: Implement AI-powered recommendations
                // This would integrate with an AI service to provide personalized property recommendations
                
                var mockRecommendations = new List<PropertyDto>
                {
                    // Mock data - replace with actual AI service call
                };

                return Ok(new { Recommendations = mockRecommendations, Count = mockRecommendations.Count });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting recommendations");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("price-prediction")]
        public async Task<IActionResult> GetPricePrediction([FromBody] PricePredictionDto prediction)
        {
            try
            {
                // TODO: Implement AI price prediction
                // This would integrate with an AI model to predict property prices
                
                var mockPrediction = new PricePredictionResultDto
                {
                    PredictedPrice = prediction.SquareFootage * 150, // Mock calculation
                    Confidence = 0.85m,
                    PriceRange = $"{prediction.SquareFootage * 120:C} - {prediction.SquareFootage * 180:C}",
                    Factors = new List<string> { "Location", "Size", "Property Type", "Amenities" }
                };

                return Ok(mockPrediction);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting price prediction");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
