using MediatR;
using RealEstate.Application.Common;
using RealEstate.Application.DTOs;

namespace RealEstate.Application.Commands.Properties
{
    public class UpdatePropertyCommand : IRequest<Result<PropertyDto>>
    {
        public int Id { get; set; }
        public UpdatePropertyDto Property { get; set; } = new();
        public string AgentId { get; set; } = string.Empty;
    }
}
