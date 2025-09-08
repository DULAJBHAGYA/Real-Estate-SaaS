using MediatR;
using RealEstate.Application.Common;
using RealEstate.Application.DTOs;

namespace RealEstate.Application.Queries.Properties
{
    public class GetPropertyByIdQuery : IRequest<Result<PropertyDto>>
    {
        public int Id { get; set; }
    }
}
