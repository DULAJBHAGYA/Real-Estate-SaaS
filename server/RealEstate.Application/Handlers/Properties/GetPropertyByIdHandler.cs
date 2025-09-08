using AutoMapper;
using MediatR;
using RealEstate.Application.Common;
using RealEstate.Application.DTOs;
using RealEstate.Application.Queries.Properties;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Application.Handlers.Properties
{
    public class GetPropertyByIdHandler : IRequestHandler<GetPropertyByIdQuery, Result<PropertyDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPropertyByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<PropertyDto>> Handle(GetPropertyByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var property = await _unitOfWork.Properties.GetByIdAsync(request.Id, cancellationToken);
                
                if (property == null)
                {
                    return Result<PropertyDto>.Failure("Property not found");
                }

                var propertyDto = _mapper.Map<PropertyDto>(property);
                return Result<PropertyDto>.Success(propertyDto);
            }
            catch (Exception ex)
            {
                return Result<PropertyDto>.Failure($"Error retrieving property: {ex.Message}");
            }
        }
    }
}
