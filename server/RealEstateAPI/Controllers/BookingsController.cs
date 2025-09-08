using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.DTOs;
using MediatR;
using System.Security.Claims;

namespace RealEstateAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BookingsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<BookingsController> _logger;

        public BookingsController(IMediator mediator, ILogger<BookingsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingDto booking)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized("User not found");
                }

                // TODO: Implement CreateBookingCommand and handler
                // var command = new CreateBookingCommand { Booking = booking, UserId = userId };
                // var result = await _mediator.Send(command);

                // Mock response for now
                var mockBooking = new BookingDto
                {
                    Id = 1,
                    ScheduledDate = booking.ScheduledDate,
                    StartTime = booking.StartTime,
                    EndTime = booking.EndTime,
                    Notes = booking.Notes,
                    Status = BookingStatus.Pending,
                    ContactPhone = booking.ContactPhone,
                    ContactEmail = booking.ContactEmail,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    PropertyId = booking.PropertyId,
                    PropertyTitle = "Sample Property",
                    PropertyAddress = "123 Main St",
                    ClientId = userId,
                    ClientName = "John Doe",
                    AgentId = "agent123",
                    AgentName = "Jane Smith"
                };

                return CreatedAtAction(nameof(GetBooking), new { id = mockBooking.Id }, mockBooking);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating booking");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetBookings([FromQuery] BookingSearchDto searchCriteria)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized("User not found");
                }

                // TODO: Implement GetBookingsQuery and handler
                // var query = new GetBookingsQuery { SearchCriteria = searchCriteria, UserId = userId };
                // var result = await _mediator.Send(query);

                // Mock response for now
                var mockBookings = new List<BookingDto>
                {
                    new BookingDto
                    {
                        Id = 1,
                        ScheduledDate = DateTime.UtcNow.AddDays(1),
                        StartTime = new TimeSpan(10, 0, 0),
                        EndTime = new TimeSpan(11, 0, 0),
                        Status = BookingStatus.Confirmed,
                        PropertyTitle = "Luxury Apartment",
                        PropertyAddress = "123 Main St",
                        ClientName = "John Doe",
                        AgentName = "Jane Smith"
                    }
                };

                return Ok(new { Bookings = mockBookings, TotalCount = mockBookings.Count });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting bookings");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBooking(int id)
        {
            try
            {
                // TODO: Implement GetBookingByIdQuery and handler
                // var query = new GetBookingByIdQuery { Id = id };
                // var result = await _mediator.Send(query);

                // Mock response for now
                var mockBooking = new BookingDto
                {
                    Id = id,
                    ScheduledDate = DateTime.UtcNow.AddDays(1),
                    StartTime = new TimeSpan(10, 0, 0),
                    EndTime = new TimeSpan(11, 0, 0),
                    Status = BookingStatus.Confirmed,
                    PropertyTitle = "Luxury Apartment",
                    PropertyAddress = "123 Main St",
                    ClientName = "John Doe",
                    AgentName = "Jane Smith"
                };

                return Ok(mockBooking);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting booking");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking(int id, [FromBody] UpdateBookingDto booking)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized("User not found");
                }

                // TODO: Implement UpdateBookingCommand and handler
                // var command = new UpdateBookingCommand { Id = id, Booking = booking, UserId = userId };
                // var result = await _mediator.Send(command);

                return Ok(new { Message = "Booking updated successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating booking");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> CancelBooking(int id)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized("User not found");
                }

                // TODO: Implement CancelBookingCommand and handler
                // var command = new CancelBookingCommand { Id = id, UserId = userId };
                // var result = await _mediator.Send(command);

                return Ok(new { Message = "Booking cancelled successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error cancelling booking");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
