using AutoMapper;
using RealEstate.Application.DTOs;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User mappings
            CreateMap<ApplicationUser, UserDto>()
                .ForMember(dest => dest.Roles, opt => opt.Ignore());

            // Property mappings
            CreateMap<Property, PropertyDto>()
                .ForMember(dest => dest.AgentName, opt => opt.MapFrom(src => $"{src.Agent.FirstName} {src.Agent.LastName}"));

            CreateMap<CreatePropertyDto, Property>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<UpdatePropertyDto, Property>()
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // PropertyImage mappings
            CreateMap<PropertyImage, PropertyImageDto>();

            // Appointment mappings
            CreateMap<Appointment, AppointmentDto>()
                .ForMember(dest => dest.PropertyTitle, opt => opt.MapFrom(src => src.Property.Title))
                .ForMember(dest => dest.PropertyAddress, opt => opt.MapFrom(src => src.Property.Address))
                .ForMember(dest => dest.ClientName, opt => opt.MapFrom(src => $"{src.Client.FirstName} {src.Client.LastName}"))
                .ForMember(dest => dest.AgentName, opt => opt.MapFrom(src => $"{src.Agent.FirstName} {src.Agent.LastName}"));

            CreateMap<CreateAppointmentDto, Appointment>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => AppointmentStatus.Pending));

            CreateMap<UpdateAppointmentDto, Appointment>()
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
