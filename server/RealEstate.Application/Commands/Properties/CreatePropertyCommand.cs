using MediatR;
using RealEstate.Application.Common;
using RealEstate.Application.DTOs;

namespace RealEstate.Application.Commands.Properties
{
    public class CreatePropertyCommand : IRequest<Result<PropertyDto>>
    {
        public CreatePropertyDto Property { get; set; } = new();
        public string AgentId { get; set; } = string.Empty;
    }
}
