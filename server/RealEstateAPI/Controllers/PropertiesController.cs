using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Commands.Properties;
using RealEstate.Application.Queries.Properties;
using RealEstate.Application.DTOs;

namespace RealEstateAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertiesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PropertiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProperties([FromQuery] PropertySearchDto searchCriteria)
        {
            var query = new GetPropertiesQuery { SearchCriteria = searchCriteria };
            var result = await _mediator.Send(query);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Error);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProperty(int id)
        {
            var query = new GetPropertyByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return NotFound(result.Error);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateProperty([FromBody] CreatePropertyDto property)
        {
            var command = new CreatePropertyCommand 
            { 
                Property = property,
                AgentId = User.Identity?.Name ?? string.Empty
            };
            var result = await _mediator.Send(command);

            if (result.IsSuccess)
            {
                return CreatedAtAction(nameof(GetProperty), new { id = result.Data?.Id }, result.Data);
            }

            return BadRequest(result.Error);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateProperty(int id, [FromBody] UpdatePropertyDto property)
        {
            var command = new UpdatePropertyCommand 
            { 
                Id = id,
                Property = property,
                AgentId = User.Identity?.Name ?? string.Empty
            };
            var result = await _mediator.Send(command);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Error);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            var command = new DeletePropertyCommand 
            { 
                Id = id,
                AgentId = User.Identity?.Name ?? string.Empty
            };
            var result = await _mediator.Send(command);

            if (result.IsSuccess)
            {
                return NoContent();
            }

            return BadRequest(result.Error);
        }
    }
}
