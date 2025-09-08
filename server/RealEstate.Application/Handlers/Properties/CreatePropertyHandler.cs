using AutoMapper;
using MediatR;
using RealEstate.Application.Common;
using RealEstate.Application.DTOs;
using RealEstate.Application.Commands.Properties;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Application.Handlers.Properties
{
    public class CreatePropertyHandler : IRequestHandler<CreatePropertyCommand, Result<PropertyDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatePropertyHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<PropertyDto>> Handle(CreatePropertyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var property = _mapper.Map<Property>(request.Property);
                property.AgentId = request.AgentId;
                property.CreatedAt = DateTime.UtcNow;
                property.UpdatedAt = DateTime.UtcNow;

                var createdProperty = await _unitOfWork.Properties.AddAsync(property, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                var propertyDto = _mapper.Map<PropertyDto>(createdProperty);
                return Result<PropertyDto>.Success(propertyDto);
            }
            catch (Exception ex)
            {
                return Result<PropertyDto>.Failure($"Error creating property: {ex.Message}");
            }
        }
    }
}
