using Api.Models.Domains;
using Api.Models.DTOs;
using AutoMapper;

namespace Api.Mapping
{
    public class MapperProfile :Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, RegisterRequestDto>().ReverseMap();    
            CreateMap<User, UpdateUserDto>().ReverseMap();
        }
    }
}
