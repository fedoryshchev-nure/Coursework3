using AutoMapper;
using Core.Models.Origin;
using Coursework.API.DTOs;
using System;

namespace Coursework.API.MapperProfiles
{
    public class SensorProfile : Profile
    {
        public SensorProfile()
        {
            CreateMap<Sensor, SensorDTO>()
                .ReverseMap()
                .ForMember(dest => dest.PasswordHash, 
                    src => src.MapFrom(x => Int32.Parse(x.Password) % 13));
        }
    }
}
