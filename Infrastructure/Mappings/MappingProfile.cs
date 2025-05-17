using AutoMapper;
using Smart_Yard_Manager.Application.DTOs;
using Smart_Yard_Manager.Domain.Entity;

namespace Smart_Yard_Manager.Infrastructure.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Sensor, SensorResponseDto>();
            CreateMap<SensorRequestDto, Sensor>();

            CreateMap<Moviment, MovimentResponseDto>()
                .ForMember(dest => dest.SensorName, opt => opt.MapFrom(src => src.Sensor.Name))
                .ForMember(dest => dest.SensorSection, opt => opt.MapFrom(src => (int)src.Sensor.Section));

            CreateMap<MovimentRequestDto, Moviment>();
        }

    }
}
