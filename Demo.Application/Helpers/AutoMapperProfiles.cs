using AutoMapper;
using Demo.Application.Dtos;
using Demo.Domain.Entities;

namespace Demo.Application.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserDto>();
        }
    }
}
