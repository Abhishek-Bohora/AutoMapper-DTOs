using AutoMapper;
using MapperApp.Models;
using MapperApp.Models.DTOs.Incoming;

namespace MapperApp.Profiles
{
    public class DriverProfile : Profile
    {
        public DriverProfile()
        {
            CreateMap<DriverForCreationDto, Driver>() // transforming the object from DriverForCreationDto to Driver
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => Guid.NewGuid())
                ).ForMember(
                    dest => dest.FirstName,
                    opt => opt.MapFrom(src => src.FirstName)
                ).ForMember(
                    dest => dest.LastName,
                    opt => opt.MapFrom(src => src.LastName)
                ).ForMember(
                    dest => dest.DriverNumber,
                    opt => opt.MapFrom(src => src.DriverNumber)
                ).ForMember(
                    dest => dest.WorldChampionships,
                    opt => opt.MapFrom(src => src.WorldChampionships)
                ).ForMember(
                    dest => dest.Status,
                    opt => opt.MapFrom(src => 1)
                ).ForMember(
                    dest => dest.DateAdded,
                    opt => opt.MapFrom(src => DateTime.Now)
                ).ForMember(
                    dest => dest.DateUpdated,
                    opt => opt.MapFrom(src => DateTime.Now)
                );
        }
    }
}
