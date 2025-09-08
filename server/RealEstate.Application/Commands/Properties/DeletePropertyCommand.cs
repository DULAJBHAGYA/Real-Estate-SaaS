using MediatR;
using RealEstate.Application.Common;

namespace RealEstate.Application.Commands.Properties
{
    public class DeletePropertyCommand : IRequest<Result>
    {
        public int Id { get; set; }
        public string AgentId { get; set; } = string.Empty;
    }
}
