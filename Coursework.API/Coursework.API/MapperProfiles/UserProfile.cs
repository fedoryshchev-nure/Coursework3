using AutoMapper;
using Core.Models.Origin;
using Coursework.API.DTOs;

namespace Coursework.API.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>()
                .ReverseMap()
                .ForMember(dest => dest.HashedPassword,
                    src => src.MapFrom(x => x.Password.GetHashCode().ToString()));
        }
    }
}
