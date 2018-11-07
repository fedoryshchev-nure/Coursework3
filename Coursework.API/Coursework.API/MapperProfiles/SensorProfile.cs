using AutoMapper;
using Core.Models.Origin;
using Coursework.API.DTOs;

namespace Coursework.API.MapperProfiles
{
    public class SensorProfile : Profile
    {
        public SensorProfile()
        {
            CreateMap<Sensor, SensorDTO>()
                .ReverseMap();
        }
    }
}
